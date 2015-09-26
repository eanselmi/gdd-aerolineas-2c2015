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

namespace AerolineaFrba.Consulta_Millas
{
    public partial class consultaMillas : Form
    {
       
        public consultaMillas()
        {
            InitializeComponent();
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            funcionesComunes.habilitarAnterior();
        }

        //este boton borra el contenido del textbox
        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            this.textBoxDNI.Clear();
        }

        //este boton le cambia el valor al label con la cantidad de millas del usuario
        private void botonConsultar_Click(object sender, EventArgs e)
        {
            String dni = this.textBoxDNI.Text;
            if (dni != "") { }
               
            else MessageBox.Show("Complete los campos requeridos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
