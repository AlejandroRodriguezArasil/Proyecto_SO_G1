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
            this.Registrarse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.id_p = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Registrarse
            // 
            this.Registrarse.Location = new System.Drawing.Point(62, 55);
            this.Registrarse.Margin = new System.Windows.Forms.Padding(4);
            this.Registrarse.Name = "Registrarse";
            this.Registrarse.Size = new System.Drawing.Size(219, 28);
            this.Registrarse.TabIndex = 5;
            this.Registrarse.Text = "Quién ha quedado segundo?";
            this.Registrarse.UseVisualStyleBackColor = true;
            this.Registrarse.Click += new System.EventHandler(this.Registrarse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(579, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Introduce ID de partida";
            // 
            // id_p
            // 
            this.id_p.Location = new System.Drawing.Point(348, 59);
            this.id_p.Name = "id_p";
            this.id_p.Size = new System.Drawing.Size(162, 22);
            this.id_p.TabIndex = 7;
            // 
            // Consultas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.id_p);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Registrarse);
            this.Name = "Consultas";
            this.Text = "Consultas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Registrarse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox id_p;
    }
}