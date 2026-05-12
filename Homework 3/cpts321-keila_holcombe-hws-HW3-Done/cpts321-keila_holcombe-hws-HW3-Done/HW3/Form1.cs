// <copyright file="Form1.cs" company="Keila Holcombe 011896868">
// Copyright (c) Keila Holcombe. All rights reserved.
// </copyright>

using System.Text;

namespace HW3
{
    /// <summary>
    /// Represents the menu of the notepad application with the UI that allows user to navigate the application.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Load all text from the reader and put it in the text box.
        /// </summary>
        /// <param name="sr">The text file where the method will read from.</param>
        private void LoadText(TextReader sr)
        {
            // Using ReadToEnd() to load all text from the reader and put it in the text box
            this.textBox1.Text = sr.ReadToEnd();
        }

        /// <summary>
        /// Open file and load by calling the LoadText() method. I referenced the following links to learn about how to open a file using openFileDialog:
        /// Referenced https://learn.microsoft.com/en-us/dotnet/desktop/winforms/controls/how-to-open-files-using-the-openfiledialog-component
        /// Referenced https://learn.microsoft.com/en-us/dotnet/api/system.io.streamreader?view=net-10.0&redirectedfrom=MSDN.
        /// </summary>
        /// <param name="sender">The menu drop down that will trigger this method.</param>
        /// <param name="e">Contains the event data.</param>
        private void OpenFile(object sender, EventArgs e)
        {
            // Check if a user chose a valid file
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Get the file name
                string file = this.openFileDialog1.FileName;

                // Open file and save it to sr
                using (StreamReader sr = new StreamReader(file))
                {
                    // Load the file by calling LoadText() method
                    this.LoadText(sr);
                }
            }
        }

        /// <summary>
        /// Loads the first 50 fibonacci numbers into the text box.
        /// </summary>
        /// <param name="sender">The menu drop down that will trigger this method.</param>
        /// <param name="e">Contains the event data.</param>
        private void LoadFibonacciFifty(object sender, EventArgs e)
        {
            // Load first 50 Fibonacci numbers
            FibonacciTextReader fibonacciTextReader = new FibonacciTextReader(50);

            // Printing the strings to the textBox
            this.textBox1.Text = fibonacciTextReader.ReadToEnd();
        }

        /// <summary>
        /// Loads the first 100 fibonacci numbers into the text box.
        /// </summary>
        /// <param name="sender">The menu drop down that will trigger this method.</param>
        /// <param name="e">Contains the event data.</param>
        private void LoadFibonacciHundred(object sender, EventArgs e)
        {
            // Load first 100 Fibonacci numbers
            FibonacciTextReader fibonacciTextReader = new FibonacciTextReader(100);

            // Printing the strings to the textBox
            this.textBox1.Text = fibonacciTextReader.ReadToEnd();
        }

        /// <summary>
        /// Saves the information that is in the text box as a text file using SaveFileDialog1.
        /// Referenced: https://learn.microsoft.com/en-us/dotnet/desktop/winforms/controls/how-to-save-files-using-the-savefiledialog-component.
        /// </summary>
        /// <param name="sender">The menu drop down that will trigger this method.</param>
        /// <param name="e">Contains the event data.</param>
        private void SaveFile(object sender, EventArgs e)
        {
            // Save to file...
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Text Files | *.txt";
            saveFileDialog1.Title = "Save a text file";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
                {
                    sw.Write(this.textBox1.Text);
                }
            }
        }
    }
}