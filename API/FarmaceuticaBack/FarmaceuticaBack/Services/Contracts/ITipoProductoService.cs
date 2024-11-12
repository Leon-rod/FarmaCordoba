using FarmaceuticaBack.Data.Contracts;
using FarmaceuticaBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaceuticaBack.Services.Contracts
{
    public interface ITipoProductoService
    {
        Task<List<TiposProducto>> GetAll();
    }
}
