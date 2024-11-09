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
    public class VTotalesFacturadosService : IVTotalesFacturadosService
    {
        private readonly IVTotalesFacturadosRepository _repository;

        public VTotalesFacturadosService(IVTotalesFacturadosRepository repository)
        {
            _repository = repository;   
        }
        public async Task<List<VTotalesFacturadosVendedore>> GetAll()
        {
            return await _repository.GetAll(); 
        }

        public async Task<List<VTotalesFacturadosVendedore>> GetByFilter(int idPersonal, int year, int month)
        {
           return await _repository.GetByFilter(idPersonal, year, month);
        }
    }
}
