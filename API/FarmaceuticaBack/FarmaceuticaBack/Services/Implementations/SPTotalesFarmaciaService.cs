using FarmaceuticaBack.Data.Contracts;
using FarmaceuticaBack.Data.Models;
using FarmaceuticaBack.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaceuticaBack.Services.Implementations
{
    public class SPTotalesFarmaciaService : ISPTotalesFarmaciaService
    {
        private readonly ISPTotalFarmacia _repository;

        public SPTotalesFarmaciaService(ISPTotalFarmacia repository)
        {
            _repository = repository;   
        }
        public async Task<List<SPTotalesFarmacia>> ExecuteSp(int año)
        {
            return await _repository.ExecuteSp(año);
        }
    }
}
