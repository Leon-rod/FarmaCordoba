using FarmaceuticaBack.Models;
using FarmaceuticaBack.Services.Contracts;
using FarmaceuticaBack.Services.Implementations;
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
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            try
            {
                PersonalCargosEstablecimiento personalEstablecimiento = await _service.GetById(id);
                return Ok(personalEstablecimiento);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }

        [HttpGet("Establishment")]
        public async Task<IActionResult> GetByEstablishment([FromQuery] int id)
        {
            try
            {
                List<PersonalCargosEstablecimiento> lst = await _service.GetByEstablishment(id);
                return Ok(lst);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }

        [HttpGet("Filter")]

        public async Task<IActionResult> GetByFilter([FromQuery] int id, [FromQuery] string? nombre, [FromQuery] string? apellido, [FromQuery] string? documento)
        {
            List<PersonalCargosEstablecimiento> lst = await _service.GetByFilter(id, nombre, apellido, documento);
            if (lst.Count > 0)
            {
                return Ok(lst);
            }
            return NotFound("No se encuentran registros.");
        }

        [HttpGet("LastId")]

        public async Task<IActionResult> LastId()
        {
            return Ok(await _service.GetLastId());
        }

        [HttpPost]

        public async Task<IActionResult> Add([FromBody]PersonalCargosEstablecimiento oPersonal)
        {
            if(oPersonal.IdPersonal == 0 || oPersonal.IdPersonal == null)
            {
                return BadRequest("Debe ingresar el id personal");
            }

            if (oPersonal.IdCargo == 0 || oPersonal.IdCargo == null)
            {
                return BadRequest("Debe ingresar el id cargo");
            }

            if (oPersonal.IdEstablecimiento == 0 || oPersonal.IdEstablecimiento == null)
            {
                return BadRequest("Debe ingresar el id establecimiento");
            }

            try
            {
                var result = await _service.Add(oPersonal);
                if (result)
                {
                    return Ok("Agregado");

                }
                else
                {
                    return BadRequest("Hubo un problema.");
                }
            }
            catch (Exception exc)
            {

                return StatusCode(500, exc.Message);
            }
        }
    }
}
