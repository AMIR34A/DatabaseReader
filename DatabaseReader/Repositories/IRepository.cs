using System.Data;

namespace DatabaseReader.Repositories;

public interface IRepository : IDisposable
{
    Task<DataTable> ExecuteSQLCommandAsync(string query);
    void UpdateConnectionString(string connectionString);
    Task<int> GetCountAsync(string tableName);
    Task<bool> DeleteAsync(string tableName,string deleteBy, string value);
    Task<bool> UpdateAsync(string tableName, string updateBy, string value, string newValue);
    Task CloseConnection();
}