using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaceuticaBack.Data.Models
{
    public class SPReporteMensualCobertura
    {
        [Column("Tipo_de_cobertura")]
        public string TipoDeCobertura { get; set; }
        [Column("Importe_a_reintegrar")]
        public decimal ImporteAReintegrar { get; set; }
    }
}
