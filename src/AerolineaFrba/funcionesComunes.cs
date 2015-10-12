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

        #region rol

        private static string rol;
        private static Int32 idRol;
        public static void setRol(String r)
        {
            rol = r;
        }
        public static String getRol()
        {
            return rol;
        }

        public static Int32 getIdRolCliente()
        {
            return idRol;
        }

        public static void setIdRolCliente(Int32 id)
        {
            idRol = id;
        }


        #endregion

        #region llenado
        public static void llenarCombobox(ComboBox combo, String display, String query)
        {
            DataTable dt = new DataTable();
            dt = SqlConnector.obtenerTablaSegunConsultaString(query);
            combo.Items.Clear();
            combo.DataSource = dt;
            combo.ValueMember = "ID";
            combo.DisplayMember = display;
            combo.SelectedIndex = -1;
        }

        public static void soloNumeros(KeyPressEventArgs e)
        {
            if (!((char.IsDigit(e.KeyChar)) || (e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
            }
        }

        public static void soloPrecio(KeyPressEventArgs e)
        {   
            if (!((char.IsDigit(e.KeyChar)) || (e.KeyChar == '.') || (e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
            }
        }

        public static void precioONumeros(TextBox textbox, KeyPressEventArgs e)
        {
            if (textbox.Text.Contains('.'))
                funcionesComunes.soloNumeros(e);
            else
                funcionesComunes.soloPrecio(e);
        }

        public static void soloLetras(KeyPressEventArgs e)
        {
            if (!((char.IsLetter(e.KeyChar)) || (e.KeyChar == (char)Keys.Back) || (e.KeyChar == (char)Keys.Space)))
            {
                 e.Handled = true;
            }
        }

        public static void soloMail(KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                e.Handled = true;
            }
        }

        public static void soloLetrasYNumeros(KeyPressEventArgs e)
        {
            if (!((char.IsLetter(e.KeyChar)) || (e.KeyChar == (char)Keys.Back) || (e.KeyChar == (char)Keys.Space) || (char.IsDigit(e.KeyChar))))
            {
                e.Handled = true;
            }
        }

       

        #endregion
    }
}
