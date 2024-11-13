using FarmaceuticaBack.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FarmaceuticaWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SPTotalesFarmaciaController : Controller
    {
        private readonly ISPTotalesFarmaciaService _service;

        public SPTotalesFarmaciaController(ISPTotalesFarmaciaService service)
        {
            _service = service;
        }
        [HttpGet("TotalesFarmacia")]
        public async Task<IActionResult> GetSp([FromQuery] int year)
        {
            try
            {
                var result = await _service.ExecuteSp(year);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpGet("TotalesCoberturas")]
        public async Task<IActionResult> GetTotalesCobertura([FromQuery] int year, [FromQuery] int month, [FromQuery] int obra)
        {
            try
            {
                var result = await _service.ExecuteSpCobertura(year, month, obra);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpGet("TotalesObraSocial")]
        public async Task<IActionResult> GetTotalesObrasSociales([FromQuery] int year, [FromQuery] int month, [FromQuery] int obra)
        {
            try
            {
                var result = await _service.ExecuteSpObraSocial(year, month, obra);
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
