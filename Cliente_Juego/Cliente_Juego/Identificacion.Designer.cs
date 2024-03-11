namespace Cliente_Juego
{
    partial class Identificación
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.usuarioBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.contraseñaBox = new System.Windows.Forms.TextBox();
            this.InicioSesion = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Registro = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(151, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre de Usuario";
            // 
            // usuarioBox
            // 
            this.usuarioBox.Location = new System.Drawing.Point(129, 70);
            this.usuarioBox.Name = "usuarioBox";
            this.usuarioBox.Size = new System.Drawing.Size(140, 20);
            this.usuarioBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(418, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Contraseña";
            // 
            // contraseñaBox
            // 
            this.contraseñaBox.Location = new System.Drawing.Point(379, 70);
            this.contraseñaBox.Name = "contraseñaBox";
            this.contraseñaBox.Size = new System.Drawing.Size(137, 20);
            this.contraseñaBox.TabIndex = 3;
            // 
            // InicioSesion
            // 
            this.InicioSesion.Location = new System.Drawing.Point(267, 121);
            this.InicioSesion.Name = "InicioSesion";
            this.InicioSesion.Size = new System.Drawing.Size(112, 23);
            this.InicioSesion.TabIndex = 4;
            this.InicioSesion.Text = "Iniciar Sesión";
            this.InicioSesion.UseVisualStyleBackColor = true;
            this.InicioSesion.Click += new System.EventHandler(this.InicioSesion_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(154, 218);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "No estas registrado? Regístrate";
            // 
            // Registro
            // 
            this.Registro.Location = new System.Drawing.Point(379, 210);
            this.Registro.Name = "Registro";
            this.Registro.Size = new System.Drawing.Size(124, 28);
            this.Registro.TabIndex = 6;
            this.Registro.Text = "Registrarse";
            this.Registro.UseVisualStyleBackColor = true;
            this.Registro.Click += new System.EventHandler(this.Registro_Click);
            // 
            // Identificación
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Registro);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.InicioSesion);
            this.Controls.Add(this.contraseñaBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.usuarioBox);
            this.Controls.Add(this.label1);
            this.Name = "Identificación";
            this.Text = "Identificación";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox usuarioBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox contraseñaBox;
        private System.Windows.Forms.Button InicioSesion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Registro;
    }
}

