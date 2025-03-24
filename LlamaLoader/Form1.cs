using System.Diagnostics;
using static ModUpdater;

namespace LlamaLoader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void disableAllButtons()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
            button10.Enabled = false;
            button11.Enabled = false;
            button12.Enabled = false;
            button13.Enabled = false;
            button14.Enabled = false;
            button15.Enabled = false;
            button16.Enabled = false;
            button17.Enabled = false;
            button18.Enabled = false;
            button19.Enabled = false;
        }

        private void enableAllButtons()
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            button10.Enabled = true;
            button11.Enabled = true;
            button12.Enabled = true;
            button13.Enabled = true;
            button14.Enabled = true;
            button15.Enabled = true;
            button16.Enabled = true;
            button17.Enabled = true;
            button18.Enabled = true;
            button19.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dlg = new FolderPicker();
            dlg.InputPath = @"C:\";
            if (dlg.ShowDialog(button1.Handle) == true)
            {
                textBox2.Text = dlg.ResultPath;
                textBox14.Text = Path.Combine(dlg.ResultPath, "decrypted");
                textBox16.Text = Path.Combine(dlg.ResultPath, "decode-js");
                textBox23.Text = Path.Combine(dlg.ResultPath, "www", "js", "plugins");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("Attempting to find The Coffin of Andy and Leyley..." + Environment.NewLine);
            string gameDirectory = GamePathFinder.GetGameInstallPath();
            if (gameDirectory != null)
            {
                textBox1.AppendText("Detected game directory at: " + gameDirectory + Environment.NewLine);
                textBox2.Text = gameDirectory;
                textBox14.Text = Path.Combine(gameDirectory, "decrypted");
                textBox16.Text = Path.Combine(gameDirectory, "decode-js");
                textBox23.Text = Path.Combine(gameDirectory, "www", "js", "plugins");
            }
            else
            {
                textBox1.AppendText("Failed to detect the game directory. Please select it manually." + Environment.NewLine);
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            string gameDirectory = textBox2.Text;
            string tombReleasesUrl = textBox3.Text;
            if (!Directory.Exists(gameDirectory))
            {
                textBox1.AppendText("Error: No game directory selected or nonexistent directory. Stopping." + Environment.NewLine);
                return;
            }
            if (string.IsNullOrEmpty(tombReleasesUrl))
            {
                textBox1.AppendText("Error: Invalid Tomb URL. Stopping." + Environment.NewLine);
                return;
            }
            textBox1.AppendText("Getting the newest Tomb version from: " + tombReleasesUrl + Environment.NewLine);
            string newestTombUrlResult = await TombUpdater.GetNewestTombUrl(tombReleasesUrl);
            if (newestTombUrlResult != null)
            {
                textBox1.AppendText("Found Tomb at: " + newestTombUrlResult + Environment.NewLine);
            }
            else
            {
                textBox1.AppendText("An error occurred while finding Tomb. Stopping." + Environment.NewLine);
                return;
            }
            textBox1.AppendText("Downloading and extracting Tomb to game directory..." + Environment.NewLine);
            string tombDirectory = Path.Combine(gameDirectory, "tomb");
            if (!Directory.Exists(tombDirectory))
            {
                textBox1.AppendText("Creating Tomb installation..." + Environment.NewLine);
                Directory.CreateDirectory(tombDirectory);
            }
            else
            {
                textBox1.AppendText("Existing Tomb installation found, updating..." + Environment.NewLine);
            }
            int downloadTombResult = await TombUpdater.DownloadAndExtractZipAsync(newestTombUrlResult, tombDirectory);
            if (downloadTombResult == 0)
            {
                textBox1.AppendText("Successfully downloaded and extracted Tomb to the game directory." + Environment.NewLine);
            }
            else
            {
                textBox1.AppendText("An error occurred while attempting to download or extract Tomb. Stopping." + Environment.NewLine);
                return;
            }
            textBox1.AppendText("Checking package.json..." + Environment.NewLine);
            int indexUpdateResult = await TombUpdater.UpdateMainFieldInPackageJson(gameDirectory);
            if (indexUpdateResult == 1)
            {
                textBox1.AppendText("Updated main to tomb/index.html" + Environment.NewLine);
                textBox1.AppendText("Modloader installation complete!" + Environment.NewLine);
            }
            else if (indexUpdateResult == -1)
            {
                textBox1.AppendText("Error: package.json not found at specified path. Stopping." + Environment.NewLine);
                return;
            }
            else
            {
                textBox1.AppendText("Tomb was already installed, no changes necessary." + Environment.NewLine);
                textBox1.AppendText("Modloader update complete!" + Environment.NewLine);
            }
        }

        private List<Mod> mods = new List<Mod>();
        private async void button4_Click(object sender, EventArgs e)
        {
            string modRepoUrl = textBox4.Text;
            textBox1.AppendText("Parsing mod list from: " + modRepoUrl + Environment.NewLine);
            mods = await ModUpdater.ParseModsFromPage(modRepoUrl);
            if (mods == null)
            {
                textBox1.AppendText("Error occurred parsing the mod list. Stopping." + Environment.NewLine);
                return;
            }
            checkedListBox1.Items.Clear();
            foreach (var mod in mods)
            {
                textBox1.AppendText("Found mod: " + mod.Name + " " + mod.Version + Environment.NewLine);
                checkedListBox1.Items.Add(mod.Name);
            }
        }


        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkedListBox1.SelectedIndex != -1)
            {
                // Get the selected mod based on the index
                var selectedMod = mods[checkedListBox1.SelectedIndex];
                textBox5.Clear();
                textBox5.AppendText($"Version: {selectedMod.Version}" + Environment.NewLine);
                textBox5.AppendText($"Description: {selectedMod.Description}");
            }
            else
            {
                // Clear labels if no mod is selected
                textBox5.Clear();
            }
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            string gameDirectory = textBox2.Text;
            if (!Directory.Exists(gameDirectory))
            {
                textBox1.AppendText("Error: No game directory selected or nonexistent directory. Stopping." + Environment.NewLine);
                return;
            }
            string modFolder = Path.Combine(gameDirectory, "tomb", "mods");
            if (!Directory.Exists(modFolder))
            {
                textBox1.AppendText("Error: mods folder not found. Is Tomb not installed? Stopping." + Environment.NewLine);
                return;
            }
            var selectedMods = checkedListBox1.CheckedItems.Cast<string>().ToList();

            if (selectedMods.Count > 0)
            {
                disableAllButtons();
                textBox1.AppendText("Downloading and installing selected mods, please wait..." + Environment.NewLine);
                var modsToInstall = mods.Where(mod => selectedMods.Contains(mod.Name)).ToList();

                // Trigger the installation process
                int installResult = await ModUpdater.InstallMods(modsToInstall, modFolder);
                if (installResult == 0)
                {
                    textBox1.AppendText("Mods installed: ");
                    foreach (var mod in selectedMods)
                    {
                        textBox1.AppendText(mod + ", ");
                    }
                    textBox1.AppendText(Environment.NewLine);
                }
                else
                {
                    textBox1.AppendText("An error occurred while attempting to download or install one or more mods." + Environment.NewLine);
                    enableAllButtons();
                    return;
                }
            }
            else
            {
                textBox1.AppendText("Please select one or more mods to install." + Environment.NewLine);
                return;
            }

            textBox1.AppendText("Installation complete!" + Environment.NewLine);
            enableAllButtons();
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            bool errors = false;
            string gameDirectory = textBox2.Text;
            string nwjsUrl = textBox6.Text;
            string greenworksUrl = textBox7.Text;
            string steamapiUrl = textBox12.Text;
            string appticketUrl = textBox13.Text;
            if (!Directory.Exists(gameDirectory))
            {
                textBox1.AppendText("Error: No game directory selected or nonexistent directory. Stopping." + Environment.NewLine);
                return;
            }
            if (string.IsNullOrEmpty(nwjsUrl))
            {
                textBox1.AppendText("Error: Invalid NW.js URL. Stopping." + Environment.NewLine);
                return;
            }
            if (string.IsNullOrEmpty(greenworksUrl))
            {
                textBox1.AppendText("Error: Invalid Greenworks URL. Stopping." + Environment.NewLine);
                return;
            }
            if (string.IsNullOrEmpty(steamapiUrl))
            {
                textBox1.AppendText("Error: Invalid steam_api.dll URL. Stopping." + Environment.NewLine);
                return;
            }
            if (string.IsNullOrEmpty(appticketUrl))
            {
                textBox1.AppendText("Error: Invalid sdkencryptedappticket.dll URL. Stopping." + Environment.NewLine);
                return;
            }
            disableAllButtons();
            textBox1.AppendText("Downloading and installing NW.js (32-bit). This will take a while, please be patient..." + Environment.NewLine);
            textBox1.AppendText("Closing the program during this operation may result in corruption of the game files!" + Environment.NewLine);
            int installNwjsResult = await NwjsUpdater.DownloadAndExtractNwjsAsync(nwjsUrl, gameDirectory);
            if (installNwjsResult == 0)
            {
                textBox1.AppendText("NW.js installed." + Environment.NewLine);
            }
            else
            {
                textBox1.AppendText("Error: Failed to download or install NW.js. Stopping." + Environment.NewLine);
                enableAllButtons();
                return;
            }
            textBox1.AppendText("Updating Game.exe..." + Environment.NewLine);
            int updateGameExeResult = NwjsUpdater.UpdateGameExe(gameDirectory);
            if (updateGameExeResult == 0)
            {
                textBox1.AppendText("Game.exe updated." + Environment.NewLine);
            }
            else
            {
                textBox1.AppendText("Error: Failed to move nw.exe to Game.exe. You may need to launch the game manually using nw.exe. Attempting to continue..." + Environment.NewLine);
                errors = true;
            }
            textBox1.AppendText("Installing matching 32-bit version of Greenworks..." + Environment.NewLine);
            string greenworksDirectory = Path.Combine(gameDirectory, "www", "greenworks");
            int installGreenworksResult = await TombUpdater.DownloadAndExtractZipAsync(greenworksUrl, greenworksDirectory);
            if (installGreenworksResult == 0)
            {
                textBox1.AppendText("Greenworks installed." + Environment.NewLine);
            }
            else
            {
                textBox1.AppendText("Error: Failed to download or install Greenworks. The game might not launch!" + Environment.NewLine);
                textBox1.AppendText("Install Greenworks manually, or re-install your game and try again." + Environment.NewLine);
                errors = true;
            }
            textBox1.AppendText("Installing 32-bit Steam DLLs..." + Environment.NewLine);
            string greenworksLibDirectory = Path.Combine(greenworksDirectory, "lib");
            int installSteamapiResult = await ModUpdater.DownloadAndSaveModAsync(steamapiUrl, greenworksLibDirectory);
            if (installSteamapiResult == 0)
            {
                textBox1.AppendText("steam_api.dll installed to lib." + Environment.NewLine);
            }
            else
            {
                textBox1.AppendText("Error: Failed to download or install steam_api.dll." + Environment.NewLine);
                textBox1.AppendText("Install steam_api.dll manually, or re-install your game and try again, making sure the URLs are valid." + Environment.NewLine);
                errors = true;
            }
            int installAppticketResult = await ModUpdater.DownloadAndSaveModAsync(appticketUrl, greenworksLibDirectory);
            if (installAppticketResult == 0)
            {
                textBox1.AppendText("sdkencryptedappticket.dll installed to lib." + Environment.NewLine);
            }
            else
            {
                textBox1.AppendText("Error: Failed to download or install sdkencryptedappticket.dll." + Environment.NewLine);
                textBox1.AppendText("Install sdkencryptedappticket.dll manually, or re-install your game and try again, making sure the URLs are valid." + Environment.NewLine);
                errors = true;
            }
            if (!errors)
            {
                textBox1.AppendText("NW.js (32-bit) upgrade complete!" + Environment.NewLine);
            }
            else
            {
                textBox1.AppendText("NW.js (32-bit) upgrade completed with one or more errors. The game might not launch!" + Environment.NewLine);
            }
            enableAllButtons();
        }

        private async void button7_Click(object sender, EventArgs e)
        {
            string gameDirectory = textBox2.Text;
            bool errors = false;
            if (!Directory.Exists(gameDirectory))
            {
                textBox1.AppendText("Error: No game directory selected or nonexistent directory. Stopping." + Environment.NewLine);
                return;
            }
            string nwjsUrl = textBox8.Text;
            string greenworksUrl = textBox9.Text;
            string steamapiUrl = textBox10.Text;
            string appticketUrl = textBox11.Text;
            if (string.IsNullOrEmpty(nwjsUrl))
            {
                textBox1.AppendText("Error: Invalid NW.js URL. Stopping." + Environment.NewLine);
                return;
            }
            if (string.IsNullOrEmpty(greenworksUrl))
            {
                textBox1.AppendText("Error: Invalid Greenworks URL. Stopping." + Environment.NewLine);
                return;
            }
            if (string.IsNullOrEmpty(steamapiUrl))
            {
                textBox1.AppendText("Error: Invalid steam_api64.dll URL. Stopping." + Environment.NewLine);
                return;
            }
            if (string.IsNullOrEmpty(appticketUrl))
            {
                textBox1.AppendText("Error: Invalid sdkencryptedappticket64.dll URL. Stopping." + Environment.NewLine);
                return;
            }
            disableAllButtons();
            textBox1.AppendText("Downloading and installing NW.js (64-bit). This will take a while, please be patient..." + Environment.NewLine);
            textBox1.AppendText("Closing the program during this operation may result in corruption of the game files!" + Environment.NewLine);
            int installNwjsResult = await NwjsUpdater.DownloadAndExtractNwjsAsync(nwjsUrl, gameDirectory);
            if (installNwjsResult == 0)
            {
                textBox1.AppendText("NW.js installed." + Environment.NewLine);
            }
            else
            {
                textBox1.AppendText("Error: Failed to download or install NW.js. Stopping." + Environment.NewLine);
                enableAllButtons();
                return;
            }
            textBox1.AppendText("Updating Game.exe..." + Environment.NewLine);
            int updateGameExeResult = NwjsUpdater.UpdateGameExe(gameDirectory);
            if (updateGameExeResult == 0)
            {
                textBox1.AppendText("Game.exe updated." + Environment.NewLine);
            }
            else
            {
                textBox1.AppendText("Error: Failed to move nw.exe to Game.exe. You may need to launch the game manually using nw.exe. Attempting to continue..." + Environment.NewLine);
                errors = true;
            }
            textBox1.AppendText("Installing matching 64-bit version of Greenworks..." + Environment.NewLine);
            string greenworksDirectory = Path.Combine(gameDirectory, "www", "greenworks");
            int installGreenworksResult = await TombUpdater.DownloadAndExtractZipAsync(greenworksUrl, greenworksDirectory);
            if (installGreenworksResult == 0)
            {
                textBox1.AppendText("Greenworks installed." + Environment.NewLine);
            }
            else
            {
                textBox1.AppendText("Error: Failed to download or install Greenworks. The game might not launch!" + Environment.NewLine);
                textBox1.AppendText("Install Greenworks manually, or re-install your game and try again, making sure the URLs are valid. Attempting to continue..." + Environment.NewLine);
                errors = true;
            }
            textBox1.AppendText("Installing 64-bit Steam DLLs..." + Environment.NewLine);
            string greenworksLibDirectory = Path.Combine(greenworksDirectory, "lib");
            int installSteamapiResult = await ModUpdater.DownloadAndSaveModAsync(steamapiUrl, greenworksLibDirectory);
            if (installSteamapiResult == 0)
            {
                textBox1.AppendText("steam_api64.dll installed to lib." + Environment.NewLine);
            }
            else
            {
                textBox1.AppendText("Error: Failed to download or install steam_api64.dll." + Environment.NewLine);
                textBox1.AppendText("Install steam_api64.dll manually, or re-install your game and try again, making sure the URLs are valid. Attempting to continue..." + Environment.NewLine);
                errors = true;
            }

            int installAppticketResult = await ModUpdater.DownloadAndSaveModAsync(appticketUrl, greenworksLibDirectory);
            if (installAppticketResult == 0)
            {
                textBox1.AppendText("sdkencryptedappticket64.dll installed to lib." + Environment.NewLine);
            }
            else
            {
                textBox1.AppendText("Error: Failed to download or install sdkencryptedappticket64.dll." + Environment.NewLine);
                textBox1.AppendText("Install sdkencryptedappticket64.dll manually, or re-install your game and try again, making sure the URLs are valid." + Environment.NewLine);
                errors = true;
            }
            if (!errors)
            {
                textBox1.AppendText("NW.js (64-bit) upgrade complete!" + Environment.NewLine);
            }
            else
            {
                textBox1.AppendText("NW.js (64-bit) upgrade completed with one or more errors. The game might not launch!" + Environment.NewLine);
            }
            enableAllButtons();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var dlg = new FolderPicker();
            dlg.InputPath = @"C:\";
            if (dlg.ShowDialog(button1.Handle) == true)
            {
                textBox14.Text = dlg.ResultPath;
            }
        }

        private async void button8_Click(object sender, EventArgs e)
        {
            string gameDirectory = textBox2.Text;
            string outputDirectory = textBox14.Text;
            if (!Directory.Exists(gameDirectory))
            {
                textBox1.AppendText("Error: No game directory selected or nonexistent directory. Stopping." + Environment.NewLine);
                return;
            }
            if (!Directory.Exists(outputDirectory))
            {
                textBox1.AppendText("Created new output directory." + Environment.NewLine);
                Directory.CreateDirectory(outputDirectory);
            }
            textBox1.AppendText("Running decryption routine..." + Environment.NewLine);
            int decryptionResult = await Decryptor.DecryptGame(gameDirectory, outputDirectory);
            if (decryptionResult == 0)
            {
                textBox1.AppendText("All assets decrypted and saved to: " + outputDirectory + Environment.NewLine);
            }
            else
            {
                textBox1.AppendText("Error: Failed to decrypt the game assets." + Environment.NewLine);
            }
        }
        private void button10_Click(object sender, EventArgs e)
        {
            var dlg = new FolderPicker();
            dlg.InputPath = @"C:\";
            if (dlg.ShowDialog(button1.Handle) == true)
            {
                textBox16.Text = dlg.ResultPath;
            }
        }
        private void button11_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = openFileDialog1.FileName;
                try
                {
                    textBox17.Text = file;
                    textBox18.Text = Path.Combine(Path.GetDirectoryName(file), "output.js");
                }
                catch (IOException)
                {
                }
            }
        }

        private async void button12_Click(object sender, EventArgs e)
        {
            string decodeJsUrl = textBox15.Text;
            string installDirectory = textBox16.Text;
            if (string.IsNullOrEmpty(decodeJsUrl))
            {
                textBox1.AppendText("Error: Invalid decode-js URL. Stopping." + Environment.NewLine);
                return;
            }
            if (!Directory.Exists(installDirectory))
            {
                textBox1.AppendText("Created new install directory." + Environment.NewLine);
                Directory.CreateDirectory(installDirectory);
            }
            disableAllButtons();
            textBox1.AppendText("Downloading and extracting decode-js..." + Environment.NewLine);
            int decodeJsExtractResult = await Deobfuscator.DownloadAndExtractDecodeJsAsync(decodeJsUrl, installDirectory);
            if (decodeJsExtractResult == 0)
            {
                textBox1.AppendText("decode-js downloaded and extracted." + Environment.NewLine);
            }
            else
            {
                textBox1.AppendText("Error: Failed to download or extract decode-js. Stopping." + Environment.NewLine);
                enableAllButtons();
                return;
            }
            textBox1.AppendText("Checking Node.js version..." + Environment.NewLine);
            string nodeVersion = await Deobfuscator.CheckNodeVersionAsync();
            if (nodeVersion.StartsWith("Error"))
            {
                textBox1.AppendText("Error: Node.js not found. Stopping." + Environment.NewLine);
                enableAllButtons();
                return;
            }
            textBox1.AppendText("Node.js " + nodeVersion + Environment.NewLine);
            string[] versionParts = nodeVersion.Split('.');
            int majorVersion = int.Parse(versionParts[0].TrimStart('v'));
            if (majorVersion >= 22)
            {
                textBox1.AppendText("Node.js version >= 22, updating isolated-vm in package.json to v5.0..." + Environment.NewLine);
                int updateIsolatedVmResult = Deobfuscator.UpdateIsolatedVm(installDirectory);
                if (updateIsolatedVmResult == 0)
                {
                    textBox1.AppendText("isolated-vm updated." + Environment.NewLine);
                }
                else
                {
                    textBox1.AppendText("Error: Failed to update isolated-vm. Attempting to continue..." + Environment.NewLine);
                }
            }

            textBox1.AppendText("Installing dependencies for decode-js..." + Environment.NewLine);

            int decodeJsInstallResult = await Deobfuscator.InstallDecodeJs(installDirectory, (output) => textBox1.Invoke((Action)(() => textBox1.AppendText(output + Environment.NewLine))));

            if (decodeJsInstallResult == 0)
            {
                textBox1.AppendText("Installed all dependencies. decode-js installation complete." + Environment.NewLine);
            }
            else
            {
                textBox1.AppendText("Error: Failed to install dependencies. You might need to install them manually using npm i." + Environment.NewLine);
            }
            enableAllButtons();
        }

        private async void button13_Click(object sender, EventArgs e)
        {
            string installDirectory = textBox16.Text;
            string inputJsPath = textBox17.Text;
            string outputJsPath = textBox18.Text;
            if (!Directory.Exists(installDirectory))
            {
                textBox1.AppendText("Error: No decode-js directory selected or nonexistent directory. Stopping." + Environment.NewLine);
                return;
            }
            if (!File.Exists(inputJsPath))
            {
                textBox1.AppendText("Error: Input .js file not found. Stopping." + Environment.NewLine);
                return;
            }

            string decodeType = "obfuscator";
            if (radioButton1.Checked) decodeType = "common";
            else if (radioButton2.Checked) decodeType = "jjencode";
            else if (radioButton3.Checked) decodeType = "sojson";
            else if (radioButton4.Checked) decodeType = "sojsonv7";
            else if (radioButton5.Checked) decodeType = "obfuscator";

            disableAllButtons();
            textBox1.AppendText("Running deobfuscator in mode: " + decodeType + Environment.NewLine);

            int runDecodeJsResult = await Deobfuscator.RunDecodeJs(
                installDirectory,
                inputJsPath,
                outputJsPath,
                decodeType,
                (output) => textBox1.Invoke((Action)(() => textBox1.AppendText(output + Environment.NewLine)))
            );

            if (runDecodeJsResult == 0)
            {
                textBox1.AppendText("Deobfuscated input file and saved output to: " + outputJsPath + Environment.NewLine);
            }
            else
            {
                textBox1.AppendText("Error: Failed to deobfuscate input file." + Environment.NewLine);
            }
            enableAllButtons();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = openFileDialog1.FileName;
                try
                {
                    textBox20.Text = file;
                    textBox21.Text = Path.Combine(Path.GetDirectoryName(file), "modified_plugin.js");
                }
                catch (IOException)
                {
                }
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            string inputJsPath = textBox20.Text;
            string outputJsPath = textBox21.Text;
            string regexTarget = textBox22.Text;
            string injectedCode = textBox19.Text;
            if (!File.Exists(inputJsPath))
            {
                textBox1.AppendText("Error: Target .js file not found. Stopping." + Environment.NewLine);
                return;
            }
            if (string.IsNullOrEmpty(regexTarget))
            {
                textBox1.AppendText("Error: Invalid or empty regex target. Stopping." + Environment.NewLine);
                return;
            }
            if (string.IsNullOrEmpty(injectedCode))
            {
                textBox1.AppendText("Error: No code to replace the target with. Stopping." + Environment.NewLine);
                return;
            }
            textBox1.AppendText("Injecting specified code to the target file..." + Environment.NewLine);
            int injectJsResult = Extractor.InjectCode(inputJsPath, outputJsPath, regexTarget, injectedCode);
            if (injectJsResult == 0)
            {
                textBox1.AppendText("Target file modified and saved to: " + outputJsPath + Environment.NewLine);
                textBox1.AppendText("Launch the game with the modified plugin to dump obfuscated game code." + Environment.NewLine);
            }
            else
            {
                textBox1.AppendText("Error: Failed to modify the target file." + Environment.NewLine);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox19.ReadOnly = false;
                textBox22.ReadOnly = false;
                textBox24.ReadOnly = false;
            }
            else
            {
                textBox19.ReadOnly = true;
                textBox22.ReadOnly = true;
                textBox24.ReadOnly = true;
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            string pluginsDirectory = textBox23.Text;
            string searchText = textBox24.Text;
            if (!Directory.Exists(pluginsDirectory))
            {
                textBox1.AppendText("Error: Invalid plugins directory selected." + Environment.NewLine);
                return;
            }
            string targetPluginPath = Extractor.FindFileWithExactMatch(pluginsDirectory, searchText);
            if (targetPluginPath != null)
            {
                textBox1.AppendText("Found target function definition in: " + Path.GetFileName(targetPluginPath) + Environment.NewLine);
            }
            else
            {
                textBox1.AppendText("Error: Failed to locate the target plugin." + Environment.NewLine);
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            var dlg = new FolderPicker();
            dlg.InputPath = @"C:\";
            if (dlg.ShowDialog(button17.Handle) == true)
            {
                textBox23.Text = dlg.ResultPath;
            }
        }

        private async void button18_Click(object sender, EventArgs e)
        {
            string pluginsDirectory = textBox23.Text;
            string searchText = textBox24.Text;
            string installDirectory = textBox16.Text;
            if (!Directory.Exists(pluginsDirectory))
            {
                textBox1.AppendText("Error: Invalid plugins directory selected." + Environment.NewLine);
                return;
            }
            string targetPluginPath = Extractor.FindFileWithExactMatch(pluginsDirectory, searchText);
            textBox1.AppendText("Starting tcaLazyCracker operation. Attempting to extract and deobfuscate game code..." + Environment.NewLine);
            if (targetPluginPath != null)
            {
                textBox1.AppendText("Found target function definition in: " + Path.GetFileName(targetPluginPath) + Environment.NewLine);
            }
            else
            {
                textBox1.AppendText("Error: Failed to locate the target plugin. Stopping." + Environment.NewLine);
                return;
            }
            string tempJsPath = Path.Combine(Path.GetDirectoryName(targetPluginPath), "plugin_temp.js");

            string decodeType = "obfuscator";

            disableAllButtons();
            textBox1.AppendText("Running deobfuscator in mode: " + decodeType + Environment.NewLine);

            int runDecodeJsResult = await Deobfuscator.RunDecodeJs(
                installDirectory,
                targetPluginPath,
                tempJsPath,
                decodeType,
                (output) => textBox1.Invoke((Action)(() => textBox1.AppendText(output + Environment.NewLine)))
            );

            if (runDecodeJsResult == 0)
            {
                textBox1.AppendText("Deobfuscated input file and saved output to: " + tempJsPath + Environment.NewLine);
            }
            else
            {
                textBox1.AppendText("Error: Failed to deobfuscate input file." + Environment.NewLine);
            }

            string backupPath = Path.ChangeExtension(targetPluginPath, ".bak");
            File.Move(targetPluginPath, backupPath);
            string regexTarget = textBox22.Text;
            string injectedCode = textBox19.Text;
            if (!File.Exists(tempJsPath))
            {
                textBox1.AppendText("Error: Target .js file not found. Stopping." + Environment.NewLine);
                enableAllButtons();
                return;
            }
            if (string.IsNullOrEmpty(regexTarget))
            {
                textBox1.AppendText("Error: Invalid or empty regex target. Stopping." + Environment.NewLine);
                enableAllButtons();
                return;
            }
            if (string.IsNullOrEmpty(injectedCode))
            {
                textBox1.AppendText("Error: No code to replace the target with. Stopping." + Environment.NewLine);
                enableAllButtons();
                return;
            }
            textBox1.AppendText("Injecting specified code to the target file..." + Environment.NewLine);
            int injectJsResult = Extractor.InjectCode(tempJsPath, targetPluginPath, regexTarget, injectedCode);

            if (injectJsResult == 0)
            {
                textBox1.AppendText("Target file modified and saved to: " + tempJsPath + Environment.NewLine);
                textBox1.AppendText("Launch the game with the modified plugin to dump obfuscated game code." + Environment.NewLine);
            }
            else
            {
                textBox1.AppendText("Error: Failed to modify the target file." + Environment.NewLine);
            }

            string gameDirectory = textBox2.Text;
            if (!Directory.Exists(gameDirectory))
            {
                textBox1.AppendText("Error: Game directory not found. Manually select the dump.js file after launching the game. Stopping." + Environment.NewLine);
                enableAllButtons();
                return;
            }
            textBox1.AppendText("Launching game to dump code..." + Environment.NewLine);

            string gameExePath = Path.Combine(gameDirectory, "Game.exe");

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = gameExePath,
                CreateNoWindow = true,
                UseShellExecute = false,
                WindowStyle = ProcessWindowStyle.Hidden
            };

            using (Process myProcess = Process.Start(startInfo))
            {
                Thread.Sleep(1000);
                if (!myProcess.HasExited)
                {
                    myProcess.Kill();
                    myProcess.WaitForExit();
                }
            }

            textBox1.AppendText("Deobfuscating dump.js..." + Environment.NewLine);
            string dumpJsPath = Path.Combine(gameDirectory, "dump.js");
            if (!File.Exists(dumpJsPath))
            {
                textBox1.AppendText("Error: dump.js file not found. You may need to launch the game manually to obtain it. Stopping." + Environment.NewLine);
                enableAllButtons();
                return;
            }

            string finalResultPath = Path.Combine(gameDirectory, "final_result.js");

            int runDecodeJsFinalResult = await Deobfuscator.RunDecodeJs(
                installDirectory,
                dumpJsPath,
                finalResultPath,
                decodeType,
                (output) => textBox1.Invoke((Action)(() => textBox1.AppendText(output + Environment.NewLine)))
            );

            if (runDecodeJsFinalResult == 0)
            {
                textBox1.AppendText("Deobfuscated dump.js and saved result to: " + finalResultPath + Environment.NewLine);
            }
            else
            {
                textBox1.AppendText("Error: Failed to deobfuscate dump.js file. Attempting to continue..." + Environment.NewLine);
            }

            if (File.Exists(tempJsPath))
            {
                textBox1.AppendText("Cleaning up temp files..." + Environment.NewLine);
                File.Delete(tempJsPath);
            }

            if (File.Exists(targetPluginPath))
            {
                textBox1.AppendText("Deleting modified plugin..." + Environment.NewLine);
                File.Delete(targetPluginPath);
            }

            textBox1.AppendText("Restoring original plugin from backup: " + Path.GetDirectoryName(targetPluginPath) + Environment.NewLine);
            File.Move(backupPath, targetPluginPath);

            textBox1.AppendText("All tcaLazyCracker operations completed!" + Environment.NewLine);
            enableAllButtons();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            string gameDirectory = textBox2.Text;
            if (!Directory.Exists(gameDirectory))
            {
                textBox1.AppendText("Error: No game directory selected, or directory does not exist." + Environment.NewLine);
                return;
            }
            textBox1.AppendText("Opening the game folder." + Environment.NewLine);
            Process.Start("explorer.exe", gameDirectory);
        }
    }
}
