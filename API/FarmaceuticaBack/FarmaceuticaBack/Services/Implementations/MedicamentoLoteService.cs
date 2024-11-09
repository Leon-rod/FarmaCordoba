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
    public class MedicamentoLoteService : IMedicamentoLoteService
    {
        private readonly IMedicamentoLoteRepository _service;

        public MedicamentoLoteService(IMedicamentoLoteRepository service)
        {
            _service = service;
        }

        public async Task<List<MedicamentosLote>> GetAll()
        {
            return await _service.GetAll();
        }
    }
}
