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
    public class LogisticaService : ILogisticaService
    {
        private readonly ILogisticaRepository _repository;

        public LogisticaService(ILogisticaRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<EmpresaLogistica>> GetAll()
        {
            return await _repository.GetAll();
        }
    }
}
