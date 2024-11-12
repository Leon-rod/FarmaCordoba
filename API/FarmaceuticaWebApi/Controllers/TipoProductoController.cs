using FarmaceuticaBack.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FarmaceuticaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoProductoController : ControllerBase
    {
        private readonly ITipoProductoService _service;

        public TipoProductoController(ITipoProductoService service)
        {
            _service = service;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetTipoProducto()
        {
            try
            {
                var tipos = await _service.GetAll();
                if (tipos.Count > 0)
                {
                    return Ok(tipos);
                }
                return StatusCode(500, "No hay tipos de producto disponibles");
            }
            catch (Exception e)
            {
                return StatusCode(500, "Error en el servidor..." + e);
            }
        }
    }
}
