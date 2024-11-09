using FarmaceuticaBack.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FarmaceuticaWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReporteMensualObraSocialController : Controller
    {
        private readonly IReporteMensualObraSocialService _service;

        public ReporteMensualObraSocialController(IReporteMensualObraSocialService service)
        {
            _service = service; 
        }

        [HttpGet]

        public async Task<IActionResult> GetAll() {

            return Ok(await _service.GetAll());
        }

        [HttpGet("Filters")]

        public async Task<IActionResult> GetByFilters(string? OS, int? year, int? month)
        {
            var list = await _service.GetByFilters(OS,year, month);

            if (list.Count > 0)
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
