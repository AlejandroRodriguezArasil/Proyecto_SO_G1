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
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Cliente_Juego
{
    public partial class Invitación : Form
    {
        private Socket server;
        private DataTable datatable;
        string invitacio = "";
        public Invitación(Socket server, DataTable datatable)
        {
            InitializeComponent();
            this.server = server;
            this.datatable = datatable;
        }

        private void Invitación_Load(object sender, EventArgs e)
        {
            conectadosgrid.Rows.Clear();
            conectadosgrid.Columns.Clear();
            conectadosgrid.DataSource = datatable;
        }

        private void invitar_Click(object sender, EventArgs e)
        {
            string mensaje = "17" + invitacio;    //el string invitacio no se actualiza por clicks en dgv así que manualmente se introduce para probar
            byte[] msg = Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }

        private void conectadosgrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && conectadosgrid.Rows[e.RowIndex].Cells[0].Value != null)
            {
                int fila = e.RowIndex;
                int id_j = Convert.ToInt32(conectadosgrid.Rows[fila].Cells[0].Value);
                invitacio = invitacio + "/" + id_j.ToString();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void añadirbtn_Click(object sender, EventArgs e)
        {
            int id_j = Convert.ToInt32(jugador_a_invitar_TB.Text);
            invitacio = invitacio + "/" + id_j.ToString();
            jugadores_invitados.Text = invitacio;
        }
    }
}
