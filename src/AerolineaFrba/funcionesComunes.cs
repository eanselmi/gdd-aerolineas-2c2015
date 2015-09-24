using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace AerolineaFrba
{
    class funcionesComunes
    {
        #region Singletons Ventanas
        private static Form ventanaAnterior;
        private static Form ventanaActual;
        private static List<Form> listaVentanas = new List<Form>();
        private static int pos;

        public static void ventanaInicial(Form ventanaInicial)
        {
            listaVentanas.Add(ventanaInicial);
            ventanaInicial.MdiParent = Principal.ActiveForm;
            ventanaInicial.Show();
        }

        public static void deshabilitarVentanaYAbrirNueva(Form ventanaNueva)
        {
            pos = listaVentanas.Count();
            ventanaAnterior = listaVentanas[pos -1];
            ventanaAnterior.Hide();
            listaVentanas.Add(ventanaNueva);
            ventanaNueva.MdiParent = Principal.ActiveForm;
            ventanaNueva.Show();
        }

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

        #endregion

       
    }
}
