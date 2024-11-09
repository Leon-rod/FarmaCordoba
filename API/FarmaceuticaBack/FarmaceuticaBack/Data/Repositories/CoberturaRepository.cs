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
    public class CoberturaRepository : ICoberturaRepository
    {
        private readonly FarmaceuticaContext _context;
        public CoberturaRepository(FarmaceuticaContext context)
        {
            this._context = context;
        }
        public async Task<List<TiposCobertura>> GetAll()
        {
            List<TiposCobertura> result = await _context.TiposCoberturas
                .ToListAsync();
            return result;
        }
    }
}
