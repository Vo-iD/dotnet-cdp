﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DbFirstContext : DbContext
    {
        public DbFirstContext()
            : base("name=bohdan_simianyk_cdp2016q1Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Cargo> Cargoes { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Crew> Crews { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<Route> Routes { get; set; }
        public virtual DbSet<Shipment> Shipments { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Truck> Trucks { get; set; }
        public virtual DbSet<Warehouse> Warehouses { get; set; }
        public virtual DbSet<vShipmentInfoCrossApply> vShipmentInfoCrossApplies { get; set; }
        public virtual DbSet<vShipmentInfoCTE> vShipmentInfoCTEs { get; set; }
        public virtual DbSet<vShipmentInfoJoin> vShipmentInfoJoins { get; set; }
        public virtual DbSet<vShipment> vShipments { get; set; }
    
        public virtual int DeleteCargo(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteCargo", idParameter);
        }
    
        public virtual int GetDriverInfo()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GetDriverInfo");
        }
    
        public virtual ObjectResult<GetDriverInfoXmlParsingFirstWay_Result> GetDriverInfoXmlParsingFirstWay(string xML)
        {
            var xMLParameter = xML != null ?
                new ObjectParameter("XML", xML) :
                new ObjectParameter("XML", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetDriverInfoXmlParsingFirstWay_Result>("GetDriverInfoXmlParsingFirstWay", xMLParameter);
        }
    
        public virtual ObjectResult<GetDriverInfoXmlParsingSecondWay_Result> GetDriverInfoXmlParsingSecondWay(string xML)
        {
            var xMLParameter = xML != null ?
                new ObjectParameter("XML", xML) :
                new ObjectParameter("XML", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetDriverInfoXmlParsingSecondWay_Result>("GetDriverInfoXmlParsingSecondWay", xMLParameter);
        }
    
        public virtual int InsertCargo(Nullable<float> weight, Nullable<float> volume, Nullable<int> senderId, Nullable<int> recepientId, Nullable<int> routeId, Nullable<float> price, ObjectParameter id)
        {
            var weightParameter = weight.HasValue ?
                new ObjectParameter("Weight", weight) :
                new ObjectParameter("Weight", typeof(float));
    
            var volumeParameter = volume.HasValue ?
                new ObjectParameter("Volume", volume) :
                new ObjectParameter("Volume", typeof(float));
    
            var senderIdParameter = senderId.HasValue ?
                new ObjectParameter("SenderId", senderId) :
                new ObjectParameter("SenderId", typeof(int));
    
            var recepientIdParameter = recepientId.HasValue ?
                new ObjectParameter("RecepientId", recepientId) :
                new ObjectParameter("RecepientId", typeof(int));
    
            var routeIdParameter = routeId.HasValue ?
                new ObjectParameter("RouteId", routeId) :
                new ObjectParameter("RouteId", typeof(int));
    
            var priceParameter = price.HasValue ?
                new ObjectParameter("Price", price) :
                new ObjectParameter("Price", typeof(float));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertCargo", weightParameter, volumeParameter, senderIdParameter, recepientIdParameter, routeIdParameter, priceParameter, id);
        }
    
        public virtual ObjectResult<ParsingFirstWay_Result> ParsingFirstWay(string xML)
        {
            var xMLParameter = xML != null ?
                new ObjectParameter("XML", xML) :
                new ObjectParameter("XML", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ParsingFirstWay_Result>("ParsingFirstWay", xMLParameter);
        }
    
        public virtual ObjectResult<ParsingSecondWay_Result> ParsingSecondWay(string xML)
        {
            var xMLParameter = xML != null ?
                new ObjectParameter("XML", xML) :
                new ObjectParameter("XML", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ParsingSecondWay_Result>("ParsingSecondWay", xMLParameter);
        }
    
        public virtual ObjectResult<SelectCargo_Result> SelectCargo(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SelectCargo_Result>("SelectCargo", idParameter);
        }
    
        public virtual int UpdateCargo(Nullable<int> id, Nullable<float> weight, Nullable<float> volume, Nullable<int> senderId, Nullable<int> recepientId, Nullable<int> routeId, Nullable<float> price)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var weightParameter = weight.HasValue ?
                new ObjectParameter("Weight", weight) :
                new ObjectParameter("Weight", typeof(float));
    
            var volumeParameter = volume.HasValue ?
                new ObjectParameter("Volume", volume) :
                new ObjectParameter("Volume", typeof(float));
    
            var senderIdParameter = senderId.HasValue ?
                new ObjectParameter("SenderId", senderId) :
                new ObjectParameter("SenderId", typeof(int));
    
            var recepientIdParameter = recepientId.HasValue ?
                new ObjectParameter("RecepientId", recepientId) :
                new ObjectParameter("RecepientId", typeof(int));
    
            var routeIdParameter = routeId.HasValue ?
                new ObjectParameter("RouteId", routeId) :
                new ObjectParameter("RouteId", typeof(int));
    
            var priceParameter = price.HasValue ?
                new ObjectParameter("Price", price) :
                new ObjectParameter("Price", typeof(float));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateCargo", idParameter, weightParameter, volumeParameter, senderIdParameter, recepientIdParameter, routeIdParameter, priceParameter);
        }
    }
}
