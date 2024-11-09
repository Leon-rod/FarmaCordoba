using FarmaceuticaBack.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FarmaceuticaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClientes()
        {
            try
            {
                var clientes = await _clienteService.GetAll();
                if(clientes.Count > 0)
                {
                    return Ok(clientes);
                }
                else
                {
                    return StatusCode(400, "No hay clientes en la base de datos");
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, "Error en el servidor: " + e);
            }
        }
    }
}
