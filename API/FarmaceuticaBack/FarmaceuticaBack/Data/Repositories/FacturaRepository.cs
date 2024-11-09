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
    public class FacturaRepository : IFacturaRepository
    {
        private readonly FarmaceuticaContext _context;
        public FacturaRepository(FarmaceuticaContext context)
        {
            this._context = context;
        }

        public async Task<List<Factura>> GetAll()
        {
            List<Factura> facturas = await _context.Facturas
                .Include(f => f.IdPersonalCargosEstablecimientosNavigation)
                .Include(f => f.IdPersonalCargosEstablecimientosNavigation.IdPersonalNavigation)
                .Include(f => f.IdPersonalCargosEstablecimientosNavigation.IdEstablecimientoNavigation)
                .Include(f => f.IdClienteNavigation)
                .ToListAsync();
            return facturas;
        }

        public async Task<List<Factura>> GetByClient(int client)
        {
            List<Factura> facturas = await _context.Facturas
                .Where(f => f.IdCliente == client)
                .ToListAsync();
            return facturas;
        }

        public async Task<List<Factura>> GetByDates(DateOnly startDate, DateOnly endDate)
        {
            List<Factura> facturas = await _context.Facturas
                .Where(f => f.Fecha >= startDate && f.Fecha <= endDate)
                .ToListAsync();
            return facturas;
        }

        public async Task<List<Factura>> GetByEmployee(int employee)
        {
            List<Factura> facturas = await _context.Facturas
                .Include(f => f.IdPersonalCargosEstablecimientosNavigation)
                .Include(f => f.IdPersonalCargosEstablecimientosNavigation.IdPersonalNavigation)
                .Where(f => f.IdPersonalCargosEstablecimientosNavigation.IdPersonalNavigation.IdPersonal == employee)
                .ToListAsync();
            return facturas;
        }

        public async Task<List<Factura>> GetByEstablishment(int establishment)
        {
            List<Factura> facturas = await _context.Facturas
                .Include(f => f.IdPersonalCargosEstablecimientosNavigation)
                .Include(f => f.IdPersonalCargosEstablecimientosNavigation.IdEstablecimientoNavigation)
                .Where(f => f.IdPersonalCargosEstablecimientosNavigation.IdEstablecimientoNavigation.IdEstablecimiento == establishment)
                .ToListAsync();
            return facturas;
        }

        public async Task<Factura> GetById(int id)
        {
            Factura? factura = await _context.Facturas.FindAsync(id);
            return factura;
        }

        public async Task<int> GetLastId()
        {
            int result = await _context.Facturas.MaxAsync(f => f.IdFactura);
            return result;
        }

        public async Task<bool> Insert(Factura factura)
        {
            int id = await _context.Facturas.MaxAsync(f => f.IdFactura) + 1;
            factura.IdFactura = id;
            await _context.Facturas.AddAsync(factura);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Update(Factura factura)
        {
            _context.Facturas.Update(factura);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
