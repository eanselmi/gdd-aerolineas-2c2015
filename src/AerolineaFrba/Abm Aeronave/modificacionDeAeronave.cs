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
    public partial class modificacionDeAeronave : Form
    {
        public modificacionDeAeronave()
        {
            InitializeComponent();
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            funcionesComunes.habilitarAnterior();
        }

        private void textBoxMatricula_KeyPress(object sender, KeyPressEventArgs e)
        {
            funcionesComunes.soloMail(e);
        }

        private void textBoxModelo_KeyPress(object sender, KeyPressEventArgs e)
        {
            funcionesComunes.soloLetrasYNumeros(e);
        }

        private void textBoxKgDisponibles_KeyPress(object sender, KeyPressEventArgs e)
        {
            funcionesComunes.soloNumeros(e);
        }

        private void textBoxCantButacas_KeyPress(object sender, KeyPressEventArgs e)
        {
            funcionesComunes.soloNumeros(e);
        }


    }
}
