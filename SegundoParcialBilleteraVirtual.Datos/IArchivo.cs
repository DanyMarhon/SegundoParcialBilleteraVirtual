using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoParcialBilleteraVirtual.Datos
{
    public interface IArchivo<T> where T : class
    {
        void GuardarDatos(T datos);
        T LeerDatos();
    }
}
