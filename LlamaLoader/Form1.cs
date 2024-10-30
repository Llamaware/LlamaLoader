using System.IO.Packaging;
using System.IO;
using static ModUpdater;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace autotomb
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
        }

        private void enableAllButtons()
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dlg = new FolderPicker();
            dlg.InputPath = @"C:\";
            if (dlg.ShowDialog(button1.Handle) == true)
            {
                textBox2.Text = dlg.ResultPath;
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
            }
            else if (indexUpdateResult == -1)
            {
                textBox1.AppendText("Error: package.json not found at specified path. Stopping." + Environment.NewLine);
                return;
            }
            else
            {
                textBox1.AppendText("Tomb was already installed, no changes necessary." + Environment.NewLine);
            }
            textBox1.AppendText("Update complete!" + Environment.NewLine);
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
            disableAllButtons();
            textBox1.AppendText("Downloading and installing NW.js. This will take a while, please be patient..." + Environment.NewLine);
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
            textBox1.AppendText("Installing matching version of Greenworks..." + Environment.NewLine);
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
            enableAllButtons();
            if (!errors)
            {
                textBox1.AppendText("NW.js upgrade complete!" + Environment.NewLine);
            }
            else
            {
                textBox1.AppendText("Operation completed, but one or more errors occurred. The game might not launch!" + Environment.NewLine);
            }
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
                textBox1.AppendText("Error: Invalid steamapi64.dll URL. Stopping." + Environment.NewLine);
                return;
            }
            if (string.IsNullOrEmpty(appticketUrl))
            {
                textBox1.AppendText("Error: Invalid sdkencryptedappticket64.dll URL. Stopping." + Environment.NewLine);
                return;
            }
            disableAllButtons();
            textBox1.AppendText("Downloading and installing NW.js. This will take a while, please be patient..." + Environment.NewLine);
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
            textBox1.AppendText("Installing matching version of Greenworks..." + Environment.NewLine);
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
                textBox1.AppendText("steamapi64.dll installed to lib." + Environment.NewLine);
            }
            else
            {
                textBox1.AppendText("Error: Failed to download or install steamapi64.dll. Attempting to continue..." + Environment.NewLine);
                textBox1.AppendText("Install steamapi64.dll manually, or re-install your game and try again, making sure the URLs are valid. Attempting to continue..." + Environment.NewLine);
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
            enableAllButtons();
            if (!errors)
            {
                textBox1.AppendText("NW.js upgrade complete!" + Environment.NewLine);
            }
            else
            {
                textBox1.AppendText("Operation completed, but one or more errors occurred. The game might not launch!" + Environment.NewLine);
            }
        }
    }
}
