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
            this.timePickerVencimiento.ResetText();
        }

        private void botonGuardar_Click(object sender, EventArgs e)
        {
            String dni = this.textBoxDni.Text;
            String numero = this.textBoxNumero.Text;
            String func = (String) this.comboBoxTipoTarjeta.SelectedItem;
            if (dni != "" && numero != "" && func != null)
                this.textBoxNumero.Clear();
            else MessageBox.Show("Complete los campos requeridos", "Error", MessageBoxButtons.OK, 
                MessageBoxIcon.Error);
        }
    }
}
