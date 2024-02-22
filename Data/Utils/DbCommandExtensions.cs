using System.Data;
using System.Data.Common;

namespace BlTechInterviewE3.Data.Utils;

public static class DbCommandExtensions
{
    public static void AddParameterWithValue(this DbCommand command, string parameterName, object value)
    {
        DbParameter parameter = command.CreateParameter();
        parameter.ParameterName = parameterName;
        parameter.Value = value ?? DBNull.Value;
        command.Parameters.Add(parameter);
    }
}
