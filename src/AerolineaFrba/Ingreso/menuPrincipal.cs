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

namespace AerolineaFrba.Ingreso
{
    public partial class menuPrincipal : Form
    {
        public menuPrincipal()
        {
            InitializeComponent();
        }

        private void botonSalir_Click(object sender, EventArgs e)
        {
            funcionesComunes.habilitarAnterior();
        }

        private void botonAceptar_Click(object sender, EventArgs e)
        {
            //Habria que cargar la lista de funcionalidades de la DB antes de hacer esto
            //Solucion provisoria
            String eleccionUsuario = (String)comboBoxFuncionalidad.SelectedItem;
            if (eleccionUsuario != null)
                abrirFormulario(eleccionUsuario);
            else MessageBox.Show("Seleccione funcionalidad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        //Abre formulario segun funcionalidad elegida en combobox
        private void abrirFormulario(String eleccionUsuario)
        {
            switch (eleccionUsuario)
            {

                case "Consultar Millas":
                    funcionesComunes.deshabilitarVentanaYAbrirNueva(new Consulta_Millas.vistaConsultaMillas());
                    break;
                case "Alta de Cliente":
                    funcionesComunes.deshabilitarVentanaYAbrirNueva(new Registro_de_Usuario.altaDeCliente());
                    break;
            }
        }

      
    }
}
