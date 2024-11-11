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
    public class GeneroRepository : IGeneroRepository
    {
        private readonly FarmaceuticaContext _context;
        public GeneroRepository(FarmaceuticaContext context) 
        {
            _context = context;
        }
        public async Task<List<TiposGenero>> GetAll()
        {
            return await _context.TiposGeneros.ToListAsync();
        }
    }
}
