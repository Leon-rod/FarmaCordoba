using FarmaceuticaBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaceuticaBack.Services.Contracts
{
    public interface IVTotalesFacturadosService
    {
        Task<List<VTotalesFacturadosVendedore>> GetAll();

        Task<List<VTotalesFacturadosVendedore>> GetByFilter(int idPersonal, int year, int month);
    }
}
