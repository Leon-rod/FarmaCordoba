using FarmaceuticaBack.Data.Contracts;
using FarmaceuticaBack.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaceuticaBack.Data.Repositories
{
    public class DetallePedidoRepository : IDetallePedidoRepository
    {
        private readonly FarmaceuticaContext _context;
        public DetallePedidoRepository(FarmaceuticaContext context)
        {
            _context = context;
        }
        public async Task<bool> Delete(int idPedido, int idDetalleP)
        {
            var filasAfectadas = await _context.Database.ExecuteSqlRawAsync("DELETE FROM DETALLES_PEDIDOS WHERE ID_PEDIDO = {0} AND ID_DETALLE_PEDIDO = {1}", idPedido, idDetalleP);

            return filasAfectadas > 0;
        }

        public async Task<DetallesPedido?> GetByDetallePedido(int idPedido, int idDetalleP)
        {
            return await _context.DetallesPedidos
                .Include(d => d.IdProductoNavigation)
                .Include(d => d.IdMedicamentoLoteNavigation)
                .Include(d => d.IdMedicamentoLoteNavigation.IdMedicamentoNavigation)
                .Include(d => d.IdProveedorNavigation)
                .Include(d => d.IdProductoNavigation)
                .FirstOrDefaultAsync(d => d.IdPedido == idPedido && d.IdDetallePedido == idDetalleP);
        }

        public async Task<List<DetallesPedido>> GetByPedido(int id)
        {
            var dp = await _context.DetallesPedidos
                .Include(d => d.IdProductoNavigation)
                .Include(d => d.IdMedicamentoLoteNavigation)
                .Include(d => d.IdMedicamentoLoteNavigation.IdMedicamentoNavigation)
                .Include(d => d.IdProveedorNavigation)
                .Include(d => d.IdProductoNavigation)
                .Where(d => d.IdPedido == id).ToListAsync();
            return dp;
        }

        public async Task<bool> Save(DetallesPedido dp)
        {
            var filasAfectadas = 0;
            if (dp.IdMedicamentoLote > 0)
            {
                filasAfectadas = await _context.Database.ExecuteSqlRawAsync("INSERT INTO DETALLES_PEDIDOS(ID_DETALLE_PEDIDO, ID_PEDIDO, ID_MEDICAMENTO_LOTE, ID_PROVEEDOR, CANTIDAD, PRECIO_UNITARIO)" +
                                                                            "VALUES({0},{1},{2}, {3}, {4}, {5})", dp.IdDetallePedido, dp.IdPedido, dp.IdMedicamentoLote, dp.IdProveedor, dp.Cantidad, dp.PrecioUnitario);
            }
            if (dp.IdProducto > 0)
            {
                filasAfectadas = await _context.Database.ExecuteSqlRawAsync("INSERT INTO DETALLES_PEDIDOS(ID_DETALLE_PEDIDO, ID_PEDIDO, ID_PROVEEDOR, ID_PRODUCTO, CANTIDAD, PRECIO_UNITARIO)" +
                                                                            "VALUES({0},{1},{2}, {3}, {4}, {5})", dp.IdDetallePedido, dp.IdPedido, dp.IdProveedor, dp.IdProducto, dp.Cantidad, dp.PrecioUnitario);
            }
            return filasAfectadas > 0;
        }
    }
}

//int id = await _context.DetallesPedidos.MaxAsync(p => p.IdDetallePedido) + 1;
//dp.IdDetallePedido = id;

//await _context.AddAsync(dp);

//return await _context.SaveChangesAsync() > 0;