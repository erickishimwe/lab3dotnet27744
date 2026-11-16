using lab3.Models;
using MySqlConnector;

namespace lab3.Data;

public sealed class ExpenseRepository
{
    private readonly string _connectionString;

    public ExpenseRepository()
    {
        var configuredConnectionString = Environment.GetEnvironmentVariable("LAB3_DB_CONNECTION")
            ?? "Server=127.0.0.1;Port=3306;Database=lab3_expenses;User ID=root;Password=;";
        var connectionBuilder = new MySqlConnectionStringBuilder(configuredConnectionString);
        if (string.IsNullOrWhiteSpace(connectionBuilder.Database))
        {
            connectionBuilder.Database = "lab3_expenses";
        }

        _connectionString = connectionBuilder.ConnectionString;
        InitializeDatabase();
    }

    public List<Expense> GetAll(string? searchText = null)
    {
        using var connection = OpenConnection();
        using var command = connection.CreateCommand();
        command.CommandText = """
            SELECT Id, Description, Category, Amount, ExpenseDate
            FROM Expenses
            WHERE @Search = '' OR Description LIKE @Pattern OR Category LIKE @Pattern
            ORDER BY ExpenseDate DESC, Id DESC;
            """;
        var search = searchText?.Trim() ?? string.Empty;
        command.Parameters.AddWithValue("@Search", search);
        command.Parameters.AddWithValue("@Pattern", $"%{search}%");

        using var reader = command.ExecuteReader();
        var expenses = new List<Expense>();
        while (reader.Read())
        {
            expenses.Add(new Expense
            {
                Id = reader.GetInt32(0),
                Description = reader.GetString(1),
                Category = reader.GetString(2),
                Amount = reader.GetDecimal(3),
                ExpenseDate = reader.GetDateTime(4)
            });
        }

        return expenses;
    }

    public int Add(Expense expense)
    {
        using var connection = OpenConnection();
        using var command = connection.CreateCommand();
        command.CommandText = """
            INSERT INTO Expenses (Description, Category, Amount, ExpenseDate)
            VALUES (@Description, @Category, @Amount, @ExpenseDate);
            SELECT LAST_INSERT_ID();
            """;
        AddExpenseParameters(command, expense);
        return Convert.ToInt32(command.ExecuteScalar());
    }

    public void Update(Expense expense)
    {
        using var connection = OpenConnection();
        using var command = connection.CreateCommand();
        command.CommandText = """
            UPDATE Expenses
            SET Description = @Description,
                Category = @Category,
                Amount = @Amount,
                ExpenseDate = @ExpenseDate
            WHERE Id = @Id;
            """;
        AddExpenseParameters(command, expense);
        command.Parameters.AddWithValue("@Id", expense.Id);
        command.ExecuteNonQuery();
    }

    public void Delete(int id)
    {
        using var connection = OpenConnection();
        using var command = connection.CreateCommand();
        command.CommandText = "DELETE FROM Expenses WHERE Id = @Id;";
        command.Parameters.AddWithValue("@Id", id);
        command.ExecuteNonQuery();
    }

    private MySqlConnection OpenConnection()
    {
        var connection = new MySqlConnection(_connectionString);
        connection.Open();
        return connection;
    }

    private void InitializeDatabase()
    {
        var databaseBuilder = new MySqlConnectionStringBuilder(_connectionString);
        var databaseName = databaseBuilder.Database;
        if (string.IsNullOrWhiteSpace(databaseName))
        {
            databaseName = "lab3_expenses";
        }

        var serverBuilder = new MySqlConnectionStringBuilder(_connectionString)
        {
            Database = string.Empty
        };
        using var serverConnection = new MySqlConnection(serverBuilder.ConnectionString);
        serverConnection.Open();
        using var createDatabaseCommand = serverConnection.CreateCommand();
        createDatabaseCommand.CommandText = $"CREATE DATABASE IF NOT EXISTS `{databaseName}` CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;";
        createDatabaseCommand.ExecuteNonQuery();

        using var connection = OpenConnection();
        using var command = connection.CreateCommand();
        command.CommandText = """
            CREATE TABLE IF NOT EXISTS Expenses (
                Id INT NOT NULL AUTO_INCREMENT,
                Description VARCHAR(255) NOT NULL,
                Category VARCHAR(100) NOT NULL,
                Amount DECIMAL(12, 2) NOT NULL,
                ExpenseDate DATE NOT NULL,
                PRIMARY KEY (Id)
            );
            """;
        command.ExecuteNonQuery();
    }

    private static void AddExpenseParameters(MySqlCommand command, Expense expense)
    {
        command.Parameters.AddWithValue("@Description", expense.Description);
        command.Parameters.AddWithValue("@Category", expense.Category);
        command.Parameters.AddWithValue("@Amount", expense.Amount);
        command.Parameters.AddWithValue("@ExpenseDate", expense.ExpenseDate.Date);
    }
}
