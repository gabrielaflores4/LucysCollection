﻿namespace C_Presentacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditarMP));
            btnCancelarActMP = new Button();
            btnGuardarActMP = new Button();
            label4 = new Label();
            nbCantidad = new NumericUpDown();
            cbProvAct = new ComboBox();
            label2 = new Label();
            tbPrecioRegAct = new TextBox();
            label1 = new Label();
            tbNombreProdAct = new TextBox();
            label22 = new Label();
            lblDashboard = new Label();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)nbCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnCancelarActMP
            // 
            btnCancelarActMP.BackColor = Color.FromArgb(221, 221, 221);
            btnCancelarActMP.BackgroundImage = Properties.Resources.btnCancelar;
            btnCancelarActMP.BackgroundImageLayout = ImageLayout.Zoom;
            btnCancelarActMP.FlatStyle = FlatStyle.Flat;
            btnCancelarActMP.ForeColor = Color.FromArgb(221, 221, 221);
            btnCancelarActMP.Location = new Point(482, 610);
            btnCancelarActMP.Name = "btnCancelarActMP";
            btnCancelarActMP.Size = new Size(187, 64);
            btnCancelarActMP.TabIndex = 11;
            btnCancelarActMP.UseVisualStyleBackColor = false;
            btnCancelarActMP.Click += btnCancelarActMP_Click;
            // 
            // btnGuardarActMP
            // 
            btnGuardarActMP.BackColor = Color.FromArgb(221, 221, 221);
            btnGuardarActMP.BackgroundImage = Properties.Resources.btnGuardar;
            btnGuardarActMP.BackgroundImageLayout = ImageLayout.Zoom;
            btnGuardarActMP.FlatStyle = FlatStyle.Flat;
            btnGuardarActMP.ForeColor = Color.FromArgb(221, 221, 221);
            btnGuardarActMP.Location = new Point(695, 610);
            btnGuardarActMP.Name = "btnGuardarActMP";
            btnGuardarActMP.Size = new Size(194, 64);
            btnGuardarActMP.TabIndex = 10;
            btnGuardarActMP.UseVisualStyleBackColor = false;
            btnGuardarActMP.Click += btnGuardarActMP_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(221, 221, 221);
            label4.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ControlText;
            label4.Location = new Point(482, 509);
            label4.Name = "label4";
            label4.Size = new Size(93, 25);
            label4.TabIndex = 8;
            label4.Text = "Cantidad";
            // 
            // nbCantidad
            // 
            nbCantidad.Location = new Point(486, 556);
            nbCantidad.Name = "nbCantidad";
            nbCantidad.Size = new Size(399, 27);
            nbCantidad.TabIndex = 9;
            // 
            // cbProvAct
            // 
            cbProvAct.DropDownHeight = 100;
            cbProvAct.DropDownWidth = 200;
            cbProvAct.FormattingEnabled = true;
            cbProvAct.IntegralHeight = false;
            cbProvAct.Location = new Point(486, 432);
            cbProvAct.Name = "cbProvAct";
            cbProvAct.Size = new Size(399, 27);
            cbProvAct.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(221, 221, 221);
            label2.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ControlText;
            label2.Location = new Point(486, 386);
            label2.Name = "label2";
            label2.Size = new Size(108, 25);
            label2.TabIndex = 6;
            label2.Text = "Proveedor";
            // 
            // tbPrecioRegAct
            // 
            tbPrecioRegAct.Location = new Point(486, 314);
            tbPrecioRegAct.Name = "tbPrecioRegAct";
            tbPrecioRegAct.Size = new Size(399, 27);
            tbPrecioRegAct.TabIndex = 5;
            tbPrecioRegAct.KeyPress += tbPrecioRegAct_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(221, 221, 221);
            label1.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlText;
            label1.Location = new Point(482, 266);
            label1.Name = "label1";
            label1.Size = new Size(150, 25);
            label1.TabIndex = 4;
            label1.Text = "Precio Unitario";
            // 
            // tbNombreProdAct
            // 
            tbNombreProdAct.Location = new Point(486, 204);
            tbNombreProdAct.Name = "tbNombreProdAct";
            tbNombreProdAct.Size = new Size(399, 27);
            tbNombreProdAct.TabIndex = 3;
            tbNombreProdAct.KeyPress += tbNombreProdAct_KeyPress;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.BackColor = Color.FromArgb(221, 221, 221);
            label22.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label22.ForeColor = SystemColors.ControlText;
            label22.Location = new Point(482, 157);
            label22.Name = "label22";
            label22.Size = new Size(87, 25);
            label22.TabIndex = 2;
            label22.Text = "Nombre";
            // 
            // lblDashboard
            // 
            lblDashboard.AutoSize = true;
            lblDashboard.BackColor = Color.Black;
            lblDashboard.Font = new Font("Bahnschrift", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDashboard.ForeColor = SystemColors.Control;
            lblDashboard.Location = new Point(593, 18);
            lblDashboard.Name = "lblDashboard";
            lblDashboard.Size = new Size(185, 33);
            lblDashboard.TabIndex = 0;
            lblDashboard.Text = "Materia Prima";
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
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(221, 221, 221);
            label3.Font = new Font("Bahnschrift SemiBold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ControlText;
            label3.Location = new Point(482, 99);
            label3.Name = "label3";
            label3.Size = new Size(167, 25);
            label3.TabIndex = 1;
            label3.Text = "Actualizar Datos";
            // 
            // EditarMP
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(221, 221, 221);
            ClientSize = new Size(1370, 696);
            ControlBox = false;
            Controls.Add(label3);
            Controls.Add(btnCancelarActMP);
            Controls.Add(btnGuardarActMP);
            Controls.Add(label4);
            Controls.Add(nbCantidad);
            Controls.Add(cbProvAct);
            Controls.Add(label2);
            Controls.Add(tbPrecioRegAct);
            Controls.Add(label1);
            Controls.Add(tbNombreProdAct);
            Controls.Add(label22);
            Controls.Add(lblDashboard);
            Controls.Add(pictureBox1);
            Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "EditarMP";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Materia Prima";
            WindowState = FormWindowState.Maximized;
            Load += EditarMP_Load_1;
            ((System.ComponentModel.ISupportInitialize)nbCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancelarActMP;
        private Button btnGuardarActMP;
        private Label label4;
        private NumericUpDown nbCantidad;
        private ComboBox cbProvAct;
        private Label label2;
        private TextBox tbPrecioRegAct;
        private Label label1;
        private TextBox tbNombreProdAct;
        private Label label22;
        private Label lblDashboard;
        private PictureBox pictureBox1;
        private Label label3;
    }
}