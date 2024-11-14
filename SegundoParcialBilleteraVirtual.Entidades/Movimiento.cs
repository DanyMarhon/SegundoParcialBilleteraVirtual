using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoParcialBilleteraVirtual.Entidades
{
    public class Movimiento
    {
        public string CodigoMoneda { get; set; }
        public decimal Deposito { get; set; }
        public decimal Retiro { get; set; }
        public DateTime FechaMovimiento { get; set; }
        public TipoMovimiento TipoMovimiento { get; set; }
    }
}
