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
    public class DispensacionService : IDispensacionService
    {
        private readonly IDispensacionRepository _repository;
        public DispensacionService(IDispensacionRepository repository)
        {
            this._repository = repository;
        }
        public async Task<bool> Delete(int idFactura, int IdDispensacion)
        {
            return await _repository.Delete(idFactura, IdDispensacion);
        }

        public async Task<List<Dispensacion>> GetByIdFactura(int id)
        {
            return await _repository.GetByIdFactura(id);
        }

        public async Task<bool> Insert(Dispensacion dispensacion)
        {
            return await _repository.Insert(dispensacion);
        }
    }
}
