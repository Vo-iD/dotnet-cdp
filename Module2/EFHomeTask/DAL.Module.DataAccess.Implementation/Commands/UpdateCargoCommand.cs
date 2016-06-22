using DAL.Module.DataAccess.Contract.Models;

namespace DAL.Module.DataAccess.Implementation.Commands
{
    public class UpdateCargoCommand : AbstractSqlCommand
    {
        private readonly Cargo _cargo;

        public UpdateCargoCommand(Cargo cargo, string schema = "dbo")
            : base(schema)
        {
            _cargo = cargo;
        }

        protected override string ProcedureName
        {
            get { return "UpdateCargo"; }
        }

        protected override void ExecuteCommand()
        {
            Command.Parameters.AddWithValue("Id", _cargo.Id);
            Command.Parameters.AddWithValue("Weight", _cargo.Weight);
            Command.Parameters.AddWithValue("Volume", _cargo.Volume);
            Command.Parameters.AddWithValue("SenderId", _cargo.SenderId);
            Command.Parameters.AddWithValue("RecepientId", _cargo.RecepientId);
            Command.Parameters.AddWithValue("RouteId", _cargo.RouteId);
            Command.Parameters.AddWithValue("Price", _cargo.Price);

            Command.ExecuteNonQuery();
        }
    }
}
