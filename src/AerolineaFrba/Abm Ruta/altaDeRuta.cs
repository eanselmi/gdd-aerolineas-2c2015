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
            funcionesComunes.precioONumeros(this.textBoxPrecioKg, e);
        }

        private void validacionPasaje(object sender, KeyPressEventArgs e)
        {
            funcionesComunes.precioONumeros(this.textBoxPrecioPasaje, e);
        }

        private void botonGuardar_Click(object sender, EventArgs e)
        {
            //TODO: validaciones de campos requeridos y que el destino no sea el mismo que el origen
            Int32 codigo = Int32.Parse(textBoxCodigo.Text);
            //TODO: hay que ver como convertir a numeric(18,2) y como redondear a 2 decimales
            Double precioKg = Math.Round(Double.Parse(textBoxPrecioKg.Text), 2);
            Double precioPasaje = Math.Round(Double.Parse(textBoxPrecioPasaje.Text), 2);
            MessageBox.Show("precio base kg: " + precioKg + " precio base pasaje: " + precioPasaje);
            Int32 origen = (Int32)comboBoxOrigen.SelectedValue;
            Int32 destino = (Int32)comboBoxDestino.SelectedValue;
            Int32 servicio = (Int32)comboBoxServicios.SelectedValue;
            List<string> lista = new List<string>();
            lista.Add("@codigo");
            lista.Add("@precioKg");
            lista.Add("@precioPasaje");
            lista.Add("@origen");
            lista.Add("@destino");
            lista.Add("@servicio");
            bool resultado = SqlConnector.executeProcedure("AERO.agregarRuta", lista, codigo, precioKg, precioPasaje, 
                origen, destino, servicio);
            if (resultado)
            {
                MessageBox.Show("Se guardo exitosamente");
                limpiar();
            }
        }
    }
}
