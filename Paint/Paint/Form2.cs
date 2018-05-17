using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class Form2 : Form
    {
        Color color1;   //Color 1 del gradiente
        Color color2;   //Color 2 del gradiente
        int rbChecked;  //Opción de dirección de gradiente

        public Form2()
        {
            InitializeComponent();
            rbChecked = 0;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            color1 = btnColor1.BackColor;
            color2 = btnColor2.BackColor;
            switch (rbChecked)
            {
                case 0:
                    rbHorizontal.Checked = true;
                    break;
                case 1:
                    rbVertical.Checked = true;
                    break;
                case 2:
                    rbDAscendente.Checked = true;
                    break;
                case 3:
                    rbDDescendente.Checked = true;
                    break;
            }
        }

        /// <summary>
        /// Reasigna a los botones los colores previamente seleccionados.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnColor1.BackColor = color1;
            btnColor2.BackColor = color2;
        }

        /// <summary>
        /// Guarda en una variable la opción de dirección de gradiente seleccionada.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (rbHorizontal.Checked)
            {
                rbChecked = 0;
            }
            else if (rbVertical.Checked)
            {
                rbChecked = 1;
            }
            else if (rbDAscendente.Checked)
            {
                rbChecked = 2;
            }
            else if (rbDDescendente.Checked)
            {
                rbChecked = 3;
            }
        }

        /// <summary>
        /// Asigna el color elegido en el colorDialog al botón correspondiente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void colores_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                ((Button)sender).BackColor = colorDialog1.Color;
            }
        }
    }
}
