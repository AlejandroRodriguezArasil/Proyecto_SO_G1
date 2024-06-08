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
        public Activas(Socket server)
        {
            InitializeComponent();
            this.server = server;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Obtiene la primera celda de la fila clicada
                DataGridViewRow clickedRow = dataGridView1.Rows[e.RowIndex];
                object firstCellValue = clickedRow.Cells[0].Value;
                Convert.ToString(firstCellValue);
                string mensaje = "12/";
                byte[] msg = Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);


                //entras en la partida seleccionafa si clicas en una fila del datagridview
                Partida partida = new Partida(server);
                partida.Show();
            }
        }

        private void Activas_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            string mensaje = "11/";
            byte[] msg = Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            Thread.Sleep(1000);

            byte[] msg1 = new byte[80];
            server.Receive(msg1);
            string mensaje1 = Encoding.ASCII.GetString(msg).Split('\0')[0];
            string[] trozos = mensaje1.Split('/');
            int num = Convert.ToInt32(trozos[0]);

            dataGridView1.Columns.Add("Columna1", "ID de la Partida");
            dataGridView1.Columns.Add("Columna2", "Turno de la Partida");

            // Añadir una fila con los datos en una sola línea de código
            dataGridView1.Rows.Add(trozos[1], trozos[2]);
        }
    }
}
