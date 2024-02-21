using System.Data;
using System.Data.Common;

namespace BlTechInterviewE3.Data.Utils;

public interface IDbConnectionFactory {
    DbConnection GetConnection();
    DbConnection GetConnection(string connectionString);
}