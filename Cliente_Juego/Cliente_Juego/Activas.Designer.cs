namespace Cliente_Juego
{
    partial class Activas
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
            this.activasGrid = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.partidaTB = new System.Windows.Forms.TextBox();
            this.unirse = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.activasGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // activasGrid
            // 
            this.activasGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.activasGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.activasGrid.Location = new System.Drawing.Point(401, 110);
            this.activasGrid.Margin = new System.Windows.Forms.Padding(4);
            this.activasGrid.Name = "activasGrid";
            this.activasGrid.RowHeadersWidth = 51;
            this.activasGrid.Size = new System.Drawing.Size(186, 289);
            this.activasGrid.TabIndex = 0;
            this.activasGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.activasGrid_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(368, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 38);
            this.label1.TabIndex = 1;
            this.label1.Text = "Partidas en curso";
            // 
            // partidaTB
            // 
            this.partidaTB.Location = new System.Drawing.Point(731, 281);
            this.partidaTB.Name = "partidaTB";
            this.partidaTB.Size = new System.Drawing.Size(163, 22);
            this.partidaTB.TabIndex = 2;
            // 
            // unirse
            // 
            this.unirse.Location = new System.Drawing.Point(780, 323);
            this.unirse.Name = "unirse";
            this.unirse.Size = new System.Drawing.Size(75, 23);
            this.unirse.TabIndex = 3;
            this.unirse.Text = "Unirse";
            this.unirse.UseVisualStyleBackColor = true;
            this.unirse.Click += new System.EventHandler(this.unirse_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(607, 226);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(448, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "Introduce la ID de la partida para unirte";
            // 
            // Activas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.unirse);
            this.Controls.Add(this.partidaTB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.activasGrid);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Activas";
            this.Text = "Activas";
            this.Load += new System.EventHandler(this.Activas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.activasGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView activasGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox partidaTB;
        private System.Windows.Forms.Button unirse;
        private System.Windows.Forms.Label label2;
    }
}