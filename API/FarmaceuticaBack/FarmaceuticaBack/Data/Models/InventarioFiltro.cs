using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaceuticaBack.Data.Models
{
    public class InventarioFiltro
    {
        public int? IdFactura { get; set; }

        public int? IdPedido { get; set; }

        public int? IdTipoMov { get; set; }

        public DateTime? FechaDesde { get; set; }

        public DateTime? FechaHasta { get; set; }
    }
}
