using FarmaceuticaBack.Data.Contracts;
using FarmaceuticaBack.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FarmaceuticaBack.Data.Repositories
{
    public class ClienteRepository:IClienteRepository
    {
        private readonly FarmaceuticaContext _context;

        public ClienteRepository(FarmaceuticaContext context)
        {
            _context = context;
        }

        public async Task<List<Cliente>> GetAll()
        {
            var clientes = await _context.Clientes.ToListAsync();
            return clientes;
        }
    }
}
