namespace C_Presentacion
{
    partial class VistaClientes
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
            lblDashboard = new Label();
            pictureBox1 = new PictureBox();
            dataGridClientes = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            Nombre = new DataGridViewTextBoxColumn();
            Apellido = new DataGridViewTextBoxColumn();
            Correo = new DataGridViewTextBoxColumn();
            Telefono = new DataGridViewTextBoxColumn();
            pictureBox9 = new PictureBox();
            tbBusquedaClientes = new TextBox();
            btnEditarClientes = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridClientes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).BeginInit();
            SuspendLayout();
            // 
            // lblDashboard
            // 
            lblDashboard.AutoSize = true;
            lblDashboard.BackColor = Color.Black;
            lblDashboard.Font = new Font("Bahnschrift", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDashboard.ForeColor = SystemColors.Control;
            lblDashboard.Location = new Point(629, 15);
            lblDashboard.Name = "lblDashboard";
            lblDashboard.Size = new Size(113, 33);
            lblDashboard.TabIndex = 47;
            lblDashboard.Text = "Clientes";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.rectangulo4;
            pictureBox1.Location = new Point(-1, -1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1372, 73);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 46;
            pictureBox1.TabStop = false;
            // 
            // dataGridClientes
            // 
            dataGridViewCellStyle1.BackColor = Color.FromArgb(221, 221, 221);
            dataGridViewCellStyle1.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridClientes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridClientes.BackgroundColor = Color.FromArgb(221, 221, 221);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.Black;
            dataGridViewCellStyle2.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.Padding = new Padding(1);
            dataGridViewCellStyle2.SelectionBackColor = Color.Black;
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridClientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridClientes.ColumnHeadersHeight = 45;
            dataGridClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridClientes.Columns.AddRange(new DataGridViewColumn[] { Id, Nombre, Apellido, Correo, Telefono });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(221, 221, 221);
            dataGridViewCellStyle3.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Desktop;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridClientes.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridClientes.EnableHeadersVisualStyles = false;
            dataGridClientes.GridColor = Color.FromArgb(221, 221, 221);
            dataGridClientes.Location = new Point(36, 149);
            dataGridClientes.Name = "dataGridClientes";
            dataGridClientes.RowHeadersVisible = false;
            dataGridClientes.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridClientes.Size = new Size(1294, 524);
            dataGridClientes.TabIndex = 48;
            dataGridClientes.CellDoubleClick += dataGridClientes_CellDoubleClick;
            // 
            // Id
            // 
            Id.HeaderText = "ID";
            Id.Name = "Id";
            Id.Visible = false;
            // 
            // Nombre
            // 
            Nombre.HeaderText = "Nombre";
            Nombre.Name = "Nombre";
            // 
            // Apellido
            // 
            Apellido.HeaderText = "Apellido";
            Apellido.Name = "Apellido";
            // 
            // Correo
            // 
            Correo.HeaderText = "Correo";
            Correo.Name = "Correo";
            // 
            // Telefono
            // 
            Telefono.HeaderText = "Teléfono";
            Telefono.Name = "Telefono";
            // 
            // pictureBox9
            // 
            pictureBox9.Image = Properties.Resources.Search;
            pictureBox9.Location = new Point(1284, 90);
            pictureBox9.Name = "pictureBox9";
            pictureBox9.Size = new Size(44, 42);
            pictureBox9.TabIndex = 50;
            pictureBox9.TabStop = false;
            // 
            // tbBusquedaClientes
            // 
            tbBusquedaClientes.Location = new Point(294, 98);
            tbBusquedaClientes.Name = "tbBusquedaClientes";
            tbBusquedaClientes.Size = new Size(984, 27);
            tbBusquedaClientes.TabIndex = 49;
            // 
            // btnEditarClientes
            // 
            btnEditarClientes.BackColor = Color.FromArgb(221, 221, 221);
            btnEditarClientes.BackgroundImage = Properties.Resources.btnEditar;
            btnEditarClientes.BackgroundImageLayout = ImageLayout.Zoom;
            btnEditarClientes.FlatStyle = FlatStyle.Flat;
            btnEditarClientes.ForeColor = Color.FromArgb(221, 221, 221);
            btnEditarClientes.Location = new Point(34, 87);
            btnEditarClientes.Name = "btnEditarClientes";
            btnEditarClientes.Size = new Size(133, 47);
            btnEditarClientes.TabIndex = 59;
            btnEditarClientes.UseVisualStyleBackColor = false;
            // 
            // VistaClientes
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(221, 221, 221);
            ClientSize = new Size(1370, 696);
            Controls.Add(btnEditarClientes);
            Controls.Add(pictureBox9);
            Controls.Add(tbBusquedaClientes);
            Controls.Add(dataGridClientes);
            Controls.Add(lblDashboard);
            Controls.Add(pictureBox1);
            Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "VistaClientes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Clientes";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridClientes).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblDashboard;
        private PictureBox pictureBox1;
        private DataGridView dataGridClientes;
        private PictureBox pictureBox9;
        private TextBox tbBusquedaClientes;
        private Button btnEditarClientes;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn Apellido;
        private DataGridViewTextBoxColumn Correo;
        private DataGridViewTextBoxColumn Telefono;
    }
}