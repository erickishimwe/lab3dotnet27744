using lab3.Data;
using lab3.Models;

namespace lab3.Controllers;

public sealed class ExpenseController
{
    private readonly ExpenseRepository _repository;

    public ExpenseController(ExpenseRepository repository)
    {
        _repository = repository;
    }

    public IReadOnlyList<Expense> GetExpenses(string? searchText = null)
    {
        return _repository.GetAll(searchText);
    }

    public int AddExpense(string description, string category, decimal amount, DateTime date)
    {
        var expense = CreateValidatedExpense(description, category, amount, date);
        return _repository.Add(expense);
    }

    public void UpdateExpense(int id, string description, string category, decimal amount, DateTime date)
    {
        if (id <= 0)
        {
            throw new ArgumentException("Select a valid expense to update.");
        }

        var expense = CreateValidatedExpense(description, category, amount, date);
        expense.Id = id;
        _repository.Update(expense);
    }

    public void DeleteExpense(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentException("Select a valid expense to delete.");
        }

        _repository.Delete(id);
    }

    private static Expense CreateValidatedExpense(
        string description,
        string category,
        decimal amount,
        DateTime date)
    {
        description = description.Trim();
        category = category.Trim();

        if (string.IsNullOrWhiteSpace(description))
        {
            throw new ArgumentException("Description is required.");
        }

        if (string.IsNullOrWhiteSpace(category))
        {
            throw new ArgumentException("Category is required.");
        }

        if (amount <= 0)
        {
            throw new ArgumentException("Amount must be greater than zero.");
        }

        if (date.Date > DateTime.Today)
        {
            throw new ArgumentException("Expense date cannot be in the future.");
        }

        return new Expense
        {
            Description = description,
            Category = category,
            Amount = amount,
            ExpenseDate = date.Date
        };
    }
}
