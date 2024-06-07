using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cliente_Juego
{
    public partial class MainDish : Form
    {

        Socket server;
        public bool conexion = false;
        public MainDish()
        {
            InitializeComponent();
        }

        public void Conectarse()
        {
            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            //al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse("10.0.3.15");
            IPEndPoint ipep = new IPEndPoint(direc, 50063);


            //Creamos el socket 
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);//Intentamos conectar el socket
                this.BackColor = Color.Green;
                MessageBox.Show("Conectado!");
                conexion = true;
            }
            catch
            {
                MessageBox.Show("No te has podido conectar al servidor");
            }
        }

        private void iniciarSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (conexion)
            {
                Identificación identificación = new Identificación(server);
                identificación.Show();
            }
            else
            {
                MessageBox.Show("Primero debes conectarte al servidor");
            }
        }

        private void conectarseAlServidorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Conectarse();
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string mensaje = "0/";
            byte[] msg = Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            MessageBox.Show("Desconectado del servidor.");

            conexion = false;
            this.BackColor = Color.Gray;
            server.Shutdown(SocketShutdown.Both);
            server.Close();
        }

        private void MainDish_Load(object sender, EventArgs e)
        {
            while (conexion == true)
            {
                int op;
                byte[] msg = new byte[80];
                // recibo mensaje del servidor
                server.Receive(msg);
                string mensaje = Encoding.ASCII.GetString(msg);
                string[] trozos = mensaje.Split('/');
                op = Convert.ToInt32(trozos[0]);
                // Averiguo el tipo de mensaje
                switch (op)
                {
                    case 16: //Nombre del anterior
                        string missatge = trozos[1];
                        if (missatge != "")
                        {
                            if(MessageBox.Show(missatge, "Aceptar?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                string mensaje16 = "17/" + trozos[2];
                                byte[] msg16 = Encoding.ASCII.GetBytes(mensaje16);
                                server.Send(msg16);
                            }
                        }
                        break;
                }

            }
        }

        private void consultasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (conexion)
            {
                Consultas consulta = new Consultas(server);
                consulta.Show();
            }
            else
            {
                MessageBox.Show("Primero debes conectarte al servidor");
            }
            
        }
    }
}
