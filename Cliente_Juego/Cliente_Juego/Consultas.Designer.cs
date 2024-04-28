namespace Cliente_Juego
{
    partial class Consultas
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
            this.nueva_partida_button = new System.Windows.Forms.Button();
            this.activas_button = new System.Windows.Forms.Button();
            this.busqueda_button = new System.Windows.Forms.Button();
            this.acabadas_button = new System.Windows.Forms.Button();
            this.conectados_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nueva_partida_button
            // 
            this.nueva_partida_button.Location = new System.Drawing.Point(164, 42);
            this.nueva_partida_button.Name = "nueva_partida_button";
            this.nueva_partida_button.Size = new System.Drawing.Size(424, 59);
            this.nueva_partida_button.TabIndex = 0;
            this.nueva_partida_button.Text = "Nueva partida";
            this.nueva_partida_button.UseVisualStyleBackColor = true;
            this.nueva_partida_button.Click += new System.EventHandler(this.nueva_partida_button_Click);
            // 
            // activas_button
            // 
            this.activas_button.Location = new System.Drawing.Point(63, 145);
            this.activas_button.Name = "activas_button";
            this.activas_button.Size = new System.Drawing.Size(235, 57);
            this.activas_button.TabIndex = 1;
            this.activas_button.Text = "Activas";
            this.activas_button.UseVisualStyleBackColor = true;
            this.activas_button.Click += new System.EventHandler(this.activas_button_Click);
            // 
            // busqueda_button
            // 
            this.busqueda_button.Location = new System.Drawing.Point(463, 145);
            this.busqueda_button.Name = "busqueda_button";
            this.busqueda_button.Size = new System.Drawing.Size(261, 57);
            this.busqueda_button.TabIndex = 2;
            this.busqueda_button.Text = "Busqueda";
            this.busqueda_button.UseVisualStyleBackColor = true;
            this.busqueda_button.Click += new System.EventHandler(this.busqueda_button_Click);
            // 
            // acabadas_button
            // 
            this.acabadas_button.Location = new System.Drawing.Point(63, 260);
            this.acabadas_button.Name = "acabadas_button";
            this.acabadas_button.Size = new System.Drawing.Size(235, 47);
            this.acabadas_button.TabIndex = 3;
            this.acabadas_button.Text = "Acabadas";
            this.acabadas_button.UseVisualStyleBackColor = true;
            this.acabadas_button.Click += new System.EventHandler(this.acabadas_button_Click);
            // 
            // conectados_button
            // 
            this.conectados_button.Location = new System.Drawing.Point(463, 260);
            this.conectados_button.Name = "conectados_button";
            this.conectados_button.Size = new System.Drawing.Size(261, 47);
            this.conectados_button.TabIndex = 4;
            this.conectados_button.Text = "Conectados";
            this.conectados_button.UseVisualStyleBackColor = true;
            this.conectados_button.Click += new System.EventHandler(this.conectados_button_Click);
            // 
            // Consultas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.conectados_button);
            this.Controls.Add(this.acabadas_button);
            this.Controls.Add(this.busqueda_button);
            this.Controls.Add(this.activas_button);
            this.Controls.Add(this.nueva_partida_button);
            this.Name = "Consultas";
            this.Text = "Consultas";
            this.Load += new System.EventHandler(this.Consultas_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button nueva_partida_button;
        private System.Windows.Forms.Button activas_button;
        private System.Windows.Forms.Button busqueda_button;
        private System.Windows.Forms.Button acabadas_button;
        private System.Windows.Forms.Button conectados_button;
    }
}