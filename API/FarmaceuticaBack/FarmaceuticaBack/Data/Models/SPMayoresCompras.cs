using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaceuticaBack.Data.Models
{
    public class SPMayoresCompras
    {
        public int Año { get; set; }
        public string Mes {  get; set; }
        public string Cliente { get; set; }
        public int Total_Medicamentos { get; set; }
        public string Contacto { get; set; }
        public string Barrio { get; set; }
        public int Cantidad_Compras { get; set; }
        public int MayorMonto { get; set; }
    }
}
