using FarmaceuticaBack.Models;
using FarmaceuticaBack.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FarmaceuticaWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonalController : Controller
    {
        private readonly IPersonalService _service;

        public PersonalController(IPersonalService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddPersonal([FromBody]Personal oPersonal)
        {
            if (string.IsNullOrEmpty(oPersonal.Nombre))
            {
                return BadRequest("Debe ingresar un nombre.");
            }

            if (string.IsNullOrEmpty(oPersonal.Apellido))
            {
                return BadRequest("Debe ingresar un apellido.");
            }

            if(oPersonal.FechaNac == DateOnly.MinValue)
            {
                return BadRequest("Debe ingresar una fecha de nacimiento");
            }

            if (string.IsNullOrEmpty(oPersonal.Calle))
            {
                return BadRequest("Debe ingresar una calle.");
            }

            if (string.IsNullOrEmpty(oPersonal.Numero))
            {
                return BadRequest("Debe ingresar un numero de calle.");
            }

            if (oPersonal.IdBarrio == 0 || oPersonal.IdBarrio == null)
            {
                return BadRequest("Debe ingresar un barrio.");
            }

            if (oPersonal.TipoDoc == 0 || oPersonal.TipoDoc == null)
            {
                return BadRequest("Debe ingresar un tipo documento.");
            }

            if (string.IsNullOrEmpty(oPersonal.NroDoc))
            {
                return BadRequest("Debe ingresar un documento.");
            }

            if (oPersonal.IdGenero == 0 || oPersonal.IdGenero == null)
            {
                return BadRequest("Debe ingresar un género.");
            }

            try
            {
                var response = await _service.Add(oPersonal);
                if (response)
                {
                    return Ok("Se ha agregado el personal");
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

        [HttpGet("LastId")]

        public async Task<IActionResult> GetLastId() {
            return Ok(await _service.GetLastId());
        }
    }
}
