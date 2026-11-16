using lab3.Controllers;
using lab3.Data;
using lab3.Models;

namespace lab3
{
    public partial class Form1 : Form
    {
        private readonly ExpenseController _controller;

        public Form1()
        {
            InitializeComponent();
            _controller = new ExpenseController(new ExpenseRepository());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ClearEditor();
            LoadExpenses();
            expensesGrid.ClearSelection();
            ClearEditor();
        }

        private void LoadExpenses()
        {
            try
            {
                var expenses = _controller.GetExpenses(searchTextBox.Text);
                expensesGrid.DataSource = expenses.ToList();
                totalLabel.Text = $"Total: {expenses.Sum(expense => expense.Amount):C}";
                countLabel.Text = $"{expenses.Count} expense(s)";
            }
            catch (Exception exception)
            {
                MessageBox.Show(this, $"Unable to load expenses.\n{exception.Message}", "Database error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddButton_Click(object? sender, EventArgs e)
        {
            try
            {
                _controller.AddExpense(descriptionTextBox.Text, categoryTextBox.Text, amountNumericUpDown.Value, expenseDatePicker.Value);
                LoadExpenses();
                ClearEditor();
            }
            catch (ArgumentException exception)
            {
                ShowValidationError(exception.Message);
            }
        }

        private void UpdateButton_Click(object? sender, EventArgs e)
        {
            if (!TryGetSelectedId(out var id))
            {
                return;
            }

            try
            {
                _controller.UpdateExpense(id, descriptionTextBox.Text, categoryTextBox.Text, amountNumericUpDown.Value, expenseDatePicker.Value);
                LoadExpenses();
                ClearEditor();
            }
            catch (ArgumentException exception)
            {
                ShowValidationError(exception.Message);
            }
        }

        private void DeleteButton_Click(object? sender, EventArgs e)
        {
            if (!TryGetSelectedId(out var id))
            {
                return;
            }

            if (MessageBox.Show(this, "Delete the selected expense?", "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                _controller.DeleteExpense(id);
                LoadExpenses();
                ClearEditor();
            }
            catch (ArgumentException exception)
            {
                ShowValidationError(exception.Message);
            }
        }

        private void ClearButton_Click(object? sender, EventArgs e)
        {
            ClearEditor();
            expensesGrid.ClearSelection();
        }

        private void SearchTextBox_TextChanged(object? sender, EventArgs e)
        {
            LoadExpenses();
        }

        private void ExpensesGrid_SelectionChanged(object? sender, EventArgs e)
        {
            if (expensesGrid.CurrentRow?.DataBoundItem is not Expense expense)
            {
                return;
            }

            descriptionTextBox.Text = expense.Description;
            categoryTextBox.Text = expense.Category;
            amountNumericUpDown.Value = Math.Min(amountNumericUpDown.Maximum, expense.Amount);
            expenseDatePicker.Value = expense.ExpenseDate;
        }

        private bool TryGetSelectedId(out int id)
        {
            id = 0;
            if (expensesGrid.SelectedRows.Count > 0 && expensesGrid.SelectedRows[0].DataBoundItem is Expense expense)
            {
                id = expense.Id;
                return true;
            }

            ShowValidationError("Select an expense first.");
            return false;
        }

        private void ClearEditor()
        {
            descriptionTextBox.Clear();
            categoryTextBox.Clear();
            amountNumericUpDown.Value = 0;
            expenseDatePicker.Value = DateTime.Today;
        }

        private void ShowValidationError(string message)
        {
            MessageBox.Show(this, message, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
