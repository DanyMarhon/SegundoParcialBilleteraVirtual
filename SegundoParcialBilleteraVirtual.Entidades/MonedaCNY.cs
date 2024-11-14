namespace SegundoParcialBilleteraVirtual.Entidades
{
    public class MonedaCNY : Moneda, IMoneda
    {
        private const decimal UsdRate = 7.1m;
        private const decimal ArsRate = 50m;

        public MonedaCNY(decimal cantidad) : base("CNY", "Y", cantidad) { }

        public MonedaCNY() : base()
        {

        }
        public override decimal ConvertirA(Type tipoMoneda)
        {
            if (tipoMoneda == typeof(MonedaCNY))
                return Cantidad;
            if (tipoMoneda == typeof(MonedaUSD))
                return Cantidad * UsdRate;
            if (tipoMoneda == typeof(MonedaARS))
                return Cantidad * ArsRate;

            throw new InvalidOperationException("Tipo de moneda no soportado.");
        }

        public decimal GetCotizacionPeso()
        {
            return Cantidad * ArsRate;
        }
    }
}