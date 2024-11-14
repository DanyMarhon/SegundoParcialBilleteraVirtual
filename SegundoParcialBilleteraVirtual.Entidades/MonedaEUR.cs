namespace SegundoParcialBilleteraVirtual.Entidades
{
    public class MonedaEUR : Moneda, IMoneda
    {
        private const decimal UsdRate = 350m;
        private const decimal ArsRate = 0.94m;

        public MonedaEUR(decimal cantidad) : base("EUR", "€", cantidad) { }

        public MonedaEUR() : base()
        {

        }
        public override decimal ConvertirA(Type tipoMoneda)
        {
            if (tipoMoneda == typeof(MonedaEUR))
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