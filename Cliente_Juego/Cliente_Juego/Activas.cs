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
            activasGrid.DataSource = datatable;
        }

        private void activasGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void unirse_Click(object sender, EventArgs e)
        {
            int idp = Convert.ToInt32(partidaTB.Text);

            GlobalData.Instance.Set_idpartida(idp);

            //entras en la partida seleccionada con la id
            Tablero partida = new Tablero(this.server);
            partida.ShowDialog();
        }
    }
}
