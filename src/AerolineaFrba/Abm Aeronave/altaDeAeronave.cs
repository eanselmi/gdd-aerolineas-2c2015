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
    public partial class altaDeAeronave : Form
    {
        public altaDeAeronave()
        {
            InitializeComponent();
        }

        private void botonCancelar_Click(object sender, EventArgs e)
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
            String fabricante = (String) this.comboBoxFabricante.SelectedItem;
            String servicio = (String) this.comboBoxServicio.SelectedItem;
            if (cantButacas != "" && kg != "" && matricula != "" && modelo != "" && fabricante != null && servicio != null)
                //aca deberiamos hacer la funcionalidad del boton de guardar
                this.textBoxModelo.Clear();//este lo puse para poder poner el else (despues lo sacamos)
            else MessageBox.Show("Complete los campos requeridos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
