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
            this.textBoxDNI.Clear();
            this.TimePickerNacimiento.ResetText();
        }

        private void botonGuardar_Click(object sender, EventArgs e)
        {
            String apellido = this.textBoxApellido.Text;
            String nombre = this.textBoxNombre.Text;
            String direccion = this.textBoxDireccion.Text;
            long telefono = 0;
            if (this.textBoxTelefono.Text != "")
            {
                telefono = long.Parse(textBoxTelefono.Text);
            }
            long dni = 0;
            if (this.textBoxDNI.Text != "")
            {
                dni = long.Parse(this.textBoxDNI.Text);
            }
            
            String mail = this.textBoxMail.Text;
            //Acordarse de validar que la fecha sea anteior a hoy y que la edad sea > 18
            if (apellido != "" && nombre != "" && direccion != "" && mail != "" && dni > 0 && telefono > 0)
            {
                if (TimePickerNacimiento.Value < DateTime.Today)
                {
                    List<string> lista = new List<string>();
                    lista.Add("@rol_id");
                    lista.Add("@nombreCliente");
                    lista.Add("@apellidoCliente");
                    lista.Add("@documentoCliente");
                    lista.Add("@direccion");
                    lista.Add("@telefono");
                    lista.Add("@mail");
                    lista.Add("@fechaNac");
                    bool resultado = SqlConnector.executeProcedure("AERO.agregarCliente", lista, 2, nombre, apellido, dni, direccion,
                        telefono, mail, Convert.ToDateTime(this.TimePickerNacimiento.Value));
                    if (resultado)
                    {
                        MessageBox.Show("Se guardo exitosamente");
                        botonLimpiar.PerformClick();
                    }
                } else
                    {
                        MessageBox.Show("La fecha de nacimiento debe ser anterior a la fecha actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }
                else
                {
                    MessageBox.Show("Complete los campos requeridos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
