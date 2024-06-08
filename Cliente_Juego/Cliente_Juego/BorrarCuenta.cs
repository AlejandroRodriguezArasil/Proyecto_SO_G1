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
    public partial class BorrarCuenta : Form
    {
        private Socket server;
        public BorrarCuenta(Socket server)
        {
            InitializeComponent();
            this.server = server;
        }

        private void BorrarCuenta_Load(object sender, EventArgs e)
        {

        }

        private void BorrarBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tu cuenta será borrada.", "Confirma la acción.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
                    string password = contraseñaBox.Text;
                    string mensaje = "2/" + username + "/" + password;

                    byte[] msg = Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                    byte[] msg2 = new byte[80];
                    server.Receive(msg2);

                    mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];

                    if (mensaje != "")
                    {
                        MessageBox.Show(mensaje);
                    }
                }
                Close();
            }
        }

        private void Show_Hide_CheckedChanged(object sender, EventArgs e)
        {
            if(Show_Hide.Checked)
            { contraseñaBox.UseSystemPasswordChar = false; }

            else
            { contraseñaBox.UseSystemPasswordChar = true; }
        }
    }
}
