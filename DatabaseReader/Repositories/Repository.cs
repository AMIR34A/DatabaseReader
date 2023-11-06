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
        //await _connection.OpenAsync();
        using SqlCommand command = new SqlCommand(query, _connection);
        //var reader = await command.ExecuteReaderAsync();
        await command.Connection.OpenAsync();
        SqlDataAdapter adapter = new SqlDataAdapter(command);
        DataTable dataTable = new DataTable();
        adapter.Fill(dataTable);
        return dataTable;
    }

    public async Task<int> GetCount(string tabelName)
    {
        await _connection.OpenAsync();
        using SqlCommand command = new SqlCommand($"SELECT COUNT(*) FROM {tabelName}", _connection);
        int count = (int)await command.ExecuteScalarAsync();
        await CloseConnection();
        return count;
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
