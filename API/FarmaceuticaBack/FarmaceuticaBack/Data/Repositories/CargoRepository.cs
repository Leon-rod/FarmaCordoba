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
    public class CargoRepository : ICargoRepository
    {
        private readonly FarmaceuticaContext _context;

        public CargoRepository(FarmaceuticaContext context)
        {
            _context = context;
        }
        public async Task<List<Cargo>> GetAll()
        {
            return await _context.Cargos.ToListAsync();
        }
    }
}
