namespace C_Presentacion
{
    partial class VistaProductos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VistaProductos));
            lblDashboard = new Label();
            pictureBox1 = new PictureBox();
            dataGridProductos = new DataGridView();
            Id_Prod = new DataGridViewTextBoxColumn();
            producto = new DataGridViewTextBoxColumn();
            categoria = new DataGridViewTextBoxColumn();
            precio = new DataGridViewTextBoxColumn();
            pictureBox9 = new PictureBox();
            tbBusquedaProductos = new TextBox();
            btnCancelarAyuda = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridProductos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnCancelarAyuda).BeginInit();
            SuspendLayout();
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
            lblDashboard.TabIndex = 0;
            lblDashboard.Text = "Productos";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.rectangulo4;
            pictureBox1.Location = new Point(-1, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1372, 73);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 44;
            pictureBox1.TabStop = false;
            // 
            // dataGridProductos
            // 
            dataGridViewCellStyle1.BackColor = Color.FromArgb(221, 221, 221);
            dataGridViewCellStyle1.Font = new Font("Bahnschrift", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridProductos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridProductos.BackgroundColor = Color.FromArgb(221, 221, 221);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.Black;
            dataGridViewCellStyle2.Font = new Font("Bahnschrift", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.Padding = new Padding(1);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.Control;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridProductos.ColumnHeadersHeight = 40;
            dataGridProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridProductos.Columns.AddRange(new DataGridViewColumn[] { Id_Prod, producto, categoria, precio });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(221, 221, 221);
            dataGridViewCellStyle3.Font = new Font("Bahnschrift", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Desktop;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridProductos.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridProductos.EnableHeadersVisualStyles = false;
            dataGridProductos.GridColor = Color.FromArgb(221, 221, 221);
            dataGridProductos.Location = new Point(40, 158);
            dataGridProductos.MultiSelect = false;
            dataGridProductos.Name = "dataGridProductos";
            dataGridProductos.ReadOnly = true;
            dataGridProductos.RowHeadersVisible = false;
            dataGridProductos.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridProductos.Size = new Size(1286, 513);
            dataGridProductos.TabIndex = 2;
            dataGridProductos.CellDoubleClick += dataGridProductos_CellDoubleClick;
            // 
            // Id_Prod
            // 
            Id_Prod.HeaderText = "Id_Prod";
            Id_Prod.Name = "Id_Prod";
            Id_Prod.ReadOnly = true;
            Id_Prod.Visible = false;
            // 
            // producto
            // 
            producto.HeaderText = "Producto";
            producto.Name = "producto";
            producto.ReadOnly = true;
            // 
            // categoria
            // 
            categoria.HeaderText = "Categoria";
            categoria.Name = "categoria";
            categoria.ReadOnly = true;
            // 
            // precio
            // 
            precio.HeaderText = "Precio Unit";
            precio.Name = "precio";
            precio.ReadOnly = true;
            // 
            // pictureBox9
            // 
            pictureBox9.Image = Properties.Resources.Search;
            pictureBox9.Location = new Point(1282, 95);
            pictureBox9.Name = "pictureBox9";
            pictureBox9.Size = new Size(44, 42);
            pictureBox9.TabIndex = 48;
            pictureBox9.TabStop = false;
            // 
            // tbBusquedaProductos
            // 
            tbBusquedaProductos.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbBusquedaProductos.Location = new Point(292, 103);
            tbBusquedaProductos.Name = "tbBusquedaProductos";
            tbBusquedaProductos.Size = new Size(984, 27);
            tbBusquedaProductos.TabIndex = 1;
            tbBusquedaProductos.TextChanged += tbBusquedaProductos_TextChanged;
            // 
            // btnCancelarAyuda
            // 
            btnCancelarAyuda.Image = (Image)resources.GetObject("btnCancelarAyuda.Image");
            btnCancelarAyuda.Location = new Point(40, 99);
            btnCancelarAyuda.Name = "btnCancelarAyuda";
            btnCancelarAyuda.Size = new Size(54, 38);
            btnCancelarAyuda.SizeMode = PictureBoxSizeMode.Zoom;
            btnCancelarAyuda.TabIndex = 75;
            btnCancelarAyuda.TabStop = false;
            btnCancelarAyuda.Click += btnCancelarAyuda_Click;
            // 
            // VistaProductos
            // 
            AutoScaleDimensions = new SizeF(6F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(221, 221, 221);
            ClientSize = new Size(1370, 696);
            Controls.Add(btnCancelarAyuda);
            Controls.Add(pictureBox9);
            Controls.Add(tbBusquedaProductos);
            Controls.Add(dataGridProductos);
            Controls.Add(lblDashboard);
            Controls.Add(pictureBox1);
            Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            Name = "VistaProductos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Productos";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridProductos).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnCancelarAyuda).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblDashboard;
        private PictureBox pictureBox1;
        private DataGridView dataGridProductos;
        private DataGridViewTextBoxColumn Id_Prod;
        private DataGridViewTextBoxColumn producto;
        private DataGridViewTextBoxColumn categoria;
        private DataGridViewTextBoxColumn precio;
        private PictureBox pictureBox9;
        private TextBox tbBusquedaProductos;
        private PictureBox btnCancelarAyuda;
    }
}