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
    public class PersonalEstablecimientoRepository : IPersonalEstablecimientoRepository
    {
        private readonly FarmaceuticaContext _context;
        public PersonalEstablecimientoRepository(FarmaceuticaContext context)
        {
            this._context = context;
        }
        public async Task<List<PersonalCargosEstablecimiento>> GetAll()
        {
            List<PersonalCargosEstablecimiento> result = await _context.PersonalCargosEstablecimientos
                .Include(p => p.IdCargoNavigation)
                .Include(p => p.IdEstablecimientoNavigation)
                .Include(p => p.IdPersonalNavigation)
                .ToListAsync();
            return result;
        }

        public async Task<PersonalCargosEstablecimiento> GetById(int id)
        {
            PersonalCargosEstablecimiento person = await _context.PersonalCargosEstablecimientos
                .Where(p => p.IdPersonalCargosEstablecimientos == id)
                .FirstOrDefaultAsync();
            return person;
        }
    }
}
