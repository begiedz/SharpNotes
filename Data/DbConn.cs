namespace SharpNotes.Data;

using Microsoft.Data.Sqlite;

public class DbConn
{
    private readonly string _connection;

    public DbConn(string connectionString) {
        if (string.IsNullOrWhiteSpace(connectionString))
            throw new ArgumentException("Missing connection string for Database connection");
        _connection = connectionString;
    }

    public SqliteConnection Open()
    {
        var conn = new SqliteConnection(_connection);
        conn.Open();
        return conn;
    }
}
