using FarmaceuticaBack.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FarmaceuticaWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SPTotalesFarmaciaController : Controller
    {
        private readonly ISPTotalesFarmaciaService _service;

        public SPTotalesFarmaciaController(ISPTotalesFarmaciaService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetSp([FromQuery] int year)
        {
            var result = await _service.ExecuteSp(year);
            return Ok(result);
        }
    }
}
