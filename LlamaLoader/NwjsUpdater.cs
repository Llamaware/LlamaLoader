
using System.IO.Compression;

public class NwjsUpdater
{
    public static async Task<int> DownloadAndExtractNwjsAsync(string fileUrl, string extractPath)
    {
        string tempZipPath = Path.Combine(Path.GetTempPath(), "nwjs-temp.zip");

        try
        {
            using (HttpClient client = new HttpClient { Timeout = TimeSpan.FromMinutes(30) }) // Increased timeout
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

    public static int UpdateGameExe(string gameDirectory)
    {
        string gameExePath = Path.Combine(gameDirectory, "Game.exe");
        string nwExePath = Path.Combine(gameDirectory, "nw.exe");
        File.Move(nwExePath, gameExePath, overwrite: true);
        return 0;
    }
}