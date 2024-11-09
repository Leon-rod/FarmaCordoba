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
    public class VReporteMensualOSService : IVReporteMensualOSService
    {
        private readonly IVReporteMensualOSRepository _repository;

        public VReporteMensualOSService(IVReporteMensualOSRepository repository)
        {
            _repository = repository;   
        }

        public async Task<List<VReporteMensualObraSocial>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<List<VReporteMensualObraSocial>> GetByFilter(string os, int year, int month)
        {
            return await _repository.GetByFilter(os, year, month);
        }
    }
}
