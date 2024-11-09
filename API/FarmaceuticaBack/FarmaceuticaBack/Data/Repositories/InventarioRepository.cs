using FarmaceuticaBack.Data.Contracts;
using FarmaceuticaBack.Data.Models;
using FarmaceuticaBack.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FarmaceuticaBack.Data.Repositories
{
    public class InventarioRepository : IInventarioRepository
    {
        private readonly FarmaceuticaContext _context;

        public InventarioRepository(FarmaceuticaContext context)
        {   
            _context = context;
        }
        public async Task<bool> CreateInventario(Inventario inv)
        {
            string sql = @"
                INSERT INTO INVENTARIOS (ID_FACTURA, ID_DISPENSACION, ID_PEDIDO, ID_DETALLE_PEDIDO, ID_TIPO_MOV, ID_STOCK, CANTIDAD, FECHA)
                VALUES (@p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7)";

            int affectedRows = await _context.Database.ExecuteSqlRawAsync(
                sql,
                inv.IdFactura,
                inv.IdDispensacion,
                inv.IdPedido,
                inv.IdDetallePedido,
                inv.IdTipoMov,
                inv.IdStock,
                inv.Cantidad,
                inv.Fecha
            );

            return affectedRows > 0;

        }

        public async Task<List<Inventario>> GetAll()
        {
            return await _context.Inventarios
                                      .Include(d => d.Dispensacione)
                                     .Include(d => d.Dispensacione.IdFacturaNavigation)
                                     .Include(d => d.Dispensacione.IdProductoNavigation)
                                     .Include(d => d.Dispensacione.IdMedicamentoLoteNavigation)
                                     .Include(d => d.Dispensacione.IdMedicamentoLoteNavigation.IdMedicamentoNavigation)
                                     .Include(d => d.DetallesPedido.IdProductoNavigation)
                                     .Include(d => d.DetallesPedido.IdPedidoNavigation)
                                     .Include(d => d.IdTipoMovNavigation)
                                        .ToListAsync() ;
        }

        public async Task<List<Inventario>> GetInventarioByFactura(int idFactura, DateTime from, DateTime to)
        {
            if(from == null || from == DateTime.MinValue || to == null || to == DateTime.MinValue)
            {
                return await _context.Inventarios
                                     .Include(d => d.Dispensacione)
                                     .Include(f => f.Dispensacione.IdFacturaNavigation)
                                     .Include(tp => tp.IdTipoMovNavigation)
                                     .Where(i => i.IdFactura == idFactura)
                    .ToListAsync();
            }
            else
            {
                DateOnly fromDateOnly = DateOnly.FromDateTime(from);
                DateOnly toDateOnly = DateOnly.FromDateTime(to);

                return await _context.Inventarios
                                     .Include(d => d.Dispensacione)
                                     .Include(f => f.Dispensacione.IdFacturaNavigation)
                                     .Include(tp => tp.IdTipoMovNavigation)
                                     .Where(i => i.IdFactura == idFactura
                                                 ||( i.Dispensacione.IdFacturaNavigation.Fecha >= fromDateOnly
                                                 && i.Dispensacione.IdFacturaNavigation.Fecha <= toDateOnly))
                                     .ToListAsync();
            }
                                
        }

        public async Task<List<Inventario>> GetInventarioByFilter(InventarioFiltro oFiltro)
        {
            IQueryable<Inventario> query = _context.Inventarios.AsQueryable();
            Type t = oFiltro.GetType();
            PropertyInfo[] properties = t.GetProperties();

            foreach (PropertyInfo p in properties)
            {

                if (p.Name == "FechaDesde" || p.Name == "FechaHasta")
                {
                    var valor = p.GetValue(oFiltro);
                    if (valor is DateTime dateTimeValue && dateTimeValue != DateTime.MinValue && valor != null)
                    {
                        var valorDateOnly = DateOnly.FromDateTime(dateTimeValue);
                        if(p.Name == "FechaDesde")
                        {
                            query = query.Include(d => d.Dispensacione)
                                         .Include(d => d.Dispensacione.IdFacturaNavigation)
                                         .Include(d => d.Dispensacione.IdProductoNavigation)
                                         .Include(d => d.Dispensacione.IdMedicamentoLoteNavigation)
                                         .Include(d => d.Dispensacione.IdMedicamentoLoteNavigation.IdMedicamentoNavigation)
                                         .Include(d => d.DetallesPedido.IdProductoNavigation)
                                         .Include(d => d.DetallesPedido.IdPedidoNavigation)
                                         .Include(d => d.IdTipoMovNavigation)                                        
                                         .Where(d => d.Dispensacione.IdFacturaNavigation.Fecha >= valorDateOnly || d.DetallesPedido.IdPedidoNavigation.Fecha >= valorDateOnly);
                        }
                        else
                        {
                            query = query.Include(d => d.Dispensacione)
                                         .Include(d => d.Dispensacione.IdFacturaNavigation)
                                         .Include(d => d.Dispensacione.IdProductoNavigation)
                                         .Include(d => d.Dispensacione.IdMedicamentoLoteNavigation)
                                         .Include(d => d.Dispensacione.IdMedicamentoLoteNavigation.IdMedicamentoNavigation)
                                         .Include(d => d.DetallesPedido.IdProductoNavigation)
                                         .Include(d => d.DetallesPedido.IdPedidoNavigation)
                                         .Include(d => d.IdTipoMovNavigation)
                                         .Where(d => d.Dispensacione.IdFacturaNavigation.Fecha <= valorDateOnly || d.DetallesPedido.IdPedidoNavigation.Fecha <= valorDateOnly);
                        }

                    }
                }
                else if (p.PropertyType == typeof(int?))
                {
                    var valorInt = (int?)p.GetValue(oFiltro);

                    if (valorInt.HasValue && valorInt.Value != 0)
                    {
                        query = query.Include(d => d.Dispensacione)
                                     .Include(d => d.Dispensacione.IdFacturaNavigation)
                                     .Include(d => d.Dispensacione.IdProductoNavigation)
                                     .Include(d => d.Dispensacione.IdMedicamentoLoteNavigation)
                                     .Include(d => d.Dispensacione.IdMedicamentoLoteNavigation.IdMedicamentoNavigation)
                                     .Include(d => d.DetallesPedido.IdProductoNavigation)
                                     .Include(d => d.DetallesPedido.IdPedidoNavigation)
                                     .Include(d => d.IdTipoMovNavigation)
                                     .Where(d => EF.Property<int>(d, p.Name) == valorInt.Value);
                    }
                }
            }

            return await query.ToListAsync();
        }

        public async Task<List<Inventario>> GetInventarioByPedido(int idPedido, DateTime from, DateTime to)
        {
            if (from == null || from == DateTime.MinValue || to == null || to == DateTime.MinValue)
            {
                return await _context.Inventarios
                    .Where(i => i.IdPedido == idPedido)
                    .ToListAsync();
            }
            else
            {
                DateOnly fromDateOnly = DateOnly.FromDateTime(from);
                DateOnly toDateOnly = DateOnly.FromDateTime(to);

                return await _context.Inventarios
                                     .Include(d => d.DetallesPedido)
                                     .Include(f => f.DetallesPedido.IdPedidoNavigation)
                                     .Where(i => i.IdPedido == idPedido
                                                 || (i.DetallesPedido.IdPedidoNavigation.Fecha >= fromDateOnly
                                                 && i.Dispensacione.IdFacturaNavigation.Fecha <= toDateOnly))
                                     .ToListAsync();
            }
        }


    }
}
