using FarmaceuticaBack.Models;
using FarmaceuticaBack.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FarmaceuticaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockService _stockService;
        public StockController(IStockService stockService)
        {
            this._stockService = stockService;
        }
        [HttpGet("/Establishment")]
        public async Task<IActionResult> GetByEstablishment([FromQuery]int id)
        {
            List<Stock> stocks = await _stockService.GetByEstablishment(id);
            if (stocks.Count > 0)
                return Ok(stocks);
            return NotFound("No se encuentran stocks cargados en esta sucursal");
        }
        [HttpGet("/Establishment/Articles")]
        public async Task<IActionResult> GetByEstablishmentArticle([FromQuery]int id, [FromQuery]string? product, [FromQuery] string? medicine)
        {
            List<Stock> stocks = await _stockService.GetByEstablishmentAndArticle(id, product, medicine);
            if (stocks.Count > 0)
            {
                foreach (Stock stock in stocks)
                {
                    stock.IdProductoNavigation = null;
                    stock.IdMedicamentoLoteNavigation = null;
                    stock.IdEstablecimientoNavigation = null;
                }
                return Ok(stocks);
            }
            return NotFound("No se encuentran registros de stocks de ese articulo para ese establecimiento");
        }

        [HttpGet("/Establishment/Lotes")]
        public async Task<IActionResult> GetLoteByEstablishment([FromQuery] int id)
        {
            List<Stock> stocks = await _stockService.GetStockLotesByEstablishment(id);
            if (stocks.Count > 0)
            {

                return Ok(stocks);
            }
            return NotFound("No se encuentran registros de stocks de lotes para ese establecimiento");
        }


        [HttpGet("/Establishment/Lotes/Filter")]
        public async Task<IActionResult> GetLoteByEstablishmentFilter([FromQuery] int id, [FromQuery] string lote, [FromQuery] string medicamento)
        {
            List<Stock> stocks = await _stockService.GetStockLotesByEstablishmentAndFilter(id, lote, medicamento);
            if (stocks.Count > 0)
            {

                return Ok(stocks);
            }
            return NotFound("No se encuentran registros de stocks de lotes.");
        }

        [HttpGet("Lotes/Establecimiento")]
        public async Task<IActionResult> GetAllStockLotesByEstablishmentAndFilter([FromQuery]int establecimiento,[FromQuery] int medicamento,[FromQuery] int producto)
        {
            try
            {
                var stock = await _stockService.GetAllStockLotesByEstablishmentAndFilter(establecimiento, medicamento, producto);
                if(establecimiento > 0)
                {
                    if (stock.Count > 0)
                    {
                        return Ok(stock);
                    }
                    else
                    {
                        return NotFound("No se encuentran registros disponibles");
                    }
                }
                else
                {
                    return StatusCode(500, "No hay pedidos disponibles");
                }
                
            }
            catch (Exception e)
            {
                return StatusCode(500, "Error: " + e);
            }
        }

    }
}
