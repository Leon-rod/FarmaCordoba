using FarmaceuticaBack.Data.Models;
using FarmaceuticaBack.Models;
using FarmaceuticaBack.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FarmaceuticaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly IFacturaService _service;
        public FacturaController(IFacturaService service)
        {
            this._service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Factura> facturas = await _service.GetAll();
                return Ok(facturas);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpGet("Client")]
        public async Task<IActionResult> GetByClient([FromQuery]int client)
        {
            try
            {
                List<Factura> facturas = await _service.GetByClient(client);
                return Ok(facturas);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
            
        }
        [HttpGet("Dates")]
        public async Task<IActionResult> GetByDates([FromQuery]DateTime startDate, [FromQuery] DateTime endDate)
        {
            try
            {
                DateOnly fromDate = DateOnly.FromDateTime(startDate);
                DateOnly toDate = DateOnly.FromDateTime(endDate);
                List<Factura> facturas = (startDate > endDate) ? await _service.GetByDates(toDate,fromDate) : await _service.GetByDates(fromDate, toDate);
                return Ok(facturas);
            }
            catch (Exception e)
            {
                return StatusCode(500,e.Message);
            }
            
        }
        [HttpGet("Employee")]
        public async Task<IActionResult> GetByEmployee([FromQuery] int employee)
        {
            try
            {
                List<Factura> facturas = await _service.GetByEmployee(employee);
                return Ok(facturas);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
            
        }
        [HttpGet("Establishment")]
        public async Task<IActionResult> GetByEstablishment([FromQuery]int establishment)
        {
            try
            {
                List<Factura> facturas = await _service.GetByEstablishment(establishment);
                return Ok(facturas);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
            
        }
        [HttpGet("ID")]
        public async Task<IActionResult> GetById([FromQuery]int id)
        {
            try
            {
                Factura? factura = await _service.GetById(id);
                if (factura == null)
                    return NotFound("No se ha encontrado una factura con ese id");
                return Ok(factura);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
            
        }

        [HttpGet("GetLastId")]
        public async Task<IActionResult> GetLastId()
        {
            try
            {
                int result = await _service.GetLastId();
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Factura? factura)
        {
            try
            {
                
                Factura? f = factura;
                if (f == null)
                    return BadRequest();
                string? validacion = ValidarFactura(f, Metodo.Post);
                if (validacion != null)
                    return BadRequest(validacion);
                bool result = await _service.Insert(f);
                if (result)
                    return Ok("Se ha agregado una factura con exito!");
                return StatusCode(500, "Ha ocurrido un error al intentar insertar una factura en la base de datos");
            }
            catch (Exception e)
            {
                return StatusCode(500,e.Message);
            }
            
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]Factura factura)
        {
            try
            {
                List<Factura> facturas = await _service.GetAll();
                Factura? f = null;
                foreach (Factura oFactura in facturas)
                {
                    if (oFactura.IdFactura == factura.IdFactura)
                        f = oFactura;
                }
                if (f == null)
                    return NotFound();
                string? validacion = ValidarFactura(factura, Metodo.Put);
                if (validacion != null)
                    return BadRequest(validacion);
                f.Fecha = factura.Fecha;
                f.IdPersonalCargosEstablecimientos = factura.IdPersonalCargosEstablecimientos;
                bool result = await _service.Update(f);
                if (result)
                    return Ok("Se ha actualizado la factura con exito");
                return StatusCode(500, "Ha ocurrido un error al intentar actualizar una factura en la base de datos");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
            
        }


        private string? ValidarFactura(Factura factura, Metodo metodo)
        {
            string? result = null;
            if (factura.Fecha > DateOnly.FromDateTime(DateTime.Today.Date) || factura.Fecha < DateOnly.FromDateTime(DateTime.Today.Date) && metodo == Metodo.Post)
            {
                result = "La factura solo se puede cargar si es de hoy";
            }
            if (factura.Fecha > DateOnly.FromDateTime(DateTime.Today.Date) || factura.Fecha < DateOnly.FromDateTime(DateTime.Today.Date) && metodo == Metodo.Put)
            {
                result = "La factura solo se puede actualizar si es de hoy";
            }
            if (factura.IdPersonalCargosEstablecimientos == null || factura.IdPersonalCargosEstablecimientos == 0)
                result = "La factura debe tener a un vendedor a cargo";
            if (factura.IdCliente == 0)
            {
                result = "La facturaa debe tener un cliente asignado";
            }
            return result;
        }
    }
}
