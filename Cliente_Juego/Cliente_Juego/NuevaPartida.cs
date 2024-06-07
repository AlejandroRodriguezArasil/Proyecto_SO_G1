using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cliente_Juego
{
    public partial class cargar_partida : Form
    {
        ListaUsuariosConectados userconlist;
        private Socket server;
        string invitacio = "";
        public cargar_partida(Socket server)
        {
            InitializeComponent();
            this.server = server;
        }

        private void cargar_partida_Load(object sender, EventArgs e)
        {
            //userconlist.actualizarconectados(userconlist);
            //dgvcarga.DataSource=userconlist.PopulateDataGridView(userconlist);

            dgvcarga.DataSource = null;

            string consulta = "5/";
            byte[] msg = Encoding.ASCII.GetBytes(consulta);
            server.Send(msg);
            // recibimos respuesta del servidor
            byte[] msg2 = new byte[80];
            server.Receive(msg2);
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
                    dgvcarga.DataSource = dataTable;
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

        private void cargar_Click(object sender, EventArgs e)
        {
            
            List<UsuarioConectado> userspartida = new List<UsuarioConectado>();
            foreach (DataGridViewRow row in dgvcarga.SelectedRows)
            {
                // Convert the DataGridViewRow.DataBoundItem to UsuarioConectado
                userspartida.Add((UsuarioConectado)row.DataBoundItem);
            }

            // Create a new ListaUsuariosConectados with selected users
            ListaUsuariosConectados userpartida = new ListaUsuariosConectados();
            userpartida.userconected = userspartida.ToArray();
            // passar els jugadors que jugaran
            Tablero tablero = new Tablero();    
            tablero.ShowDialog();   
        }

        private void dgvcarga_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = e.RowIndex;
            int id_j = Convert.ToInt32(dgvcarga.Rows[fila].Cells[0].Value);
            invitacio = invitacio + "-" + id_j;
        }

        private void invitar_Click(object sender, EventArgs e)
        {
            string mensaje1 = "16/" + invitacio;
            byte[] msg1 = Encoding.ASCII.GetBytes(mensaje1);
            server.Send(msg1);

        }
    }
}
