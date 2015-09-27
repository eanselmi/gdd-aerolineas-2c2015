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

namespace AerolineaFrba.Abm_Ciudad
{
    public partial class altaDeCiudad : Form
    {
        public altaDeCiudad()
        {
            InitializeComponent();
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            funcionesComunes.habilitarAnterior();
        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            this.textBoxNombre.Clear();
        }

        private void botonGuardar_Click(object sender, EventArgs e)
        {
            String eleccionUsuario = this.textBoxNombre.Text;
            if (eleccionUsuario != "")
                //aca deberiamos hacer la funcionalidad del boton de guardar
                this.textBoxNombre.Clear();//este lo puse para poder poner el else (despues lo sacamos)
            else MessageBox.Show("Complete los campos requeridos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
