using AutoMapper;
using Common.WebDto;
using DataAccess.Contract.Models;

namespace EFHomeTask
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