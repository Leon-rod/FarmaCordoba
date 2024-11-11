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
    public class TipoDocumentoService : ITipoDocumentoService
    {
        private readonly ITipoDocumentoRepository _repository;

        public TipoDocumentoService(ITipoDocumentoRepository repository)
        {
            _repository = repository;   
        }
        public async Task<List<TiposDocumento>> GetAll()
        {
            return await _repository.GetAll();
        }
    }
}
