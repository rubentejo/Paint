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
    public partial class Form1 : Form
    {
        Graphics g;
        Pen p;
        bool dibujando, borrando, cambios;
        Point inicio, fin;

        public Form1()
        {
            InitializeComponent();

            // Inicializamos componentes

            g = canvas.CreateGraphics();
            p = new Pen(Color.Black, 1);
            dibujando = false;
            borrando = false;
            cambios = false;
            inicio = new Point();
            fin = new Point();
        }

        private void colores_Click(object sender, EventArgs e)
        {
            colorActual.BackColor = ((Button)sender).BackColor;
            p.Color = colorActual.BackColor;
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                dibujando = true; // o borrando
                cambios = true;
                inicio = e.Location;
            }
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (dibujando)
            {
                fin = e.Location;

                p.Color = colorActual.BackColor;
                g.DrawLine(p, inicio, fin);

                inicio = fin; 
            } else if (borrando)
            {

            }
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left){
                dibujando = false; // o borrando
            }
        }
    }
}
