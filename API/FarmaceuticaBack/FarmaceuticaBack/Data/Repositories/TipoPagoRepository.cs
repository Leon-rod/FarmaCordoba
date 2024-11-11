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
    public class TipoPagoRepository : ITipoPagoRepository
    {
        private readonly FarmaceuticaContext _context;
        public TipoPagoRepository(FarmaceuticaContext context)
        {
            this._context = context;
        }
        public async Task<List<TiposPago>> GetAll()
        {
            List<TiposPago> tiposPagos = await _context.TiposPagos.ToListAsync();
            return tiposPagos;
        }
    }
}
