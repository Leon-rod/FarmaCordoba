using FarmaceuticaBack.Models;
using FarmaceuticaBack.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FarmaceuticaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstablecimientoController : ControllerBase
    {
        private readonly IEstablecimientoService _service;
        public EstablecimientoController(IEstablecimientoService service)
        {
            this._service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Establecimiento> establecimientos = await _service.GetAll();
            if (establecimientos.Count > 0)
                return Ok(establecimientos);
            return Ok("No se encuentran establecimientos cargados");
        }
    }
}
