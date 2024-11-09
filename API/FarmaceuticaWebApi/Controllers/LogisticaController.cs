using FarmaceuticaBack.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FarmaceuticaWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LogisticaController : Controller
    {
        private readonly ILogisticaService _service;
        public LogisticaController(ILogisticaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll() 
        {
            var list = await _service.GetAll();
            if (list.Count > 0)
            {
                return Ok(list);
            }
            else
            {
                return NotFound("No se encontraron registros.");
            }
        }
    }
}
