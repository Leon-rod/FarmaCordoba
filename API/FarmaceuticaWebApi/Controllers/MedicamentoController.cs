using FarmaceuticaBack.Data.Models;
using FarmaceuticaBack.Models;
using FarmaceuticaBack.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FarmaceuticaWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicamentoController : Controller
    {
        private readonly IMedicamentoService _service;
        public MedicamentoController(IMedicamentoService service)
        {
            _service = service;
        }
        [HttpGet("Filter")]
        public async Task<IActionResult> GetByFilter([FromQuery] MedicamentoFiltro filtro)
        {

          
                return Ok(await _service.GetByFiltro(filtro));
            

        }

        [HttpGet("Id")]

        public async Task<IActionResult> GetMedicamentoById([FromQuery] int id)
        {
            try
            {
                var med = await _service.GetMedicamentoById(id);
                if (med != null)
                {
                    return Ok(med);
                }
                else
                {
                    return NotFound("No se encontró el medicamento.");
                }

            }
            catch (Exception exc)
            {

                return StatusCode(500, "Error" + exc); ;
            }

        }


        [HttpGet("LastId")]

        public async Task<IActionResult> GetLastId()
        {
            return Ok(await _service.GetLastId());
        }
       
        [HttpGet]
        public async Task<IActionResult> GetMedicamentos()
        {
            try
            {
                var list = await _service.GetAll();
                if (list.Count > 0)
                {
                    return Ok(list);
                }
                return StatusCode(500, "No Hay Medicamentos Cargados En La Base De Datos...");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error en el servidor..." + ex);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteMedicamentos([FromQuery] int? id)
        {
            try
            {
                if (id != 0 && id != null)
                {
                    var baja = await _service.Delete(id);
                    return Ok("Se dio la baja con exito");
                }
                return StatusCode(500, "Debe ingresar un codigo o Uno de valor distinto a 0");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error en el servidor");
            }
        }

        [HttpPost]
        public async Task<IActionResult> SaveMedicamento([FromBody] Medicamento oMedicamento)
        {
            var result = IsValid(oMedicamento);
            if (result == null)
            {
                var response = await _service.Save(oMedicamento);
                if (response)
                    return Ok("Medicamento Registrado Con Exito");
                return StatusCode(500, "Error en el servidor");
            }
            return BadRequest(IsValid(oMedicamento));
        }
        
        [HttpPut]
        public async Task<IActionResult> PutMedicamento([FromBody] Medicamento oMedicamento)
        {
            try
            {
                var result = IsValid(oMedicamento);
                if (result == null)
                {
                    var obj = await _service.Update(oMedicamento);
                    return Ok("Se Ejecutaron Los Cambios Con Exito...");
                }
                return BadRequest(IsValid(oMedicamento));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Hubo Un Problema En El Servidor" + ex);
            }
        }
        private string? IsValid(Medicamento oMedicamento)
        {
            string? result = null;
            if (oMedicamento.IdMedicamento == 0 || oMedicamento.IdMonodroga == 0 || oMedicamento.IdLaboratorio == 0 || oMedicamento.IdMarca == 0 || oMedicamento.IdPresentacion == 0)
                result = "El Campo Debe Ser Mayor a 0";
            if (oMedicamento.NombreComercial.Length > 100 || string.IsNullOrEmpty(oMedicamento.NombreComercial))
                result = "La Cantidad De Caracrteres Que Debe Tener Debe Ser Entre 1 y 100";
            if (oMedicamento.VentaLibre == null)
                result = "No Se Aceptan Valores Nulos En Este Campo";
            if (oMedicamento.Descripcion.Length > 255 || string.IsNullOrEmpty(oMedicamento.Descripcion))
                result = "La Lomgitud Del Campo Debe Tener De 1 a 255 Caracteres";
            if (oMedicamento.Precio == null)
                result = "Debe Ingresar Un Precio...";


            return result;
        }
    }
}
