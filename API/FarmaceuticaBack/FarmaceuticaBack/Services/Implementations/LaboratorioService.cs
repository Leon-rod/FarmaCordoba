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
    public class LaboratorioService : ILaboratorioService
    {
        private readonly ILaboratorioRepository _repository;
        public LaboratorioService(ILaboratorioRepository _repository)
        {
            this._repository = _repository;
        }

        public async Task<List<Laboratorio>> GetLaboratorio()
        {
            return await _repository.GetAll();
        }
    }
}
