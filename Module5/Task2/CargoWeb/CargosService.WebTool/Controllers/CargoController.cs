using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using CargosService.Business.Contract.Services;
using CargosService.Common.WebDto;
using CargosService.WebTool.Models;
using Microsoft.Security.Application;

namespace CargosService.WebTool.Controllers
{
    public class CargoController : Controller
    {
        private readonly ICargoService _cargoService;

        public CargoController(ICargoService cargoService)
        {
            _cargoService = cargoService;
        }

        // GET: Cargo
        [HttpGet]
        [ValidateInput(true)]
        public ActionResult Index(string cargoName)
        {
            var clearText = Sanitizer.GetSafeHtmlFragment(cargoName);
            var cargoes = _cargoService.SearchCargo(clearText);
            var dtos = Mapper.Map<IEnumerable<CargoDto>>(cargoes);
            var viewModel = new SearchCargoViewModel
            {
                SearchTerm = clearText,
                Cargos = dtos
            };

            return View(viewModel);
        }
    }
}