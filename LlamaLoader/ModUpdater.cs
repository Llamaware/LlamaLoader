using System.Text.Json;

public class ModUpdater
{
    public class Mod
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Version { get; set; }
        public string Description { get; set; }
    }

    public class ModItem
    {
        public ModData Data { get; set; }
        public ModJson ModJson { get; set; }
    }

    public class ModData
    {
        public DateTime LastUpdate { get; set; }
        public string Url { get; set; }
        public string Source { get; set; }
        public string Sha256 { get; set; }
        public string Id { get; set; }
    }

    public class ModJson
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Authors { get; set; }
        public string Version { get; set; }
    }


    public static async Task<List<Mod>> ParseModsFromPage(string url)
    {
        var mods = new List<Mod>();

        using (HttpClient client = new HttpClient())
        {
            // Get the JSON content from the given URL.
            string jsonContent = await client.GetStringAsync(url);

            // Deserialize the JSON into a list of ModItem objects.
            // Notice the case-insensitivity so it matches our JSON keys even though our C# properties are PascalCase.
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var modItems = JsonSerializer.Deserialize<List<ModItem>>(jsonContent, options);

            // Loop through each item and add it to the mods list.
            if (modItems != null)
            {
                foreach (var item in modItems)
                {
                    mods.Add(new Mod
                    {
                        Name = item.ModJson?.Name ?? "Unnamed Mod",
                        Version = item.ModJson?.Version ?? "No Version",
                        Description = item.ModJson?.Description ?? "No Description",
                        Url = item.Data?.Url // This is where the download URL comes from.
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

