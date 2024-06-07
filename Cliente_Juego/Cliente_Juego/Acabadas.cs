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
        public Acabadas(Socket server)
        {
            InitializeComponent();
            this.server = server;
        }

        private void Acabadas_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;

            string mensaje = "11/";
            byte[] msg = Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            byte[] msg1 = new byte[80];
            server.Receive(msg1);
            string mensaje1 = Encoding.ASCII.GetString(msg).Split('\0')[0];

            if(mensaje1 != null)
            {
                try
                {
                    string[] trozos = mensaje1.Split('/');

                    DataTable dataTable = new DataTable();
                    dataTable.Clear();
                    dataTable.Columns.Add("ID Partida", typeof(int));

                    string[] trozos1 = trozos[1].Split(',');

                    foreach(string data in trozos1)
                    {
                        if(trozos[0] == "10")
                        {
                            int id = Convert.ToInt32(data);
                            dataTable.Rows.Add(id);
                        }
                        else
                        {
                            MessageBox.Show($"Invalid row data: {data}");
                        }
                    }
                }
                catch (FormatException ex)
                {
                    // Handle format exceptions that occur during conversion
                    MessageBox.Show($"Error converting data: {ex.Message}");
                }
                catch (Exception ex)
                {
                    // Handle any other exceptions that might occur
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }

        }

    }
}
