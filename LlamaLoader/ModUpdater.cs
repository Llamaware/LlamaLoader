using AngleSharp;

public class ModUpdater
{
    public class Mod
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Version { get; set; }
        public string Description { get; set; }
    }

    public static async Task<List<Mod>> ParseModsFromPage(string url)
    {
        var mods = new List<Mod>();

        using (HttpClient client = new HttpClient())
        {
            string htmlContent = await client.GetStringAsync(url);

            // Configure AngleSharp
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);

            // Load HTML document
            var document = await context.OpenAsync(req => req.Content(htmlContent));

            // Select each mod article
            var modArticles = document.QuerySelectorAll("article.mod");

            foreach (var article in modArticles)
            {
                // Attempt to retrieve the mod name
                var nameElement = article.QuerySelector("h1 a");
                var name = nameElement?.TextContent.Trim() ?? "Unnamed Mod";

                // Attempt to retrieve the version
                var versionElement = article.QuerySelector("h1 .version");
                var version = versionElement?.TextContent.Trim() ?? "No Version";

                // Attempt to retrieve the description
                var descriptionElement = article.QuerySelector("p");
                var description = descriptionElement?.TextContent.Trim() ?? "No Description";

                // Attempt to retrieve the download URL specifically from the "links" div
                var linksDiv = article.QuerySelector("div.links");
                // Check for any <a> tags with href containing ".zip"
                var downloadLink = linksDiv?.QuerySelector("a.link")?.GetAttribute("href");
                if (!string.IsNullOrEmpty(downloadLink) && downloadLink.Contains(".zip"))
                {
                    // Ensure the link is fully qualified if it's a relative path
                    if (!downloadLink.StartsWith("http"))
                    {
                        var baseUri = new Uri(url);
                        downloadLink = new Uri(baseUri, downloadLink).ToString();
                    }

                    // Create a new Mod object and add it to the list
                    mods.Add(new Mod
                    {
                        Name = name,
                        Version = version,
                        Description = description,
                        Url = downloadLink
                    });
                }
            }
        }

        return mods;
    }

    public static async Task<int> InstallMods(List<Mod> modsToInstall, string modDirectory)
    {
        int result = 0;
        foreach (var mod in modsToInstall)
        {
            int downloadModResult = await DownloadAndSaveModAsync(mod.Url, modDirectory);
            if (downloadModResult != 0)
            {
                result = -1;
            }
        }
        return result;
    }

    public static async Task<int> DownloadAndSaveModAsync(string modUrl, string saveDirectory)
    {
        // Validate the URL and save directory
        if (string.IsNullOrWhiteSpace(modUrl))
        {
            return -1;
        }

        if (!Directory.Exists(saveDirectory))
        {
            return -2;
        }

        try
        {
            using (HttpClient client = new HttpClient())
            {
                // Start the download
                byte[] modData = await client.GetByteArrayAsync(modUrl);

                // Determine the file name from the URL
                string fileName = Path.GetFileName(new Uri(modUrl).AbsolutePath);
                string filePath = Path.Combine(saveDirectory, fileName);

                // Save the file
                await File.WriteAllBytesAsync(filePath, modData);
                return 0;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to download or save the mod. Error: {ex.Message}");
            return 1;
        }
    }
}

