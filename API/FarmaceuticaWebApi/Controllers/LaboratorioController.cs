using FarmaceuticaBack.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FarmaceuticaWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LaboratorioController : Controller
    {
        private readonly ILaboratorioService _service;

        public LaboratorioController(ILaboratorioService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetMonodrogas()
        {
            return Ok(await _service.GetLaboratorio());
        }
    }
}
