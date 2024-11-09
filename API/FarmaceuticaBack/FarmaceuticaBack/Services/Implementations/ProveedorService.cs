using FarmaceuticaBack.Data.Contracts;
using FarmaceuticaBack.Models;
using FarmaceuticaBack.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaceuticaBack.Services.Implementations
{
    public class ProveedorService : IProveedorService
    {
        private readonly IProveedorRepository _proveedorRepo;

        public ProveedorService(IProveedorRepository proveedorRepo)
        {
            _proveedorRepo = proveedorRepo;
        }

        public async Task<List<Proveedor>> GetAll()
        {
            return await _proveedorRepo.GetAll();
        }
    }
}
