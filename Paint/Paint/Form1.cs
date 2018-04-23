using System;
using System.Drawing;
using System.Windows.Forms;

namespace Paint
{
    /// <summary>
    /// Herramientas.
    /// </summary>
    public enum Herramientas
    {
        /// <summary>
        /// The lapiz.
        /// </summary>
        Lapiz,
        /// <summary>
        /// The goma.
        /// </summary>
        Goma,
        /// <summary>
        /// The brocha.
        /// </summary>
        Brocha,
        /// <summary>
        /// The relleno.
        /// </summary>
        Relleno,
        /// <summary>
        /// The figura.
        /// </summary>
        Figura
    }

    /// <summary>
    /// Form1.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// The g.
        /// </summary>
        Graphics g;

        /// <summary>
        /// The p.
        /// </summary>
        Pen p;

        /// <summary>
        /// The mouse down.
        /// </summary>
        bool mouseDown;

        /// <summary>
        /// The cambios.
        /// </summary>
        bool cambios;

        /// <summary>
        /// The tamaño lapiz.
        /// </summary>
        int tamañoLapiz;

        /// <summary>
        /// The tamaño goma.
        /// </summary>
        int tamañoGoma;

        /// <summary>
        /// The tamaño brocha.
        /// </summary>
        int tamañoBrocha;

        /// <summary>
        /// The tamaños lapiz.
        /// </summary>
        int[] tamañosLapiz = { 1, 2, 3, 4, 5 };

        /// <summary>
        /// The tamaños goma.
        /// </summary>
        int[] tamañosGoma = { 5, 10, 15, 20, 25 };

        /// <summary>
        /// The tamaños brocha.
        /// </summary>
        int[] tamañosBrocha = { 5, 6, 7, 8, 9, 10 };

        /// <summary>
        /// The inicio.
        /// </summary>
        Point inicio;

        /// <summary>
        /// The fin.
        /// </summary>
        Point fin;

        /// <summary>
        /// The herramienta.
        /// </summary>
        Herramientas herramienta;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Paint.Form1"/> class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Form1s the load.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
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

        /// <summary>
        /// Coloreses the click.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
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

        /// <summary>
        /// Nuevos the tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
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

        /// <summary>
        /// Abrirs the tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
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

        /// <summary>
        /// Canvases the click.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
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

        /// <summary>
        /// Canvases the mouse down.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                mouseDown = true; // o borrando
                cambios = true;
                inicio = e.Location;
            }
        }

        /// <summary>
        /// Canvases the mouse move.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
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

        /// <summary>
        /// Canvases the mouse up.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left){
                mouseDown = false;
            }
        }
    }
}
