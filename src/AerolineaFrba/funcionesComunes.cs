using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;


namespace AerolineaFrba
{
    //creamos una clase con funciones que utilizan las demas para no repetir codigo
    class funcionesComunes
    {
        #region Singletons Ventanas
        private static Form ventanaAnterior;
        private static Form ventanaActual;
        private static List<Form> listaVentanas = new List<Form>();
        private static int pos;

        //lo que hace esta funcion es setear cual es la ventana principal
        public static void ventanaInicial(Form ventanaInicial)
        {
            listaVentanas.Add(ventanaInicial);
            ventanaInicial.MdiParent = Principal.ActiveForm;
            ventanaInicial.Show();
        }

        //esta funcion abre una ventana nueva seteando la anterior para luego poder volver atras
        public static void deshabilitarVentanaYAbrirNueva(Form ventanaNueva)
        {
            pos = listaVentanas.Count();
            ventanaAnterior = listaVentanas[pos -1];
            ventanaAnterior.Hide();
            listaVentanas.Add(ventanaNueva);
            ventanaNueva.MdiParent = Principal.ActiveForm;
            ventanaNueva.Show();
        }


        //esta funcion permite volver a la ventana anterior
        public static void habilitarAnterior()
        {
            pos = listaVentanas.Count();
            if (pos > 0)
            {
                ventanaAnterior = listaVentanas[pos - 2];
                ventanaActual = listaVentanas[pos - 1];
                ventanaActual.Close();
                listaVentanas.RemoveAt(pos - 1);
                ventanaAnterior.Show();
            }
        }

        //esta funcion permite volver al menu principal
        public static void volverAMenuPrincipal()
        {
            pos = listaVentanas.Count();
            ventanaActual = listaVentanas[pos - 1];
            ventanaActual.Hide();
            while (pos > 2)
            {
                listaVentanas.RemoveAt(pos - 1);
                pos = pos - 1;
            }
            pos = listaVentanas.Count();
            ventanaActual = listaVentanas[pos - 1];
            ventanaActual.Show();
        }
        #endregion

        #region conexion

        private static SqlConnection cn;
        public static bool conectarABaseDeDatos(){
            try{
                cn = new SqlConnection("Data Source=(local)" + "\\" + "SQLSERVER2012;Initial Catalog=GD2C2015;User ID=gd;Password=gd2015;");
                cn.Open();
                return true;
            }catch{
                MessageBox.Show("No se puede conectar a la base de datos");
                return false;
            }
          
        }

        public static SqlConnection getCn() {
            return cn;
        }


        #endregion

    }
}
