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
    public class ObraSocialRepository : IObraSocialRepository
    {
        private readonly FarmaceuticaContext _context;

        public ObraSocialRepository(FarmaceuticaContext context)
        {
            _context = context;
        }
        public async Task<List<ObraSocial>> GetAll()
        {
            return await _context.ObraSocials.ToListAsync();
        }
    }
}
