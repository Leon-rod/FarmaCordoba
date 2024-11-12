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
    public class PersonalEstablecimientoService : IPersonalEstablecimientoService
    {
        private readonly IPersonalEstablecimientoRepository _repository;
        public PersonalEstablecimientoService(IPersonalEstablecimientoRepository repository)
        {
            this._repository = repository;
        }

        public async Task<bool> Add(PersonalCargosEstablecimiento oPersonal)
        {
           return await _repository.Add(oPersonal);
        }

        public async Task<List<PersonalCargosEstablecimiento>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<List<PersonalCargosEstablecimiento>> GetByEstablishment(int id)
        {
            return await _repository.GetByEstablishment(id);
        }

        public async Task<List<PersonalCargosEstablecimiento>> GetByFilter(int id, string nombre, string apellido)
        {
            return await _repository.GetByFilter(id, nombre, apellido); 
        }

        public async Task<PersonalCargosEstablecimiento> GetById(int id)
        {
            return await this._repository.GetById(id);
        }

        public async Task<int> GetLastId()
        {
            return await _repository.GetLastId();   
        }
    }
}
