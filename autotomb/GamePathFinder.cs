using Microsoft.Win32;
using System;
using System.IO;
using System.Text.RegularExpressions;

public class GamePathFinder
{
    public static string GetSteamInstallPath()
    {
        try
        {
            using (RegistryKey regKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Valve\Steam"))
            {
                if (regKey == null)
                {
                    throw new FileNotFoundException("Steam not found in registry.");
                }
                return regKey.GetValue("InstallPath").ToString();
            }
        }
        catch (Exception ex)
        {
            throw new FileNotFoundException("Steam not found in registry.", ex);
        }
    }

    public static string GetGameInstallPath()
    {
        try
        {
            string steamPath = GetSteamInstallPath();
            string libraryFile = Path.Combine(steamPath, "steamapps", "libraryfolders.vdf");

            if (!File.Exists(libraryFile))
            {
                throw new FileNotFoundException("libraryfolders.vdf not found.");
            }

            string content = File.ReadAllText(libraryFile);
            var libraryPaths = new Regex("\"path\"\\s+\"([^\"]+)\"").Matches(content);
            var pathsList = new List<string> { steamPath };

            foreach (Match match in libraryPaths)
            {
                pathsList.Add(match.Groups[1].Value);
            }

            foreach (string libraryPath in pathsList)
            {
                string gamePath = Path.Combine(libraryPath, "steamapps", "common", "The Coffin of Andy and Leyley");
                string fullPath = Path.GetFullPath(gamePath);
                if (Directory.Exists(fullPath))
                {
                    return fullPath;
                }
            }

            return null;
        }
        catch (Exception ex)
        {
            throw new Exception("Error occurred while detecting the game path.", ex);
        }
    }
}
