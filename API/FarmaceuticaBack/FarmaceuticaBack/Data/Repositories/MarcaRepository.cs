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
    public class MarcaRepository : IMarcaRepository
    {
        private readonly FarmaceuticaContext _context;
        public MarcaRepository(FarmaceuticaContext context)
        {
            _context = context;
        }

        public async Task<List<Marca>> GetAll()
        {
            return await _context.Marcas.ToListAsync();
        }
    }
}
