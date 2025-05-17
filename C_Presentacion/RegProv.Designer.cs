namespace C_Presentacion
{
    partial class RegProv
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegProv));
            btnRegistrarProv = new Button();
            tbTelefonoProv = new TextBox();
            label5 = new Label();
            tbCorreoProv = new TextBox();
            label4 = new Label();
            tbDireccionProv = new TextBox();
            label3 = new Label();
            tbNombreProv = new TextBox();
            label1 = new Label();
            lblDashboard = new Label();
            pictureBox1 = new PictureBox();
            label22 = new Label();
            errorProveedores = new ErrorProvider(components);
            btnCancelarProveedor = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProveedores).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnCancelarProveedor).BeginInit();
            SuspendLayout();
            // 
            // btnRegistrarProv
            // 
            btnRegistrarProv.BackColor = Color.FromArgb(221, 221, 221);
            btnRegistrarProv.BackgroundImage = Properties.Resources.BtnRegistrar;
            btnRegistrarProv.BackgroundImageLayout = ImageLayout.Zoom;
            btnRegistrarProv.FlatStyle = FlatStyle.Flat;
            btnRegistrarProv.ForeColor = Color.FromArgb(221, 221, 221);
            btnRegistrarProv.Location = new Point(495, 600);
            btnRegistrarProv.Name = "btnRegistrarProv";
            btnRegistrarProv.Size = new Size(378, 56);
            btnRegistrarProv.TabIndex = 98;
            btnRegistrarProv.UseVisualStyleBackColor = false;
            btnRegistrarProv.Click += btnRegistrarProv_Click;
            // 
            // tbTelefonoProv
            // 
            tbTelefonoProv.Location = new Point(447, 533);
            tbTelefonoProv.Name = "tbTelefonoProv";
            tbTelefonoProv.Size = new Size(483, 27);
            tbTelefonoProv.TabIndex = 93;
            tbTelefonoProv.KeyPress += tbTelefonoProv_KeyPress;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.FromArgb(221, 221, 221);
            label5.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ControlText;
            label5.Location = new Point(443, 483);
            label5.Name = "label5";
            label5.Size = new Size(90, 25);
            label5.TabIndex = 92;
            label5.Text = "Teléfono";
            // 
            // tbCorreoProv
            // 
            tbCorreoProv.Location = new Point(447, 431);
            tbCorreoProv.Name = "tbCorreoProv";
            tbCorreoProv.Size = new Size(483, 27);
            tbCorreoProv.TabIndex = 91;
            tbCorreoProv.KeyPress += tbCorreoProv_KeyPress;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(221, 221, 221);
            label4.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ControlText;
            label4.Location = new Point(443, 381);
            label4.Name = "label4";
            label4.Size = new Size(76, 25);
            label4.TabIndex = 90;
            label4.Text = "Correo";
            // 
            // tbDireccionProv
            // 
            tbDireccionProv.Location = new Point(447, 329);
            tbDireccionProv.Name = "tbDireccionProv";
            tbDireccionProv.Size = new Size(483, 27);
            tbDireccionProv.TabIndex = 89;
            tbDireccionProv.KeyPress += tbDireccionProv_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(221, 221, 221);
            label3.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ControlText;
            label3.Location = new Point(443, 279);
            label3.Name = "label3";
            label3.Size = new Size(99, 25);
            label3.TabIndex = 88;
            label3.Text = "Dirección";
            // 
            // tbNombreProv
            // 
            tbNombreProv.Location = new Point(447, 227);
            tbNombreProv.Name = "tbNombreProv";
            tbNombreProv.Size = new Size(483, 27);
            tbNombreProv.TabIndex = 87;
            tbNombreProv.KeyPress += tbNombreProv_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(221, 221, 221);
            label1.Font = new Font("Bahnschrift", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlText;
            label1.Location = new Point(440, 119);
            label1.Name = "label1";
            label1.Size = new Size(235, 33);
            label1.TabIndex = 85;
            label1.Text = "Datos de Contacto";
            // 
            // lblDashboard
            // 
            lblDashboard.AutoSize = true;
            lblDashboard.BackColor = Color.Black;
            lblDashboard.Font = new Font("Bahnschrift", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDashboard.ForeColor = SystemColors.Control;
            lblDashboard.Location = new Point(560, 16);
            lblDashboard.Name = "lblDashboard";
            lblDashboard.Size = new Size(251, 33);
            lblDashboard.TabIndex = 83;
            lblDashboard.Text = "Registro Proveedor";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.rectangulo4;
            pictureBox1.Location = new Point(-1, -2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1372, 73);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 82;
            pictureBox1.TabStop = false;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.BackColor = Color.FromArgb(221, 221, 221);
            label22.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label22.ForeColor = SystemColors.ControlText;
            label22.Location = new Point(443, 177);
            label22.Name = "label22";
            label22.Size = new Size(87, 25);
            label22.TabIndex = 84;
            label22.Text = "Nombre";
            // 
            // errorProveedores
            // 
            errorProveedores.ContainerControl = this;
            // 
            // btnCancelarProveedor
            // 
            btnCancelarProveedor.Image = (Image)resources.GetObject("btnCancelarProveedor.Image");
            btnCancelarProveedor.Location = new Point(1304, 618);
            btnCancelarProveedor.Name = "btnCancelarProveedor";
            btnCancelarProveedor.Size = new Size(54, 38);
            btnCancelarProveedor.SizeMode = PictureBoxSizeMode.Zoom;
            btnCancelarProveedor.TabIndex = 102;
            btnCancelarProveedor.TabStop = false;
            btnCancelarProveedor.Click += btnCancelarProveedor_Click;
            // 
            // RegProv
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(221, 221, 221);
            ClientSize = new Size(1370, 696);
            Controls.Add(btnCancelarProveedor);
            Controls.Add(btnRegistrarProv);
            Controls.Add(tbTelefonoProv);
            Controls.Add(label5);
            Controls.Add(tbCorreoProv);
            Controls.Add(label4);
            Controls.Add(tbDireccionProv);
            Controls.Add(label3);
            Controls.Add(tbNombreProv);
            Controls.Add(label1);
            Controls.Add(lblDashboard);
            Controls.Add(pictureBox1);
            Controls.Add(label22);
            Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "RegProv";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RegProv";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProveedores).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnCancelarProveedor).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnRegistrarProv;
        private TextBox tbTelefonoProv;
        private Label label5;
        private TextBox tbCorreoProv;
        private Label label4;
        private TextBox tbDireccionProv;
        private Label label3;
        private TextBox tbNombreProv;
        private Label label1;
        private Label lblDashboard;
        private PictureBox pictureBox1;
        private Label label22;
        private ErrorProvider errorProveedores;
        private PictureBox btnCancelarProveedor;
    }
}