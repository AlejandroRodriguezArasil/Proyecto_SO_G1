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

namespace Cliente_Juego
{
    public partial class Acabadas : Form
    {
        private Socket server;
        public Acabadas()
        {
            InitializeComponent();
        }

        private void Acabadas_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            string mensaje = "10/";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            while(true)
            {
                byte[] msg1 = new byte[80];
                server.Receive(msg1);
                string mensaje1 = Encoding.ASCII.GetString(msg).Split('\0')[0];
                string[] trozos = mensaje1.Split('/');
                int num = Convert.ToInt32(trozos[0]);
                switch (num)
                {
                    case 10:
                        dataGridView1.Columns.Add("Columna1", "ID de la Partida");
                        dataGridView1.Columns.Add("Columna2", "Inicio de la Partida");
                        dataGridView1.Columns.Add("Columna3", "Final de la Partida");
                        dataGridView1.Columns.Add("Columna4", "Ganador de la Partida");

                        // Añadir una fila con los datos en una sola línea de código
                        dataGridView1.Rows.Add(trozos[1], trozos[2], trozos[3], trozos[4]);

                }
            }



        }

    }
}
