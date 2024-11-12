using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaceuticaBack.Data.Models
{
    public class SPTotalesFarmacia
    {
        [Column("ID_ESTABLECIMIENTO")]
        public int IdEstablecimiento { get; set; }

        [Column("Establecimiento")]
        public string Establecimiento { get; set; }

        [Column("Total facturado")]
        public decimal TotalFacturado { get; set; }

        [Column("Mejor año facturado")]
        public string MejorAño { get; set; }
    }
}
