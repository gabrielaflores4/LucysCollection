﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_Presentacion
{
    public partial class EditarMP : Form
    {
        public EditarMP()
        {
            InitializeComponent();
        }

        private void tbNombreProdAct_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloLetras(e);
        }

        private void tbPrecioRegAct_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloNumerosDecimales(e, tbPrecioRegAct);
        }
    }
}
