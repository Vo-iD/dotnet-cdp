using AutoMapper;
using CargosService.Common.WebDto;
using CargosService.DataAccess.Contract.Models;

namespace CargosService.WebApi
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