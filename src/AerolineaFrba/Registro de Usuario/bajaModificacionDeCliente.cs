using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Registro_de_Usuario
{
    public partial class bajaModificacionDeCliente : Form
    {
        DataTable listado;
        public bajaModificacionDeCliente()
        {
            InitializeComponent();
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            funcionesComunes.habilitarAnterior();
        }

        private void bajaModificacionDeCliente_Load(object sender, EventArgs e)
        {
            listado = SqlConnector.obtenerTablaSegunConsultaString("select NOMBRE as Nombre, APELLIDO as Apellido, DNI as Dni, DIRECCION as Dirección, TELEFONO as Teléfono, MAIL as Mail, FECHA_NACIMIENTO as 'Fecha de Nacimiento' from AERO.clientes ");
            dataGridListadoClientes.DataSource = listado;
        }

    }
}
