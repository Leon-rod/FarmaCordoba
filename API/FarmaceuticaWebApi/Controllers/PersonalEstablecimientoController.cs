using FarmaceuticaBack.Models;
using FarmaceuticaBack.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FarmaceuticaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalEstablecimientoController : ControllerBase
    {
        private readonly IPersonalEstablecimientoService _service;
        public PersonalEstablecimientoController(IPersonalEstablecimientoService service)
        {
            this._service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<PersonalCargosEstablecimiento> list = await _service.GetAll();
                return Ok(list);
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
                PersonalCargosEstablecimiento personalEstablecimiento = await _service.GetById(id);
                return Ok(personalEstablecimiento);
            }
            catch (Exception e)
            {
                return StatusCode(500,e.Message);
            }
            
        }
    }
}
