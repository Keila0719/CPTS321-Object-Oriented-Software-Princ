namespace HW3
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
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openFileToolStripMenuItem = new ToolStripMenuItem();
            loadFibonacciNumbersfirstToolStripMenuItem = new ToolStripMenuItem();
            loadFibonacciNumbersfirst100ToolStripMenuItem = new ToolStripMenuItem();
            saveToFileToolStripMenuItem = new ToolStripMenuItem();
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            textBox1 = new TextBox();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            //menuStrip1.ItemClicked += menuStrip1_ItemClicked;
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openFileToolStripMenuItem, loadFibonacciNumbersfirstToolStripMenuItem, loadFibonacciNumbersfirst100ToolStripMenuItem, saveToFileToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(46, 24);
            fileToolStripMenuItem.Text = "File";
            // 
            // openFileToolStripMenuItem
            // 
            openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            openFileToolStripMenuItem.Size = new Size(320, 26);
            openFileToolStripMenuItem.Text = "Load from file...";
            openFileToolStripMenuItem.Click += OpenFile;
            // 
            // loadFibonacciNumbersfirstToolStripMenuItem
            // 
            loadFibonacciNumbersfirstToolStripMenuItem.Name = "loadFibonacciNumbersfirstToolStripMenuItem";
            loadFibonacciNumbersfirstToolStripMenuItem.Size = new Size(320, 26);
            loadFibonacciNumbersfirstToolStripMenuItem.Text = "Load Fibonacci numbers (first 50)";
            loadFibonacciNumbersfirstToolStripMenuItem.Click += LoadFibonacciFifty;
            // 
            // loadFibonacciNumbersfirst100ToolStripMenuItem
            // 
            loadFibonacciNumbersfirst100ToolStripMenuItem.Name = "loadFibonacciNumbersfirst100ToolStripMenuItem";
            loadFibonacciNumbersfirst100ToolStripMenuItem.Size = new Size(320, 26);
            loadFibonacciNumbersfirst100ToolStripMenuItem.Text = "Load Fibonacci numbers (first 100)";
            loadFibonacciNumbersfirst100ToolStripMenuItem.Click += LoadFibonacciHundred;
            // 
            // saveToFileToolStripMenuItem
            // 
            saveToFileToolStripMenuItem.Name = "saveToFileToolStripMenuItem";
            saveToFileToolStripMenuItem.Size = new Size(320, 26);
            saveToFileToolStripMenuItem.Text = "Save to file...";
            saveToFileToolStripMenuItem.Click += SaveFile;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            //openFileDialog1.FileOk += openFileDialog1_FileOk;
            // 
            // saveFileDialog1
            // 
            //saveFileDialog1.FileOk += saveFileDialog1_FileOk;
            // 
            // textBox1
            // 
            textBox1.Dock = DockStyle.Fill;
            textBox1.Location = new Point(0, 28);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ScrollBars = ScrollBars.Both;
            textBox1.Size = new Size(800, 422);
            textBox1.TabIndex = 1;
            //textBox1.TextChanged += textBox1_TextChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBox1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openFileToolStripMenuItem;
        private ToolStripMenuItem loadFibonacciNumbersfirstToolStripMenuItem;
        private ToolStripMenuItem loadFibonacciNumbersfirst100ToolStripMenuItem;
        private ToolStripMenuItem saveToFileToolStripMenuItem;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        private TextBox textBox1;
    }
}
