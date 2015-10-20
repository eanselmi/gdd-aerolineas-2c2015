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
                if (dni.Length >= 7)
                {
                    if (validarDni(dni))
                    {
                        //TODO Hacer que mueste un nueva vista tal vez con los resultados de clientes con ese dni para elegir uno 
                        Form listadoClientes = new Registro_de_Usuario.bajaModificacionDeCliente();
                        int valor = 1;
                        foreach (Control gb in listadoClientes.Controls) {
                            if (gb is GroupBox) {
                                if (gb.Name == "groupBox1")
                                    ((TextBox)gb.Controls["textDni"]).Text = this.textBoxDniPas.Text;
                            }
                        }
                        ((TextBox)listadoClientes.Controls["textBoxTipoForm"]).Text = valor.ToString();
                        funcionesComunes.deshabilitarVentanaYAbrirNueva(listadoClientes);
                    }
                    else
                    {
                        MessageBox.Show("Dni de cliente inexistente, debe darlo de alta para poder seguir con las operaciones");

                        Form altaDeCliente = new Registro_de_Usuario.altaModificacionDeCliente();
                        int valor = 1;
                        ((TextBox)altaDeCliente.Controls["textBoxTipoForm"]).Text = valor.ToString();
                        altaDeCliente.Text = "Alta de Cliente";
                        ((TextBox)altaDeCliente.Controls["textBoxDNI"]).Text = dni;
                        ((TextBox)altaDeCliente.Controls["textBoxDNI"]).ReadOnly = true;
                        funcionesComunes.deshabilitarVentanaYAbrirNueva(altaDeCliente);
                    }
                }
                else
                    MessageBox.Show("Numero de documento invalido debe poseer al menos 7 digitos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Ingrese un numero de documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool validarDni(string dni)
        {
            DataTable tablaClientes = SqlConnector.obtenerTablaSegunConsultaString(@"select ID as Id,
                NOMBRE as Nombre, APELLIDO as Apellido, DNI as Dni, DIRECCION as Dirección, 
                TELEFONO as Teléfono, MAIL as Mail, FECHA_NACIMIENTO as 'Fecha de Nacimiento' 
                from AERO.clientes where BAJA = 0 AND DNI = "+ dni);
            return tablaClientes.Rows.Count != 0; 
        }

       
    }

}
