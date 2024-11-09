using FarmaceuticaBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaceuticaBack.Data.Contracts
{
    public interface IReporteMensualObraSocialRepository
    {
        Task<List<VReporteMensualObraSocial>> GetAll();

        Task<List<VReporteMensualObraSocial>> GetByFilters(string? OS, int? year, int? month);
    }
}
