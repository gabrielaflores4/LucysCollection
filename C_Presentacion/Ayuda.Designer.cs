namespace C_Presentacion
{
    partial class Ayuda
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
            lblDashboard = new Label();
            pictureBox1 = new PictureBox();
            btnContacto = new Button();
            lblFAQ = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblDashboard
            // 
            lblDashboard.AutoSize = true;
            lblDashboard.BackColor = Color.Black;
            lblDashboard.Font = new Font("Bahnschrift", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDashboard.ForeColor = SystemColors.Control;
            lblDashboard.Location = new Point(641, 16);
            lblDashboard.Name = "lblDashboard";
            lblDashboard.Size = new Size(89, 33);
            lblDashboard.TabIndex = 43;
            lblDashboard.Text = "Ayuda";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.rectangulo4;
            pictureBox1.Location = new Point(-1, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1372, 73);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 42;
            pictureBox1.TabStop = false;
            // 
            // btnContacto
            // 
            btnContacto.BackColor = Color.FromArgb(221, 221, 221);
            btnContacto.BackgroundImage = Properties.Resources.btnContacto;
            btnContacto.BackgroundImageLayout = ImageLayout.Zoom;
            btnContacto.FlatStyle = FlatStyle.Flat;
            btnContacto.ForeColor = Color.FromArgb(221, 221, 221);
            btnContacto.Location = new Point(34, 612);
            btnContacto.Name = "btnContacto";
            btnContacto.Size = new Size(273, 57);
            btnContacto.TabIndex = 70;
            btnContacto.UseVisualStyleBackColor = false;
            // 
            // lblFAQ
            // 
            lblFAQ.AutoSize = true;
            lblFAQ.Font = new Font("Bahnschrift SemiBold", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFAQ.Location = new Point(34, 101);
            lblFAQ.Name = "lblFAQ";
            lblFAQ.Size = new Size(381, 35);
            lblFAQ.TabIndex = 71;
            lblFAQ.Text = "Preguntas Frecuentes (FAQ)";
            // 
            // Ayuda
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(1370, 696);
            Controls.Add(lblFAQ);
            Controls.Add(btnContacto);
            Controls.Add(lblDashboard);
            Controls.Add(pictureBox1);
            Name = "Ayuda";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ayuda";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblDashboard;
        private PictureBox pictureBox1;
        private Button btnContacto;
        private Label lblFAQ;
    }
}