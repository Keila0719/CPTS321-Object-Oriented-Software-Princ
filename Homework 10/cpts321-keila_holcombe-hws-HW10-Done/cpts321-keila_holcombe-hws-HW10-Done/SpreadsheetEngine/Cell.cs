// <copyright file="Cell.cs" company="Keila Holcombe 011896868">
// Copyright (c) Keila Holcombe. All rights reserved.
// </copyright>
using System.ComponentModel;

namespace SpreadsheetEngine
{
    /// <summary>
    /// Represets an abstract class of Cells which provides the base structure
    /// of when dealing with cells. Stores the text and value for a single cell.
    /// </summary>
    public abstract class Cell : INotifyPropertyChanged
    {
        /// <summary>
        /// Stores the string of values. Represents the evaluated value of the cell.
        /// </summary>
#pragma warning disable SA1401 // Assignment requires protected field
        protected string value;
#pragma warning restore SA1401

        /// <summary>
        /// Stores the string of texts.
        /// </summary>
#pragma warning disable SA1401 // Assignment requires protected field
        protected string text;
#pragma warning restore SA1401

        /// <summary>
        /// Stores the previous text of the cell.
        /// </summary>
#pragma warning disable SA1401 // Assignment requires protected field
        protected string previousText;
#pragma warning restore SA1401

        /// <summary>
        /// Stores the uint of the bgcolor.
        /// </summary>
#pragma warning disable SA1401 // Assignment requires protected field
        protected uint bgColor;
#pragma warning restore SA1401

        /// <summary>
        /// Stores the previous uint of the cell.
        /// </summary>
#pragma warning disable SA1401 // Assignment requires protected field
        protected uint previousBGColor;
#pragma warning restore SA1401

        /// <summary>
        /// Initializes a new instance of the <see cref="Cell"/> class.
        /// This will initialize the RowIndex and Column Index.
        /// </summary>
        /// <param name="rowIndex"> The number of row for the cell.</param>
        /// <param name="columnIndex"> The number of column for the cell.</param>
        protected Cell(int rowIndex, int columnIndex)
        {
            this.RowIndex = rowIndex;
            this.ColumnIndex = columnIndex;
            this.value = string.Empty;
            this.text = string.Empty;
            this.bgColor = 0xFFFFFFFF;
            this.previousText = string.Empty;
            this.previousBGColor = 0xFFFFFFFF;
        }

        /// <summary>
        /// Event that will happen when the property of text is changed.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Event that will happen when the value is changed.
        /// </summary>
        public event PropertyChangedEventHandler? ValueChanged;

        /// <summary>
        /// Gets the number that the RowIndex is currently storing.
        /// </summary>
        public int RowIndex { get; }

        /// <summary>
        /// Gets the number that the ColumnIndex is currently storing.
        /// </summary>
        public int ColumnIndex { get; }

        /// <summary>
        /// Gets the current cell's previous text.
        /// </summary>
        public string PreviousText
        {
            get => this.previousText;
        }

        /// <summary>
        /// Gets the current cell's previous bgcolor.
        /// </summary>
        public uint PreviousBGColor
        {
            get => this.previousBGColor;
        }

        /// <summary>
        /// Gets or sets the color value to the current bgcolor.
        /// </summary>
        public uint BGColor
        {
            get => this.bgColor;

            set
            {
                // Save the previous BGcolor
                this.previousBGColor = this.BGColor;
                this.bgColor = value;
                this.OnPropertyChanged(nameof(this.BGColor));
            }
        }

        /// <summary>
        /// Gets or sets the text variable or sets the text variable after checking with the value.
        /// </summary>
        public string Text
        {
            get => this.text;

            set
            {
                if (this.text == value)
                {
                    return;
                }

                // Save what the previous text was
                this.previousText = this.text;
                this.text = value;
                this.OnPropertyChanged(nameof(this.Text));
            }
        }

        /// <summary>
        /// Gets the text variable or sets the text variable by using the value.
        /// </summary>
        public string Value
        {
            get { return this.value; }
        }

        /// <summary>
        /// Protected method to raise the event to notify the changes.
        /// </summary>
        /// <param name="propertyName"> The name of the property changed.</param>
        protected void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// This will notigy that the value has changed.
        /// </summary>
        /// <param name="propertyName"> The property name of the string.</param>
        protected void OnValueChanged(string propertyName)
        {
            this.ValueChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
