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

namespace AerolineaFrba.Abm_Ruta
{
    public partial class altaDeRuta : Form
    {
        public altaDeRuta()
        {
            InitializeComponent();
            funcionesComunes.llenarCombobox(this.comboBoxOrigen, "NOMBRE","select ID,NOMBRE from AERO.aeropuertos");
            funcionesComunes.llenarCombobox(this.comboBoxDestino, "NOMBRE", "select ID,NOMBRE from AERO.aeropuertos");
            funcionesComunes.llenarCombobox(this.comboBoxServicios, "NOMBRE", "select ID, NOMBRE from AERO.tipos_de_servicio");
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
            this.textBoxCodigo.Clear();
            this.textBoxPrecioKg.Clear();
            this.textBoxPrecioPasaje.Clear();
            this.comboBoxDestino.SelectedIndex = -1;
            this.comboBoxOrigen.SelectedIndex = -1;
            this.comboBoxServicios.SelectedIndex = -1;
        }

        private void soloNumeros(object sender, KeyPressEventArgs e)
        {
            funcionesComunes.soloNumeros(e);
        }

        private void validacion(object sender, KeyPressEventArgs e)
        {
           
            if (this.textBoxPrecioKg.Text.Contains('.'))
                funcionesComunes.soloNumeros(e);
            else
                funcionesComunes.soloPrecio(e);

        }

        private void validacionPasaje(object sender, KeyPressEventArgs e)
        {
            if (this.textBoxPrecioPasaje.Text.Contains('.'))
                funcionesComunes.soloNumeros(e);
            else
                funcionesComunes.soloPrecio(e);
        }
    }
}
