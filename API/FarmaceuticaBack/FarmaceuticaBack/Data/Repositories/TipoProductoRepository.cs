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
    public class TipoProductoRepository : ITipoProductoRepository
    {
        private readonly FarmaceuticaContext _context;

        public TipoProductoRepository(FarmaceuticaContext context)
        {
            _context = context;
        }

        public async Task<List<TiposProducto>> GetAll()
        {
            var tiposProductos = await _context.TiposProductos.ToListAsync();
            return tiposProductos;
        }
    }
}
