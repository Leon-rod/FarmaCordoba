using Azure.Core;
using FarmaceuticaBack.Models;
using FarmaceuticaBack.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FarmaceuticaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetallePedidoController : ControllerBase
    {
        private readonly IDetallePedidoService _service;

        public DetallePedidoController(IDetallePedidoService service)
        {
            _service = service;
        }
        
        //Task<bool> Delete(int idPedido, int idDetalleP);

        [HttpGet]
        public async Task<IActionResult> GetByPedido([FromQuery]int id)
        {
            try
            {
                if (id <= 0)
                {
                    return StatusCode(500, "Debe introducir un numero de pedido mayor a 0");
                }
                else
                {
                    var pedido = await _service.GetByPedido(id);
                    if (pedido.Count > 0)
                    {
                        return Ok(pedido);
                    }
                    else
                    {
                        return StatusCode(500, "No existen detalles para ese numero de pedido");
                    }
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, "Error en el servidor:" + e);
            }
        }

        [HttpGet("detallePedido")]
        public async Task<IActionResult> GetByDetallePedido([FromQuery]int idPedido, [FromQuery]int idDetalleP)
        {
            try
            {
                if (idPedido > 0 && idDetalleP > 0)
                {
                    var pedido = await _service.GetByDetallePedido(idPedido, idDetalleP);
                    if(pedido != null)
                    {
                        return Ok(pedido);
                    }
                    else
                    {
                        return StatusCode(500, "No existen detalle de pedido con esa característica");
                    }
                }
                else
                {
                    return StatusCode(500, "Los parametros no son correctos, ambos deben ser mayores a 0");
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, "Error en el servidor:" + e);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody]DetallesPedido dp)
        {
            try
            {
                if (ValidarDetalle(dp))
                {
                    if (await _service.Save(dp))
                    {
                        return Ok("Se guardo el detalle con exito");
                    }
                    else
                    {
                        return StatusCode(500, "Error al guardar el detalle de pedido");
                    }
                }
                else
                {
                    return StatusCode(500, "Los datos del detalle no han pasado las validaciones");
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, "Error en el servidor:" + e);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDetallePedido([FromQuery]int idPedido, [FromQuery]int idDetalleP)
        {
            try
            {
                if (idPedido > 0 && idDetalleP > 0)
                {
                    if (await _service.Delete(idPedido, idDetalleP))
                    {
                        return Ok("Pedido eliminado con exito");
                    }
                    else
                    {
                        return StatusCode(500, "No existen detalle de pedido con esa característica");
                    }
                }
                else
                {
                    return StatusCode(500, "Los parametros no son correctos, ambos deben ser mayores a 0");
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, "Error en el servidor:" + e);
            }
        }

        private bool ValidarDetalle(DetallesPedido dp)
        {
            bool aux = true;
            if (dp.IdPedido < 1 || dp.IdDetallePedido < 1 || dp.Cantidad < 1 || (dp.IdMedicamentoLote < 1 & dp.IdProducto < 1) || (dp.IdMedicamentoLote > 1 & dp.IdProducto > 1) || dp.IdProveedor < 1)
            {
                aux = false;
                return aux;
            }
            return aux;
        }
    }
}
