namespace Cliente_Juego
{
    partial class Usuarios_Conectados
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
            this.lista_usuarios_conectados = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.lista_usuarios_conectados)).BeginInit();
            this.SuspendLayout();
            // 
            // lista_usuarios_conectados
            // 
            this.lista_usuarios_conectados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lista_usuarios_conectados.Location = new System.Drawing.Point(31, 12);
            this.lista_usuarios_conectados.Name = "lista_usuarios_conectados";
            this.lista_usuarios_conectados.RowHeadersWidth = 51;
            this.lista_usuarios_conectados.RowTemplate.Height = 24;
            this.lista_usuarios_conectados.Size = new System.Drawing.Size(714, 382);
            this.lista_usuarios_conectados.TabIndex = 0;
            this.lista_usuarios_conectados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Usuarios_Conectados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lista_usuarios_conectados);
            this.Name = "Usuarios_Conectados";
            this.Text = "Lista Usuarios Conectados";
            ((System.ComponentModel.ISupportInitialize)(this.lista_usuarios_conectados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView lista_usuarios_conectados;
    }
}