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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditarEmpleados));
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
            label4 = new Label();
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
            btnCancelarActEmp.Location = new Point(482, 618);
            btnCancelarActEmp.Name = "btnCancelarActEmp";
            btnCancelarActEmp.Size = new Size(187, 64);
            btnCancelarActEmp.TabIndex = 12;
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
            btnGuardarActEmp.Location = new Point(695, 618);
            btnGuardarActEmp.Name = "btnGuardarActEmp";
            btnGuardarActEmp.Size = new Size(194, 64);
            btnGuardarActEmp.TabIndex = 11;
            btnGuardarActEmp.UseVisualStyleBackColor = false;
            btnGuardarActEmp.Click += btnGuardarActEmp_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(221, 221, 221);
            label3.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ControlText;
            label3.Location = new Point(485, 517);
            label3.Name = "label3";
            label3.Size = new Size(43, 25);
            label3.TabIndex = 9;
            label3.Text = "Rol";
            // 
            // cbRolEmpAct
            // 
            cbRolEmpAct.FormattingEnabled = true;
            cbRolEmpAct.Items.AddRange(new object[] { "admin", "empleado" });
            cbRolEmpAct.Location = new Point(489, 559);
            cbRolEmpAct.Name = "cbRolEmpAct";
            cbRolEmpAct.Size = new Size(399, 27);
            cbRolEmpAct.TabIndex = 10;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(221, 221, 221);
            label2.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ControlText;
            label2.Location = new Point(483, 333);
            label2.Name = "label2";
            label2.Size = new Size(76, 25);
            label2.TabIndex = 5;
            label2.Text = "Correo";
            // 
            // tbApellidoEmpAct
            // 
            tbApellidoEmpAct.Location = new Point(489, 277);
            tbApellidoEmpAct.Name = "tbApellidoEmpAct";
            tbApellidoEmpAct.Size = new Size(399, 27);
            tbApellidoEmpAct.TabIndex = 4;
            tbApellidoEmpAct.KeyPress += tbApellidoEmpAct_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(221, 221, 221);
            label1.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlText;
            label1.Location = new Point(485, 239);
            label1.Name = "label1";
            label1.Size = new Size(87, 25);
            label1.TabIndex = 3;
            label1.Text = "Apellido";
            // 
            // tbNombreEmpAct
            // 
            tbNombreEmpAct.Location = new Point(489, 183);
            tbNombreEmpAct.Name = "tbNombreEmpAct";
            tbNombreEmpAct.Size = new Size(399, 27);
            tbNombreEmpAct.TabIndex = 2;
            tbNombreEmpAct.KeyPress += tbNombreEmpAct_KeyPress;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.BackColor = Color.FromArgb(221, 221, 221);
            label22.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label22.ForeColor = SystemColors.ControlText;
            label22.Location = new Point(485, 144);
            label22.Name = "label22";
            label22.Size = new Size(87, 25);
            label22.TabIndex = 1;
            label22.Text = "Nombre";
            // 
            // lblDashboard
            // 
            lblDashboard.AutoSize = true;
            lblDashboard.BackColor = Color.Black;
            lblDashboard.Font = new Font("Bahnschrift", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDashboard.ForeColor = SystemColors.Control;
            lblDashboard.Location = new Point(611, 15);
            lblDashboard.Name = "lblDashboard";
            lblDashboard.Size = new Size(149, 33);
            lblDashboard.TabIndex = 0;
            lblDashboard.Text = "Empleados";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.rectangulo4;
            pictureBox1.Location = new Point(-1, -2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1372, 73);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 57;
            pictureBox1.TabStop = false;
            // 
            // tbCorreoEmpAct
            // 
            tbCorreoEmpAct.Location = new Point(489, 374);
            tbCorreoEmpAct.Name = "tbCorreoEmpAct";
            tbCorreoEmpAct.Size = new Size(399, 27);
            tbCorreoEmpAct.TabIndex = 6;
            tbCorreoEmpAct.KeyPress += tbCorreoEmpAct_KeyPress;
            // 
            // tbTelefonoEmpAct
            // 
            tbTelefonoEmpAct.Location = new Point(489, 468);
            tbTelefonoEmpAct.Name = "tbTelefonoEmpAct";
            tbTelefonoEmpAct.Size = new Size(399, 27);
            tbTelefonoEmpAct.TabIndex = 8;
            tbTelefonoEmpAct.KeyPress += tbTelefonoEmpAct_KeyPress;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.FromArgb(221, 221, 221);
            label5.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ControlText;
            label5.Location = new Point(484, 427);
            label5.Name = "label5";
            label5.Size = new Size(90, 25);
            label5.TabIndex = 7;
            label5.Text = "Telefono";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(221, 221, 221);
            label4.Font = new Font("Bahnschrift SemiBold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ControlText;
            label4.Location = new Point(485, 91);
            label4.Name = "label4";
            label4.Size = new Size(191, 29);
            label4.TabIndex = 58;
            label4.Text = "Actualizar Datos";
            // 
            // EditarEmpleados
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(221, 221, 221);
            ClientSize = new Size(1370, 696);
            ControlBox = false;
            Controls.Add(label4);
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
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "EditarEmpleados";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Empleados";
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
        private Label label4;
    }
}