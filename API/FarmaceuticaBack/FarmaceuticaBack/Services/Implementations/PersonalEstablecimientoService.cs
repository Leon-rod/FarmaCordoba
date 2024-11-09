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
        public async Task<List<PersonalCargosEstablecimiento>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<PersonalCargosEstablecimiento> GetById(int id)
        {
            return await this._repository.GetById(id);
        }
    }
}
