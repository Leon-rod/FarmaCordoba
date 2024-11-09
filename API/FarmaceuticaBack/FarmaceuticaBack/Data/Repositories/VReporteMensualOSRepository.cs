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
    public class VReporteMensualOSRepository : IVReporteMensualOSRepository
    {
        private readonly FarmaceuticaContext _context;

        public VReporteMensualOSRepository(FarmaceuticaContext context)
        {
            _context = context; 
        }

        public async Task<List<VReporteMensualObraSocial>> GetAll()
        {
            return await _context.VReporteMensualObraSocials.ToListAsync();
        }

        public async Task<List<VReporteMensualObraSocial>> GetByFilter(string os, int year, int month)
        {
            IQueryable<VReporteMensualObraSocial> query = _context.VReporteMensualObraSocials.AsQueryable();

            if (os != "0" && os != "")
            {
                query = query.Where(x => x.ObraSocial == os);
            }

            if (year != null && year != 0)
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

