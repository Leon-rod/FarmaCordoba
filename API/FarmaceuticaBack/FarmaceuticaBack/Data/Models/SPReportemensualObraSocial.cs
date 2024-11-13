using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaceuticaBack.Data.Models
{
    public class SPReportemensualObraSocial
    {
        [Column("Obra_social")]
        public string ObraSocial { get; set; }
        [Column("Importe_a_reintegrar")]
        public decimal ImporteAReintegrar { get; set; }
    }
}
