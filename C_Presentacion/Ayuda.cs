using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_Presentacion
{
    public partial class Ayuda : Form
    {
        private Dictionary<string, string> faqDiccionario = new Dictionary<string, string>();
        string respuestaActual = "";
        public Ayuda()
        {
            InitializeComponent();
        }

        private void Ayuda_Load(object sender, EventArgs e)
        {
            faqDiccionario.Add("¿Cómo registrar una venta?",
                "En el menú principal haz clic en el botón Ventas, selecciona productos, su talla y cantidad, luego en la parte de abajo seleccione un cliente y haga clic en 'Guardar'.");
            faqDiccionario.Add("¿Cómo agregar un cliente?",
                "Ve al menú 'Venta' y haz clic en 'Nuevo' en la parte de abajo. Llena el formulario con los datos solicitados y haga clici en 'Registrar'.");
            faqDiccionario.Add("¿Qué hago si la impresora no responde?",
                "Primero verifique que la impresora se encuentre encendida, en caso de estarlo y seguir sin funcionar, puede dirigirse a Configuración > Dispositivos > Impresoras/escáneres en Windows y seleccionar la impresora con doble clic, si esto no funciona verifique que el cable USB de la impresora este correctamente conectado a la computadora");
            faqDiccionario.Add("¿Cómo me salgo del sistema?",
                "En el menú principal haga clic en el botón --Cerrar Sesión--, luego de clic en la opción --Si--");

            // Botones para las preguntas
            foreach (var item in faqDiccionario)
            {
                Button btnPregunta = new Button();
                btnPregunta.Text = item.Key;
                btnPregunta.Width = 250;
                btnPregunta.Height = 60;
                btnPregunta.BackColor = Color.MediumPurple;
                btnPregunta.ForeColor = Color.White;
                btnPregunta.FlatStyle = FlatStyle.Flat;
                btnPregunta.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                btnPregunta.Tag = item.Value; // Guarda la respuesta

                btnPregunta.Click += BtnPregunta_Click;

                flpPreguntas.Controls.Add(btnPregunta);
            }

            panelRespuesta.Visible = false;


        }

        private void BtnPregunta_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string respuesta = btn.Tag.ToString();

            lblRespuesta.Text = respuesta;
            panelRespuesta.Visible = true;
            panelRespuesta.BringToFront();
        }
        private void btnCancelarAyuda_Click_1(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "¿Estás seguro que deseas cancelar?",
                "Confirmar cancelación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnContacto_Click_1(object sender, EventArgs e)
        {
            string contacto = "👤 Desarrolladores: Angela Barillas\n" + 
                                                 "Gabriela Flores\n" +
                             "📧 Correo: angela.barillas@catolica.edu.sv\n" +
                                         "gabriela.flores9@catolica.edu.sv\n" +
                             "📞 Teléfono: +503 6070-3230\n";

            respuestaActual = contacto;

            lblRespuesta.Text = respuestaActual;
            panelRespuesta.Visible = true;
            panelRespuesta.BringToFront();
        }
    }
}
    

