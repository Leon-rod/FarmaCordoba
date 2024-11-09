using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaceuticaBack.Data.Models
{
    public class MedicamentoFiltro
    {
        public int IdMarca { get; set; }
        public int IdLaboratorio { get; set; }
        public int IdMonodroga { get; set; }
        public int IdPresentacion { get; set; }

        public bool Activo { get; set; }
        public string? NombreComercial { get; set; }

    }
}
