using FarmaceuticaBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaceuticaBack.Services.Contracts
{
    public interface IPersonalEstablecimientoService
    {
        Task<List<PersonalCargosEstablecimiento>> GetAll();
        Task<PersonalCargosEstablecimiento> GetById(int id);

        Task<List<PersonalCargosEstablecimiento>> GetByEstablishment(int id);

        Task<List<PersonalCargosEstablecimiento>> GetByFilter(int id, string nombre, string apellido);

        Task<bool> Add(PersonalCargosEstablecimiento oPersonal);

        Task<int> GetLastId();
    }
}
