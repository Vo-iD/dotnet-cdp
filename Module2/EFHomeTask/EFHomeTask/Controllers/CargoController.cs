using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using DataAccess.Contract.Exceptions;
using DataAccess.Contract.Infrastructure;
using DataAccess.Contract.Models;
using EFHomeTask.WebDto;

namespace EFHomeTask.Controllers
{
    public class CargoController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public CargoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<CargoWebDto> Get()
        {
            var cargoes = _unitOfWork.Repository<Cargo>().Get().ToList();
            var webDtos = Mapper.Map<IEnumerable<CargoWebDto>>(cargoes);

            return webDtos;
        }

        [HttpGet]
        public CargoWebDto Get(int id)
        {
            try
            {
                var cargo = _unitOfWork.Repository<Cargo>().Get(id);
                var webDto = Mapper.Map<CargoWebDto>(cargo);

                return webDto;
            }
            catch (EntityNotFoundException)
            {
                Request.CreateErrorResponse(HttpStatusCode.NotFound, string.Format("Cargo with id {0} not found.", id));
                return null;
            }
        }

        [HttpPost]
        public void Post(CargoWebDto model)
        {
            var cargo = Mapper.Map<Cargo>(model);

            try
            {
                _unitOfWork.Repository<Cargo>().Insert(cargo);
                Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (EntityAlreadyExistException)
            {
                Request.CreateErrorResponse(HttpStatusCode.Conflict, "The same cargo already exists");
            }
        }

        [HttpPut]
        public void Put(CargoWebDto model)
        {
            var cargo = Mapper.Map<Cargo>(model);

            try
            {
                _unitOfWork.Repository<Cargo>().Update(cargo);
                Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (EntityNotFoundException)
            {
                Request.CreateErrorResponse(HttpStatusCode.NotFound,
                    string.Format("Cargo with id {0} not found.", model.Id));
            }
        }

        [HttpDelete]
        public void Delete(int id)
        {
            try
            {
                _unitOfWork.Repository<Cargo>().Delete(id);
                Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (EntityNotFoundException)
            {
                Request.CreateErrorResponse(HttpStatusCode.NotFound, string.Format("Cargo with id {0} not found.", id));
                throw;
            }
        }
    }
}
