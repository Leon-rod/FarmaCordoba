using FarmaceuticaBack.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaceuticaBack.Services.Contracts
{
    public interface ISPTotalesFarmaciaService
    {
        Task<List<SPTotalesFarmacia>> ExecuteSp(int año);

        Task<List<SPReporteMensualCobertura>> ExecuteSpCobertura(int año, int mes, int obra);

        Task<List<SPReportemensualObraSocial>> ExecuteSpObraSocial(int a, int mes, int obra);
    }
}
