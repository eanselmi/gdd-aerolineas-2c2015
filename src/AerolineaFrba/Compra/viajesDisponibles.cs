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
            funcionesComunes.llenarCombobox(this.comboBoxOrigen, "NOMBRE", "select ID,NOMBRE from AERO.aeropuertos");
            funcionesComunes.llenarCombobox(this.comboBoxDestino, "NOMBRE", "select ID,NOMBRE from AERO.aeropuertos");
            consultarViajes();
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
            dataGridViajes.DataSource = filtrarViajes();
            dataGridViajes.Columns[0].Visible = false;
        }

        private object filtrarViajes()
        {   //TODO: Hacer filtrado
            throw new NotImplementedException();
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
    }
}
