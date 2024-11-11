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
    public class PersonalService : IPersonalService
    {
        private readonly IPersonalRepository _repository;
        public PersonalService(IPersonalRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Add(Personal oPersonal)
        {
            return await _repository.Add(oPersonal);
        }

        public Task<int> GetLastId()
        {
            return _repository.GetLastId(); 
        }
    }
}
