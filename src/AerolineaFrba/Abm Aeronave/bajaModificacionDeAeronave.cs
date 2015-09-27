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

namespace AerolineaFrba.Abm_Aeronave
{
    public partial class bajaModificacionDeAeronave : Form
    {
        public bajaModificacionDeAeronave()
        {
            InitializeComponent();
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            funcionesComunes.habilitarAnterior();
        }

        private void botonModificacion_Click(object sender, EventArgs e)
        {
            Form modificacionAeronave = new Abm_Aeronave.modificacionDeAeronave();
            ((TextBox)modificacionAeronave.Controls["textBoxMatricula"]).Text = "Probando";
            funcionesComunes.deshabilitarVentanaYAbrirNueva(modificacionAeronave);
        }
    }
}
