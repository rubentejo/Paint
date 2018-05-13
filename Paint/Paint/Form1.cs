using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    /// <summary>
    /// Enumerado de herramientas de trabajo.
    /// </summary>
    public enum Herramientas
    {
        Lapiz, Goma, Brocha, Linea, Cuadrado, Triangulo, Circulo
    }

    public partial class Form1 : Form
    {
        Graphics g;
        Pen p;
        bool mouseDown, cambios, imagenAbierta, rellenoActivado;
        string ruta = "";
        ImageFormat formato;
        int tamañoLapiz, tamañoGoma, tamañoBrocha;
        int[] tamañosLapiz = { 1, 2, 3, 4, 5 };
        int[] tamañosGoma = { 10, 15, 20, 25, 30 };
        int[] tamañosBrocha = { 5, 6, 7, 8, 9, 10 };
        Point inicio, fin;
        Point[] puntosTriangulo = new Point[3];
        Image imagenAux;
        Rectangle r;
        Herramientas herramienta, relleno;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Inicializa los componentes de trabajo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            // Inicializamos componentes

            Text = "Sin título";
            g = canvas.CreateGraphics();
            tamañoLapiz = 1;
            tamañoGoma = 10;
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

            canvas.Image = new Bitmap(canvas.Width, canvas.Height);
            g = Graphics.FromImage(canvas.Image);
            g.FillRectangle(Brushes.White, canvas.ClientRectangle);
        }

        /// <summary>
        /// Devuelve el índice del item dentro del combobox. En caso de no encontrarlo
        /// devuelve -1.
        /// </summary>
        /// <param name="cbo"></param>
        /// <param name="item"></param>
        /// <returns>Índice del item</returns>
        private int buscaCombo(ComboBox cbo, int item)
        {
            foreach (object aux in cbo.Items)
            {
                if ((int)aux == item)
                {
                    return cbo.Items.IndexOf(aux);
                }
            }
            return -1;
        }

        /// <summary>
        /// Devuelve el índice del elemento dentro del array. En caso de no encontralo
        /// devuelve -1.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="elemento"></param>
        /// <returns></returns>
        private int buscaIndice(int[] array, int elemento)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (elemento == array[i])
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Actualiza el color de trabajo según el color que se haya seleccionado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            if ((Button)sender == btnLapiz)
            {
                rellenoActivado = false;
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
                rellenoActivado = false;
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
                rellenoActivado = false;
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
                rellenoActivado = true;
                relleno = Herramientas.Cuadrado;
                herramienta = Herramientas.Cuadrado;
                grbTamaños.Enabled = false;
            }
            else if ((Button)sender == btnLinea)
            {
                rellenoActivado = false;
                herramienta = Herramientas.Linea;
                grbTamaños.Enabled = false;
            }
            else if ((Button)sender == btnCuadrado)
            {
                if (rellenoActivado)
                {
                    relleno = Herramientas.Cuadrado;
                }
                herramienta = Herramientas.Cuadrado;
                grbTamaños.Enabled = false;
            }
            else if ((Button)sender == btnTriangulo)
            {
                if (rellenoActivado)
                {
                    relleno = Herramientas.Triangulo;
                }
                herramienta = Herramientas.Triangulo;
                grbTamaños.Enabled = false;
            }
            else if ((Button)sender == btnCirculo)
            {
                if (rellenoActivado)
                {
                    relleno = Herramientas.Circulo;
                }
                herramienta = Herramientas.Circulo;
                grbTamaños.Enabled = false;
            }
        }

        /// <summary>
        /// Limpia el picturebox. Si se realizaron cambios previamente, pregunta si se desea
        /// guardar o no.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cambios)
            {
                DialogResult dr = MessageBox.Show("¿Desea guardar los cambios de " + Text + "?", "Paint", MessageBoxButtons.YesNoCancel);
                switch (dr)
                {
                    case DialogResult.Yes:
                        guardarToolStripMenuItem.PerformClick();
                        //Text = "Sin título";
                        //canvas.Image = new Bitmap(canvas.Width, canvas.Height);
                        //g = Graphics.FromImage(canvas.Image);
                        //g.FillRectangle(Brushes.White, canvas.ClientRectangle);
                        //cambios = false;
                        //imagenAbierta = false;
                        //ruta = "";
                        //canvas.Invalidate();
                        //break;
                        goto case DialogResult.No;
                    case DialogResult.No:
                        Text = "Sin título";
                        canvas.Image = new Bitmap(canvas.Width, canvas.Height);
                        g = Graphics.FromImage(canvas.Image);
                        g.FillRectangle(Brushes.White, canvas.ClientRectangle);
                        cambios = false;
                        imagenAbierta = false;
                        ruta = "";
                        canvas.Invalidate();
                        break;
                    case DialogResult.Cancel:
                        break;
                }
            }
            else
            {
                Text = "Sin título";
                canvas.Image = new Bitmap(canvas.Width, canvas.Height);
                g = Graphics.FromImage(canvas.Image);
                g.FillRectangle(Brushes.White, canvas.ClientRectangle);
                cambios = false;
                imagenAbierta = false;
                ruta = "";
            }
        }

        /// <summary>
        /// Abre una imagen sobre el picturebox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK && openFileDialog1.FileName != null)
            {
                if (cambios)
                {
                    DialogResult dr2 = MessageBox.Show("¿Desea guardar los cambios de " + Text + "?", "Paint", MessageBoxButtons.YesNoCancel);
                    if (dr2 == DialogResult.Yes)
                    {
                        guardarToolStripMenuItem.PerformClick();
                    }
                }


                canvas.Image = new Bitmap(openFileDialog1.FileName);// Image.FromFile(openFileDialog1.FileName);
                g = Graphics.FromImage(canvas.Image);
                canvas.Invalidate();
                //g.Clear(Color.White);
                //r = new Rectangle(new Point(0, 0), Image.FromFile(openFileDialog1.FileName).Size);
                //g.DrawImage(Image.FromFile(openFileDialog1.FileName), r);
                imagenAbierta = true;
                ruta = openFileDialog1.FileName;
                formato = canvas.Image.RawFormat;
                FileInfo f = new FileInfo(ruta);
                string aux = "";
                for (int i = 0; i < f.Name.Length; i++)
                {
                    if (f.Name[i] != '.')
                    {
                        aux += f.Name[i];
                    }
                    else break;
                }
                Text = aux;
                cambios = false;
                //openFileDialog1.Dispose();                
            }
        }

        /// <summary>
        /// Guarda la imagen creada sobre el picturebox en el formato que se le indique.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = Text;
            if (formato == ImageFormat.Png)
            {
                saveFileDialog1.FilterIndex = 1;
            }
            else if (formato == ImageFormat.Jpeg)
            {
                saveFileDialog1.FilterIndex = 2;
            }
            else if (formato == ImageFormat.Bmp)
            {
                saveFileDialog1.FilterIndex = 3;
            }
            else if (formato == ImageFormat.Gif)
            {
                saveFileDialog1.FilterIndex = 4;
            }
            else
            {
                saveFileDialog1.FilterIndex = 0;
            }
            DialogResult dr = saveFileDialog1.ShowDialog();
            if (dr == DialogResult.OK && saveFileDialog1.FileName != null)
            {
                canvas.Image.Save(saveFileDialog1.FileName);
                ruta = saveFileDialog1.FileName;
                FileInfo f = new FileInfo(ruta);
                string aux = "";
                for (int i = 0; i < f.Name.Length; i++)
                {
                    if (f.Name[i] != '.')
                    {
                        aux += f.Name[i];
                    }
                    else break;
                }
                Text = aux;
                cambios = false;
                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                        formato = ImageFormat.Png;
                        break;
                    case 2:
                        formato = ImageFormat.Jpeg;
                        break;
                    case 3:
                        formato = ImageFormat.Bmp;
                        break;
                    case 4:
                        formato = ImageFormat.Gif;
                        break;
                }
            }
        }

        /// <summary>
        /// Ofrece información acerca de la aplicación.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void acercaDePaintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Este Paint ha sido realizado por Rubén Tejo Pereira.", "Acerca de Paint");
        }

        /// <summary>
        /// Antes de cerrar la aplicación se pregunta si se desean guardar los cambios.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cambios)
            {
                DialogResult dr = MessageBox.Show("¿Desea guardar los cambios de " + Text + "?", "Paint", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                switch (dr)
                {
                    case DialogResult.Yes:
                        guardarToolStripMenuItem.PerformClick();
                        if (cambios) e.Cancel = true;
                        break;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            }
        }

        /// <summary>
        /// Sale de la aplicación.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Permite cambiar el tamaño de la herramienta (lápiz, goma o brocha) mediante
        /// la tecla CTRL y +/-.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //ModifierKeys.HasFlag(Keys.Control)
            if ((ModifierKeys & Keys.Control) == Keys.Control)
            {
                int auxIndice;

                if (e.KeyCode == Keys.Add)
                {
                    switch (herramienta)
                    {
                        case Herramientas.Lapiz:
                            auxIndice = buscaIndice(tamañosLapiz, tamañoLapiz);
                            if (auxIndice + 1 <= tamañosLapiz.Length - 1)
                            {
                                tamañoLapiz = tamañosLapiz[auxIndice + 1];
                                cboTamaños.SelectedIndex = buscaCombo(cboTamaños, tamañoLapiz);
                            }
                            break;
                        case Herramientas.Goma:
                            auxIndice = buscaIndice(tamañosGoma, tamañoGoma);
                            if (auxIndice + 1 <= tamañosGoma.Length - 1)
                            {
                                tamañoGoma = tamañosGoma[auxIndice + 1];
                                cboTamaños.SelectedIndex = buscaCombo(cboTamaños, tamañoGoma);
                            }
                            break;
                        case Herramientas.Brocha:
                            auxIndice = buscaIndice(tamañosBrocha, tamañoBrocha);
                            if (auxIndice + 1 <= tamañosBrocha.Length - 1)
                            {
                                tamañoBrocha = tamañosBrocha[auxIndice + 1];
                                cboTamaños.SelectedIndex = buscaCombo(cboTamaños, tamañoBrocha);
                            }
                            break;
                    }
                }
                else if (e.KeyCode == Keys.Subtract)
                {
                    switch (herramienta)
                    {
                        case Herramientas.Lapiz:
                            auxIndice = buscaIndice(tamañosLapiz, tamañoLapiz);
                            if (auxIndice - 1 >= 0)
                            {
                                tamañoLapiz = tamañosLapiz[auxIndice - 1];
                                cboTamaños.SelectedIndex = buscaCombo(cboTamaños, tamañoLapiz);
                            }
                            break;
                        case Herramientas.Goma:
                            auxIndice = buscaIndice(tamañosGoma, tamañoGoma);
                            if (auxIndice - 1 >= 0)
                            {
                                tamañoGoma = tamañosGoma[auxIndice - 1];
                                cboTamaños.SelectedIndex = buscaCombo(cboTamaños, tamañoGoma);
                            }
                            break;
                        case Herramientas.Brocha:
                            auxIndice = buscaIndice(tamañosBrocha, tamañoBrocha);
                            if (auxIndice - 1 >= 0)
                            {
                                tamañoBrocha = tamañosBrocha[auxIndice - 1];
                                cboTamaños.SelectedIndex = buscaCombo(cboTamaños, tamañoBrocha);
                            }
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Resetea el label de coordenadas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void canvas_MouseLeave(object sender, EventArgs e)
        {
            lblCoordenadas.Text = "";
        }

        /// <summary>
        /// Guarda la imagen creada sobre el picturebox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cambios)
            {
                if (imagenAbierta || ruta.Length != 0)
                {
                    //Image aux = canvas.Image;
                    canvas.Image.Save(ruta, formato);
                    cambios = false;
                }
                else
                {
                    guardarComoToolStripMenuItem.PerformClick();
                }
            }
        }

        /// <summary>
        /// Lleva a cabo los cambios procedentes en el picturebox cuando se efectúa
        /// sobre él un click izquierdo del ratón.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            }
            canvas.Invalidate();
        }

        /// <summary>
        /// Detecta cuando se inicia la actividad dentro del picturebox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseDown = true;
                cambios = true;
                inicio = e.Location;
            }
        }

        /// <summary>
        /// Lleva a cabo los cambios procedentes en el picturebox cuando el raton se mueve sobre él
        /// con el boton izquierdo pulsado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            lblCoordenadas.Text = e.X + ", " + e.Y;
            fin = e.Location;

            if (mouseDown)
            {
                switch (herramienta)
                {
                    case Herramientas.Lapiz:
                        p.Color = colorActual.BackColor;
                        p.Width = tamañoLapiz;
                        g.DrawLine(p, inicio, fin);
                        inicio = fin;
                        break;
                    case Herramientas.Goma:
                        g.FillRectangle(new SolidBrush(canvas.BackColor), e.X, e.Y, tamañoGoma, tamañoGoma);
                        break;
                    case Herramientas.Brocha:
                        p.Color = colorActual.BackColor;
                        p.Width = tamañoBrocha;
                        g.DrawLine(p, inicio, fin);
                        inicio = fin;
                        break;
                    case Herramientas.Linea:
                        imagenAux = canvas.Image;
                        g.Clear(Color.White);
                        //g.DrawImage(imagenAux, canvas.ClientRectangle);
                        canvas.Image = imagenAux;
                        g = Graphics.FromImage(canvas.Image);
                        g.DrawLine(new Pen(colorActual.BackColor, 3), inicio, fin);
                        break;
                    case Herramientas.Cuadrado:
                        imagenAux = canvas.Image;
                        g.Clear(Color.White);
                        g.DrawImage(imagenAux, canvas.ClientRectangle);
                        canvas.Image = imagenAux;
                        g = Graphics.FromImage(canvas.Image);

                        if (inicio.X - fin.X > 0 && inicio.Y - fin.Y > 0)
                        {
                            r = new Rectangle(fin, new Size(Math.Abs(inicio.X - fin.X), Math.Abs(inicio.Y - fin.Y)));
                        }
                        else if (inicio.X - fin.X < 0 && inicio.Y - fin.Y > 0)
                        {
                            r = new Rectangle(new Point(inicio.X, fin.Y), new Size(Math.Abs(inicio.X - fin.X), Math.Abs(inicio.Y - fin.Y)));
                        }
                        else if (inicio.X - fin.X > 0 && inicio.Y - fin.Y < 0)
                        {
                            r = new Rectangle(new Point(fin.X, inicio.Y), new Size(Math.Abs(inicio.X - fin.X), Math.Abs(inicio.Y - fin.Y)));
                        }
                        else
                        {
                            r = new Rectangle(inicio, new Size(Math.Abs(inicio.X - fin.X), Math.Abs(inicio.Y - fin.Y)));
                        }

                        if (rellenoActivado)
                        {
                            g.FillRectangle(new SolidBrush(colorActual.BackColor), r);
                        }
                        else
                        {
                            g.DrawRectangle(new Pen(colorActual.BackColor, 3), r);
                        }
                        break;
                    case Herramientas.Triangulo:
                        imagenAux = canvas.Image;
                        g.Clear(Color.White);
                        //g.DrawImage(imagenAux, canvas.ClientRectangle);
                        canvas.Image = imagenAux;
                        g = Graphics.FromImage(canvas.Image);

                        if (inicio.X - fin.X > 0 && inicio.Y - fin.Y > 0)
                        {
                            r = new Rectangle(fin, new Size(Math.Abs(inicio.X - fin.X), Math.Abs(inicio.Y - fin.Y)));
                        }
                        else if (inicio.X - fin.X < 0 && inicio.Y - fin.Y > 0)
                        {
                            r = new Rectangle(new Point(inicio.X, fin.Y), new Size(Math.Abs(inicio.X - fin.X), Math.Abs(inicio.Y - fin.Y)));
                        }
                        else if (inicio.X - fin.X > 0 && inicio.Y - fin.Y < 0)
                        {
                            r = new Rectangle(new Point(fin.X, inicio.Y), new Size(Math.Abs(inicio.X - fin.X), Math.Abs(inicio.Y - fin.Y)));
                        }
                        else
                        {
                            r = new Rectangle(inicio, new Size(Math.Abs(inicio.X - fin.X), Math.Abs(inicio.Y - fin.Y)));
                        }

                        puntosTriangulo[0] = new Point(r.Right / 2, r.Top);
                        puntosTriangulo[1] = new Point(r.Right, r.Bottom);
                        puntosTriangulo[2] = new Point(r.Left, r.Bottom);

                        if (rellenoActivado)
                        {
                            g.FillPolygon(new SolidBrush(colorActual.BackColor), puntosTriangulo);
                        }
                        else
                        {
                            g.DrawPolygon(new Pen(colorActual.BackColor, 3), puntosTriangulo);
                        }
                        g.DrawRectangle(new Pen(colorActual.BackColor, 3), r);
                        break;
                    case Herramientas.Circulo:
                        imagenAux = canvas.Image;
                        g.Clear(Color.White);
                        //g.DrawImage(imagenAux, canvas.ClientRectangle);
                        canvas.Image = imagenAux;
                        g = Graphics.FromImage(canvas.Image);

                        if (inicio.X - fin.X > 0 && inicio.Y - fin.Y > 0)
                        {
                            r = new Rectangle(fin, new Size(Math.Abs(inicio.X - fin.X), Math.Abs(inicio.Y - fin.Y)));
                        }
                        else if (inicio.X - fin.X < 0 && inicio.Y - fin.Y > 0)
                        {
                            r = new Rectangle(new Point(inicio.X, fin.Y), new Size(Math.Abs(inicio.X - fin.X), Math.Abs(inicio.Y - fin.Y)));
                        }
                        else if (inicio.X - fin.X > 0 && inicio.Y - fin.Y < 0)
                        {
                            r = new Rectangle(new Point(fin.X, inicio.Y), new Size(Math.Abs(inicio.X - fin.X), Math.Abs(inicio.Y - fin.Y)));
                        }
                        else
                        {
                            r = new Rectangle(inicio, new Size(Math.Abs(inicio.X - fin.X), Math.Abs(inicio.Y - fin.Y)));
                        }

                        if (rellenoActivado)
                        {
                            g.FillEllipse(new SolidBrush(colorActual.BackColor), r);
                        }
                        else
                        {
                            g.DrawEllipse(new Pen(colorActual.BackColor, 3), r);
                        }
                        break;
                }
            }

            canvas.Invalidate();
        }

        /// <summary>
        /// Detecta el fin de la actividad sobre el picturebox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseDown = false;
                if (imagenAux != null) g.DrawImage(imagenAux, canvas.ClientRectangle);
                canvas.Invalidate();
            }
        }
    }
}
