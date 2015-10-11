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
            funcionesComunes.deshabilitarVentanaYAbrirNueva(new Abm_Ruta.modificacionDeRuta());
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
