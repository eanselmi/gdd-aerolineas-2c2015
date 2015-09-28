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
                    funcionesComunes.deshabilitarVentanaYAbrirNueva(new Consulta_Millas.consultaMillas());
                    break;
                case "Alta de Cliente":
                    funcionesComunes.deshabilitarVentanaYAbrirNueva(new Registro_de_Usuario.altaDeCliente());
                    break;
                case "Alta de Aeronave":
                    funcionesComunes.deshabilitarVentanaYAbrirNueva(new Abm_Aeronave.altaDeAeronave());
                    break;
                case "Alta de Ciudad":
                    funcionesComunes.deshabilitarVentanaYAbrirNueva(new Abm_Ciudad.altaDeCiudad());
                    break;
                case "Alta de Tarjeta de Crédito":
                    funcionesComunes.deshabilitarVentanaYAbrirNueva(new Tarjeta.altaDeTarjeta());
                    break;
                case "Baja de Aeronave":
                    funcionesComunes.deshabilitarVentanaYAbrirNueva(new Abm_Aeronave.bajaModificacionDeAeronave());
                    break;
                case "Baja de Ciudad":
                    funcionesComunes.deshabilitarVentanaYAbrirNueva(new Abm_Ciudad.bajaModificacionDeCiudad());
                    break;
                case "Baja de Cliente":
                    funcionesComunes.deshabilitarVentanaYAbrirNueva(new Registro_de_Usuario.bajaCliente());
                    break;
                case "Baja de Tarjeta de Crédito":
                    funcionesComunes.deshabilitarVentanaYAbrirNueva(new Tarjeta.bajaTarjeta());
                    break;
                case "Modificacion de Aeronave":
                    funcionesComunes.deshabilitarVentanaYAbrirNueva(new Abm_Aeronave.bajaModificacionDeAeronave());
                    break;
                case "Modificacion de Ciudad":
                    funcionesComunes.deshabilitarVentanaYAbrirNueva(new Abm_Ciudad.bajaModificacionDeCiudad());
                    break;
                case "Modificacion de Cliente":
                    funcionesComunes.deshabilitarVentanaYAbrirNueva(new Registro_de_Usuario.modificacionCliente());
                    break;
                case "Realizar Canje":
                    funcionesComunes.deshabilitarVentanaYAbrirNueva(new Canje_Millas.realizarCanjeMillas());
                    break;
                case "Alta de Rol":
                    funcionesComunes.deshabilitarVentanaYAbrirNueva(new Abm_Rol.altaRol());
                    break;
                case "Baja de Rol":
                    funcionesComunes.deshabilitarVentanaYAbrirNueva(new Abm_Rol.bajaRol());
                    break;
                case "Modificacion de Rol":
                    funcionesComunes.deshabilitarVentanaYAbrirNueva(new Abm_Rol.modificacionRol());
                    break;
                case "Alta de Ruta":
                    funcionesComunes.deshabilitarVentanaYAbrirNueva(new Abm_Ruta.altaDeRuta());
                    break;
                case "Baja de Ruta":
                    funcionesComunes.deshabilitarVentanaYAbrirNueva(new Abm_Ruta.bajaModificacionDeRuta());
                    break;
                case "Modificacion de Ruta":
                    funcionesComunes.deshabilitarVentanaYAbrirNueva(new Abm_Ruta.bajaModificacionDeRuta());
                    break;
                case "Realizar Encomienda":
                    funcionesComunes.deshabilitarVentanaYAbrirNueva(new Compra.realizarEncomienda());
                    break;
                case "Comprar Pasaje":
                    funcionesComunes.deshabilitarVentanaYAbrirNueva(new Compra.comprarPasaje());
                    break;
                case "Cancelar Encomienda":
                    funcionesComunes.deshabilitarVentanaYAbrirNueva(new Compra.bajaEncomienda());
                    break;
                case "Cancelar Pasaje":
                    funcionesComunes.deshabilitarVentanaYAbrirNueva(new Compra.bajaPasaje());
                    break;
                case "Generar Viaje":
                    funcionesComunes.deshabilitarVentanaYAbrirNueva(new Abm_Vuelos.generarViaje());
                    break;
                case "Registrar Llegadas":
                    funcionesComunes.deshabilitarVentanaYAbrirNueva(new Registro_Llegada_Destino.registroDeLlegadaADestino());
                    break;
            }
            this.comboBoxFuncionalidad.SelectedIndex = -1;
        }

    

    }
}
