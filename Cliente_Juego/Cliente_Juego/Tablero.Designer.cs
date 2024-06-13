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
            this.notificaciones = new System.Windows.Forms.TextBox();
            this.jugar_turno = new System.Windows.Forms.Button();
            this.no_button = new System.Windows.Forms.Button();
            this.cantidad_no = new System.Windows.Forms.TextBox();
            this.cantidad_rda = new System.Windows.Forms.TextBox();
            this.jugar_rda = new System.Windows.Forms.Button();
            this.cantidad_ataque = new System.Windows.Forms.TextBox();
            this.jugar_ataque = new System.Windows.Forms.Button();
            this.cantidad_mef = new System.Windows.Forms.TextBox();
            this.cantidad_saltar = new System.Windows.Forms.TextBox();
            this.cantidad_cel = new System.Windows.Forms.TextBox();
            this.cantidad_mezclar = new System.Windows.Forms.TextBox();
            this.cantidad_ataquedir = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.mef_button = new System.Windows.Forms.Button();
            this.saltar_jugar = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.atdir_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // notificaciones
            // 
            this.notificaciones.Location = new System.Drawing.Point(1613, 57);
            this.notificaciones.Margin = new System.Windows.Forms.Padding(4);
            this.notificaciones.Name = "notificaciones";
            this.notificaciones.Size = new System.Drawing.Size(132, 22);
            this.notificaciones.TabIndex = 0;
            // 
            // jugar_turno
            // 
            this.jugar_turno.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jugar_turno.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.jugar_turno.Location = new System.Drawing.Point(1709, 111);
            this.jugar_turno.Margin = new System.Windows.Forms.Padding(4);
            this.jugar_turno.Name = "jugar_turno";
            this.jugar_turno.Size = new System.Drawing.Size(136, 30);
            this.jugar_turno.TabIndex = 1;
            this.jugar_turno.Text = "Jugar turno";
            this.jugar_turno.UseVisualStyleBackColor = true;
            this.jugar_turno.Click += new System.EventHandler(this.jugar_turno_Click_1);
            // 
            // no_button
            // 
            this.no_button.Location = new System.Drawing.Point(112, 1010);
            this.no_button.Margin = new System.Windows.Forms.Padding(4);
            this.no_button.Name = "no_button";
            this.no_button.Size = new System.Drawing.Size(100, 28);
            this.no_button.TabIndex = 2;
            this.no_button.Text = "Jugar";
            this.no_button.UseVisualStyleBackColor = true;
            this.no_button.Click += new System.EventHandler(this.no_button_Click_1);
            // 
            // cantidad_no
            // 
            this.cantidad_no.Location = new System.Drawing.Point(97, 804);
            this.cantidad_no.Margin = new System.Windows.Forms.Padding(4);
            this.cantidad_no.Name = "cantidad_no";
            this.cantidad_no.Size = new System.Drawing.Size(132, 22);
            this.cantidad_no.TabIndex = 3;
            // 
            // cantidad_rda
            // 
            this.cantidad_rda.Location = new System.Drawing.Point(321, 804);
            this.cantidad_rda.Margin = new System.Windows.Forms.Padding(4);
            this.cantidad_rda.Name = "cantidad_rda";
            this.cantidad_rda.Size = new System.Drawing.Size(132, 22);
            this.cantidad_rda.TabIndex = 4;
            // 
            // jugar_rda
            // 
            this.jugar_rda.Location = new System.Drawing.Point(333, 1010);
            this.jugar_rda.Margin = new System.Windows.Forms.Padding(4);
            this.jugar_rda.Name = "jugar_rda";
            this.jugar_rda.Size = new System.Drawing.Size(100, 28);
            this.jugar_rda.TabIndex = 5;
            this.jugar_rda.Text = "Jugar";
            this.jugar_rda.UseVisualStyleBackColor = true;
            this.jugar_rda.Click += new System.EventHandler(this.jugar_rda_Click_1);
            // 
            // cantidad_ataque
            // 
            this.cantidad_ataque.Location = new System.Drawing.Point(557, 804);
            this.cantidad_ataque.Margin = new System.Windows.Forms.Padding(4);
            this.cantidad_ataque.Name = "cantidad_ataque";
            this.cantidad_ataque.Size = new System.Drawing.Size(132, 22);
            this.cantidad_ataque.TabIndex = 6;
            // 
            // jugar_ataque
            // 
            this.jugar_ataque.Location = new System.Drawing.Point(569, 1010);
            this.jugar_ataque.Margin = new System.Windows.Forms.Padding(4);
            this.jugar_ataque.Name = "jugar_ataque";
            this.jugar_ataque.Size = new System.Drawing.Size(100, 28);
            this.jugar_ataque.TabIndex = 7;
            this.jugar_ataque.Text = "Jugar";
            this.jugar_ataque.UseVisualStyleBackColor = true;
            this.jugar_ataque.Click += new System.EventHandler(this.jugar_ataque_Click_1);
            // 
            // cantidad_mef
            // 
            this.cantidad_mef.Location = new System.Drawing.Point(783, 804);
            this.cantidad_mef.Margin = new System.Windows.Forms.Padding(4);
            this.cantidad_mef.Name = "cantidad_mef";
            this.cantidad_mef.Size = new System.Drawing.Size(132, 22);
            this.cantidad_mef.TabIndex = 8;
            // 
            // cantidad_saltar
            // 
            this.cantidad_saltar.Location = new System.Drawing.Point(1013, 804);
            this.cantidad_saltar.Margin = new System.Windows.Forms.Padding(4);
            this.cantidad_saltar.Name = "cantidad_saltar";
            this.cantidad_saltar.Size = new System.Drawing.Size(132, 22);
            this.cantidad_saltar.TabIndex = 9;
            // 
            // cantidad_cel
            // 
            this.cantidad_cel.Location = new System.Drawing.Point(1475, 804);
            this.cantidad_cel.Margin = new System.Windows.Forms.Padding(4);
            this.cantidad_cel.Name = "cantidad_cel";
            this.cantidad_cel.Size = new System.Drawing.Size(132, 22);
            this.cantidad_cel.TabIndex = 10;
            // 
            // cantidad_mezclar
            // 
            this.cantidad_mezclar.Location = new System.Drawing.Point(1239, 804);
            this.cantidad_mezclar.Margin = new System.Windows.Forms.Padding(4);
            this.cantidad_mezclar.Name = "cantidad_mezclar";
            this.cantidad_mezclar.Size = new System.Drawing.Size(132, 22);
            this.cantidad_mezclar.TabIndex = 10;
            // 
            // cantidad_ataquedir
            // 
            this.cantidad_ataquedir.Location = new System.Drawing.Point(1722, 804);
            this.cantidad_ataquedir.Margin = new System.Windows.Forms.Padding(4);
            this.cantidad_ataquedir.Name = "cantidad_ataquedir";
            this.cantidad_ataquedir.Size = new System.Drawing.Size(132, 22);
            this.cantidad_ataquedir.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1251, 1010);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 12;
            this.button1.Text = "Jugar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // mef_button
            // 
            this.mef_button.Location = new System.Drawing.Point(783, 1010);
            this.mef_button.Margin = new System.Windows.Forms.Padding(4);
            this.mef_button.Name = "mef_button";
            this.mef_button.Size = new System.Drawing.Size(100, 28);
            this.mef_button.TabIndex = 12;
            this.mef_button.Text = "Jugar";
            this.mef_button.UseVisualStyleBackColor = true;
            this.mef_button.Click += new System.EventHandler(this.mef_button_Click_1);
            // 
            // saltar_jugar
            // 
            this.saltar_jugar.Location = new System.Drawing.Point(1032, 1010);
            this.saltar_jugar.Margin = new System.Windows.Forms.Padding(4);
            this.saltar_jugar.Name = "saltar_jugar";
            this.saltar_jugar.Size = new System.Drawing.Size(100, 28);
            this.saltar_jugar.TabIndex = 13;
            this.saltar_jugar.Text = "Jugar";
            this.saltar_jugar.UseVisualStyleBackColor = true;
            this.saltar_jugar.Click += new System.EventHandler(this.saltar_jugar_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1487, 1010);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 28);
            this.button2.TabIndex = 14;
            this.button2.Text = "Jugar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // atdir_button
            // 
            this.atdir_button.Location = new System.Drawing.Point(1732, 1010);
            this.atdir_button.Margin = new System.Windows.Forms.Padding(4);
            this.atdir_button.Name = "atdir_button";
            this.atdir_button.Size = new System.Drawing.Size(100, 28);
            this.atdir_button.TabIndex = 15;
            this.atdir_button.Text = "Jugar";
            this.atdir_button.UseVisualStyleBackColor = true;
            this.atdir_button.Click += new System.EventHandler(this.atdir_button_Click_1);
            // 
            // Tablero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Cliente_Juego.Properties.Resources.Tablero_con_cartas_v1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.atdir_button);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.saltar_jugar);
            this.Controls.Add(this.mef_button);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cantidad_ataquedir);
            this.Controls.Add(this.cantidad_mezclar);
            this.Controls.Add(this.cantidad_cel);
            this.Controls.Add(this.cantidad_saltar);
            this.Controls.Add(this.cantidad_mef);
            this.Controls.Add(this.jugar_ataque);
            this.Controls.Add(this.cantidad_ataque);
            this.Controls.Add(this.jugar_rda);
            this.Controls.Add(this.cantidad_rda);
            this.Controls.Add(this.cantidad_no);
            this.Controls.Add(this.no_button);
            this.Controls.Add(this.jugar_turno);
            this.Controls.Add(this.notificaciones);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Tablero";
            this.Text = "Tablero";
            this.Load += new System.EventHandler(this.Tablero_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox notificaciones;
        private System.Windows.Forms.Button jugar_turno;
        private System.Windows.Forms.Button no_button;
        private System.Windows.Forms.TextBox cantidad_no;
        private System.Windows.Forms.TextBox cantidad_rda;
        private System.Windows.Forms.Button jugar_rda;
        private System.Windows.Forms.TextBox cantidad_ataque;
        private System.Windows.Forms.Button jugar_ataque;
        private System.Windows.Forms.TextBox cantidad_mef;
        private System.Windows.Forms.TextBox cantidad_saltar;
        private System.Windows.Forms.TextBox cantidad_cel;
        private System.Windows.Forms.TextBox cantidad_mezclar;
        private System.Windows.Forms.TextBox cantidad_ataquedir;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button mef_button;
        private System.Windows.Forms.Button saltar_jugar;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button atdir_button;
    }
}