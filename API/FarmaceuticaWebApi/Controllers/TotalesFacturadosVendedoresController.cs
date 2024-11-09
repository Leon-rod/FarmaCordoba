using FarmaceuticaBack.Models;
using FarmaceuticaBack.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FarmaceuticaWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TotalesFacturadosVendedoresController : Controller
    {
        private readonly ITotalesFacturadosVendedoresService _service;

        public TotalesFacturadosVendedoresController(ITotalesFacturadosVendedoresService service)
        {
            _service = service; 
        }

        [HttpGet]

        public async Task<IActionResult> GetTotales()
        {
            return Ok(await _service.GetTotales());
        }

        [HttpGet("Date")]

        public async Task<IActionResult> GetTotalesMonthYear(int? year, int? month)
        {

                var list = await _service.GetTotalesByMonthYear(year, month);

                if(list.Count > 0)
                {
                    return Ok(list);
                }
                else
                {
                    return NotFound("No se encontraron resultados.");
                }
            

        }
    }
}
