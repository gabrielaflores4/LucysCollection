namespace C_Presentacion
{
    partial class Ventas
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
            btnCancelarRegProd = new Button();
            btnGuardarRegProd = new Button();
            btnEliminarRegProd = new Button();
            btnAgregarRegProd = new Button();
            label4 = new Label();
            label3 = new Label();
            nbCantidad = new NumericUpDown();
            cbTallasRegProd = new ComboBox();
            label22 = new Label();
            precio = new DataGridViewTextBoxColumn();
            categoria = new DataGridViewTextBoxColumn();
            stock = new DataGridViewTextBoxColumn();
            talla = new DataGridViewTextBoxColumn();
            producto = new DataGridViewTextBoxColumn();
            dataGridVentaProducto = new DataGridView();
            lblDashboard = new Label();
            pictureBox1 = new PictureBox();
            label5 = new Label();
            lblTotalVenta = new Label();
            cbProductos = new ComboBox();
            label1 = new Label();
            rbCliNuevo = new RadioButton();
            rbCliAntiguo = new RadioButton();
            btnFacturaVenta = new Button();
            ((System.ComponentModel.ISupportInitialize)nbCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridVentaProducto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnCancelarRegProd
            // 
            btnCancelarRegProd.BackColor = Color.FromArgb(221, 221, 221);
            btnCancelarRegProd.BackgroundImage = Properties.Resources.btnCancelar;
            btnCancelarRegProd.BackgroundImageLayout = ImageLayout.Zoom;
            btnCancelarRegProd.FlatStyle = FlatStyle.Flat;
            btnCancelarRegProd.ForeColor = Color.FromArgb(221, 221, 221);
            btnCancelarRegProd.Location = new Point(947, 611);
            btnCancelarRegProd.Name = "btnCancelarRegProd";
            btnCancelarRegProd.Size = new Size(187, 64);
            btnCancelarRegProd.TabIndex = 56;
            btnCancelarRegProd.UseVisualStyleBackColor = false;
            // 
            // btnGuardarRegProd
            // 
            btnGuardarRegProd.BackColor = Color.FromArgb(221, 221, 221);
            btnGuardarRegProd.BackgroundImage = Properties.Resources.btnGuardar;
            btnGuardarRegProd.BackgroundImageLayout = ImageLayout.Zoom;
            btnGuardarRegProd.FlatStyle = FlatStyle.Flat;
            btnGuardarRegProd.ForeColor = Color.FromArgb(221, 221, 221);
            btnGuardarRegProd.Location = new Point(1160, 611);
            btnGuardarRegProd.Name = "btnGuardarRegProd";
            btnGuardarRegProd.Size = new Size(186, 64);
            btnGuardarRegProd.TabIndex = 55;
            btnGuardarRegProd.UseVisualStyleBackColor = false;
            // 
            // btnEliminarRegProd
            // 
            btnEliminarRegProd.BackColor = Color.FromArgb(221, 221, 221);
            btnEliminarRegProd.BackgroundImage = Properties.Resources.btnEliminar;
            btnEliminarRegProd.BackgroundImageLayout = ImageLayout.Zoom;
            btnEliminarRegProd.FlatStyle = FlatStyle.Flat;
            btnEliminarRegProd.ForeColor = Color.FromArgb(221, 221, 221);
            btnEliminarRegProd.Location = new Point(24, 309);
            btnEliminarRegProd.Name = "btnEliminarRegProd";
            btnEliminarRegProd.Size = new Size(161, 64);
            btnEliminarRegProd.TabIndex = 54;
            btnEliminarRegProd.UseVisualStyleBackColor = false;
            // 
            // btnAgregarRegProd
            // 
            btnAgregarRegProd.BackColor = Color.FromArgb(221, 221, 221);
            btnAgregarRegProd.BackgroundImage = Properties.Resources.btnAgregar;
            btnAgregarRegProd.BackgroundImageLayout = ImageLayout.Zoom;
            btnAgregarRegProd.FlatStyle = FlatStyle.Flat;
            btnAgregarRegProd.ForeColor = Color.FromArgb(221, 221, 221);
            btnAgregarRegProd.Location = new Point(213, 309);
            btnAgregarRegProd.Name = "btnAgregarRegProd";
            btnAgregarRegProd.Size = new Size(162, 64);
            btnAgregarRegProd.TabIndex = 53;
            btnAgregarRegProd.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(221, 221, 221);
            label4.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ControlText;
            label4.Location = new Point(213, 208);
            label4.Name = "label4";
            label4.Size = new Size(93, 25);
            label4.TabIndex = 52;
            label4.Text = "Cantidad";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(221, 221, 221);
            label3.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ControlText;
            label3.Location = new Point(24, 209);
            label3.Name = "label3";
            label3.Size = new Size(55, 25);
            label3.TabIndex = 51;
            label3.Text = "Talla";
            // 
            // nbCantidad
            // 
            nbCantidad.Location = new Point(213, 252);
            nbCantidad.Name = "nbCantidad";
            nbCantidad.Size = new Size(162, 27);
            nbCantidad.TabIndex = 50;
            // 
            // cbTallasRegProd
            // 
            cbTallasRegProd.FormattingEnabled = true;
            cbTallasRegProd.Location = new Point(28, 251);
            cbTallasRegProd.Name = "cbTallasRegProd";
            cbTallasRegProd.Size = new Size(162, 27);
            cbTallasRegProd.TabIndex = 49;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.BackColor = Color.FromArgb(221, 221, 221);
            label22.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label22.ForeColor = SystemColors.ControlText;
            label22.Location = new Point(24, 107);
            label22.Name = "label22";
            label22.Size = new Size(87, 25);
            label22.TabIndex = 43;
            label22.Text = "Nombre";
            // 
            // precio
            // 
            precio.HeaderText = "Precio Unit";
            precio.Name = "precio";
            // 
            // categoria
            // 
            categoria.HeaderText = "Categoria";
            categoria.Name = "categoria";
            // 
            // stock
            // 
            stock.HeaderText = "Stock";
            stock.Name = "stock";
            // 
            // talla
            // 
            talla.HeaderText = "Talla";
            talla.Name = "talla";
            // 
            // producto
            // 
            producto.HeaderText = "Producto";
            producto.Name = "producto";
            // 
            // dataGridVentaProducto
            // 
            dataGridViewCellStyle1.BackColor = Color.Black;
            dataGridViewCellStyle1.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridVentaProducto.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridVentaProducto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridVentaProducto.BackgroundColor = Color.FromArgb(221, 221, 221);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.Black;
            dataGridViewCellStyle2.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.Padding = new Padding(1);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Desktop;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridVentaProducto.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridVentaProducto.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridVentaProducto.Columns.AddRange(new DataGridViewColumn[] { producto, talla, stock, categoria, precio });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(221, 221, 221);
            dataGridViewCellStyle3.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Desktop;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridVentaProducto.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridVentaProducto.EnableHeadersVisualStyles = false;
            dataGridVentaProducto.GridColor = Color.FromArgb(221, 221, 221);
            dataGridVentaProducto.Location = new Point(405, 92);
            dataGridVentaProducto.Name = "dataGridVentaProducto";
            dataGridVentaProducto.RowHeadersVisible = false;
            dataGridVentaProducto.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridVentaProducto.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridVentaProducto.Size = new Size(941, 382);
            dataGridVentaProducto.TabIndex = 42;
            // 
            // lblDashboard
            // 
            lblDashboard.AutoSize = true;
            lblDashboard.BackColor = Color.Black;
            lblDashboard.Font = new Font("Bahnschrift", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDashboard.ForeColor = SystemColors.Control;
            lblDashboard.Location = new Point(632, 16);
            lblDashboard.Name = "lblDashboard";
            lblDashboard.Size = new Size(96, 33);
            lblDashboard.TabIndex = 41;
            lblDashboard.Text = "Ventas";
            lblDashboard.Click += lblDashboard_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.rectangulo4;
            pictureBox1.Location = new Point(-1, -2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1372, 73);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 40;
            pictureBox1.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.FromArgb(221, 221, 221);
            label5.Font = new Font("Bahnschrift SemiBold", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ControlText;
            label5.Location = new Point(1145, 536);
            label5.Name = "label5";
            label5.Size = new Size(118, 33);
            label5.TabIndex = 57;
            label5.Text = "TOTAL: $";
            // 
            // lblTotalVenta
            // 
            lblTotalVenta.AutoSize = true;
            lblTotalVenta.BackColor = Color.FromArgb(221, 221, 221);
            lblTotalVenta.Font = new Font("Bahnschrift SemiBold", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalVenta.ForeColor = SystemColors.ControlText;
            lblTotalVenta.Location = new Point(1253, 536);
            lblTotalVenta.Name = "lblTotalVenta";
            lblTotalVenta.Size = new Size(30, 33);
            lblTotalVenta.TabIndex = 58;
            lblTotalVenta.Text = "0";
            // 
            // cbProductos
            // 
            cbProductos.FormattingEnabled = true;
            cbProductos.Location = new Point(29, 146);
            cbProductos.Name = "cbProductos";
            cbProductos.Size = new Size(347, 27);
            cbProductos.TabIndex = 59;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(221, 221, 221);
            label1.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlText;
            label1.Location = new Point(24, 425);
            label1.Name = "label1";
            label1.Size = new Size(77, 25);
            label1.TabIndex = 60;
            label1.Text = "Cliente";
            // 
            // rbCliNuevo
            // 
            rbCliNuevo.AutoSize = true;
            rbCliNuevo.Font = new Font("Bahnschrift", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rbCliNuevo.Location = new Point(29, 473);
            rbCliNuevo.Name = "rbCliNuevo";
            rbCliNuevo.Size = new Size(82, 27);
            rbCliNuevo.TabIndex = 61;
            rbCliNuevo.TabStop = true;
            rbCliNuevo.Text = "Nuevo";
            rbCliNuevo.UseVisualStyleBackColor = true;
            rbCliNuevo.CheckedChanged += rbCliNuevo_CheckedChanged;
            // 
            // rbCliAntiguo
            // 
            rbCliAntiguo.AutoSize = true;
            rbCliAntiguo.Font = new Font("Bahnschrift", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rbCliAntiguo.Location = new Point(213, 473);
            rbCliAntiguo.Name = "rbCliAntiguo";
            rbCliAntiguo.Size = new Size(93, 27);
            rbCliAntiguo.TabIndex = 62;
            rbCliAntiguo.TabStop = true;
            rbCliAntiguo.Text = "Antiguo";
            rbCliAntiguo.UseVisualStyleBackColor = true;
            rbCliAntiguo.CheckedChanged += rbCliAntiguo_CheckedChanged;
            // 
            // btnFacturaVenta
            // 
            btnFacturaVenta.BackColor = Color.FromArgb(221, 221, 221);
            btnFacturaVenta.BackgroundImage = Properties.Resources.btnFactura;
            btnFacturaVenta.BackgroundImageLayout = ImageLayout.Zoom;
            btnFacturaVenta.FlatStyle = FlatStyle.Flat;
            btnFacturaVenta.ForeColor = Color.FromArgb(221, 221, 221);
            btnFacturaVenta.Location = new Point(29, 611);
            btnFacturaVenta.Name = "btnFacturaVenta";
            btnFacturaVenta.Size = new Size(187, 64);
            btnFacturaVenta.TabIndex = 63;
            btnFacturaVenta.UseVisualStyleBackColor = false;
            // 
            // Ventas
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(221, 221, 221);
            ClientSize = new Size(1370, 696);
            Controls.Add(btnFacturaVenta);
            Controls.Add(rbCliAntiguo);
            Controls.Add(rbCliNuevo);
            Controls.Add(label1);
            Controls.Add(cbProductos);
            Controls.Add(lblTotalVenta);
            Controls.Add(label5);
            Controls.Add(btnCancelarRegProd);
            Controls.Add(btnGuardarRegProd);
            Controls.Add(btnEliminarRegProd);
            Controls.Add(btnAgregarRegProd);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(nbCantidad);
            Controls.Add(cbTallasRegProd);
            Controls.Add(label22);
            Controls.Add(dataGridVentaProducto);
            Controls.Add(lblDashboard);
            Controls.Add(pictureBox1);
            Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "Ventas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ventas";
            WindowState = FormWindowState.Maximized;
            Load += Ventas_Load;
            ((System.ComponentModel.ISupportInitialize)nbCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridVentaProducto).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancelarRegProd;
        private Button btnGuardarRegProd;
        private Button btnEliminarRegProd;
        private Button btnAgregarRegProd;
        private Label label4;
        private Label label3;
        private NumericUpDown nbCantidad;
        private ComboBox cbTallasRegProd;
        private Label label22;
        private DataGridViewTextBoxColumn precio;
        private DataGridViewTextBoxColumn categoria;
        private DataGridViewTextBoxColumn stock;
        private DataGridViewTextBoxColumn talla;
        private DataGridViewTextBoxColumn producto;
        private DataGridView dataGridVentaProducto;
        private Label lblDashboard;
        private PictureBox pictureBox1;
        private Label label5;
        private Label lblTotalVenta;
        private ComboBox cbProductos;
        private Label label1;
        private RadioButton rbCliNuevo;
        private RadioButton rbCliAntiguo;
        private Button btnFacturaVenta;
    }
}