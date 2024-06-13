namespace Cliente_Juego
{
    partial class Invitación
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
            this.conectadosgrid = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.invitar = new System.Windows.Forms.Button();
            this.jugador_a_invitar_TB = new System.Windows.Forms.TextBox();
            this.añadirbtn = new System.Windows.Forms.Button();
            this.jugadores_invitados = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.conectadosgrid)).BeginInit();
            this.SuspendLayout();
            // 
            // conectadosgrid
            // 
            this.conectadosgrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.conectadosgrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.conectadosgrid.Location = new System.Drawing.Point(319, 158);
            this.conectadosgrid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.conectadosgrid.Name = "conectadosgrid";
            this.conectadosgrid.RowHeadersWidth = 51;
            this.conectadosgrid.Size = new System.Drawing.Size(452, 185);
            this.conectadosgrid.TabIndex = 0;
            this.conectadosgrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.conectadosgrid_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ID Jugador";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Nombre de usuario";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 125;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Puerto de conexión";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 125;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(276, 82);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(495, 38);
            this.label1.TabIndex = 1;
            this.label1.Text = "INVITAR: Jugadores conectados";
            // 
            // invitar
            // 
            this.invitar.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invitar.Location = new System.Drawing.Point(831, 234);
            this.invitar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.invitar.Name = "invitar";
            this.invitar.Size = new System.Drawing.Size(111, 32);
            this.invitar.TabIndex = 2;
            this.invitar.Text = "Invitar";
            this.invitar.UseVisualStyleBackColor = true;
            this.invitar.Click += new System.EventHandler(this.invitar_Click);
            // 
            // jugador_a_invitar_TB
            // 
            this.jugador_a_invitar_TB.Location = new System.Drawing.Point(137, 412);
            this.jugador_a_invitar_TB.Name = "jugador_a_invitar_TB";
            this.jugador_a_invitar_TB.Size = new System.Drawing.Size(100, 22);
            this.jugador_a_invitar_TB.TabIndex = 3;
            // 
            // añadirbtn
            // 
            this.añadirbtn.Location = new System.Drawing.Point(369, 412);
            this.añadirbtn.Name = "añadirbtn";
            this.añadirbtn.Size = new System.Drawing.Size(75, 23);
            this.añadirbtn.TabIndex = 4;
            this.añadirbtn.Text = "Añadir";
            this.añadirbtn.UseVisualStyleBackColor = true;
            this.añadirbtn.Click += new System.EventHandler(this.añadirbtn_Click);
            // 
            // jugadores_invitados
            // 
            this.jugadores_invitados.Location = new System.Drawing.Point(629, 413);
            this.jugadores_invitados.Name = "jugadores_invitados";
            this.jugadores_invitados.ReadOnly = true;
            this.jugadores_invitados.Size = new System.Drawing.Size(100, 22);
            this.jugadores_invitados.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(99, 393);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(203, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Escribe la ID del jugador a invitar";
            // 
            // Invitación
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.jugadores_invitados);
            this.Controls.Add(this.añadirbtn);
            this.Controls.Add(this.jugador_a_invitar_TB);
            this.Controls.Add(this.invitar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.conectadosgrid);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Invitación";
            this.Text = "Invitación";
            this.Load += new System.EventHandler(this.Invitación_Load);
            ((System.ComponentModel.ISupportInitialize)(this.conectadosgrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView conectadosgrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button invitar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.TextBox jugador_a_invitar_TB;
        private System.Windows.Forms.Button añadirbtn;
        private System.Windows.Forms.TextBox jugadores_invitados;
        private System.Windows.Forms.Label label2;
    }
}