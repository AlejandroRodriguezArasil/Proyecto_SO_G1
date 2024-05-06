namespace Cliente_Juego
{
    partial class Tablero
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
            this.cantidad_no = new System.Windows.Forms.TextBox();
            this.cantidad_rda = new System.Windows.Forms.TextBox();
            this.cantidad_ataque = new System.Windows.Forms.TextBox();
            this.cantidad_mef = new System.Windows.Forms.TextBox();
            this.cantidad_saltar = new System.Windows.Forms.TextBox();
            this.cantidad_mezclar = new System.Windows.Forms.TextBox();
            this.cantidad_cel = new System.Windows.Forms.TextBox();
            this.cantidad_ataquedir = new System.Windows.Forms.TextBox();
            this.notificaciones = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cantidad_no
            // 
            this.cantidad_no.Location = new System.Drawing.Point(73, 642);
            this.cantidad_no.Name = "cantidad_no";
            this.cantidad_no.Size = new System.Drawing.Size(100, 22);
            this.cantidad_no.TabIndex = 0;
            this.cantidad_no.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // cantidad_rda
            // 
            this.cantidad_rda.Location = new System.Drawing.Point(246, 642);
            this.cantidad_rda.Name = "cantidad_rda";
            this.cantidad_rda.Size = new System.Drawing.Size(100, 22);
            this.cantidad_rda.TabIndex = 1;
            // 
            // cantidad_ataque
            // 
            this.cantidad_ataque.Location = new System.Drawing.Point(416, 642);
            this.cantidad_ataque.Name = "cantidad_ataque";
            this.cantidad_ataque.Size = new System.Drawing.Size(100, 22);
            this.cantidad_ataque.TabIndex = 2;
            // 
            // cantidad_mef
            // 
            this.cantidad_mef.Location = new System.Drawing.Point(582, 642);
            this.cantidad_mef.Name = "cantidad_mef";
            this.cantidad_mef.Size = new System.Drawing.Size(100, 22);
            this.cantidad_mef.TabIndex = 3;
            // 
            // cantidad_saltar
            // 
            this.cantidad_saltar.Location = new System.Drawing.Point(771, 642);
            this.cantidad_saltar.Name = "cantidad_saltar";
            this.cantidad_saltar.Size = new System.Drawing.Size(100, 22);
            this.cantidad_saltar.TabIndex = 4;
            // 
            // cantidad_mezclar
            // 
            this.cantidad_mezclar.Location = new System.Drawing.Point(930, 633);
            this.cantidad_mezclar.Name = "cantidad_mezclar";
            this.cantidad_mezclar.Size = new System.Drawing.Size(100, 22);
            this.cantidad_mezclar.TabIndex = 5;
            // 
            // cantidad_cel
            // 
            this.cantidad_cel.Location = new System.Drawing.Point(1111, 633);
            this.cantidad_cel.Name = "cantidad_cel";
            this.cantidad_cel.Size = new System.Drawing.Size(100, 22);
            this.cantidad_cel.TabIndex = 6;
            // 
            // cantidad_ataquedir
            // 
            this.cantidad_ataquedir.Location = new System.Drawing.Point(1285, 633);
            this.cantidad_ataquedir.Name = "cantidad_ataquedir";
            this.cantidad_ataquedir.Size = new System.Drawing.Size(100, 22);
            this.cantidad_ataquedir.TabIndex = 7;
            // 
            // notificaciones
            // 
            this.notificaciones.Location = new System.Drawing.Point(1194, 41);
            this.notificaciones.Name = "notificaciones";
            this.notificaciones.Size = new System.Drawing.Size(100, 22);
            this.notificaciones.TabIndex = 8;
            // 
            // Tablero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = global::Cliente_Juego.Properties.Resources.Tablero_con_cartas_v1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1444, 867);
            this.Controls.Add(this.notificaciones);
            this.Controls.Add(this.cantidad_ataquedir);
            this.Controls.Add(this.cantidad_cel);
            this.Controls.Add(this.cantidad_mezclar);
            this.Controls.Add(this.cantidad_saltar);
            this.Controls.Add(this.cantidad_mef);
            this.Controls.Add(this.cantidad_ataque);
            this.Controls.Add(this.cantidad_rda);
            this.Controls.Add(this.cantidad_no);
            this.Name = "Tablero";
            this.Text = " ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox cantidad_no;
        private System.Windows.Forms.TextBox cantidad_rda;
        private System.Windows.Forms.TextBox cantidad_ataque;
        private System.Windows.Forms.TextBox cantidad_mef;
        private System.Windows.Forms.TextBox cantidad_saltar;
        private System.Windows.Forms.TextBox cantidad_mezclar;
        private System.Windows.Forms.TextBox cantidad_cel;
        private System.Windows.Forms.TextBox cantidad_ataquedir;
        private System.Windows.Forms.TextBox notificaciones;
    }
}