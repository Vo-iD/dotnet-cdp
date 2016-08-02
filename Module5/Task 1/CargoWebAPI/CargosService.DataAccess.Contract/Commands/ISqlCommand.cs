using System;
using System.Data.SqlClient;

namespace CargosService.DataAccess.Contract.Commands
{
    public interface ISqlCommand : IDisposable
    {
        void Execute(SqlConnection connection);

        void Execute(SqlConnection connection, SqlTransaction transaction);
    }
}
