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
            this.Show_Hide = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(201, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre de Usuario";
            // 
            // usuarioBox
            // 
            this.usuarioBox.Location = new System.Drawing.Point(172, 86);
            this.usuarioBox.Margin = new System.Windows.Forms.Padding(4);
            this.usuarioBox.MaxLength = 16;
            this.usuarioBox.Name = "usuarioBox";
            this.usuarioBox.Size = new System.Drawing.Size(185, 22);
            this.usuarioBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(557, 48);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Contraseña";
            // 
            // contraseñaBox
            // 
            this.contraseñaBox.Location = new System.Drawing.Point(505, 86);
            this.contraseñaBox.Margin = new System.Windows.Forms.Padding(4);
            this.contraseñaBox.MaxLength = 8;
            this.contraseñaBox.Name = "contraseñaBox";
            this.contraseñaBox.Size = new System.Drawing.Size(181, 22);
            this.contraseñaBox.TabIndex = 3;
            this.contraseñaBox.UseSystemPasswordChar = true;
            // 
            // InicioSesion
            // 
            this.InicioSesion.Location = new System.Drawing.Point(356, 149);
            this.InicioSesion.Margin = new System.Windows.Forms.Padding(4);
            this.InicioSesion.Name = "InicioSesion";
            this.InicioSesion.Size = new System.Drawing.Size(149, 28);
            this.InicioSesion.TabIndex = 4;
            this.InicioSesion.Text = "Iniciar Sesión";
            this.InicioSesion.UseVisualStyleBackColor = true;
            this.InicioSesion.Click += new System.EventHandler(this.InicioSesion_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(205, 268);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(197, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "No estas registrado? Regístrate";
            // 
            // Registro
            // 
            this.Registro.Location = new System.Drawing.Point(505, 258);
            this.Registro.Margin = new System.Windows.Forms.Padding(4);
            this.Registro.Name = "Registro";
            this.Registro.Size = new System.Drawing.Size(165, 34);
            this.Registro.TabIndex = 6;
            this.Registro.Text = "Registrarse";
            this.Registro.UseVisualStyleBackColor = true;
            this.Registro.Click += new System.EventHandler(this.Registro_Click);
            // 
            // Show_Hide
            // 
            this.Show_Hide.AutoSize = true;
            this.Show_Hide.Location = new System.Drawing.Point(718, 88);
            this.Show_Hide.Name = "Show_Hide";
            this.Show_Hide.Size = new System.Drawing.Size(62, 20);
            this.Show_Hide.TabIndex = 7;
            this.Show_Hide.Text = "Show";
            this.Show_Hide.UseVisualStyleBackColor = true;
            this.Show_Hide.CheckedChanged += new System.EventHandler(this.Show_Hide_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(505, 350);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(165, 34);
            this.button1.TabIndex = 9;
            this.button1.Text = "Borrar cuenta";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(205, 360);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(167, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Quieres eliminar tu cuenta?";
            // 
            // Identificación
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Show_Hide);
            this.Controls.Add(this.Registro);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.InicioSesion);
            this.Controls.Add(this.contraseñaBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.usuarioBox);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private System.Windows.Forms.CheckBox Show_Hide;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
    }
}

