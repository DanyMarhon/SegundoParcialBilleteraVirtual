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
                frmDeposito.ShowDialog(); // Muestra el formulario de depósito como un diálogo modal

                if (frmDeposito.Confirmado)
                {
                    // Crea un objeto Moneda con los datos ingresados
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
                        billetera.Deposito(moneda); // Llama al método Depósito en la billetera
                        MessageBox.Show($"Se depositaron {frmDeposito.Cantidad} {frmDeposito.MonedaSeleccionada}.", "Depósito Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        var monedas = billetera.MostrarContenido();
                        GridHelper.MostrarDatosEnGrilla(monedas, dgvDatos); // Método para refrescar la grilla
                    }
                }
            }
        }

        private void btnExtraccion_Click(object sender, EventArgs e)
        {

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
