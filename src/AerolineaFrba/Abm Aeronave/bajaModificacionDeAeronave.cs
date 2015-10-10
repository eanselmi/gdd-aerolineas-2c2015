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

namespace AerolineaFrba.Abm_Aeronave
{
    public partial class bajaModificacionDeAeronave : Form
    {
        DataTable listado;
        public bajaModificacionDeAeronave()
        {
            InitializeComponent();
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            funcionesComunes.habilitarAnterior();
        }

        private void botonModificacion_Click(object sender, EventArgs e)
        {
            Form modificacionAeronave = new Abm_Aeronave.modificacionDeAeronave();
            ((TextBox)modificacionAeronave.Controls["textBoxId"]).Text = dataGridListadoAeronaves.SelectedCells[0].Value.ToString();
            ((TextBox)modificacionAeronave.Controls["textBoxMatricula"]).Text = dataGridListadoAeronaves.SelectedCells[1].Value.ToString();
            ((TextBox)modificacionAeronave.Controls["textBoxModelo"]).Text = dataGridListadoAeronaves.SelectedCells[2].Value.ToString();
            ((TextBox)modificacionAeronave.Controls["textBoxKgDisponibles"]).Text = dataGridListadoAeronaves.SelectedCells[3].Value.ToString();
            ((ComboBox)modificacionAeronave.Controls["comboBoxFabricante"]).Text = dataGridListadoAeronaves.SelectedCells[4].Value.ToString();
            ((ComboBox)modificacionAeronave.Controls["comboBoxServicio"]).Text = dataGridListadoAeronaves.SelectedCells[5].Value.ToString();
            ((DateTimePicker)modificacionAeronave.Controls["timePickerAlta"]).Value = Convert.ToDateTime(dataGridListadoAeronaves.SelectedCells[7].Value.ToString());
            ((TextBox)modificacionAeronave.Controls["textBoxCantButacas"]).Text = dataGridListadoAeronaves.SelectedCells[8].Value.ToString();
            funcionesComunes.deshabilitarVentanaYAbrirNueva(modificacionAeronave);
        }

        private void bajaModificacionDeAeronave_Load(object sender, EventArgs e)
        {
            listado = SqlConnector.obtenerTablaSegunConsultaString("SELECT a.ID as Id, a.MATRICULA as Matricula, a.MODELO as Modelo, a.KG_DISPONIBLES as 'KG Disponibles', f.NOMBRE as Fabricante, ts.NOMBRE as Servicio, a.FECHA_ALTA as 'Fecha de Alta', a.CANT_BUTACAS as Butacas FROM AERO.aeronaves a, AERO.fabricantes f, AERO.tipos_de_servicio ts WHERE a.FABRICANTE_ID = f.ID AND a.TIPO_SERVICIO_ID = ts.ID AND a.BAJA IS NULL;");
            dataGridListadoAeronaves.DataSource = listado;
            dataGridListadoAeronaves.Columns[0].Visible = false;
        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            textFabricante.Clear();
            textMatricula.Clear();
            textModelo.Clear();
            textTipoServicio.Clear();
        }

        private void botonBuscar_Click(object sender, EventArgs e)
        {
            DataTable aeronavesFiltro = filtrarAeronave(textFabricante.Text, textMatricula.Text, textModelo.Text, textTipoServicio.Text);
            dataGridListadoAeronaves.DataSource = aeronavesFiltro;
        }

        private DataTable filtrarAeronave(string fabricante, string matricula, string modelo, string tipoServicio)
        {
            DataTable tablaAeronaves = listado;
            var final_rol = "";
            var posFiltro = true;
            var filtrosBusqueda = new List<string>();
            if (fabricante != "") filtrosBusqueda.Add("Fabricante LIKE '%" + fabricante + "%'");
            if (matricula != "") filtrosBusqueda.Add("Matricula LIKE '%" + matricula + "%'");
            if (modelo != "") filtrosBusqueda.Add("Modelo LIKE '%" + modelo + "%'");
            if (tipoServicio != "") filtrosBusqueda.Add("Servicio LIKE '%" + tipoServicio + "%'");

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
            if (tablaAeronaves != null)
                tablaAeronaves.DefaultView.RowFilter = final_rol;
            return tablaAeronaves;
        }

        private void botonBaja_Click(object sender, EventArgs e)
        {
            //TODO: dar de baja aeronave
        }
    }
}
