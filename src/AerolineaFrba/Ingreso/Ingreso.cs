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
           
                String contr = "";
                int activo = -1;
                int intentos = -1;
                String nombreRol = " ";
                DataTable usuario = SqlConnector.obtenerTablaSegunConsultaString(@"select u.PASSWORD, u.ACTIVO, 
                    u.INTENTOS_LOGIN, r.NOMBRE from AERO.usuarios u,AERO.roles r  where 
                    u.USERNAME = '" + this.textUsuario.Text + "' AND r.ID = u.ROL_ID");
               
                if (usuario.Rows.Count > 0) {
                        contr = (String)usuario.Rows[0].ItemArray[0];
                        activo = (int)usuario.Rows[0].ItemArray[1];
                        intentos = (int)usuario.Rows[0].ItemArray[2];
                        nombreRol = (String)usuario.Rows[0].ItemArray[3];
                    if (activo == 1) {
                        if (contr == Base.pasarASha256(this.textPassword.Text)) {
                          
                            List < string > lista = new List<string>();
                            lista.Add("@nombre");
                            lista.Add("@exitoso");
                            SqlConnector.executeProcedure("AERO.updateIntento",lista, this.textUsuario.Text,1);
                            menuPrincipal menu = new menuPrincipal();
                            funcionesComunes.setRol(nombreRol);
                            funcionesComunes.deshabilitarVentanaYAbrirNueva(menu);
                       
                        } else {
                      
                            List<string> lista = new List<string>();
                            lista.Add("@nombre");
                            lista.Add("@exitoso");
                            SqlConnector.executeProcedure("AERO.updateIntento", lista, this.textUsuario.Text,2);
                            MessageBox.Show("Contraseña inválida, le quedan " + (2 - intentos) + " intentos"); 

                        }
                    } else {
                        MessageBox.Show("El usuario ingresado esta inhabilitado, contacte al administrador");
                    }
                } else {
                    MessageBox.Show("Usuario inválido");
                }
                this.textUsuario.Clear();
                this.textPassword.Clear();

        }

        private void botonInvitado_Click(object sender, EventArgs e) {
            //Apertura formulario menu para invitado
            funcionesComunes.setRol("cliente");
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
