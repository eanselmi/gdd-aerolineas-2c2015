using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Abm_Rol
{
    public partial class altaModificacionDeRol : Form
    {
        public altaModificacionDeRol()
        {
            InitializeComponent();
        }

        private void altaModificacionDeRol_Load(object sender, EventArgs e)
        {
            cargarComboBoxFuncionalidades();
            if (textTipoForm.Text == "0")
            {
                botonAgregar.Enabled = false;
                botonQuitar.Enabled = false;
            }
            else
            {
                cargarFuncionalidadesDelRol();
                botonCrearRol.Visible = false;
                textRol.Enabled = false;
            }
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            funcionesComunes.habilitarAnterior();
        }

        private void cargarComboBoxFuncionalidades()
        {
            DataTable dt = new DataTable();
            dt = SqlConnector.obtenerTablaSegunConsultaString("select f.ID, f.DETALLES from aero.funcionalidades f");
            foreach (DataRow row in dt.Rows)
            comboBoxFuncionalidades.Items.Add(row.ItemArray[1].ToString());
            comboBoxFuncionalidades.DisplayMember = "DETALLES";
            comboBoxFuncionalidades.SelectedIndex = 0;
        }

        private void cargarFuncionalidadesDelRol()
        {
            DataTable listado;
            listado = SqlConnector.obtenerTablaSegunConsultaString(@"select f.ID as Id, f.DETALLES as Funcionalidad from AERO.funcionalidades_por_rol fr inner join AERO.funcionalidades f on fr.FUNCIONALIDAD_ID = f.ID where fr.ROL_ID = '" + textId.Text + "'");
            dataGridFuncionalidades.DataSource = listado;
            dataGridFuncionalidades.Columns[0].Visible = false;
        }

        private void botonCrearRol_Click(object sender, EventArgs e)
        {
            //Aca haria todo el procedure de creacion de Rol en la tabla roles, me devuelve el Id y lo guardo en textId
            //Si guarda bien hace lo siguiente:
            botonCrearRol.Visible = false;
            botonAgregar.Enabled = true;
            botonQuitar.Enabled = true;
        }

        private void botonAgregar_Click(object sender, EventArgs e)
        {
            //Agregaria las funcionalidades a la tabla detalle por rol. 
            //El id del rol lo obtiene del textId y el id de funcionalidad lo obtiene de la primer columna del dataGrid
        }

        private void botonQuitar_Click(object sender, EventArgs e)
        {
            //Toma la selected row y ejecuta la query eliminando en la tabla de funcionalidades por row usando el id de funcionalidad que es la primer
            //Columna del datagrid y el idrol que lo toma del textId
        }


    }
}
