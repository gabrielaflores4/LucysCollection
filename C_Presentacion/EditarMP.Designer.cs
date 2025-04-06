namespace C_Presentacion
{
    partial class EditarMP
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
            btnCancelarActProd.Location = new Point(507, 595);
            btnCancelarActProd.Name = "btnCancelarActProd";
            btnCancelarActProd.Size = new Size(187, 64);
            btnCancelarActProd.TabIndex = 70;
            btnCancelarActProd.UseVisualStyleBackColor = false;
            // 
            // btnGuardarActProd
            // 
            btnGuardarActProd.BackColor = Color.FromArgb(221, 221, 221);
            btnGuardarActProd.BackgroundImage = Properties.Resources.btnGuardar;
            btnGuardarActProd.BackgroundImageLayout = ImageLayout.Zoom;
            btnGuardarActProd.FlatStyle = FlatStyle.Flat;
            btnGuardarActProd.ForeColor = Color.FromArgb(221, 221, 221);
            btnGuardarActProd.Location = new Point(720, 595);
            btnGuardarActProd.Name = "btnGuardarActProd";
            btnGuardarActProd.Size = new Size(194, 64);
            btnGuardarActProd.TabIndex = 69;
            btnGuardarActProd.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(221, 221, 221);
            label4.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ControlText;
            label4.Location = new Point(744, 451);
            label4.Name = "label4";
            label4.Size = new Size(93, 25);
            label4.TabIndex = 68;
            label4.Text = "Cantidad";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(221, 221, 221);
            label3.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ControlText;
            label3.Location = new Point(507, 451);
            label3.Name = "label3";
            label3.Size = new Size(55, 25);
            label3.TabIndex = 67;
            label3.Text = "Talla";
            // 
            // nbCantidad
            // 
            nbCantidad.Location = new Point(744, 495);
            nbCantidad.Name = "nbCantidad";
            nbCantidad.Size = new Size(162, 27);
            nbCantidad.TabIndex = 66;
            // 
            // cbTallasRegAct
            // 
            cbTallasRegAct.FormattingEnabled = true;
            cbTallasRegAct.Items.AddRange(new object[] { "5", "6", "7", "8", "9" });
            cbTallasRegAct.Location = new Point(511, 493);
            cbTallasRegAct.Name = "cbTallasRegAct";
            cbTallasRegAct.Size = new Size(162, 27);
            cbTallasRegAct.TabIndex = 65;
            // 
            // cbCategoriaAct
            // 
            cbCategoriaAct.DropDownHeight = 100;
            cbCategoriaAct.DropDownWidth = 200;
            cbCategoriaAct.FormattingEnabled = true;
            cbCategoriaAct.IntegralHeight = false;
            cbCategoriaAct.Location = new Point(507, 387);
            cbCategoriaAct.Name = "cbCategoriaAct";
            cbCategoriaAct.Size = new Size(399, 27);
            cbCategoriaAct.TabIndex = 64;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(221, 221, 221);
            label2.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ControlText;
            label2.Location = new Point(507, 348);
            label2.Name = "label2";
            label2.Size = new Size(101, 25);
            label2.TabIndex = 63;
            label2.Text = "Categoria";
            // 
            // tbPrecioRegAct
            // 
            tbPrecioRegAct.Location = new Point(507, 285);
            tbPrecioRegAct.Name = "tbPrecioRegAct";
            tbPrecioRegAct.Size = new Size(399, 27);
            tbPrecioRegAct.TabIndex = 62;
            tbPrecioRegAct.KeyPress += tbPrecioRegAct_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(221, 221, 221);
            label1.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlText;
            label1.Location = new Point(507, 247);
            label1.Name = "label1";
            label1.Size = new Size(150, 25);
            label1.TabIndex = 61;
            label1.Text = "Precio Unitario";
            // 
            // tbNombreProdAct
            // 
            tbNombreProdAct.Location = new Point(507, 191);
            tbNombreProdAct.Name = "tbNombreProdAct";
            tbNombreProdAct.Size = new Size(399, 27);
            tbNombreProdAct.TabIndex = 60;
            tbNombreProdAct.KeyPress += tbNombreProdAct_KeyPress;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.BackColor = Color.FromArgb(221, 221, 221);
            label22.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label22.ForeColor = SystemColors.ControlText;
            label22.Location = new Point(507, 152);
            label22.Name = "label22";
            label22.Size = new Size(87, 25);
            label22.TabIndex = 59;
            label22.Text = "Nombre";
            // 
            // lblDashboard
            // 
            lblDashboard.AutoSize = true;
            lblDashboard.BackColor = Color.Black;
            lblDashboard.Font = new Font("Bahnschrift", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDashboard.ForeColor = SystemColors.Control;
            lblDashboard.Location = new Point(547, 18);
            lblDashboard.Name = "lblDashboard";
            lblDashboard.Size = new Size(314, 33);
            lblDashboard.TabIndex = 58;
            lblDashboard.Text = "Actualizar Materia Prima";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.rectangulo4;
            pictureBox1.Location = new Point(-1, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1372, 73);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 57;
            pictureBox1.TabStop = false;
            // 
            // EditarMP
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
            Name = "EditarMP";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EditarMP";
            WindowState = FormWindowState.Maximized;
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