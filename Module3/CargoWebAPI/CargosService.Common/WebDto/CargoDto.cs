using System.Runtime.Serialization;

namespace CargosService.Common.WebDto
{
    [DataContract]
    public class CargoDto
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public double Weight { get; set; }

        [DataMember]
        public double Volume { get; set; }

        [DataMember]
        public decimal Price { get; set; }

        [DataMember]
        public int RecepientId { get; set; }

        [DataMember]
        public int SenderId { get; set; }

        [DataMember]
        public int RouteId { get; set; }
    }
}