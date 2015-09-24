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
           //Apertura formulario Administrador
            Usuarios.vistaAdministrador frmAdministrador = new Usuarios.vistaAdministrador();
        }

        private void botonInvitado_Click(object sender, EventArgs e)
        {
            //Apertura formulario Invitado
            funcionesComunes.deshabilitarVentanaYAbrirNueva(new Usuarios.vistaInvitado());
            
          
        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            this.textUsuario.Clear();
            this.textPassword.Clear();
        }

 
    }
}
