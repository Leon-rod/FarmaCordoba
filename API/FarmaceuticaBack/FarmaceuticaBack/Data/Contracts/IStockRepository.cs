using FarmaceuticaBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaceuticaBack.Data.Contracts
{
    public interface IStockRepository
    {
        Task<bool> Add(Stock stock);
        Task<bool> Update(Stock stock);
        Task<List<Stock>> GetByEstablishment(int id);
        Task<List<Stock>> GetByEstablishmentAndArticle(int id,string? product,string? medicine);

        Task<List<Stock>> GetStockLotesByEstablishment(int id);

        Task<List<Stock>> GetStockLotesByEstablishmentAndFilter(int id, string medicamento, string lote, bool active);

        Task<List<Stock>> GetAllStockLotesByEstablishmentAndFilter(int establecimiento, int medicamento, int producto);
        
    }
}
