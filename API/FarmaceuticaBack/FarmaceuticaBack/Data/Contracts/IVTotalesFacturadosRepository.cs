using FarmaceuticaBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaceuticaBack.Data.Contracts
{
    public interface IVTotalesFacturadosRepository
    {
        Task<List<VTotalesFacturadosVendedore>> GetAll();

        Task<List<VTotalesFacturadosVendedore>> GetByFilter(int idPersonal, int year, int month);
    }
}
