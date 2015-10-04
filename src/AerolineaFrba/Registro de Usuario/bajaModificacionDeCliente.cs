using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Registro_de_Usuario
{
    public partial class bajaModificacionDeCliente : Form
    {
        DataTable listado;
        public bajaModificacionDeCliente()
        {
            InitializeComponent();
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            funcionesComunes.habilitarAnterior();
        }

        private void bajaModificacionDeCliente_Load(object sender, EventArgs e)
        {
            consultarClientes();
        }

        private void botonBuscar_Click(object sender, EventArgs e)
        {
            DataTable clientesFiltro = filtrarCliente(textNombre.Text, textApellido.Text, textMail.Text, textDni.Text, textTelefono.Text);
            dataGridListadoClientes.DataSource = clientesFiltro;
        }

        private DataTable filtrarCliente(string nombre, string apellido, string mail, string dni, string telefono)
        {
            DataTable tablaClientes = listado;
            var final_rol = "";
            var posFiltro = true;
            var filtrosBusqueda = new List<string>();
            if (nombre != "") filtrosBusqueda.Add("Nombre LIKE '%" + nombre + "%'");
            if (apellido != "") filtrosBusqueda.Add("Apellido LIKE '%" + apellido + "%'");
            if (mail != "") filtrosBusqueda.Add("Mail LIKE '%" + mail + "%'");
            if (dni != "") filtrosBusqueda.Add("Dni = " + dni);
            if (telefono != "") filtrosBusqueda.Add("Teléfono = " + telefono);
   
            foreach (var filtro in filtrosBusqueda)
            {
                if (!posFiltro)
                    final_rol += " AND " + filtro;
                else
                {
                    final_rol += filtro;
                    posFiltro = false;
                }
            }
            if (tablaClientes != null)
                tablaClientes.DefaultView.RowFilter = final_rol;
            return tablaClientes;
        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();

        }

        private void limpiar()
        {
            dataGridListadoClientes.DataSource = null;
            consultarClientes();
            textNombre.Text = "";
            textApellido.Text = "";
            textMail.Text = "";
            textDni.Text = "";
            textTelefono.Text = "";
        }

        private void consultarClientes()
        {
            listado = SqlConnector.obtenerTablaSegunConsultaString("select ID as Id,NOMBRE as Nombre, APELLIDO as Apellido, DNI as Dni, DIRECCION as Dirección, TELEFONO as Teléfono, MAIL as Mail, FECHA_NACIMIENTO as 'Fecha de Nacimiento' from AERO.clientes ");
            dataGridListadoClientes.DataSource = listado;
            dataGridListadoClientes.Columns[0].Visible = false;
        }
    }
}
