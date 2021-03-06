﻿using System;
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
    public partial class registrarPagoEfectivo : Form
    {
        public registrarPagoEfectivo()
        {
            InitializeComponent();
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            funcionesComunes.habilitarAnterior();
        }

        private void botonConfirmar_Click(object sender, EventArgs e)
        {
            funcionesComunes.deshabilitarVentanaYAbrirNueva(new Compra.procesoCompraExitoso());
        }

        private void botonBuscar_Click(object sender, EventArgs e)
        {
            if (textBoxDni.TextLength >= 6)
            {
                DataTable tablaClientes = SqlConnector.obtenerTablaSegunConsultaString(@"select ID as Id,
                NOMBRE as Nombre, APELLIDO as Apellido, DNI as Dni, DIRECCION as Dirección, 
                TELEFONO as Teléfono, MAIL as Mail, FECHA_NACIMIENTO as 'Fecha de Nacimiento' 
                from AERO.clientes where BAJA = 0 AND DNI = " + textBoxDni.Text);
                if (tablaClientes.Rows.Count > 0)
                {

                    DataRow row = tablaClientes.Rows[0];
                    textBoxId.Text = row["Id"].ToString();
                    textBoxNombre.Text = row["Nombre"].ToString();
                    textBoxApellido.Text = row["Apellido"].ToString();
                    textBoxDireccion.Text = row["Dirección"].ToString();
                    textBoxDNICliente.Text = row["Dni"].ToString();
                    textBoxTelefono.Text = row["Teléfono"].ToString();
                    textBoxMail.Text = row["Mail"].ToString();
                    timePickerNacimiento.Value = (DateTime)row["Fecha de Nacimiento"];
                    textBoxImporte.Enabled = true;
                    textBoxImporte.Focus();
                }
                else
                {
                    MessageBox.Show("No se encuentra al cliente seleccionado");
                }   
            }
            else
            {
                MessageBox.Show("Ingrese el DNI completo");
                textBoxDni.Focus();
            }
        }

        private void botonActualizarDatos_Click(object sender, EventArgs e)
        {
            if (textBoxApellido.Text != "")
            {
                cargarFormulario(2, "Modificación de cliente");
            }
            else
            {
                MessageBox.Show("Busque un cliente para ser modificado");
            }
        }

        private void botonNuevo_Click(object sender, EventArgs e)
        {
            cargarFormulario(0, "Alta de Cliente");
        }


        private void cargarFormulario(int val, string nombre)
        {
            Form altaDeCliente = new Registro_de_Usuario.altaModificacionDeCliente();
            int valor = val;
            ((TextBox)altaDeCliente.Controls["textBoxTipoForm"]).Text = val.ToString();
            ((TextBox)altaDeCliente.Controls["textBoxVolver"]).Text = "1";
            altaDeCliente.Text = nombre;
            if (val == 2)
            {
                ((TextBox)altaDeCliente.Controls["textBoxId"]).Text = textBoxId.Text;
                ((TextBox)altaDeCliente.Controls["textBoxNombre"]).Text = textBoxNombre.Text;
                ((TextBox)altaDeCliente.Controls["textBoxApellido"]).Text = textBoxApellido.Text;
                ((TextBox)altaDeCliente.Controls["textBoxDni"]).Text = textBoxDNICliente.Text;
                ((TextBox)altaDeCliente.Controls["textBoxDireccion"]).Text = textBoxDireccion.Text;
                ((TextBox)altaDeCliente.Controls["textBoxTelefono"]).Text = textBoxTelefono.Text;
                ((TextBox)altaDeCliente.Controls["textBoxMail"]).Text = textBoxMail.Text;
                ((DateTimePicker)altaDeCliente.Controls["TimePickerNacimiento"]).Value = timePickerNacimiento.Value;
            }
            funcionesComunes.deshabilitarVentanaYAbrirNueva(altaDeCliente);

        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            textBoxId.Clear();
            textBoxNombre.Clear();
            textBoxApellido.Clear();
            textBoxDni.Clear();
            textBoxDireccion.Clear();
            textBoxTelefono.Clear();
            textBoxMail.Clear();
            textBoxMail.Clear();
            textBoxDNICliente.Clear();
            textBoxImporte.Enabled = false;
            textBoxDni.Focus();
        }

   
    }
}
