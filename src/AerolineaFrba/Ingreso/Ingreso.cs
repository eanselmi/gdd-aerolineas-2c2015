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
           //Apertura formulario menu para administrador
            funcionesComunes.deshabilitarVentanaYAbrirNueva(new menuPrincipal());
           
        }

        private void botonInvitado_Click(object sender, EventArgs e)
        {
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
