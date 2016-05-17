using AutoMapper;
using DataAccess.Contract.Models;
using EFHomeTask.WebDto;

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
            Mapper.CreateMap<Cargo, CargoWebDto>();
        }

        private static void WebDtoToDomain()
        {
            Mapper.CreateMap<CargoWebDto, Cargo>();
        }
    }
}