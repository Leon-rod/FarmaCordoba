using FarmaceuticaBack.Models;
using FarmaceuticaBack.Services.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FarmaceuticaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly ProductoService _service;

        public ProductoController(ProductoService service)
        {
            _service = service;
        }

        //Task<int> GetLastId();

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var productos = await _service.GetAll();
                if (productos.Count > 0)
                {
                    return Ok(productos);
                }
                else
                {
                    return StatusCode(500, "No hay productos");
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, "Error en el sistema: " + e);
            }
        }

        [HttpGet("LastId")]
        public async Task<IActionResult> GetLastId()
        {
            return Ok(await _service.GetLastId());
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            try
            {
                if (id > 0)
                {
                    var producto = await _service.GetById(id);
                    if (producto != null)
                    {
                        return Ok(producto);
                    }
                    else
                    {
                        return StatusCode(400, "No existen productos disponibles");
                    }
                }
                else
                {
                    return BadRequest("El parámetro debe ser mayor a 0");
                }

            }
            catch (Exception e)
            {
                return StatusCode(500, "Error: " + e);
            }
        }

        [HttpGet("filtros")]
        public async Task<IActionResult> GetProdByFilters([FromQuery] string nombre, [FromQuery] int marca, [FromQuery] int tipoProd, [FromQuery] bool active)
        {
            try
            {
                var productos = await _service.GetByFilters(nombre, marca, tipoProd, active);
                if (productos.Count > 0)
                {
                    return Ok(productos);
                }
                else
                {
                    return StatusCode(500, "No hay productos");
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, "Error en el sistema: " + e);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] Producto p)
        {
            try
            {
                if (p != null)
                {
                    if (await _service.Update(p))
                    {
                        return Ok("Actualizado con exito");
                    }
                    else
                    {
                        return StatusCode(400, "Error al actualizar, intente de nuevo");
                    }
                }
                else
                {
                    return BadRequest("Es necesario enviar un producto");
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, "Error en el sistema: " + e);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromQuery] Producto producto)
        {
            try
            {
                if (producto != null)
                {
                    if (Validar(producto))
                    {
                        if (await _service.Save(producto))
                        {
                            return Ok("Producto agregado exitosamente");
                        }
                        else
                        {
                            return StatusCode(500, "Error al agregar producto");
                        }
                    }
                    else
                    {
                        return BadRequest("Error en producto");
                    }
                }
                else
                {
                    return StatusCode(500, "El producto no puede ser nulo");
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, "Error en el sistema: " + e);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            try
            {
                if (id > 0)
                {
                    if (await _service.Delete(id))
                    {
                        return Ok("Eliminado con exito");
                    }
                    else
                    {
                        return NotFound("No existe articulo id");
                    }
                }
                else
                {
                    return BadRequest("El id debe ser mayor a 0");
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, "Error en el sistema: " + e);
            }
        }

        private bool Validar(Producto producto)
        {
            bool aux = true;
            if (string.IsNullOrEmpty(producto.Nombre) || string.IsNullOrEmpty(producto.Descripcion) || producto.Nombre.Length > 100 || producto.Descripcion.Length > 255 || producto.IdMarca < 1 || producto.TipoProducto < 1 || producto.Precio < 1)
            {
                aux = false;
                return aux;
            }
            return aux;
        }
    }
}
