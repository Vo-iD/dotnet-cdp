using System.Runtime.Serialization;

namespace EFHomeTask.WebDto
{
    [DataContract]
    public class CargoWebDto
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