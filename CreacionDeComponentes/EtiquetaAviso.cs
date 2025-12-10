using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreacionDeComponentes//Offset en nada, cambio de fuente que la imagen no se monte en el texto. evento clickenmarca
{
    public enum EMarca
    {
        Nada,
        Cruz,
        Circulo,
        Imagen,
    }
    public partial class EtiquetaAviso : Control
    {
        private EMarca marca = EMarca.Nada;

        [Category("Appearance")]
        [Description("Indica el tipo de marca que aparece junto al texto")]

        public EMarca Marca
        {
            set
            {
                this.marca = value;
                this.Refresh();
            }
            get
            {
                return marca;
            }
        }

        private Color colorInicial;

        [Category("Appearence")]
        [Description("Color del que comienza el degradado del fondo del componente")]

        public Color ColorInicial
        {
            set
            {
                this.colorInicial = value;
                Refresh();
            }
            get
            {
                return colorInicial;
            }
        }

        private Color colorFinal;

        [Category("Appearence")]
        [Description("Color en el que termina el degradado del fondo del componente")]

        public Color ColorFinal
        {
            set
            {
                this.colorFinal = value;
                Refresh();
            }
            get
            {
                return colorFinal;
            }
        }

        public EtiquetaAviso()
        {
            InitializeComponent();
        }

        private bool degradado = false;

        [Category("Appearence")]
        [Description("Indica si se establece o no un degradado")]

        public bool Degradado
        {
            set
            {
                this.degradado = value;
                Refresh();
            }
            get
            {
                return degradado;
            }
        }

        private Bitmap imagenMarca;

        [Category("Appearence")]
        [Description("Imagen que se le asigna en el icono de la izquierda")]

        public Bitmap ImagenMarca
        {
            set
            {
                imagenMarca = value;
                Refresh();
            }
            get
            {
                return imagenMarca;
            }
        }
        int offsetX = 0; //Desplazamiento a la derecha del texto
        int offsetY = 0; //Desplazamiento hacia abajo del texto
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            Graphics g = pe.Graphics;
            int grosor = 0;//Grosor de las líneas de dibujo

            int h = this.Font.Height; // Altura de fuente, usada como referencia en varias partes

            //Esta propiedad provoca mejoras en la apariencia o en la eficiencia  a la hora de dibujar
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            LinearGradientBrush lg = new LinearGradientBrush(new Point(this.Left, this.Top), new Point(this.Right, this.Bottom), colorInicial, colorFinal);
            if (Degradado)
            {
                g.FillRectangle(lg, this.ClientRectangle);
            }
            //Inmportante liberar Memoria!!!!
            lg.Dispose();

            //Dependiendo del valor de la propiedad marca dibujamos una
            //Cruz o un Círculo
            switch (Marca)
            {
                case EMarca.Circulo:
                    grosor = 20;
                    g.DrawEllipse(new Pen(Color.Green, grosor), grosor, grosor, h, h);

                    offsetX = h + grosor;
                    offsetY = grosor;
                    break;

                case EMarca.Cruz:
                    grosor = 3;
                    Pen lapiz = new Pen(Color.Red, grosor);
                    g.DrawLine(lapiz, grosor, grosor, h, h);
                    g.DrawLine(lapiz, h, grosor, grosor, h);

                    offsetX = h + grosor;
                    offsetY = grosor / 2;

                    //Es recomendable liberar recursos de dibujo pues se
                    //pueden realizar muchos y cogen memoria
                    lapiz.Dispose();
                    break;

                case EMarca.Imagen:

                    grosor = 50;
                    if (ImagenMarca != null)
                    {
                        g.DrawImage(ImagenMarca, h, h, h, h); //cambiar esto
                        offsetX = grosor + h;
                        offsetY = grosor / 2;
                    }
                    break;
            }

            //Finalmente pintamos el Texto; desplazado si fuera necesario

            SolidBrush b = new SolidBrush(this.ForeColor);
            g.DrawString(this.Text, this.Font, b, offsetX + grosor, offsetY);

            Size tam = g.MeasureString(this.Text, this.Font).ToSize();
            this.Size = new Size(tam.Width + offsetX + grosor, tam.Height + offsetY * 2);
            b.Dispose();

            b.Dispose();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            this.Refresh();
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (Marca != EMarca.Nada && Marca != EMarca.Circulo)
            {
                if (e.X <= this.Font.Height + offsetX)
                {
                    ClickEnMarca();
                }
            }
            else if (Marca == EMarca.Circulo)
            {
                if (e.X <= this.Font.Height + offsetX)
                {
                    ClickEnMarca();
                }
            }
        }

        public void ClickEnMarca()
        {
            MessageBox.Show("Has pulsado la marca!", "pulsacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
