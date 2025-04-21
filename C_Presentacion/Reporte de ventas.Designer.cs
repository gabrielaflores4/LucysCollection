namespace C_Presentacion
{
    partial class Reporte_de_ventas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            dtpDesde = new DateTimePicker();
            dtpHasta = new DateTimePicker();
            btnFiltrar = new Button();
            dgvVentas = new DataGridView();
            lblMayorVenta = new Label();
            btnExportar = new Button();
            pbGrafico = new PictureBox();
            lblTotal = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dgvVentas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbGrafico).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Black;
            label1.Font = new Font("Bahnschrift", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(565, 18);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(235, 33);
            label1.TabIndex = 0;
            label1.Text = "Reporte de Ventas";
            // 
            // dtpDesde
            // 
            dtpDesde.Font = new Font("Bahnschrift", 12F);
            dtpDesde.Location = new Point(44, 167);
            dtpDesde.Margin = new Padding(4, 4, 4, 4);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new Size(256, 27);
            dtpDesde.TabIndex = 1;
            dtpDesde.Value = new DateTime(2025, 4, 7, 0, 0, 0, 0);
            // 
            // dtpHasta
            // 
            dtpHasta.Font = new Font("Bahnschrift", 12F);
            dtpHasta.Location = new Point(44, 231);
            dtpHasta.Margin = new Padding(4, 4, 4, 4);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new Size(256, 27);
            dtpHasta.TabIndex = 2;
            // 
            // btnFiltrar
            // 
            btnFiltrar.Font = new Font("Bahnschrift", 12F);
            btnFiltrar.Location = new Point(204, 307);
            btnFiltrar.Margin = new Padding(4, 4, 4, 4);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(96, 29);
            btnFiltrar.TabIndex = 3;
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.UseVisualStyleBackColor = true;
            btnFiltrar.Click += btnFiltrar_Click;
            // 
            // dgvVentas
            // 
            dgvVentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVentas.Location = new Point(501, 328);
            dgvVentas.Margin = new Padding(4, 4, 4, 4);
            dgvVentas.Name = "dgvVentas";
            dgvVentas.Size = new Size(820, 346);
            dgvVentas.TabIndex = 5;
            // 
            // lblMayorVenta
            // 
            lblMayorVenta.AutoSize = true;
            lblMayorVenta.Font = new Font("Bahnschrift", 12F);
            lblMayorVenta.Location = new Point(44, 431);
            lblMayorVenta.Margin = new Padding(4, 0, 4, 0);
            lblMayorVenta.Name = "lblMayorVenta";
            lblMayorVenta.Size = new Size(99, 19);
            lblMayorVenta.TabIndex = 7;
            lblMayorVenta.Text = "Más Vendido";
            // 
            // btnExportar
            // 
            btnExportar.Font = new Font("Bahnschrift", 12F);
            btnExportar.Location = new Point(44, 307);
            btnExportar.Margin = new Padding(4, 4, 4, 4);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(96, 29);
            btnExportar.TabIndex = 9;
            btnExportar.Text = "Exportar";
            btnExportar.UseVisualStyleBackColor = true;
            btnExportar.Click += btnExportar_Click;
            // 
            // pbGrafico
            // 
            pbGrafico.Location = new Point(501, 104);
            pbGrafico.Margin = new Padding(4, 4, 4, 4);
            pbGrafico.Name = "pbGrafico";
            pbGrafico.Size = new Size(820, 184);
            pbGrafico.TabIndex = 10;
            pbGrafico.TabStop = false;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Bahnschrift", 12F);
            lblTotal.Location = new Point(44, 380);
            lblTotal.Margin = new Padding(4, 0, 4, 0);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(44, 19);
            lblTotal.TabIndex = 11;
            lblTotal.Tag = "";
            lblTotal.Text = "Total";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.rectangulo4;
            pictureBox1.Location = new Point(-3, 1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1372, 73);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 58;
            pictureBox1.TabStop = false;
            // 
            // Reporte_de_ventas
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(212, 221, 221);
            ClientSize = new Size(1370, 696);
            Controls.Add(lblTotal);
            Controls.Add(pbGrafico);
            Controls.Add(btnExportar);
            Controls.Add(lblMayorVenta);
            Controls.Add(dgvVentas);
            Controls.Add(btnFiltrar);
            Controls.Add(dtpHasta);
            Controls.Add(dtpDesde);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 4, 4, 4);
            Name = "Reporte_de_ventas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Reporte_de_ventas";
            WindowState = FormWindowState.Maximized;
            Load += Reporte_de_ventas_Load;
            ((System.ComponentModel.ISupportInitialize)dgvVentas).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbGrafico).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DateTimePicker dtpDesde;
        private DateTimePicker dtpHasta;
        private Button btnFiltrar;
        private DataGridView dgvVentas;
        private Label lblMayorVenta;
        private Button btnExportar;
        private PictureBox pbGrafico;
        private Label lblTotal;
        private PictureBox pictureBox1;
    }
}