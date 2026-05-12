// <copyright file="Form1.cs" company="Keila Holcombe 011896868">
// Copyright (c) Keila Holcombe. All rights reserved.
// </copyright>
using System.ComponentModel;
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

            // Making it so that the button is disable and initialize the text
            this.undoToolStripMenuItem.Enabled = false;
            this.redoCellTextChangeToolStripMenuItem.Enabled = false;
            this.undoToolStripMenuItem.Text = "Undo: Nothing to undo";
            this.redoCellTextChangeToolStripMenuItem.Text = "Redo: Nothing to redo";
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
        /// An event that is triggered when the cell is changed.
        /// For the following code, I referenced:
        /// https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.datagridviewrow.cells?view=windowsdesktop-10.0.
        /// I referenced this to learn how to convert Uint -> Color:
        /// https://stackoverflow.com/questions/1328220/split-argb-into-byte-values.
        /// Referenced the following to learn how to enable or disable the button:
        /// https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.control.enabled?view=windowsdesktop-10.0.
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

            // Check if the property name of e is value
            if (e.PropertyName == "Value" || e.PropertyName == "Text")
            {
                this.dataGridView1.Rows[row].Cells[column].Value = currentCell.Value;
            }

            // Check if the property name of e is BGColor
            if (e.PropertyName == "BGColor")
            {
                // Change the uint to Color by getting their byte value
                byte b = (byte)(currentCell.BGColor & 0xFF);
                byte g = (byte)((currentCell.BGColor >> 8) & 0xFF);
                byte r = (byte)((currentCell.BGColor >> 16) & 0xFF);
                byte a = (byte)((currentCell.BGColor >> 24) & 0xFF);

                Color color = Color.FromArgb(a, r, g, b);
                this.dataGridView1.Rows[row].Cells[column].Style.BackColor = color;
            }

            // Update the button of each redo and undo
            this.undoToolStripMenuItem.Text = this.spreadsheet.GetUndoText();
            this.redoCellTextChangeToolStripMenuItem.Text = this.spreadsheet.GetRedoText();

            // If the text is nothing to undo, disable the button
            if (this.undoToolStripMenuItem.Text == "Undo: Nothing to undo")
            {
                this.undoToolStripMenuItem.Enabled = false;
            }
            else
            {
                this.undoToolStripMenuItem.Enabled = true;
            }

            // If the text is nothing to redo, disable the button
            if (this.redoCellTextChangeToolStripMenuItem.Text == "Redo: Nothing to redo")
            {
                this.redoCellTextChangeToolStripMenuItem.Enabled = false;
            }
            else
            {
                this.redoCellTextChangeToolStripMenuItem.Enabled = true;
            }
        }

        /// <summary>
        /// It will get triggered when the user clicks out from the cell.
        /// Referenced the following:
        /// https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.datagridview.cellbeginedit?view=windowsdesktop-10.0&redirectedfrom=MSDN.
        /// </summary>
        /// <param name="sender">The DataGridView object.</param>
        /// <param name="e">Object of the Cell.</param>
        private void DataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            // Get current the row and col
            int row = e.RowIndex;
            int column = e.ColumnIndex;

            // Get the cell at the position row and col
            Cell? currentCell = this.spreadsheet.GetCell(row, column);

            if (currentCell != null)
            {
                // Set the current cell's text to the current value so the user can see what the original expression was.
                this.dataGridView1.Rows[row].Cells[column].Value = currentCell.Text;
            }
        }

        /// <summary>
        /// It will get triggered when the user click into the cell.
        /// Referenced the following:
        /// https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.datagridview.cellendedit?view=windowsdesktop-10.0&redirectedfrom=MSDN
        /// https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.datagridview.cellendedit?view=windowsdesktop-10.0&redirectedfrom=MSDN
        /// https://stackoverflow.com/questions/16118085/best-practices-for-mapping-one-object-to-another.
        /// </summary>
        /// <param name="sender">The DataGribView object.</param>
        /// <param name="e">Object of the Cell.</param>
        private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e == null)
            {
                return;
            }

            if (sender == null)
            {
                return;
            }

            // Get the current row and col
            int row = e.RowIndex;
            int column = e.ColumnIndex;

            // Get the cell at the current position
            Cell? currentCell = this.spreadsheet.GetCell(row, column);

            if (currentCell != null)
            {
                string? current = string.Empty;

                current = this.dataGridView1.Rows[row]?.Cells[column]?.Value?.ToString();

                // Set the expression of what user typed to this cell's text so the cell will evaluate the value
#pragma warning disable CS8601 // Possible null reference assignment.
                currentCell.Text = current;
#pragma warning restore CS8601 // Possible null reference assignment.

                // Display the evaluated value
                this.dataGridView1.Rows[row].Cells[column].Value = currentCell.Value;
            }
        }

        /// <summary>
        /// When the user chooses to press the undo button, execute the undo method to bring the spreadsheet to the previous state.
        /// </summary>
        /// <param name="sender">Object of the button.</param>
        /// <param name="e">Event data of the button clicked.</param>
        private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check if sender is null
            if (sender == null)
            {
                return;
            }

            // Check if e is null
            if (e == null)
            {
                return;
            }

            // Execute the undo action
            this.spreadsheet.ExecuteUndo();
        }

        /// <summary>
        /// When the user chooses to press the redo button, execute the redo method to bring the spreadsheet to the future state.
        /// </summary>
        /// <param name="sender">Object of the button.</param>
        /// <param name="e">Event data of the button clicked.</param>
        private void RedoCellTextChangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // check if the sender is null
            if (sender == null)
            {
                return;
            }

            // Check if e is null
            if (e == null)
            {
                return;
            }

            // Execute the redo action
            this.spreadsheet.ExecuteRedo();
        }

        /// <summary>
        /// When the user chooses to change the color of the cell, it will allow them to select the color and change it.
        /// I have referenced the following website to learn how to use the color thing:
        /// https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.colordialog?view=windowsdesktop-10.0&redirectedfrom=MSDN
        /// https://learn.microsoft.com/en-us/dotnet/api/system.drawing.color?view=net-10.0&redirectedfrom=MSDN
        /// https://learn.microsoft.com/en-us/dotnet/api/system.drawing.color.fromargb?view=net-10.0&redirectedfrom=MSDN#System_Drawing_Color_FromArgb_System_Int32_.
        /// </summary>
        /// <param name="sender">Object of the button.</param>
        /// <param name="e">Event data of the button clicked.</param>
        private void ChangeBGColor_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedCells.Count == 0)
            {
                return;
            }

            if (sender == null)
            {
                return;
            }

            if (e == null)
            {
                return;
            }

            using (ColorDialog myDialog = new ColorDialog())
            {
                // Keeps the user from selecting a custom color.
                myDialog.AllowFullOpen = false;

                // Allows the user to get help. (The default is false.)
                myDialog.ShowHelp = true;

                if (myDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the color that the user selected
                    Color color = myDialog.Color;

                    // Change the color to uint
                    uint currentColor = (uint)color.ToArgb();
                    List<Cell> currentCells = new List<Cell>();

                    // For each currentCell, get the Cell and add it to the list
                    foreach (DataGridViewCell currentCell in this.dataGridView1.SelectedCells)
                    {
                        int row = currentCell.RowIndex;
                        int column = currentCell.ColumnIndex;

                        Cell? cell = this.spreadsheet?.GetCell(row, column);

                        if (cell != null)
                        {
                            currentCells.Add(cell);
                        }
                    }

                    // Execute the changecolor action
                    this.spreadsheet?.ChangeColor(currentCells, currentColor);
                }
            }
        }
    }
}
