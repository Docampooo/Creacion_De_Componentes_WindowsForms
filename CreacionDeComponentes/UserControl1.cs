using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace CreacionDeComponentes
{
    public enum EPosicion
    {
        IZQUIERDA, DERECHA
    }
    [
    DefaultProperty("TextLbl"),
    DefaultEvent("Load")
    ]

    public partial class LabelTextBox : UserControl
    {
        public LabelTextBox()
        {
            InitializeComponent();
            TextLbl = Name;
            TextTxt = "";
            recolocar();
        }
        private EPosicion posicion = EPosicion.IZQUIERDA;

        [Category("Appearance")]
        [Description("Indica si la Label se sitúa a la IZQUIERDA o DERECHA del Textbox")]
        public EPosicion Posicion
        {
            set
            {
                if (Enum.IsDefined(typeof(EPosicion), value))
                {
                    posicion = value;
                    Refresh();
                    OnPosicionChanged(EventArgs.Empty);
                }
                else
                {
                    throw new InvalidEnumArgumentException();
                }
            }
            get
            {
                return posicion;
            }
        }

        //Pixeles de separación entre label y textbox
        private int separacion = 0;
        [Category("Mis propiedades")] // O se puede meter en categoría Design.
        [Description("Píxels de separación entre Label y Textbox")]
        public int Separacion
        {
            set
            {
                if (value >= 0)
                {
                    separacion = value;
                    Refresh();
                    OnSeparationChanged(EventArgs.Empty);
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            get
            {
                return separacion;
            }
        }

        [Category("Mis propiedades")]
        [Description("Texto asociado a la Label del control")]
        public string TextLbl
        {
            set
            {
                lbl.Text = value;
            }
            get
            {
                return lbl.Text;
            }
        }

        [Category("Mis Propiedades")]
        [Description("Texto asociado al TextBox del control")]
        public string TextTxt
        {
            set
            {
                txt.Text = value;
            }
            get
            {
                return txt.Text;
            }
        }

        [Category("Nuevas Propiedades")]
        [Description("Enlace con la propiedad PassWrodChar del textBox interno")]

        //falla aqui 
        public char PswChr
        {
            set
            {
                PswChr = txt.PasswordChar;
            }

            get
            {
                return PswChr;
            }
        }


        private void recolocar()
        {
            switch (posicion)
            {
                case EPosicion.IZQUIERDA:
                    //Establecemos posición del componente lbl
                    lbl.Location = new Point(0, 0);
                    // Establecemos posición componente txt
                    txt.Location = new Point(lbl.Width + Separacion, 0);
                    //Establecemos ancho del Textbox
                    //(la label tiene ancho por autosize)
                    //txt.Width = this.Width - lbl.Width - Separacion;
                    //Establecemos altura del componente
                    this.Height = Math.Max(txt.Height, lbl.Height);

                    break;
                case EPosicion.DERECHA:
                    //Establecemos posición del componente txt
                    txt.Location = new Point(0, 0);
                    //Establecemos ancho del Textbox
                    //txt.Width = this.Width - lbl.Width - Separacion;
                    //Establecemos posición del componente lbl
                    lbl.Location = new Point(txt.Width + Separacion, 0);
                    //Establecemos altura del componente (Puede sacarse del switch)
                    this.Height = Math.Max(txt.Height, lbl.Height);
                    break;
            }
            this.Width = lbl.Width + separacion + txt.Width;

        }

        bool subrayado = true;
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            recolocar();

            //Pintar subrayado
            if (subrayado)
            {
                e.Graphics.DrawLine(new Pen(Color.Violet),
                lbl.Left, this.Height - 1,
                lbl.Left + lbl.Width, this.Height - 1);
            }


        }
        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.OnKeyPress(e);
        }

        [Category("La propiedad cambió")]
        [Description("Se lanza cuando la propiedad Posicion cambia")]
        public event System.EventHandler PosicionChanged;

        protected virtual void OnPosicionChanged(EventArgs e)
        {
            //PosicionChanged?.Invoke(this, e);  //Lo mismo que lo de abajo
            if (PosicionChanged != null)
            {
                PosicionChanged(this, e);
            }
        }

        [Category("La Separacion Cambió")]
        [Description("Se lanza cuando la propiedad Separacion cambia")]
        public event System.EventHandler SeparationChanged;
        protected virtual void OnSeparationChanged(EventArgs e)
        {
            SeparationChanged?.Invoke(this, e);
        }

        private void txt_KeyUp(object sender, KeyEventArgs e)
        {
            this.OnKeyUp(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            lbl.Text = e.KeyCode.ToString();
        }

        [Category("El texto cambió")]
        [Description("Se lanza cuando cambia la propiedad TextChanged en el txt")]
        public event System.EventHandler TxtChanged;

        protected virtual void onTextChanged(EventArgs e)
        {
            TxtChanged?.Invoke(this, e);
        }

        private void txt_TextChanged(object sender, EventArgs e)
        {
            this.onTextChanged(e);
        }


    }
}
