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

        public async Task<bool> Add(MedicamentosLote oMedicamento)
        {
          _context.MedicamentosLotes.Add(oMedicamento);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var oLote = await _context.MedicamentosLotes.FindAsync(id);
            if (oLote != null)
            {
                oLote.Activo = false;
                _context.Update(oLote);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<List<MedicamentosLote>> GetAll()
        {
            var medicamentos = await _context.MedicamentosLotes.Include(p => p.IdMedicamentoNavigation).ToListAsync();
            return medicamentos;
        }

        public async Task<int> GetLastId()
        {
            var lastId = await _context.MedicamentosLotes
            .OrderByDescending(m => m.IdMedicamentoLote)
            .Select(m => m.IdMedicamentoLote)
            .FirstOrDefaultAsync();

             return lastId;
        }
    }
}
