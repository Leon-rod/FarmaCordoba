using FarmaceuticaBack.Data.Contracts;
using FarmaceuticaBack.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaceuticaBack.Data.Repositories
{
    public class TotalesFacturadosVendedoresRepository : ITotalesFacturadosVendedoresRepository
    {
        private readonly FarmaceuticaContext _context;

        public TotalesFacturadosVendedoresRepository(FarmaceuticaContext context)
        {
            _context = context; 
        }
        public async Task<List<VTotalesFacturadosVendedore>> GetTotales()
        {
            return await _context.VTotalesFacturadosVendedores.ToListAsync();
        }

        public async Task<List<VTotalesFacturadosVendedore>> GetTotalesByMonthYear(int? year, int? month)
        {
            if((year == null || year == 0) && (month != null && month != 0))
            {
                return await _context.VTotalesFacturadosVendedores
                                                    .Where(v => v.Mes == month)
                                                    .ToListAsync(); 
            }else if((month == null || month == 0) && (year != null && year != 0)){
                return await _context.VTotalesFacturadosVendedores
                                                    .Where(v => v.Año == year)
                                                    .ToListAsync();
            }
            else
            {
                return await _context.VTotalesFacturadosVendedores
                                                   .Where(v => v.Año == year && v.Mes == month)
                                                   .ToListAsync();
            }
        }
    }
}
