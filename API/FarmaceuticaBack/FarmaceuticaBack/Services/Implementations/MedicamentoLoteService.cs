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

        public async Task<bool> Add(MedicamentosLote oMedicamento)
        {
           return await _service.Add(oMedicamento);
        }

        public async Task<bool> Delete(int id)
        {
            return await _service.Delete(id);
        }

        public async Task<List<MedicamentosLote>> GetAll()
        {
            return await _service.GetAll();
        }

        public async Task<int> GetLastId()
        {
            return await _service.GetLastId();
        }
    }
}
