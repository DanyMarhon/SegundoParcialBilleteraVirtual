using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoParcialBilleteraVirtual.Entidades
{
    public class MonedaUSD : Moneda, IMoneda
    {
        private const decimal ArsRate = 350m;
        private const decimal EurRate = 0.94m;
        private const decimal CnyRate = 7.1m;

        public MonedaUSD(decimal cantidad) : base("USD", "$", cantidad) { }

        public override decimal ConvertirA(Type tipoMoneda)
        {
            if (tipoMoneda == typeof(MonedaARS))
                return Cantidad * ArsRate;
            if (tipoMoneda == typeof(MonedaEUR))
                return Cantidad * EurRate;
            if (tipoMoneda == typeof(MonedaCNY))
                return Cantidad * CnyRate;

            throw new InvalidOperationException("Tipo de moneda no soportado.");
        }

        public decimal GetCotizacionPeso()
        {
            return Cantidad * ArsRate;
        }
    }
}
