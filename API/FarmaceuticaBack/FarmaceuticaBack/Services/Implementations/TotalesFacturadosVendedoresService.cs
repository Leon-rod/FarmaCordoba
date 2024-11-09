using FarmaceuticaBack.Data.Contracts;
using FarmaceuticaBack.Data.Repositories;
using FarmaceuticaBack.Models;
using FarmaceuticaBack.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaceuticaBack.Services.Implementations
{
    public class TotalesFacturadosVendedoresService : ITotalesFacturadosVendedoresService
    {
        private readonly ITotalesFacturadosVendedoresRepository _repository;

        public TotalesFacturadosVendedoresService(ITotalesFacturadosVendedoresRepository repository)
        {
            _repository = repository;   
        }
        public async Task<List<VTotalesFacturadosVendedore>> GetTotales()
        {
            return await _repository.GetTotales();
        }

        public async Task<List<VTotalesFacturadosVendedore>> GetTotalesByMonthYear(int? year, int? month)
        {
            return await _repository.GetTotalesByMonthYear(year, month);
        }
    }
}
