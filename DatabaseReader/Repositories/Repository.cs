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

    public async Task<int> GetCountAsync(string tableName)
    {
        await _connection.OpenAsync();
        using SqlCommand command = new SqlCommand($"SELECT COUNT(*) FROM {tableName}", _connection);
        int count = (int)await command.ExecuteScalarAsync();
        await _connection.CloseAsync();
        return count;
    }

    public async Task<bool> DeleteAsync(string tableName, string deleteBy, string value)
    {
        try
        {
            await _connection.OpenAsync();
            using SqlCommand command = new SqlCommand($"DELETE FROM {tableName} WHERE [{deleteBy}] = '{value}'", _connection);
            int result = await command.ExecuteNonQueryAsync();
            return result > 0;
        }
        catch
        {
            return false;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<bool> UpdateAsync(string tableName, string updateBy, string value, string newValue)
    {
        try
        {
            await _connection.OpenAsync();
            using SqlCommand command = new SqlCommand($"UPDATE {tableName} SET {updateBy} = '{newValue}' WHERE {updateBy} = '{value}'", _connection);
            int result = await command.ExecuteNonQueryAsync();
            return result > 0;
        }
        catch
        {
            return false;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public void UpdateConnectionString(string connectionString)
    {
        _connection.Close();
        _connection.ConnectionString = connectionString;
    }

    public async Task CloseConnection() => await _connection.CloseAsync();

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
