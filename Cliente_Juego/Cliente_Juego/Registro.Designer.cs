namespace Cliente_Juego
{
    partial class Registro
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
            this.registrarse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.usuarioBox = new System.Windows.Forms.TextBox();
            this.contraseñaBox = new System.Windows.Forms.TextBox();
            this.show = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // registrarse
            // 
            this.registrarse.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registrarse.Location = new System.Drawing.Point(579, 337);
            this.registrarse.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.registrarse.Name = "registrarse";
            this.registrarse.Size = new System.Drawing.Size(133, 38);
            this.registrarse.TabIndex = 0;
            this.registrarse.Text = "Registrarse";
            this.registrarse.UseVisualStyleBackColor = true;
            this.registrarse.Click += new System.EventHandler(this.registrarse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(411, 183);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre de usuario";
            // 
            // usuarioBox
            // 
            this.usuarioBox.Location = new System.Drawing.Point(579, 180);
            this.usuarioBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.usuarioBox.Name = "usuarioBox";
            this.usuarioBox.Size = new System.Drawing.Size(132, 22);
            this.usuarioBox.TabIndex = 2;
            // 
            // contraseñaBox
            // 
            this.contraseñaBox.Location = new System.Drawing.Point(579, 235);
            this.contraseñaBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.contraseñaBox.Name = "contraseñaBox";
            this.contraseñaBox.Size = new System.Drawing.Size(132, 22);
            this.contraseñaBox.TabIndex = 3;
            this.contraseñaBox.UseSystemPasswordChar = true;
            this.contraseñaBox.TextChanged += new System.EventHandler(this.contraseñaBox_TextChanged);
            // 
            // show
            // 
            this.show.AutoSize = true;
            this.show.Location = new System.Drawing.Point(776, 238);
            this.show.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.show.Name = "show";
            this.show.Size = new System.Drawing.Size(62, 20);
            this.show.TabIndex = 4;
            this.show.Text = "Show";
            this.show.UseVisualStyleBackColor = true;
            this.show.CheckedChanged += new System.EventHandler(this.show_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(467, 234);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 22);
            this.label2.TabIndex = 5;
            this.label2.Text = "Contraseña";
            // 
            // Registro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.show);
            this.Controls.Add(this.contraseñaBox);
            this.Controls.Add(this.usuarioBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.registrarse);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Registro";
            this.Text = "Registro";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button registrarse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox usuarioBox;
        private System.Windows.Forms.TextBox contraseñaBox;
        private System.Windows.Forms.CheckBox show;
        private System.Windows.Forms.Label label2;
    }
}