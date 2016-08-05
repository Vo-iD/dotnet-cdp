using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using AutoMapper;
using CargosService.Common.WebDto;
using CargosService.DataAccess.Contract.Exceptions;
using CargosService.DataAccess.Contract.Infrastructure;
using CargosService.DataAccess.Contract.Models;

namespace CargosService.WebApi.Controllers
{
    public class CargosController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public CargosController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public CargoDto Get(Guid id)
        {
            try
            {
                var cargo = _unitOfWork.Repository<Cargo>().Get(id);
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
                _unitOfWork.Repository<Cargo>().Insert(cargo);
                _unitOfWork.Save();
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
                _unitOfWork.Repository<Cargo>().Update(cargo);
                _unitOfWork.Save();
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
                _unitOfWork.Repository<Cargo>().Delete(id);
                _unitOfWork.Save();
            }
            catch (EntityNotFoundException)
            {
                Request.CreateErrorResponse(HttpStatusCode.NotFound, string.Format("Cargo with id {0} not found.", id));
                throw;
            }

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(id.ToString())
            };
        }
    }
}
