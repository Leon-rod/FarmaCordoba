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
    public class ReporteMensualObraSocialRepository : IReporteMensualObraSocialRepository
    {
        private readonly FarmaceuticaContext _context;

        public ReporteMensualObraSocialRepository(FarmaceuticaContext context)
        {
            _context = context;
        }
        public async Task<List<VReporteMensualObraSocial>> GetAll()
        {
            return await _context.VReporteMensualObraSocials.ToListAsync(); 
        }

        public async Task<List<VReporteMensualObraSocial>> GetByFilters(string? OS, int? year, int? month)
        {
            var query = _context.VReporteMensualObraSocials.AsQueryable();

            if (!string.IsNullOrEmpty(OS))
            {
                query = query.Where(r => r.ObraSocial.Contains(OS));
            }

            if (year.HasValue)
            {
                query = query.Where(r => r.Año == year.Value);
            }

            if (month.HasValue)
            {
                query = query.Where(r => r.Mes == month.Value);
            }

            return await query.ToListAsync();
        }
    }
}
