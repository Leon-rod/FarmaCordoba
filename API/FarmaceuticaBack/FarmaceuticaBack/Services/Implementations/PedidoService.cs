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
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedido;

        public PedidoService(IPedidoRepository pedido)
        {
            _pedido = pedido;
        }

        public async Task<bool> Edit(Pedido pedido)
        {
            return await _pedido.Edit(pedido);
        }

        public async Task<List<Pedido>> GetAll()
        {
            return await _pedido.GetAll();
        }

        public async Task<List<Pedido>> GetByEstablecimiento(int id)
        {
            return await _pedido.GetByEstablecimiento(id);
        }

        public async Task<List<Pedido>> GetByFecha(DateTime fechaDesde, DateTime fechaHasta)
        {
            return await _pedido.GetByFecha(fechaDesde, fechaHasta);
        }

        public async Task<Pedido> GetById(int id)
        {
            return await _pedido.GetById(id);
        }

        public async Task<List<Pedido>> GetByLogistica(string id)
        {
            return await _pedido.GetByLogistica(id);
        }

        public async Task<int> GetLastId()
        {
            return await _pedido.GetLastId();
        }

        public async Task<bool> Save(Pedido pedido)
        {
            return await _pedido.Save(pedido);
        }
    }
}
