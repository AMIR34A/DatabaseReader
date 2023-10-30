using DatabaseReader.Repositories;
using Microsoft.Data.SqlClient;

namespace DatabaseReader.Repository;

public class Repository : IRepository
{
    private readonly SqlConnection _connection;
    private bool disposedValue = false;

    public Repository(string connectionString) => _connection = new SqlConnection(connectionString);

    public async Task<SqlDataReader> ExecuteSQLCommandAsync(string query)
    {
        await _connection.OpenAsync();
        using SqlCommand command = new SqlCommand(query, _connection);
        var reader = await command.ExecuteReaderAsync();

        return reader;
    }

    public async Task CloseConnection() => await _connection.CloseAsync();

    public void UpdateConnectionString(string connectionString) => _connection.ConnectionString = connectionString;


    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
                _connection.Dispose();

            disposedValue = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    ~Repository() => Dispose();
}
