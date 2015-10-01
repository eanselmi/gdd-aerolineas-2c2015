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
            try {
                SqlConnection cn = funcionesComunes.getCn();
                SqlCommand cmd = new SqlCommand("select u.PASSWORD, u.ACTIVO, u.INTENTOS_LOGIN, r.NOMBRE from AERO.usuarios u,AERO.roles r  where u.USERNAME = '" + this.textUsuario.Text + "' AND r.ID = u.ROL_ID", cn);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                String contr = "";
                int activo = -1;
                int intentos = -1;
                String nombreRol = " ";
                if (dr.HasRows) {
                    while (dr.Read()) {
                        contr = dr.GetString(0);
                        activo = (int)dr.GetInt32(1);
                        intentos = (int)dr.GetInt32(2);
                        nombreRol = dr.GetString(3);
                    }
                    dr.Close();
                    Base b = new Base();
                    if (activo == 1) {
                        if (contr == b.pasarASha256(this.textPassword.Text)) {
                            try {
                                cmd = new SqlCommand("AERO.updateIntento", cn);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add(new SqlParameter("@nombre", this.textUsuario.Text));
                                //exitoso = 1 es cuando pasa bien
                                cmd.Parameters.Add(new SqlParameter("@exitoso", 1));
                                dr = cmd.ExecuteReader();
                                menuPrincipal menu = new menuPrincipal();
                                menu.textUsuario.Text = this.textUsuario.Text;
                                menu.textPassword.Text = nombreRol;
                                funcionesComunes.deshabilitarVentanaYAbrirNueva(menu);
                            }
                            catch (Exception ex){
                                MessageBox.Show(ex.Message);
                            }
                        } else {
                            try {
                                cmd = new SqlCommand("AERO.updateIntento", cn);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add(new SqlParameter("@nombre", this.textUsuario.Text));
                                //exitoso != 1 es cuando pasa mal, no deja pasarle 0
                                cmd.Parameters.Add(new SqlParameter("@exitoso", 2));
                                dr = cmd.ExecuteReader();
                                MessageBox.Show("Contraseña inválida, le quedan " + (2 - intentos) + " intentos");
                            }
                            catch (Exception ex) {
                                MessageBox.Show(ex.Message);
                            }

                        }
                    } else {
                        MessageBox.Show("El usuario ingresado esta inhabilitado, contacte al administrador");
                    }
                } else {
                    MessageBox.Show("Usuario inválido");
                }
                this.textUsuario.Clear();
                this.textPassword.Clear();
            }catch(Exception ex){
                MessageBox.Show(ex.Message);
            }

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
