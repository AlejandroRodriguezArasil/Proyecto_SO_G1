﻿using System;
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
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                if (mensaje == "-")
                {
                    MessageBox.Show("Error al iniciar sesión");
                }
                else
                {
                    MessageBox.Show("Sesión iniciada correctamente");
 
                }
                string[] trozos = mensaje.Split('/');
                
                try
                {
                    GlobalData.Instance.Set_idjugador(Convert.ToInt32(trozos[2]));
                    GlobalData.Instance.Set_nombrejugador(username);
                    GlobalData.Instance.Set_socketconn(Convert.ToInt32(trozos[1]));
                }
                catch { }
                
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
            byte[] msg2 = new byte[80];
            server.Receive(msg2);
            mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
            MessageBox.Show(mensaje);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BorrarCuenta borrar = new BorrarCuenta(server);
            borrar.Show();
        }
    }
}
