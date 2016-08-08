using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using CargosService.Business.Contract.Services;
using CargosService.Common.WebDto;
using CargosService.DataAccess.Contract.Exceptions;
using CargosService.DataAccess.Contract.Models;

namespace CargosService.WebApi.Controllers
{
    public class CargosController : ApiController
    {
        private readonly ICargoService _cargoService;

        public CargosController(ICargoService cargoService)
        {
            _cargoService = cargoService;
        }

        [HttpGet]
        public CargoDto Get(Guid id)
        {
            try
            {
                var cargo = _cargoService.Get(id);
                var webDto = Mapper.Map<CargoDto>(cargo);

                return webDto;
            }
            catch (EntityNotFoundException)
            {
                Request.CreateErrorResponse(HttpStatusCode.NotFound, string.Format("Cargo with id {0} not found.", id));
                return null;
            }
        }

        [HttpPost]
        public HttpResponseMessage Post(CargoDto model)
        {
            var cargo = Mapper.Map<Cargo>(model);

            try
            {
                _cargoService.Insert(cargo);
            }
            catch (EntityAlreadyExistException)
            {
                Request.CreateErrorResponse(HttpStatusCode.Conflict, "The same cargo already exists");
            }

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(cargo.Id.ToString())
            };
        }

        [HttpPut]
        public HttpResponseMessage Put(CargoDto model)
        {
            var cargo = Mapper.Map<Cargo>(model);

            try
            {
                _cargoService.Update(cargo);
            }
            catch (EntityNotFoundException)
            {
                Request.CreateErrorResponse(HttpStatusCode.NotFound,
                    string.Format("Cargo with id {0} not found.", model.Id));
            }

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(cargo.Id.ToString())
            };
        }

        [HttpDelete]
        public HttpResponseMessage Delete(Guid id)
        {
            try
            {
                _cargoService.Delete(id);
            }
            catch (EntityNotFoundException)
            {
                Request.CreateErrorResponse(HttpStatusCode.NotFound, string.Format("Cargo with id {0} not found.", id));
            }

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(id.ToString())
            };
        }
    }
}
