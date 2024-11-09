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
    public class PresentacionRepository : IPresentacionRepository
    {
        private readonly FarmaceuticaContext _context;

        public PresentacionRepository(FarmaceuticaContext context)
        {
            _context = context;
        }

        public async Task<List<Presentacion>> GetAll()
        {
            return await _context.Presentaciones.ToListAsync();
        }
    }
}
