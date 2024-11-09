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
    public class MonodrogaRepository : IMonodrogaRepository
    {
        private readonly FarmaceuticaContext _context;

        public MonodrogaRepository(FarmaceuticaContext context)
        {
            _context = context;
        }

        public async Task<List<Monodroga>> GetAll()
        {
            var list = await _context.Monodrogas.ToListAsync();
            return list;
        }
    }
}
