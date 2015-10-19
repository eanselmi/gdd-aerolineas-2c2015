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
            //Abre formulario segun sea el rol
            if (funcionesComunes.getRol() == "administrador")
            {
                funcionesComunes.deshabilitarVentanaYAbrirNueva(new Compra.formaDePago());
            }else{
                funcionesComunes.deshabilitarVentanaYAbrirNueva(new Compra.registrarPagoTarjeta());
            }

        }

        private void valida(object sender, KeyPressEventArgs e)
        {
            funcionesComunes.soloNumeros(e);
        }

        private void botonGuardar_Click(object sender, EventArgs e)
        {
            this.consultarContactos();
        }
        private void consultarContactos()
        {
            String dni = this.textBoxDniPas.Text;
            if (dni != "")
            {
                if (dni.Length == 8)
                {
                    List<string> lista = new List<string>();
                    lista.Add("@dni");
                    DataTable resultado = SqlConnector.obtenerTablaSegunProcedure("AERO.obtenerClienteConMillas", lista, dni);
                    if (resultado.Rows.Count == 0)
                    {

                    }
                }
                else
                    MessageBox.Show("Numero de documento invalido debe poseer 8 digitos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Ingrese un numero de documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
