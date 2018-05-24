using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
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
        Graphics g;                                         //Componente Graphics del picturebox
        Pen p;                                              //Herramienta pen empleada para dibujar
        bool mouseDown;                                     //Indica si el ratón está pulsado
        bool cambios;                                       //Indica si se han realizado cambios
        bool imagenAbierta;                                 //Indica si se ha abierto una imagen
        bool rellenoActivado;                               //Indica si la herramienta de relleno está activada
        bool moving;                                        //Indica si el raton se está moviendo
        bool imagenAuxGuardada;                             //Indica (a la hora de dibujar figuras) si se ha guardado la imagen previa
        bool desaturar;                                     //Indica si la aplicación debe desaturar
        bool readOnly;                                      //Indica si la imagen abierta tiene unicamente permisos de lectura
        string ruta;                                        //Ruta de la imagen abierta
        ImageFormat formato;                                //Formato de la imagen abierta
        int tamañoLapiz;                                    //Tamaño de la herramienta lápiz
        int tamañoGoma;                                     //Tamaño de la herramienta goma
        int tamañoBrocha;                                   //Tamaño de la herramienta brocha
        int[] tamañosLapiz = { 1, 2, 3, 4, 5 };             //Array de tamaños que puede tomar el lápiz
        int[] tamañosGoma = { 10, 15, 20, 25, 30 };         //Array de tamaños que puede tomar la goma
        int[] tamañosBrocha = { 5, 6, 7, 8, 9, 10 };        //Array de tamaños que puede tomar la brocha
        Point inicio;                                       //Punto inicial de dibujado
        Point fin;                                          //Punto final de dibujado
        Point[] puntosTriangulo = new Point[3];             //Puntos del triangulo (cuando se dibujan triángulos)
        Image imgauxMouseMove;                              //Variable auxiliar que guarda la imagen previo dibujado de figuras
        Image imgauxDesaturar;                              //Variable auxiliar que guarda la imagen previo desaturado
        StreamReader stream;                                //Variable auxiliar necesaria para abrir imágenes
        Stream s;                                           //Variable auxiliar para el guardado de imágenes previas
        Stream sDesaturar;                                  //Variable auxiliar que ayuda al guardado de la imagen previo desaturado
        Rectangle r;                                        //Variable auxiliar para el dibujado de figuras
        Herramientas herramienta;                           //Herramienta de trabajo
        LinearGradientBrush gradiente;                      //Variable auxiliar que guarda el gradiente del relleno
        LinearGradientMode modoGradiente;                   //Variable auxiliar que guarda el modo del gradiente del relleno
        Form2 f;                                            //Formluario secundario de configuración del gradiente
        List<Stream> controlCambios = new List<Stream>();   //Lista de streams que sirve para simular la funcionalidad del Ctrl+Z

        ColorMatrix clrMatrix;                              //Matriz de color de desaturado
        ImageAttributes imgAttributes;                      //Variable auxiliar que guarda la matriz de color de desaturado


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
            ruta = "";
            g = canvas.CreateGraphics();
            tamañoLapiz = 1;
            tamañoGoma = 10;
            tamañoBrocha = 5;
            p = new Pen(Color.Black, tamañoLapiz);
            mouseDown = false;
            cambios = false;
            moving = false;
            readOnly = false;
            herramienta = Herramientas.Lapiz;
            inicio = new Point();
            fin = new Point();
            modoGradiente = LinearGradientMode.Horizontal;

            cboTamaños.DataSource = tamañosLapiz;
            cboTamaños.SelectedIndex = 0;

            canvas.Image = new Bitmap(canvas.Width, canvas.Height);
            g = Graphics.FromImage(canvas.Image);
            g.FillRectangle(Brushes.White, canvas.ClientRectangle);

            s = new MemoryStream();
            canvas.Image.Save(s, ImageFormat.Png);
            controlCambios.Add(s);

            //Inicializamos los componentes de la matriz de desaturado

            clrMatrix = new ColorMatrix();
            clrMatrix.Matrix00 = 0.11f;
            clrMatrix.Matrix01 = 0.11f;
            clrMatrix.Matrix02 = 0.11f;
            clrMatrix.Matrix10 = 0.59f;
            clrMatrix.Matrix11 = 0.59f;
            clrMatrix.Matrix12 = 0.59f;
            clrMatrix.Matrix20 = 0.3f;
            clrMatrix.Matrix21 = 0.3f;
            clrMatrix.Matrix22 = 0.3f;
            clrMatrix.Matrix33 = 1.0f;
            clrMatrix.Matrix44 = 1.0f;

            imgAttributes = new ImageAttributes();
            imgAttributes.SetColorMatrix(clrMatrix);
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
            if ((Button)sender == colorActual)
            {
                if (colorDialog1.ShowDialog() == DialogResult.OK)
                {
                    colorActual.BackColor = colorDialog1.Color;
                }
            }
            else
            {
                colorActual.BackColor = ((Button)sender).BackColor;
                p.Color = colorActual.BackColor;
            }

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
                cboTamaños.Enabled = true;
                chkGradiente.Enabled = false;
                btnConfigGradiente.Enabled = false;
                btnRelleno.BackColor = Color.Transparent;
                toolTip1.SetToolTip(cboTamaños, "Tamaño del lapiz");
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
                herramienta = Herramientas.Lapiz;
                lblTamaños.Text = "Tamaño del lápiz:";
                cboTamaños.DataSource = tamañosLapiz;
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
                cboTamaños.Enabled = true;
                chkGradiente.Enabled = false;
                btnConfigGradiente.Enabled = false;
                btnRelleno.BackColor = Color.Transparent;
                toolTip1.SetToolTip(cboTamaños, "Tamaño de la goma");
                herramienta = Herramientas.Goma;
                lblTamaños.Text = "Tamaño de la goma:";
                cboTamaños.DataSource = tamañosGoma;
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
                cboTamaños.Enabled = true;
                chkGradiente.Enabled = false;
                btnConfigGradiente.Enabled = false;
                btnRelleno.BackColor = Color.Transparent;
                toolTip1.SetToolTip(cboTamaños, "Tamaño de la brocha");
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                herramienta = Herramientas.Brocha;
                lblTamaños.Text = "Tamaño de la brocha:";
                cboTamaños.DataSource = tamañosBrocha;
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
                herramienta = Herramientas.Cuadrado;
                cboTamaños.Enabled = false;
                chkGradiente.Enabled = true;
                btnRelleno.BackColor = System.Drawing.SystemColors.ActiveBorder;
            }
            else if ((Button)sender == btnLinea)
            {
                herramienta = Herramientas.Linea;
                cboTamaños.Enabled = false;
            }
            else if ((Button)sender == btnCuadrado)
            {
                herramienta = Herramientas.Cuadrado;
                cboTamaños.Enabled = false;
            }
            else if ((Button)sender == btnTriangulo)
            {
                herramienta = Herramientas.Triangulo;
                cboTamaños.Enabled = false;
            }
            else if ((Button)sender == btnCirculo)
            {
                herramienta = Herramientas.Circulo;
                cboTamaños.Enabled = false;
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
                        goto case DialogResult.No;
                    case DialogResult.No:
                        Text = "Sin título";
                        g.Clear(Color.White);
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
                g.Clear(Color.White);
                cambios = false;
                imagenAbierta = false;
                ruta = "";
                canvas.Invalidate();
            }
        }

        /// <summary>
        /// Abre una imagen. Si se hubieran realizado cambios previamente, se da la 
        /// opción de guardarlos.
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

                try
                {
                    ruta = openFileDialog1.FileName;
                    FileInfo f = new FileInfo(ruta);
                    readOnly = f.IsReadOnly;
                    stream = new StreamReader(openFileDialog1.FileName);
                    canvas.Image = Image.FromStream(stream.BaseStream);
                    g = Graphics.FromImage(canvas.Image);
                    canvas.Invalidate();
                    imagenAbierta = true;
                    formato = canvas.Image.RawFormat;
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
                }
                catch (ArgumentException)
                {
                    MessageBox.Show("Ha ocurrido un problema al abrir el archivo. Inténtalo de nuevo o prueba con otro.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ruta = "";
                    cambios = false;
                    imagenAbierta = false;
                    readOnly = false;
                }
                catch (IOException)
                {
                    MessageBox.Show("Ha ocurrido un problema al abrir el archivo. Inténtalo de nuevo o prueba con otro.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ruta = "";
                    cambios = false;
                    imagenAbierta = false;
                    readOnly = false;
                }

                stream.Dispose();
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
            else
            {
                saveFileDialog1.FilterIndex = 0;
            }

            if (saveFileDialog1.ShowDialog() == DialogResult.OK && saveFileDialog1.FileName != null)
            {
                try
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
                    }
                }
                catch (System.Runtime.InteropServices.ExternalException)
                {
                    MessageBox.Show("Se denegó el acceso a " + ruta, "Paint", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        /// Lanza un formulario modal para configurar el gradiente del relleno.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfigGradiente_Click(object sender, EventArgs e)
        {
            if (f.ShowDialog() == DialogResult.OK)
            {
                if (f.rbHorizontal.Checked)
                {
                    modoGradiente = LinearGradientMode.Horizontal;
                }
                else if (f.rbVertical.Checked)
                {
                    modoGradiente = LinearGradientMode.Vertical;
                }
                else if (f.rbDAscendente.Checked)
                {
                    modoGradiente = LinearGradientMode.BackwardDiagonal;
                }
                else if (f.rbDDescendente.Checked)
                {
                    modoGradiente = LinearGradientMode.ForwardDiagonal;
                }
            }
        }

        /// <summary>
        /// Activa/desactiva la opción de gradiente del relleno. Al activarse lanza un formulario modal 
        /// para configurar dicho gradiente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkGradiente_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGradiente.Checked)
            {
                btnConfigGradiente.Enabled = true;
                toolTip1.SetToolTip(chkGradiente, "Gradiente activado");

                if (f == null)
                {
                    f = new Form2();
                    f.btnColor1.BackColor = colorActual.BackColor;
                    f.btnColor2.BackColor = colorActual.BackColor;
                }

                if (f.ShowDialog() == DialogResult.OK)
                {
                    if (f.rbHorizontal.Checked)
                    {
                        modoGradiente = LinearGradientMode.Horizontal;
                    }
                    else if (f.rbVertical.Checked)
                    {
                        modoGradiente = LinearGradientMode.Vertical;
                    }
                    else if (f.rbDAscendente.Checked)
                    {
                        modoGradiente = LinearGradientMode.BackwardDiagonal;
                    }
                    else if (f.rbDDescendente.Checked)
                    {
                        modoGradiente = LinearGradientMode.ForwardDiagonal;
                    }
                }
            }
            else
            {
                btnConfigGradiente.Enabled = false;
                toolTip1.SetToolTip(chkGradiente, "Gradiente desactivado");
            }
        }

        /// <summary>
        /// Activa/desactiva el saturado de la imagen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkDesaturar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDesaturar.Checked)
            {
                desaturar = true;
                toolTip1.SetToolTip(chkDesaturar, "Desaturado activado");
                sDesaturar = new MemoryStream();
                if (formato != null)
                {
                    canvas.Image.Save(sDesaturar, formato);
                }
                else
                {
                    canvas.Image.Save(sDesaturar, ImageFormat.Png);
                }
                imgauxDesaturar = Image.FromStream(sDesaturar);

                g.Clear(Color.White);
                g.DrawImage(imgauxDesaturar, canvas.ClientRectangle, 0, 0, canvas.Image.Width, canvas.Image.Height, GraphicsUnit.Pixel, imgAttributes);
                sDesaturar.Dispose();
            }
            else
            {
                toolTip1.SetToolTip(chkDesaturar, "Desaturado desactivado");
                if (imgauxDesaturar != null && desaturar)
                {
                    g.Clear(Color.White);
                    g.DrawImage(imgauxDesaturar, canvas.ClientRectangle);
                }
            }
            canvas.Invalidate();
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
                else if (e.KeyCode == Keys.Z)
                {
                    if (controlCambios.Count > 0)
                    {
                        if (controlCambios.Count > 1)
                        {
                            controlCambios.RemoveAt(controlCambios.Count - 1);
                        }
                        else
                        {
                            if (!imagenAbierta) cambios = false;
                            else cambios = true;
                        }
                        g.Clear(Color.White);
                        g.DrawImage(Image.FromStream(controlCambios.ElementAt(controlCambios.Count - 1)), canvas.ClientRectangle);

                        canvas.Invalidate();
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
                if ((imagenAbierta || ruta.Length != 0) && !readOnly)
                {
                    try
                    {
                        canvas.Image.Save(ruta, formato);
                        cambios = false;
                    }
                    catch (System.Runtime.InteropServices.ExternalException)
                    {
                        MessageBox.Show("Se denegó el acceso a " + ruta, "Paint", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    guardarComoToolStripMenuItem.PerformClick();
                }
            }
        }

        /// <summary>
        /// Detecta cuando se inicia la actividad dentro del picturebox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            desaturar = false;
            chkDesaturar.Checked = false;
            if (e.Button == MouseButtons.Left)
            {
                mouseDown = true;
                imagenAuxGuardada = false;
                moving = false;
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
            moving = true;

            if (mouseDown)
            {
                switch (herramienta)
                {
                    case Herramientas.Lapiz:
                        p.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                        p.EndCap = p.StartCap;
                        p.Color = colorActual.BackColor;
                        p.Width = tamañoLapiz;
                        g.DrawLine(p, inicio, fin);
                        inicio = fin;
                        break;
                    case Herramientas.Goma:
                        p.StartCap = System.Drawing.Drawing2D.LineCap.Square;
                        p.EndCap = p.StartCap;
                        p.Color = Color.White;
                        p.Width = tamañoGoma;
                        g.DrawLine(p, inicio, fin);
                        inicio = fin;
                        //g.FillRectangle(new SolidBrush(canvas.BackColor), e.X, e.Y, tamañoGoma, tamañoGoma);
                        break;
                    case Herramientas.Brocha:
                        p.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                        p.EndCap = p.StartCap;
                        p.Color = colorActual.BackColor;
                        p.Width = tamañoBrocha;
                        g.DrawLine(p, inicio, fin);
                        inicio = fin;
                        break;
                    case Herramientas.Linea:
                        if (!imagenAuxGuardada)
                        {
                            s = new MemoryStream();
                            canvas.Image.Save(s, ImageFormat.Png);
                            imgauxMouseMove = Image.FromStream(s);
                            imagenAuxGuardada = true;
                        }
                        g.Clear(Color.White);
                        g.DrawImage(imgauxMouseMove, canvas.ClientRectangle);
                        g.DrawLine(new Pen(colorActual.BackColor, 3), inicio, fin);
                        s.Dispose();
                        break;
                    case Herramientas.Cuadrado:
                        if (!imagenAuxGuardada)
                        {
                            s = new MemoryStream();
                            canvas.Image.Save(s, ImageFormat.Png);
                            imgauxMouseMove = Image.FromStream(s);
                            imagenAuxGuardada = true;
                        }
                        g.Clear(Color.White);
                        g.DrawImage(imgauxMouseMove, canvas.ClientRectangle);

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
                            if (chkGradiente.Checked)
                            {
                                try
                                {
                                    gradiente = new LinearGradientBrush(r, f.btnColor1.BackColor, f.btnColor2.BackColor, modoGradiente);
                                }
                                catch (ArgumentException) { }
                                try
                                {
                                    g.FillRectangle(gradiente, r);
                                }
                                catch (ArgumentNullException)
                                {
                                    g.FillRectangle(new SolidBrush(colorActual.BackColor), r);
                                }
                            }
                            else
                            {
                                g.FillRectangle(new SolidBrush(colorActual.BackColor), r);
                            }
                        }
                        else
                        {
                            g.DrawRectangle(new Pen(colorActual.BackColor, 3), r);
                        }
                        s.Dispose();
                        break;
                    case Herramientas.Triangulo:
                        if (!imagenAuxGuardada)
                        {
                            s = new MemoryStream();
                            canvas.Image.Save(s, ImageFormat.Png);
                            imgauxMouseMove = Image.FromStream(s);
                            imagenAuxGuardada = true;
                        }
                        g.Clear(Color.White);
                        g.DrawImage(imgauxMouseMove, canvas.ClientRectangle);

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

                        puntosTriangulo[0] = new Point(r.Right - r.Width / 2, r.Top);
                        puntosTriangulo[1] = new Point(r.Right, r.Bottom);
                        puntosTriangulo[2] = new Point(r.Left, r.Bottom);

                        if (rellenoActivado)
                        {
                            if (chkGradiente.Checked)
                            {
                                try
                                {
                                    gradiente = new LinearGradientBrush(r, f.btnColor1.BackColor, f.btnColor2.BackColor, modoGradiente);
                                }
                                catch (ArgumentException) { }
                                try
                                {
                                    g.FillPolygon(gradiente, puntosTriangulo);
                                }
                                catch (ArgumentNullException)
                                {
                                    g.FillPolygon(new SolidBrush(colorActual.BackColor), puntosTriangulo);
                                }
                            }
                            else
                            {
                                g.FillPolygon(new SolidBrush(colorActual.BackColor), puntosTriangulo);
                            }
                        }
                        else
                        {
                            g.DrawPolygon(new Pen(colorActual.BackColor, 3), puntosTriangulo);
                        }
                        s.Dispose();
                        break;
                    case Herramientas.Circulo:
                        if (!imagenAuxGuardada)
                        {
                            s = new MemoryStream();
                            canvas.Image.Save(s, ImageFormat.Png);
                            imgauxMouseMove = Image.FromStream(s);
                            imagenAuxGuardada = true;
                        }
                        g.Clear(Color.White);
                        g.DrawImage(imgauxMouseMove, canvas.ClientRectangle);

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
                            if (chkGradiente.Checked)
                            {
                                try
                                {
                                    gradiente = new LinearGradientBrush(r, f.btnColor1.BackColor, f.btnColor2.BackColor, modoGradiente);
                                }
                                catch (ArgumentException) { }
                                try
                                {
                                    g.FillEllipse(gradiente, r);
                                }
                                catch (ArgumentNullException)
                                {
                                    g.FillEllipse(new SolidBrush(colorActual.BackColor), r);
                                }
                            }
                            else
                            {
                                g.FillEllipse(new SolidBrush(colorActual.BackColor), r);
                            }
                        }
                        else
                        {
                            g.DrawEllipse(new Pen(colorActual.BackColor, 3), r);
                        }
                        s.Dispose();
                        break;
                }
            }

            canvas.Invalidate();
        }

        /// <summary>
        /// Detecta el fin de la actividad sobre el picturebox. Ademas efectúa los cambios procedentes sobre el picturebox
        /// si se detecta un click sin movimiento sobre él.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseDown = false;
                imagenAuxGuardada = false;
                if (!moving)
                {
                    switch (herramienta)
                    {
                        case Herramientas.Lapiz:
                            g.FillEllipse(new SolidBrush(colorActual.BackColor), inicio.X - tamañoLapiz / 2, inicio.Y - tamañoLapiz / 2, tamañoLapiz, tamañoLapiz);
                            break;
                        case Herramientas.Goma:
                            g.FillRectangle(new SolidBrush(canvas.BackColor), inicio.X - tamañoGoma / 2, inicio.Y - tamañoGoma / 2, tamañoGoma, tamañoGoma);
                            break;
                        case Herramientas.Brocha:
                            g.FillEllipse(new SolidBrush(colorActual.BackColor), inicio.X - tamañoBrocha / 2, inicio.Y - tamañoBrocha / 2, tamañoBrocha, tamañoBrocha);
                            break;
                    }
                    canvas.Invalidate();
                }
                moving = false;

                s = new MemoryStream();
                if (formato != null)
                {
                    canvas.Image.Save(s, formato);
                }
                else
                {
                    canvas.Image.Save(s, ImageFormat.Png);
                }
                controlCambios.Add(s);
            }
        }
    }
}
