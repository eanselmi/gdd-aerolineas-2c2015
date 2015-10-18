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

namespace AerolineaFrba.Tarjeta
{
    public partial class altaDeTarjeta : Form
    {
        public altaDeTarjeta()
        {
            InitializeComponent();
            funcionesComunes.llenarCombobox(this.comboBoxTipoTarjeta, "NOMBRE", "select ID, NOMBRE from AERO.tipos_tarjeta");
        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            funcionesComunes.habilitarAnterior();
        }

        //este boton borra el contenido de todos los campos
        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            this.textBoxDni.Clear();
            this.textBoxNumero.Clear();
            this.comboBoxTipoTarjeta.SelectedIndex = -1;
            this.dataGridCliente.DataSource = null;
            this.fechavencimiento.ResetText();
        }

        private void botonGuardar_Click(object sender, EventArgs e)
        {
            if (validarDatos()) {
                
                
            }
        }

        private void consultarContactos()
        {
            String dni = this.textBoxDni.Text;
            if (dni != "")
            {
                List<string> lista = new List<string>();
                lista.Add("@dni");
                DataTable resultado = SqlConnector.obtenerTablaSegunProcedure("AERO.obtenerClienteConMillas", lista, dni);
                dataGridCliente.DataSource = resultado;
                dataGridCliente.Columns[0].Visible = false;
            }
            else
            {
                MessageBox.Show("Ingrese un numero de documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private bool validarDatos()
        {
            Int32 numero;
            if (this.textBoxNumero.Text == "")
                numero = 0;
            else
                numero = Int32.Parse(this.textBoxNumero.Text);
            if (this.dataGridCliente.DataSource != null && numero > 0 && this.comboBoxTipoTarjeta.SelectedValue != null)
                return true;
            else MessageBox.Show("Complete los campos requeridos correctamente", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            if (this.fechavencimiento.Value > DateTime.Today)
                return true;
            else
                MessageBox.Show("La fecha de vencimiento debe ser superior a la de hoy", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            return false;
   
        }

        private void soloNumer(object sender, KeyPressEventArgs e)
        {
            funcionesComunes.soloNumeros(e);
        }

        private void botonBuscar_Click(object sender, EventArgs e)
        {
            consultarContactos();
        }
    }
}
