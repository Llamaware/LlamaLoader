using System;
using System.IO.Compression;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text.RegularExpressions;
using AngleSharp;

public class TombUpdater
{
    public static async Task<string> GetNewestTombUrl(string url)
    {
        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync(url);
            string htmlContent = await response.Content.ReadAsStringAsync();

            // Configure AngleSharp
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);

            // Load HTML document
            var document = await context.OpenAsync(req => req.Content(htmlContent));

            // Regular expression to capture versions like v0.6.0 or v0.6.0-beta
            var versionRegex = new Regex(@"v(\d+\.\d+\.\d+(?:-beta)?)");

            // List to hold download links with their version information
            var downloadLinks = new List<(string url, string version)>();

            // Select all anchor tags with download links
            var downloadElements = document.QuerySelectorAll("a[href][download]");

            foreach (var element in downloadElements)
            {
                var href = element.GetAttribute("href");
                var match = versionRegex.Match(href);

                if (match.Success)
                {
                    var version = match.Value;
                    downloadLinks.Add((href, version));
                }
            }

            // Sort download links by version
            var latestDownload = downloadLinks
                .OrderByDescending(link => ParseVersion(link.version))
                .FirstOrDefault();

            return latestDownload.url ?? null;
        }
    }

    private static Version ParseVersion(string versionString)
    {
        // Remove the "v" and "-beta" suffix if present
        versionString = versionString.TrimStart('v').Replace("-beta", "");
        return Version.TryParse(versionString, out var version) ? version : new Version();
    }

    public static async Task<int> DownloadAndExtractZipAsync(string fileUrl, string extractPath)
    {
        using (HttpClient client = new HttpClient())
        {
            // Download the ZIP file into a memory stream
            using (var response = await client.GetAsync(fileUrl))
            {
                response.EnsureSuccessStatusCode();

                using (var zipStream = await response.Content.ReadAsStreamAsync())
                {
                    // Create the extraction directory if it doesn't exist
                    if (!Directory.Exists(extractPath))
                    {
                        return -1;
                    }

                    // Extract the ZIP file contents to the specified directory
                    using (var archive = new ZipArchive(zipStream))
                    {
                        archive.ExtractToDirectory(extractPath, overwriteFiles: true);
                    }
                }
            }
        }
        return 0;
    }

    public static async Task<int> UpdateMainFieldInPackageJson(string gameDirectory)
    {
        string packageJsonPath = Path.Combine(gameDirectory, "package.json");
        if (!File.Exists(packageJsonPath))
        {
            return -1;
        }

        // Read the file content
        string jsonContent = await File.ReadAllTextAsync(packageJsonPath);

        // Parse the JSON content into a dynamic object
        var jsonDocument = JsonDocument.Parse(jsonContent);
        var root = jsonDocument.RootElement;

        // Extract the current "main" value
        var mainProperty = root.TryGetProperty("main", out var mainValue) ? mainValue.GetString() : null;

        // Check if "main" equals "www/index.html" and update it if necessary
        if (mainProperty == "www/index.html")
        {
            // Deserialize, update, and re-serialize JSON content with the updated "main" value
            var options = new JsonSerializerOptions { WriteIndented = true };
            var packageData = JsonSerializer.Deserialize<PackageJson>(jsonContent, options);

            packageData.Main = "tomb/index.html";

            // Write the modified JSON back to the file
            await File.WriteAllTextAsync(packageJsonPath, JsonSerializer.Serialize(packageData, options));
            return 1;
        }
        else
        {
            return 0;
        }
    }

    public class PackageJson
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("main")]
        public string Main { get; set; }

        [JsonPropertyName("js-flags")]
        public string JsFlags { get; set; }

        [JsonPropertyName("window")]
        public Window Window { get; set; }
    }

    public class Window
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("toolbar")]
        public bool Toolbar { get; set; }

        [JsonPropertyName("width")]
        public int Width { get; set; }

        [JsonPropertyName("height")]
        public int Height { get; set; }

        [JsonPropertyName("icon")]
        public string Icon { get; set; }
    }

}