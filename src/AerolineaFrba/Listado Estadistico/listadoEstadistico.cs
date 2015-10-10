using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Listado_Estadistico
{
    public partial class listadoEstadistico : Form
    {
        public listadoEstadistico()
        {
            InitializeComponent();
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            funcionesComunes.habilitarAnterior();
        }

        private void botonConsultar_Click(object sender, EventArgs e)
        {
            //TODO:Realizar las consultas 

            switch ((String)this.comboBoxListados.SelectedItem)
            {
                case "Top 5 Destinos con más pasajes comprados":
                    //TODO
                    MessageBox.Show("Top 5 Destinos con más pasajes comprados");
                    break;
                case "Top 5 Destinos con aeronaves más vacias":
                    //TODO
                    MessageBox.Show("Top 5 Destinos con aeronaves más vacias");
                    break;
                case "Top 5 Clientes con más puntos acumulados a la fecha":
                    //TODO
                    MessageBox.Show("Top 5 Clientes con más puntos acumulados a la fechas");
                    break;
                case "Top 5 Destinos con más pasajes cancelados":
                    //TODO
                    MessageBox.Show("Top 5 Destinos con más pasajes cancelados");
                    break;
                case "Top 5 Aeronaves con mayor cantidad de dias fuera de servicio":
                    //TODO
                    MessageBox.Show("Top 5 Aeronaves con mayor cantidad de dias fuera de servicio");
                    break;
            }
        }
    }
}
