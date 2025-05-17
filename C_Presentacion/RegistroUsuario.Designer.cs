namespace C_Presentacion
{
    partial class RegistroUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistroUsuario));
            lblDashboard = new Label();
            pictureBox1 = new PictureBox();
            label22 = new Label();
            label1 = new Label();
            label2 = new Label();
            tbNombreUser = new TextBox();
            tbApellidoUser = new TextBox();
            label3 = new Label();
            tbCorreoUser = new TextBox();
            label4 = new Label();
            tbTelefonoUser = new TextBox();
            label5 = new Label();
            tbUsername = new TextBox();
            label6 = new Label();
            tbPassword = new TextBox();
            label7 = new Label();
            btnRegistrarUsuarios = new Button();
            label8 = new Label();
            cbRol = new ComboBox();
            errorIconoUsuarios = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorIconoUsuarios).BeginInit();
            SuspendLayout();
            // 
            // lblDashboard
            // 
            lblDashboard.AutoSize = true;
            lblDashboard.BackColor = Color.Black;
            lblDashboard.Font = new Font("Bahnschrift", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDashboard.ForeColor = SystemColors.Control;
            lblDashboard.Location = new Point(564, 17);
            lblDashboard.Name = "lblDashboard";
            lblDashboard.Size = new Size(234, 33);
            lblDashboard.TabIndex = 65;
            lblDashboard.Text = "Registro Usuarios";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.rectangulo4;
            pictureBox1.Location = new Point(-1, -1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1372, 73);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 64;
            pictureBox1.TabStop = false;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.BackColor = Color.FromArgb(221, 221, 221);
            label22.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label22.ForeColor = SystemColors.ControlText;
            label22.Location = new Point(124, 175);
            label22.Name = "label22";
            label22.Size = new Size(87, 25);
            label22.TabIndex = 67;
            label22.Text = "Nombre";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(221, 221, 221);
            label1.Font = new Font("Bahnschrift", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlText;
            label1.Location = new Point(121, 124);
            label1.Name = "label1";
            label1.Size = new Size(228, 33);
            label1.TabIndex = 68;
            label1.Text = "Datos Personales";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(221, 221, 221);
            label2.Font = new Font("Bahnschrift", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ControlText;
            label2.Location = new Point(753, 124);
            label2.Name = "label2";
            label2.Size = new Size(214, 33);
            label2.TabIndex = 69;
            label2.Text = "Datos de Acceso";
            // 
            // tbNombreUser
            // 
            tbNombreUser.Location = new Point(128, 223);
            tbNombreUser.Name = "tbNombreUser";
            tbNombreUser.Size = new Size(483, 27);
            tbNombreUser.TabIndex = 70;
            tbNombreUser.KeyPress += tbNombreUser_KeyPress;
            // 
            // tbApellidoUser
            // 
            tbApellidoUser.Location = new Point(128, 321);
            tbApellidoUser.Name = "tbApellidoUser";
            tbApellidoUser.Size = new Size(483, 27);
            tbApellidoUser.TabIndex = 72;
            tbApellidoUser.KeyPress += tbApellidoUser_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(221, 221, 221);
            label3.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ControlText;
            label3.Location = new Point(124, 273);
            label3.Name = "label3";
            label3.Size = new Size(87, 25);
            label3.TabIndex = 71;
            label3.Text = "Apellido";
            // 
            // tbCorreoUser
            // 
            tbCorreoUser.Location = new Point(128, 419);
            tbCorreoUser.Name = "tbCorreoUser";
            tbCorreoUser.Size = new Size(483, 27);
            tbCorreoUser.TabIndex = 74;
            tbCorreoUser.KeyPress += tbCorreoUser_KeyPress;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(221, 221, 221);
            label4.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ControlText;
            label4.Location = new Point(124, 371);
            label4.Name = "label4";
            label4.Size = new Size(76, 25);
            label4.TabIndex = 73;
            label4.Text = "Correo";
            // 
            // tbTelefonoUser
            // 
            tbTelefonoUser.Location = new Point(128, 517);
            tbTelefonoUser.Name = "tbTelefonoUser";
            tbTelefonoUser.Size = new Size(483, 27);
            tbTelefonoUser.TabIndex = 76;
            tbTelefonoUser.KeyPress += tbTelefonoUser_KeyPress;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.FromArgb(221, 221, 221);
            label5.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ControlText;
            label5.Location = new Point(124, 469);
            label5.Name = "label5";
            label5.Size = new Size(90, 25);
            label5.TabIndex = 75;
            label5.Text = "Telefono";
            // 
            // tbUsername
            // 
            tbUsername.Location = new Point(760, 219);
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new Size(483, 27);
            tbUsername.TabIndex = 78;
            tbUsername.KeyPress += tbUsername_KeyPress;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.FromArgb(221, 221, 221);
            label6.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = SystemColors.ControlText;
            label6.Location = new Point(760, 175);
            label6.Name = "label6";
            label6.Size = new Size(85, 25);
            label6.TabIndex = 77;
            label6.Text = "Usuario";
            // 
            // tbPassword
            // 
            tbPassword.Location = new Point(760, 309);
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(483, 27);
            tbPassword.TabIndex = 80;
            tbPassword.KeyPress += tbPassword_KeyPress;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.FromArgb(221, 221, 221);
            label7.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = SystemColors.ControlText;
            label7.Location = new Point(760, 265);
            label7.Name = "label7";
            label7.Size = new Size(120, 25);
            label7.TabIndex = 79;
            label7.Text = "Contraseña";
            // 
            // btnRegistrarUsuarios
            // 
            btnRegistrarUsuarios.BackColor = Color.FromArgb(221, 221, 221);
            btnRegistrarUsuarios.BackgroundImage = Properties.Resources.BtnRegistrar;
            btnRegistrarUsuarios.BackgroundImageLayout = ImageLayout.Zoom;
            btnRegistrarUsuarios.FlatStyle = FlatStyle.Flat;
            btnRegistrarUsuarios.ForeColor = Color.FromArgb(221, 221, 221);
            btnRegistrarUsuarios.Location = new Point(488, 600);
            btnRegistrarUsuarios.Name = "btnRegistrarUsuarios";
            btnRegistrarUsuarios.Size = new Size(378, 56);
            btnRegistrarUsuarios.TabIndex = 81;
            btnRegistrarUsuarios.UseVisualStyleBackColor = false;
            btnRegistrarUsuarios.Click += btnRegistrarUsuarios_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.FromArgb(221, 221, 221);
            label8.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = SystemColors.ControlText;
            label8.Location = new Point(753, 371);
            label8.Name = "label8";
            label8.Size = new Size(43, 25);
            label8.TabIndex = 82;
            label8.Text = "Rol";
            // 
            // cbRol
            // 
            cbRol.FormattingEnabled = true;
            cbRol.Items.AddRange(new object[] { "admin", "empleado" });
            cbRol.Location = new Point(760, 419);
            cbRol.Name = "cbRol";
            cbRol.Size = new Size(483, 27);
            cbRol.TabIndex = 83;
            // 
            // errorIconoUsuarios
            // 
            errorIconoUsuarios.ContainerControl = this;
            // 
            // RegistroUsuario
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(221, 221, 221);
            ClientSize = new Size(1370, 696);
            Controls.Add(cbRol);
            Controls.Add(label8);
            Controls.Add(btnRegistrarUsuarios);
            Controls.Add(tbPassword);
            Controls.Add(label7);
            Controls.Add(tbUsername);
            Controls.Add(label6);
            Controls.Add(tbTelefonoUser);
            Controls.Add(label5);
            Controls.Add(tbCorreoUser);
            Controls.Add(label4);
            Controls.Add(tbApellidoUser);
            Controls.Add(label3);
            Controls.Add(tbNombreUser);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblDashboard);
            Controls.Add(pictureBox1);
            Controls.Add(label22);
            Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "RegistroUsuario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RegistroUsuario";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorIconoUsuarios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblDashboard;
        private PictureBox pictureBox1;
        private Label label22;
        private Label label1;
        private Label label2;
        private TextBox tbNombreUser;
        private TextBox tbApellidoUser;
        private Label label3;
        private TextBox tbCorreoUser;
        private Label label4;
        private TextBox tbTelefonoUser;
        private Label label5;
        private TextBox tbUsername;
        private Label label6;
        private TextBox tbPassword;
        private Label label7;
        private Button btnRegistrarUsuarios;
        private Label label8;
        private ComboBox cbRol;
        private ErrorProvider errorIconoUsuarios;
    }
}