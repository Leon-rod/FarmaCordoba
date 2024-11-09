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
    public class VTotalesFacturadosRepository : IVTotalesFacturadosRepository
    {
        private readonly FarmaceuticaContext _context;

        public VTotalesFacturadosRepository(FarmaceuticaContext context)
        {
            _context = context; 
        }
        public async Task<List<VTotalesFacturadosVendedore>> GetAll()
        {
          return await _context.VTotalesFacturadosVendedores.ToListAsync();
        }

        public async Task<List<VTotalesFacturadosVendedore>> GetByFilter(int idPersonal, int year, int month)
        {
            IQueryable<VTotalesFacturadosVendedore> query = _context.VTotalesFacturadosVendedores.AsQueryable();

            if(idPersonal != null && idPersonal != 0)
            {
                query = query.Where(x => x.IdPersonal == idPersonal);
            }

            if(year != null && year != 0)
            {
                query = query.Where(x => x.Año == year);
            }


            if (month != null && month != 0)
            {
                query = query.Where(x => x.Mes == month);
            }

            return await query.ToListAsync();
        }
    }
}
