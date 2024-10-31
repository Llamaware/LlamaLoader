using System.Diagnostics;
using System.IO.Compression;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

public class Deobfuscator
{


    public static async Task<int> DownloadAndExtractDecodeJsAsync(string fileUrl, string extractPath)
    {
        string tempZipPath = Path.Combine(Path.GetTempPath(), "decode-js-temp.zip");

        try
        {
            using (HttpClient client = new HttpClient { Timeout = TimeSpan.FromMinutes(3) }) // Increased timeout
            {
                // Download the ZIP file to a temporary file on disk
                using (var response = await client.GetAsync(fileUrl, HttpCompletionOption.ResponseHeadersRead))
                {
                    response.EnsureSuccessStatusCode();

                    // Stream the file to disk to avoid memory issues
                    using (var fileStream = new FileStream(tempZipPath, FileMode.Create, FileAccess.Write, FileShare.None, bufferSize: 81920, useAsync: true))
                    {
                        await response.Content.CopyToAsync(fileStream);
                    }
                }
            }

            // Ensure the extraction directory exists
            if (!Directory.Exists(extractPath))
            {
                Directory.CreateDirectory(extractPath);
            }

            // Extract the ZIP file contents to the specified directory
            using (var archive = ZipFile.OpenRead(tempZipPath))
            {
                // Get the root folder name by finding the first entry's path
                var rootFolderName = archive.Entries[0].FullName.Split('/')[0];

                foreach (var entry in archive.Entries)
                {
                    // Skip the root folder itself
                    if (string.IsNullOrEmpty(entry.Name)) continue;

                    // Remove the root folder prefix and build the destination path
                    var relativePath = entry.FullName.Substring(rootFolderName.Length + 1);
                    var destinationPath = Path.Combine(extractPath, relativePath);

                    if (entry.FullName.EndsWith("/"))
                    {
                        Directory.CreateDirectory(destinationPath);
                    }
                    else
                    {
                        // Ensure the directory structure exists for the file
                        Directory.CreateDirectory(Path.GetDirectoryName(destinationPath)!);

                        // Delete the file if it exists to enable overwriting
                        if (File.Exists(destinationPath))
                        {
                            File.Delete(destinationPath);
                        }

                        // Extract the file
                        entry.ExtractToFile(destinationPath, overwrite: true);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
        finally
        {
            // Clean up temporary ZIP file
            if (File.Exists(tempZipPath))
            {
                File.Delete(tempZipPath);
            }
        }
        return 0;
    }

    public static async Task<int> InstallDecodeJs(string installPath, Action<string> outputHandler)
    {
        try
        {
            // create a new process
            Process process = new Process();

            // set the process start info
            process.StartInfo.FileName = "cmd.exe"; // specify the command to run
            process.StartInfo.Arguments = "/c npm install"; // specify the arguments

            // set additional process start info as necessary
            process.StartInfo.WorkingDirectory = installPath;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.CreateNoWindow = true;

            process.OutputDataReceived += (sender, e) => { if (e.Data != null) outputHandler(e.Data); };
            process.ErrorDataReceived += (sender, e) => { if (e.Data != null) outputHandler("Error: " + e.Data); };

            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();

            await Task.Run(() => process.WaitForExit());

            // print the output
            //File.WriteAllText("log.txt", "Output:\n" + output + "\n\nError:\n" + error);
            return process.ExitCode;
        }
        catch (Exception ex)
        {
            //File.WriteAllText("log.txt", "Error: " + ex.Message + Environment.NewLine + ex.StackTrace);
            Console.WriteLine("An error occurred: " + ex.Message);
            return -1;
        }

    }

    public static async Task<int> RunDecodeJs(string installPath, string inputPath, string outputPath, string decodeType, Action<string> outputHandler)
    {
        try
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = $"/c npm run decode -- -t {decodeType} -i \"{inputPath}\" -o \"{outputPath}\"";
            process.StartInfo.WorkingDirectory = installPath;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.CreateNoWindow = true;

            // Set the encoding to UTF-8 to handle Chinese characters properly
            process.StartInfo.StandardOutputEncoding = Encoding.UTF8;
            process.StartInfo.StandardErrorEncoding = Encoding.UTF8;

            process.OutputDataReceived += (sender, e) => { if (e.Data != null) outputHandler(e.Data); };
            process.ErrorDataReceived += (sender, e) => { if (e.Data != null) outputHandler("Error: " + e.Data); };

            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();

            await Task.Run(() => process.WaitForExit());

            return process.ExitCode;
        }
        catch (Exception ex)
        {
            outputHandler("An error occurred: " + ex.Message);
            return -1;
        }
    }

    public static async Task<string> CheckNodeVersionAsync()
    {
        try
        {
            using (Process process = new Process())
            {
                process.StartInfo.FileName = "node";
                process.StartInfo.Arguments = "-v"; // Command to get the Node.js version
                process.StartInfo.UseShellExecute = false; // Do not use the shell to execute
                process.StartInfo.RedirectStandardOutput = true; // Redirect output to capture it
                process.StartInfo.RedirectStandardError = true; // Redirect error output
                process.StartInfo.CreateNoWindow = true; // Hide the command window

                // Start the process
                process.Start();

                // Asynchronously read the output
                string output = await process.StandardOutput.ReadToEndAsync();
                string error = await process.StandardError.ReadToEndAsync();

                // Wait for the process to exit
                await Task.Run(() => process.WaitForExit());

                // Check if there was an error
                if (!string.IsNullOrEmpty(error))
                {
                    return $"Error: {error.Trim()}"; // Return any error encountered
                }

                return output.Trim(); // Return the output, which is the Node.js version
            }
        }
        catch (Exception ex)
        {
            return $"An error occurred: {ex.Message}"; // Handle any exceptions
        }
    }
    public static int UpdateIsolatedVm(string filePath)
    {
        string packagePath = Path.Combine(filePath, "package.json");
        string packageLockPath = Path.Combine(filePath, "package-lock.json");

        if (File.Exists(packageLockPath))
        {
            File.Delete(packageLockPath);
        }

        // Read and deserialize the package.json file
        var jsonString = File.ReadAllText(packagePath);
        var packageData = JsonSerializer.Deserialize<DecodeJsPackageJson>(jsonString);

        // Update isolated-vm dependency version
        const string dependencyToUpdate = "isolated-vm";
        const string newVersion = "^5.0.1";

        if (packageData.Dependencies.ContainsKey(dependencyToUpdate))
        {
            packageData.Dependencies[dependencyToUpdate] = newVersion;
            //Console.WriteLine($"Updated {dependencyToUpdate} to version {newVersion}");
        }
        else
        {
            //Console.WriteLine($"{dependencyToUpdate} dependency not found.");
        }

        // Serialize and write the updated JSON back to package.json
        var updatedJson = JsonSerializer.Serialize(packageData, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(packagePath, updatedJson);

        //Console.WriteLine("package.json has been updated successfully.");
        return 0;
    }

    public class DecodeJsPackageJson
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("scripts")]
        public Dictionary<string, string> Scripts { get; set; }

        [JsonPropertyName("dependencies")]
        public Dictionary<string, string> Dependencies { get; set; }
    }
}

