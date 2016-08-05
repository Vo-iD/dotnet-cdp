using System;
using System.Data;
using CargosService.DataAccess.Contract.Models;

namespace CargosService.DataAccess.Implementation.Commands
{
    public class InsertCargoCommand : AbstractSqlCommand
    {
        private readonly Cargo _cargo;

        public InsertCargoCommand(Cargo cargo, string schema = "dbo")
            : base(schema)
        {
            _cargo = cargo;
        }

        protected override string ProcedureName
        {
            get { return "InsertCargo"; }
        }

        protected override void ExecuteCommand()
        {
            Command.Parameters.AddWithValue("Weight", _cargo.Weight);
            Command.Parameters.AddWithValue("Volume", _cargo.Volume);
            Command.Parameters.AddWithValue("SenderId", _cargo.SenderId);
            Command.Parameters.AddWithValue("RecepientId", _cargo.RecepientId);
            Command.Parameters.AddWithValue("RouteId", _cargo.RouteId);
            Command.Parameters.AddWithValue("Price", _cargo.Price);
            Command.Parameters.Add("Id", SqlDbType.Int).Direction = ParameterDirection.Output;

            Command.ExecuteNonQuery();
            _cargo.Id = (Guid)Command.Parameters["Id"].Value;
        }
    }
}
