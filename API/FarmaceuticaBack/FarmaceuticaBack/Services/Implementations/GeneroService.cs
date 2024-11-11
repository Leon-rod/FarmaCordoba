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
    public class GeneroService : IGeneroService
    {
        private readonly IGeneroRepository _repository;

        public GeneroService(IGeneroRepository repository)
        {
            _repository = repository;

        }

        public async Task<List<TiposGenero>> GetAll()
        {
            return await _repository.GetAll();  
        }
    }
}
