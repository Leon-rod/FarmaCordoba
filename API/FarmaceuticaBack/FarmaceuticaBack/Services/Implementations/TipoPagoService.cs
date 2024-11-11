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
    public class TipoPagoService : ITipoPagoService
    {
        private readonly ITipoPagoRepository _repository;
        public TipoPagoService(ITipoPagoRepository repository)
        {
            this._repository = repository;
        }
        public async Task<List<TiposPago>> GetAll()
        {
            return await _repository.GetAll();
        }
    }
}
