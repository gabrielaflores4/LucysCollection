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
            ((System.ComponentModel.ISupportInitialize)dgvVentas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbGrafico).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(274, 18);
            label1.Name = "label1";
            label1.Size = new Size(271, 40);
            label1.TabIndex = 0;
            label1.Text = "Reporte de Ventas";
            // 
            // dtpDesde
            // 
            dtpDesde.Location = new Point(17, 132);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new Size(200, 23);
            dtpDesde.TabIndex = 1;
            dtpDesde.Value = new DateTime(2025, 4, 7, 0, 0, 0, 0);
            // 
            // dtpHasta
            // 
            dtpHasta.Location = new Point(17, 182);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new Size(200, 23);
            dtpHasta.TabIndex = 2;
            // 
            // btnFiltrar
            // 
            btnFiltrar.Location = new Point(142, 251);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(75, 23);
            btnFiltrar.TabIndex = 3;
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.UseVisualStyleBackColor = true;
            btnFiltrar.Click += btnFiltrar_Click;
            // 
            // dgvVentas
            // 
            dgvVentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVentas.Location = new Point(191, 421);
            dgvVentas.Name = "dgvVentas";
            dgvVentas.Size = new Size(638, 360);
            dgvVentas.TabIndex = 5;
            // 
            // lblMayorVenta
            // 
            lblMayorVenta.AutoSize = true;
            lblMayorVenta.Font = new Font("Segoe UI", 12F);
            lblMayorVenta.Location = new Point(34, 340);
            lblMayorVenta.Name = "lblMayorVenta";
            lblMayorVenta.Size = new Size(92, 21);
            lblMayorVenta.TabIndex = 7;
            lblMayorVenta.Text = "Ma vendido";
            // 
            // btnExportar
            // 
            btnExportar.Location = new Point(34, 251);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(75, 23);
            btnExportar.TabIndex = 9;
            btnExportar.Text = "Exportar";
            btnExportar.UseVisualStyleBackColor = true;
            btnExportar.Click += btnExportar_Click;
            // 
            // pbGrafico
            // 
            pbGrafico.Location = new Point(240, 101);
            pbGrafico.Name = "pbGrafico";
            pbGrafico.Size = new Size(542, 271);
            pbGrafico.TabIndex = 10;
            pbGrafico.TabStop = false;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 12F);
            lblTotal.Location = new Point(34, 300);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(42, 21);
            lblTotal.TabIndex = 11;
            lblTotal.Tag = "";
            lblTotal.Text = "Total";
            // 
            // Reporte_de_ventas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(890, 792);
            Controls.Add(lblTotal);
            Controls.Add(pbGrafico);
            Controls.Add(btnExportar);
            Controls.Add(lblMayorVenta);
            Controls.Add(dgvVentas);
            Controls.Add(btnFiltrar);
            Controls.Add(dtpHasta);
            Controls.Add(dtpDesde);
            Controls.Add(label1);
            Name = "Reporte_de_ventas";
            Text = "Reporte_de_ventas";
            Load += Reporte_de_ventas_Load;
            ((System.ComponentModel.ISupportInitialize)dgvVentas).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbGrafico).EndInit();
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
    }
}