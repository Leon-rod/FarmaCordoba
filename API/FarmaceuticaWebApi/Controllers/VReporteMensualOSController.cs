using FarmaceuticaBack.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FarmaceuticaWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VReporteMensualOSController : Controller
    {
        private readonly IVReporteMensualOSService _service;
        public VReporteMensualOSController(IVReporteMensualOSService service)
        {
            _service = service; 
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
           var lst = await _service.GetAll();

            if(lst.Count > 0)
            {
                return Ok(lst);
            }
            else
            {
                return BadRequest("No hay resultados.");
            }
        }

        [HttpGet("Filter")]

        public async Task<IActionResult> GetByFilter([FromQuery] string os, int year, int month)
        {
            if((os == "" || os == "0") && year == 0 && month == 0)
            {
                return Ok(await _service.GetAll());
            }
            else
            {
                var lst = await _service.GetByFilter(os, year, month);


                return Ok(lst);
            }



        }
    }
}
