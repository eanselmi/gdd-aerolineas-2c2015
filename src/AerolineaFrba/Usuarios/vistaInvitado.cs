using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Usuarios
   
{
    public partial class vistaInvitado : Form
    {
        funcionesComunes funciones;
        public vistaInvitado()
        {
            InitializeComponent();
            funciones = new funcionesComunes();
        }

        private void vistaInvitado_Load(object sender, EventArgs e)
        {

        }

        private void botonConsultarMillas_Click(object sender, EventArgs e)
        {
            //Abre el formulario para consultar millas
            Consulta_Millas.vistaConsultaMillas frmMillas = new Consulta_Millas.vistaConsultaMillas();
            funciones.abrirNuevaVista(frmMillas,this);
            
        }

  
    }
}
