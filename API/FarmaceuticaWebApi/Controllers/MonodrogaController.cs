using FarmaceuticaBack.Services.Contracts;
using FarmaceuticaBack.Services.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace FarmaceuticaWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MonodrogaController : Controller
    {
        private readonly IMonodrogaService _service;

        public MonodrogaController(IMonodrogaService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetMonodrogas()
        {
            return Ok(await _service.GetMonodroga());
        }
    }
}
