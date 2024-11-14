using SegundoParcialBilleteraVirtual.Datos;
using SegundoParcialBilleteraVirtual.Entidades;
using SegundoParcialBilleteraVirtual.Windows.Helpers;

namespace SegundoParcialBilleteraVirtual.Windows
{
    public partial class frmBilleteraVirtual : Form
    {
        private Billetera? billetera;
        private Dictionary<string, Moneda>? monedas;
        public frmBilleteraVirtual()
        {
            InitializeComponent();
        }


        Moneda monedaAr = new MonedaARS(500);
        Moneda monedaUs = new MonedaUSD(500);
        Moneda monedaYn = new MonedaCNY(500);
        Moneda monedaEu = new MonedaEUR(500);

        private void btnSalir_Click(object sender, EventArgs e)
        {
            billetera!.GuardarDatos();
            Application.Exit();
        }

        private void btnDeposito_Click(object sender, EventArgs e)
        {
            
        }

        private void btnExtraccion_Click(object sender, EventArgs e)
        {

        }

        private void btnPagar_Click(object sender, EventArgs e)
        {

        }

        private void frmBilleteraVirtual_Load(object sender, EventArgs e)
        {

            //GridHelper.MostrarDatosEnGrilla<Moneda>(billeteras!, billeteras.ToString());
        }

        private void btnComprarDivisas_Click(object sender, EventArgs e)
        {
        }

        private void btnMovimientos_Click(object sender, EventArgs e)
        {

        }

        private void btnUltimosMovimientos_Click(object sender, EventArgs e)
        {

        }
    }
}
