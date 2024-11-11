using FarmaceuticaBack.Services.Contracts;
using FarmaceuticaBack.Services.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace FarmaceuticaWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GeneroController : Controller
    {
        private readonly IGeneroService _generoService;

        public GeneroController(IGeneroService generoService)
        {
            _generoService = generoService; 
        }

        [HttpGet]
        public async Task<IActionResult> GetGeneros()
        {
            return  Ok(await _generoService.GetAll());
        }
    }
}
