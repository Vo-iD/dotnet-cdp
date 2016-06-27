using System.Web.Http;
using CargosService.Business.Contract.Packaging;
using CargosService.DataAccess.Contract.Models;

namespace CargosService.WebApi.Controllers
{
    public class PackagesController : ApiController
    {
        private readonly IPackagingService _service;

        public PackagesController(IPackagingService service)
        {
            _service = service;
        }

        [HttpGet]
        public void Get()
        {
            _service.LoadTruck(new Truck());
        }
    }
}
