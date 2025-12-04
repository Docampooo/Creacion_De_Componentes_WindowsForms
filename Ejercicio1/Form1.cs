using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CreacionDeComponentes;

namespace Ejercicio1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Debug.WriteLine(lTxt.PswChr);
        }

        private void btnPosicion_Click(object sender, EventArgs e)
        {
            lTxt.Posicion = lTxt.Posicion == EPosicion.DERECHA ? EPosicion.IZQUIERDA : EPosicion.DERECHA;
        }

        private void lTxt_PosicionChanged(object sender, EventArgs e)
        {
            this.Text = $"Valor del Enumerado: %{lTxt.Posicion}";

        }

        private void btnAumentar_Click(object sender, EventArgs e)
        {
            lTxt.Separacion += 10;
        }

        private void btnReducir_Click(object sender, EventArgs e)
        {
            lTxt.Separacion -= 10;

        }

        private void lTxt_SeparationChanged(object sender, EventArgs e)
        {
            this.Text = $"Separacion: {lTxt.Separacion}";
        }
    }
}
