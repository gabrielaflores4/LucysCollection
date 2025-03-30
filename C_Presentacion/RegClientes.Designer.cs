namespace C_Presentacion
{
    partial class FrmRegClientes
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
            btnRegistraCliente = new Button();
            tbTelefonoCliente = new TextBox();
            label5 = new Label();
            tbCorreoCliente = new TextBox();
            label4 = new Label();
            tbApellidoCliente = new TextBox();
            label3 = new Label();
            tbNombreClien = new TextBox();
            label1 = new Label();
            lblDashboard = new Label();
            pictureBox1 = new PictureBox();
            label22 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnRegistraCliente
            // 
            btnRegistraCliente.BackColor = Color.FromArgb(221, 221, 221);
            btnRegistraCliente.BackgroundImage = Properties.Resources.BtnRegistrar;
            btnRegistraCliente.BackgroundImageLayout = ImageLayout.Zoom;
            btnRegistraCliente.FlatStyle = FlatStyle.Flat;
            btnRegistraCliente.ForeColor = Color.FromArgb(221, 221, 221);
            btnRegistraCliente.Location = new Point(446, 633);
            btnRegistraCliente.Name = "btnRegistraCliente";
            btnRegistraCliente.Size = new Size(378, 56);
            btnRegistraCliente.TabIndex = 100;
            btnRegistraCliente.UseVisualStyleBackColor = false;
            btnRegistraCliente.Click += btnRegistraCliente_Click;
            // 
            // tbTelefonoCliente
            // 
            tbTelefonoCliente.Location = new Point(400, 551);
            tbTelefonoCliente.Name = "tbTelefonoCliente";
            tbTelefonoCliente.Size = new Size(483, 23);
            tbTelefonoCliente.TabIndex = 95;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.FromArgb(221, 221, 221);
            label5.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ControlText;
            label5.Location = new Point(396, 503);
            label5.Name = "label5";
            label5.Size = new Size(90, 25);
            label5.TabIndex = 94;
            label5.Text = "Telefono";
            // 
            // tbCorreoCliente
            // 
            tbCorreoCliente.Location = new Point(400, 453);
            tbCorreoCliente.Name = "tbCorreoCliente";
            tbCorreoCliente.Size = new Size(483, 23);
            tbCorreoCliente.TabIndex = 93;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(221, 221, 221);
            label4.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ControlText;
            label4.Location = new Point(396, 405);
            label4.Name = "label4";
            label4.Size = new Size(76, 25);
            label4.TabIndex = 92;
            label4.Text = "Correo";
            // 
            // tbApellidoCliente
            // 
            tbApellidoCliente.Location = new Point(400, 355);
            tbApellidoCliente.Name = "tbApellidoCliente";
            tbApellidoCliente.Size = new Size(483, 23);
            tbApellidoCliente.TabIndex = 91;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(221, 221, 221);
            label3.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ControlText;
            label3.Location = new Point(396, 307);
            label3.Name = "label3";
            label3.Size = new Size(87, 25);
            label3.TabIndex = 90;
            label3.Text = "Apellido";
            // 
            // tbNombreClien
            // 
            tbNombreClien.Location = new Point(400, 257);
            tbNombreClien.Name = "tbNombreClien";
            tbNombreClien.Size = new Size(483, 23);
            tbNombreClien.TabIndex = 89;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(221, 221, 221);
            label1.Font = new Font("Bahnschrift", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlText;
            label1.Location = new Point(393, 158);
            label1.Name = "label1";
            label1.Size = new Size(228, 33);
            label1.TabIndex = 87;
            label1.Text = "Datos Personales";
            // 
            // lblDashboard
            // 
            lblDashboard.AutoSize = true;
            lblDashboard.BackColor = Color.Black;
            lblDashboard.Font = new Font("Bahnschrift", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDashboard.ForeColor = SystemColors.Control;
            lblDashboard.Location = new Point(526, 9);
            lblDashboard.Name = "lblDashboard";
            lblDashboard.Size = new Size(223, 33);
            lblDashboard.TabIndex = 85;
            lblDashboard.Text = "Registro Clientes";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.rectangulo4;
            pictureBox1.Location = new Point(-3, -4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1372, 73);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 84;
            pictureBox1.TabStop = false;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.BackColor = Color.FromArgb(221, 221, 221);
            label22.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label22.ForeColor = SystemColors.ControlText;
            label22.Location = new Point(396, 209);
            label22.Name = "label22";
            label22.Size = new Size(87, 25);
            label22.TabIndex = 86;
            label22.Text = "Nombre";
            // 
            // FrmRegClientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 777);
            Controls.Add(btnRegistraCliente);
            Controls.Add(tbTelefonoCliente);
            Controls.Add(label5);
            Controls.Add(tbCorreoCliente);
            Controls.Add(label4);
            Controls.Add(tbApellidoCliente);
            Controls.Add(label3);
            Controls.Add(tbNombreClien);
            Controls.Add(label1);
            Controls.Add(lblDashboard);
            Controls.Add(pictureBox1);
            Controls.Add(label22);
            Name = "FrmRegClientes";
            Text = "Clientes";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnRegistraCliente;
        private TextBox tbTelefonoCliente;
        private Label label5;
        private TextBox tbCorreoCliente;
        private Label label4;
        private TextBox tbApellidoCliente;
        private Label label3;
        private TextBox tbNombreClien;
        private Label label1;
        private Label lblDashboard;
        private PictureBox pictureBox1;
        private Label label22;
    }
}