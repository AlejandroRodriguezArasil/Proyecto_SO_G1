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

        private void borrar_Click(object sender, EventArgs e)
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
                }
                Close();
            }
        }

        private void show_CheckedChanged(object sender, EventArgs e)
        {
            if (show.Checked)
            { contraseñaBox.UseSystemPasswordChar = false; }

            else
            { contraseñaBox.UseSystemPasswordChar = true; }
        }

        private void contraseñaBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
