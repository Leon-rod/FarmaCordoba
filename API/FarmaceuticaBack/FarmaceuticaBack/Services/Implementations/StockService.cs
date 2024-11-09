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
    public class StockService : IStockService
    {
        private readonly IStockRepository _stockRepository;
        public StockService(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }
        public async Task<bool> Add(Stock stock)
        {
            return await _stockRepository.Add(stock);
        }

        public async Task<List<Stock>> GetByEstablishment(int id)
        {
            return await _stockRepository.GetByEstablishment(id);
        }

        public async Task<List<Stock>> GetByEstablishmentAndArticle(int id, string? product, string? medicine)
        {
            return await _stockRepository.GetByEstablishmentAndArticle(id, product, medicine);
        }

        public async Task<bool> Update(Stock stock)
        {
            return await _stockRepository.Update(stock);
        }
    }
}
