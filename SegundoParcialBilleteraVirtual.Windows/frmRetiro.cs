namespace SegundoParcialBilleteraVirtual.Windows
{
    public partial class frmRetiro : Form
    {
        public frmRetiro()
        {
            InitializeComponent();
        }

        public string MonedaSeleccionada
        {
            get
            {
                if (rbtPesoArgentino.Checked) return "ARS";
                if (rbtDolar.Checked) return "USD";
                if (rbtEuro.Checked) return "EUR";
                if (rbtYuan.Checked) return "CNY";
                return null;
            }
        }

        public decimal Cantidad
        {
            get
            {
                decimal.TryParse(txtCantidad.Text, out decimal cantidad);
                return cantidad;
            }
        }
        public bool Confirmado { get; private set; } = false;

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (Cantidad <= 0)
            {
                MessageBox.Show("Ingrese una cantidad válida para el retiro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Confirmado = true;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Confirmado = false;
            Close();
        }
    }
}
