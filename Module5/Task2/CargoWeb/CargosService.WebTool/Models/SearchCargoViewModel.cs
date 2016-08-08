using System.Collections.Generic;
using CargosService.Common.WebDto;

namespace CargosService.WebTool.Models
{
    public class SearchCargoViewModel
    {
        public string SearchTerm { get; set; }
        public IEnumerable<CargoDto> Cargos { get; set; }
    }
}