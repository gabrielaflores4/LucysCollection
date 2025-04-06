namespace C_Presentacion
{
    partial class RegMP
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
            btnCancelarMP = new Button();
            btnGuardarMP = new Button();
            btnEliminarMP = new Button();
            btnAgregarMP = new Button();
            label4 = new Label();
            label3 = new Label();
            cbProvMP = new ComboBox();
            tbPrecioMP = new TextBox();
            label1 = new Label();
            label22 = new Label();
            tbNombreMP = new TextBox();
            dataGridRegMP = new DataGridView();
            nombre = new DataGridViewTextBoxColumn();
            precioUnit = new DataGridViewTextBoxColumn();
            proveedor = new DataGridViewTextBoxColumn();
            cantidad = new DataGridViewTextBoxColumn();
            lblDashboard = new Label();
            pictureBox1 = new PictureBox();
            nbCantidadMP = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)dataGridRegMP).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nbCantidadMP).BeginInit();
            SuspendLayout();
            // 
            // btnCancelarMP
            // 
            btnCancelarMP.BackColor = Color.FromArgb(221, 221, 221);
            btnCancelarMP.BackgroundImage = Properties.Resources.btnCancelar;
            btnCancelarMP.BackgroundImageLayout = ImageLayout.Zoom;
            btnCancelarMP.FlatStyle = FlatStyle.Flat;
            btnCancelarMP.ForeColor = Color.FromArgb(221, 221, 221);
            btnCancelarMP.Location = new Point(948, 613);
            btnCancelarMP.Name = "btnCancelarMP";
            btnCancelarMP.Size = new Size(187, 64);
            btnCancelarMP.TabIndex = 56;
            btnCancelarMP.UseVisualStyleBackColor = false;
            // 
            // btnGuardarMP
            // 
            btnGuardarMP.BackColor = Color.FromArgb(221, 221, 221);
            btnGuardarMP.BackgroundImage = Properties.Resources.btnGuardar;
            btnGuardarMP.BackgroundImageLayout = ImageLayout.Zoom;
            btnGuardarMP.FlatStyle = FlatStyle.Flat;
            btnGuardarMP.ForeColor = Color.FromArgb(221, 221, 221);
            btnGuardarMP.Location = new Point(1161, 613);
            btnGuardarMP.Name = "btnGuardarMP";
            btnGuardarMP.Size = new Size(186, 64);
            btnGuardarMP.TabIndex = 55;
            btnGuardarMP.UseVisualStyleBackColor = false;
            // 
            // btnEliminarMP
            // 
            btnEliminarMP.BackColor = Color.FromArgb(221, 221, 221);
            btnEliminarMP.BackgroundImage = Properties.Resources.btnEliminar;
            btnEliminarMP.BackgroundImageLayout = ImageLayout.Zoom;
            btnEliminarMP.FlatStyle = FlatStyle.Flat;
            btnEliminarMP.ForeColor = Color.FromArgb(221, 221, 221);
            btnEliminarMP.Location = new Point(28, 508);
            btnEliminarMP.Name = "btnEliminarMP";
            btnEliminarMP.Size = new Size(161, 64);
            btnEliminarMP.TabIndex = 54;
            btnEliminarMP.UseVisualStyleBackColor = false;
            // 
            // btnAgregarMP
            // 
            btnAgregarMP.BackColor = Color.FromArgb(221, 221, 221);
            btnAgregarMP.BackgroundImage = Properties.Resources.btnAgregar;
            btnAgregarMP.BackgroundImageLayout = ImageLayout.Zoom;
            btnAgregarMP.FlatStyle = FlatStyle.Flat;
            btnAgregarMP.ForeColor = Color.FromArgb(221, 221, 221);
            btnAgregarMP.Location = new Point(217, 508);
            btnAgregarMP.Name = "btnAgregarMP";
            btnAgregarMP.Size = new Size(162, 64);
            btnAgregarMP.TabIndex = 53;
            btnAgregarMP.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(221, 221, 221);
            label4.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ControlText;
            label4.Location = new Point(27, 413);
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
            label3.Location = new Point(27, 307);
            label3.Name = "label3";
            label3.Size = new Size(108, 25);
            label3.TabIndex = 51;
            label3.Text = "Proveedor";
            // 
            // cbProvMP
            // 
            cbProvMP.FormattingEnabled = true;
            cbProvMP.Location = new Point(32, 347);
            cbProvMP.Name = "cbProvMP";
            cbProvMP.Size = new Size(347, 27);
            cbProvMP.TabIndex = 49;
            // 
            // tbPrecioMP
            // 
            tbPrecioMP.Location = new Point(32, 241);
            tbPrecioMP.Name = "tbPrecioMP";
            tbPrecioMP.Size = new Size(347, 27);
            tbPrecioMP.TabIndex = 46;
            tbPrecioMP.KeyPress += tbPrecioMP_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(221, 221, 221);
            label1.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlText;
            label1.Location = new Point(27, 204);
            label1.Name = "label1";
            label1.Size = new Size(150, 25);
            label1.TabIndex = 45;
            label1.Text = "Precio Unitario";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.BackColor = Color.FromArgb(221, 221, 221);
            label22.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label22.ForeColor = SystemColors.ControlText;
            label22.Location = new Point(27, 110);
            label22.Name = "label22";
            label22.Size = new Size(87, 25);
            label22.TabIndex = 43;
            label22.Text = "Nombre";
            // 
            // tbNombreMP
            // 
            tbNombreMP.Location = new Point(32, 147);
            tbNombreMP.Name = "tbNombreMP";
            tbNombreMP.Size = new Size(347, 27);
            tbNombreMP.TabIndex = 44;
            tbNombreMP.KeyPress += tbNombreMP_KeyPress;
            // 
            // dataGridRegMP
            // 
            dataGridViewCellStyle1.BackColor = Color.Black;
            dataGridViewCellStyle1.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridRegMP.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridRegMP.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridRegMP.BackgroundColor = Color.FromArgb(221, 221, 221);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.Black;
            dataGridViewCellStyle2.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.Padding = new Padding(1);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Desktop;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridRegMP.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridRegMP.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridRegMP.Columns.AddRange(new DataGridViewColumn[] { nombre, precioUnit, proveedor, cantidad });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(221, 221, 221);
            dataGridViewCellStyle3.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Desktop;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridRegMP.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridRegMP.EnableHeadersVisualStyles = false;
            dataGridRegMP.GridColor = Color.FromArgb(221, 221, 221);
            dataGridRegMP.Location = new Point(405, 95);
            dataGridRegMP.Name = "dataGridRegMP";
            dataGridRegMP.RowHeadersVisible = false;
            dataGridRegMP.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridRegMP.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridRegMP.Size = new Size(941, 488);
            dataGridRegMP.TabIndex = 42;
            // 
            // nombre
            // 
            nombre.HeaderText = "Nombre";
            nombre.Name = "nombre";
            // 
            // precioUnit
            // 
            precioUnit.HeaderText = "Precio Unit";
            precioUnit.Name = "precioUnit";
            // 
            // proveedor
            // 
            proveedor.HeaderText = "Proveedor";
            proveedor.Name = "proveedor";
            // 
            // cantidad
            // 
            cantidad.HeaderText = "Cantidad";
            cantidad.Name = "cantidad";
            // 
            // lblDashboard
            // 
            lblDashboard.AutoSize = true;
            lblDashboard.BackColor = Color.Black;
            lblDashboard.Font = new Font("Bahnschrift", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDashboard.ForeColor = SystemColors.Control;
            lblDashboard.Location = new Point(561, 18);
            lblDashboard.Name = "lblDashboard";
            lblDashboard.Size = new Size(306, 33);
            lblDashboard.TabIndex = 41;
            lblDashboard.Text = "Registrar Materia Prima";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.rectangulo4;
            pictureBox1.Location = new Point(-1, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1372, 73);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 40;
            pictureBox1.TabStop = false;
            // 
            // nbCantidadMP
            // 
            nbCantidadMP.Font = new Font("Bahnschrift", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nbCantidadMP.Location = new Point(32, 451);
            nbCantidadMP.Name = "nbCantidadMP";
            nbCantidadMP.Size = new Size(347, 30);
            nbCantidadMP.TabIndex = 50;
            // 
            // RegMP
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(221, 221, 221);
            ClientSize = new Size(1370, 696);
            Controls.Add(btnCancelarMP);
            Controls.Add(btnGuardarMP);
            Controls.Add(btnEliminarMP);
            Controls.Add(btnAgregarMP);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(nbCantidadMP);
            Controls.Add(cbProvMP);
            Controls.Add(tbPrecioMP);
            Controls.Add(label1);
            Controls.Add(label22);
            Controls.Add(tbNombreMP);
            Controls.Add(dataGridRegMP);
            Controls.Add(lblDashboard);
            Controls.Add(pictureBox1);
            Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "RegMP";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RegMP";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)dataGridRegMP).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)nbCantidadMP).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancelarMP;
        private Button btnGuardarMP;
        private Button btnEliminarMP;
        private Button btnAgregarMP;
        private Label label4;
        private Label label3;
        private ComboBox cbProvMP;
        private TextBox tbPrecioMP;
        private Label label1;
        private Label label22;
        private TextBox tbNombreMP;
        private DataGridView dataGridRegMP;
        private Label lblDashboard;
        private PictureBox pictureBox1;
        private NumericUpDown nbCantidadMP;
        private DataGridViewTextBoxColumn nombre;
        private DataGridViewTextBoxColumn precioUnit;
        private DataGridViewTextBoxColumn proveedor;
        private DataGridViewTextBoxColumn cantidad;
    }
}