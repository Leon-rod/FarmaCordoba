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
    public class LaboratorioRepository : ILaboratorioRepository
    {
        private readonly FarmaceuticaContext _context;
        public LaboratorioRepository(FarmaceuticaContext context)
        {
            _context = context;
        }
        public async Task<List<Laboratorio>> GetAll()
        {
            var list = await _context.Laboratorios.ToListAsync();
            return list;
        }
    }
}
