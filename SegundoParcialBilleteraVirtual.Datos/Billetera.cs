using SegundoParcialBilleteraVirtual.Entidades;

namespace SegundoParcialBilleteraVirtual.Datos
{
    public class Billetera
    {
        public Dictionary<string, Moneda> _monedas;

        public Billetera()
        {
            _monedas = new Dictionary<string, Moneda>();
            _serializador = new SerializadorXml();
        }

        public string Deposito(Moneda moneda)
        {
            if (_monedas.ContainsKey(moneda.Codigo))
            {
                _monedas[moneda.Codigo].Cantidad += moneda.Cantidad;
                return "Cantidad actualizada en la billetera.";
            }
            else
            {
                _monedas.Add(moneda.Codigo, moneda);
                return "Moneda agregada a la billetera.";
            }
        }

        public (bool, string) Retiro(Moneda moneda)
        {
            if (_monedas.ContainsKey(moneda.Codigo) && _monedas[moneda.Codigo].Cantidad >= moneda.Cantidad)
            {
                _monedas[moneda.Codigo].Cantidad -= moneda.Cantidad;
                return (true, "Retiro exitoso.");
            }
            return (false, "No se pudo realizar el retiro.");
        }

        public (bool, string) Pagar((string, decimal) pago)
        {
            if (_monedas.ContainsKey("ARS") && _monedas["ARS"].Cantidad >= pago.Item2)
            {
                _monedas["ARS"].Cantidad -= pago.Item2;
                return (true, $"Pago de {pago.Item1} realizado exitosamente.");
            }
            return (false, "No se pudo realizar el pago.");
        }

        public List<Moneda> MostrarContenido()
        {
            return _monedas.Values.ToList();
        }

        private SerializadorXml _serializador;

        public void GuardarDatos()
        {
            _serializador.GuardarDatos(_monedas.Values.ToList());
        }

        public void RecuperarDatos()
        {
            var monedas = _serializador.LeerDatos();
            foreach (var moneda in monedas)
            {
                Deposito(moneda);
            }
        }

        public int GetCantidad()
        {
            return _monedas.Count;
        }
    }

}
