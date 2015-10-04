using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Compra
{
    public partial class formaDePago : Form
    {
        public formaDePago()
        {
            InitializeComponent();
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            funcionesComunes.habilitarAnterior();
        }

        private void buttonTarjeta_Click(object sender, EventArgs e)
        {
            funcionesComunes.deshabilitarVentanaYAbrirNueva(new Compra.registrarPagoTarjeta());
        }

        private void botonEfectivo_Click(object sender, EventArgs e)
        {
            funcionesComunes.deshabilitarVentanaYAbrirNueva(new Compra.registrarPagoEfectivo());
        }
    }
}
