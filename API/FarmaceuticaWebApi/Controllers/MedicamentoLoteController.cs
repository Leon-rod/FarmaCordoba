using FarmaceuticaBack.Models;
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

        [HttpDelete]

        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            try
            {
                if (id != 0 && id != null)
                {
                    var baja = await _medicamentoLoteService.Delete(id);
                    return Ok("Se dio la baja con exito");
                }
                return StatusCode(500, "Debe ingresar un codigo o Uno de valor distinto a 0");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error en el servidor");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
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
                    return StatusCode(400, "No hay lotes en la base de datos");
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, "Error en el servidor: " + e);
            }
        }

        [HttpGet("LastId")]

        public async Task<IActionResult> GetLastId()
        {
            return Ok(await _medicamentoLoteService.GetLastId());   
        }

        [HttpPost]

        public async Task<IActionResult> AddLote(MedicamentosLote oMedicamento)
        {
            if(oMedicamento.IdMedicamento == 0 || oMedicamento.IdMedicamento == null)
            {
                return BadRequest("Debe ingresar un medicamento");
            }

            if (oMedicamento.Lote == "0" || oMedicamento.Lote == null)
            {
                return BadRequest("Debe ingresar un lote");
            }

            if(oMedicamento.FechaVencimiento == DateOnly.MinValue || oMedicamento.FechaVencimiento == null)
            {
                return BadRequest("Debe ingresar una fecha de vencimiento");
            }


            try
            {
                bool result = await _medicamentoLoteService.Add(oMedicamento);
                if (result)
                {
                    return Ok("Lote agregado.");
                }
                else
                {
                    return BadRequest("Hubo un problema.");
                } }
            catch (Exception exc)
            {
                return StatusCode(500, exc.ToString());
             
            }
        }
    }
}
