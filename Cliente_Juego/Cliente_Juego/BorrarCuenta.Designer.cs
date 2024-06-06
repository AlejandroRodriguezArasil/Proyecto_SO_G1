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
            this.Show_Hide = new System.Windows.Forms.CheckBox();
            this.contraseñaBox = new System.Windows.Forms.TextBox();
            this.usuarioBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BorrarBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Show_Hide
            // 
            this.Show_Hide.AutoSize = true;
            this.Show_Hide.Location = new System.Drawing.Point(670, 230);
            this.Show_Hide.Name = "Show_Hide";
            this.Show_Hide.Size = new System.Drawing.Size(62, 20);
            this.Show_Hide.TabIndex = 10;
            this.Show_Hide.Text = "Show";
            this.Show_Hide.UseVisualStyleBackColor = true;
            this.Show_Hide.CheckedChanged += new System.EventHandler(this.Show_Hide_CheckedChanged);
            // 
            // contraseñaBox
            // 
            this.contraseñaBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contraseñaBox.Location = new System.Drawing.Point(485, 228);
            this.contraseñaBox.Margin = new System.Windows.Forms.Padding(4);
            this.contraseñaBox.MaxLength = 8;
            this.contraseñaBox.Name = "contraseñaBox";
            this.contraseñaBox.Size = new System.Drawing.Size(132, 22);
            this.contraseñaBox.TabIndex = 9;
            this.contraseñaBox.UseSystemPasswordChar = true;
            // 
            // usuarioBox
            // 
            this.usuarioBox.Location = new System.Drawing.Point(485, 167);
            this.usuarioBox.Margin = new System.Windows.Forms.Padding(4);
            this.usuarioBox.MaxLength = 16;
            this.usuarioBox.Name = "usuarioBox";
            this.usuarioBox.Size = new System.Drawing.Size(132, 22);
            this.usuarioBox.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(182, 236);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Contraseña";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(164, 167);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Nombre de Usuario";
            // 
            // BorrarBtn
            // 
            this.BorrarBtn.Location = new System.Drawing.Point(485, 314);
            this.BorrarBtn.Name = "BorrarBtn";
            this.BorrarBtn.Size = new System.Drawing.Size(132, 28);
            this.BorrarBtn.TabIndex = 11;
            this.BorrarBtn.Text = "Borrar Cuenta";
            this.BorrarBtn.UseVisualStyleBackColor = true;
            this.BorrarBtn.Click += new System.EventHandler(this.BorrarBtn_Click);
            // 
            // BorrarCuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 594);
            this.Controls.Add(this.BorrarBtn);
            this.Controls.Add(this.Show_Hide);
            this.Controls.Add(this.contraseñaBox);
            this.Controls.Add(this.usuarioBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "BorrarCuenta";
            this.Text = "BorrarCuenta";
            this.Load += new System.EventHandler(this.BorrarCuenta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox Show_Hide;
        private System.Windows.Forms.TextBox contraseñaBox;
        private System.Windows.Forms.TextBox usuarioBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BorrarBtn;
    }
}