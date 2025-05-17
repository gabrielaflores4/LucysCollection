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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VistaClientes));
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
            btnEditarCli = new Button();
            btnAgregarCli = new Button();
            btnEliminarCli = new Button();
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
            tbBusquedaClientes.Location = new Point(684, 98);
            tbBusquedaClientes.Name = "tbBusquedaClientes";
            tbBusquedaClientes.Size = new Size(594, 27);
            tbBusquedaClientes.TabIndex = 49;
            tbBusquedaClientes.TextChanged += tbBusquedaClientes_TextChanged;
            // 
            // btnEditarCli
            // 
            btnEditarCli.BackColor = Color.FromArgb(221, 221, 221);
            btnEditarCli.BackgroundImage = Properties.Resources.btnEditar;
            btnEditarCli.BackgroundImageLayout = ImageLayout.Zoom;
            btnEditarCli.FlatStyle = FlatStyle.Flat;
            btnEditarCli.ForeColor = Color.FromArgb(221, 221, 221);
            btnEditarCli.Location = new Point(325, 87);
            btnEditarCli.Name = "btnEditarCli";
            btnEditarCli.Size = new Size(157, 47);
            btnEditarCli.TabIndex = 59;
            btnEditarCli.UseVisualStyleBackColor = false;
            // 
            // btnAgregarCli
            // 
            btnAgregarCli.BackColor = Color.FromArgb(221, 221, 221);
            btnAgregarCli.BackgroundImage = (Image)resources.GetObject("btnAgregarCli.BackgroundImage");
            btnAgregarCli.BackgroundImageLayout = ImageLayout.Zoom;
            btnAgregarCli.FlatStyle = FlatStyle.Flat;
            btnAgregarCli.ForeColor = Color.FromArgb(221, 221, 221);
            btnAgregarCli.Location = new Point(27, 87);
            btnAgregarCli.Name = "btnAgregarCli";
            btnAgregarCli.Size = new Size(157, 47);
            btnAgregarCli.TabIndex = 60;
            btnAgregarCli.UseVisualStyleBackColor = false;
            btnAgregarCli.Click += btnAgregarCli_Click;
            // 
            // btnEliminarCli
            // 
            btnEliminarCli.BackColor = Color.FromArgb(221, 221, 221);
            btnEliminarCli.BackgroundImage = Properties.Resources.btnEliminarCli;
            btnEliminarCli.BackgroundImageLayout = ImageLayout.Zoom;
            btnEliminarCli.FlatStyle = FlatStyle.Flat;
            btnEliminarCli.ForeColor = Color.FromArgb(221, 221, 221);
            btnEliminarCli.Location = new Point(176, 87);
            btnEliminarCli.Name = "btnEliminarCli";
            btnEliminarCli.Size = new Size(157, 47);
            btnEliminarCli.TabIndex = 61;
            btnEliminarCli.UseVisualStyleBackColor = false;
            // 
            // VistaClientes
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(221, 221, 221);
            ClientSize = new Size(1370, 696);
            Controls.Add(btnEliminarCli);
            Controls.Add(btnAgregarCli);
            Controls.Add(btnEditarCli);
            Controls.Add(pictureBox9);
            Controls.Add(tbBusquedaClientes);
            Controls.Add(dataGridClientes);
            Controls.Add(lblDashboard);
            Controls.Add(pictureBox1);
            Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "VistaClientes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Clientes";
            WindowState = FormWindowState.Maximized;
            Load += VistaClientes_Load;
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
        private Button btnEditarCli;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn Apellido;
        private DataGridViewTextBoxColumn Correo;
        private DataGridViewTextBoxColumn Telefono;
        private Button btnAgregarCli;
        private Button btnEliminarCli;
    }
}