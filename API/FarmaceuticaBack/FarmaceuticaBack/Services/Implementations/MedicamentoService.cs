using FarmaceuticaBack.Data.Contracts;
using FarmaceuticaBack.Data.Models;
using FarmaceuticaBack.Models;
using FarmaceuticaBack.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaceuticaBack.Services.Implementations
{
    public class MedicamentoService : IMedicamentoService
    {
        private readonly IMedicamentoRepository _repository;
        public MedicamentoService(IMedicamentoRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Delete(int? id)
        {
            return await _repository.Delete(id);
        }

        public async Task<List<Medicamento>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<List<Medicamento>> GetByFiltro(MedicamentoFiltro oFiltro)
        {
            return await _repository.GetByFiltro(oFiltro);
        }

        public async Task<int> GetLastId()
        {
            return await (_repository.GetLastId());
        }

        public async Task<Medicamento> GetMedicamentoById(int id)
        {
            return await _repository.GetMedicamentoById(id);
        }

        public async Task<bool> Save(Medicamento oMedicamento)
        {
            return await _repository.Save(oMedicamento);
        }

        public async Task<bool> Update(Medicamento oMedicamento)
        {
            return await _repository.Update(oMedicamento);
        }
    }
}
