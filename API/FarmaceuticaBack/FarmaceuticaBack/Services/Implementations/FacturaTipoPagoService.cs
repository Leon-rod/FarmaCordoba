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
    public class FacturaTipoPagoService : IFacturaTipoPagoService
    {
        private readonly IFacturaTipoPagoRepository _repository;
        public FacturaTipoPagoService(IFacturaTipoPagoRepository repository)
        {
            this._repository = repository;
        }

        public Task<int> GetLastId()
        {
            return _repository.GetLastId();
        }

        public async Task<bool> Insert(FacturasTiposPago facturasTiposPago)
        {
            return await _repository.Insert(facturasTiposPago);
        }
    }
}
