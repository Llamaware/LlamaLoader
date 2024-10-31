using System.Text.RegularExpressions;

public class Extractor
{
    public static int InjectCode(string inputFilePath, string outputFilePath, string functionPattern, string replacementContent)
    {
        // Read the JavaScript file
        string jsContent = File.ReadAllText(inputFilePath);

        // Perform the replacement
        string modifiedContent = Regex.Replace(jsContent, functionPattern, replacementContent, RegexOptions.Singleline);

        // Write the modified content to a new file
        File.WriteAllText(outputFilePath, modifiedContent);

        Console.WriteLine("Modified JavaScript file has been saved to " + outputFilePath);
        return 0;
    }

    public static string FindFileWithExactMatch(string directoryPath, string searchString)
    {
        // Ensure the directory exists
        if (!Directory.Exists(directoryPath))
        {
            throw new DirectoryNotFoundException($"Directory not found: {directoryPath}");
        }

        // Get all JavaScript files in the directory
        string[] jsFiles = Directory.GetFiles(directoryPath, "*.js", SearchOption.AllDirectories);

        // Iterate through each JavaScript file
        foreach (string filePath in jsFiles)
        {
            // Read the content of the file
            string fileContent = File.ReadAllText(filePath);

            // Check if the file contains the exact match
            if (fileContent.Contains(searchString))
            {
                return filePath;
            }
        }

        // If no file was found, return null
        return null;
    }
}
