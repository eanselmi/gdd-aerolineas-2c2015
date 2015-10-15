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

namespace AerolineaFrba.Registro_Llegada_Destino
{
    public partial class registroDeLlegadaADestino : Form
    {
        public registroDeLlegadaADestino()
        {
            InitializeComponent();
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            funcionesComunes.habilitarAnterior();
        }

        private void matricula(object sender, KeyPressEventArgs e)
        {
            funcionesComunes.martricula(this.textBoxMatricula, e);
        }

        private void botonBuscar_Click(object sender, EventArgs e)
        {
            DataTable filtradoVuelos = filtradoDeVuelos(this.textBoxMatricula.Text);
            dataGridListadoVuelos.DataSource = filtradoVuelos;
            dataGridListadoVuelos.Columns[0].Visible = false;
            
        }

        private DataTable filtradoDeVuelos(string matricula)
        {
            DataTable tablaVuelos = consultarVuelos();
            var final_rol = "";
            var posFiltro = true;
            var filtrosBusqueda = new List<string>();

            if (matricula != "") filtrosBusqueda.Add("Matricula LIKE '%" + matricula + "%'");

            foreach (var filtro in filtrosBusqueda)
            {
                if (!posFiltro)
                    final_rol += " AND " + filtro;
                else
                {
                    final_rol += filtro;
                    posFiltro = false;
                }
            }
            if (tablaVuelos != null)
                tablaVuelos.DefaultView.RowFilter = final_rol;

            return tablaVuelos;
        }

        private DataTable consultarVuelos()
        {
            DataTable listado = SqlConnector.obtenerTablaSegunConsultaString(@"select v.ID as ID,a.MATRICULA as Matricula,r.CODIGO as 'Codigo de Ruta',
                                                    o.NOMBRE as Origen,d.NOMBRE as Destino,v.FECHA_SALIDA as 'Fecha De Salida' 
                                                    from AERO.vuelos v join Aero.aeronaves a on v.AERONAVE_ID = a.ID
                                                    join AERO.rutas r on v.RUTA_ID = r.ID
                                                    join AERO.aeropuertos o on r.ORIGEN_ID = o.ID
                                                    join AERO.aeropuertos d on r.DESTINO_ID = d.ID
                                                    where v.FECHA_LLEGADA IS NULL");
            return listado;
        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void limpiar()
        {
            this.textBoxMatricula.Clear();
            this.timePickerLlegada.ResetText();
            this.dataGridListadoVuelos.DataSource = null;
        }

        private void botonRegistrar_Click(object sender, EventArgs e)
        {
            if (validarRegistro()) {
                List<string> lista = new List<string>();
                lista.Add("@idVuelo");
                lista.Add("@fechaLlegada");
                bool resultado = SqlConnector.executeProcedure("AERO.registrarLlegada", lista, dataGridListadoVuelos.SelectedCells[0].Value.ToString(), Convert.ToDateTime(this.timePickerLlegada.Value));
                if (resultado)
                {
                    MessageBox.Show("Se registro exitosamente la fecha de llegada");
                    limpiar();
                    this.botonBuscar.PerformClick();
                }
            }
        }

        private bool validarRegistro()
        {        DateTime fechaSalida=Convert.ToDateTime (dataGridListadoVuelos.SelectedCells[5].Value.ToString());
             if (this.timePickerLlegada.Value < fechaSalida)
                 {
                    MessageBox.Show("No puede haber una fecha de llega antes de la de salida");
                    return false;
                 }
            if (fechaSalida.AddDays((double)1) < timePickerLlegada.Value)
                {
                     MessageBox.Show("La fecha de llegada no puede ser mayor a 24hs de la de salida");
                     return false;
                }
            return true;
        }
    }
}
