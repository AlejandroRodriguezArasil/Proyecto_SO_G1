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
            this.no_button = new System.Windows.Forms.Button();
            this.jugar_rda = new System.Windows.Forms.Button();
            this.jugar_ataque = new System.Windows.Forms.Button();
            this.mef_button = new System.Windows.Forms.Button();
            this.saltar_jugar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.atdir_button = new System.Windows.Forms.Button();
            this.jugar_turno = new System.Windows.Forms.Button();
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
            // no_button
            // 
            this.no_button.Location = new System.Drawing.Point(85, 815);
            this.no_button.Name = "no_button";
            this.no_button.Size = new System.Drawing.Size(75, 23);
            this.no_button.TabIndex = 9;
            this.no_button.Text = "jugar";
            this.no_button.UseVisualStyleBackColor = true;
            this.no_button.Click += new System.EventHandler(this.no_button_Click);
            // 
            // jugar_rda
            // 
            this.jugar_rda.Location = new System.Drawing.Point(246, 815);
            this.jugar_rda.Name = "jugar_rda";
            this.jugar_rda.Size = new System.Drawing.Size(75, 23);
            this.jugar_rda.TabIndex = 10;
            this.jugar_rda.Text = "jugar";
            this.jugar_rda.UseVisualStyleBackColor = true;
            this.jugar_rda.Click += new System.EventHandler(this.jugar_rda_Click);
            // 
            // jugar_ataque
            // 
            this.jugar_ataque.Location = new System.Drawing.Point(427, 815);
            this.jugar_ataque.Name = "jugar_ataque";
            this.jugar_ataque.Size = new System.Drawing.Size(75, 23);
            this.jugar_ataque.TabIndex = 11;
            this.jugar_ataque.Text = "jugar";
            this.jugar_ataque.UseVisualStyleBackColor = true;
            this.jugar_ataque.Click += new System.EventHandler(this.jugar_ataque_Click);
            // 
            // mef_button
            // 
            this.mef_button.Location = new System.Drawing.Point(607, 815);
            this.mef_button.Name = "mef_button";
            this.mef_button.Size = new System.Drawing.Size(75, 23);
            this.mef_button.TabIndex = 12;
            this.mef_button.Text = "jugar";
            this.mef_button.UseVisualStyleBackColor = true;
            this.mef_button.Click += new System.EventHandler(this.mef_button_Click);
            // 
            // saltar_jugar
            // 
            this.saltar_jugar.Location = new System.Drawing.Point(771, 815);
            this.saltar_jugar.Name = "saltar_jugar";
            this.saltar_jugar.Size = new System.Drawing.Size(75, 23);
            this.saltar_jugar.TabIndex = 13;
            this.saltar_jugar.Text = "jugar";
            this.saltar_jugar.UseVisualStyleBackColor = true;
            this.saltar_jugar.Click += new System.EventHandler(this.saltar_jugar_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(955, 815);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "jugar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1121, 815);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "jugar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // atdir_button
            // 
            this.atdir_button.Location = new System.Drawing.Point(1310, 815);
            this.atdir_button.Name = "atdir_button";
            this.atdir_button.Size = new System.Drawing.Size(75, 23);
            this.atdir_button.TabIndex = 16;
            this.atdir_button.Text = "jugar";
            this.atdir_button.UseVisualStyleBackColor = true;
            this.atdir_button.Click += new System.EventHandler(this.atdir_button_Click);
            // 
            // jugar_turno
            // 
            this.jugar_turno.Location = new System.Drawing.Point(1272, 110);
            this.jugar_turno.Name = "jugar_turno";
            this.jugar_turno.Size = new System.Drawing.Size(75, 23);
            this.jugar_turno.TabIndex = 17;
            this.jugar_turno.Text = "Jugar turno";
            this.jugar_turno.UseVisualStyleBackColor = true;
            this.jugar_turno.Click += new System.EventHandler(this.jugar_turno_Click);
            // 
            // Tablero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = global::Cliente_Juego.Properties.Resources.Tablero_con_cartas_v1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1444, 867);
            this.Controls.Add(this.jugar_turno);
            this.Controls.Add(this.atdir_button);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.saltar_jugar);
            this.Controls.Add(this.mef_button);
            this.Controls.Add(this.jugar_ataque);
            this.Controls.Add(this.jugar_rda);
            this.Controls.Add(this.no_button);
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
        private System.Windows.Forms.Button no_button;
        private System.Windows.Forms.Button jugar_rda;
        private System.Windows.Forms.Button jugar_ataque;
        private System.Windows.Forms.Button mef_button;
        private System.Windows.Forms.Button saltar_jugar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button atdir_button;
        private System.Windows.Forms.Button jugar_turno;
    }
}