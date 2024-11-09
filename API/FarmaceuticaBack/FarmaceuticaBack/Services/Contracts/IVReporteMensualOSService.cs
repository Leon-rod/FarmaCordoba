using FarmaceuticaBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaceuticaBack.Services.Contracts
{
    public interface IVReporteMensualOSService
    {
        Task<List<VReporteMensualObraSocial>> GetAll();

        Task<List<VReporteMensualObraSocial>> GetByFilter(string os, int year, int month);
    }
}
