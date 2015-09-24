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

namespace AerolineaFrba.Usuarios
   
{
    public partial class vistaInvitado : Form
    {
  
        public vistaInvitado()
        {
            InitializeComponent();
           
        }


        private void botonConsultarMillas_Click(object sender, EventArgs e)
        {
            //Abre el formulario para consultar millas
            funcionesComunes.deshabilitarVentanaYAbrirNueva(new Consulta_Millas.vistaConsultaMillas());
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            funcionesComunes.habilitarAnterior();
        }


  
    }
}
