namespace lab3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Label titleLabel;
        private Label descriptionLabel;
        private Label categoryLabel;
        private Label amountLabel;
        private Label dateLabel;
        private Label searchLabel;
        private Label totalLabel;
        private Label countLabel;
        private TextBox descriptionTextBox;
        private TextBox categoryTextBox;
        private TextBox searchTextBox;
        private NumericUpDown amountNumericUpDown;
        private DateTimePicker expenseDatePicker;
        private Button addButton;
        private Button updateButton;
        private Button deleteButton;
        private Button clearButton;
        private DataGridView expensesGrid;

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
            components = new System.ComponentModel.Container();
            titleLabel = new Label();
            descriptionLabel = new Label();
            categoryLabel = new Label();
            amountLabel = new Label();
            dateLabel = new Label();
            searchLabel = new Label();
            totalLabel = new Label();
            countLabel = new Label();
            descriptionTextBox = new TextBox();
            categoryTextBox = new TextBox();
            searchTextBox = new TextBox();
            amountNumericUpDown = new NumericUpDown();
            expenseDatePicker = new DateTimePicker();
            addButton = new Button();
            updateButton = new Button();
            deleteButton = new Button();
            clearButton = new Button();
            expensesGrid = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)amountNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)expensesGrid).BeginInit();
            SuspendLayout();
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            titleLabel.Location = new Point(24, 18);
            titleLabel.Text = "Expense Tracker";
            descriptionLabel.AutoSize = true;
            descriptionLabel.Location = new Point(26, 76);
            descriptionLabel.Text = "Description";
            categoryLabel.AutoSize = true;
            categoryLabel.Location = new Point(226, 76);
            categoryLabel.Text = "Category";
            amountLabel.AutoSize = true;
            amountLabel.Location = new Point(426, 76);
            amountLabel.Text = "Amount";
            dateLabel.AutoSize = true;
            dateLabel.Location = new Point(566, 76);
            dateLabel.Text = "Date";
            descriptionTextBox.Location = new Point(26, 96);
            descriptionTextBox.Size = new Size(180, 23);
            categoryTextBox.Location = new Point(226, 96);
            categoryTextBox.Size = new Size(180, 23);
            amountNumericUpDown.DecimalPlaces = 2;
            amountNumericUpDown.Increment = 1;
            amountNumericUpDown.Maximum = 100000000;
            amountNumericUpDown.Location = new Point(426, 96);
            amountNumericUpDown.Size = new Size(120, 23);
            expenseDatePicker.Format = DateTimePickerFormat.Short;
            expenseDatePicker.Location = new Point(566, 96);
            expenseDatePicker.Size = new Size(120, 23);
            addButton.Location = new Point(26, 136);
            addButton.Size = new Size(90, 32);
            addButton.Text = "Add";
            addButton.Click += AddButton_Click;
            updateButton.Location = new Point(126, 136);
            updateButton.Size = new Size(90, 32);
            updateButton.Text = "Update";
            updateButton.Click += UpdateButton_Click;
            deleteButton.Location = new Point(226, 136);
            deleteButton.Size = new Size(90, 32);
            deleteButton.Text = "Delete";
            deleteButton.Click += DeleteButton_Click;
            clearButton.Location = new Point(326, 136);
            clearButton.Size = new Size(90, 32);
            clearButton.Text = "Clear";
            clearButton.Click += ClearButton_Click;
            searchLabel.AutoSize = true;
            searchLabel.Location = new Point(26, 198);
            searchLabel.Text = "Search";
            searchTextBox.Location = new Point(80, 195);
            searchTextBox.Size = new Size(280, 23);
            searchTextBox.TextChanged += SearchTextBox_TextChanged;
            totalLabel.AutoSize = true;
            totalLabel.Location = new Point(410, 198);
            totalLabel.Text = "Total: $0.00";
            countLabel.AutoSize = true;
            countLabel.Location = new Point(600, 198);
            countLabel.Text = "0 expense(s)";
            expensesGrid.AllowUserToAddRows = false;
            expensesGrid.AllowUserToDeleteRows = false;
            expensesGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            expensesGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            expensesGrid.Location = new Point(26, 230);
            expensesGrid.MultiSelect = false;
            expensesGrid.ReadOnly = true;
            expensesGrid.RowHeadersVisible = false;
            expensesGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            expensesGrid.Size = new Size(744, 270);
            expensesGrid.SelectionChanged += ExpensesGrid_SelectionChanged;
            expensesGrid.AutoGenerateColumns = true;
            ClientSize = new Size(800, 530);
            AutoScaleMode = AutoScaleMode.Font;
            Name = "Form1";
            Text = "Expense Tracker";
            Controls.Add(titleLabel);
            Controls.Add(descriptionLabel);
            Controls.Add(categoryLabel);
            Controls.Add(amountLabel);
            Controls.Add(dateLabel);
            Controls.Add(descriptionTextBox);
            Controls.Add(categoryTextBox);
            Controls.Add(amountNumericUpDown);
            Controls.Add(expenseDatePicker);
            Controls.Add(addButton);
            Controls.Add(updateButton);
            Controls.Add(deleteButton);
            Controls.Add(clearButton);
            Controls.Add(searchLabel);
            Controls.Add(searchTextBox);
            Controls.Add(totalLabel);
            Controls.Add(countLabel);
            Controls.Add(expensesGrid);
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)amountNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)expensesGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
