using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace AerolineaFrba
{
    
    public partial class Principal : Form
    {
        funcionesComunes funciones;
        
        public Principal()
        {
            InitializeComponent();
            funciones = new funcionesComunes();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
           
            Ingreso.Ingreso frmIngreso = new Ingreso.Ingreso();
            frmIngreso.MdiParent = this;
            frmIngreso.Show();
        }
    }
}
