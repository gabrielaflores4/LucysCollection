﻿namespace C_Presentacion
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
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
            btnCancelar = new PictureBox();
            btnEliminarTalla = new Button();
            button1 = new Button();
            btnAgregarTallas = new Button();
            ((System.ComponentModel.ISupportInitialize)nbCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridProductoDet).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnCancelar).BeginInit();
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
            lblDashboard.Location = new Point(616, 16);
            lblDashboard.Name = "lblDashboard";
            lblDashboard.Size = new Size(139, 33);
            lblDashboard.TabIndex = 41;
            lblDashboard.Text = "Productos";
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
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(221, 221, 221);
            dataGridViewCellStyle4.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.Black;
            dataGridProductoDet.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridProductoDet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridProductoDet.BackgroundColor = Color.FromArgb(221, 221, 221);
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = Color.Black;
            dataGridViewCellStyle5.Font = new Font("Bahnschrift", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.Padding = new Padding(1);
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.Control;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dataGridProductoDet.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dataGridProductoDet.ColumnHeadersHeight = 40;
            dataGridProductoDet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridProductoDet.Columns.AddRange(new DataGridViewColumn[] { Id_Prod, talla, stock });
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(221, 221, 221);
            dataGridViewCellStyle6.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Desktop;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dataGridProductoDet.DefaultCellStyle = dataGridViewCellStyle6;
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
            // btnCancelar
            // 
            btnCancelar.Image = (Image)resources.GetObject("btnCancelar.Image");
            btnCancelar.Location = new Point(1297, 651);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(54, 38);
            btnCancelar.SizeMode = PictureBoxSizeMode.Zoom;
            btnCancelar.TabIndex = 102;
            btnCancelar.TabStop = false;
            btnCancelar.Click += btnCancelarDetallePr_Click;
            // 
            // btnEliminarTalla
            // 
            btnEliminarTalla.BackColor = Color.FromArgb(221, 221, 221);
            btnEliminarTalla.BackgroundImage = Properties.Resources.btnEliminarTalla;
            btnEliminarTalla.BackgroundImageLayout = ImageLayout.Zoom;
            btnEliminarTalla.FlatStyle = FlatStyle.Flat;
            btnEliminarTalla.ForeColor = Color.FromArgb(221, 221, 221);
            btnEliminarTalla.Location = new Point(992, 71);
            btnEliminarTalla.Name = "btnEliminarTalla";
            btnEliminarTalla.Size = new Size(195, 74);
            btnEliminarTalla.TabIndex = 103;
            btnEliminarTalla.UseVisualStyleBackColor = false;
            btnEliminarTalla.Click += btnEliminarTalla_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(221, 221, 221);
            button1.BackgroundImageLayout = ImageLayout.Zoom;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.FromArgb(221, 221, 221);
            button1.Location = new Point(773, 71);
            button1.Name = "button1";
            button1.Size = new Size(195, 74);
            button1.TabIndex = 104;
            button1.UseVisualStyleBackColor = false;
            // 
            // btnAgregarTallas
            // 
            btnAgregarTallas.BackColor = Color.FromArgb(221, 221, 221);
            btnAgregarTallas.BackgroundImage = Properties.Resources.btnAgregarTallas;
            btnAgregarTallas.BackgroundImageLayout = ImageLayout.Zoom;
            btnAgregarTallas.FlatStyle = FlatStyle.Flat;
            btnAgregarTallas.ForeColor = Color.FromArgb(221, 221, 221);
            btnAgregarTallas.Location = new Point(782, 71);
            btnAgregarTallas.Name = "btnAgregarTallas";
            btnAgregarTallas.Size = new Size(195, 74);
            btnAgregarTallas.TabIndex = 105;
            btnAgregarTallas.UseVisualStyleBackColor = false;
            btnAgregarTallas.Click += btnAgregarTallas_Click;
            // 
            // EditarProducto
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(221, 221, 221);
            ClientSize = new Size(1370, 696);
            ControlBox = false;
            Controls.Add(btnAgregarTallas);
            Controls.Add(button1);
            Controls.Add(btnEliminarTalla);
            Controls.Add(btnCancelar);
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
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "EditarProducto";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Producto";
            WindowState = FormWindowState.Maximized;
            Load += EditarProducto_Load;
            ((System.ComponentModel.ISupportInitialize)nbCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridProductoDet).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnCancelar).EndInit();
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
        private PictureBox btnCancelar;
        private DataGridViewTextBoxColumn Id_Prod;
        private DataGridViewTextBoxColumn talla;
        private DataGridViewTextBoxColumn stock;
        private Button btnEliminarTalla;
        private Button button1;
        private Button btnAgregarTallas;
    }
}