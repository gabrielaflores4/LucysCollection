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
            ((System.ComponentModel.ISupportInitialize)nbCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnCancelarActProd
            // 
            btnCancelarActProd.BackColor = Color.FromArgb(221, 221, 221);
            btnCancelarActProd.BackgroundImage = Properties.Resources.btnCancelar;
            btnCancelarActProd.BackgroundImageLayout = ImageLayout.Zoom;
            btnCancelarActProd.FlatStyle = FlatStyle.Flat;
            btnCancelarActProd.ForeColor = Color.FromArgb(221, 221, 221);
            btnCancelarActProd.Location = new Point(507, 596);
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
            btnGuardarActProd.Location = new Point(720, 596);
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
            label4.Location = new Point(744, 452);
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
            label3.Location = new Point(507, 452);
            label3.Name = "label3";
            label3.Size = new Size(55, 25);
            label3.TabIndex = 51;
            label3.Text = "Talla";
            // 
            // nbCantidad
            // 
            nbCantidad.Location = new Point(744, 496);
            nbCantidad.Name = "nbCantidad";
            nbCantidad.Size = new Size(162, 27);
            nbCantidad.TabIndex = 50;
            // 
            // cbTallasRegAct
            // 
            cbTallasRegAct.FormattingEnabled = true;
            cbTallasRegAct.Items.AddRange(new object[] { "5", "6", "7", "8", "9" });
            cbTallasRegAct.Location = new Point(511, 494);
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
            cbCategoriaAct.Location = new Point(507, 388);
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
            label2.Location = new Point(507, 349);
            label2.Name = "label2";
            label2.Size = new Size(101, 25);
            label2.TabIndex = 47;
            label2.Text = "Categoria";
            // 
            // tbPrecioRegAct
            // 
            tbPrecioRegAct.Location = new Point(507, 286);
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
            label1.Location = new Point(507, 248);
            label1.Name = "label1";
            label1.Size = new Size(150, 25);
            label1.TabIndex = 45;
            label1.Text = "Precio Unitario";
            // 
            // tbNombreProdAct
            // 
            tbNombreProdAct.Location = new Point(507, 192);
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
            label22.Location = new Point(507, 153);
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
            lblDashboard.Size = new Size(268, 33);
            lblDashboard.TabIndex = 41;
            lblDashboard.Text = "Actualizar Productos";
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
            // EditarProducto
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(221, 221, 221);
            ClientSize = new Size(1370, 749);
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
    }
}