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
            SqlCommand cmd = new SqlCommand("select PASSWORD, ACTIVO, INTENTOS_LOGIN from AERO.usuarios where USERNAME = '" + this.textUsuario.Text + "'", cn);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            String contr = "";
            int activo = -1;
            int intentos = -1;
            if (dr.HasRows) {
                while (dr.Read()){
                    contr = dr.GetString(0);
                    activo = (int)dr.GetInt32(1);
                    intentos = (int)dr.GetInt32(2);
                }
                dr.Close();
                Base b = new Base();
                if (activo == 1){
                    if (contr == b.pasarASha256(this.textPassword.Text)){
                        cmd = new SqlCommand("AERO.updateIntento", cn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@nombre", this.textUsuario.Text));
                        //exitoso = 1 es cuando pasa bien
                        cmd.Parameters.Add(new SqlParameter("@exitoso", 1));
                        dr = cmd.ExecuteReader();
                        funcionesComunes.deshabilitarVentanaYAbrirNueva(new menuPrincipal());
                    }else{
                        cmd = new SqlCommand("AERO.updateIntento", cn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@nombre", this.textUsuario.Text));
                        //exitoso != 1 es cuando pasa mal, no deja pasarle 0
                        cmd.Parameters.Add(new SqlParameter("@exitoso", 2));
                        dr = cmd.ExecuteReader();
                        MessageBox.Show("Contraseña inválida, le quedan " + (2-intentos) + " intentos");
                    }
                }else{
                    MessageBox.Show("El usuario ingresado esta inhabilitado, contacte al administrador");
                }
            }else{
                MessageBox.Show("Usuario inválido");
            }
            this.textUsuario.Clear();
            this.textPassword.Clear();
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
