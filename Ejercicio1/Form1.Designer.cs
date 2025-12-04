namespace Ejercicio1
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
            this.btnPosicion = new System.Windows.Forms.Button();
            this.btnReducir = new System.Windows.Forms.Button();
            this.btnAumentar = new System.Windows.Forms.Button();
            this.lTxt = new CreacionDeComponentes.LabelTextBox();
            this.SuspendLayout();
            // 
            // btnPosicion
            // 
            this.btnPosicion.Location = new System.Drawing.Point(83, 55);
            this.btnPosicion.Name = "btnPosicion";
            this.btnPosicion.Size = new System.Drawing.Size(137, 34);
            this.btnPosicion.TabIndex = 1;
            this.btnPosicion.Text = "Cambiar Posicion";
            this.btnPosicion.UseVisualStyleBackColor = true;
            this.btnPosicion.Click += new System.EventHandler(this.btnPosicion_Click);
            // 
            // btnReducir
            // 
            this.btnReducir.Location = new System.Drawing.Point(83, 202);
            this.btnReducir.Name = "btnReducir";
            this.btnReducir.Size = new System.Drawing.Size(137, 34);
            this.btnReducir.TabIndex = 3;
            this.btnReducir.Text = "Reducir Tamaño";
            this.btnReducir.UseVisualStyleBackColor = true;
            this.btnReducir.Click += new System.EventHandler(this.btnReducir_Click);
            // 
            // btnAumentar
            // 
            this.btnAumentar.Location = new System.Drawing.Point(83, 140);
            this.btnAumentar.Name = "btnAumentar";
            this.btnAumentar.Size = new System.Drawing.Size(137, 34);
            this.btnAumentar.TabIndex = 4;
            this.btnAumentar.Text = "Aumentar Tamaño";
            this.btnAumentar.UseVisualStyleBackColor = true;
            this.btnAumentar.Click += new System.EventHandler(this.btnAumentar_Click);
            // 
            // lTxt
            // 
            this.lTxt.Location = new System.Drawing.Point(251, 55);
            this.lTxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lTxt.Name = "lTxt";
            this.lTxt.Posicion = CreacionDeComponentes.EPosicion.IZQUIERDA;
            this.lTxt.Separacion = 0;
            this.lTxt.Size = new System.Drawing.Size(394, 22);
            this.lTxt.TabIndex = 0;
            this.lTxt.TextLbl = "LabelTextBox";
            this.lTxt.TextTxt = "";
            this.lTxt.PosicionChanged += new System.EventHandler(this.lTxt_PosicionChanged);
            this.lTxt.SeparationChanged += new System.EventHandler(this.lTxt_SeparationChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAumentar);
            this.Controls.Add(this.btnReducir);
            this.Controls.Add(this.btnPosicion);
            this.Controls.Add(this.lTxt);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private CreacionDeComponentes.LabelTextBox lTxt;
        private System.Windows.Forms.Button btnPosicion;
        private System.Windows.Forms.Button btnReducir;
        private System.Windows.Forms.Button btnAumentar;
    }
}

