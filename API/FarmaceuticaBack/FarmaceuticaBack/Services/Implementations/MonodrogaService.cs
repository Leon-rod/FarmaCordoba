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
    public class MonodrogaService : IMonodrogaService
    {
        private readonly IMonodrogaRepository _repository;
        public MonodrogaService(IMonodrogaRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Monodroga>> GetMonodroga()
        {
            return await _repository.GetAll();
        }
    }
}
