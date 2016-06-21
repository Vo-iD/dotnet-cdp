using AutoMapper;
using DAL.Module.Common.WebDto;
using DAL.Module.DataAccess.Contract.Models;

namespace DAL.Module.WebApi
{
    public static class AutomapperConfiguration
    {
        public static void CreateMappings()
        {
            DomainToWebDto();
            WebDtoToDomain();
        }

        private static void DomainToWebDto()
        {
            Mapper.CreateMap<Cargo, CargoDto>();
        }

        private static void WebDtoToDomain()
        {
            Mapper.CreateMap<CargoDto, Cargo>();
        }
    }
}