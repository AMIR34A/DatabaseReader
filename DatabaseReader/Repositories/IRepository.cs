using Microsoft.Data.SqlClient;
using System.Data;

namespace DatabaseReader.Repositories;

public interface IRepository : IDisposable
{
    //Task<SqlDataReader> ExecuteSQLCommandAsync(string query);
    Task<DataTable> ExecuteSQLCommandAsync(string query);
    void UpdateConnectionString(string connectionString);
    Task<int> GetCount(string tabelName);
}