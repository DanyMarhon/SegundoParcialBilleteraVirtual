using SegundoParcialBilleteraVirtual.Datos;
using SegundoParcialBilleteraVirtual.Entidades;
using SegundoParcialBilleteraVirtual.Windows.Helpers;
using System.Drawing;

namespace SegundoParcialBilleteraVirtual.Windows
{
    public partial class frmBilleteraVirtual : Form
    {
        private Billetera? billetera;
        private Dictionary<string, Moneda>? monedas;
        public frmBilleteraVirtual()
        {
            InitializeComponent();
            billetera = new Billetera();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            billetera!.GuardarDatos();
            Application.Exit();
        }

        private void btnDeposito_Click(object sender, EventArgs e)
        {
            using (var frmDeposito = new frmDeposito())
            {
                frmDeposito.ShowDialog();

                if (frmDeposito.Confirmado)
                {
                    Moneda moneda = null;

                    switch (frmDeposito.MonedaSeleccionada)
                    {
                        case "ARS":
                            moneda = new MonedaARS(frmDeposito.Cantidad);
                            break;
                        case "USD":
                            moneda = new MonedaUSD(frmDeposito.Cantidad);
                            break;
                        case "EUR":
                            moneda = new MonedaEUR(frmDeposito.Cantidad);
                            break;
                        case "CNY":
                            moneda = new MonedaCNY(frmDeposito.Cantidad);
                            break;
                    }

                    if (moneda != null)
                    {
                        billetera.Deposito(moneda);
                        MessageBox.Show($"Se depositaron {frmDeposito.Cantidad} {frmDeposito.MonedaSeleccionada}.", "Depósito Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        var monedas = billetera.MostrarContenido();
                        GridHelper.MostrarDatosEnGrilla(monedas, dgvDatos);
                    }
                }
            }
        }

        private void btnExtraccion_Click(object sender, EventArgs e)
        {
            using (var frmRetiro = new frmRetiro())
            {
                frmRetiro.ShowDialog();

                if (frmRetiro.Confirmado)
                {
                    Moneda moneda = null;

                    switch (frmRetiro.MonedaSeleccionada)
                    {
                        case "ARS":
                            moneda = new MonedaARS(frmRetiro.Cantidad);
                            break;
                        case "USD":
                            moneda = new MonedaUSD(frmRetiro.Cantidad);
                            break;
                        case "EUR":
                            moneda = new MonedaEUR(frmRetiro.Cantidad);
                            break;
                        case "CNY":
                            moneda = new MonedaCNY(frmRetiro.Cantidad);
                            break;
                    }

                    if (moneda != null)
                    {
                        billetera.Retiro(moneda);
                        MessageBox.Show($"Se retiró {frmRetiro.Cantidad} {frmRetiro.MonedaSeleccionada}.", "Retiro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        var monedas = billetera.MostrarContenido();
                        GridHelper.MostrarDatosEnGrilla(monedas, dgvDatos);
                    }
                }
            }
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {

        }

        private void frmBilleteraVirtual_Load(object sender, EventArgs e)
        {
            billetera.RecuperarDatos();

            var monedas = billetera.MostrarContenido();
            GridHelper.MostrarDatosEnGrilla(monedas, dgvDatos);
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
