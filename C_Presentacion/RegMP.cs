namespace C_Presentacion
{
    public partial class RegMP : Form
    {
        public RegMP()
        {
            InitializeComponent();
        }

        private void tbNombreMP_KeyPress(object? sender, KeyPressEventArgs e)
        {
            Validaciones.SoloLetras(e);
        }

        private void tbPrecioMP_KeyPress(object? sender, KeyPressEventArgs e)
        {
            Validaciones.SoloNumerosDecimales(e, tbPrecioMP);
        }
    }
}
