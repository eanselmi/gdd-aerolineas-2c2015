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
    public partial class bajaModificacionDeRuta : Form
    {
        DataTable listado;
        public bajaModificacionDeRuta()
        {
            InitializeComponent();
        }

        private void botonModificacion_Click(object sender, EventArgs e)
        {
            Form modificacionRuta = new Abm_Ruta.modificacionDeRuta();
            ((TextBox)modificacionRuta.Controls["textBoxId"]).Text = dataGridListadoRutas.SelectedCells[0].Value.ToString();
            ((TextBox)modificacionRuta.Controls["textBoxCodigo"]).Text = dataGridListadoRutas.SelectedCells[1].Value.ToString();
            ((TextBox)modificacionRuta.Controls["textBoxPrecioKg"]).Text = dataGridListadoRutas.SelectedCells[2].Value.ToString().Replace(',','.');
            ((TextBox)modificacionRuta.Controls["textBoxPrecioPasaje"]).Text = dataGridListadoRutas.SelectedCells[3].Value.ToString().Replace(',', '.');
            ((TextBox)modificacionRuta.Controls["textBoxOrigen"]).Text = dataGridListadoRutas.SelectedCells[4].Value.ToString();
            ((TextBox)modificacionRuta.Controls["textBoxDestino"]).Text = dataGridListadoRutas.SelectedCells[5].Value.ToString();
            ((ComboBox)modificacionRuta.Controls["comboBoxServicios"]).Text = dataGridListadoRutas.SelectedCells[6].Value.ToString();
            funcionesComunes.deshabilitarVentanaYAbrirNueva(modificacionRuta);
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            funcionesComunes.habilitarAnterior();
        }

        private void bajaModificacionDeRuta_Load(object sender, EventArgs e)
        {
            consultarRutas();
        }

        private void consultarRutas()
        {
            listado = SqlConnector.obtenerTablaSegunConsultaString(@"SELECT r.ID as ID,r.CODIGO as Codigo,
                r.PRECIO_BASE_KG as 'Precio Base Kg',
                r.PRECIO_BASE_PASAJE as 'Precio Base Pasaje',c1.NOMBRE as Origen,
                c2.NOMBRE as Destino,t.NOMBRE as 'Tipo de Servicio' 
                from AERO.rutas r, AERO.aeropuertos c1,AERO.aeropuertos c2,AERO.tipos_de_servicio t  
                WHERE  r.ORIGEN_ID = c1.ID AND r.DESTINO_ID=c2.ID AND r.TIPO_SERVICIO_ID = t.ID ");
            dataGridListadoRutas.DataSource = listado;
            dataGridListadoRutas.Columns[0].Visible = false;
        }
    }
}
