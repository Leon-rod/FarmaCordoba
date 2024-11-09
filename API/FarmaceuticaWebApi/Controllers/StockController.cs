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
            return Ok("No se encuentran stocks cargados en esta sucursal");
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
            return Ok("No se encuentran registros de stocks de ese articulo para ese establecimiento");
        }
    }
}
