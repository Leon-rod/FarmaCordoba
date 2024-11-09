using FarmaceuticaBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaceuticaBack.Data.Contracts
{
    public interface IDispensacionRepository
    {
        Task<List<Dispensacion>> GetByIdFactura(int id);
        Task<bool> Insert(Dispensacion dispensacion);
        Task<bool> Delete(int idFactura, int IdDispensacion);
    }
}
