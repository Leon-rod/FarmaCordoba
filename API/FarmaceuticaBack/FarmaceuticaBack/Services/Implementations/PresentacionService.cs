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
    public class PresentacionService : IPresentacionService
    {
        private readonly IPresentacionRepository _repository;
        public PresentacionService(IPresentacionRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Presentacion>> GetPresentacion()
        {
            return await _repository.GetAll();
        }
    }
}
