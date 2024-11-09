using FarmaceuticaBack.Models;
using FarmaceuticaBack.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FarmaceuticaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DispensacionController : ControllerBase
    {
        private readonly IDispensacionService _service;
        public DispensacionController(IDispensacionService service)
        {
            this._service = service;
        }
        [HttpGet("Factura")]
        public async Task<IActionResult> GetByFactura(int id)
        {
            try
            {
                List<Dispensacion> dispensacions = await _service.GetByIdFactura(id);
                return Ok(dispensacions);
            }
            catch (Exception e)
            {
                return StatusCode(500,e.Message);
            }
            
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Dispensacion d)
        {
            try
            {
                List<Dispensacion> dispensaciones = await _service.GetByIdFactura(d.IdFactura);
                int id = 0;
                if (dispensaciones.Count == 0)
                    id = 1;
                else
                    foreach (Dispensacion dis in dispensaciones)
                    {
                        if (dis.IdDispensacion >= id)
                            id = dis.IdDispensacion + 1;
                    }
                d.IdDispensacion = id;
                string? validacion = DispensacionValidator(d);
                if (validacion != null)
                    return BadRequest(validacion);
                bool result = await _service.Insert(d);
                if (result)
                    return Ok("Se ha agregado una dispensacion con exito!");
                return StatusCode(500, "Ha ocurrido un error al intentar agregar una dispensacion");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
            
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int idFactura, [FromQuery] int idDispensacion)
        {
            try
            {
                if (idFactura == 0 || idDispensacion == 0)
                    return BadRequest("El id de factura y de dispensacion deben ser validos");
                bool result = await _service.Delete(idFactura, idDispensacion);
                if (result)
                    return Ok("Se ha eliminado con exito una dispensacion de la base de datos!");
                return StatusCode(500, "Ha ocurrido un error al intentar eliminar una dispensacion");
            }
            catch (Exception e)
            {
                return StatusCode(500,e.Message);
            }
            
        }


        private string? DispensacionValidator(Dispensacion d)
        {
            string? result = null;
            if (d.IdFactura == 0)
                result = "La dispensacion debe tener un id de factura válido";
            if (d.Cantidad == 0)
                result = "La dispensacion debe tener una cantidad valida";
            if (d.IdProducto != null && (d.IdCobertura != null || d.IdMedicamentoLote != null || !String.IsNullOrEmpty(d.Matricula) || !String.IsNullOrEmpty(d.CodigoValidacion)))
                result = "No se deben combinar valores de un producto con un medicamento";
            if (d.IdProducto == null && d.IdMedicamentoLote == null)
                result = "Se deben cargar datos de un medicamento o producto";
            if (d.IdMedicamentoLote != null && (d.IdCobertura == null || String.IsNullOrEmpty(d.Matricula) || String.IsNullOrEmpty(d.CodigoValidacion)))
                result = "Se deben completar los datos referidos a medicamentos";
            return result;
        }
    }
}
