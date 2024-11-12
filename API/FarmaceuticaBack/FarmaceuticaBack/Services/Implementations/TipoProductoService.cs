using FarmaceuticaBack.Data.Contracts;
using FarmaceuticaBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaceuticaBack.Services.Implementations
{
    public class TipoProductoService
    {
        private readonly ITipoProductoRepository _repository;

        public TipoProductoService(ITipoProductoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<TiposProducto>> GetAll()
        {
            return await _repository.GetAll();
        }
    }
}
