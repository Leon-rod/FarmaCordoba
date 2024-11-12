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
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _repository;

        public ProductoService(IProductoRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<List<Producto>> GetAll()
        {
            return await _repository.GetAll();
        }

        public Task<List<Producto>> GetByFilters(string nombre, int marca, int tipoProd, bool active)
        {
            return _repository.GetByFilters(nombre, marca, tipoProd, active);
        }

        public async Task<Producto> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<int> GetLastId()
        {
            return await _repository.GetLastId();
        }

        public async Task<bool> Save(Producto producto)
        {
            return await _repository.Save(producto);
        }

        public async Task<bool> Update(Producto producto)
        {
            return await _repository.Update(producto);
        }
    }
}
