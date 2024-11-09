using FarmaceuticaBack.Data.Contracts;
using FarmaceuticaBack.Data.Models;
using FarmaceuticaBack.Models;
using FarmaceuticaBack.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaceuticaBack.Services.Implementations
{
    public class InventarioService : IInventarioService
    {
        private readonly IInventarioRepository _repository;

        public InventarioService(IInventarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> CreateInventario(Inventario inv)
        {
            return await _repository.CreateInventario(inv);
        }

        public async Task<List<Inventario>> GetAll()
        {
            return await _repository.GetAll();
        }


        public async Task<List<Inventario>> GetInventarioByFactura(int idFactura, DateTime from, DateTime to)
        {
            return await _repository.GetInventarioByFactura(idFactura, from, to);
        }

        public async Task<List<Inventario>> GetInventarioByFilter(InventarioFiltro oFiltro)
        {
            return await _repository.GetInventarioByFilter(oFiltro);
        }

        public async Task<List<Inventario>> GetInventarioByPedido(int idPedido, DateTime from, DateTime to)
        {
            return await _repository.GetInventarioByPedido(idPedido, from, to);
        }

    }
}
