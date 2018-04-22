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
    public enum Herramientas
    {
        Lapiz, Goma, Brocha, Relleno, Figura
    }

    public partial class Form1 : Form
    {
        Graphics g;
        Pen p;
        bool mouseDown, cambios;
        int tamañoLapiz, tamañoGoma, tamañoBrocha;
        int[] tamañosLapiz = { 1, 2, 3, 4, 5 };
        int[] tamañosGoma = { 5, 10, 15, 20, 25 };
        int[] tamañosBrocha = { 5, 6, 7, 8, 9, 10 };
        Point inicio, fin;
        Herramientas herramienta;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Inicializamos componentes

            Text = "Sin título";
            g = canvas.CreateGraphics();
            tamañoLapiz = 1;
            tamañoGoma = 5;
            tamañoBrocha = 5;
            p = new Pen(Color.Black, tamañoLapiz);
            p.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            p.EndCap = p.StartCap;
            mouseDown = false;
            cambios = false;
            herramienta = Herramientas.Lapiz;
            inicio = new Point();
            fin = new Point();

            cboTamaños.DataSource = tamañosLapiz;
            cboTamaños.SelectedIndex = 0;
        }

        /// <summary>
        /// Devuelve el índice del item dentro del combobox. En caso de no encontrarlo
        /// devuelve -1;
        /// </summary>
        /// <param name="cbo"></param>
        /// <param name="item"></param>
        /// <returns>Índice del item</returns>
        private int buscaCombo(ComboBox cbo, int item)
        {
            foreach(object aux in cbo.Items)
            {
                if((int)aux == item)
                {
                    return cbo.Items.IndexOf(aux);
                }
            }

            return -1;
        }

        private void colores_Click(object sender, EventArgs e)
        {
            colorActual.BackColor = ((Button)sender).BackColor;
            p.Color = colorActual.BackColor;
        }

        /// <summary>
        /// Cambia el tamaño del lápiz, de la goma o de la brocha, dependiendo de
        /// cual esté activo en ese momento.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboTamaños_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (herramienta == Herramientas.Lapiz)
            {
                tamañoLapiz = (int)cboTamaños.SelectedItem;
            }
            else if (herramienta == Herramientas.Goma)
            {
                tamañoGoma = (int)cboTamaños.SelectedItem;
            }
            else if (herramienta == Herramientas.Brocha)
            {
                tamañoBrocha = (int)cboTamaños.SelectedItem;
            }
        }

        /// <summary>
        /// Habilita/deshabilita las distintas herramientas disponibles.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void herramientas_Click(object sender, EventArgs e)
        {
            if((Button)sender == btnLapiz)
            {
                grbTamaños.Enabled = true;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
                herramienta = Herramientas.Lapiz;
                lblTamaños.Text = "Tamaño del lápiz:";
                cboTamaños.DataSource = tamañosLapiz;
                cboTamaños.Width = lblTamaños.Width - 3;
                if (buscaCombo(cboTamaños, tamañoLapiz) > -1)
                {
                    cboTamaños.SelectedIndex = buscaCombo(cboTamaños, tamañoLapiz);
                }
                else
                {
                    cboTamaños.SelectedIndex = 0;
                    tamañoLapiz = (int)cboTamaños.SelectedItem;
                }
            }
            else if ((Button)sender == btnGoma)
            {
                grbTamaños.Enabled = true;
                herramienta = Herramientas.Goma;
                lblTamaños.Text = "Tamaño de la goma:";
                cboTamaños.DataSource = tamañosGoma;
                cboTamaños.Width = lblTamaños.Width - 3;
                if (buscaCombo(cboTamaños, tamañoGoma) > -1)
                {
                    cboTamaños.SelectedIndex = buscaCombo(cboTamaños, tamañoGoma);
                }
                else
                {
                    cboTamaños.SelectedIndex = 0;
                    tamañoGoma = (int)cboTamaños.SelectedItem;
                }
            }
            else if ((Button)sender == btnBrocha)
            {
                grbTamaños.Enabled = true;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                herramienta = Herramientas.Brocha;
                lblTamaños.Text = "Tamaño de la brocha:";
                cboTamaños.DataSource = tamañosBrocha;
                cboTamaños.Width = lblTamaños.Width - 3;
                if (buscaCombo(cboTamaños, tamañoBrocha) > -1)
                {
                    cboTamaños.SelectedIndex = buscaCombo(cboTamaños, tamañoBrocha);
                }
                else
                {
                    cboTamaños.SelectedIndex = 0;
                    tamañoBrocha = (int)cboTamaños.SelectedItem;
                }
            }
            else if ((Button)sender == btnRelleno)
            {
                herramienta = Herramientas.Relleno;
                grbTamaños.Enabled = false;
            }
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cambios)
            {
                DialogResult dr = MessageBox.Show("Paint", "¿Desea guardar los cambios de " + Text + "?", MessageBoxButtons.YesNoCancel);
                switch (dr)
                {
                    case DialogResult.Yes:
                        saveFileDialog1.ShowDialog();
                        break;
                    case DialogResult.No:
                        canvas.Refresh();
                        canvas.Image = null;
                        break;
                    case DialogResult.Cancel:
                        break;
                }
            }
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();
            if(dr == DialogResult.OK) //FALTA COMPROBAR DISTINTO DE NULL
            {
                if (cambios)
                {
                    DialogResult dr2 = MessageBox.Show("Paint", "¿Desea guardar los cambios de " + Text + "?", MessageBoxButtons.YesNoCancel);
                    switch (dr2)
                    {
                        case DialogResult.Yes:
                            saveFileDialog1.ShowDialog();
                            //Falta el codigo de guardado
                            break;
                        case DialogResult.No:
                            canvas.Refresh();
                            canvas.Image = null;
                            break;
                        case DialogResult.Cancel:
                            break;
                    }
                }

                //Aqui se carga la imagen que se quiere abrir
            }
        }

        private void canvas_Click(object sender, EventArgs e)
        {
            switch (herramienta)
            {
                case Herramientas.Lapiz:
                    g.FillEllipse(new SolidBrush(colorActual.BackColor), inicio.X, inicio.Y, tamañoLapiz, tamañoLapiz);
                    break;
                case Herramientas.Goma:
                    g.FillRectangle(new SolidBrush(canvas.BackColor), inicio.X, inicio.Y, tamañoGoma, tamañoGoma);
                    break;
                case Herramientas.Brocha:
                    g.FillEllipse(new SolidBrush(colorActual.BackColor), inicio.X, inicio.Y, tamañoBrocha, tamañoBrocha);
                    break;
                case Herramientas.Relleno:
                    break;
                case Herramientas.Figura:
                    break;
            }
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                mouseDown = true; // o borrando
                cambios = true;
                inicio = e.Location;
            }
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            fin = e.Location;

            if (mouseDown)
            {
                switch (herramienta)
                {
                    case Herramientas.Lapiz:
                        p.Color = colorActual.BackColor;
                        p.Width = tamañoLapiz;
                        g.DrawLine(p, inicio, fin);
                        break;
                    case Herramientas.Goma:
                        g.FillRectangle(new SolidBrush(canvas.BackColor), e.X, e.Y, tamañoGoma, tamañoGoma);
                        break;
                    case Herramientas.Brocha:
                        p.Color = colorActual.BackColor;
                        p.Width = tamañoBrocha;
                        g.DrawLine(p, inicio, fin);
                        break;
                    case Herramientas.Relleno:
                        break;
                    case Herramientas.Figura:
                        break;
                } 
            }

            inicio = fin; 
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left){
                mouseDown = false;
            }
        }
    }
}
