using FarmaceuticaBack.Data.Contracts;
using FarmaceuticaBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaceuticaBack.Data.Repositories
{
    public class FacturaTipoPagoRepository : IFacturaTipoPagoRepository
    {
        private readonly FarmaceuticaContext _context;
        public FacturaTipoPagoRepository(FarmaceuticaContext context)
        {
            this._context = context;
        }
        public async Task<bool> Insert(FacturasTiposPago facturasTiposPago)
        {
            bool result = false;
            await _context.FacturasTiposPagos.AddAsync(facturasTiposPago);
            result = await _context.SaveChangesAsync() > 0;
            return result;
        }
    }
}
