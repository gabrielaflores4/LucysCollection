﻿namespace C_Presentacion
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reporte_de_ventas));
            label1 = new Label();
            dtpDesde = new DateTimePicker();
            dgvVentas = new DataGridView();
            lblMayorVenta = new Label();
            pbGrafico = new PictureBox();
            lblTotal = new Label();
            pictureBox1 = new PictureBox();
            cbFiltro = new ComboBox();
            lblEmpleadoTop = new Label();
            btnCancelarReporte = new PictureBox();
            btnGenerar = new PictureBox();
            lblInfor = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvVentas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbGrafico).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnCancelarReporte).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnGenerar).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Black;
            label1.Font = new Font("Bahnschrift", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(565, 15);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(235, 33);
            label1.TabIndex = 0;
            label1.Text = "Reporte de Ventas";
            // 
            // dtpDesde
            // 
            dtpDesde.Font = new Font("Bahnschrift", 12F);
            dtpDesde.Location = new Point(799, 588);
            dtpDesde.Margin = new Padding(4);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new Size(302, 27);
            dtpDesde.TabIndex = 1;
            dtpDesde.Value = new DateTime(2025, 4, 7, 0, 0, 0, 0);
            // 
            // dgvVentas
            // 
            dataGridViewCellStyle1.BackColor = Color.FromArgb(224, 224, 224);
            dataGridViewCellStyle1.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dgvVentas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvVentas.BackgroundColor = Color.FromArgb(224, 224, 224);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.Black;
            dataGridViewCellStyle2.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.Black;
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvVentas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvVentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Desktop;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvVentas.DefaultCellStyle = dataGridViewCellStyle3;
            dgvVentas.EnableHeadersVisualStyles = false;
            dgvVentas.GridColor = Color.FromArgb(224, 224, 224);
            dgvVentas.Location = new Point(799, 214);
            dgvVentas.Margin = new Padding(4);
            dgvVentas.Name = "dgvVentas";
            dgvVentas.RowHeadersVisible = false;
            dgvVentas.Size = new Size(520, 325);
            dgvVentas.TabIndex = 5;
            // 
            // lblMayorVenta
            // 
            lblMayorVenta.AutoSize = true;
            lblMayorVenta.Font = new Font("Bahnschrift", 12F);
            lblMayorVenta.Location = new Point(799, 133);
            lblMayorVenta.Margin = new Padding(4, 0, 4, 0);
            lblMayorVenta.Name = "lblMayorVenta";
            lblMayorVenta.Size = new Size(103, 19);
            lblMayorVenta.TabIndex = 7;
            lblMayorVenta.Text = "Más Vendido:";
            // 
            // pbGrafico
            // 
            pbGrafico.BackColor = Color.FromArgb(224, 224, 224);
            pbGrafico.Location = new Point(13, 79);
            pbGrafico.Margin = new Padding(4);
            pbGrafico.Name = "pbGrafico";
            pbGrafico.Size = new Size(742, 604);
            pbGrafico.TabIndex = 10;
            pbGrafico.TabStop = false;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Bahnschrift", 12F);
            lblTotal.Location = new Point(799, 97);
            lblTotal.Margin = new Padding(4, 0, 4, 0);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(48, 19);
            lblTotal.TabIndex = 11;
            lblTotal.Tag = "";
            lblTotal.Text = "Total:";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.rectangulo4;
            pictureBox1.Location = new Point(-3, -1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1372, 73);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 58;
            pictureBox1.TabStop = false;
            // 
            // cbFiltro
            // 
            cbFiltro.FormattingEnabled = true;
            cbFiltro.Location = new Point(1198, 588);
            cbFiltro.Name = "cbFiltro";
            cbFiltro.Size = new Size(121, 27);
            cbFiltro.TabIndex = 59;
            // 
            // lblEmpleadoTop
            // 
            lblEmpleadoTop.AutoSize = true;
            lblEmpleadoTop.Font = new Font("Bahnschrift", 12F);
            lblEmpleadoTop.Location = new Point(799, 171);
            lblEmpleadoTop.Margin = new Padding(4, 0, 4, 0);
            lblEmpleadoTop.Name = "lblEmpleadoTop";
            lblEmpleadoTop.Size = new Size(208, 19);
            lblEmpleadoTop.TabIndex = 60;
            lblEmpleadoTop.Text = "Empleado con mas ventas: ";
            // 
            // btnCancelarReporte
            // 
            btnCancelarReporte.Image = (Image)resources.GetObject("btnCancelarReporte.Image");
            btnCancelarReporte.Location = new Point(1265, 645);
            btnCancelarReporte.Name = "btnCancelarReporte";
            btnCancelarReporte.Size = new Size(54, 38);
            btnCancelarReporte.SizeMode = PictureBoxSizeMode.Zoom;
            btnCancelarReporte.TabIndex = 65;
            btnCancelarReporte.TabStop = false;
            btnCancelarReporte.Click += btnCancelarReporte_Click;
            // 
            // btnGenerar
            // 
            btnGenerar.Image = (Image)resources.GetObject("btnGenerar.Image");
            btnGenerar.Location = new Point(799, 631);
            btnGenerar.Name = "btnGenerar";
            btnGenerar.Size = new Size(164, 52);
            btnGenerar.SizeMode = PictureBoxSizeMode.StretchImage;
            btnGenerar.TabIndex = 67;
            btnGenerar.TabStop = false;
            btnGenerar.Click += btnGenerar_Click;
            // 
            // lblInfor
            // 
            lblInfor.AutoSize = true;
            lblInfor.Location = new Point(799, 556);
            lblInfor.Name = "lblInfor";
            lblInfor.Size = new Size(172, 19);
            lblInfor.TabIndex = 69;
            lblInfor.Text = "Seleccione una fecha: ";
            // 
            // Reporte_de_ventas
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(1370, 696);
            ControlBox = false;
            Controls.Add(lblInfor);
            Controls.Add(btnGenerar);
            Controls.Add(btnCancelarReporte);
            Controls.Add(lblEmpleadoTop);
            Controls.Add(cbFiltro);
            Controls.Add(lblTotal);
            Controls.Add(pbGrafico);
            Controls.Add(lblMayorVenta);
            Controls.Add(dgvVentas);
            Controls.Add(dtpDesde);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "Reporte_de_ventas";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = " ";
            WindowState = FormWindowState.Maximized;
            Load += Reporte_de_ventas_Load;
            ((System.ComponentModel.ISupportInitialize)dgvVentas).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbGrafico).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnCancelarReporte).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnGenerar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DateTimePicker dtpDesde;
        private DataGridView dgvVentas;
        private Label lblMayorVenta;
        private PictureBox pbGrafico;
        private Label lblTotal;
        private PictureBox pictureBox1;
        private ComboBox cbFiltro;
        private Label lblEmpleadoTop;
        private PictureBox btnCancelarReporte;
        private PictureBox btnGenerar;
        private Label lblInfor;
    }
}