//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL.Module.DataAccess.Contract.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class vShipment
    {
        public System.DateTime ShipmentDepartureDate { get; set; }
        public Nullable<System.DateTime> ShipmentDeliveryDate { get; set; }
        public int Distance { get; set; }
        public string SourceCity { get; set; }
        public string DestinationCity { get; set; }
        public int TruckId { get; set; }
        public string Brand { get; set; }
        public string Status { get; set; }
        public Nullable<double> TotalWeight { get; set; }
        public Nullable<double> TotalVolume { get; set; }
        public Nullable<int> CargoCount { get; set; }
        public Nullable<double> UtilizedTruckCapacity { get; set; }
        public Nullable<double> UtilizedTruckPayload { get; set; }
    }
}
