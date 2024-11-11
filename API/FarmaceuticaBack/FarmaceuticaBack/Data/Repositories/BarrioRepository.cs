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
    public class BarrioRepository : IBarrioRepository
    {
        private readonly FarmaceuticaContext _context;

        public BarrioRepository(FarmaceuticaContext context)
        {
            _context = context;
        }
        public async Task<List<Barrio>> GetAll()
        {
            return await _context.Barrios.ToListAsync();    
        }
    }
}
