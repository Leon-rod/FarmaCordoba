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
    public class EstablecimientoService : IEstablecimientoService
    {
        private readonly IEstablecimientoRepository _repository;
        public EstablecimientoService(IEstablecimientoRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<Establecimiento>> GetAll()
        {
            return await _repository.GetAll();
        }
    }
}
