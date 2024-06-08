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
using System.Security.Cryptography.X509Certificates;
using System.Collections;

namespace Cliente_Juego
{

    public partial class Usuarios_Conectados : Form
    {
        private Socket server;
        ListaUsuariosConectados userconlist;
        public Usuarios_Conectados(Socket server)
        {
            InitializeComponent();
            this.server = server;

        }
        

        private void Usuarios_Conectados_Load(object sender, EventArgs e)
        {

            dataGridView1.DataSource = null;

            string consulta = "5/";
            byte[] msg = Encoding.ASCII.GetBytes(consulta);
            server.Send(msg);
            // recibimos respuesta del servidor
            byte[] msg2 = new byte[80];
            server.Receive(msg2);
            if (Encoding.ASCII.GetString(msg2) == " ")
            { 
                MessageBox.Show("No hay conectados"); 
            }
            else
            {

                string serializedData = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                serializedData = serializedData.TrimEnd('/');

                if (serializedData != null)
                {
                    try
                    {
                        // Split the serialized data by '/'
                        string[] rows = serializedData.Split('/');

                        // Create a new DataTable and define its columns
                        DataTable dataTable = new DataTable();
                        dataTable.Clear();
                        dataTable.Columns.Add("ID", typeof(int));
                        dataTable.Columns.Add("Nombre", typeof(string));
                        dataTable.Columns.Add("Puerto", typeof(int));

                        foreach (string rowData in rows)
                        {
                            // Split the row data by ',' to get the individual fields
                            string[] fields = rowData.Split(',');

                            // Ensure that there are exactly 3 fields before proceeding
                            if (fields.Length == 3)
                            {
                                // Parse and convert the fields to their respective types
                                int id = Convert.ToInt32(fields[0]);
                                string nombre = fields[1];
                                int puerto = Convert.ToInt32(fields[2]);

                                // Add the data to the DataTable
                                dataTable.Rows.Add(id, nombre, puerto);
                            }
                            else
                            {
                                // Handle the case where the number of fields is not as expected
                                MessageBox.Show($"Invalid row data: {rowData}");
                            }
                        }

                        // Set the DataSource of the DataGridView to the DataTable
                        dataGridView1.DataSource = dataTable;
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
                else
                {
                    MessageBox.Show("No hay usuarios conectados");
                }
            }
        }
    }
}

     