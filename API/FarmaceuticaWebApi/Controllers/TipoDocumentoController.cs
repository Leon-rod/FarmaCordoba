using FarmaceuticaBack.Data.Contracts;
using FarmaceuticaBack.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FarmaceuticaWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoDocumentoController : Controller
    {
        private readonly ITipoDocumentoService _service;

        public TipoDocumentoController(ITipoDocumentoService service)
        {
            _service = service; 
        }

        [HttpGet]
        public async Task<IActionResult> GetDocumentos()
        {
            return Ok(await _service.GetAll());
        }
    }
}
