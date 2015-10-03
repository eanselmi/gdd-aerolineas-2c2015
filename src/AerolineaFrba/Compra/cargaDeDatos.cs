using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AerolineaFrba;

namespace AerolineaFrba.Compra
{
    public partial class cargaDeDatos : Form
    {
        public cargaDeDatos()
        {
            InitializeComponent();
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            funcionesComunes.habilitarAnterior();
        }

        private void botonComprar_Click(object sender, EventArgs e)
        {
            //Si el rol actual es cliente
            if (funcionesComunes.getRol() == "administrador")
            {

                funcionesComunes.deshabilitarVentanaYAbrirNueva(new Compra.VistaFormaDePago());
            }
            else
            {
                Form frmPagoTarjeta = new Compra.registrarPagoTarjeta();
                funcionesComunes.deshabilitarVentanaYAbrirNueva(frmPagoTarjeta);
            }

        }
    }
}
