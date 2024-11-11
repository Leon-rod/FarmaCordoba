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
    public class TipoDocumentoRepository : ITipoDocumentoRepository
    {
        private readonly FarmaceuticaContext _context;

        public TipoDocumentoRepository(FarmaceuticaContext context)
        {
            _context = context;
        }
        public async Task<List<TiposDocumento>> GetAll()
        {
            return await _context.TiposDocumentos.ToListAsync();
        }
    }
}
