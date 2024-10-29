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
            groupBox1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.WindowText;
            textBox1.Font = new Font("Cascadia Mono", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.ForeColor = SystemColors.Window;
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
            label2.Location = new Point(68, 91);
            label2.Name = "label2";
            label2.Size = new Size(61, 15);
            label2.TabIndex = 5;
            label2.Text = "Tomb URL";
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
            button3.Text = "Update Tomb";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
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
            tabPage1.Text = "Tomb";
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
            tabPage2.Text = "Mods";
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
            textBox5.Location = new Point(389, 72);
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
            textBox4.Size = new Size(515, 23);
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
    }
}
