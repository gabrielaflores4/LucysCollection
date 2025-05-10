using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using C_Datos;
using C_Negocios;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using Font = System.Drawing.Font;
using Rectangle = System.Drawing.Rectangle;
using System.Drawing.Drawing2D;
using System.Security.Policy;

namespace C_Presentacion
{
    public partial class Reporte_de_ventas : Form
    {
        public Reporte_de_ventas()
        {
            InitializeComponent();
        }

        private void DibujarGrafico(DataTable dt)
        {
            int width = pbGrafico.Width;
            int height = pbGrafico.Height;

            Bitmap bmp = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bmp);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Color.White);

            if (dt.Rows.Count == 0)
            {
                pbGrafico.Image = bmp;
                return;
            }

            // Colores combinables para el sistema
            Color[] colores = {
            Color.FromArgb(128, 0, 128), // Morado //
            Color.Gray,
            Color.Black,
            Color.DarkSlateBlue,
            Color.DarkGray,
            Color.MediumPurple,
            Color.DimGray,
            Color.Indigo
         };

            decimal maxValor = dt.AsEnumerable().Max(row => Convert.ToDecimal(row["total"]));
            int barHeight = 30; 
            int espacio = 10;
            int margenIzquierdo = 30;
            int margenSuperior = 20;

            int zonaLeyendaAltura = dt.Rows.Count * 20 + 50;
            int zonaGraficoAltura = height - zonaLeyendaAltura;

            // --- Dibujo de barras (parte superior) ---
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                decimal valor = Convert.ToDecimal(row["total"]);
                float proporcion = (float)(valor / maxValor);

                int barraAncho = (int)((width - margenIzquierdo - 30) * proporcion);
                int posY = margenSuperior + i * (barHeight + espacio);

                if (posY + barHeight > zonaGraficoAltura)
                    break;

                using (Brush b = new SolidBrush(colores[i % colores.Length]))
                {
                    g.FillRectangle(b, margenIzquierdo, posY, barraAncho, barHeight);
                }

                // Mostrar solo el valor al final de la barra
                g.DrawString($"{valor:C}", new Font("Arial", 8), Brushes.Black, margenIzquierdo + barraAncho + 5, posY + 6);

                i++;
            }

            // --- Sección con los nombres en forma de lista vertical debajo ---
            int xLeyenda = 10;
            int yLeyendaInicio = zonaGraficoAltura - 7;

            i = 0;
            foreach (DataRow row in dt.Rows)
            {
                string producto = row["producto"].ToString();
                int y = yLeyendaInicio + i * 20;

                using (Brush b = new SolidBrush(colores[i % colores.Length]))
                {
                    g.FillRectangle(b, xLeyenda, y, 12, 12);
                }

                g.DrawRectangle(Pens.Black, xLeyenda, y, 12, 12);
                g.DrawString(producto, new Font("Arial", 12), Brushes.Black, xLeyenda + 18, y - 1);

                i++;
            }

            pbGrafico.Image = bmp;
        }


        private void MostrarTotales(DataTable dt)
        {
            decimal totalGeneral = dt.AsEnumerable().Sum(r => r.Field<decimal>("total"));

            string masVendido = "Sin ventas";
            string empleadoTop = "Sin datos";

            if (dt.Rows.Count > 0)
            {
                masVendido = dt.AsEnumerable()
                    .GroupBy(r => r.Field<string>("producto"))
                    .OrderByDescending(g => g.Sum(r => r.Field<decimal>("total")))
                    .First()
                    .Key;

                empleadoTop = dt.AsEnumerable()
                    .GroupBy(r => r.Field<string>("empleado"))
                    .OrderByDescending(g => g.Sum(r => r.Field<decimal>("total")))
                    .First()
                    .Key;
            }

            lblTotal.Text = $"Total generado: {totalGeneral:C}";
            lblMayorVenta.Text = $"Mayor ventas: {masVendido}";
            lblEmpleadoTop.Text = $"Usuario con más ventas: {empleadoTop}";
        }

        private void Reporte_de_ventas_Load(object sender, EventArgs e)
        {
            cbFiltro.Items.Add("Dia");
            cbFiltro.Items.Add("Semana");
            cbFiltro.Items.Add("Mes");
        }

        private void btnCancelarReporte_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbFiltro.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, seleccione si por: Día, Semana o Mes.");
                    return;
                }

                DateTime desde, hasta;

                switch (cbFiltro.SelectedItem.ToString())
                {
                    case "Dia":
                        desde = dtpDesde.Value.Date;
                        hasta = desde.AddDays(1).AddSeconds(-1);
                        break;

                    case "Semana":
                        int delta = DayOfWeek.Monday - dtpDesde.Value.DayOfWeek;
                        desde = dtpDesde.Value.AddDays(delta).Date;
                        hasta = desde.AddDays(7).AddSeconds(-1);
                        break;

                    case "Mes":
                        desde = new DateTime(dtpDesde.Value.Year, dtpDesde.Value.Month, 1);
                        hasta = desde.AddMonths(1).AddSeconds(-1);
                        break;

                    default:
                        MessageBox.Show("Filtro no válido");
                        return;
                }

                DataTable dt = Reportes.ObtenerReporteVentas(desde, hasta);
                dgvVentas.DataSource = dt;

                DibujarGrafico(dt);
                MostrarTotales(dt);

                string carpetaDestino = @"C:\Users\Usuario\Desktop\Reportes de ventas Lucy´s Collections";

                if (!Directory.Exists(carpetaDestino))
                {
                    Directory.CreateDirectory(carpetaDestino);
                }

                string fechaActual = DateTime.Now.ToString("dd-MM-yyyy");
                string nombreArchivo = $"RV{fechaActual}.pdf";
                string rutaCompleta = Path.Combine(carpetaDestino, nombreArchivo);

                int contador = 1;
                while (File.Exists(rutaCompleta))
                {
                    nombreArchivo = $"RV{fechaActual}_{contador}.pdf";
                    rutaCompleta = Path.Combine(carpetaDestino, nombreArchivo);
                    contador++;
                }

                using (FileStream fs = new FileStream(rutaCompleta, FileMode.Create))
                {
                    Document doc = new Document(PageSize.A4, 10, 10, 10, 10);
                    PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                    doc.Open();

                    doc.Add(new Paragraph("Reporte de Ventas"));
                    doc.Add(new Paragraph("\n"));
                    doc.Add(new Paragraph(lblTotal.Text));
                    doc.Add(new Paragraph(lblMayorVenta.Text));
                    doc.Add(new Paragraph(lblEmpleadoTop.Text));
                    doc.Add(new Paragraph("\n"));

                    PdfPTable tabla = new PdfPTable(dgvVentas.Columns.Count);
                    foreach (DataGridViewColumn col in dgvVentas.Columns)
                    {
                        tabla.AddCell(new Phrase(col.HeaderText));
                    }
                    foreach (DataGridViewRow row in dgvVentas.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                tabla.AddCell(cell.Value?.ToString() ?? "");
                            }
                        }
                    }
                    doc.Add(tabla);
                    doc.Add(new Paragraph("\n"));

                    if (pbGrafico.Image != null)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            pbGrafico.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            iTextSharp.text.Image chartImg = iTextSharp.text.Image.GetInstance(ms.ToArray());
                            chartImg.ScaleToFit(600f, 400f);
                            chartImg.Alignment = Element.ALIGN_CENTER;
                            doc.Add(chartImg);
                        }
                    }

                    doc.Close();
                }

                MessageBox.Show($"Reporte guardado correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al guardar el reporte: {ex.Message}");
            }
        }
    }
}
