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
    public partial class IniciarSesion : Form
    {
        private Socket server;
        public IniciarSesion(Socket server)
        {
            InitializeComponent();
            this.server = server;

        }

        private void IniciarSesion_Load(object sender, EventArgs e)
        {

        }

        private void iniciosesion_Click(object sender, EventArgs e)
        {
            if (usuarioBox.Text == "" || contraseñaBox.Text == "") //evitar campos vacíos
            {
                if (usuarioBox.Text == "" && contraseñaBox.Text == "")
                {
                    MessageBox.Show("Por favor rellene los campos.");
                }
                else
                {
                    MessageBox.Show("Por favor rellene todos los campos.");
                }
            }

            else
            {
                string username = usuarioBox.Text;
                string contraseña = contraseñaBox.Text;
                string mensaje = "3/" + username + "/" + contraseña;

                byte[] msg = Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
        }

        private void show_CheckedChanged(object sender, EventArgs e)
        {
            if (show.Checked)
            { contraseñaBox.UseSystemPasswordChar = false; }

            else
            { contraseñaBox.UseSystemPasswordChar = true; }
        }
    }
}
