using FarmaceuticaBack.Data.Contracts;
using FarmaceuticaBack.Models;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FarmaceuticaBack.Data.Models;

namespace FarmaceuticaBack.Data.Repositories
{
    public class SPTotalFarmaciaRepository : ISPTotalFarmacia
    {
        private readonly FarmaceuticaContext _context;

        public SPTotalFarmaciaRepository(FarmaceuticaContext context)
        {
            _context = context;
        }
        public async Task<List<SPTotalesFarmacia>> ExecuteSp(int año)
        {
            var resultados = await _context.Set<SPTotalesFarmacia>()
            .FromSqlRaw("EXEC SP_TOTALES_FACTURADOS_FARMACIAS @año = {0}", año)
            .ToListAsync();

            return resultados;
        }

        public async Task<List<SPReporteMensualCobertura>> ExecuteSpCobertura(int año, int mes, int obra)
        {
            var resultados = await _context.Set<SPReporteMensualCobertura>()
                .FromSqlRaw("EXEC SP_REPORTE_MENSUAL_COBERTURA @ANIO = {0}, @MES = {1}, @OBRA_SOCIAL = {2}", año, mes, obra)
                .ToListAsync();
            return resultados;
        }

        public async Task<List<SPMayoresCompras>> ExecuteSpMayoresCompras(int year, int count)
        {
            var resultados = await _context.Set<SPMayoresCompras>()
                .FromSqlRaw("EXEC SP_MAYORES_COMPRAS @AÑO = {0}, @CANTIDAD = {1}", year, count)
                .ToListAsync();
                return resultados;
        }

        public async Task<List<SPReportemensualObraSocial>> ExecuteSpObraSocial(int a, int mes, int obra)
        {
            var resultados = await _context.Set<SPReportemensualObraSocial>()
                .FromSqlRaw("EXEC SP_REPORTE_MENSUAL_OBRA_SOCIAL @ANIO = {0}, @MES = {1}, @OBRA_SOCIAL = {2}", a, mes, obra)
                .ToListAsync();
            return resultados;
        }
    }
}
