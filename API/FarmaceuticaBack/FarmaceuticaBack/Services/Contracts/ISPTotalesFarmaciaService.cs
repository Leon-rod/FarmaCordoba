using FarmaceuticaBack.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaceuticaBack.Services.Contracts
{
    public interface ISPTotalesFarmaciaService
    {
        Task<List<SPTotalesFarmacia>> ExecuteSp(int año);
    }
}
