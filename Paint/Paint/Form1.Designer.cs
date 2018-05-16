namespace Paint
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarComoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.acercaDePaintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grbTamaños = new System.Windows.Forms.GroupBox();
            this.lblTamaños = new System.Windows.Forms.Label();
            this.cboTamaños = new System.Windows.Forms.ComboBox();
            this.grbFiguras = new System.Windows.Forms.GroupBox();
            this.btnCirculo = new System.Windows.Forms.Button();
            this.btnTriangulo = new System.Windows.Forms.Button();
            this.btnCuadrado = new System.Windows.Forms.Button();
            this.btnLinea = new System.Windows.Forms.Button();
            this.grbColores = new System.Windows.Forms.GroupBox();
            this.colorActual = new System.Windows.Forms.Label();
            this.btnVioleta = new System.Windows.Forms.Button();
            this.btnAzulGrisaceo = new System.Windows.Forms.Button();
            this.btnBlanco = new System.Windows.Forms.Button();
            this.btnAzulClaro = new System.Windows.Forms.Button();
            this.btnLima = new System.Windows.Forms.Button();
            this.btnAmarilloClaro = new System.Windows.Forms.Button();
            this.btnDorado = new System.Windows.Forms.Button();
            this.btnRosa = new System.Windows.Forms.Button();
            this.btnMarron = new System.Windows.Forms.Button();
            this.btnGrisClaro = new System.Windows.Forms.Button();
            this.btnMorado = new System.Windows.Forms.Button();
            this.btnAzulOscuro = new System.Windows.Forms.Button();
            this.btnNegro = new System.Windows.Forms.Button();
            this.btnAzul = new System.Windows.Forms.Button();
            this.btnVerde = new System.Windows.Forms.Button();
            this.btnAmarillo = new System.Windows.Forms.Button();
            this.btnNaranja = new System.Windows.Forms.Button();
            this.btnRojo = new System.Windows.Forms.Button();
            this.btnRojoOcuro = new System.Windows.Forms.Button();
            this.btnGris = new System.Windows.Forms.Button();
            this.grbHerramientas = new System.Windows.Forms.GroupBox();
            this.btnRelleno = new System.Windows.Forms.Button();
            this.btnBrocha = new System.Windows.Forms.Button();
            this.btnGoma = new System.Windows.Forms.Button();
            this.btnLapiz = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblCoordenadas = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.canvas = new System.Windows.Forms.PictureBox();
            this.limpiarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.grbTamaños.SuspendLayout();
            this.grbFiguras.SuspendLayout();
            this.grbColores.SuspendLayout();
            this.grbHerramientas.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.limpiarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(706, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.abrirToolStripMenuItem,
            this.guardarToolStripMenuItem,
            this.guardarComoToolStripMenuItem,
            this.toolStripMenuItem1,
            this.acercaDePaintToolStripMenuItem,
            this.toolStripMenuItem2,
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "A&rchivo";
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.nuevoToolStripMenuItem.Text = "&Nuevo";
            this.nuevoToolStripMenuItem.Click += new System.EventHandler(this.nuevoToolStripMenuItem_Click);
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.abrirToolStripMenuItem.Text = "&Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.guardarToolStripMenuItem.Text = "&Guardar";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click);
            // 
            // guardarComoToolStripMenuItem
            // 
            this.guardarComoToolStripMenuItem.Name = "guardarComoToolStripMenuItem";
            this.guardarComoToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.guardarComoToolStripMenuItem.Text = "Guardar c&omo";
            this.guardarComoToolStripMenuItem.Click += new System.EventHandler(this.guardarComoToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(153, 6);
            // 
            // acercaDePaintToolStripMenuItem
            // 
            this.acercaDePaintToolStripMenuItem.Name = "acercaDePaintToolStripMenuItem";
            this.acercaDePaintToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.acercaDePaintToolStripMenuItem.Text = "Acerca de &Paint";
            this.acercaDePaintToolStripMenuItem.Click += new System.EventHandler(this.acercaDePaintToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(153, 6);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.salirToolStripMenuItem.Text = "&Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grbTamaños);
            this.panel1.Controls.Add(this.grbFiguras);
            this.panel1.Controls.Add(this.grbColores);
            this.panel1.Controls.Add(this.grbHerramientas);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(706, 100);
            this.panel1.TabIndex = 1;
            // 
            // grbTamaños
            // 
            this.grbTamaños.Controls.Add(this.lblTamaños);
            this.grbTamaños.Controls.Add(this.cboTamaños);
            this.grbTamaños.Location = new System.Drawing.Point(99, 3);
            this.grbTamaños.Name = "grbTamaños";
            this.grbTamaños.Size = new System.Drawing.Size(127, 94);
            this.grbTamaños.TabIndex = 4;
            this.grbTamaños.TabStop = false;
            this.grbTamaños.Text = "Tamaños";
            // 
            // lblTamaños
            // 
            this.lblTamaños.AutoSize = true;
            this.lblTamaños.Location = new System.Drawing.Point(6, 25);
            this.lblTamaños.Name = "lblTamaños";
            this.lblTamaños.Size = new System.Drawing.Size(90, 13);
            this.lblTamaños.TabIndex = 1;
            this.lblTamaños.Text = "Tamaño del lápiz:";
            // 
            // cboTamaños
            // 
            this.cboTamaños.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTamaños.FormattingEnabled = true;
            this.cboTamaños.Location = new System.Drawing.Point(9, 41);
            this.cboTamaños.Name = "cboTamaños";
            this.cboTamaños.Size = new System.Drawing.Size(87, 21);
            this.cboTamaños.TabIndex = 0;
            this.cboTamaños.SelectedIndexChanged += new System.EventHandler(this.cboTamaños_SelectedIndexChanged);
            // 
            // grbFiguras
            // 
            this.grbFiguras.Controls.Add(this.btnCirculo);
            this.grbFiguras.Controls.Add(this.btnTriangulo);
            this.grbFiguras.Controls.Add(this.btnCuadrado);
            this.grbFiguras.Controls.Add(this.btnLinea);
            this.grbFiguras.Location = new System.Drawing.Point(613, 3);
            this.grbFiguras.Name = "grbFiguras";
            this.grbFiguras.Size = new System.Drawing.Size(86, 94);
            this.grbFiguras.TabIndex = 2;
            this.grbFiguras.TabStop = false;
            this.grbFiguras.Text = "Figuras";
            // 
            // btnCirculo
            // 
            this.btnCirculo.BackColor = System.Drawing.Color.Transparent;
            this.btnCirculo.Image = global::Paint.Properties.Resources.circulo;
            this.btnCirculo.Location = new System.Drawing.Point(46, 55);
            this.btnCirculo.Name = "btnCirculo";
            this.btnCirculo.Size = new System.Drawing.Size(30, 30);
            this.btnCirculo.TabIndex = 5;
            this.btnCirculo.UseVisualStyleBackColor = false;
            this.btnCirculo.Click += new System.EventHandler(this.herramientas_Click);
            // 
            // btnTriangulo
            // 
            this.btnTriangulo.BackColor = System.Drawing.Color.Transparent;
            this.btnTriangulo.Image = global::Paint.Properties.Resources.triangulo;
            this.btnTriangulo.Location = new System.Drawing.Point(10, 55);
            this.btnTriangulo.Name = "btnTriangulo";
            this.btnTriangulo.Size = new System.Drawing.Size(30, 30);
            this.btnTriangulo.TabIndex = 4;
            this.btnTriangulo.UseVisualStyleBackColor = false;
            this.btnTriangulo.Click += new System.EventHandler(this.herramientas_Click);
            // 
            // btnCuadrado
            // 
            this.btnCuadrado.BackColor = System.Drawing.Color.Transparent;
            this.btnCuadrado.Image = global::Paint.Properties.Resources.cuadrado;
            this.btnCuadrado.Location = new System.Drawing.Point(46, 19);
            this.btnCuadrado.Name = "btnCuadrado";
            this.btnCuadrado.Size = new System.Drawing.Size(30, 30);
            this.btnCuadrado.TabIndex = 3;
            this.btnCuadrado.UseVisualStyleBackColor = false;
            this.btnCuadrado.Click += new System.EventHandler(this.herramientas_Click);
            // 
            // btnLinea
            // 
            this.btnLinea.BackColor = System.Drawing.Color.Transparent;
            this.btnLinea.Image = global::Paint.Properties.Resources.linea;
            this.btnLinea.Location = new System.Drawing.Point(10, 19);
            this.btnLinea.Name = "btnLinea";
            this.btnLinea.Size = new System.Drawing.Size(30, 30);
            this.btnLinea.TabIndex = 2;
            this.btnLinea.UseVisualStyleBackColor = false;
            this.btnLinea.Click += new System.EventHandler(this.herramientas_Click);
            // 
            // grbColores
            // 
            this.grbColores.Controls.Add(this.colorActual);
            this.grbColores.Controls.Add(this.btnVioleta);
            this.grbColores.Controls.Add(this.btnAzulGrisaceo);
            this.grbColores.Controls.Add(this.btnBlanco);
            this.grbColores.Controls.Add(this.btnAzulClaro);
            this.grbColores.Controls.Add(this.btnLima);
            this.grbColores.Controls.Add(this.btnAmarilloClaro);
            this.grbColores.Controls.Add(this.btnDorado);
            this.grbColores.Controls.Add(this.btnRosa);
            this.grbColores.Controls.Add(this.btnMarron);
            this.grbColores.Controls.Add(this.btnGrisClaro);
            this.grbColores.Controls.Add(this.btnMorado);
            this.grbColores.Controls.Add(this.btnAzulOscuro);
            this.grbColores.Controls.Add(this.btnNegro);
            this.grbColores.Controls.Add(this.btnAzul);
            this.grbColores.Controls.Add(this.btnVerde);
            this.grbColores.Controls.Add(this.btnAmarillo);
            this.grbColores.Controls.Add(this.btnNaranja);
            this.grbColores.Controls.Add(this.btnRojo);
            this.grbColores.Controls.Add(this.btnRojoOcuro);
            this.grbColores.Controls.Add(this.btnGris);
            this.grbColores.Location = new System.Drawing.Point(232, 3);
            this.grbColores.Name = "grbColores";
            this.grbColores.Size = new System.Drawing.Size(375, 94);
            this.grbColores.TabIndex = 1;
            this.grbColores.TabStop = false;
            this.grbColores.Text = "Colores";
            // 
            // colorActual
            // 
            this.colorActual.BackColor = System.Drawing.Color.Black;
            this.colorActual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.colorActual.Location = new System.Drawing.Point(6, 19);
            this.colorActual.Name = "colorActual";
            this.colorActual.Size = new System.Drawing.Size(50, 56);
            this.colorActual.TabIndex = 20;
            // 
            // btnVioleta
            // 
            this.btnVioleta.BackColor = System.Drawing.Color.Violet;
            this.btnVioleta.Location = new System.Drawing.Point(341, 50);
            this.btnVioleta.Name = "btnVioleta";
            this.btnVioleta.Size = new System.Drawing.Size(25, 25);
            this.btnVioleta.TabIndex = 19;
            this.btnVioleta.UseVisualStyleBackColor = false;
            this.btnVioleta.Click += new System.EventHandler(this.colores_Click);
            // 
            // btnAzulGrisaceo
            // 
            this.btnAzulGrisaceo.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnAzulGrisaceo.Location = new System.Drawing.Point(310, 50);
            this.btnAzulGrisaceo.Name = "btnAzulGrisaceo";
            this.btnAzulGrisaceo.Size = new System.Drawing.Size(25, 25);
            this.btnAzulGrisaceo.TabIndex = 18;
            this.btnAzulGrisaceo.UseVisualStyleBackColor = false;
            this.btnAzulGrisaceo.Click += new System.EventHandler(this.colores_Click);
            // 
            // btnBlanco
            // 
            this.btnBlanco.BackColor = System.Drawing.Color.White;
            this.btnBlanco.Location = new System.Drawing.Point(62, 50);
            this.btnBlanco.Name = "btnBlanco";
            this.btnBlanco.Size = new System.Drawing.Size(25, 25);
            this.btnBlanco.TabIndex = 17;
            this.btnBlanco.UseVisualStyleBackColor = false;
            this.btnBlanco.Click += new System.EventHandler(this.colores_Click);
            // 
            // btnAzulClaro
            // 
            this.btnAzulClaro.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnAzulClaro.Location = new System.Drawing.Point(279, 50);
            this.btnAzulClaro.Name = "btnAzulClaro";
            this.btnAzulClaro.Size = new System.Drawing.Size(25, 25);
            this.btnAzulClaro.TabIndex = 16;
            this.btnAzulClaro.UseVisualStyleBackColor = false;
            this.btnAzulClaro.Click += new System.EventHandler(this.colores_Click);
            // 
            // btnLima
            // 
            this.btnLima.BackColor = System.Drawing.Color.Lime;
            this.btnLima.Location = new System.Drawing.Point(248, 50);
            this.btnLima.Name = "btnLima";
            this.btnLima.Size = new System.Drawing.Size(25, 25);
            this.btnLima.TabIndex = 15;
            this.btnLima.UseVisualStyleBackColor = false;
            this.btnLima.Click += new System.EventHandler(this.colores_Click);
            // 
            // btnAmarilloClaro
            // 
            this.btnAmarilloClaro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAmarilloClaro.Location = new System.Drawing.Point(217, 50);
            this.btnAmarilloClaro.Name = "btnAmarilloClaro";
            this.btnAmarilloClaro.Size = new System.Drawing.Size(25, 25);
            this.btnAmarilloClaro.TabIndex = 14;
            this.btnAmarilloClaro.UseVisualStyleBackColor = false;
            this.btnAmarilloClaro.Click += new System.EventHandler(this.colores_Click);
            // 
            // btnDorado
            // 
            this.btnDorado.BackColor = System.Drawing.Color.Gold;
            this.btnDorado.Location = new System.Drawing.Point(186, 50);
            this.btnDorado.Name = "btnDorado";
            this.btnDorado.Size = new System.Drawing.Size(25, 25);
            this.btnDorado.TabIndex = 13;
            this.btnDorado.UseVisualStyleBackColor = false;
            this.btnDorado.Click += new System.EventHandler(this.colores_Click);
            // 
            // btnRosa
            // 
            this.btnRosa.BackColor = System.Drawing.Color.Pink;
            this.btnRosa.Location = new System.Drawing.Point(155, 50);
            this.btnRosa.Name = "btnRosa";
            this.btnRosa.Size = new System.Drawing.Size(25, 25);
            this.btnRosa.TabIndex = 12;
            this.btnRosa.UseVisualStyleBackColor = false;
            this.btnRosa.Click += new System.EventHandler(this.colores_Click);
            // 
            // btnMarron
            // 
            this.btnMarron.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnMarron.Location = new System.Drawing.Point(124, 50);
            this.btnMarron.Name = "btnMarron";
            this.btnMarron.Size = new System.Drawing.Size(25, 25);
            this.btnMarron.TabIndex = 11;
            this.btnMarron.UseVisualStyleBackColor = false;
            this.btnMarron.Click += new System.EventHandler(this.colores_Click);
            // 
            // btnGrisClaro
            // 
            this.btnGrisClaro.BackColor = System.Drawing.Color.DarkGray;
            this.btnGrisClaro.Location = new System.Drawing.Point(93, 50);
            this.btnGrisClaro.Name = "btnGrisClaro";
            this.btnGrisClaro.Size = new System.Drawing.Size(25, 25);
            this.btnGrisClaro.TabIndex = 10;
            this.btnGrisClaro.UseVisualStyleBackColor = false;
            this.btnGrisClaro.Click += new System.EventHandler(this.colores_Click);
            // 
            // btnMorado
            // 
            this.btnMorado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnMorado.Location = new System.Drawing.Point(341, 19);
            this.btnMorado.Name = "btnMorado";
            this.btnMorado.Size = new System.Drawing.Size(25, 25);
            this.btnMorado.TabIndex = 9;
            this.btnMorado.UseVisualStyleBackColor = false;
            this.btnMorado.Click += new System.EventHandler(this.colores_Click);
            // 
            // btnAzulOscuro
            // 
            this.btnAzulOscuro.BackColor = System.Drawing.Color.Blue;
            this.btnAzulOscuro.Location = new System.Drawing.Point(310, 19);
            this.btnAzulOscuro.Name = "btnAzulOscuro";
            this.btnAzulOscuro.Size = new System.Drawing.Size(25, 25);
            this.btnAzulOscuro.TabIndex = 8;
            this.btnAzulOscuro.UseVisualStyleBackColor = false;
            this.btnAzulOscuro.Click += new System.EventHandler(this.colores_Click);
            // 
            // btnNegro
            // 
            this.btnNegro.BackColor = System.Drawing.Color.Black;
            this.btnNegro.Location = new System.Drawing.Point(62, 19);
            this.btnNegro.Name = "btnNegro";
            this.btnNegro.Size = new System.Drawing.Size(25, 25);
            this.btnNegro.TabIndex = 7;
            this.btnNegro.UseVisualStyleBackColor = false;
            this.btnNegro.Click += new System.EventHandler(this.colores_Click);
            // 
            // btnAzul
            // 
            this.btnAzul.BackColor = System.Drawing.Color.Turquoise;
            this.btnAzul.Location = new System.Drawing.Point(279, 19);
            this.btnAzul.Name = "btnAzul";
            this.btnAzul.Size = new System.Drawing.Size(25, 25);
            this.btnAzul.TabIndex = 6;
            this.btnAzul.UseVisualStyleBackColor = false;
            this.btnAzul.Click += new System.EventHandler(this.colores_Click);
            // 
            // btnVerde
            // 
            this.btnVerde.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnVerde.Location = new System.Drawing.Point(248, 19);
            this.btnVerde.Name = "btnVerde";
            this.btnVerde.Size = new System.Drawing.Size(25, 25);
            this.btnVerde.TabIndex = 5;
            this.btnVerde.UseVisualStyleBackColor = false;
            this.btnVerde.Click += new System.EventHandler(this.colores_Click);
            // 
            // btnAmarillo
            // 
            this.btnAmarillo.BackColor = System.Drawing.Color.Yellow;
            this.btnAmarillo.Location = new System.Drawing.Point(217, 19);
            this.btnAmarillo.Name = "btnAmarillo";
            this.btnAmarillo.Size = new System.Drawing.Size(25, 25);
            this.btnAmarillo.TabIndex = 4;
            this.btnAmarillo.UseVisualStyleBackColor = false;
            this.btnAmarillo.Click += new System.EventHandler(this.colores_Click);
            // 
            // btnNaranja
            // 
            this.btnNaranja.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnNaranja.Location = new System.Drawing.Point(186, 19);
            this.btnNaranja.Name = "btnNaranja";
            this.btnNaranja.Size = new System.Drawing.Size(25, 25);
            this.btnNaranja.TabIndex = 3;
            this.btnNaranja.UseVisualStyleBackColor = false;
            this.btnNaranja.Click += new System.EventHandler(this.colores_Click);
            // 
            // btnRojo
            // 
            this.btnRojo.BackColor = System.Drawing.Color.Red;
            this.btnRojo.Location = new System.Drawing.Point(155, 19);
            this.btnRojo.Name = "btnRojo";
            this.btnRojo.Size = new System.Drawing.Size(25, 25);
            this.btnRojo.TabIndex = 2;
            this.btnRojo.UseVisualStyleBackColor = false;
            this.btnRojo.Click += new System.EventHandler(this.colores_Click);
            // 
            // btnRojoOcuro
            // 
            this.btnRojoOcuro.BackColor = System.Drawing.Color.DarkRed;
            this.btnRojoOcuro.Location = new System.Drawing.Point(124, 19);
            this.btnRojoOcuro.Name = "btnRojoOcuro";
            this.btnRojoOcuro.Size = new System.Drawing.Size(25, 25);
            this.btnRojoOcuro.TabIndex = 1;
            this.btnRojoOcuro.UseVisualStyleBackColor = false;
            this.btnRojoOcuro.Click += new System.EventHandler(this.colores_Click);
            // 
            // btnGris
            // 
            this.btnGris.BackColor = System.Drawing.Color.Gray;
            this.btnGris.Location = new System.Drawing.Point(93, 19);
            this.btnGris.Name = "btnGris";
            this.btnGris.Size = new System.Drawing.Size(25, 25);
            this.btnGris.TabIndex = 0;
            this.btnGris.UseVisualStyleBackColor = false;
            this.btnGris.Click += new System.EventHandler(this.colores_Click);
            // 
            // grbHerramientas
            // 
            this.grbHerramientas.Controls.Add(this.btnRelleno);
            this.grbHerramientas.Controls.Add(this.btnBrocha);
            this.grbHerramientas.Controls.Add(this.btnGoma);
            this.grbHerramientas.Controls.Add(this.btnLapiz);
            this.grbHerramientas.Location = new System.Drawing.Point(7, 3);
            this.grbHerramientas.Name = "grbHerramientas";
            this.grbHerramientas.Size = new System.Drawing.Size(86, 94);
            this.grbHerramientas.TabIndex = 0;
            this.grbHerramientas.TabStop = false;
            this.grbHerramientas.Text = "Herramientas";
            // 
            // btnRelleno
            // 
            this.btnRelleno.BackColor = System.Drawing.Color.Transparent;
            this.btnRelleno.Image = global::Paint.Properties.Resources.relleno;
            this.btnRelleno.Location = new System.Drawing.Point(45, 55);
            this.btnRelleno.Name = "btnRelleno";
            this.btnRelleno.Size = new System.Drawing.Size(30, 30);
            this.btnRelleno.TabIndex = 3;
            this.btnRelleno.UseVisualStyleBackColor = false;
            this.btnRelleno.Click += new System.EventHandler(this.herramientas_Click);
            // 
            // btnBrocha
            // 
            this.btnBrocha.BackColor = System.Drawing.Color.Transparent;
            this.btnBrocha.Image = global::Paint.Properties.Resources.brocha;
            this.btnBrocha.Location = new System.Drawing.Point(9, 55);
            this.btnBrocha.Name = "btnBrocha";
            this.btnBrocha.Size = new System.Drawing.Size(30, 30);
            this.btnBrocha.TabIndex = 2;
            this.btnBrocha.UseVisualStyleBackColor = false;
            this.btnBrocha.Click += new System.EventHandler(this.herramientas_Click);
            // 
            // btnGoma
            // 
            this.btnGoma.BackColor = System.Drawing.Color.Transparent;
            this.btnGoma.Image = global::Paint.Properties.Resources.goma;
            this.btnGoma.Location = new System.Drawing.Point(45, 19);
            this.btnGoma.Name = "btnGoma";
            this.btnGoma.Size = new System.Drawing.Size(30, 30);
            this.btnGoma.TabIndex = 1;
            this.btnGoma.UseVisualStyleBackColor = false;
            this.btnGoma.Click += new System.EventHandler(this.herramientas_Click);
            // 
            // btnLapiz
            // 
            this.btnLapiz.BackColor = System.Drawing.Color.Transparent;
            this.btnLapiz.Image = global::Paint.Properties.Resources.lapiz;
            this.btnLapiz.Location = new System.Drawing.Point(9, 19);
            this.btnLapiz.Name = "btnLapiz";
            this.btnLapiz.Size = new System.Drawing.Size(30, 30);
            this.btnLapiz.TabIndex = 0;
            this.btnLapiz.UseVisualStyleBackColor = false;
            this.btnLapiz.Click += new System.EventHandler(this.herramientas_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Todos los archivos de imagen|*.png;*.jpg;*.jpeg;*.bmp;*.gif|PNG|*.png|JPEG|*.jpeg" +
    ";*.jpg|BMP|*.bmp|GIF|*.gif";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "PNG|*.png|JPEG|*.jpeg;*.jpg|BMP|*.bmp|GIF|*.gif";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblCoordenadas);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 541);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(706, 20);
            this.panel3.TabIndex = 3;
            // 
            // lblCoordenadas
            // 
            this.lblCoordenadas.AutoSize = true;
            this.lblCoordenadas.Location = new System.Drawing.Point(4, 3);
            this.lblCoordenadas.Name = "lblCoordenadas";
            this.lblCoordenadas.Size = new System.Drawing.Size(70, 13);
            this.lblCoordenadas.TabIndex = 0;
            this.lblCoordenadas.Text = "Coordenadas";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.canvas);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 124);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(7);
            this.panel2.Size = new System.Drawing.Size(706, 417);
            this.panel2.TabIndex = 4;
            // 
            // canvas
            // 
            this.canvas.BackColor = System.Drawing.Color.White;
            this.canvas.Location = new System.Drawing.Point(7, 7);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(692, 397);
            this.canvas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.canvas.TabIndex = 3;
            this.canvas.TabStop = false;
            this.canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseDown);
            this.canvas.MouseLeave += new System.EventHandler(this.canvas_MouseLeave);
            this.canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseMove);
            this.canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseUp);
            // 
            // limpiarToolStripMenuItem
            // 
            this.limpiarToolStripMenuItem.Name = "limpiarToolStripMenuItem";
            this.limpiarToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.limpiarToolStripMenuItem.Text = "&Limpiar";
            this.limpiarToolStripMenuItem.Click += new System.EventHandler(this.limpiarToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 561);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Paint";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.grbTamaños.ResumeLayout(false);
            this.grbTamaños.PerformLayout();
            this.grbFiguras.ResumeLayout(false);
            this.grbColores.ResumeLayout(false);
            this.grbHerramientas.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarComoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem acercaDePaintToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox grbHerramientas;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.GroupBox grbFiguras;
        private System.Windows.Forms.GroupBox grbColores;
        private System.Windows.Forms.Button btnVioleta;
        private System.Windows.Forms.Button btnAzulGrisaceo;
        private System.Windows.Forms.Button btnBlanco;
        private System.Windows.Forms.Button btnAzulClaro;
        private System.Windows.Forms.Button btnLima;
        private System.Windows.Forms.Button btnAmarilloClaro;
        private System.Windows.Forms.Button btnDorado;
        private System.Windows.Forms.Button btnRosa;
        private System.Windows.Forms.Button btnMarron;
        private System.Windows.Forms.Button btnGrisClaro;
        private System.Windows.Forms.Button btnMorado;
        private System.Windows.Forms.Button btnAzulOscuro;
        private System.Windows.Forms.Button btnNegro;
        private System.Windows.Forms.Button btnAzul;
        private System.Windows.Forms.Button btnVerde;
        private System.Windows.Forms.Button btnAmarillo;
        private System.Windows.Forms.Button btnNaranja;
        private System.Windows.Forms.Button btnRojo;
        private System.Windows.Forms.Button btnRojoOcuro;
        private System.Windows.Forms.Button btnGris;
        private System.Windows.Forms.Button btnLapiz;
        private System.Windows.Forms.Button btnRelleno;
        private System.Windows.Forms.Button btnBrocha;
        private System.Windows.Forms.Button btnGoma;
        private System.Windows.Forms.GroupBox grbTamaños;
        private System.Windows.Forms.Label lblTamaños;
        private System.Windows.Forms.ComboBox cboTamaños;
        private System.Windows.Forms.Button btnLinea;
        private System.Windows.Forms.Button btnTriangulo;
        private System.Windows.Forms.Button btnCuadrado;
        private System.Windows.Forms.Button btnCirculo;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblCoordenadas;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.Label colorActual;
        private System.Windows.Forms.ToolStripMenuItem limpiarToolStripMenuItem;
    }
}

