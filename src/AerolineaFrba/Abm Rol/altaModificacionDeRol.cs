﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace AerolineaFrba.Abm_Rol
{
    public partial class altaModificacionDeRol : Form
    {
        int idFuncionalidad;
        int idRol;
        public altaModificacionDeRol()
        {
            InitializeComponent();
        }

        private void altaModificacionDeRol_Load(object sender, EventArgs e)
        {
            cargarComboBoxFuncionalidades();
            if (textTipoForm.Text == "0")
            {
                botonAgregar.Enabled = false;
                botonQuitar.Enabled = false;
            }else{
                funcionesComunes.consultarFuncionalidadesDelRol(Convert.ToInt32(textId.Text), 
                    dataGridFuncionalidades);
                botonCrearRol.Visible = false;
                textRol.Enabled = false;
            }
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            funcionesComunes.habilitarAnterior();
        }

        private void cargarComboBoxFuncionalidades()
        {
            funcionesComunes.llenarCombobox(comboBoxFuncionalidades, "DETALLES", @"select f.ID, 
                f.DETALLES from aero.funcionalidades f order by f.DETALLES");           
        }

        private void botonCrearRol_Click(object sender, EventArgs e)
        {
            //Aca haria todo el procedure de creacion de Rol en la tabla roles, me devuelve el Id y lo guardo en textId
            //Si guarda bien hace lo siguiente:
            List<string> lista = new List<string>();
            lista.Add("@nombreRol");
            int id = SqlConnector.executeProcedureWithReturnValue("AERO.agregarRol", lista, textRol.Text);
            if (id != -1){
                MessageBox.Show("El rol fue creado exitosamente");
                botonCrearRol.Visible = false;
                botonAgregar.Enabled = true;
                botonQuitar.Enabled = true;
                idRol = id;
                textId.Text = Convert.ToString(idRol);
            }else{
                MessageBox.Show("No hace naranja");
            }
        }

        private void botonAgregar_Click(object sender, EventArgs e)
        {
            idFuncionalidad = Convert.ToInt32(comboBoxFuncionalidades.SelectedValue);
            idRol = Convert.ToInt32(textId.Text);
            if (!(existeFuncionalidad(idFuncionalidad))){
                  List<string> lista = new List<string>();
            lista.Add("@idRol");
            lista.Add("@idFunc");
            SqlConnector.executeProcedure("AERO.agregarFuncionalidad", lista, idRol,idFuncionalidad);
            funcionesComunes.consultarFuncionalidadesDelRol(Convert.ToInt32(textId.Text),
                    dataGridFuncionalidades);
            }else{
                MessageBox.Show("La funcionalidad seleccionada ya existe");
            }
        }

        private bool existeFuncionalidad(int idFuncionalidad)
        {
            foreach (DataGridViewRow row in dataGridFuncionalidades.Rows){
                if (Convert.ToInt32(row.Cells[0].Value) == idFuncionalidad)
                {
                    return true;
                }
            }
            return false;
        }

        private void botonQuitar_Click(object sender, EventArgs e)
        {
            idFuncionalidad = Convert.ToInt32(dataGridFuncionalidades.SelectedCells[0].Value);
            idRol = Convert.ToInt32(textId.Text);
            List<string> lista = new List<string>();
            lista.Add("@idRol");
            lista.Add("@idFunc");
            SqlConnector.executeProcedure("AERO.quitarFuncionalidad", lista, idRol, idFuncionalidad);
            funcionesComunes.consultarFuncionalidadesDelRol(Convert.ToInt32(textId.Text),
                    dataGridFuncionalidades);
        }
    }
}
