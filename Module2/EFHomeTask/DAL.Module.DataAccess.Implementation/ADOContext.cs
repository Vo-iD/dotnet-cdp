using System.Collections.Generic;
using System.Data.SqlClient;
using DAL.Module.DataAccess.Contract.Commands;

namespace DAL.Module.DataAccess.Implementation
{
    public class AdoContext
    {
        public string ConnectionString { get; private set; }

        public Queue<ISqlCommand> Commands { get; private set; }

        public AdoContext(string connectionString)
        {
            ConnectionString = connectionString;

            Commands = new Queue<ISqlCommand>();
        }

        public void SaveChanges()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        foreach (ISqlCommand command in Commands)
                        {
                            command.Execute(connection, transaction);
                        }

                        transaction.Commit();
                    }
                    catch (SqlException)
                    {
                        transaction.Rollback();
                    }
                }
            }
        }
    }
}
