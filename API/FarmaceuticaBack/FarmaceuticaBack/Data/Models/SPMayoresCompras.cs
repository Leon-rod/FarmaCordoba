using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaceuticaBack.Data.Models
{
    public class SPMayoresCompras
    {
        [Column("Año")]
        public int Year { get; set; }
        [Column("Mes")]
        public string Month {  get; set; }
        [Column("Cliente")]
        public string Client { get; set; }
        [Column("Total_Medicamentos")]
        public decimal TotalMedicine { get; set; }
        [Column("Contacto")]
        public string Contact { get; set; }
        [Column("Barrio")]
        public string District { get; set; }
        [Column("Cantidad_Compras")]
        public int QuantityPurchases { get; set; }
        [Column("Mayor_Monto")]
        public decimal MaxAmount { get; set; }
    }
}
