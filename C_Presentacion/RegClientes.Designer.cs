﻿namespace C_Presentacion
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRegClientes));
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
            errorIconoClientes = new ErrorProvider(components);
            btnCancelarCli = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorIconoClientes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnCancelarCli).BeginInit();
            SuspendLayout();
            // 
            // btnRegistraCliente
            // 
            btnRegistraCliente.BackColor = Color.FromArgb(221, 221, 221);
            btnRegistraCliente.BackgroundImage = Properties.Resources.BtnRegistrar;
            btnRegistraCliente.BackgroundImageLayout = ImageLayout.Zoom;
            btnRegistraCliente.FlatStyle = FlatStyle.Flat;
            btnRegistraCliente.ForeColor = Color.FromArgb(221, 221, 221);
            btnRegistraCliente.Location = new Point(496, 604);
            btnRegistraCliente.Name = "btnRegistraCliente";
            btnRegistraCliente.Size = new Size(378, 56);
            btnRegistraCliente.TabIndex = 10;
            btnRegistraCliente.UseVisualStyleBackColor = false;
            btnRegistraCliente.Click += btnRegistraCliente_Click;
            // 
            // tbTelefonoCliente
            // 
            tbTelefonoCliente.Location = new Point(447, 538);
            tbTelefonoCliente.Name = "tbTelefonoCliente";
            tbTelefonoCliente.Size = new Size(483, 23);
            tbTelefonoCliente.TabIndex = 9;
            tbTelefonoCliente.KeyPress += tbTelefonoCliente_KeyPress;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.FromArgb(221, 221, 221);
            label5.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ControlText;
            label5.Location = new Point(443, 486);
            label5.Name = "label5";
            label5.Size = new Size(90, 25);
            label5.TabIndex = 8;
            label5.Text = "Telefono";
            // 
            // tbCorreoCliente
            // 
            tbCorreoCliente.Location = new Point(447, 436);
            tbCorreoCliente.Name = "tbCorreoCliente";
            tbCorreoCliente.Size = new Size(483, 23);
            tbCorreoCliente.TabIndex = 7;
            tbCorreoCliente.KeyPress += tbCorreoCliente_KeyPress;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(221, 221, 221);
            label4.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ControlText;
            label4.Location = new Point(443, 384);
            label4.Name = "label4";
            label4.Size = new Size(76, 25);
            label4.TabIndex = 6;
            label4.Text = "Correo";
            // 
            // tbApellidoCliente
            // 
            tbApellidoCliente.Location = new Point(447, 334);
            tbApellidoCliente.Name = "tbApellidoCliente";
            tbApellidoCliente.Size = new Size(483, 23);
            tbApellidoCliente.TabIndex = 5;
            tbApellidoCliente.KeyPress += tbApellidoCliente_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(221, 221, 221);
            label3.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ControlText;
            label3.Location = new Point(443, 282);
            label3.Name = "label3";
            label3.Size = new Size(87, 25);
            label3.TabIndex = 4;
            label3.Text = "Apellido";
            // 
            // tbNombreClien
            // 
            tbNombreClien.Location = new Point(447, 232);
            tbNombreClien.Name = "tbNombreClien";
            tbNombreClien.Size = new Size(483, 23);
            tbNombreClien.TabIndex = 3;
            tbNombreClien.KeyPress += tbNombreClien_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(221, 221, 221);
            label1.Font = new Font("Bahnschrift", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlText;
            label1.Location = new Point(440, 120);
            label1.Name = "label1";
            label1.Size = new Size(228, 33);
            label1.TabIndex = 1;
            label1.Text = "Datos Personales";
            // 
            // lblDashboard
            // 
            lblDashboard.AutoSize = true;
            lblDashboard.BackColor = Color.Black;
            lblDashboard.Font = new Font("Bahnschrift", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDashboard.ForeColor = SystemColors.Control;
            lblDashboard.Location = new Point(629, 16);
            lblDashboard.Name = "lblDashboard";
            lblDashboard.Size = new Size(113, 33);
            lblDashboard.TabIndex = 0;
            lblDashboard.Text = "Clientes";
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
            label22.Location = new Point(443, 180);
            label22.Name = "label22";
            label22.Size = new Size(87, 25);
            label22.TabIndex = 2;
            label22.Text = "Nombre";
            // 
            // errorIconoClientes
            // 
            errorIconoClientes.ContainerControl = this;
            // 
            // btnCancelarCli
            // 
            btnCancelarCli.Image = (Image)resources.GetObject("btnCancelarCli.Image");
            btnCancelarCli.Location = new Point(1270, 622);
            btnCancelarCli.Name = "btnCancelarCli";
            btnCancelarCli.Size = new Size(54, 38);
            btnCancelarCli.SizeMode = PictureBoxSizeMode.Zoom;
            btnCancelarCli.TabIndex = 101;
            btnCancelarCli.TabStop = false;
            btnCancelarCli.Click += btnCancelarCli_Click;
            // 
            // FrmRegClientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(221, 221, 221);
            ClientSize = new Size(1370, 696);
            ControlBox = false;
            Controls.Add(btnCancelarCli);
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
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmRegClientes";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Clientes";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorIconoClientes).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnCancelarCli).EndInit();
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
        private ErrorProvider errorIconoClientes;
        private PictureBox btnCancelarCli;
    }
}