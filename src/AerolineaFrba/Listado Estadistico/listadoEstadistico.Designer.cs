namespace AerolineaFrba.Listado_Estadistico
{
    partial class listadoEstadistico
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridListadoEstadistico = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxListados = new System.Windows.Forms.ComboBox();
            this.botonVolver = new System.Windows.Forms.Button();
            this.botonConsultar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridListadoEstadistico)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridListadoEstadistico
            // 
            this.dataGridListadoEstadistico.AllowUserToAddRows = false;
            this.dataGridListadoEstadistico.AllowUserToDeleteRows = false;
            this.dataGridListadoEstadistico.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridListadoEstadistico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridListadoEstadistico.Location = new System.Drawing.Point(106, 84);
            this.dataGridListadoEstadistico.MultiSelect = false;
            this.dataGridListadoEstadistico.Name = "dataGridListadoEstadistico";
            this.dataGridListadoEstadistico.ReadOnly = true;
            this.dataGridListadoEstadistico.RowHeadersVisible = false;
            this.dataGridListadoEstadistico.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridListadoEstadistico.Size = new System.Drawing.Size(560, 174);
            this.dataGridListadoEstadistico.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(102, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 28;
            this.label1.Text = "Listado";
            // 
            // comboBoxListados
            // 
            this.comboBoxListados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxListados.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.comboBoxListados.FormattingEnabled = true;
            this.comboBoxListados.Items.AddRange(new object[] {
            "Top 5 Destinos con más pasajes comprados",
            "Top 5 Destinos con aeronaves más vacias",
            "Top 5 Clientes con más puntos acumulados a la fecha",
            "Top 5 Destinos con más pasajes cancelados",
            "Top 5 Aeronaves con mayor cantidad de dias fuera de servicio"});
            this.comboBoxListados.Location = new System.Drawing.Point(197, 28);
            this.comboBoxListados.Name = "comboBoxListados";
            this.comboBoxListados.Size = new System.Drawing.Size(469, 28);
            this.comboBoxListados.TabIndex = 29;
            // 
            // botonVolver
            // 
            this.botonVolver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.botonVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonVolver.Location = new System.Drawing.Point(188, 268);
            this.botonVolver.Name = "botonVolver";
            this.botonVolver.Size = new System.Drawing.Size(105, 42);
            this.botonVolver.TabIndex = 48;
            this.botonVolver.Text = "Volver";
            this.botonVolver.UseVisualStyleBackColor = true;
            this.botonVolver.Click += new System.EventHandler(this.botonVolver_Click);
            // 
            // botonConsultar
            // 
            this.botonConsultar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.botonConsultar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonConsultar.Location = new System.Drawing.Point(433, 268);
            this.botonConsultar.Name = "botonConsultar";
            this.botonConsultar.Size = new System.Drawing.Size(105, 42);
            this.botonConsultar.TabIndex = 49;
            this.botonConsultar.Text = "Consultar";
            this.botonConsultar.UseVisualStyleBackColor = true;
            this.botonConsultar.Click += new System.EventHandler(this.botonConsultar_Click);
            // 
            // listadoEstadistico
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(726, 325);
            this.ControlBox = false;
            this.Controls.Add(this.botonConsultar);
            this.Controls.Add(this.botonVolver);
            this.Controls.Add(this.comboBoxListados);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridListadoEstadistico);
            this.Name = "listadoEstadistico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listados Estadisticos";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridListadoEstadistico)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridListadoEstadistico;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxListados;
        private System.Windows.Forms.Button botonVolver;
        private System.Windows.Forms.Button botonConsultar;
    }
}