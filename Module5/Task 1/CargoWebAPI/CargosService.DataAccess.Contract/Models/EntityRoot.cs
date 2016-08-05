using System;

namespace CargosService.DataAccess.Contract.Models
{
    public abstract class EntityRoot
    {
        protected EntityRoot()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }
}
