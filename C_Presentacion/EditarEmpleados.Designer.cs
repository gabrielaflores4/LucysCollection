namespace C_Presentacion
{
    partial class EditarEmpleados
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
            btnCancelarActEmp = new Button();
            btnGuardarActEmp = new Button();
            label3 = new Label();
            cbRolEmpAct = new ComboBox();
            label2 = new Label();
            tbApellidoEmpAct = new TextBox();
            label1 = new Label();
            tbNombreEmpAct = new TextBox();
            label22 = new Label();
            lblDashboard = new Label();
            pictureBox1 = new PictureBox();
            tbCorreoEmpAct = new TextBox();
            tbTelefonoEmpAct = new TextBox();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnCancelarActEmp
            // 
            btnCancelarActEmp.BackColor = Color.FromArgb(221, 221, 221);
            btnCancelarActEmp.BackgroundImage = Properties.Resources.btnCancelar;
            btnCancelarActEmp.BackgroundImageLayout = ImageLayout.Zoom;
            btnCancelarActEmp.FlatStyle = FlatStyle.Flat;
            btnCancelarActEmp.ForeColor = Color.FromArgb(221, 221, 221);
            btnCancelarActEmp.Location = new Point(507, 645);
            btnCancelarActEmp.Name = "btnCancelarActEmp";
            btnCancelarActEmp.Size = new Size(187, 64);
            btnCancelarActEmp.TabIndex = 70;
            btnCancelarActEmp.UseVisualStyleBackColor = false;
            btnCancelarActEmp.Click += btnCancelarActEmp_Click;
            // 
            // btnGuardarActEmp
            // 
            btnGuardarActEmp.BackColor = Color.FromArgb(221, 221, 221);
            btnGuardarActEmp.BackgroundImage = Properties.Resources.btnGuardar;
            btnGuardarActEmp.BackgroundImageLayout = ImageLayout.Zoom;
            btnGuardarActEmp.FlatStyle = FlatStyle.Flat;
            btnGuardarActEmp.ForeColor = Color.FromArgb(221, 221, 221);
            btnGuardarActEmp.Location = new Point(720, 645);
            btnGuardarActEmp.Name = "btnGuardarActEmp";
            btnGuardarActEmp.Size = new Size(194, 64);
            btnGuardarActEmp.TabIndex = 69;
            btnGuardarActEmp.UseVisualStyleBackColor = false;
            btnGuardarActEmp.Click += btnGuardarActEmp_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(221, 221, 221);
            label3.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ControlText;
            label3.Location = new Point(503, 509);
            label3.Name = "label3";
            label3.Size = new Size(43, 25);
            label3.TabIndex = 67;
            label3.Text = "Rol";
            // 
            // cbRolEmpAct
            // 
            cbRolEmpAct.FormattingEnabled = true;
            cbRolEmpAct.Items.AddRange(new object[] { "admin", "empleado" });
            cbRolEmpAct.Location = new Point(507, 551);
            cbRolEmpAct.Name = "cbRolEmpAct";
            cbRolEmpAct.Size = new Size(399, 27);
            cbRolEmpAct.TabIndex = 65;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(221, 221, 221);
            label2.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ControlText;
            label2.Location = new Point(501, 325);
            label2.Name = "label2";
            label2.Size = new Size(76, 25);
            label2.TabIndex = 63;
            label2.Text = "Correo";
            // 
            // tbApellidoEmpAct
            // 
            tbApellidoEmpAct.Location = new Point(507, 269);
            tbApellidoEmpAct.Name = "tbApellidoEmpAct";
            tbApellidoEmpAct.Size = new Size(399, 27);
            tbApellidoEmpAct.TabIndex = 62;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(221, 221, 221);
            label1.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlText;
            label1.Location = new Point(503, 231);
            label1.Name = "label1";
            label1.Size = new Size(87, 25);
            label1.TabIndex = 61;
            label1.Text = "Apellido";
            // 
            // tbNombreEmpAct
            // 
            tbNombreEmpAct.Location = new Point(507, 175);
            tbNombreEmpAct.Name = "tbNombreEmpAct";
            tbNombreEmpAct.Size = new Size(399, 27);
            tbNombreEmpAct.TabIndex = 60;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.BackColor = Color.FromArgb(221, 221, 221);
            label22.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label22.ForeColor = SystemColors.ControlText;
            label22.Location = new Point(503, 136);
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
            lblDashboard.Location = new Point(580, 19);
            lblDashboard.Name = "lblDashboard";
            lblDashboard.Size = new Size(278, 33);
            lblDashboard.TabIndex = 58;
            lblDashboard.Text = "Actualizar Empleados";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.rectangulo4;
            pictureBox1.Location = new Point(-1, 1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1372, 73);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 57;
            pictureBox1.TabStop = false;
            // 
            // tbCorreoEmpAct
            // 
            tbCorreoEmpAct.Location = new Point(507, 366);
            tbCorreoEmpAct.Name = "tbCorreoEmpAct";
            tbCorreoEmpAct.Size = new Size(399, 27);
            tbCorreoEmpAct.TabIndex = 71;
            // 
            // tbTelefonoEmpAct
            // 
            tbTelefonoEmpAct.Location = new Point(507, 460);
            tbTelefonoEmpAct.Name = "tbTelefonoEmpAct";
            tbTelefonoEmpAct.Size = new Size(399, 27);
            tbTelefonoEmpAct.TabIndex = 73;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.FromArgb(221, 221, 221);
            label5.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ControlText;
            label5.Location = new Point(502, 419);
            label5.Name = "label5";
            label5.Size = new Size(90, 25);
            label5.TabIndex = 72;
            label5.Text = "Telefono";
            // 
            // EditarEmpleados
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(221, 221, 221);
            ClientSize = new Size(1370, 749);
            Controls.Add(tbTelefonoEmpAct);
            Controls.Add(label5);
            Controls.Add(tbCorreoEmpAct);
            Controls.Add(btnCancelarActEmp);
            Controls.Add(btnGuardarActEmp);
            Controls.Add(label3);
            Controls.Add(cbRolEmpAct);
            Controls.Add(label2);
            Controls.Add(tbApellidoEmpAct);
            Controls.Add(label1);
            Controls.Add(tbNombreEmpAct);
            Controls.Add(label22);
            Controls.Add(lblDashboard);
            Controls.Add(pictureBox1);
            Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "EditarEmpleados";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EditarEmpleados";
            WindowState = FormWindowState.Maximized;
            Load += EditarEmpleados_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancelarActEmp;
        private Button btnGuardarActEmp;
        private Label label3;
        private ComboBox cbRolEmpAct;
        private ComboBox cbCategoriaAct;
        private Label label2;
        private TextBox tbApellidoEmpAct;
        private Label label1;
        private TextBox tbNombreEmpAct;
        private Label label22;
        private Label lblDashboard;
        private PictureBox pictureBox1;
        private TextBox tbCorreoEmpAct;
        private TextBox tbTelefonoEmpAct;
        private Label label5;
    }
}