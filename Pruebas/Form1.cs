using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pruebas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //funciona igual pero mas efectivo

        bool pintar = true;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (pintar)
            {
                e.Graphics.DrawString("Prueba de escritura de texto", this.Font, Brushes.BlueViolet, 10, 10);

                e.Graphics.FillEllipse(Brushes.Aquamarine, 10, 30, 150, 50);

            }
        }

        //No se debe pintar fuera del onPaint
        private void button1_Click(object sender, EventArgs e)
        {
            //Obtener el canvas del formulario
            Graphics gr = this.CreateGraphics();

            gr.DrawString("Escribo fuera del OnPaint", this.Font, Brushes.BlueViolet, 10, 100);
            gr.DrawImage(new Bitmap(@"C:\Users\Usuario\OneDrive\Images\Recursos\Aspectos\chacarron\aroundTheCat.jpg"), 10, 130);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            pintar = !pintar;

            //Este evento lanza de nuevo el OnPaint para pintar los componentes
            this.Refresh();

            this.Text = pintar.ToString();
        }
    }
}
