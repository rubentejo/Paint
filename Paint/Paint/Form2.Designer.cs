namespace Paint
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnColor1 = new System.Windows.Forms.Button();
            this.btnColor2 = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbDDescendente = new System.Windows.Forms.RadioButton();
            this.rbDAscendente = new System.Windows.Forms.RadioButton();
            this.rbVertical = new System.Windows.Forms.RadioButton();
            this.rbHorizontal = new System.Windows.Forms.RadioButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Color 1:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Color 2:";
            // 
            // btnColor1
            // 
            this.btnColor1.BackColor = System.Drawing.Color.Black;
            this.btnColor1.Location = new System.Drawing.Point(71, 24);
            this.btnColor1.Name = "btnColor1";
            this.btnColor1.Size = new System.Drawing.Size(25, 25);
            this.btnColor1.TabIndex = 8;
            this.toolTip1.SetToolTip(this.btnColor1, "Primer color del gradiente");
            this.btnColor1.UseVisualStyleBackColor = false;
            this.btnColor1.Click += new System.EventHandler(this.colores_Click);
            // 
            // btnColor2
            // 
            this.btnColor2.BackColor = System.Drawing.Color.Black;
            this.btnColor2.Location = new System.Drawing.Point(71, 55);
            this.btnColor2.Name = "btnColor2";
            this.btnColor2.Size = new System.Drawing.Size(25, 25);
            this.btnColor2.TabIndex = 9;
            this.toolTip1.SetToolTip(this.btnColor2, "Segundo color del gradiente");
            this.btnColor2.UseVisualStyleBackColor = false;
            this.btnColor2.Click += new System.EventHandler(this.colores_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAceptar.Location = new System.Drawing.Point(50, 111);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 10;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(131, 111);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbDDescendente);
            this.groupBox1.Controls.Add(this.rbDAscendente);
            this.groupBox1.Controls.Add(this.rbVertical);
            this.groupBox1.Controls.Add(this.rbHorizontal);
            this.groupBox1.Location = new System.Drawing.Point(117, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(140, 93);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dirección";
            // 
            // rbDDescendente
            // 
            this.rbDDescendente.AutoSize = true;
            this.rbDDescendente.Location = new System.Drawing.Point(6, 69);
            this.rbDDescendente.Name = "rbDDescendente";
            this.rbDDescendente.Size = new System.Drawing.Size(132, 17);
            this.rbDDescendente.TabIndex = 3;
            this.rbDDescendente.Tag = "3";
            this.rbDDescendente.Text = "Diagonal descendente";
            this.toolTip1.SetToolTip(this.rbDDescendente, "El gradiente se verá de la esquina superior izquierda a la esquina inferior derec" +
        "ha");
            this.rbDDescendente.UseVisualStyleBackColor = true;
            // 
            // rbDAscendente
            // 
            this.rbDAscendente.AutoSize = true;
            this.rbDAscendente.Location = new System.Drawing.Point(6, 51);
            this.rbDAscendente.Name = "rbDAscendente";
            this.rbDAscendente.Size = new System.Drawing.Size(126, 17);
            this.rbDAscendente.TabIndex = 2;
            this.rbDAscendente.Tag = "2";
            this.rbDAscendente.Text = "Diagonal ascendente";
            this.toolTip1.SetToolTip(this.rbDAscendente, "El gradiente se verá de la esquina inferior izquierda a la esquina superior derec" +
        "ha");
            this.rbDAscendente.UseVisualStyleBackColor = true;
            // 
            // rbVertical
            // 
            this.rbVertical.AutoSize = true;
            this.rbVertical.Location = new System.Drawing.Point(7, 33);
            this.rbVertical.Name = "rbVertical";
            this.rbVertical.Size = new System.Drawing.Size(60, 17);
            this.rbVertical.TabIndex = 1;
            this.rbVertical.Tag = "1";
            this.rbVertical.Text = "Vertical";
            this.toolTip1.SetToolTip(this.rbVertical, "El gradiente se verá de arriba a abajo");
            this.rbVertical.UseVisualStyleBackColor = true;
            // 
            // rbHorizontal
            // 
            this.rbHorizontal.AutoSize = true;
            this.rbHorizontal.Checked = true;
            this.rbHorizontal.Location = new System.Drawing.Point(7, 15);
            this.rbHorizontal.Name = "rbHorizontal";
            this.rbHorizontal.Size = new System.Drawing.Size(72, 17);
            this.rbHorizontal.TabIndex = 0;
            this.rbHorizontal.TabStop = true;
            this.rbHorizontal.Tag = "0";
            this.rbHorizontal.Text = "Horizontal";
            this.toolTip1.SetToolTip(this.rbHorizontal, "El gradiente se verá de izquierda a derecha");
            this.rbHorizontal.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 146);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnColor2);
            this.Controls.Add(this.btnColor1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gradiente";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button btnColor1;
        public System.Windows.Forms.Button btnColor2;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.RadioButton rbHorizontal;
        public System.Windows.Forms.RadioButton rbDDescendente;
        public System.Windows.Forms.RadioButton rbDAscendente;
        public System.Windows.Forms.RadioButton rbVertical;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}