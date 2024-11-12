using FarmaceuticaBack.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaceuticaBack.Data.Contracts
{
    public interface ISPTotalFarmacia
    {
        Task<List<SPTotalesFarmacia>> ExecuteSp(int año);

    }
}
