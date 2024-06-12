using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Cliente_Juego
{
    public partial class Activas : Form
    {
        private Socket server;
        private DataTable datatable;
        public Activas(Socket server, DataTable datatable)
        {
            InitializeComponent();
            this.server = server;
            this.datatable = datatable;
        }

        private void Activas_Load(object sender, EventArgs e)
        {
            activasGrid.Rows.Clear();
            activasGrid.Columns.Clear();
            string mensaje = "11/";
            byte[] msg = Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);


            activasGrid.DataSource = datatable;
        }

        private void activasGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Obtiene la primera celda de la fila clicada
                DataGridViewRow clickedRow = activasGrid.Rows[e.RowIndex];
                object firstCellValue = clickedRow.Cells[0].Value;
                Convert.ToString(firstCellValue);
                string mensaje = "12/";
                byte[] msg = Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);


                //entras en la partida seleccionafa si clicas en una fila del datagridview
                Tablero partida = new Tablero();
                partida.Show();
            }
        }
    }
}
