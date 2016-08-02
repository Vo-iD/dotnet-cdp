using System.Data;
using System.Data.SqlClient;
using CargosService.DataAccess.Contract.Exceptions;
using CargosService.DataAccess.Contract.Infrastructure;
using CargosService.DataAccess.Contract.Models;
using CargosService.DataAccess.Implementation.Commands;

namespace CargosService.DataAccess.Implementation.Repositories.AdoRepositories
{
    public class AdoCargoRepository : IRepository<Cargo>
    {
        private readonly AdoContext _context;

        public AdoCargoRepository(AdoContext context)
        {
            _context = context;
        }

        public Cargo Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(_context.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("dbo.SelectCargo", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("Id", id);

                    connection.Open();
                    var reader = command.ExecuteReader();

                    if (!reader.HasRows)
                    {
                        throw new EntityNotFoundException();
                    }

                    var cargo = MapCargo(reader);

                    return cargo;
                }
            }
        }

        public void Insert(Cargo entity)
        {
            var command = new InsertCargoCommand(entity);

            _context.Commands.Enqueue(command);
        }

        public void Update(Cargo entity)
        {
            var command = new UpdateCargoCommand(entity);

            _context.Commands.Enqueue(command);
        }

        public void Delete(int id)
        {
            var command = new DeleteCargoCommand(id);

            _context.Commands.Enqueue(command);
        }

        private Cargo MapCargo(SqlDataReader reader)
        {
            if (reader.Read())
            {
                var cargo = new Cargo
                {
                    Id = (int)reader["Id"],
                    Weight = (double)reader["Weight"],
                    Volume = (double)reader["Volume"],
                    SenderId = (int)reader["SenderId"],
                    RecepientId = (int)reader["RecepientId"],
                    RouteId = (int)reader["RouteId"],
                    Price = (decimal)reader["Price"]
                };

                return cargo;
            }

            return null;
        }
    }
}
