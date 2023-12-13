using DatabaseReader.Repositories;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DatabaseReader.Repository;

public class Repository : IRepository
{
    private readonly SqlConnection _connection;
    private bool disposedValue = false;

    public Repository(string connectionString) => _connection = new SqlConnection(connectionString);

    public async Task<DataTable> ExecuteSQLCommandAsync(string query) 
    {
        using SqlCommand command = new SqlCommand(query, _connection);
        await command.Connection.OpenAsync();
        SqlDataAdapter adapter = new SqlDataAdapter(command);
        DataTable dataTable = new DataTable();
        adapter.Fill(dataTable);
        await _connection.CloseAsync();
        return dataTable;
    }

    public async Task<int> GetCount(string tableName)
    {
        await _connection.OpenAsync();
        using SqlCommand command = new SqlCommand($"SELECT COUNT(*) FROM {tableName}", _connection);
        int count = (int)await command.ExecuteScalarAsync();
        await _connection.CloseAsync();
        return count;
    }

    public async Task<bool> DeleteAsync(string tableName,string id)
    {
        await _connection.OpenAsync();
        using SqlCommand command = new SqlCommand($"DELETE FROM {tableName} WHERE Id = '{id}'", _connection);
        int result = await command.ExecuteNonQueryAsync();
        return result > 0;
    }

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
