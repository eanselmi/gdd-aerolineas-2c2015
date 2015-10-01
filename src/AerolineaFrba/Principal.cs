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
  
        
        public Principal()
        {
            InitializeComponent();
            
        }

        private void Principal_Load(object sender, EventArgs e)
        {

            if (funcionesComunes.conectarABaseDeDatos()){
                funcionesComunes.ventanaInicial(new Ingreso.Ingreso());
            }else{
                MessageBox.Show("Cierre el programa e intente nuevamente");
            }
            
     
        }
    }
}
