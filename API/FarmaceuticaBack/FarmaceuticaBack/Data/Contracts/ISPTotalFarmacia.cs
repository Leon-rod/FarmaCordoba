using FarmaceuticaBack.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaceuticaBack.Data.Contracts
{
    public interface ISPTotalFarmacia
    {
        Task<List<SPTotalesFarmacia>> ExecuteSp(int año);
        Task<List<SPReporteMensualCobertura>> ExecuteSpCobertura(int año, int mes, int obra);
        Task<List<SPReportemensualObraSocial>> ExecuteSpObraSocial(int a,  int mes, int obra);
        Task<List<SPMayoresCompras>> ExecuteSpMayoresCompras(int year, int count);



    }
}
