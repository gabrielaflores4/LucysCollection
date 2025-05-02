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

            decimal total = dt.AsEnumerable().Sum(row => Convert.ToDecimal(row["total"]));
            float startAngle = 0f;

            int margenX = (int)(width * 0.1);
            int margenY = (int)(height * 0.1);
            int diametro = Math.Min(width - 2 * margenX, height - 2 * margenY);

            Rectangle rect = new Rectangle(margenX, margenY, diametro, diametro);
            Color[] colors = { Color.SteelBlue, Color.Orange, Color.Green, Color.Red, Color.DeepPink, Color.Goldenrod, Color.Teal, Color.LightCoral };

            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                decimal valor = Convert.ToDecimal(row["total"]);
                float sweepAngle = (float)(valor / total) * 360f;

                using (Brush b = new SolidBrush(colors[i % colors.Length]))
                {
                    g.FillPie(b, rect, startAngle, sweepAngle);
                }

                startAngle += sweepAngle;
                i++;
            }

            int legendX = rect.Right + 10;
            int legendY = margenY;

            i = 0;

            foreach (DataRow row in dt.Rows)
            {
                string producto = row["producto"].ToString();
                decimal valor = Convert.ToDecimal(row["total"]);
                float porcentaje = (float)(valor / total) * 100f;

                using (Brush b = new SolidBrush(colors[i % colors.Length]))
                {
                    g.FillRectangle(b, legendX, legendY, 15, 15);
                }

                g.DrawString($"{producto} ({porcentaje:F1}%)", new Font("Arial", 9), Brushes.Black, legendX + 20, legendY - 2);
                legendY += 20;
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

        private void btnExportarPDF_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "PDF files (*.pdf)|*.pdf",
                FileName = "Reporte de Ventas.pdf"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = new FileStream(sfd.FileName, FileMode.Create))
                {
                    Document doc = new Document(PageSize.A4, 10, 10, 10, 10);
                    PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                    doc.Open();

                    /*Título*/
                    doc.Add(new Paragraph("Reporte de Ventas"));
                    doc.Add(new Paragraph("\n"));
                    doc.Add(new Paragraph("\n"));
                    doc.Add(new Paragraph("\n"));

                    /*Tabla*/
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
                            chartImg.ScaleToFit(500f, 300f);
                            chartImg.Alignment = Element.ALIGN_CENTER;
                            doc.Add(chartImg);
                        }
                    }

                    doc.Close();
                }

                MessageBox.Show("PDF guardado correctamente.");
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (cbFiltro.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione si por: Día, Semana o Mes).");
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
        }
    }
}
