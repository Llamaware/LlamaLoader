﻿namespace LlamaLoader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
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
            textBox13 = new TextBox();
            label13 = new Label();
            textBox12 = new TextBox();
            label12 = new Label();
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
            tabPage5 = new TabPage();
            button8 = new Button();
            groupBox5 = new GroupBox();
            button9 = new Button();
            label14 = new Label();
            textBox14 = new TextBox();
            tabPage6 = new TabPage();
            button13 = new Button();
            button12 = new Button();
            groupBox6 = new GroupBox();
            label19 = new Label();
            radioButton5 = new RadioButton();
            radioButton4 = new RadioButton();
            radioButton3 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            button11 = new Button();
            button10 = new Button();
            label18 = new Label();
            label17 = new Label();
            label16 = new Label();
            textBox18 = new TextBox();
            label15 = new Label();
            textBox17 = new TextBox();
            textBox16 = new TextBox();
            textBox15 = new TextBox();
            groupBox1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            groupBox2.SuspendLayout();
            tabPage3.SuspendLayout();
            groupBox3.SuspendLayout();
            tabPage4.SuspendLayout();
            groupBox4.SuspendLayout();
            tabPage5.SuspendLayout();
            groupBox5.SuspendLayout();
            tabPage6.SuspendLayout();
            groupBox6.SuspendLayout();
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
            textBox1.ScrollBars = ScrollBars.Vertical;
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
            groupBox1.Size = new Size(768, 142);
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
            button3.Text = "Install/Update Modloader";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Controls.Add(tabPage5);
            tabControl1.Controls.Add(tabPage6);
            tabControl1.Location = new Point(7, 175);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(788, 324);
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
            tabPage1.Size = new Size(780, 296);
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
            tabPage2.Size = new Size(780, 296);
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
            groupBox2.Size = new Size(768, 219);
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
            textBox5.Size = new Size(319, 130);
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
            checkedListBox1.Size = new Size(319, 130);
            checkedListBox1.TabIndex = 0;
            checkedListBox1.SelectedIndexChanged += checkedListBox1_SelectedIndexChanged;
            // 
            // button5
            // 
            button5.Location = new Point(465, 239);
            button5.Name = "button5";
            button5.Size = new Size(190, 40);
            button5.TabIndex = 4;
            button5.Text = "Install/Update Selected Mods";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button4
            // 
            button4.Location = new Point(125, 239);
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
            tabPage3.Size = new Size(780, 296);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "NW.js (32-bit)";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Location = new Point(290, 238);
            button6.Name = "button6";
            button6.Size = new Size(190, 40);
            button6.TabIndex = 1;
            button6.Text = "Upgrade NW.js (32-bit)";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(textBox13);
            groupBox3.Controls.Add(label13);
            groupBox3.Controls.Add(textBox12);
            groupBox3.Controls.Add(label12);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(textBox7);
            groupBox3.Controls.Add(textBox6);
            groupBox3.Location = new Point(6, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(768, 216);
            groupBox3.TabIndex = 0;
            groupBox3.TabStop = false;
            groupBox3.Text = "Options";
            // 
            // textBox13
            // 
            textBox13.Location = new Point(210, 124);
            textBox13.Name = "textBox13";
            textBox13.Size = new Size(508, 23);
            textBox13.TabIndex = 8;
            textBox13.Text = "https://github.com/rlabrecque/SteamworksSDK/raw/refs/heads/main/public/steam/lib/win32/sdkencryptedappticket.dll";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(37, 127);
            label13.Name = "label13";
            label13.Size = new Size(167, 15);
            label13.TabIndex = 7;
            label13.Text = "sdkencryptedappticket.dll URL";
            // 
            // textBox12
            // 
            textBox12.Location = new Point(210, 95);
            textBox12.Name = "textBox12";
            textBox12.Size = new Size(508, 23);
            textBox12.TabIndex = 6;
            textBox12.Text = "https://github.com/rlabrecque/SteamworksSDK/raw/refs/heads/main/redistributable_bin/steam_api.dll";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(104, 98);
            label12.Name = "label12";
            label12.Size = new Size(100, 15);
            label12.TabIndex = 5;
            label12.Text = "steam_api.dll URL";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = Color.Red;
            label6.Location = new Point(88, 174);
            label6.Name = "label6";
            label6.Size = new Size(618, 15);
            label6.TabIndex = 4;
            label6.Text = "Warning: Compatibility is not guaranteed. NW.js and Greenworks versions must match. This operation is irreversible.";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(111, 69);
            label5.Name = "label5";
            label5.Size = new Size(93, 15);
            label5.TabIndex = 3;
            label5.Text = "Greenworks URL";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(142, 40);
            label4.Name = "label4";
            label4.Size = new Size(62, 15);
            label4.TabIndex = 2;
            label4.Text = "NW.js URL";
            // 
            // textBox7
            // 
            textBox7.Location = new Point(210, 66);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(508, 23);
            textBox7.TabIndex = 1;
            textBox7.Text = "https://github.com/greenheartgames/greenworks/releases/download/v0.18.0/greenworks-v0.18.0-nw-v0.92.0-win-32.zip";
            // 
            // textBox6
            // 
            textBox6.Location = new Point(210, 37);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(508, 23);
            textBox6.TabIndex = 0;
            textBox6.Text = "https://dl.nwjs.io/v0.92.0/nwjs-sdk-v0.92.0-win-ia32.zip";
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(button7);
            tabPage4.Controls.Add(groupBox4);
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new Size(780, 296);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "NW.js (64-bit)";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            button7.Location = new Point(290, 238);
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
            groupBox4.Size = new Size(768, 212);
            groupBox4.TabIndex = 0;
            groupBox4.TabStop = false;
            groupBox4.Text = "Options";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.ForeColor = Color.Red;
            label11.Location = new Point(88, 174);
            label11.Name = "label11";
            label11.Size = new Size(618, 15);
            label11.TabIndex = 8;
            label11.Text = "Warning: Compatibility is not guaranteed. NW.js and Greenworks versions must match. This operation is irreversible.";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(25, 127);
            label10.Name = "label10";
            label10.Size = new Size(179, 15);
            label10.TabIndex = 7;
            label10.Text = "sdkencryptedappticket64.dll URL";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(92, 98);
            label9.Name = "label9";
            label9.Size = new Size(112, 15);
            label9.TabIndex = 6;
            label9.Text = "steam_api64.dll URL";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(111, 69);
            label8.Name = "label8";
            label8.Size = new Size(93, 15);
            label8.TabIndex = 5;
            label8.Text = "Greenworks URL";
            // 
            // textBox11
            // 
            textBox11.Location = new Point(210, 124);
            textBox11.Name = "textBox11";
            textBox11.Size = new Size(508, 23);
            textBox11.TabIndex = 4;
            textBox11.Text = "https://github.com/rlabrecque/SteamworksSDK/raw/refs/heads/main/public/steam/lib/win64/sdkencryptedappticket64.dll";
            // 
            // textBox10
            // 
            textBox10.Location = new Point(210, 95);
            textBox10.Name = "textBox10";
            textBox10.Size = new Size(508, 23);
            textBox10.TabIndex = 3;
            textBox10.Text = "https://github.com/rlabrecque/SteamworksSDK/raw/refs/heads/main/redistributable_bin/win64/steam_api64.dll";
            // 
            // textBox9
            // 
            textBox9.Location = new Point(210, 66);
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(508, 23);
            textBox9.TabIndex = 2;
            textBox9.Text = "https://github.com/greenheartgames/greenworks/releases/download/v0.18.0/greenworks-v0.18.0-nw-v0.92.0-win-64.zip";
            // 
            // textBox8
            // 
            textBox8.Location = new Point(210, 37);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(508, 23);
            textBox8.TabIndex = 1;
            textBox8.Text = "https://dl.nwjs.io/v0.92.0/nwjs-sdk-v0.92.0-win-x64.zip";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(142, 40);
            label7.Name = "label7";
            label7.Size = new Size(62, 15);
            label7.TabIndex = 0;
            label7.Text = "NW.js URL";
            // 
            // tabPage5
            // 
            tabPage5.Controls.Add(button8);
            tabPage5.Controls.Add(groupBox5);
            tabPage5.Location = new Point(4, 24);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new Padding(3);
            tabPage5.Size = new Size(780, 296);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "Decrypt";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            button8.Location = new Point(290, 147);
            button8.Name = "button8";
            button8.Size = new Size(190, 40);
            button8.TabIndex = 1;
            button8.Text = "Decrypt Assets";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(button9);
            groupBox5.Controls.Add(label14);
            groupBox5.Controls.Add(textBox14);
            groupBox5.Location = new Point(6, 3);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(768, 118);
            groupBox5.TabIndex = 0;
            groupBox5.TabStop = false;
            groupBox5.Text = "Options";
            // 
            // button9
            // 
            button9.Location = new Point(639, 48);
            button9.Name = "button9";
            button9.Size = new Size(75, 23);
            button9.TabIndex = 2;
            button9.Text = "Browse";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(53, 51);
            label14.Name = "label14";
            label14.Size = new Size(96, 15);
            label14.TabIndex = 1;
            label14.Text = "Output Directory";
            // 
            // textBox14
            // 
            textBox14.Location = new Point(155, 48);
            textBox14.Name = "textBox14";
            textBox14.Size = new Size(469, 23);
            textBox14.TabIndex = 0;
            // 
            // tabPage6
            // 
            tabPage6.Controls.Add(button13);
            tabPage6.Controls.Add(button12);
            tabPage6.Controls.Add(groupBox6);
            tabPage6.Location = new Point(4, 24);
            tabPage6.Name = "tabPage6";
            tabPage6.Size = new Size(780, 296);
            tabPage6.TabIndex = 5;
            tabPage6.Text = "Deobfuscate";
            tabPage6.UseVisualStyleBackColor = true;
            // 
            // button13
            // 
            button13.Location = new Point(465, 239);
            button13.Name = "button13";
            button13.Size = new Size(190, 40);
            button13.TabIndex = 3;
            button13.Text = "Deobfuscate File";
            button13.UseVisualStyleBackColor = true;
            button13.Click += button13_Click;
            // 
            // button12
            // 
            button12.Location = new Point(125, 239);
            button12.Name = "button12";
            button12.Size = new Size(190, 40);
            button12.TabIndex = 2;
            button12.Text = "Install decode-js";
            button12.UseVisualStyleBackColor = true;
            button12.Click += button12_Click;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(label19);
            groupBox6.Controls.Add(radioButton5);
            groupBox6.Controls.Add(radioButton4);
            groupBox6.Controls.Add(radioButton3);
            groupBox6.Controls.Add(radioButton2);
            groupBox6.Controls.Add(radioButton1);
            groupBox6.Controls.Add(button11);
            groupBox6.Controls.Add(button10);
            groupBox6.Controls.Add(label18);
            groupBox6.Controls.Add(label17);
            groupBox6.Controls.Add(label16);
            groupBox6.Controls.Add(textBox18);
            groupBox6.Controls.Add(label15);
            groupBox6.Controls.Add(textBox17);
            groupBox6.Controls.Add(textBox16);
            groupBox6.Controls.Add(textBox15);
            groupBox6.Location = new Point(6, 3);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(768, 216);
            groupBox6.TabIndex = 1;
            groupBox6.TabStop = false;
            groupBox6.Text = "Options";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(40, 171);
            label19.Name = "label19";
            label19.Size = new Size(99, 15);
            label19.TabIndex = 15;
            label19.Text = "Obfuscation Type";
            // 
            // radioButton5
            // 
            radioButton5.AutoSize = true;
            radioButton5.Checked = true;
            radioButton5.Location = new Point(541, 169);
            radioButton5.Name = "radioButton5";
            radioButton5.Size = new Size(82, 19);
            radioButton5.TabIndex = 14;
            radioButton5.TabStop = true;
            radioButton5.Text = "obfuscator";
            radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            radioButton4.AutoSize = true;
            radioButton4.Location = new Point(445, 169);
            radioButton4.Name = "radioButton4";
            radioButton4.Size = new Size(71, 19);
            radioButton4.TabIndex = 13;
            radioButton4.Text = "sojsonv7";
            radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(358, 169);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(59, 19);
            radioButton3.TabIndex = 12;
            radioButton3.Text = "sojson";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(256, 169);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(70, 19);
            radioButton2.TabIndex = 11;
            radioButton2.Text = "jjencode";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(163, 169);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(74, 19);
            radioButton1.TabIndex = 10;
            radioButton1.Text = "common";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            button11.Location = new Point(653, 89);
            button11.Name = "button11";
            button11.Size = new Size(75, 23);
            button11.TabIndex = 9;
            button11.Text = "Browse";
            button11.UseVisualStyleBackColor = true;
            button11.Click += button11_Click;
            // 
            // button10
            // 
            button10.Location = new Point(653, 59);
            button10.Name = "button10";
            button10.Size = new Size(75, 23);
            button10.TabIndex = 8;
            button10.Text = "Browse";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(73, 121);
            label18.Name = "label18";
            label18.Size = new Size(66, 15);
            label18.TabIndex = 7;
            label18.Text = "Output File";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(69, 92);
            label17.Name = "label17";
            label17.Size = new Size(70, 15);
            label17.TabIndex = 6;
            label17.Text = "Input .js File";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(65, 63);
            label16.Name = "label16";
            label16.Size = new Size(74, 15);
            label16.TabIndex = 5;
            label16.Text = "Install Folder";
            // 
            // textBox18
            // 
            textBox18.Location = new Point(145, 118);
            textBox18.Name = "textBox18";
            textBox18.Size = new Size(493, 23);
            textBox18.TabIndex = 4;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(56, 34);
            label15.Name = "label15";
            label15.Size = new Size(83, 15);
            label15.TabIndex = 3;
            label15.Text = "decode-js URL";
            // 
            // textBox17
            // 
            textBox17.Location = new Point(145, 89);
            textBox17.Name = "textBox17";
            textBox17.Size = new Size(493, 23);
            textBox17.TabIndex = 2;
            // 
            // textBox16
            // 
            textBox16.Location = new Point(145, 60);
            textBox16.Name = "textBox16";
            textBox16.Size = new Size(493, 23);
            textBox16.TabIndex = 1;
            // 
            // textBox15
            // 
            textBox15.Location = new Point(145, 31);
            textBox15.Name = "textBox15";
            textBox15.Size = new Size(493, 23);
            textBox15.TabIndex = 0;
            textBox15.Text = "https://github.com/echo094/decode-js/archive/refs/heads/main.zip";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 511);
            Controls.Add(textBox1);
            Controls.Add(tabControl1);
            Icon = (Icon)resources.GetObject("$this.Icon");
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
            tabPage5.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            tabPage6.ResumeLayout(false);
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
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
        private TextBox textBox12;
        private Label label12;
        private Label label13;
        private TextBox textBox13;
        private TabPage tabPage5;
        private GroupBox groupBox5;
        private Label label14;
        private TextBox textBox14;
        private Button button8;
        private Button button9;
        private TabPage tabPage6;
        private GroupBox groupBox6;
        private TextBox textBox17;
        private TextBox textBox16;
        private TextBox textBox15;
        private TextBox textBox18;
        private Label label15;
        private Button button11;
        private Button button10;
        private Label label18;
        private Label label17;
        private Label label16;
        private Button button13;
        private Button button12;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Label label19;
        private RadioButton radioButton5;
        private RadioButton radioButton4;
        private RadioButton radioButton3;
    }
}
