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
using System.Drawing.Text;
using System.Threading;

namespace Cliente_Juego
{
    public partial class MainDish : Form
    {

        Socket server;
        public bool conexion = false;
        private BackgroundWorker backgroundWorker;
        public MainDish()
        {
            InitializeComponent();
            InitializeBackgroundWorker();
        }

        public void Conectarse()
        {
            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            //al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse("192.168.56.102");
            IPEndPoint ipep = new IPEndPoint(direc, 9010);


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
            atenderservidor();
            backgroundWorker.RunWorkerAsync();
        }

        private void atenderservidor ()
        {
            while (conexion == true)
            {
                int op;
                byte[] msg = new byte[80];
                server.Receive(msg);
                string mensaje = Encoding.ASCII.GetString(msg);
                string[] trozos = mensaje.Split('/');
                op = Convert.ToInt32(trozos[0]);

                switch (op)
                {
                    case 20:
                        {
                            string missatge = trozos[1];
                            int id_partida = Convert.ToInt32(trozos[2]);
                            int id_jugador_invitado = Convert.ToInt32(trozos[3]);
                            if (missatge != "")
                            {
                                DialogResult resultado = MessageBox.Show(missatge, "Selecciona opción", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (resultado == DialogResult.Yes)
                                {
                                    string mensaje1 = "21/" + id_partida + "/" + id_jugador_invitado;
                                    byte[] msg1 = Encoding.ASCII.GetBytes(mensaje1);
                                    server.Send(msg1);
                                    //ENTRA EN PARTIDA (supuestamente) si la lógica está implementada
                                    Tablero tablero = new Tablero();
                                    tablero.ShowDialog();
                                }
                            }
                            break;
                        }
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

        private void MainDish_FormClosing(object sender, FormClosingEventArgs e)
        {
            string mensaje = "4/";
            byte[] msg = Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            byte[] msg2 = new byte[80];
            server.Receive(msg2);
            mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
            MessageBox.Show(mensaje);
        }

        private void MainDish_FormClosed(object sender, FormClosedEventArgs e)
        {
            string mensaje = "4/";
            byte[] msg = Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            byte[] msg2 = new byte[80];
            server.Receive(msg2);
            mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
            MessageBox.Show(mensaje);
        }
        private void InitializeBackgroundWorker()
        {
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.DoWork += new DoWorkEventHandler(BackgroundWorker_DoWork);
        }
        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!backgroundWorker.CancellationPending)
            {
                // The code to be executed periodically goes here
                atenderservidor();
                // Sleep for a while to simulate periodic work
                Thread.Sleep(1); // 1000 milliseconds = 1 second
            }
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (backgroundWorker.IsBusy)
            {
                backgroundWorker.CancelAsync();
            }
            base.OnFormClosing(e);
        }




    }
}
