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
    public class PersonalRepository : IPersonalRepository
    {
        private readonly FarmaceuticaContext _context;

        public PersonalRepository(FarmaceuticaContext context)
        {
            _context = context;
        }
        public async Task<bool> Add(Personal oPersonal)
        {
            _context.Personals.Add(oPersonal);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<int> GetLastId()
        {
            var lastId = await _context.Personals
                        .OrderByDescending(m => m.IdPersonal)
                        .Select(m => m.IdPersonal)
                        .FirstOrDefaultAsync();

                                return lastId;
        }
    }
}
