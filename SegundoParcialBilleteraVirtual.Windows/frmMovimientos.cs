using SegundoParcialBilleteraVirtual.Datos;
using SegundoParcialBilleteraVirtual.Entidades;
using SegundoParcialBilleteraVirtual.Windows.Helpers;

namespace SegundoParcialBilleteraVirtual.Windows
{
    public partial class frmMovimientos : Form
    {
        private Billetera? billetera;
        public frmMovimientos()
        {
            InitializeComponent();
            billetera = new Billetera();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            billetera!.GuardarDatos();
            Application.Exit();
        }

        private void frmMovimientos_Load(object sender, EventArgs e)
        {
            GridHelper.MostrarDatosEnGrilla<Moneda>(billetera.MostrarContenido()!, dgvDatos);
        }
    }
}
