using System.Text;

public class Decryptor
{
    public static async Task<int> DecryptGame(string gameDirectory, string outputDirectory)
    {
        string[] dirInputs = { Path.Combine("www", "img"), Path.Combine("www", "audio"), Path.Combine("www", "data") };

        var decryptTasks = dirInputs.Select(async folder =>
        {
            string fullFolderPath = Path.Combine(gameDirectory, folder);
            if (Directory.Exists(fullFolderPath))
            {
                //Console.WriteLine($"Decrypting files in directory: {folder}");

                string[] fileList = Directory.GetFiles(fullFolderPath, "*.k9a", SearchOption.AllDirectories);

                // Use Parallel.ForEachAsync for concurrent decryption of files.
                await Parallel.ForEachAsync(fileList, async (f, cancellationToken) =>
                {
                    try
                    {
                        // Read the file asynchronously.
                        byte[] rawData = await File.ReadAllBytesAsync(f, cancellationToken);

                        // Determine the file extension and decrypt the file.
                        string fileExtension = GetFileExtension(rawData);
                        byte[] decryptedFile = DecryptFile(rawData, f);

                        // If decryption fails, handle the failure.
                        if (decryptedFile.Length == 1)
                        {
                            DecryptionFailure(f);
                        }
                        else
                        {
                            // Construct the output path for the decrypted file.
                            string decryptedFilename = Path.Combine(outputDirectory, Path.GetRelativePath(gameDirectory, f));
                            string directoryToCreate = Path.GetDirectoryName(decryptedFilename);

                            // Create the output directory if it doesn't exist.
                            if (directoryToCreate != null)
                            {
                                Directory.CreateDirectory(directoryToCreate);
                            }

                            // Set the new filename with the correct extension.
                            string newFilename = Path.ChangeExtension(decryptedFilename, fileExtension);

                            // Write the decrypted file asynchronously.
                            await File.WriteAllBytesAsync(newFilename, decryptedFile, cancellationToken);

                            //Console.WriteLine("File decrypted and saved to: " + newFilename);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle any exceptions that occur during file processing.
                        Console.WriteLine($"Error processing file {f}: {ex.Message}");
                    }
                });
            }
        });

        // Wait for the current set of decryption tasks to complete.
        await Task.WhenAll(decryptTasks);
        return 0;
    }
    static void DecryptionFailure(string userIn)
    {
        Console.WriteLine("Decryption failed. File was NOT decrypted: " + userIn);
    }
    static string GetFileExtension(byte[] data)
    {
        int headerLength = data[0];
        return Encoding.ASCII.GetString(data, 1, headerLength);
    }
    static int Mask(string inputString)
    {
        int maskValue = 0;
        string decodedFilename = Path.GetFileNameWithoutExtension(inputString).ToUpper();
        foreach (char c in decodedFilename)
        {
            maskValue = (maskValue << 1) ^ c;
        }
        return maskValue;
    }
    static byte[] DecryptFile(byte[] data, string url)
    {
        if (!url.EndsWith(".k9a"))
        {
            byte[] empty = { 0 };
            return empty;
        }

        int headerLength = data[0];
        int dataLength = data[1 + headerLength];
        byte[] encryptedData = new byte[data.Length - 2 - headerLength];
        Array.Copy(data, 2 + headerLength, encryptedData, 0, encryptedData.Length);
        int newMask = Mask(url);

        if (dataLength == 0)
        {
            dataLength = encryptedData.Length;
        }

        byte[] decryptedData = encryptedData;

        for (int i = 0; i < dataLength; i++)
        {
            byte encryptedByte = encryptedData[i];
            decryptedData[i] = (byte)((encryptedByte ^ newMask) % 256);
            newMask = newMask << 1 ^ encryptedByte;
        }

        return decryptedData;
    }
    static string[] GetFiles(string sourceFolder, string filters, SearchOption searchOption)
    {
        return filters.Split('|').SelectMany(filter => Directory.GetFiles(sourceFolder, filter, searchOption)).ToArray();
    }
}

