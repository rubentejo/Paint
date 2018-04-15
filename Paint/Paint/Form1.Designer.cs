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
            this.gbFiguras = new System.Windows.Forms.GroupBox();
            this.gbColores = new System.Windows.Forms.GroupBox();
            this.colorActual = new System.Windows.Forms.Button();
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
            this.gbHerramientas = new System.Windows.Forms.GroupBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.canvas = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gbColores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
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
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.abrirToolStripMenuItem.Text = "&Abrir";
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.guardarToolStripMenuItem.Text = "&Guardar";
            // 
            // guardarComoToolStripMenuItem
            // 
            this.guardarComoToolStripMenuItem.Name = "guardarComoToolStripMenuItem";
            this.guardarComoToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.guardarComoToolStripMenuItem.Text = "Guardar c&omo";
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
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gbFiguras);
            this.panel1.Controls.Add(this.gbColores);
            this.panel1.Controls.Add(this.gbHerramientas);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 100);
            this.panel1.TabIndex = 1;
            // 
            // gbFiguras
            // 
            this.gbFiguras.Location = new System.Drawing.Point(589, 3);
            this.gbFiguras.Name = "gbFiguras";
            this.gbFiguras.Size = new System.Drawing.Size(208, 94);
            this.gbFiguras.TabIndex = 2;
            this.gbFiguras.TabStop = false;
            this.gbFiguras.Text = "Figuras";
            // 
            // gbColores
            // 
            this.gbColores.Controls.Add(this.colorActual);
            this.gbColores.Controls.Add(this.btnVioleta);
            this.gbColores.Controls.Add(this.btnAzulGrisaceo);
            this.gbColores.Controls.Add(this.btnBlanco);
            this.gbColores.Controls.Add(this.btnAzulClaro);
            this.gbColores.Controls.Add(this.btnLima);
            this.gbColores.Controls.Add(this.btnAmarilloClaro);
            this.gbColores.Controls.Add(this.btnDorado);
            this.gbColores.Controls.Add(this.btnRosa);
            this.gbColores.Controls.Add(this.btnMarron);
            this.gbColores.Controls.Add(this.btnGrisClaro);
            this.gbColores.Controls.Add(this.btnMorado);
            this.gbColores.Controls.Add(this.btnAzulOscuro);
            this.gbColores.Controls.Add(this.btnNegro);
            this.gbColores.Controls.Add(this.btnAzul);
            this.gbColores.Controls.Add(this.btnVerde);
            this.gbColores.Controls.Add(this.btnAmarillo);
            this.gbColores.Controls.Add(this.btnNaranja);
            this.gbColores.Controls.Add(this.btnRojo);
            this.gbColores.Controls.Add(this.btnRojoOcuro);
            this.gbColores.Controls.Add(this.btnGris);
            this.gbColores.Location = new System.Drawing.Point(209, 3);
            this.gbColores.Name = "gbColores";
            this.gbColores.Size = new System.Drawing.Size(374, 94);
            this.gbColores.TabIndex = 1;
            this.gbColores.TabStop = false;
            this.gbColores.Text = "Colores";
            // 
            // colorActual
            // 
            this.colorActual.BackColor = System.Drawing.Color.Black;
            this.colorActual.Location = new System.Drawing.Point(6, 19);
            this.colorActual.Name = "colorActual";
            this.colorActual.Size = new System.Drawing.Size(50, 56);
            this.colorActual.TabIndex = 20;
            this.colorActual.UseVisualStyleBackColor = false;
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
            // gbHerramientas
            // 
            this.gbHerramientas.Location = new System.Drawing.Point(3, 3);
            this.gbHerramientas.Name = "gbHerramientas";
            this.gbHerramientas.Size = new System.Drawing.Size(200, 94);
            this.gbHerramientas.TabIndex = 0;
            this.gbHerramientas.TabStop = false;
            this.gbHerramientas.Text = "Herramientas";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // canvas
            // 
            this.canvas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.canvas.BackColor = System.Drawing.Color.White;
            this.canvas.Location = new System.Drawing.Point(3, 124);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(794, 325);
            this.canvas.TabIndex = 2;
            this.canvas.TabStop = false;
            this.canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseDown);
            this.canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseMove);
            this.canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Paint";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.gbColores.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox gbHerramientas;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.GroupBox gbFiguras;
        private System.Windows.Forms.GroupBox gbColores;
        private System.Windows.Forms.Button colorActual;
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
    }
}

