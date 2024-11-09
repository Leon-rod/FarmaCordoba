using FarmaceuticaBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaceuticaBack.Services.Contracts
{
    public interface ITotalesFacturadosVendedoresService
    {
        Task<List<VTotalesFacturadosVendedore>> GetTotales();

        Task<List<VTotalesFacturadosVendedore>> GetTotalesByMonthYear(int? year, int? month);
    }
}
