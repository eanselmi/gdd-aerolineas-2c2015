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
            this.dataGridListadoAeronaves = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxListados = new System.Windows.Forms.ComboBox();
            this.botonVolver = new System.Windows.Forms.Button();
            this.botonConsultar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridListadoAeronaves)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridListadoAeronaves
            // 
            this.dataGridListadoAeronaves.AllowUserToAddRows = false;
            this.dataGridListadoAeronaves.AllowUserToDeleteRows = false;
            this.dataGridListadoAeronaves.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridListadoAeronaves.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridListadoAeronaves.Location = new System.Drawing.Point(70, 84);
            this.dataGridListadoAeronaves.MultiSelect = false;
            this.dataGridListadoAeronaves.Name = "dataGridListadoAeronaves";
            this.dataGridListadoAeronaves.ReadOnly = true;
            this.dataGridListadoAeronaves.RowHeadersVisible = false;
            this.dataGridListadoAeronaves.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridListadoAeronaves.Size = new System.Drawing.Size(596, 229);
            this.dataGridListadoAeronaves.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(102, 36);
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
            this.botonVolver.Location = new System.Drawing.Point(168, 332);
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
            this.botonConsultar.Location = new System.Drawing.Point(413, 332);
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
            this.ClientSize = new System.Drawing.Size(726, 395);
            this.ControlBox = false;
            this.Controls.Add(this.botonConsultar);
            this.Controls.Add(this.botonVolver);
            this.Controls.Add(this.comboBoxListados);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridListadoAeronaves);
            this.Name = "listadoEstadistico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listados Estadisticos";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridListadoAeronaves)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridListadoAeronaves;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxListados;
        private System.Windows.Forms.Button botonVolver;
        private System.Windows.Forms.Button botonConsultar;
    }
}