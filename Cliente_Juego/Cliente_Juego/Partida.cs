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
    public partial class Partida : Form
    {
        private Socket server;
        public Partida(Socket server)
        {
            InitializeComponent();
            this.server = server;
        }
        private void Partida_Load(object sender, EventArgs e)
        {

        }
    }
}
