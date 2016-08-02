using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using CargosService.DataAccess.Contract.Commands;

namespace CargosService.DataAccess.Implementation
{
    public class AdoContext
    {
        public string ConnectionString { get; private set; }

        public Queue<ISqlCommand> Commands { get; private set; }

        public AdoContext()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["ShipmentEntitiesADO"].ConnectionString;

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
                    catch (SqlException ex)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}
