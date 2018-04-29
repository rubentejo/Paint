﻿using System;
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
        Lapiz, Goma, Brocha, Relleno, Figura
    }

    public partial class Form1 : Form
    {
        Graphics g;
        Pen p;
        bool mouseDown, cambios, imagenAbierta;
        string ruta = "";
        ImageFormat formato;
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
        /// Limpia el picturebox. Si se realizaron cambios previamente, pregunta si se desea
        /// guardar o no.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cambios)
            {
                DialogResult dr = MessageBox.Show("Paint", "¿Desea guardar los cambios de " + Text + "?", MessageBoxButtons.YesNoCancel);
                switch (dr)
                {
                    case DialogResult.Yes:
                        guardarToolStripMenuItem.PerformClick();
                        Text = "Sin título";
                        break;
                    case DialogResult.No:
                        canvas.Refresh();
                        canvas.Image = null;
                        Text = "Sin título";
                        break;
                    case DialogResult.Cancel:
                        break;
                }
            }
            else
            {
                Text = "Sin título";
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
            if(dr == DialogResult.OK && openFileDialog1.FileName != null)
            {
                if (cambios)
                {
                    DialogResult dr2 = MessageBox.Show("Paint", "¿Desea guardar los cambios de " + Text + "?", MessageBoxButtons.YesNoCancel);
                    switch (dr2)
                    {
                        case DialogResult.Yes:
                            //saveFileDialog1.ShowDialog();
                            guardarToolStripMenuItem.PerformClick();
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

                canvas.Image = (Image)Image.FromFile(openFileDialog1.FileName).Clone();
                imagenAbierta = true;
                ruta = openFileDialog1.FileName;
                formato = canvas.Image.RawFormat;
                FileInfo f = new FileInfo(ruta);
                Text = f.Name;
                openFileDialog1.Dispose();
                //string[] split = ruta.Split('.');
                //if(split.Length > 1)
                //{
                //    formato = split[split.Length - 1];
                //}
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
                saveFileDialog1.FilterIndex = 0;
            }
            else if (formato == ImageFormat.Jpeg)
            {
                saveFileDialog1.FilterIndex = 1;
            }
            else if (formato == ImageFormat.Bmp)
            {
                saveFileDialog1.FilterIndex = 2;
            }
            else if (formato == ImageFormat.Gif)
            {
                saveFileDialog1.FilterIndex = 3;
            }
            else
            {
                saveFileDialog1.FilterIndex = -1;
            }
            DialogResult dr = saveFileDialog1.ShowDialog();
            if (dr == DialogResult.OK && saveFileDialog1.FileName != null)
            {
                Image img = canvas.Image;
                img.Save(saveFileDialog1.FileName);
            }
        }

        private void acercaDePaintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Acerca de Paint", "Este Paint ha sido realizado por Rubén Tejo Pereira.");
        }

        /// <summary>
        /// Guarda la imagen creada sobre el picturebox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (imagenAbierta)
            {
                Bitmap bmp = new Bitmap(canvas.Width, canvas.Height);
                Graphics g = Graphics.FromImage(bmp);
                Rectangle rect = canvas.RectangleToScreen(canvas.ClientRectangle);
                g.CopyFromScreen(rect.Location, Point.Empty, canvas.Size);
                g.Dispose();

                //Image img = canvas.Image;

                //FileInfo fi = new FileInfo(ruta);
                //DirectoryInfo di = new DirectoryInfo(fi.DirectoryName);
                //foreach(FileInfo f in di.GetFiles())
                //{
                //    if(f.FullName == ruta)
                //    {
                //        try
                //        {
                //            f.Delete();
                //            break;
                //        }
                //        catch (IOException) { }
                //    }
                //}
                try
                {
                    if (File.Exists(ruta))
                    {
                        File.Delete(ruta);
                    }
                }
                catch (IOException) { }
                bmp.Save(ruta, formato);
            }
            else
            {   
                guardarComoToolStripMenuItem.PerformClick();
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
                case Herramientas.Relleno:
                    break;
                case Herramientas.Figura:
                    break;
            }
        }

        /// <summary>
        /// Detecta cuando se inicia la actividad dentro del picturebox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
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
        /// Detecta el fin de la actividad sobre el picturebox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left){
                mouseDown = false;
            }
        }
    }
}
