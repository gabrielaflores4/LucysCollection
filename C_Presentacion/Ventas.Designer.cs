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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ventas));
            btnCancelarRegProd = new Button();
            btnGuardarRegProd = new Button();
            btnEliminarRegProd = new Button();
            btnAgregarRegProd = new Button();
            label4 = new Label();
            label3 = new Label();
            nbCantidad = new NumericUpDown();
            cbTallasRegProd = new ComboBox();
            label22 = new Label();
            dataGridVentaProducto = new DataGridView();
            id_prod = new DataGridViewTextBoxColumn();
            producto = new DataGridViewTextBoxColumn();
            talla = new DataGridViewTextBoxColumn();
            cantidad = new DataGridViewTextBoxColumn();
            precioUnit = new DataGridViewTextBoxColumn();
            subtotal = new DataGridViewTextBoxColumn();
            lblDashboard = new Label();
            pictureBox1 = new PictureBox();
            lblTotalVenta = new Label();
            cbProductos = new ComboBox();
            label1 = new Label();
            rbCliNuevo = new RadioButton();
            rbCliAntiguo = new RadioButton();
            lblStockDisponible = new Label();
            printPreviewDialogo = new PrintPreviewDialog();
            btnTodosProductos = new Button();
            tbClientes = new TextBox();
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
            btnCancelarRegProd.TabIndex = 18;
            btnCancelarRegProd.UseVisualStyleBackColor = false;
            btnCancelarRegProd.Click += btnCancelarRegProd_Click;
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
            btnGuardarRegProd.TabIndex = 17;
            btnGuardarRegProd.UseVisualStyleBackColor = false;
            btnGuardarRegProd.Click += btnGuardarRegProd_Click;
            // 
            // btnEliminarRegProd
            // 
            btnEliminarRegProd.BackColor = Color.FromArgb(221, 221, 221);
            btnEliminarRegProd.BackgroundImage = Properties.Resources.btnEliminar;
            btnEliminarRegProd.BackgroundImageLayout = ImageLayout.Zoom;
            btnEliminarRegProd.FlatStyle = FlatStyle.Flat;
            btnEliminarRegProd.ForeColor = Color.FromArgb(221, 221, 221);
            btnEliminarRegProd.Location = new Point(24, 344);
            btnEliminarRegProd.Name = "btnEliminarRegProd";
            btnEliminarRegProd.Size = new Size(161, 64);
            btnEliminarRegProd.TabIndex = 10;
            btnEliminarRegProd.UseVisualStyleBackColor = false;
            btnEliminarRegProd.Click += btnEliminarRegProd_Click;
            // 
            // btnAgregarRegProd
            // 
            btnAgregarRegProd.BackColor = Color.FromArgb(221, 221, 221);
            btnAgregarRegProd.BackgroundImage = Properties.Resources.btnAgregar;
            btnAgregarRegProd.BackgroundImageLayout = ImageLayout.Zoom;
            btnAgregarRegProd.FlatStyle = FlatStyle.Flat;
            btnAgregarRegProd.ForeColor = Color.FromArgb(221, 221, 221);
            btnAgregarRegProd.Location = new Point(213, 344);
            btnAgregarRegProd.Name = "btnAgregarRegProd";
            btnAgregarRegProd.Size = new Size(162, 64);
            btnAgregarRegProd.TabIndex = 9;
            btnAgregarRegProd.UseVisualStyleBackColor = false;
            btnAgregarRegProd.Click += btnAgregarRegProd_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(221, 221, 221);
            label4.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ControlText;
            label4.Location = new Point(213, 243);
            label4.Name = "label4";
            label4.Size = new Size(93, 25);
            label4.TabIndex = 7;
            label4.Text = "Cantidad";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(221, 221, 221);
            label3.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ControlText;
            label3.Location = new Point(24, 244);
            label3.Name = "label3";
            label3.Size = new Size(55, 25);
            label3.TabIndex = 5;
            label3.Text = "Talla";
            // 
            // nbCantidad
            // 
            nbCantidad.Location = new Point(213, 287);
            nbCantidad.Name = "nbCantidad";
            nbCantidad.Size = new Size(162, 27);
            nbCantidad.TabIndex = 8;
            // 
            // cbTallasRegProd
            // 
            cbTallasRegProd.FormattingEnabled = true;
            cbTallasRegProd.Items.AddRange(new object[] { "5", "6", "7", "8", "9" });
            cbTallasRegProd.Location = new Point(28, 286);
            cbTallasRegProd.Name = "cbTallasRegProd";
            cbTallasRegProd.Size = new Size(162, 27);
            cbTallasRegProd.TabIndex = 6;
            cbTallasRegProd.SelectedIndexChanged += cbTallasRegProd_SelectedIndexChanged;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.BackColor = Color.FromArgb(221, 221, 221);
            label22.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label22.ForeColor = SystemColors.ControlText;
            label22.Location = new Point(24, 92);
            label22.Name = "label22";
            label22.Size = new Size(87, 25);
            label22.TabIndex = 1;
            label22.Text = "Nombre";
            // 
            // dataGridVentaProducto
            // 
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(221, 221, 221);
            dataGridViewCellStyle4.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.Black;
            dataGridVentaProducto.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridVentaProducto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridVentaProducto.BackgroundColor = Color.FromArgb(221, 221, 221);
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = Color.Black;
            dataGridViewCellStyle5.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.Padding = new Padding(1);
            dataGridViewCellStyle5.SelectionBackColor = Color.Black;
            dataGridViewCellStyle5.SelectionForeColor = Color.White;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dataGridVentaProducto.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dataGridVentaProducto.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridVentaProducto.Columns.AddRange(new DataGridViewColumn[] { id_prod, producto, talla, cantidad, precioUnit, subtotal });
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(221, 221, 221);
            dataGridViewCellStyle6.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Desktop;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dataGridVentaProducto.DefaultCellStyle = dataGridViewCellStyle6;
            dataGridVentaProducto.EnableHeadersVisualStyles = false;
            dataGridVentaProducto.GridColor = Color.FromArgb(221, 221, 221);
            dataGridVentaProducto.Location = new Point(405, 92);
            dataGridVentaProducto.MultiSelect = false;
            dataGridVentaProducto.Name = "dataGridVentaProducto";
            dataGridVentaProducto.RowHeadersVisible = false;
            dataGridVentaProducto.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridVentaProducto.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridVentaProducto.Size = new Size(941, 422);
            dataGridVentaProducto.TabIndex = 15;
            // 
            // id_prod
            // 
            id_prod.HeaderText = "ID";
            id_prod.Name = "id_prod";
            id_prod.Visible = false;
            // 
            // producto
            // 
            producto.HeaderText = "Producto";
            producto.Name = "producto";
            // 
            // talla
            // 
            talla.HeaderText = "Talla";
            talla.Name = "talla";
            // 
            // cantidad
            // 
            cantidad.HeaderText = "Cantidad";
            cantidad.Name = "cantidad";
            // 
            // precioUnit
            // 
            precioUnit.HeaderText = "Precio Unit";
            precioUnit.Name = "precioUnit";
            // 
            // subtotal
            // 
            subtotal.HeaderText = "SubTotal";
            subtotal.Name = "subtotal";
            // 
            // lblDashboard
            // 
            lblDashboard.AutoSize = true;
            lblDashboard.BackColor = Color.Black;
            lblDashboard.Font = new Font("Bahnschrift", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDashboard.ForeColor = SystemColors.Control;
            lblDashboard.Location = new Point(637, 16);
            lblDashboard.Name = "lblDashboard";
            lblDashboard.Size = new Size(96, 33);
            lblDashboard.TabIndex = 0;
            lblDashboard.Text = "Ventas";
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
            // lblTotalVenta
            // 
            lblTotalVenta.AutoSize = true;
            lblTotalVenta.BackColor = Color.FromArgb(221, 221, 221);
            lblTotalVenta.Font = new Font("Bahnschrift SemiBold", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalVenta.ForeColor = SystemColors.ControlText;
            lblTotalVenta.Location = new Point(947, 534);
            lblTotalVenta.Name = "lblTotalVenta";
            lblTotalVenta.Size = new Size(116, 33);
            lblTotalVenta.TabIndex = 16;
            lblTotalVenta.Text = "Total: $0";
            // 
            // cbProductos
            // 
            cbProductos.FormattingEnabled = true;
            cbProductos.Location = new Point(29, 187);
            cbProductos.Name = "cbProductos";
            cbProductos.Size = new Size(347, 27);
            cbProductos.TabIndex = 4;
            cbProductos.SelectedIndexChanged += cbProductos_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(221, 221, 221);
            label1.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlText;
            label1.Location = new Point(24, 439);
            label1.Name = "label1";
            label1.Size = new Size(77, 25);
            label1.TabIndex = 11;
            label1.Text = "Cliente";
            // 
            // rbCliNuevo
            // 
            rbCliNuevo.AutoSize = true;
            rbCliNuevo.Font = new Font("Bahnschrift", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rbCliNuevo.Location = new Point(29, 487);
            rbCliNuevo.Name = "rbCliNuevo";
            rbCliNuevo.Size = new Size(82, 27);
            rbCliNuevo.TabIndex = 12;
            rbCliNuevo.TabStop = true;
            rbCliNuevo.Text = "Nuevo";
            rbCliNuevo.UseVisualStyleBackColor = true;
            rbCliNuevo.CheckedChanged += rbCliNuevo_CheckedChanged;
            // 
            // rbCliAntiguo
            // 
            rbCliAntiguo.AutoSize = true;
            rbCliAntiguo.Font = new Font("Bahnschrift", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rbCliAntiguo.Location = new Point(213, 487);
            rbCliAntiguo.Name = "rbCliAntiguo";
            rbCliAntiguo.Size = new Size(93, 27);
            rbCliAntiguo.TabIndex = 13;
            rbCliAntiguo.TabStop = true;
            rbCliAntiguo.Text = "Antiguo";
            rbCliAntiguo.UseVisualStyleBackColor = true;
            rbCliAntiguo.CheckedChanged += rbCliAntiguo_CheckedChanged;
            // 
            // lblStockDisponible
            // 
            lblStockDisponible.AutoSize = true;
            lblStockDisponible.BackColor = Color.FromArgb(221, 221, 221);
            lblStockDisponible.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStockDisponible.ForeColor = Color.Red;
            lblStockDisponible.Location = new Point(24, 139);
            lblStockDisponible.Name = "lblStockDisponible";
            lblStockDisponible.Size = new Size(87, 25);
            lblStockDisponible.TabIndex = 2;
            lblStockDisponible.Text = "Stock: 0";
            // 
            // printPreviewDialogo
            // 
            printPreviewDialogo.AutoScrollMargin = new Size(0, 0);
            printPreviewDialogo.AutoScrollMinSize = new Size(0, 0);
            printPreviewDialogo.ClientSize = new Size(400, 300);
            printPreviewDialogo.Enabled = true;
            printPreviewDialogo.Icon = (Icon)resources.GetObject("printPreviewDialogo.Icon");
            printPreviewDialogo.Name = "printPreviewDialogo";
            printPreviewDialogo.Visible = false;
            // 
            // btnTodosProductos
            // 
            btnTodosProductos.BackColor = Color.FromArgb(221, 221, 221);
            btnTodosProductos.BackgroundImage = Properties.Resources.btnTodosLosProductos;
            btnTodosProductos.BackgroundImageLayout = ImageLayout.Zoom;
            btnTodosProductos.FlatStyle = FlatStyle.Flat;
            btnTodosProductos.ForeColor = Color.FromArgb(221, 221, 221);
            btnTodosProductos.Location = new Point(173, 134);
            btnTodosProductos.Name = "btnTodosProductos";
            btnTodosProductos.Size = new Size(212, 40);
            btnTodosProductos.TabIndex = 3;
            btnTodosProductos.UseVisualStyleBackColor = false;
            btnTodosProductos.Click += btnTodosProductos_Click;
            // 
            // tbClientes
            // 
            tbClientes.Location = new Point(29, 555);
            tbClientes.Name = "tbClientes";
            tbClientes.ReadOnly = true;
            tbClientes.Size = new Size(346, 27);
            tbClientes.TabIndex = 14;
            // 
            // Ventas
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(221, 221, 221);
            ClientSize = new Size(1370, 696);
            Controls.Add(tbClientes);
            Controls.Add(btnTodosProductos);
            Controls.Add(lblStockDisponible);
            Controls.Add(rbCliAntiguo);
            Controls.Add(rbCliNuevo);
            Controls.Add(label1);
            Controls.Add(cbProductos);
            Controls.Add(lblTotalVenta);
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
            Icon = (Icon)resources.GetObject("$this.Icon");
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
        private DataGridView dataGridVentaProducto;
        private Label lblDashboard;
        private PictureBox pictureBox1;
        private Label lblTotalVenta;
        private ComboBox cbProductos;
        private Label label1;
        private RadioButton rbCliNuevo;
        private RadioButton rbCliAntiguo;
        private Label lblStockDisponible;
        private PrintPreviewDialog printPreviewDialogo;
        private Button btnTodosProductos;
        private DataGridViewTextBoxColumn id_prod;
        private DataGridViewTextBoxColumn producto;
        private DataGridViewTextBoxColumn talla;
        private DataGridViewTextBoxColumn cantidad;
        private DataGridViewTextBoxColumn precioUnit;
        private DataGridViewTextBoxColumn subtotal;
        private TextBox tbClientes;
    }
}