namespace Cliente_Juego
{
    partial class IniciarSesion
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
            this.show = new System.Windows.Forms.CheckBox();
            this.iniciosesion = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.usuarioBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.contraseñaBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // show
            // 
            this.show.AutoSize = true;
            this.show.Location = new System.Drawing.Point(755, 234);
            this.show.Margin = new System.Windows.Forms.Padding(4);
            this.show.Name = "show";
            this.show.Size = new System.Drawing.Size(62, 20);
            this.show.TabIndex = 0;
            this.show.Text = "Show";
            this.show.UseVisualStyleBackColor = true;
            this.show.CheckedChanged += new System.EventHandler(this.show_CheckedChanged);
            // 
            // iniciosesion
            // 
            this.iniciosesion.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iniciosesion.Location = new System.Drawing.Point(592, 298);
            this.iniciosesion.Margin = new System.Windows.Forms.Padding(4);
            this.iniciosesion.Name = "iniciosesion";
            this.iniciosesion.Size = new System.Drawing.Size(133, 32);
            this.iniciosesion.TabIndex = 1;
            this.iniciosesion.Text = "Iniciar Sesion";
            this.iniciosesion.UseVisualStyleBackColor = true;
            this.iniciosesion.Click += new System.EventHandler(this.iniciosesion_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(419, 171);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre de Usuario";
            // 
            // usuarioBox
            // 
            this.usuarioBox.Location = new System.Drawing.Point(592, 170);
            this.usuarioBox.Margin = new System.Windows.Forms.Padding(4);
            this.usuarioBox.Name = "usuarioBox";
            this.usuarioBox.Size = new System.Drawing.Size(132, 22);
            this.usuarioBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(484, 233);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "Contraseña";
            // 
            // contraseñaBox
            // 
            this.contraseñaBox.Location = new System.Drawing.Point(592, 231);
            this.contraseñaBox.Margin = new System.Windows.Forms.Padding(4);
            this.contraseñaBox.Name = "contraseñaBox";
            this.contraseñaBox.Size = new System.Drawing.Size(132, 22);
            this.contraseñaBox.TabIndex = 5;
            this.contraseñaBox.UseSystemPasswordChar = true;
            // 
            // IniciarSesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.contraseñaBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.usuarioBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.iniciosesion);
            this.Controls.Add(this.show);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "IniciarSesion";
            this.Text = "IniciarSesion";
            this.Load += new System.EventHandler(this.IniciarSesion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox show;
        private System.Windows.Forms.Button iniciosesion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox usuarioBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox contraseñaBox;
    }
}