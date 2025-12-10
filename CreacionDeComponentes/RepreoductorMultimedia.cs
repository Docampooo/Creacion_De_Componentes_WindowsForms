using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreacionDeComponentes
{
    public partial class RepreoductorMultimedia : UserControl
    {
        public RepreoductorMultimedia()
        {
            InitializeComponent();
        }

        bool play = false;

        //Cargar siempre las imagenes de recursos desde la carpeta Poperties.Resources !

        Image continuar = Properties.Resources.btnReanudarPixel;
        Image pausar = Properties.Resources.btnPausePixel;

        [Category("Comportamiento Boton")]
        [Description("Se ha pulsado el boton play")]
        public event System.EventHandler PlayClick;

        [Category("Comportamiento Timer")]
        [Description("Ha alcanzado 60 o el contador de segundos o el de minutos")]
        public event System.EventHandler DesbordaTiempo;

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            play = !play;

            if (play)
            {
                btnPlay.Image = continuar;

            }
            else
            {
                btnPlay.Image = pausar;
            }

            //Llamar siempre al componente comprobando que no sea null
            PlayClick?.Invoke(sender, e);
        }

        [Category("componente")]
        [Description("Propiedad de minutos del componente")]
        private int mins;
        public int Mins
        {
            set
            {
                mins = value;
            }

            get
            {
                return mins;
            }
        }

        [Category("componentes")]
        [Description("Propiedad de los segundos del componente")]
        private int secs = 0;
        public int Secs
        {
            set
            {
                secs = value;
            }

            get
            {
                return secs;
            }
        }

        string[] parametros;
        private void lblTiempo_TextChanged(object sender, EventArgs e)
        {
            parametros = lblTiempo.Text.Split(':');

            if (!int.TryParse(parametros[0], out mins) || !int.TryParse(parametros[1], out secs))
            {
                throw new ArgumentException("Solo se admiten numeros");
            }

            if (mins < 0 || secs < 0)
            {
                throw new ArgumentException("Los indices de tiempo no pueden ser negativos");

            }
            else
            {
                secs++;

                if (secs > 59)
                {
                    secs = secs % 60;
                    mins++;
                }

                if (mins > 59)
                {
                    mins = 0;
                }

                lblTiempo.Text = $"{mins:00}:{secs:00}";
                if (secs % 60 == 0 && secs != 0)
                {
                    //Llamar al evento siempre comprobando que no sea null
                    DesbordaTiempo?.Invoke (sender, e);
                }
            }
        }
    }
}
