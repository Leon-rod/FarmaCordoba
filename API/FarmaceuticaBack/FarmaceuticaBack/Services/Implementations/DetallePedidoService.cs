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
    public class DetallePedidoService : IDetallePedidoService
    {
        private readonly IDetallePedidoRepository _repository;

        public DetallePedidoService(IDetallePedidoRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Delete(int idPedido, int idDetalleP)
        {
            return await _repository.Delete(idPedido, idDetalleP);
        }

        public async Task<DetallesPedido> GetByDetallePedido(int idPedido, int idDetalleP)
        {
            return await _repository.GetByDetallePedido(idPedido,idDetalleP);
        }

        public async Task<List<DetallesPedido>> GetByPedido(int id)
        {
            return await _repository.GetByPedido(id);
        }

        public async Task<bool> Save(DetallesPedido dp)
        {
            return await _repository.Save(dp);
        }
    }
}
