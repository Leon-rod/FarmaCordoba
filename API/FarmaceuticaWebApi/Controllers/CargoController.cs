using FarmaceuticaBack.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FarmaceuticaWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CargoController : Controller
    {
        private readonly ICargoService _service;
        public CargoController(ICargoService service)
        {
            _service = service; 
        }

        [HttpGet]
        public async Task<IActionResult> GetCargos()
        {
            return Ok(await _service.GetAll());
        }
    }
}
