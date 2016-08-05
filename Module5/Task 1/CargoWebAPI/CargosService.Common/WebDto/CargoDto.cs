using System;
using System.Runtime.Serialization;

namespace CargosService.Common.WebDto
{
    [DataContract]
    public class CargoDto
    {
        [DataMember]
        public Guid? Id { get; set; }

        [DataMember]
        public double Weight { get; set; }

        [DataMember]
        public double Volume { get; set; }

        [DataMember]
        public decimal Price { get; set; }

        [DataMember]
        public Guid RecepientId { get; set; }

        [DataMember]
        public Guid SenderId { get; set; }

        [DataMember]
        public Guid RouteId { get; set; }
    }
}