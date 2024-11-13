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

        public async Task<List<SPReporteMensualCobertura>> ExecuteSpCobertura(int año, int mes, int obra)
        {
            return await _repository.ExecuteSpCobertura(año, mes, obra);
        }

        public async Task<List<SPMayoresCompras>> ExecuteSpMayoresCompras(int year, int count)
        {
            return await _repository.ExecuteSpMayoresCompras(year, count);
        }

        public async Task<List<SPReportemensualObraSocial>> ExecuteSpObraSocial(int a, int mes, int obra)
        {
            return await _repository.ExecuteSpObraSocial(a, mes, obra);
        }
    }
}
