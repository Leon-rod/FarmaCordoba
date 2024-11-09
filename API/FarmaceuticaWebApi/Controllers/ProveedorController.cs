using FarmaceuticaBack.Services.Contracts;
using FarmaceuticaBack.Services.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FarmaceuticaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        private readonly IProveedorService _proveedorService;

        public ProveedorController(IProveedorService proveedorService)
        {
            _proveedorService = proveedorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProveedores()
        {
            try
            {
                var proveedores = await _proveedorService.GetAll();
                if (proveedores.Count > 0)
                {
                    return Ok(proveedores);
                }
                else
                {
                    return StatusCode(400, "No hay proveedores en la base de datos");
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, "Error en el servidor: " + e);
            }
        }
    }
}
