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
using System.Collections;

namespace AerolineaFrba.Abm_Aeronave
{
    public partial class altaDeAeronave : Form
    {
        public altaDeAeronave()
        {
            InitializeComponent();
            funcionesComunes.llenarCombobox(comboBoxFabricante,"NOMBRE","select ID, NOMBRE from AERO.fabricantes");
            funcionesComunes.llenarCombobox(comboBoxServicio, "NOMBRE", "select ID, NOMBRE from AERO.tipos_de_servicio");
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            funcionesComunes.habilitarAnterior();
        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            this.textBoxCantButacas.Clear();
            this.textBoxKgDisponibles.Clear();
            this.textBoxMatricula.Clear();
            this.textBoxModelo.Clear();
            this.timePickerAlta.ResetText();
            this.comboBoxFabricante.SelectedIndex = -1;
            this.comboBoxServicio.SelectedIndex = -1;
        }

        private void botonGuardar_Click(object sender, EventArgs e)
        {
            String cantButacas = this.textBoxCantButacas.Text;
            String kg = this.textBoxKgDisponibles.Text;
            String matricula = this.textBoxMatricula.Text;
            String modelo = this.textBoxModelo.Text;
            Int32 fabricante = 0;
            Int32 servicio = 0;
            if (comboBoxFabricante.SelectedValue != null)
                fabricante = (Int32)comboBoxFabricante.SelectedValue;
            if (comboBoxServicio.SelectedValue != null)
                servicio = (Int32)this.comboBoxServicio.SelectedValue;
            if (cantButacas != "" && kg != "" && matricula != "" && modelo != "" && fabricante > 0 && servicio > 0)
                if(validarCampos(cantButacas, kg, matricula)){
                     //TODO: insertar en tabla aeronaves
                }else{
                    MessageBox.Show("Uno o más campos son inválidos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            else MessageBox.Show("Complete los campos requeridos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool validarCampos(String butacas, String kg, String matricula){
            if (Int32.Parse(butacas) < 0){
                return false;
            }
            if (Int32.Parse(kg) < 0){
                return false;
            }
            DataTable dt = new DataTable();
            dt = SqlConnector.obtenerTablaSegunConsultaString("select MATRICULA from AERO.aeronaves where MATRICULA = UPPER('"+ matricula +"')");
            if (dt.Rows.Count != 0){
                return false;
            }
            return true;
        }

        private void textBoxKgDisponibles_KeyPress(object sender, KeyPressEventArgs e)
        {
            funcionesComunes.soloNumeros(e);
        }

        private void textBoxCantButacas_KeyPress(object sender, KeyPressEventArgs e)
        {
            funcionesComunes.soloNumeros(e);
        }

        private void textBoxCantButacas_Enter(object sender, EventArgs e)
        {
            Clipboard.Clear();
        }

        private void textBoxKgDisponibles_Enter(object sender, EventArgs e)
        {
            Clipboard.Clear();
        }
    }
}
