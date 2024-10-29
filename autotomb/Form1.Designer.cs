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
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.WindowText;
            textBox1.Font = new Font("Cascadia Mono", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.ForeColor = SystemColors.Window;
            textBox1.Location = new Point(12, 12);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(776, 176);
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
            groupBox1.Location = new Point(12, 206);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(776, 149);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Options";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(68, 91);
            label2.Name = "label2";
            label2.Size = new Size(69, 15);
            label2.TabIndex = 5;
            label2.Text = "Update URL";
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
            button2.Location = new Point(108, 378);
            button2.Name = "button2";
            button2.Size = new Size(190, 37);
            button2.TabIndex = 4;
            button2.Text = "Auto-Detect Game";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(473, 378);
            button3.Name = "button3";
            button3.Size = new Size(190, 37);
            button3.TabIndex = 5;
            button3.Text = "Update Tomb";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(groupBox1);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "AutoTomb";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
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
    }
}
