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
    public partial class viajesDisponibles : Form
    {
        public viajesDisponibles()
        {
            InitializeComponent();
        }

        private void consultarViajes()
        {   
            //TODO:Hacer o un procedure o funcion para sacar la cantidad de butacas y kg libres
            //DataTable listado = SqlConnector
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            funcionesComunes.habilitarAnterior();
        }

        private void botonComprar_Click(object sender, EventArgs e)
        {
            Form frmCargaDeDatos = new Compra.cargaDeDatos();
            funcionesComunes.deshabilitarVentanaYAbrirNueva(frmCargaDeDatos);
        }

        private void botonBuscar_Click(object sender, EventArgs e)
        {
            if (comboBoxOrigen.SelectedIndex != comboBoxDestino.SelectedIndex){

                   if (timePickerFecha.Value >= DateTime.Today)
                      {
                      //dataGridViajes.DataSource = filtrarViajes();
                      //dataGridViajes.Columns[0].Visible = false;
                      }
                   else
                      {
                          MessageBox.Show("La fecha seleccionada debe ser el dia actual o posterior al dia actual");
                      }
            }else{
                MessageBox.Show("La ciudad de origen no puede ser la misma que la de destino");
            }
        }

        private void filtrarViajes()
        {   //TODO: Hacer filtrado
           
        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
            this.comboBoxOrigen.SelectedIndex = -1;
            this.comboBoxDestino.SelectedIndex = -1;
        }

        private void Limpiar()
        {
            this.timePickerFecha.ResetText();
            this.numericUpDownEncomiendas.ResetText();
            this.numericUpDownPasajes.ResetText();
            this.comboBoxOrigen.SelectedIndex = -1;
            this.comboBoxDestino.SelectedIndex = -1;
        }

        private void viajesDisponibles_Load(object sender, EventArgs e)
        {
            llenarComboBoxs();
        }

        private void llenarComboBoxs()
        {
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            dt1 = SqlConnector.obtenerTablaSegunConsultaString("select c.ID, c.NOMBRE from aero.ciudades c order by c.NOMBRE");
            comboBoxOrigen.DataSource = dt1;
            comboBoxOrigen.DisplayMember = "NOMBRE";
            comboBoxOrigen.ValueMember = "ID";
            dt2 = SqlConnector.obtenerTablaSegunConsultaString("select c.ID, c.NOMBRE from aero.ciudades c order by c.NOMBRE");
            comboBoxDestino.DataSource = dt2;
            comboBoxDestino.DisplayMember = "NOMBRE";
            comboBoxDestino.ValueMember = "ID";
        }
    }
}
