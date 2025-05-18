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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegProd));
            pictureBox1 = new PictureBox();
            lblDashboard = new Label();
            dataGridRegProducto = new DataGridView();
            talla = new DataGridViewTextBoxColumn();
            stock = new DataGridViewTextBoxColumn();
            label22 = new Label();
            tbNombreProdReg = new TextBox();
            tbPrecioRegProd = new TextBox();
            label1 = new Label();
            label2 = new Label();
            cbCategoriaReg = new ComboBox();
            btnGuardarRegProd = new Button();
            btnCancelarRegProd = new Button();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridRegProducto).BeginInit();
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
            lblDashboard.Location = new Point(616, 17);
            lblDashboard.Name = "lblDashboard";
            lblDashboard.Size = new Size(139, 33);
            lblDashboard.TabIndex = 0;
            lblDashboard.Text = "Productos";
            // 
            // dataGridRegProducto
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(221, 221, 221);
            dataGridViewCellStyle1.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridRegProducto.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridRegProducto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridRegProducto.BackgroundColor = Color.FromArgb(221, 221, 221);
            dataGridRegProducto.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.Black;
            dataGridViewCellStyle2.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.Padding = new Padding(1);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.Control;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridRegProducto.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridRegProducto.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridRegProducto.Columns.AddRange(new DataGridViewColumn[] { talla, stock });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(221, 221, 221);
            dataGridViewCellStyle3.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Desktop;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridRegProducto.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridRegProducto.EnableHeadersVisualStyles = false;
            dataGridRegProducto.GridColor = Color.FromArgb(221, 221, 221);
            dataGridRegProducto.Location = new Point(494, 93);
            dataGridRegProducto.MultiSelect = false;
            dataGridRegProducto.Name = "dataGridRegProducto";
            dataGridRegProducto.RowHeadersVisible = false;
            dataGridRegProducto.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridRegProducto.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridRegProducto.Size = new Size(853, 488);
            dataGridRegProducto.TabIndex = 8;
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
            // label22
            // 
            label22.AutoSize = true;
            label22.BackColor = Color.FromArgb(221, 221, 221);
            label22.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label22.ForeColor = SystemColors.ControlText;
            label22.Location = new Point(46, 218);
            label22.Name = "label22";
            label22.Size = new Size(87, 25);
            label22.TabIndex = 2;
            label22.Text = "Nombre";
            // 
            // tbNombreProdReg
            // 
            tbNombreProdReg.Location = new Point(51, 255);
            tbNombreProdReg.Name = "tbNombreProdReg";
            tbNombreProdReg.Size = new Size(397, 27);
            tbNombreProdReg.TabIndex = 3;
            tbNombreProdReg.KeyPress += tbNombreProdReg_KeyPress;
            // 
            // tbPrecioRegProd
            // 
            tbPrecioRegProd.Location = new Point(51, 349);
            tbPrecioRegProd.Name = "tbPrecioRegProd";
            tbPrecioRegProd.Size = new Size(397, 27);
            tbPrecioRegProd.TabIndex = 5;
            tbPrecioRegProd.KeyPress += tbPrecioRegProd_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(221, 221, 221);
            label1.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlText;
            label1.Location = new Point(46, 312);
            label1.Name = "label1";
            label1.Size = new Size(150, 25);
            label1.TabIndex = 4;
            label1.Text = "Precio Unitario";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(221, 221, 221);
            label2.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ControlText;
            label2.Location = new Point(46, 408);
            label2.Name = "label2";
            label2.Size = new Size(101, 25);
            label2.TabIndex = 6;
            label2.Text = "Categoria";
            // 
            // cbCategoriaReg
            // 
            cbCategoriaReg.DropDownHeight = 100;
            cbCategoriaReg.DropDownWidth = 200;
            cbCategoriaReg.FormattingEnabled = true;
            cbCategoriaReg.IntegralHeight = false;
            cbCategoriaReg.Location = new Point(51, 451);
            cbCategoriaReg.Name = "cbCategoriaReg";
            cbCategoriaReg.Size = new Size(397, 27);
            cbCategoriaReg.TabIndex = 7;
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
            btnGuardarRegProd.TabIndex = 9;
            btnGuardarRegProd.UseVisualStyleBackColor = false;
            btnGuardarRegProd.Click += btnGuardarRegProd_Click;
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
            btnCancelarRegProd.TabIndex = 10;
            btnCancelarRegProd.UseVisualStyleBackColor = false;
            btnCancelarRegProd.Click += btnCancelarRegProd_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(221, 221, 221);
            label3.Font = new Font("Bahnschrift SemiBold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.Desktop;
            label3.Location = new Point(51, 150);
            label3.Name = "label3";
            label3.Size = new Size(104, 29);
            label3.TabIndex = 1;
            label3.Text = "Registro";
            // 
            // RegProd
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(221, 221, 221);
            ClientSize = new Size(1370, 696);
            ControlBox = false;
            Controls.Add(label3);
            Controls.Add(btnCancelarRegProd);
            Controls.Add(btnGuardarRegProd);
            Controls.Add(cbCategoriaReg);
            Controls.Add(label2);
            Controls.Add(tbPrecioRegProd);
            Controls.Add(label1);
            Controls.Add(tbNombreProdReg);
            Controls.Add(label22);
            Controls.Add(dataGridRegProducto);
            Controls.Add(lblDashboard);
            Controls.Add(pictureBox1);
            Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "RegProd";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Productos";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridRegProducto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label lblDashboard;
        private DataGridView dataGridRegProducto;
        private Label label22;
        private TextBox tbNombreProdReg;
        private TextBox tbPrecioRegProd;
        private Label label1;
        private Label label2;
        private ComboBox cbCategoriaReg;
        private Button btnGuardarRegProd;
        private Button btnCancelarRegProd;
        private DataGridViewTextBoxColumn talla;
        private DataGridViewTextBoxColumn stock;
        private Label label3;
    }
}