using FarmaceuticaBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaceuticaBack.Data.Contracts
{
    public interface IMedicamentoLoteRepository
    {
        Task<List<MedicamentosLote>> GetAll();

        Task<bool> Add(MedicamentosLote oMedicamento);

        Task<int> GetLastId();

    }
}
