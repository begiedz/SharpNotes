namespace SharpNotes.Data;

using Microsoft.Data.Sqlite;

public class DbConn
{
    private readonly string _connection;

    public DbConn(string connectionString) {
        if (string.IsNullOrWhiteSpace(connectionString))
            throw new ArgumentException("Missing connection string for Database connection");
        _connection = connectionString;
        EnsureCreated();
    }

    public SqliteConnection Open()
    {
        var conn = new SqliteConnection(_connection);
        conn.Open();
        return conn;
    }

    private void EnsureCreated() 
    {
        using var conn = new SqliteConnection(_connection);
        conn.Open();

        using var cmd = conn.CreateCommand();
        cmd.CommandText = """
            CREATE TABLE IF NOT EXISTS Notes (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            Title TEXT NOT NULL,
            Content TEXT NOT NULL,
            CreatedAt TEXT NOT NULL
            );
            """;
        cmd.ExecuteNonQuery();
    }
}
