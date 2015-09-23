using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AerolineaFrba
{
    class funcionesComunes
    {
        public void abrirNuevaVista(System.Windows.Forms.Form vista,System.Windows.Forms.Form padre){
            vista.MdiParent = Principal.ActiveForm;
            //vista.Parent = padre;
            vista.Show();
            padre.Close();
        }
    }
}
