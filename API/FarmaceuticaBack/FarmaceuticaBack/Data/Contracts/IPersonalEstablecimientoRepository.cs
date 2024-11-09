using FarmaceuticaBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaceuticaBack.Data.Contracts
{
    public interface IPersonalEstablecimientoRepository
    {
        Task<List<PersonalCargosEstablecimiento>> GetAll();
        Task<PersonalCargosEstablecimiento> GetById(int id);
    }
}
