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
    public class ProductoRepository : IProductoRepository
    {
        private readonly FarmaceuticaContext _context;

        public ProductoRepository(FarmaceuticaContext context)
        {
            _context = context;
        }

        public async Task<bool> Delete(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto != null)
            {
                producto.Activo = false;
            }
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<Producto>> GetAll()
        {
            var productos = await _context.Productos
                .Include(x => x.IdMarcaNavigation)
                .Include(x => x.TipoProductoNavigation)
                .ToListAsync();
            return productos;
        }

        public async Task<List<Producto>> GetByFilters(string nombre, int marca, int tipoProd, bool active)
        {
            IQueryable<Producto> query = _context.Productos.AsQueryable();
            
            if (!string.IsNullOrEmpty(nombre))
            {
                query = query.Where(x => x.Nombre.Contains(nombre));
            }
            if (marca > 0)
            {
                query = query.Where(x => x.IdMarca == marca);
            }
            if (tipoProd > 0)
            {
                query = query.Where(x => x.TipoProducto == tipoProd);
            }

            query = query.Where(x => x.IdMarca == marca);

            return await _context.Productos
                .Include(x => x.IdMarcaNavigation)
                .Include(x => x.TipoProductoNavigation)
                .ToListAsync();
        }

        public async Task<Producto> GetById(int id)
        {
            var producto = await _context.Productos
                .FirstOrDefaultAsync(x => x.IdProducto == id);
            return producto;
        }

        public async Task<bool> Save(Producto producto)
        {
            _context.Productos.Add(producto);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Update(Producto producto)
        {
            var p = await _context.Productos
                .FirstOrDefaultAsync(p => p.IdProducto == producto.IdProducto);
            if (p != null)
            {
                p.Nombre = producto.Nombre;
                p.IdMarca = producto.IdMarca;
                p.TipoProducto = producto.TipoProducto;
                p.Descripcion = producto.Descripcion;
                p.Precio = producto.Precio;
            }
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<int> GetLastId()
        {
            int id = await _context.Productos.MaxAsync(p => p.IdProducto);
            return id + 1;
        }
    }
}
