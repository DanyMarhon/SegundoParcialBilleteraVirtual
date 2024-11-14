using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoParcialBilleteraVirtual.Entidades
{
    public class MonedaARS : Moneda
    {
        private const decimal UsdRate = 350m;
        private const decimal EurRate = 0.94m;
        private const decimal CnyRate = 50m;

        public MonedaARS(decimal cantidad) : base("ARS", "$", cantidad) { }

        public override decimal ConvertirA(Type tipoMoneda)
        {
            if (tipoMoneda == typeof(MonedaUSD))
                return Cantidad * UsdRate;
            if (tipoMoneda == typeof(MonedaEUR))
                return Cantidad * EurRate;
            if (tipoMoneda == typeof(MonedaCNY))
                return Cantidad * CnyRate;

            throw new InvalidOperationException("Tipo de moneda no soportado.");
        }
    }
}
