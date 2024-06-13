namespace Cliente_Juego
{
    partial class Principal
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.conectarseAlServidorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.identificaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iniciarSesiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borrarCuentaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invitarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.desconectarseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.Conectados = new System.Windows.Forms.Button();
            this.Activas = new System.Windows.Forms.Button();
            this.Acabadas = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.conectarseAlServidorToolStripMenuItem,
            this.identificaciónToolStripMenuItem,
            this.invitarToolStripMenuItem,
            this.desconectarseToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1067, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // conectarseAlServidorToolStripMenuItem
            // 
            this.conectarseAlServidorToolStripMenuItem.Name = "conectarseAlServidorToolStripMenuItem";
            this.conectarseAlServidorToolStripMenuItem.Size = new System.Drawing.Size(169, 24);
            this.conectarseAlServidorToolStripMenuItem.Text = "Conectarse al servidor";
            this.conectarseAlServidorToolStripMenuItem.Click += new System.EventHandler(this.conectarseAlServidorToolStripMenuItem_Click_1);
            // 
            // identificaciónToolStripMenuItem
            // 
            this.identificaciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iniciarSesiónToolStripMenuItem,
            this.registrarseToolStripMenuItem,
            this.cerrarSesiónToolStripMenuItem,
            this.borrarCuentaToolStripMenuItem});
            this.identificaciónToolStripMenuItem.Name = "identificaciónToolStripMenuItem";
            this.identificaciónToolStripMenuItem.Size = new System.Drawing.Size(113, 24);
            this.identificaciónToolStripMenuItem.Text = "Identificación";
            // 
            // iniciarSesiónToolStripMenuItem
            // 
            this.iniciarSesiónToolStripMenuItem.Name = "iniciarSesiónToolStripMenuItem";
            this.iniciarSesiónToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.iniciarSesiónToolStripMenuItem.Text = "Iniciar Sesión";
            this.iniciarSesiónToolStripMenuItem.Click += new System.EventHandler(this.iniciarSesiónToolStripMenuItem_Click);
            // 
            // registrarseToolStripMenuItem
            // 
            this.registrarseToolStripMenuItem.Name = "registrarseToolStripMenuItem";
            this.registrarseToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.registrarseToolStripMenuItem.Text = "Registrarse";
            this.registrarseToolStripMenuItem.Click += new System.EventHandler(this.registrarseToolStripMenuItem_Click);
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            this.cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            this.cerrarSesiónToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.cerrarSesiónToolStripMenuItem.Text = "Cerrar Sesión";
            this.cerrarSesiónToolStripMenuItem.Click += new System.EventHandler(this.cerrarSesiónToolStripMenuItem_Click_1);
            // 
            // borrarCuentaToolStripMenuItem
            // 
            this.borrarCuentaToolStripMenuItem.Name = "borrarCuentaToolStripMenuItem";
            this.borrarCuentaToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.borrarCuentaToolStripMenuItem.Text = "Borrar cuenta";
            this.borrarCuentaToolStripMenuItem.Click += new System.EventHandler(this.borrarCuentaToolStripMenuItem_Click);
            // 
            // invitarToolStripMenuItem
            // 
            this.invitarToolStripMenuItem.Name = "invitarToolStripMenuItem";
            this.invitarToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.invitarToolStripMenuItem.Text = "Invitar";
            this.invitarToolStripMenuItem.Click += new System.EventHandler(this.invitarToolStripMenuItem_Click);
            // 
            // desconectarseToolStripMenuItem
            // 
            this.desconectarseToolStripMenuItem.Name = "desconectarseToolStripMenuItem";
            this.desconectarseToolStripMenuItem.Size = new System.Drawing.Size(119, 24);
            this.desconectarseToolStripMenuItem.Text = "Desconectarse";
            this.desconectarseToolStripMenuItem.Click += new System.EventHandler(this.desconectarseToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(776, 124);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "CONSULTAS";
            // 
            // Conectados
            // 
            this.Conectados.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Conectados.Location = new System.Drawing.Point(721, 174);
            this.Conectados.Margin = new System.Windows.Forms.Padding(4);
            this.Conectados.Name = "Conectados";
            this.Conectados.Size = new System.Drawing.Size(121, 43);
            this.Conectados.TabIndex = 2;
            this.Conectados.Text = "Conectados";
            this.Conectados.UseVisualStyleBackColor = true;
            this.Conectados.Click += new System.EventHandler(this.Conectados_Click);
            // 
            // Activas
            // 
            this.Activas.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Activas.Location = new System.Drawing.Point(884, 174);
            this.Activas.Margin = new System.Windows.Forms.Padding(4);
            this.Activas.Name = "Activas";
            this.Activas.Size = new System.Drawing.Size(121, 43);
            this.Activas.TabIndex = 3;
            this.Activas.Text = "Activas";
            this.Activas.UseVisualStyleBackColor = true;
            this.Activas.Click += new System.EventHandler(this.Activas_Click);
            // 
            // Acabadas
            // 
            this.Acabadas.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Acabadas.Location = new System.Drawing.Point(804, 252);
            this.Acabadas.Margin = new System.Windows.Forms.Padding(4);
            this.Acabadas.Name = "Acabadas";
            this.Acabadas.Size = new System.Drawing.Size(121, 41);
            this.Acabadas.TabIndex = 4;
            this.Acabadas.Text = "Acabadas";
            this.Acabadas.UseVisualStyleBackColor = true;
            this.Acabadas.Click += new System.EventHandler(this.Acabadas_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.Acabadas);
            this.Controls.Add(this.Activas);
            this.Controls.Add(this.Conectados);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Principal";
            this.Text = "Principal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Principal_FormClosing);
            this.Load += new System.EventHandler(this.Principal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem conectarseAlServidorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem identificaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iniciarSesiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem borrarCuentaToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Conectados;
        private System.Windows.Forms.Button Activas;
        private System.Windows.Forms.Button Acabadas;
        private System.Windows.Forms.ToolStripMenuItem invitarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem desconectarseToolStripMenuItem;
    }
}

