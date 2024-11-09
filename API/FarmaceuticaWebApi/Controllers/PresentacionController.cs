using FarmaceuticaBack.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FarmaceuticaWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PresentacionController : Controller
    {
        private readonly IPresentacionService _service;

        public PresentacionController(IPresentacionService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetPresentaciones()
        {
            return Ok(await _service.GetPresentacion());
        }
    }
}
