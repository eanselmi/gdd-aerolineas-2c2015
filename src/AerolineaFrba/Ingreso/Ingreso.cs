using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using AerolineaFrba;

namespace AerolineaFrba.Ingreso
{
    public partial class Ingreso : Form
    {
   
        public Ingreso()
        {
            InitializeComponent();
        }

        private void botonIngresar_Click(object sender, EventArgs e)
        {
           //Validar campos ingresados y buscar en la BD
           //Si valida correctamente ingresa
           //Apertura formulario menu para administrador
            SqlConnection cn = new SqlConnection("Data Source=(local)" + "\\" + "SQLSERVER2012;Initial Catalog=GD2C2015;User ID=gd;Password=gd2015;");
            cn.Open();
            SqlCommand cmd = new SqlCommand("select PASSWORD from AERO.usuarios where USERNAME = '" + this.textUsuario.Text + "'",cn);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            String contr = "";
            if (dr.HasRows) {
                while (dr.Read()){
                    contr = dr.GetString(0);
                }
                Base b = new Base();
                if (contr == b.pasarASha256(this.textPassword.Text)){
                    //TODO: update intento exitoso procedure
                    funcionesComunes.deshabilitarVentanaYAbrirNueva(new menuPrincipal());
                }else{
                    //TODO: update intento fallido procedure
                    MessageBox.Show("Contraseña inválida, tenga en cuenta que son 3 intentos en total");
                }
            }else{
                MessageBox.Show("Usuario inválido");
            }
            this.textUsuario.Clear();
            this.textPassword.Clear();
            dr.Close();
        }

        private void botonInvitado_Click(object sender, EventArgs e) {
            //Apertura formulario menu para invitado
            funcionesComunes.deshabilitarVentanaYAbrirNueva(new menuPrincipal());
        }

        //este boton borra el contenido de los input
        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            this.textUsuario.Clear();
            this.textPassword.Clear();
        }
    }
}
