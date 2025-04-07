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

namespace C_Presentacion
{
    public partial class Reporte_de_ventas : Form
    {
        public Reporte_de_ventas()
        {
            InitializeComponent();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            DateTime desde = dtpDesde.Value.Date;
            DateTime hasta = dtpHasta.Value.Date.AddDays(1).AddTicks(-1);


            DataTable dt = Reportes.ObtenerReporteVentas(desde, hasta);
            dgvVentas.Columns.Clear();
            dgvVentas.AutoGenerateColumns = true;
            dgvVentas.DataSource = dt;

            MessageBox.Show("Filas cargadas: " + dt.Rows.Count);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron ventas en ese rango de fechas.");
                dgvVentas.DataSource = null;
                pbGrafico.Image = null;
                lblTotal.Text = "Total generado: $0.00";
                lblMayorVenta.Text = "Mayor ventas: Sin ventas";
                return;
            }

            // Generar gráfico y totales
            DibujarGrafico(dt);
            MostrarTotales(dt);
            CargarReporte();

        }


        private void DibujarGrafico(DataTable dt)
        {
            if (dt.Rows.Count == 0) return;

            var datos = dt.AsEnumerable()
                .GroupBy(r => r.Field<string>("producto"))
                .Select(g => new
                {
                    Producto = g.Key,
                    Total = g.Sum(r => r.Field<decimal>("total"))
                })
                .OrderByDescending(g => g.Total)
                .ToList();

            int ancho = pbGrafico.Width;
            int altura = pbGrafico.Height;

            Bitmap bmp = new Bitmap(ancho, altura);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);

                int margenIzq = 40, margenInf = 40;
                int espacio = 20;
                int anchoBarra = (ancho - 2 * margenIzq - espacio * (datos.Count - 1)) / datos.Count;

                decimal maxTotal = datos.Max(x => x.Total);
                Font fuente = new Font("Segoe UI", 9);
                StringFormat formatoCentro = new StringFormat { Alignment = StringAlignment.Center };

                // Ejes
                g.DrawLine(Pens.Black, margenIzq, altura - margenInf, ancho - margenIzq, altura - margenInf);
                g.DrawLine(Pens.Black, margenIzq, 20, margenIzq, altura - margenInf);

                for (int i = 0; i < datos.Count; i++)
                {
                    var d = datos[i];
                    int x = margenIzq + i * (anchoBarra + espacio);
                    int h = (int)((d.Total / maxTotal) * (altura - margenInf - 40));
                    int y = altura - margenInf - h;

                    g.FillRectangle(Brushes.SkyBlue, x, y, anchoBarra, h);
                    g.DrawRectangle(Pens.Black, x, y, anchoBarra, h);

                    g.DrawString(d.Producto, fuente, Brushes.Black, x + anchoBarra / 2, altura - 30, formatoCentro);
                    g.DrawString(d.Total.ToString("C"), fuente, Brushes.Black, x + anchoBarra / 2, y - 20, formatoCentro);
                }
            }

            pbGrafico.Image?.Dispose();
            pbGrafico.Image = bmp;
        }
        
        private void CargarReporte()
        {
            DateTime desde = dtpDesde.Value.Date;
            DateTime hasta = dtpDesde.Value.Date.AddDays(1).AddTicks(-1); 

            var tabla = Reportes.ObtenerReporteVentas(desde, hasta);
            dgvVentas.DataSource = tabla;
            MostrarTotales(tabla);
            DibujarGrafico(tabla);
        }
        private void MostrarTotales(DataTable dt)
        {
            // Calcular el total general de todas las ventas
            decimal totalGeneral = dt.AsEnumerable().Sum(r => r.Field<decimal>("total"));

            // Calcular el producto que más dinero generó
            string masVendido = "Sin ventas";

            if (dt.Rows.Count > 0)
            {
                masVendido = dt.AsEnumerable()
                    .GroupBy(r => r.Field<string>("producto"))
                    .OrderByDescending(g => g.Sum(r => r.Field<decimal>("total")))
                    .First()
                    .Key;
            }

            // Mostrar los resultados en los label
            lblTotal.Text = $"Total generado: {totalGeneral:C}";
            lblMayorVenta.Text = $"Mayor ventas: {masVendido}";
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "PDF|*.pdf" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream fs = new FileStream(sfd.FileName, FileMode.Create))
                    {
                        Document doc = new Document(PageSize.A4);
                        PdfWriter.GetInstance(doc, fs);
                        doc.Open();

                        doc.Add(new Paragraph("Reporte de Ventas", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16)));

                        PdfPTable tabla = new PdfPTable(dgvVentas.Columns.Count);
                        foreach (DataGridViewColumn col in dgvVentas.Columns)
                            tabla.AddCell(col.HeaderText);

                        foreach (DataGridViewRow row in dgvVentas.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                    tabla.AddCell(cell.Value?.ToString() ?? "");
                            }
                        }

                        doc.Add(tabla);
                        doc.Add(new Paragraph(lblMayorVenta.Text));
                        doc.Add(new Paragraph(lblTotal.Text));
                        doc.Close();
                    }

                    MessageBox.Show("Exportado con éxito", "PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void Reporte_de_ventas_Load(object sender, EventArgs e)
        {

        }
    }
}
