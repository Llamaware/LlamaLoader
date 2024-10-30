using System.IO.Packaging;
using System.IO;
using static ModUpdater;

namespace autotomb
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
            if (!Directory.Exists(gameDirectory))
            {
                textBox1.AppendText("Error: No game directory selected or nonexistent directory. Stopping." + Environment.NewLine);
                return;
            }
            textBox1.AppendText("Getting the newest Tomb version from: " + textBox3.Text + Environment.NewLine);
            string newestTombUrlResult = await TombUpdater.GetNewestTombUrl(textBox3.Text);
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
            if (downloadTombResult == 1)
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
                Console.WriteLine("Error: mods folder not found. Is Tomb not installed? Stopping.");
                return;
            }
            var selectedMods = checkedListBox1.CheckedItems.Cast<string>().ToList();

            if (selectedMods.Count > 0)
            {
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
                    return;
                }
            }
            else
            {
                textBox1.AppendText("Please select one or more mods to install." + Environment.NewLine);
                return;
            }

            textBox1.AppendText("Installation complete!" + Environment.NewLine);
        }
    }
}
