namespace C_Presentacion
{
    partial class EditarProducto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditarProducto));
            btnCancelarActProd = new Button();
            btnGuardarActProd = new Button();
            label4 = new Label();
            label3 = new Label();
            nbCantidad = new NumericUpDown();
            cbTallasRegAct = new ComboBox();
            cbCategoriaAct = new ComboBox();
            label2 = new Label();
            tbPrecioRegAct = new TextBox();
            label1 = new Label();
            tbNombreProdAct = new TextBox();
            label22 = new Label();
            lblDashboard = new Label();
            pictureBox1 = new PictureBox();
            dataGridProductoDet = new DataGridView();
            Id_Prod = new DataGridViewTextBoxColumn();
            talla = new DataGridViewTextBoxColumn();
            stock = new DataGridViewTextBoxColumn();
            btnEditarProd = new Button();
            lblDetalleProd = new Label();
            btnCancelarDetallePr = new PictureBox();
            btnEliminarTalla = new Button();
            ((System.ComponentModel.ISupportInitialize)nbCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridProductoDet).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnCancelarDetallePr).BeginInit();
            SuspendLayout();
            // 
            // btnCancelarActProd
            // 
            btnCancelarActProd.BackColor = Color.FromArgb(221, 221, 221);
            btnCancelarActProd.BackgroundImage = Properties.Resources.btnCancelar;
            btnCancelarActProd.BackgroundImageLayout = ImageLayout.Zoom;
            btnCancelarActProd.FlatStyle = FlatStyle.Flat;
            btnCancelarActProd.ForeColor = Color.FromArgb(221, 221, 221);
            btnCancelarActProd.Location = new Point(39, 588);
            btnCancelarActProd.Name = "btnCancelarActProd";
            btnCancelarActProd.Size = new Size(187, 64);
            btnCancelarActProd.TabIndex = 56;
            btnCancelarActProd.UseVisualStyleBackColor = false;
            btnCancelarActProd.Click += btnCancelarActProd_Click;
            // 
            // btnGuardarActProd
            // 
            btnGuardarActProd.BackColor = Color.FromArgb(221, 221, 221);
            btnGuardarActProd.BackgroundImage = Properties.Resources.btnGuardar;
            btnGuardarActProd.BackgroundImageLayout = ImageLayout.Zoom;
            btnGuardarActProd.FlatStyle = FlatStyle.Flat;
            btnGuardarActProd.ForeColor = Color.FromArgb(221, 221, 221);
            btnGuardarActProd.Location = new Point(252, 588);
            btnGuardarActProd.Name = "btnGuardarActProd";
            btnGuardarActProd.Size = new Size(194, 64);
            btnGuardarActProd.TabIndex = 55;
            btnGuardarActProd.UseVisualStyleBackColor = false;
            btnGuardarActProd.Click += btnGuardarActProd_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(221, 221, 221);
            label4.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ControlText;
            label4.Location = new Point(276, 444);
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
            label3.Location = new Point(39, 444);
            label3.Name = "label3";
            label3.Size = new Size(55, 25);
            label3.TabIndex = 51;
            label3.Text = "Talla";
            // 
            // nbCantidad
            // 
            nbCantidad.Location = new Point(276, 488);
            nbCantidad.Name = "nbCantidad";
            nbCantidad.Size = new Size(162, 27);
            nbCantidad.TabIndex = 50;
            // 
            // cbTallasRegAct
            // 
            cbTallasRegAct.DropDownHeight = 250;
            cbTallasRegAct.FlatStyle = FlatStyle.Flat;
            cbTallasRegAct.FormattingEnabled = true;
            cbTallasRegAct.IntegralHeight = false;
            cbTallasRegAct.Location = new Point(43, 486);
            cbTallasRegAct.MaxDropDownItems = 10;
            cbTallasRegAct.Name = "cbTallasRegAct";
            cbTallasRegAct.Size = new Size(162, 27);
            cbTallasRegAct.TabIndex = 49;
            // 
            // cbCategoriaAct
            // 
            cbCategoriaAct.DropDownHeight = 100;
            cbCategoriaAct.DropDownWidth = 200;
            cbCategoriaAct.FormattingEnabled = true;
            cbCategoriaAct.IntegralHeight = false;
            cbCategoriaAct.Location = new Point(39, 380);
            cbCategoriaAct.Name = "cbCategoriaAct";
            cbCategoriaAct.Size = new Size(399, 27);
            cbCategoriaAct.TabIndex = 48;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(221, 221, 221);
            label2.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ControlText;
            label2.Location = new Point(39, 341);
            label2.Name = "label2";
            label2.Size = new Size(101, 25);
            label2.TabIndex = 47;
            label2.Text = "Categoria";
            // 
            // tbPrecioRegAct
            // 
            tbPrecioRegAct.Location = new Point(39, 278);
            tbPrecioRegAct.Name = "tbPrecioRegAct";
            tbPrecioRegAct.Size = new Size(399, 27);
            tbPrecioRegAct.TabIndex = 46;
            tbPrecioRegAct.KeyPress += tbPrecioRegAct_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(221, 221, 221);
            label1.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlText;
            label1.Location = new Point(39, 240);
            label1.Name = "label1";
            label1.Size = new Size(150, 25);
            label1.TabIndex = 45;
            label1.Text = "Precio Unitario";
            // 
            // tbNombreProdAct
            // 
            tbNombreProdAct.Location = new Point(39, 184);
            tbNombreProdAct.Name = "tbNombreProdAct";
            tbNombreProdAct.Size = new Size(399, 27);
            tbNombreProdAct.TabIndex = 44;
            tbNombreProdAct.KeyPress += tbNombreProdAct_KeyPress;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.BackColor = Color.FromArgb(221, 221, 221);
            label22.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label22.ForeColor = SystemColors.ControlText;
            label22.Location = new Point(39, 145);
            label22.Name = "label22";
            label22.Size = new Size(87, 25);
            label22.TabIndex = 43;
            label22.Text = "Nombre";
            // 
            // lblDashboard
            // 
            lblDashboard.AutoSize = true;
            lblDashboard.BackColor = Color.Black;
            lblDashboard.Font = new Font("Bahnschrift", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDashboard.ForeColor = SystemColors.Control;
            lblDashboard.Location = new Point(580, 16);
            lblDashboard.Name = "lblDashboard";
            lblDashboard.Size = new Size(245, 33);
            lblDashboard.TabIndex = 41;
            lblDashboard.Text = "Detalles Productos";
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
            // dataGridProductoDet
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(221, 221, 221);
            dataGridViewCellStyle1.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridProductoDet.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridProductoDet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridProductoDet.BackgroundColor = Color.FromArgb(221, 221, 221);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.Black;
            dataGridViewCellStyle2.Font = new Font("Bahnschrift", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.Padding = new Padding(1);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.Control;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridProductoDet.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridProductoDet.ColumnHeadersHeight = 40;
            dataGridProductoDet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridProductoDet.Columns.AddRange(new DataGridViewColumn[] { Id_Prod, talla, stock });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(221, 221, 221);
            dataGridViewCellStyle3.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Desktop;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridProductoDet.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridProductoDet.EnableHeadersVisualStyles = false;
            dataGridProductoDet.GridColor = Color.FromArgb(221, 221, 221);
            dataGridProductoDet.Location = new Point(39, 145);
            dataGridProductoDet.Name = "dataGridProductoDet";
            dataGridProductoDet.RowHeadersVisible = false;
            dataGridProductoDet.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridProductoDet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridProductoDet.Size = new Size(1312, 500);
            dataGridProductoDet.TabIndex = 57;
            dataGridProductoDet.CellDoubleClick += dataGridProductoDet_CellDoubleClick;
            // 
            // Id_Prod
            // 
            Id_Prod.HeaderText = "Id_Prod";
            Id_Prod.Name = "Id_Prod";
            Id_Prod.Visible = false;
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
            // btnEditarProd
            // 
            btnEditarProd.BackColor = Color.FromArgb(221, 221, 221);
            btnEditarProd.BackgroundImage = Properties.Resources.btnEditar;
            btnEditarProd.BackgroundImageLayout = ImageLayout.Zoom;
            btnEditarProd.FlatStyle = FlatStyle.Flat;
            btnEditarProd.ForeColor = Color.FromArgb(221, 221, 221);
            btnEditarProd.Location = new Point(1199, 77);
            btnEditarProd.Name = "btnEditarProd";
            btnEditarProd.Size = new Size(152, 62);
            btnEditarProd.TabIndex = 58;
            btnEditarProd.UseVisualStyleBackColor = false;
            btnEditarProd.Click += btnEditarProd_Click;
            // 
            // lblDetalleProd
            // 
            lblDetalleProd.AutoSize = true;
            lblDetalleProd.Font = new Font("Bahnschrift", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDetalleProd.Location = new Point(39, 91);
            lblDetalleProd.Name = "lblDetalleProd";
            lblDetalleProd.Size = new Size(114, 29);
            lblDetalleProd.TabIndex = 59;
            lblDetalleProd.Text = "Producto:";
            // 
            // btnCancelarDetallePr
            // 
            btnCancelarDetallePr.Image = (Image)resources.GetObject("btnCancelarDetallePr.Image");
            btnCancelarDetallePr.Location = new Point(12, 699);
            btnCancelarDetallePr.Name = "btnCancelarDetallePr";
            btnCancelarDetallePr.Size = new Size(54, 38);
            btnCancelarDetallePr.SizeMode = PictureBoxSizeMode.Zoom;
            btnCancelarDetallePr.TabIndex = 102;
            btnCancelarDetallePr.TabStop = false;
            btnCancelarDetallePr.Click += btnCancelarDetallePr_Click;
            // 
            // btnEliminarTalla
            // 
            btnEliminarTalla.BackColor = Color.FromArgb(221, 221, 221);
            btnEliminarTalla.BackgroundImage = Properties.Resources.btnEliminarTalla;
            btnEliminarTalla.BackgroundImageLayout = ImageLayout.Zoom;
            btnEliminarTalla.FlatStyle = FlatStyle.Flat;
            btnEliminarTalla.ForeColor = Color.FromArgb(221, 221, 221);
            btnEliminarTalla.Location = new Point(983, 71);
            btnEliminarTalla.Name = "btnEliminarTalla";
            btnEliminarTalla.Size = new Size(195, 74);
            btnEliminarTalla.TabIndex = 103;
            btnEliminarTalla.UseVisualStyleBackColor = false;
            btnEliminarTalla.Click += btnEliminarTalla_Click;
            // 
            // EditarProducto
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(221, 221, 221);
            ClientSize = new Size(1370, 749);
            Controls.Add(btnEliminarTalla);
            Controls.Add(btnCancelarDetallePr);
            Controls.Add(lblDetalleProd);
            Controls.Add(btnEditarProd);
            Controls.Add(dataGridProductoDet);
            Controls.Add(btnCancelarActProd);
            Controls.Add(btnGuardarActProd);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(nbCantidad);
            Controls.Add(cbTallasRegAct);
            Controls.Add(cbCategoriaAct);
            Controls.Add(label2);
            Controls.Add(tbPrecioRegAct);
            Controls.Add(label1);
            Controls.Add(tbNombreProdAct);
            Controls.Add(label22);
            Controls.Add(lblDashboard);
            Controls.Add(pictureBox1);
            Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "EditarProducto";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EditarProducto";
            WindowState = FormWindowState.Maximized;
            Load += EditarProducto_Load;
            ((System.ComponentModel.ISupportInitialize)nbCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridProductoDet).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnCancelarDetallePr).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancelarActProd;
        private Button btnGuardarActProd;
        private Label label4;
        private Label label3;
        private NumericUpDown nbCantidad;
        private ComboBox cbTallasRegAct;
        private ComboBox cbCategoriaAct;
        private Label label2;
        private TextBox tbPrecioRegAct;
        private Label label1;
        private TextBox tbNombreProdAct;
        private Label label22;
        private Label lblDashboard;
        private PictureBox pictureBox1;
        private DataGridView dataGridProductoDet;
        private Button btnEditarProd;
        private Label lblDetalleProd;
        private PictureBox btnCancelarDetallePr;
        private DataGridViewTextBoxColumn Id_Prod;
        private DataGridViewTextBoxColumn talla;
        private DataGridViewTextBoxColumn stock;
        private Button btnEliminarTalla;
    }
}