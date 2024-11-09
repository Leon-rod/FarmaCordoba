using FarmaceuticaBack.Services.Contracts;
using FarmaceuticaBack.Services.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FarmaceuticaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicamentoLoteController : ControllerBase
    {
        private readonly IMedicamentoLoteService _medicamentoLoteService;

        public MedicamentoLoteController(IMedicamentoLoteService medicamentoLoteService)
        {
            _medicamentoLoteService = medicamentoLoteService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClientes()
        {
            try
            {
                var medicamentos = await _medicamentoLoteService.GetAll();
                if (medicamentos.Count > 0)
                {
                    return Ok(medicamentos);
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
