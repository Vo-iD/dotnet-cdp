using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using DAL.Module.Common.WebDto;
using DAL.Module.DataAccess.Contract.Exceptions;
using DAL.Module.DataAccess.Contract.Infrastructure;
using DAL.Module.DataAccess.Contract.Models;

namespace DAL.Module.WebApi.Controllers
{
    public class CargoController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public CargoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<CargoDto> Get()
        {
            var cargoes = _unitOfWork.Repository<Cargo>().Get().ToList();
            var webDtos = Mapper.Map<IEnumerable<CargoDto>>(cargoes);

            return webDtos;
        }

        [HttpGet]
        public CargoDto Get(int id)
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
        public int Post(CargoDto model)
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

            return cargo.Id;
        }

        [HttpPut]
        public int Put(CargoDto model)
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

            return cargo.Id;
        }

        [HttpDelete]
        public int Delete(int id)
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

            return id;
        }
    }
}
