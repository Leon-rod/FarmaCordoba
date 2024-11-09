using FarmaceuticaBack.Models;
using FarmaceuticaBack.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FarmaceuticaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _service;

        public PedidoController(IPedidoService service)
        {
            _service = service;
        }

        [HttpGet("LastId")]

        public async Task<IActionResult> GetLastId()
        {
            return Ok(await _service.GetLastId());
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPedidos()
        {
            try
            {
                var pedidos = await _service.GetAll();
                if (pedidos.Count > 0)
                {
                    return Ok(pedidos);
                }
                return StatusCode(500, "No hay pedidos disponibles");
            }
            catch (Exception e)
            {
                return StatusCode(500, "Error en el servidor..." + e);
            }
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetPedidoId([FromQuery] int id)
        {
            try
            {
                if (id <= 0)
                {
                    return StatusCode(500, "Debe introducir un numero de pedido mayor a 0");
                }
                else
                {
                    var pedido = await _service.GetById(id);
                    if (pedido != null)
                    {
                        return Ok(pedido);
                    }
                    else
                    {
                        return StatusCode(500, "No existe ese numero de pedido");
                    }
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, "Error en el servidor:" + e);
            }
        }

        [HttpGet("logistica")]
        public async Task<IActionResult> GetByLogistica(string cuit)
        {
            try
            {
                if (string.IsNullOrEmpty(cuit))
                {
                    return StatusCode(500, "Debe introducir un CUIT");
                }
                else
                {
                    if (SoloNumeros(cuit))
                    {
                        var pedidos = await _service.GetByLogistica(cuit);
                        return Ok(pedidos);
                    }
                    else
                    {
                        return StatusCode(500, "El CUIT solo debe llevar numeros");
                    }
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, "Error en el servidor:" + e);
            }
        }

        [HttpGet("establecimiento")]
        public async Task<IActionResult> GetByEstablecimiento([FromQuery] int id)
        {
            try
            {
                if (id <= 0)
                {
                    return StatusCode(500, "Debe introducir un numero de pedido mayor a 0");
                }
                else
                {
                    var pedido = await _service.GetByEstablecimiento(id);
                    if (pedido.Count > 0)
                    {
                        return Ok(pedido);
                    }
                    else
                    {
                        return StatusCode(500, "No hay pedidos para el establecimiento indicado");
                    }
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, "Error en el servidor:" + e);
            }
        }

        [HttpGet("fechas")]
        public async Task<IActionResult> GetByFechas([FromQuery] DateTime fechaDesde, [FromQuery] DateTime fechaHasta)
        {
            try
            {
                DateOnly fromDateOnly = DateOnly.FromDateTime(fechaDesde);
                DateOnly toDateOnly = DateOnly.FromDateTime(fechaHasta);

                if (fromDateOnly > toDateOnly)
                {
                    return StatusCode(500, "La fecha desde debe ser mayor a la fecha hasta");
                }
                else
                {
                    var pedidos = await _service.GetByFecha(fechaDesde, fechaHasta);
                    if (pedidos.Count > 0)
                    {
                        return Ok(pedidos);
                    }
                    else
                    {
                        return StatusCode(500, "No hay pedidos para las fechas brindadas");
                    }
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, "Error en el servidor:" + e);
            }
        }

        [HttpPost]
        public async Task<IActionResult> SavePedido(Pedido pedido)
        {
            try
            {
                if (ValidarPedido(pedido) && ValidarFecha(pedido))
                {
                    if (await _service.Save(pedido))
                    {
                        return Ok("Pedido guardado con éxito");
                    }
                    else
                    {
                        return StatusCode(500, "No se pudo guardar su pedido");
                    }
                }
                else
                {
                    return StatusCode(500, "Su pedido no pasó las validaciones");
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, "Error en el servidor:" + e);
            }
        }

        [HttpPut]
        public async Task<IActionResult> EditPedido(Pedido pedido)
        {
            try
            {
                if (ValidarPedido(pedido))
                {
                    if (await _service.Edit(pedido))
                    {
                        return Ok("Pedido editado con éxito");
                    }
                    else
                    {
                        return StatusCode(500, "No se pudo editar su pedido");
                    }
                }
                else
                {
                    return StatusCode(500, "Su pedido no pasó las validaciones");
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, "Error en el servidor:" + e);
            }
        }


        private bool ValidarPedido(Pedido pedido)
        {
            bool aux = true;

            if (string.IsNullOrEmpty(pedido.IdLogistica) || pedido.IdLogistica.Length > 20 || pedido.IdLogistica.Length < 1)
            {
                aux = false;
                return aux;
            }

            DateOnly fechaDesde = DateOnly.FromDateTime(DateTime.Now.AddDays(-1));
            DateOnly fechaHasta = DateOnly.FromDateTime(DateTime.Now.AddDays(1));
            if (pedido.Fecha >= fechaHasta || pedido.Fecha <= fechaDesde)
            {
                aux = false;
                return aux;
            }

            if (pedido.IdPersonalCargosEstablecimientos < 0)
            {
                aux = false;
                return aux;
            }
            return aux;
        }
        private bool ValidarFecha(Pedido pedido)
        {
            bool aux = true;

            DateOnly fechaDesde = DateOnly.FromDateTime(DateTime.Now.AddDays(-1));
            DateOnly fechaHasta = DateOnly.FromDateTime(DateTime.Now.AddDays(1));
            if (pedido.Fecha > fechaHasta || pedido.Fecha < fechaDesde)
            {
                aux = false;
                return aux;
            }
            return aux;
        }

        private bool SoloNumeros(string cuit)
        {
            return long.TryParse(cuit, out _);
        }

    }
}
