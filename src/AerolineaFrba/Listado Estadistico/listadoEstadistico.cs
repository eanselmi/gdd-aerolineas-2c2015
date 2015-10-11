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
            pickerAño.Format = DateTimePickerFormat.Custom;
            pickerAño.CustomFormat = "yyyy";
            pickerAño.ShowUpDown = true;
            comboBoxSemestre.SelectedIndex = 0;
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            funcionesComunes.habilitarAnterior();
        }

        private void botonConsultar_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            Int32 mesInicio;
            Int32 mesFin;
            if (comboBoxSemestre.SelectedIndex == 0){
                mesInicio = 1;
                mesFin = 6;
            }else{
                mesInicio = 7;
                mesFin = 12;
            }
            //Creo las fechas de inicio y fin dependiendo del año y el semestre elegido
            DateTime fechaInicio = new DateTime(Int32.Parse(pickerAño.Text), mesInicio, 1);
            DateTime fechaFin = new DateTime(Int32.Parse(pickerAño.Text), mesFin, 1);
            MessageBox.Show("Fecha Inicio: " + fechaInicio + " Fecha Fin: " + fechaFin);
            //TODO: tenemos que agarrar las fechas de inicio y fin del semestre para hacer las queries
            switch ((String)this.comboBoxListados.SelectedItem)
            {
                case "Top 5 Destinos con más pasajes comprados":
                    dt = SqlConnector.obtenerTablaSegunConsultaString(@"select top 5 a.NOMBRE as Destino, 
                        count(p.ID) as 'Cantidad de Pasajes' from AERO.aeropuertos a join AERO.rutas r on 
                        a.ID=r.DESTINO_ID join AERO.vuelos v on r.ID=v.RUTA_ID join AERO.aeronaves naves on 
                        v.AERONAVE_ID= naves.ID join AERO. butacas b on naves.ID=b.AERONAVE_ID join 
                        AERO.pasajes p on b.ID=p.BUTACA_ID group by a.nombre order by 2 desc");
                    break;
                case "Top 5 Destinos con aeronaves más vacias":
                    dt = SqlConnector.obtenerTablaSegunConsultaString(@"select a.NOMBRE as Destino, naves.ID as 
                        'ID de Aeronave', count(b.ID) as 'Butacas Vacias' from AERO.aeronaves naves join 
                        AERO.butacas b on naves.ID = b.Aeronave_id join AERO.vuelos v on naves.ID=v.AERONAVE_ID 
                        join AERO.rutas r on v.RUTA_ID=r.ID join AERO.aeropuertos a on r.DESTINO_ID=a.ID where 
                        b.ESTADO = 'LIBRE' group by a.NOMBRE, naves.ID order by 3 desc");
                    break;
                case "Top 5 Clientes con más puntos acumulados a la fecha":
                    dt = SqlConnector.obtenerTablaSegunConsultaString(@"select c.nombre as 'Nombre Cliente', 
                        sum(bc.millas) as 'Cantidad de Millas' from AERO.clientes c join AERO.pasajes p on 
                        c.ID=p.CLIENTE_ID join AERO.boletos_de_compra bc on p.BOLETO_COMPRA_ID=bc.ID where 
                        bc.ID NOT IN (select BOLETO_COMPRA_ID from AERO.cancelaciones) group by c.nombre order 
                        by 2 desc");
                    break;
                case "Top 5 Destinos con más pasajes cancelados":
                    dt = SqlConnector.obtenerTablaSegunConsultaString(@"select top 5 a.NOMBRE as Destino, 
                        count(c.ID) as 'Cantidad de Cancelaciones' from AERO.aeropuertos a join AERO.rutas r on 
                        a.ID=r.DESTINO_ID join AERO.vuelos v on r.ID=v.RUTA_ID join AERO.aeronaves naves on 
                        v.AERONAVE_ID= naves.ID join AERO. butacas b on naves.ID=b.AERONAVE_ID join 
                        AERO.pasajes p on b.ID=p.BUTACA_ID join AERO.boletos_de_compra bc on 
                        p.BOLETO_COMPRA_ID=bc.ID join AERO.cancelaciones c on bc.ID=c.BOLETO_COMPRA_ID group by 
                        a.nombre order by 2 desc");
                    break;
                case "Top 5 Aeronaves con mayor cantidad de dias fuera de servicio":
                    //TODO
                    MessageBox.Show("Top 5 Aeronaves con mayor cantidad de dias fuera de servicio");
                    break;
            }
            this.dataGridListadoEstadistico.DataSource = dt;
        }
    }
}
