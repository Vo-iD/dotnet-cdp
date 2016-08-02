namespace CargosService.DataAccess.Implementation.Commands
{
    public class DeleteCargoCommand : AbstractSqlCommand
    {
        private readonly int _cargoId;

        public DeleteCargoCommand(int cargoId, string schema = "dbo")
            : base(schema)
        {
            _cargoId = cargoId;
        }

        protected override string ProcedureName
        {
            get { return "DeleteCargo"; }
        }

        protected override void ExecuteCommand()
        {
            Command.Parameters.AddWithValue("Id", _cargoId);
            Command.ExecuteNonQuery();
        }
    }
}
