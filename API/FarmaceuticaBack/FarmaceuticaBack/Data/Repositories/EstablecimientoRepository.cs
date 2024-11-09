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
    public class EstablecimientoRepository : IEstablecimientoRepository
    {
        private readonly FarmaceuticaContext _context;
        public EstablecimientoRepository(FarmaceuticaContext context)
        {
            this._context = context;
        }
        public async Task<List<Establecimiento>> GetAll()
        {
            List<Establecimiento> establecimientos = await _context.Establecimientos
                .ToListAsync();
            return establecimientos;
        }
    }
}
