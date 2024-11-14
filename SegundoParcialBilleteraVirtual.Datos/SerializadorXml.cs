using SegundoParcialBilleteraVirtual.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SegundoParcialBilleteraVirtual.Datos
{
    public class SerializadorXml : IArchivo<List<Moneda>>
    {
        private readonly string nombreArchivo = "Billetera.Xml";
        private readonly string rutaCompletaArchivo;

        public SerializadorXml()
        {
            string rutaPrograma = AppDomain.CurrentDomain.BaseDirectory;
            rutaCompletaArchivo = Path.Combine(rutaPrograma, nombreArchivo);
        }

        public void GuardarDatos(List<Moneda> datos)
        {
            using (FileStream fs = new FileStream(rutaCompletaArchivo, FileMode.Create))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Moneda>));
                serializer.Serialize(fs, datos);
            }
        }

        public List<Moneda> LeerDatos()
        {
            if (!File.Exists(rutaCompletaArchivo))
                return new List<Moneda>();

            using (FileStream fs = new FileStream(rutaCompletaArchivo, FileMode.Open))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Moneda>));
                return (List<Moneda>)serializer.Deserialize(fs);
            }
        }
    }
}
