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
    public class CoberturaService : ICoberturaService
    {
        private readonly ICoberturaRepository _repository;
        public CoberturaService(ICoberturaRepository repository)
        {
            this._repository = repository;
        }
        public async Task<List<TiposCobertura>> GetAll()
        {
            return await _repository.GetAll();
        }
    }
}
