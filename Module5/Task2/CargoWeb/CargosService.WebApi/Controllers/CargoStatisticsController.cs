using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using CargosService.Business.Contract.Services;
using CargosService.Common.WebDto;

namespace CargosService.WebApi.Controllers
{
    public class CargoStatisticsController : ApiController
    {
        private readonly ICargoService _cargoService;

        public CargoStatisticsController(ICargoService cargoService)
        {
            _cargoService = cargoService;
        }

        [HttpGet]
        public IEnumerable<CargoDto> GetTop([FromUri]int count)
        {
            var cargoes = _cargoService.GetTop(count);
            var dtos = Mapper.Map<IEnumerable<CargoDto>>(cargoes);

            return dtos;
        }
    }
}
