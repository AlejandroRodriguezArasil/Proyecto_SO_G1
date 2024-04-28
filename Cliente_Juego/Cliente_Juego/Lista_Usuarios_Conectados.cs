using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Cliente_Juego
{
    public partial class Usuarios_Conectados : Form
    {
        private Socket server;
        public Usuarios_Conectados()
        {
            InitializeComponent();
            // enviamos peticion de usuarios conectados
            string consulta = "5/";
            byte[] msg = Encoding.ASCII.GetBytes(consulta);
            server.Send(msg);

            // recibimos respuesta del servidor
            byte[] msg2 = new byte[80];
            server.Receive(msg2);
            string serializedData = Encoding.ASCII.GetString(msg2).Split('\0')[0];

            // Desencriptamos la informacion recibida 
            DataTable dataTable = new DataTable();
            string[] rows = serializedData.Split('\n');
            foreach (string rowData in rows)
            {
                string[] fields = rowData.Split(',');
                dataTable.Rows.Add(fields);
            }

            // Bind DataTable to DataGridView
            lista_usuarios_conectados.DataSource = dataTable;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
