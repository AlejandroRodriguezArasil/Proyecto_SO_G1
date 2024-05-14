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
        public Usuarios_Conectados()
        {
            InitializeComponent();
           
            actualizarconectados();

            PopulateDataGridView();
            
        }
        
        public void PopulateDataGridView()
        {
            // Create a new DataTable
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ID", typeof(int));
            dataTable.Columns.Add("Nombre", typeof(string));
            dataTable.Columns.Add("Puerto", typeof(int));

            // Iterate through the userconected array and add data to the DataTable
            foreach (UsuarioConectado user in listauserconec.userconected)
            {
                if (user != null) // Check if the slot is not null
                {
                    dataTable.Rows.Add(user.GetID(), user.GetNombre(), user.GetPuerto());
                }
            }

            // Bind DataTable to DataGridView
            lista_usuarios_conectados.DataSource = dataTable;
        }
    }
}

     