using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Ingreso
{
    public partial class Ingreso : Form
    {
        funcionesComunes funciones;
        public Ingreso()
        {
            InitializeComponent();
            funciones = new funcionesComunes();
        }

        private void botonIngresar_Click(object sender, EventArgs e)
        {
           //Validar campos ingresados y buscar en la BD
           //Si valida correctamente ingresa
           //Apertura formulario Administrador
            Usuarios.vistaAdministrador frmAdministrador = new Usuarios.vistaAdministrador();
            funciones.abrirNuevaVista(frmAdministrador,this);
            this.Close();
        }

        private void botonInvitado_Click(object sender, EventArgs e)
        {
            //Apertura formulario Invitado
            Usuarios.vistaInvitado frmInvitado = new Usuarios.vistaInvitado();
            frmInvitado.setearFormularioAnterior(this);
            funciones.abrirNuevaVista(frmInvitado, this);
        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            this.textUsuario.Clear();
            this.textPassword.Clear();
        }

        private void Ingreso_Load(object sender, EventArgs e)
        {

        }

   

    
    }
}
