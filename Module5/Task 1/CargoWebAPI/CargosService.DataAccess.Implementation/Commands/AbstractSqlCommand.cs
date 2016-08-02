using System.Data;
using System.Data.SqlClient;
using CargosService.DataAccess.Contract.Commands;

namespace CargosService.DataAccess.Implementation.Commands
{
    public abstract class AbstractSqlCommand : ISqlCommand
    {
        protected readonly SqlCommand Command;
        protected abstract string ProcedureName { get; }

        protected AbstractSqlCommand(string schema)
        {
            Command = new SqlCommand(string.Format("{0}.{1}", schema, ProcedureName))
            {
                CommandType = CommandType.StoredProcedure
            };
        }

        protected abstract void ExecuteCommand();

        public void Execute(SqlConnection connection)
        {
            Command.Connection = connection;
            ExecuteCommand();
        }

        public void Execute(SqlConnection connection, SqlTransaction transaction)
        {
            Command.Connection = connection;
            Command.Transaction = transaction;
            ExecuteCommand();
        }

        public void Dispose()
        {
            Command.Dispose();
        }
    }
}
