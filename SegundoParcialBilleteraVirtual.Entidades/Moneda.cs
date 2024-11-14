using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace SegundoParcialBilleteraVirtual.Entidades
{
    [XmlInclude(typeof(MonedaARS))]
    [XmlInclude(typeof(MonedaCNY))]
    [XmlInclude(typeof(MonedaEUR))]
    [XmlInclude(typeof(MonedaUSD))]

    public abstract class Moneda
    {
        private string _codigo;
        private string _simbolo;
        private decimal _cantidad;

        public string Codigo
        {
            get => _codigo;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("El código no puede ser nulo o vacío.");
                _codigo = value;
            }
        }

        public string Simbolo
        {
            get => _simbolo;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("El símbolo no puede ser nulo o vacío.");
                _simbolo = value;
            }
        }

        public decimal Cantidad
        {
            get => _cantidad;
            set
            {
                if (value < 0)
                    throw new ArgumentException("La cantidad debe ser mayor o igual a cero.");
                _cantidad = value;
            }
        }

        public Moneda() { }

        protected Moneda(string codigo, string simbolo, decimal cantidad)
        {
            Codigo = codigo;
            Simbolo = simbolo;
            Cantidad = cantidad;
        }

        public override string ToString()
        {
            return $"{Codigo} {Simbolo} {Cantidad}";
        }

        public abstract decimal ConvertirA(Type tipoMoneda);

        
    }
}
