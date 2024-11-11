using FarmaceuticaBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaceuticaBack.Services.Contracts
{
    public interface IPersonalService
    {
        Task<bool> Add(Personal oPersonal);

        Task<int> GetLastId();
    }
}
