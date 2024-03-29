﻿using System;
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
            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            //al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse("192.168.56.102");
            IPEndPoint ipep = new IPEndPoint(direc, 9000);


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

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string mensaje = "0/";
            byte[] msg = Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            conexion = false;
            this.BackColor = Color.Gray;
            server.Shutdown(SocketShutdown.Both);
            server.Close();
        }

        private void MainDish_Load(object sender, EventArgs e)
        {

        }
    }
}
