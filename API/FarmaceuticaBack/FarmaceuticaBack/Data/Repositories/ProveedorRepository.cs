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
    public class ProveedorRepository : IProveedorRepository
    {
        private readonly FarmaceuticaContext _context;

        public ProveedorRepository(FarmaceuticaContext context)
        {
            _context = context;
        }

        public async Task<List<Proveedor>> GetAll()
        {
            var proveedores = await _context.Proveedores.ToListAsync();
            return proveedores;
        }
    }
}
