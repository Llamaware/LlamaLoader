namespace autotomb
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            button1 = new Button();
            textBox2 = new TextBox();
            groupBox1 = new GroupBox();
            label2 = new Label();
            textBox3 = new TextBox();
            label1 = new Label();
            button2 = new Button();
            button3 = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            groupBox2 = new GroupBox();
            textBox5 = new TextBox();
            label3 = new Label();
            textBox4 = new TextBox();
            checkedListBox1 = new CheckedListBox();
            button5 = new Button();
            button4 = new Button();
            tabPage3 = new TabPage();
            button6 = new Button();
            groupBox3 = new GroupBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            textBox7 = new TextBox();
            textBox6 = new TextBox();
            tabPage4 = new TabPage();
            button7 = new Button();
            groupBox4 = new GroupBox();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            textBox11 = new TextBox();
            textBox10 = new TextBox();
            textBox9 = new TextBox();
            textBox8 = new TextBox();
            label7 = new Label();
            groupBox1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            groupBox2.SuspendLayout();
            tabPage3.SuspendLayout();
            groupBox3.SuspendLayout();
            tabPage4.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.WindowText;
            textBox1.Font = new Font("Cascadia Mono", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.ForeColor = Color.White;
            textBox1.Location = new Point(7, 12);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(788, 157);
            textBox1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(667, 33);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "Browse";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(156, 34);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(482, 23);
            textBox2.TabIndex = 2;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(textBox3);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(button1);
            groupBox1.Location = new Point(6, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(768, 169);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Options";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 91);
            label2.Name = "label2";
            label2.Size = new Size(108, 15);
            label2.TabIndex = 5;
            label2.Text = "Tomb Releases URL";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(156, 88);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(482, 23);
            textBox3.TabIndex = 4;
            textBox3.Text = "https://codeberg.org/basil/tomb/releases";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 37);
            label1.Name = "label1";
            label1.Size = new Size(115, 15);
            label1.TabIndex = 3;
            label1.Text = "Path to Game Folder";
            // 
            // button2
            // 
            button2.Location = new Point(130, 180);
            button2.Name = "button2";
            button2.Size = new Size(190, 40);
            button2.TabIndex = 4;
            button2.Text = "Auto-Detect Game";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(470, 180);
            button3.Name = "button3";
            button3.Size = new Size(190, 40);
            button3.TabIndex = 5;
            button3.Text = "Update Modloader";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Location = new Point(7, 175);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(788, 263);
            tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(button3);
            tabPage1.Controls.Add(groupBox1);
            tabPage1.Controls.Add(button2);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(780, 235);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Modloader";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(groupBox2);
            tabPage2.Controls.Add(button5);
            tabPage2.Controls.Add(button4);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(780, 235);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Get Mods";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(textBox5);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(textBox4);
            groupBox2.Controls.Add(checkedListBox1);
            groupBox2.Location = new Point(6, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(768, 169);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "Options";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(403, 72);
            textBox5.Multiline = true;
            textBox5.Name = "textBox5";
            textBox5.ReadOnly = true;
            textBox5.ScrollBars = ScrollBars.Vertical;
            textBox5.Size = new Size(319, 76);
            textBox5.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(70, 30);
            label3.Name = "label3";
            label3.Size = new Size(86, 15);
            label3.TabIndex = 2;
            label3.Text = "Mod Repo URL";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(193, 27);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(529, 23);
            textBox4.TabIndex = 1;
            textBox4.Text = "https://llamawa.re/mods/";
            // 
            // checkedListBox1
            // 
            checkedListBox1.ColumnWidth = 400;
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Location = new Point(32, 72);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(319, 76);
            checkedListBox1.TabIndex = 0;
            checkedListBox1.SelectedIndexChanged += checkedListBox1_SelectedIndexChanged;
            // 
            // button5
            // 
            button5.Location = new Point(470, 180);
            button5.Name = "button5";
            button5.Size = new Size(190, 40);
            button5.TabIndex = 4;
            button5.Text = "Install/Update Selected Mods";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button4
            // 
            button4.Location = new Point(130, 180);
            button4.Name = "button4";
            button4.Size = new Size(190, 40);
            button4.TabIndex = 3;
            button4.Text = "Load Mod List";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(button6);
            tabPage3.Controls.Add(groupBox3);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(780, 235);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "NW.js (32-bit)";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Location = new Point(290, 180);
            button6.Name = "button6";
            button6.Size = new Size(190, 40);
            button6.TabIndex = 1;
            button6.Text = "Upgrade NW.js (32-bit)";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(textBox7);
            groupBox3.Controls.Add(textBox6);
            groupBox3.Location = new Point(6, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(768, 169);
            groupBox3.TabIndex = 0;
            groupBox3.TabStop = false;
            groupBox3.Text = "Options";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = Color.Red;
            label6.Location = new Point(82, 140);
            label6.Name = "label6";
            label6.Size = new Size(618, 15);
            label6.TabIndex = 4;
            label6.Text = "Warning: Compatibility is not guaranteed. NW.js and Greenworks versions must match. This operation is irreversible.";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(44, 89);
            label5.Name = "label5";
            label5.Size = new Size(93, 15);
            label5.TabIndex = 3;
            label5.Text = "Greenworks URL";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(75, 37);
            label4.Name = "label4";
            label4.Size = new Size(62, 15);
            label4.TabIndex = 2;
            label4.Text = "NW.js URL";
            // 
            // textBox7
            // 
            textBox7.Location = new Point(143, 86);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(572, 23);
            textBox7.TabIndex = 1;
            textBox7.Text = "https://github.com/greenheartgames/greenworks/releases/download/v0.18.0/greenworks-v0.18.0-nw-v0.92.0-win-32.zip";
            // 
            // textBox6
            // 
            textBox6.Location = new Point(143, 34);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(572, 23);
            textBox6.TabIndex = 0;
            textBox6.Text = "https://dl.nwjs.io/v0.92.0/nwjs-sdk-v0.92.0-win-ia32.zip";
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(button7);
            tabPage4.Controls.Add(groupBox4);
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new Size(780, 235);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "NW.js (64-bit)";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            button7.Location = new Point(290, 180);
            button7.Name = "button7";
            button7.Size = new Size(190, 40);
            button7.TabIndex = 1;
            button7.Text = "Upgrade NW.js (64-bit)";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(label11);
            groupBox4.Controls.Add(label10);
            groupBox4.Controls.Add(label9);
            groupBox4.Controls.Add(label8);
            groupBox4.Controls.Add(textBox11);
            groupBox4.Controls.Add(textBox10);
            groupBox4.Controls.Add(textBox9);
            groupBox4.Controls.Add(textBox8);
            groupBox4.Controls.Add(label7);
            groupBox4.Location = new Point(6, 3);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(768, 169);
            groupBox4.TabIndex = 0;
            groupBox4.TabStop = false;
            groupBox4.Text = "Options";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.ForeColor = Color.Red;
            label11.Location = new Point(82, 140);
            label11.Name = "label11";
            label11.Size = new Size(618, 15);
            label11.TabIndex = 8;
            label11.Text = "Warning: Compatibility is not guaranteed. NW.js and Greenworks versions must match. This operation is irreversible.";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(25, 112);
            label10.Name = "label10";
            label10.Size = new Size(179, 15);
            label10.TabIndex = 7;
            label10.Text = "sdkencryptedappticket64.dll URL";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(97, 83);
            label9.Name = "label9";
            label9.Size = new Size(107, 15);
            label9.TabIndex = 6;
            label9.Text = "steamapi64.dll URL";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(111, 54);
            label8.Name = "label8";
            label8.Size = new Size(93, 15);
            label8.TabIndex = 5;
            label8.Text = "Greenworks URL";
            // 
            // textBox11
            // 
            textBox11.Location = new Point(210, 109);
            textBox11.Name = "textBox11";
            textBox11.Size = new Size(508, 23);
            textBox11.TabIndex = 4;
            textBox11.Text = "https://github.com/rlabrecque/SteamworksSDK/raw/refs/heads/main/public/steam/lib/win64/sdkencryptedappticket64.dll";
            // 
            // textBox10
            // 
            textBox10.Location = new Point(210, 80);
            textBox10.Name = "textBox10";
            textBox10.Size = new Size(508, 23);
            textBox10.TabIndex = 3;
            textBox10.Text = "https://github.com/rlabrecque/SteamworksSDK/raw/refs/heads/main/redistributable_bin/win64/steam_api64.dll";
            // 
            // textBox9
            // 
            textBox9.Location = new Point(210, 51);
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(508, 23);
            textBox9.TabIndex = 2;
            textBox9.Text = "https://github.com/greenheartgames/greenworks/releases/download/v0.18.0/greenworks-v0.18.0-nw-v0.92.0-win-64.zip";
            // 
            // textBox8
            // 
            textBox8.Location = new Point(210, 22);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(508, 23);
            textBox8.TabIndex = 1;
            textBox8.Text = "https://dl.nwjs.io/v0.92.0/nwjs-sdk-v0.92.0-win-x64.zip";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(142, 25);
            label7.Name = "label7";
            label7.Size = new Size(62, 15);
            label7.TabIndex = 0;
            label7.Text = "NW.js URL";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBox1);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "LlamaLoader";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            tabPage3.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            tabPage4.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button button1;
        private TextBox textBox2;
        private GroupBox groupBox1;
        private Label label1;
        private Label label2;
        private TextBox textBox3;
        private Button button2;
        private Button button3;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Label label3;
        private TextBox textBox4;
        private CheckedListBox checkedListBox1;
        private Button button5;
        private Button button4;
        private GroupBox groupBox2;
        private TextBox textBox5;
        private TabPage tabPage3;
        private GroupBox groupBox3;
        private Label label4;
        private TextBox textBox7;
        private TextBox textBox6;
        private Button button6;
        private Label label5;
        private Label label6;
        private TabPage tabPage4;
        private GroupBox groupBox4;
        private TextBox textBox9;
        private TextBox textBox8;
        private Label label7;
        private Button button7;
        private Label label10;
        private Label label9;
        private Label label8;
        private TextBox textBox11;
        private TextBox textBox10;
        private Label label11;
    }
}
