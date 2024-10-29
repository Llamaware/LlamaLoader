using System.IO.Packaging;
using System.IO;

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
                textBox1.AppendText("Failed to detect game directory. Please select manually." + Environment.NewLine);
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("Getting the newest Tomb version from: " + textBox3.Text + Environment.NewLine);
            string newestTombUrl = await TombUpdater.GetNewestTombUrl(textBox3.Text);
            if (newestTombUrl != null)
            {
                textBox1.AppendText("Found Tomb at: " + newestTombUrl + Environment.NewLine);
            }
            else
            {
                textBox1.AppendText("An error occurred while finding Tomb. Stopping." + Environment.NewLine);
                return;
            }
            textBox1.AppendText("Downloading and extracting Tomb to game directory..." + Environment.NewLine);
            string gameDirectory = textBox2.Text;
            int downloadTomb = await TombUpdater.DownloadAndExtractZipAsync(newestTombUrl, gameDirectory);
            if (downloadTomb == 1)
            {
                textBox1.AppendText("Successfully downloaded and extracted Tomb to the game directory." + Environment.NewLine);
            }
            else
            {
                textBox1.AppendText("An error occurred while attempting to download or extract Tomb. Stopping." + Environment.NewLine);
                return;
            }
            textBox1.AppendText("Checking package.json..." + Environment.NewLine);
            int indexUpdate = await TombUpdater.UpdateMainFieldInPackageJson(gameDirectory);
            if (indexUpdate == 1)
            {
                textBox1.AppendText("Updated main to tomb/index.html" + Environment.NewLine);
            }
            else if (indexUpdate == -1) 
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
    }
}
