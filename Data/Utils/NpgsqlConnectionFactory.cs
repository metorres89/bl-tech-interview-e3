using System.Data;
using System.Data.Common;
using Npgsql;

namespace BlTechInterviewE3.Data.Utils;

public class NpgsqlConnectionFactory : IDbConnectionFactory {
    private string _connectionString;

    public NpgsqlConnectionFactory(string connectionString) {
        _connectionString = connectionString;
    }

    public DbConnection GetConnection() {
        return new NpgsqlConnection(_connectionString);
    }

    public DbConnection GetConnection(string connectionString) {
        return new NpgsqlConnection(connectionString);
    }
}