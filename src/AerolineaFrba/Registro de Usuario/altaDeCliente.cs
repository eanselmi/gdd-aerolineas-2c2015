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

namespace AerolineaFrba.Registro_de_Usuario
{
    public partial class altaDeCliente : Form
    {
        public altaDeCliente()
        {
            InitializeComponent();
        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            funcionesComunes.habilitarAnterior();
        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            this.textBoxApellido.Clear();
            this.textBoxDireccion.Clear();
            this.textBoxMail.Clear();
            this.textBoxNombre.Clear();
            this.textBoxTelefono.Clear();
            this.TimePickerNacimiento.ResetText();
        }

        private void botonGuardar_Click(object sender, EventArgs e)
        {
            String apellido = this.textBoxApellido.Text;
            String nombre = this.textBoxNombre.Text;
            String direccion = this.textBoxDireccion.Text;
            String telefono = this.textBoxTelefono.Text;
            String dni = this.textBoxDNI.Text;
            String mail = this.textBoxMail.Text;
            //Acordarse de validar que la fecha sea anteior a hoy y que la edad sea > 18
            if (apellido != "" && nombre != "" && direccion != "" && telefono != "" && dni != "" && mail != "")
                this.textBoxNombre.Clear(); //de nuevo: este lo pongo para que funcione, despues lo modificamos
            else MessageBox.Show("Complete los campos requeridos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void textBoxApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            funcionesComunes.soloLetras(e);
        }

        private void textBoxNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            funcionesComunes.soloLetras(e);
        }

        private void textBoxDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            funcionesComunes.soloLetrasYNumeros(e);
        }

        private void textBoxTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            funcionesComunes.soloNumeros(e);
        }

        private void textBoxMail_KeyPress(object sender, KeyPressEventArgs e)
        {
            funcionesComunes.soloMail(e);
        }

        private void textBoxDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            funcionesComunes.soloNumeros(e);
        }







    }
}
