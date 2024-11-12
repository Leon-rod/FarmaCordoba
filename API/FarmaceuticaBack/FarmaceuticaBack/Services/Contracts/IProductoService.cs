using FarmaceuticaBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaceuticaBack.Services.Contracts
{
    public interface IProductoService
    {
        Task<List<Producto>> GetAll();
        Task<List<Producto>> GetByFilters(string nombre, int marca, int tipoProd, bool active);
        Task<Producto> GetById(int id);
        Task<bool> Update(Producto producto);
        Task<bool> Save(Producto producto);
        Task<bool> Delete(int id);
        Task<int> GetLastId();
    }
}
