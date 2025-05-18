namespace C_Presentacion
{
    partial class AgregarTallas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgregarTallas));
            lblDashboard = new Label();
            pictureBox1 = new PictureBox();
            dataGridViewTallas = new DataGridView();
            Id_Prod = new DataGridViewTextBoxColumn();
            talla = new DataGridViewTextBoxColumn();
            stock = new DataGridViewTextBoxColumn();
            btnAgregarTallas = new Button();
            btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTallas).BeginInit();
            SuspendLayout();
            // 
            // lblDashboard
            // 
            lblDashboard.AutoSize = true;
            lblDashboard.BackColor = Color.Black;
            lblDashboard.Font = new Font("Bahnschrift", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDashboard.ForeColor = SystemColors.Control;
            lblDashboard.Location = new Point(643, 15);
            lblDashboard.Name = "lblDashboard";
            lblDashboard.Size = new Size(85, 33);
            lblDashboard.TabIndex = 0;
            lblDashboard.Text = "Tallas";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.rectangulo4;
            pictureBox1.Location = new Point(0, -2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1371, 73);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 42;
            pictureBox1.TabStop = false;
            // 
            // dataGridViewTallas
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(221, 221, 221);
            dataGridViewCellStyle1.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewTallas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewTallas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewTallas.BackgroundColor = Color.FromArgb(221, 221, 221);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.Black;
            dataGridViewCellStyle2.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.Padding = new Padding(1);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.Control;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridViewTallas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewTallas.ColumnHeadersHeight = 40;
            dataGridViewTallas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewTallas.Columns.AddRange(new DataGridViewColumn[] { Id_Prod, talla, stock });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(221, 221, 221);
            dataGridViewCellStyle3.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Desktop;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridViewTallas.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewTallas.EnableHeadersVisualStyles = false;
            dataGridViewTallas.GridColor = Color.FromArgb(221, 221, 221);
            dataGridViewTallas.Location = new Point(40, 100);
            dataGridViewTallas.Name = "dataGridViewTallas";
            dataGridViewTallas.RowHeadersVisible = false;
            dataGridViewTallas.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewTallas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewTallas.Size = new Size(1291, 498);
            dataGridViewTallas.TabIndex = 1;
            // 
            // Id_Prod
            // 
            Id_Prod.HeaderText = "Id_Prod";
            Id_Prod.Name = "Id_Prod";
            Id_Prod.Visible = false;
            // 
            // talla
            // 
            talla.HeaderText = "Talla";
            talla.Name = "talla";
            // 
            // stock
            // 
            stock.HeaderText = "Stock";
            stock.Name = "stock";
            // 
            // btnAgregarTallas
            // 
            btnAgregarTallas.BackColor = Color.FromArgb(221, 221, 221);
            btnAgregarTallas.BackgroundImage = Properties.Resources.btnAgregar;
            btnAgregarTallas.BackgroundImageLayout = ImageLayout.Zoom;
            btnAgregarTallas.FlatStyle = FlatStyle.Flat;
            btnAgregarTallas.ForeColor = Color.FromArgb(221, 221, 221);
            btnAgregarTallas.Location = new Point(1136, 618);
            btnAgregarTallas.Name = "btnAgregarTallas";
            btnAgregarTallas.Size = new Size(195, 74);
            btnAgregarTallas.TabIndex = 2;
            btnAgregarTallas.UseVisualStyleBackColor = false;
            btnAgregarTallas.Click += btnAgregarTallas_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.FromArgb(221, 221, 221);
            btnCancelar.BackgroundImage = Properties.Resources.btnCancelar;
            btnCancelar.BackgroundImageLayout = ImageLayout.Zoom;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.ForeColor = Color.FromArgb(221, 221, 221);
            btnCancelar.Location = new Point(40, 634);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(188, 42);
            btnCancelar.TabIndex = 3;
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // AgregarTallas
            // 
            AcceptButton = btnAgregarTallas;
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(221, 221, 221);
            CancelButton = btnCancelar;
            ClientSize = new Size(1370, 749);
            Controls.Add(btnCancelar);
            Controls.Add(btnAgregarTallas);
            Controls.Add(dataGridViewTallas);
            Controls.Add(lblDashboard);
            Controls.Add(pictureBox1);
            Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "AgregarTallas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tallas";
            WindowState = FormWindowState.Maximized;
            Load += AgregarTallas_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTallas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblDashboard;
        private PictureBox pictureBox1;
        private DataGridView dataGridViewTallas;
        private DataGridViewTextBoxColumn Id_Prod;
        private DataGridViewTextBoxColumn talla;
        private DataGridViewTextBoxColumn stock;
        private Button btnAgregarTallas;
        private Button btnCancelar;
    }
}