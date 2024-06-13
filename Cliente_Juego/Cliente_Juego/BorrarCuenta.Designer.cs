namespace Cliente_Juego
{
    partial class BorrarCuenta
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.usuarioBox = new System.Windows.Forms.TextBox();
            this.contraseñaBox = new System.Windows.Forms.TextBox();
            this.borrar = new System.Windows.Forms.Button();
            this.show = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(436, 171);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre de Usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(501, 281);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Contraseña";
            // 
            // usuarioBox
            // 
            this.usuarioBox.Location = new System.Drawing.Point(609, 171);
            this.usuarioBox.Margin = new System.Windows.Forms.Padding(4);
            this.usuarioBox.Name = "usuarioBox";
            this.usuarioBox.Size = new System.Drawing.Size(132, 22);
            this.usuarioBox.TabIndex = 2;
            // 
            // contraseñaBox
            // 
            this.contraseñaBox.Location = new System.Drawing.Point(609, 278);
            this.contraseñaBox.Margin = new System.Windows.Forms.Padding(4);
            this.contraseñaBox.Name = "contraseñaBox";
            this.contraseñaBox.Size = new System.Drawing.Size(132, 22);
            this.contraseñaBox.TabIndex = 3;
            this.contraseñaBox.UseSystemPasswordChar = true;
            this.contraseñaBox.TextChanged += new System.EventHandler(this.contraseñaBox_TextChanged);
            // 
            // borrar
            // 
            this.borrar.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.borrar.Location = new System.Drawing.Point(597, 364);
            this.borrar.Margin = new System.Windows.Forms.Padding(4);
            this.borrar.Name = "borrar";
            this.borrar.Size = new System.Drawing.Size(161, 32);
            this.borrar.TabIndex = 4;
            this.borrar.Text = "Borrar Cuenta";
            this.borrar.UseVisualStyleBackColor = true;
            this.borrar.Click += new System.EventHandler(this.borrar_Click);
            // 
            // show
            // 
            this.show.AutoSize = true;
            this.show.Location = new System.Drawing.Point(799, 282);
            this.show.Margin = new System.Windows.Forms.Padding(4);
            this.show.Name = "show";
            this.show.Size = new System.Drawing.Size(62, 20);
            this.show.TabIndex = 5;
            this.show.Text = "Show";
            this.show.UseVisualStyleBackColor = true;
            this.show.CheckedChanged += new System.EventHandler(this.show_CheckedChanged);
            // 
            // BorrarCuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.show);
            this.Controls.Add(this.borrar);
            this.Controls.Add(this.contraseñaBox);
            this.Controls.Add(this.usuarioBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BorrarCuenta";
            this.Text = "BorrarCuenta";
            this.Load += new System.EventHandler(this.BorrarCuenta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox usuarioBox;
        private System.Windows.Forms.TextBox contraseñaBox;
        private System.Windows.Forms.Button borrar;
        private System.Windows.Forms.CheckBox show;
    }
}