﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Cliente_Juego
{
    public partial class Registro : Form
    {
        private Socket server;
        public Registro(Socket server)
        {
            InitializeComponent();
            this.server = server;
        }

        private void Registrarse_Click(object sender, EventArgs e)
        {
            // comprueba errores en los campos de información, si existe un usuario no permite el registro, de lo contrario registra a ese usuario en la base de datos
            if (usuarioBox.Text == "" || contraseñaBox.Text == "") //evitar campos vacíos
            {
                if (usuarioBox.Text == "" &&  contraseñaBox.Text == "")
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
                string mensaje = "1/Registro/" + username + "/" + contraseña + "/quiere registrarse.";


                byte[] msg = Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                
                byte[] msg3 = new byte[80];
                server.Receive(msg3);
                mensaje = Encoding.ASCII.GetString(msg3).Split('\0')[0];
                MessageBox.Show(mensaje);
                if (mensaje == "Registrado") 
                {
                    MessageBox.Show("Te has registrado correctamente");
                }
            }
                
       }
    }
}
