using FarmaceuticaBack.Data.Contracts;
using FarmaceuticaBack.Models;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FarmaceuticaBack.Data.Models;

namespace FarmaceuticaBack.Data.Repositories
{
    public class SPTotalFarmaciaRepository : ISPTotalFarmacia
    {
        private readonly FarmaceuticaContext _context;

        public SPTotalFarmaciaRepository(FarmaceuticaContext context)
        {
            _context = context;
        }
        public async Task<List<SPTotalesFarmacia>> ExecuteSp(int año)
        {
            var resultados = _context.Set<SPTotalesFarmacia>()
            .FromSqlRaw("EXEC SP_TOTALES_FACTURADOS_FARMACIAS @año = {0}", año)
            .ToList();

            return resultados;
        }
    }
}
