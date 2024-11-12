using FarmaceuticaBack.Data.Models;
using FarmaceuticaBack.Models;
using FarmaceuticaBack.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FarmaceuticaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaTipoPagoController : ControllerBase
    {
        private readonly IFacturaTipoPagoService _service;
        public FacturaTipoPagoController(IFacturaTipoPagoService service)
        {
            this._service = service;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]FacturasTiposPago facturasTiposPago)
        {
            try
            {
                string? validacion = Validar(facturasTiposPago, Metodo.Post);
                if (validacion != null)
                    return  BadRequest(validacion);
                bool result = await _service.Insert(facturasTiposPago);
                if (result) 
                    return Ok("Se ha insertado un método de pago con éxito");
                return StatusCode(500, "Ha ocurrido un error al intentar insertar un tipo de pago correspondiente a la factura");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        private string? Validar(FacturasTiposPago facturasTiposPago, Metodo metodo)
        {
            string? valor = null;
            if (facturasTiposPago.EsCuotas == true && (facturasTiposPago.CantidadCuotas == null || facturasTiposPago.CantidadCuotas < 1))
                valor = "El pago en cuotas debe tener asociada la cantidad de cuotas";
            if (facturasTiposPago.PorcentajePago == 0 || facturasTiposPago.PorcentajePago > 100)
                valor = "El porcentaje de pago debe ser válido (mayor a 0 y menor o igual a 100";
            if (facturasTiposPago.IdTipoPago == null)
                valor = "El pago debe tener una forma de pago vinculada";
            return valor;
        }
    }
}
