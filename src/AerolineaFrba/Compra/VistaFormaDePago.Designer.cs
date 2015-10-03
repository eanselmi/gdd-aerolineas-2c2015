namespace AerolineaFrba.Compra
{
    partial class VistaFormaDePago
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
            this.botonEfectivo = new System.Windows.Forms.Button();
            this.buttonTarjeta = new System.Windows.Forms.Button();
            this.botonVolver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // botonEfectivo
            // 
            this.botonEfectivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.botonEfectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonEfectivo.Location = new System.Drawing.Point(84, 84);
            this.botonEfectivo.Name = "botonEfectivo";
            this.botonEfectivo.Size = new System.Drawing.Size(197, 66);
            this.botonEfectivo.TabIndex = 37;
            this.botonEfectivo.Text = "Efectivo";
            this.botonEfectivo.UseVisualStyleBackColor = true;
            // 
            // buttonTarjeta
            // 
            this.buttonTarjeta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTarjeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTarjeta.Location = new System.Drawing.Point(395, 84);
            this.buttonTarjeta.Name = "buttonTarjeta";
            this.buttonTarjeta.Size = new System.Drawing.Size(197, 66);
            this.buttonTarjeta.TabIndex = 38;
            this.buttonTarjeta.Text = "Tarjeta";
            this.buttonTarjeta.UseVisualStyleBackColor = true;
            // 
            // botonVolver
            // 
            this.botonVolver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.botonVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonVolver.Location = new System.Drawing.Point(279, 173);
            this.botonVolver.Name = "botonVolver";
            this.botonVolver.Size = new System.Drawing.Size(117, 46);
            this.botonVolver.TabIndex = 60;
            this.botonVolver.Text = "Volver";
            this.botonVolver.UseVisualStyleBackColor = true;
            // 
            // VistaFormaDePago
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(658, 231);
            this.ControlBox = false;
            this.Controls.Add(this.botonVolver);
            this.Controls.Add(this.buttonTarjeta);
            this.Controls.Add(this.botonEfectivo);
            this.Name = "VistaFormaDePago";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccione forma de pago";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button botonEfectivo;
        private System.Windows.Forms.Button buttonTarjeta;
        private System.Windows.Forms.Button botonVolver;
    }
}