using FarmaceuticaBack.Data.Models;
using FarmaceuticaBack.Models;
using FarmaceuticaBack.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FarmaceuticaWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventarioController : Controller
    {
        private readonly IInventarioService _inventarioService;

        public InventarioController(IInventarioService inventarioService)
        {
            _inventarioService = inventarioService;
        }

        [HttpGet("Movements")]

        public async Task<IActionResult> GetMovements()
        {
            return Ok(await _inventarioService.GetAllMovements());  
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInventarios()
        {
            return Ok(await _inventarioService.GetAll());
        }

        [HttpGet("Factura")]

        public async Task<IActionResult> GetInventarioByFactura(int id, DateTime from, DateTime to)
        {
            try
            {
                var inventario = await _inventarioService.GetInventarioByFactura(id, from, to);

                if (inventario != null)
                {
                    foreach(Inventario i in inventario)
                    {
                        i.DetallesPedido = null;
                        i.IdTipoMovNavigation = null;
                        i.IdStockNavigation = null; 
                    }
                    return Ok(inventario);
                }
                else
                {
                    return BadRequest("No se encontraron coincidencias.");
                }
            }
            catch (Exception exc)
            {
                return StatusCode(500, "Error de servidor");
            }

        }

        [HttpGet("Filters")]

        public async Task<IActionResult> GetInventarioByFilter([FromQuery]InventarioFiltro oFiltro)
        {
            if ((oFiltro.IdFactura == 0 || oFiltro.GetType().GetProperty("IdFactura")?.PropertyType != typeof(int?)) && oFiltro.IdFactura != null)
            {
                return BadRequest("El id factura no puede ser 0 y debe ser un entero");
            }

            if ((oFiltro.IdPedido == 0 || oFiltro.GetType().GetProperty("IdPedido")?.PropertyType != typeof(int?)) && oFiltro.IdFactura != null)
            {
                return BadRequest("El id pedido no puede ser 0 y debe ser un entero");
            }

            if ((oFiltro.IdTipoMov == 0 || oFiltro.GetType().GetProperty("IdTipoMov")?.PropertyType != typeof(int?)) && oFiltro.IdFactura != null)
            {
                return BadRequest("El id tipo movimiento no puede ser 0 y debe ser un entero");
            }

            return Ok(await _inventarioService.GetInventarioByFilter(oFiltro));
        }




        [HttpGet("Pedido")]

        public async Task<IActionResult> GetInventarioByPedido(int id, DateTime from, DateTime to)
        {
            try
            {
                var inventario = await _inventarioService.GetInventarioByPedido(id, from, to);

                if (inventario != null)
                {
                    return Ok(inventario);
                }
                else
                {
                    return BadRequest("No se encontraron coincidencias.");
                }
            }
            catch (Exception exc)
            {
                return StatusCode(500, "Error de servidor");
            }

        }


        [HttpPost("Inventario")]

        public async Task<IActionResult> CreateInventario(Inventario inv)
        {
            if(!(inv.IdFactura is int || inv.IdFactura is null))
            {
                return BadRequest("Si ingresa un numero de factura debe ser un entero");
            }
            
            if (!(inv.IdPedido is int || inv.IdPedido is null))
            {
                return BadRequest("Si ingresa un numero de pedido debe ser un entero");
            }

            if (!(inv.IdDispensacion is int || inv.IdDispensacion is null))
            {
                return BadRequest("Si ingresa un numero de dispensacion debe ser un entero");
            }

            if (!(inv.IdDetallePedido is int || inv.IdDetallePedido is null))
            {
                return BadRequest("Si ingresa un numero de dispensacion debe ser un entero");
            }

            if(inv.IdTipoMov == null || inv.IdTipoMov == 0)
            {
                return BadRequest("Debe ingresar un tipo de movimiento y no puede ser 0");
            }

            if(inv.IdStock == null || inv.IdStock == 0)
            {
                return BadRequest("Debe ingresar un numero de stock y no puede ser 0");
            }

            try
            {
                if (await _inventarioService.CreateInventario(inv)) 
                {
                    return Ok("Inventario creado");
                }
                else
                {
                    return BadRequest("No se pudo. Revise los datos.");
                }
            }
            catch (Exception)
            {

                return StatusCode(500, "Error de servidor");
            }

        }
    }
}
