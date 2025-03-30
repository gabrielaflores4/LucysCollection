namespace C_Presentacion
{
    partial class RegProd
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
            pictureBox1 = new PictureBox();
            lblDashboard = new Label();
            dataGridInventarioProducto = new DataGridView();
            producto = new DataGridViewTextBoxColumn();
            talla = new DataGridViewTextBoxColumn();
            stock = new DataGridViewTextBoxColumn();
            categoria = new DataGridViewTextBoxColumn();
            precio = new DataGridViewTextBoxColumn();
            label22 = new Label();
            tbNombreProdReg = new TextBox();
            tbPrecioRegProd = new TextBox();
            label1 = new Label();
            label2 = new Label();
            cbCategoriaReg = new ComboBox();
            cbTallasRegProd = new ComboBox();
            nbCantidad = new NumericUpDown();
            label3 = new Label();
            label4 = new Label();
            btnEliminarRegProd = new Button();
            btnAgregarRegProd = new Button();
            btnGuardarRegProd = new Button();
            btnCancelarRegProd = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridInventarioProducto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nbCantidad).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.rectangulo4;
            pictureBox1.Location = new Point(0, -1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1372, 73);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // lblDashboard
            // 
            lblDashboard.AutoSize = true;
            lblDashboard.BackColor = Color.Black;
            lblDashboard.Font = new Font("Bahnschrift", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDashboard.ForeColor = SystemColors.Control;
            lblDashboard.Location = new Point(581, 17);
            lblDashboard.Name = "lblDashboard";
            lblDashboard.Size = new Size(246, 33);
            lblDashboard.TabIndex = 2;
            lblDashboard.Text = "Registrar Producto";
            // 
            // dataGridInventarioProducto
            // 
            dataGridViewCellStyle4.BackColor = Color.Black;
            dataGridViewCellStyle4.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.White;
            dataGridInventarioProducto.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridInventarioProducto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridInventarioProducto.BackgroundColor = Color.FromArgb(221, 221, 221);
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = Color.Black;
            dataGridViewCellStyle5.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.Padding = new Padding(1);
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Desktop;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dataGridInventarioProducto.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dataGridInventarioProducto.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridInventarioProducto.Columns.AddRange(new DataGridViewColumn[] { producto, talla, stock, categoria, precio });
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(221, 221, 221);
            dataGridViewCellStyle6.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Desktop;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dataGridInventarioProducto.DefaultCellStyle = dataGridViewCellStyle6;
            dataGridInventarioProducto.EnableHeadersVisualStyles = false;
            dataGridInventarioProducto.GridColor = Color.FromArgb(221, 221, 221);
            dataGridInventarioProducto.Location = new Point(406, 93);
            dataGridInventarioProducto.Name = "dataGridInventarioProducto";
            dataGridInventarioProducto.RowHeadersVisible = false;
            dataGridInventarioProducto.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridInventarioProducto.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridInventarioProducto.Size = new Size(941, 488);
            dataGridInventarioProducto.TabIndex = 25;
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
            // stock
            // 
            stock.HeaderText = "Stock";
            stock.Name = "stock";
            // 
            // categoria
            // 
            categoria.HeaderText = "Categoria";
            categoria.Name = "categoria";
            // 
            // precio
            // 
            precio.HeaderText = "Precio Unit";
            precio.Name = "precio";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.BackColor = Color.FromArgb(221, 221, 221);
            label22.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label22.ForeColor = SystemColors.ControlText;
            label22.Location = new Point(28, 108);
            label22.Name = "label22";
            label22.Size = new Size(87, 25);
            label22.TabIndex = 26;
            label22.Text = "Nombre";
            // 
            // tbNombreProdReg
            // 
            tbNombreProdReg.Location = new Point(33, 145);
            tbNombreProdReg.Name = "tbNombreProdReg";
            tbNombreProdReg.Size = new Size(347, 27);
            tbNombreProdReg.TabIndex = 27;
            // 
            // tbPrecioRegProd
            // 
            tbPrecioRegProd.Location = new Point(33, 239);
            tbPrecioRegProd.Name = "tbPrecioRegProd";
            tbPrecioRegProd.Size = new Size(347, 27);
            tbPrecioRegProd.TabIndex = 29;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(221, 221, 221);
            label1.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlText;
            label1.Location = new Point(28, 202);
            label1.Name = "label1";
            label1.Size = new Size(150, 25);
            label1.TabIndex = 28;
            label1.Text = "Precio Unitario";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(221, 221, 221);
            label2.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ControlText;
            label2.Location = new Point(28, 298);
            label2.Name = "label2";
            label2.Size = new Size(101, 25);
            label2.TabIndex = 30;
            label2.Text = "Categoria";
            // 
            // cbCategoriaReg
            // 
            cbCategoriaReg.FormattingEnabled = true;
            cbCategoriaReg.Location = new Point(33, 341);
            cbCategoriaReg.Name = "cbCategoriaReg";
            cbCategoriaReg.Size = new Size(347, 27);
            cbCategoriaReg.TabIndex = 31;
            // 
            // cbTallasRegProd
            // 
            cbTallasRegProd.FormattingEnabled = true;
            cbTallasRegProd.Location = new Point(33, 448);
            cbTallasRegProd.Name = "cbTallasRegProd";
            cbTallasRegProd.Size = new Size(162, 27);
            cbTallasRegProd.TabIndex = 32;
            // 
            // nbCantidad
            // 
            nbCantidad.Location = new Point(218, 449);
            nbCantidad.Name = "nbCantidad";
            nbCantidad.Size = new Size(162, 27);
            nbCantidad.TabIndex = 33;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(221, 221, 221);
            label3.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ControlText;
            label3.Location = new Point(29, 406);
            label3.Name = "label3";
            label3.Size = new Size(55, 25);
            label3.TabIndex = 34;
            label3.Text = "Talla";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(221, 221, 221);
            label4.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ControlText;
            label4.Location = new Point(218, 405);
            label4.Name = "label4";
            label4.Size = new Size(93, 25);
            label4.TabIndex = 35;
            label4.Text = "Cantidad";
            // 
            // btnEliminarRegProd
            // 
            btnEliminarRegProd.BackColor = Color.FromArgb(221, 221, 221);
            btnEliminarRegProd.BackgroundImage = Properties.Resources.btnEliminar;
            btnEliminarRegProd.BackgroundImageLayout = ImageLayout.Zoom;
            btnEliminarRegProd.FlatStyle = FlatStyle.Flat;
            btnEliminarRegProd.ForeColor = Color.FromArgb(221, 221, 221);
            btnEliminarRegProd.Location = new Point(29, 506);
            btnEliminarRegProd.Name = "btnEliminarRegProd";
            btnEliminarRegProd.Size = new Size(161, 64);
            btnEliminarRegProd.TabIndex = 37;
            btnEliminarRegProd.UseVisualStyleBackColor = false;
            // 
            // btnAgregarRegProd
            // 
            btnAgregarRegProd.BackColor = Color.FromArgb(221, 221, 221);
            btnAgregarRegProd.BackgroundImage = Properties.Resources.btnAgregar;
            btnAgregarRegProd.BackgroundImageLayout = ImageLayout.Zoom;
            btnAgregarRegProd.FlatStyle = FlatStyle.Flat;
            btnAgregarRegProd.ForeColor = Color.FromArgb(221, 221, 221);
            btnAgregarRegProd.Location = new Point(218, 506);
            btnAgregarRegProd.Name = "btnAgregarRegProd";
            btnAgregarRegProd.Size = new Size(162, 64);
            btnAgregarRegProd.TabIndex = 36;
            btnAgregarRegProd.UseVisualStyleBackColor = false;
            // 
            // btnGuardarRegProd
            // 
            btnGuardarRegProd.BackColor = Color.FromArgb(221, 221, 221);
            btnGuardarRegProd.BackgroundImage = Properties.Resources.btnGuardar;
            btnGuardarRegProd.BackgroundImageLayout = ImageLayout.Zoom;
            btnGuardarRegProd.FlatStyle = FlatStyle.Flat;
            btnGuardarRegProd.ForeColor = Color.FromArgb(221, 221, 221);
            btnGuardarRegProd.Location = new Point(1161, 612);
            btnGuardarRegProd.Name = "btnGuardarRegProd";
            btnGuardarRegProd.Size = new Size(186, 64);
            btnGuardarRegProd.TabIndex = 38;
            btnGuardarRegProd.UseVisualStyleBackColor = false;
            // 
            // btnCancelarRegProd
            // 
            btnCancelarRegProd.BackColor = Color.FromArgb(221, 221, 221);
            btnCancelarRegProd.BackgroundImage = Properties.Resources.btnCancelar;
            btnCancelarRegProd.BackgroundImageLayout = ImageLayout.Zoom;
            btnCancelarRegProd.FlatStyle = FlatStyle.Flat;
            btnCancelarRegProd.ForeColor = Color.FromArgb(221, 221, 221);
            btnCancelarRegProd.Location = new Point(948, 612);
            btnCancelarRegProd.Name = "btnCancelarRegProd";
            btnCancelarRegProd.Size = new Size(187, 64);
            btnCancelarRegProd.TabIndex = 39;
            btnCancelarRegProd.UseVisualStyleBackColor = false;
            // 
            // RegProd
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(221, 221, 221);
            ClientSize = new Size(1370, 696);
            Controls.Add(btnCancelarRegProd);
            Controls.Add(btnGuardarRegProd);
            Controls.Add(btnEliminarRegProd);
            Controls.Add(btnAgregarRegProd);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(nbCantidad);
            Controls.Add(cbTallasRegProd);
            Controls.Add(cbCategoriaReg);
            Controls.Add(label2);
            Controls.Add(tbPrecioRegProd);
            Controls.Add(label1);
            Controls.Add(tbNombreProdReg);
            Controls.Add(label22);
            Controls.Add(dataGridInventarioProducto);
            Controls.Add(lblDashboard);
            Controls.Add(pictureBox1);
            Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "RegProd";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RegProd";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridInventarioProducto).EndInit();
            ((System.ComponentModel.ISupportInitialize)nbCantidad).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label lblDashboard;
        private DataGridView dataGridInventarioProducto;
        private DataGridViewTextBoxColumn producto;
        private DataGridViewTextBoxColumn talla;
        private DataGridViewTextBoxColumn stock;
        private DataGridViewTextBoxColumn categoria;
        private DataGridViewTextBoxColumn precio;
        private Label label22;
        private TextBox tbNombreProdReg;
        private TextBox tbPrecioRegProd;
        private Label label1;
        private Label label2;
        private ComboBox cbCategoriaReg;
        private ComboBox cbTallasRegProd;
        private NumericUpDown nbCantidad;
        private Label label3;
        private Label label4;
        private Button btnEliminarRegProd;
        private Button btnAgregarRegProd;
        private Button btnGuardarRegProd;
        private Button btnCancelarRegProd;
    }
}