using FarmaceuticaBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaceuticaBack.Services.Contracts
{
    public interface IFacturaService
    {
        Task<List<Factura>> GetAll();
        Task<Factura> GetById(int id);
        Task<List<Factura>> GetByClient(int client);
        Task<List<Factura>> GetByEmployee(int employee);
        Task<List<Factura>> GetByEstablishment(int establishment);
        Task<List<Factura>> GetByDates(DateOnly startDate, DateOnly endDate);
        Task<bool> Insert(Factura factura);
        Task<bool> Update(Factura factura);
        Task<int> GetLastId();
    }
}
