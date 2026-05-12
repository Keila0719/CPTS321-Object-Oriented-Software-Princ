// <copyright file="Form1.cs" company="Keila Holcombe 011896868">
// Copyright (c) Keila Holcombe. All rights reserved.
// </copyright>
using System.ComponentModel;
using System.Security.Cryptography;
using SpreadsheetEngine;

namespace Spreadsheet_Keila_Holcombe
{
    /// <summary>
    /// Represents the main form the spreadsheet applications and helps assist with the UI.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Access the object of spreadsheet.
        /// </summary>
        private Spreadsheet spreadsheet;

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            this.spreadsheet = new Spreadsheet(50, 26);

            this.InitializeComponent();
            this.InitializeDataGrid();
            this.spreadsheet.CellPropertyChanged += this.CellPropertyChanged;
        }

        /// <summary>
        /// Initializes the data grid view. Clear what the grid has for column and row.
        /// Then add 26 colums with their name being from A - Z and also
        /// having 50 rows for each columns with the name being from 1 - 50.
        /// Referenced the following website to help implement the method:
        /// https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.datagridviewcolumn?view=windowsdesktop-10.0
        /// https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.datagridviewrow.headercell?view=windowsdesktop-10.0.
        /// </summary>
        public void InitializeDataGrid()
        {
            // Clear what the grid had for column and row
            this.dataGridView1.Columns.Clear();
            this.dataGridView1.Rows.Clear();

            this.dataGridView1.Size = new Size(300, 200);

            // Create A-Z columns
            this.dataGridView1.ColumnCount = 26;

            // Set the column header names A-Z
            for (int i = 0; i < 26; i++)
            {
                // inserting letters with ASCII numbers
                char letter = (char)(65 + i);
                this.dataGridView1.Columns[i].Name = letter.ToString();
            }

            // Create 1 - 50 rows
            this.dataGridView1.RowCount = 50;
            this.dataGridView1.RowHeadersVisible = true;

            // Set the column header names 1 - 50 rows
            for (int i = 0; i < 50; i++)
            {
                // inserting letters with ASCII numbers
                this.dataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
        }

        /// <summary>
        /// Demo button that will demonstrate the work done for this project.
        /// </summary>
        /// <param name="sender"> Object of the button.</param>
        /// <param name="e">Event data of the button clicked.</param>
        private void DemoButton(object sender, EventArgs e)
        {
            Random rand = new Random();

            // Get 50 random position and declare them as "Hello World"
            for (int i = 0; i < 50; i++)
            {
                int randomRow = rand.Next(0, 50);
                int randomCol = rand.Next(0, 26);
                this.spreadsheet?.GetCell(randomRow, randomCol)?.Text = "Hello World";
            }

            // Set all cells in column B to "This is cell B#" where # is the number.
            for (int i = 0; i < 50; i++)
            {
                this.spreadsheet?.GetCell(i, 1)?.Text = "This is cell B" + (i + 1);
            }

            // Then set all the cell in A to "=B#"
            for (int i = 0; i < 50; i++)
            {
                this.spreadsheet?.GetCell(i, 0)?.Text = "=B" + i;
            }
        }

        /// <summary>
        /// For the following code, I referenced:
        /// https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.datagridviewrow.cells?view=windowsdesktop-10.0.
        /// </summary>
        /// <param name="sender">Object of the Cell.</param>
        /// <param name="e"> The changed value.</param>
        private void CellPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (sender is not Cell currentCell)
            {
                return;
            }

            int row = currentCell.RowIndex;
            int column = currentCell.ColumnIndex;

            // Check if the property name of e is value or text
            if (e.PropertyName == "Value")
            {
                this.dataGridView1.Rows[row].Cells[column].Value = currentCell.Value;
            }
        }
    }
}
