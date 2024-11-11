using FarmaceuticaBack.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FarmaceuticaWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BarrioController : Controller
    {
        private readonly IBarrioService _service;

        public BarrioController(IBarrioService service)
        {
            _service = service; 
        }
        [HttpGet]
        public async Task<IActionResult> GetBarrios()
        {
            return Ok(await _service.GetAll());
        }
    }
}
