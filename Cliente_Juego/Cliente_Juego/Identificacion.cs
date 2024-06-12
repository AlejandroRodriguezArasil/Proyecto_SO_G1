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
    public partial class Identificación : Form
    {
        private Socket server;

        public Identificación(Socket server)
        {
            InitializeComponent();
            this.server = server;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Registro_Click(object sender, EventArgs e)
        {
            Registro registro = new Registro(server);
            registro.Show();
        }

        private void InicioSesion_Click(object sender, EventArgs e)
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

        private void Show_Hide_CheckedChanged(object sender, EventArgs e)
        {
            if (Show_Hide.Checked)
            { contraseñaBox.UseSystemPasswordChar = false; }

            else
            { contraseñaBox.UseSystemPasswordChar = true; }
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            string mensaje = "4/";
            byte[] msg = Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BorrarCuenta borrar = new BorrarCuenta(server);
            borrar.Show();
        }

        private void atender_server()
        {
            while (true)
            {
                int op;
                byte[] msg = new byte[80];
                server.Receive(msg);
                string mensaje = Encoding.ASCII.GetString(msg).Split('\0')[0];
                string[] trozos = mensaje.Split('/');
                op = Convert.ToInt32(trozos[0]);

                switch (op)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        if (Convert.ToInt32(trozos[1]) == 1)
                        {
                            GlobalData.Instance.Set_idjugador(Convert.ToInt32(trozos[2]));
                            GlobalData.Instance.Set_nombrejugador(trozos[3]);
                            GlobalData.Instance.Set_socketconn(Convert.ToInt32(trozos[1]));
                            MessageBox.Show("Has iniciado sesión correctamente");
                        }
                        else
                            MessageBox.Show("No has podido iniciar sesión");
                        break;
                    case 4:
                        if (Convert.ToInt32(trozos[1]) == 1)
                            MessageBox.Show("Has cerrado sesión correctamente");
                        else
                            MessageBox.Show("No has podido cerrar sesión");
                        break;
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                    case 8:
                        break;
                    case 9:
                        break;
                    case 10:
                        break;
                    case 11:
                        break;
                    case 12:
                        break;
                    case 13:
                        break;
                    case 14:
                        break;
                    case 15:
                        break;
                    case 16:
                        break;
                    case 17:
                        break;
                    case 18:
                        break;
                }
            }
        }
    }
}
