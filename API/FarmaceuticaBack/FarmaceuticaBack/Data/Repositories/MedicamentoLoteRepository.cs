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
    public class MedicamentoLoteRepository : IMedicamentoLoteRepository
    {
        private readonly FarmaceuticaContext _context;

        public MedicamentoLoteRepository(FarmaceuticaContext context)
        {
            _context = context;
        }

        public async Task<List<MedicamentosLote>> GetAll()
        {
            var medicamentos = await _context.MedicamentosLotes.Include(p => p.IdMedicamentoNavigation).ToListAsync();
            return medicamentos;
        }
    }
}
