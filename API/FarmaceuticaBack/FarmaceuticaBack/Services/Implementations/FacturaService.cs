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
    public class FacturaService : IFacturaService
    {
        private readonly IFacturaRepository _repository;
        public FacturaService(IFacturaRepository repository)
        {
            this._repository = repository;
        }
        public async Task<List<Factura>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<List<Factura>> GetByClient(int client)
        {
            return await _repository.GetByClient(client);
        }

        public async Task<List<Factura>> GetByDates(DateOnly startDate, DateOnly endDate)
        {
            return await _repository.GetByDates(startDate, endDate);
        }

        public async Task<List<Factura>> GetByEmployee(int employee)
        {
            return await _repository.GetByEmployee(employee);
        }

        public async Task<List<Factura>> GetByEstablishment(int establishment)
        {
            return await _repository.GetByEstablishment(establishment);
        }

        public async Task<Factura> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<int> GetLastId()
        {
            return await _repository.GetLastId();
        }

        public async Task<bool> Insert(Factura factura)
        {
            return await _repository.Insert(factura);
        }

        public async Task<bool> Update(Factura factura)
        {
            return await _repository.Update(factura);
        }
    }
}
