using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Consulta_Millas
{
    public partial class vistaConsultaMillas : Form
    {
        Form formularioAnterior;
        public vistaConsultaMillas()
        {
            InitializeComponent();
        }

        public void setFormularioAnterior(Form formulario)
        {
            formularioAnterior = formulario;
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            formularioAnterior.Show();
            this.Close();
        }
    }
}
