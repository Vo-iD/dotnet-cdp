//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CargosService.DataAccess.Contract.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Cargo : EntityRoot
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cargo()
        {
            this.Shipments = new HashSet<Shipment>();
        }
    
        public double Weight { get; set; }
        public double Volume { get; set; }
        public decimal Price { get; set; }
        public System.Guid RecepientId { get; set; }
        public System.Guid SenderId { get; set; }
        public System.Guid RouteId { get; set; }
        public System.DateTime RegisterDate { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual Customer Customer1 { get; set; }
        public virtual Route Route { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Shipment> Shipments { get; set; }
    }
}
