using FarmaceuticaBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaceuticaBack.Data.Contracts
{
    public interface ITotalesFacturadosVendedoresRepository
    {
        Task<List<VTotalesFacturadosVendedore>> GetTotales();

        Task<List<VTotalesFacturadosVendedore>> GetTotalesByMonthYear(int? year, int? month);
    }
}
