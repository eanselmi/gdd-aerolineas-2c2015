using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Abm_Rol
{
    public partial class bajaModificacionDeRol : Form
    {
        DataTable listado;
        public bajaModificacionDeRol()
        {
            InitializeComponent();
        }

        private void bajaModificacionDeRol_Load(object sender, EventArgs e)
        {
            consultarRoles();
        }

        private void consultarRoles()
        {
            listado = SqlConnector.obtenerTablaSegunConsultaString("select r.ID as IdRol, r.NOMBRE as Rol, r.ACTIVO as Activo from AERO.roles r");
            listado.Columns.Add("Estado", typeof(String));
            foreach (DataRow row in listado.Rows)
            {
                if (Convert.ToInt32(row[2]) == 0)
                {
                    row[3] = "Inactivo";
                }
                else
                {
                    row[3] = "Activo";
                }
            }
            dataGridListadoRoles.DataSource = listado;
            dataGridListadoRoles.Columns[0].Visible = false;
            dataGridListadoRoles.Columns[2].Visible = false;
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            funcionesComunes.habilitarAnterior();
        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void limpiar()
        {
            textRol.Clear();
            textEstado.Clear();
            consultarRoles();
        }

        private void botonBaja_Click(object sender, EventArgs e)
        {
            List<string> lista = new List<string>();
            lista.Add("@id");
            bool resultado = SqlConnector.executeProcedure("AERO.bajaRol", lista, dataGridListadoRoles.SelectedCells[0].Value.ToString());
            if (resultado)
            {
                MessageBox.Show("El rol se dio de baja exitosamente");
            }
            consultarRoles();
        }

        private void botonModificacion_Click(object sender, EventArgs e)
        {
            if (dataGridListadoRoles.SelectedRows.Count > 0)
            {
                Form modificacionDeRol = new Abm_Rol.altaModificacionDeRol();
                int val = 1;
                ((TextBox)modificacionDeRol.Controls["textTipoForm"]).Text = val.ToString();
                ((TextBox)modificacionDeRol.Controls["textId"]).Text = dataGridListadoRoles.SelectedCells[0].Value.ToString();
                ((TextBox)modificacionDeRol.Controls["textRol"]).Text = dataGridListadoRoles.SelectedCells[1].Value.ToString();
                modificacionDeRol.Text = "Modificación de Rol";
                funcionesComunes.deshabilitarVentanaYAbrirNueva(modificacionDeRol);
            }
            else
            {
                MessageBox.Show("Seleccione un rol para modificar");
            }
        }

        private void botonBuscar_Click(object sender, EventArgs e)
        {
            DataTable clientesFiltro = filtrarRol(textRol.Text, textEstado.Text);
            dataGridListadoRoles.DataSource = clientesFiltro;
        }

        private DataTable filtrarRol(string rol, string estado)
        {
            DataTable tablaRoles = listado;
            var final_rol = "";
            var posFiltro = true;
            var filtrosBusqueda = new List<string>();
            if (rol != "") filtrosBusqueda.Add("Rol LIKE '%" + rol + "%'");
            if (estado != "") filtrosBusqueda.Add("Estado LIKE '%" + estado + "%'");

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
            if (tablaRoles != null)
                tablaRoles.DefaultView.RowFilter = final_rol;
            return tablaRoles;
        }
    }
}
