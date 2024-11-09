using FarmaceuticaBack.Data.Contracts;
using FarmaceuticaBack.Models;
using FarmaceuticaBack.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaceuticaBack.Services.Implementations
{
    public class ObraSocialService : IObraSocialService
    {
        private readonly IObraSocialRepository _repository;

        public ObraSocialService(IObraSocialRepository repository)
        {
            _repository = repository;
        }



        public async Task<List<ObraSocial>> GetAll()
        {
            return await _repository.GetAll();  
        }
    }
}
