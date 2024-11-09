using FarmaceuticaBack.Data.Contracts;
using FarmaceuticaBack.Models;
using FarmaceuticaBack.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaceuticaBack.Services.Implementations
{
    public class ReporteMensualObraSocialService : IReporteMensualObraSocialService
    {
        private readonly IReporteMensualObraSocialRepository _repository;

        public ReporteMensualObraSocialService(IReporteMensualObraSocialRepository repository)
        {
            _repository = repository;   
        }
        public async Task<List<VReporteMensualObraSocial>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<List<VReporteMensualObraSocial>> GetByFilters(string? OS, int? year, int? month)
        {
            return await _repository.GetByFilters(OS, year, month); 
        }
    }
}
