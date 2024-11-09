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
    public class LogisticaRepository : ILogisticaRepository
    {
        private readonly FarmaceuticaContext _context;

        public LogisticaRepository(FarmaceuticaContext context)
        {
            _context = context;
        }
        public async Task<List<EmpresaLogistica>> GetAll()
        {
           var lst = await _context.EmpresaLogisticas.ToListAsync();
            return lst;
        }
    }
}
