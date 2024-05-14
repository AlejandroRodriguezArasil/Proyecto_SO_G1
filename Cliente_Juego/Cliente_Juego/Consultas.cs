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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Cliente_Juego
{
    public class UsuarioConectado
    {
        int id;
        string nombre;
        int puerto;
        
        public int GetID()
        {
            return id;
        }
        public string GetNombre()
        {
            return nombre;
        }
        public int GetPuerto()
        {
            return puerto;
        }
        public void SetID(int a)
        {
            this.id=a;
        }
        public void SetNombre(string a)
        {
            this.nombre=a;
        }
        public void SetPuerto(int a)
        {
            this.puerto=a;
        }
    }
    public class ListaUsuariosConectados
    {
        public UsuarioConectado[] userconected = new UsuarioConectado[100];
        int num = 0;
        public UsuarioConectado GetUsuarioConectado(int index)
        {
            return userconected[index];
        }
        public int GetNum()
        {
            return num;
        }
        public void SetNum(int a)
        {
            this.num = a;
        }
    }
    



    public partial class Consultas : Form
    {
        private Socket server;
        public Consultas(Socket server)
        {
            InitializeComponent();
            this.server = server;
        }

        //private void Registrarse_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        int partida = Convert.ToInt32(id_p.Text);

        //        string mensaje = "2/Consulta 2o jugador/Partida:" + id_p.Text;

        //        byte[] msg = Encoding.ASCII.GetBytes(mensaje);
        //        server.Send(msg);
        //        byte[] msg2 = new byte[80];
        //        server.Receive(msg2);

        //        mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
        //        if (mensaje != "")
        //        {
        //            MessageBox.Show("Falta de datos en la base.");
        //        }
        //        else
        //        {
        //            MessageBox.Show("Respuesta: " + mensaje);
        //        }
        //    }
        //    catch 
        //    { MessageBox.Show ("Por favor introduzca un número entero como id de partida"); }

            
        //}

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    if (persona.Text == "")
        //    {
        //        MessageBox.Show("Por favor inserte un nombre de usuario");
        //    }
        //    else
        //    {
        //        string mensaje = "4/Consulta contrasena/" + persona.Text;

        //        byte[] msg = Encoding.ASCII.GetBytes(mensaje);
        //        server.Send(msg);
        //        byte[] msg2 = new byte[80];
        //        server.Receive(msg2);

        //        mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
        //        if (mensaje != "")
        //        {
        //            MessageBox.Show("Respuesta: " + mensaje);
        //        }
        //        else
        //        {
        //            MessageBox.Show("Nombre no encontrado");
        //        }
        //    }

        //}

        //private void cons_Click(object sender, EventArgs e)
        //{
        //    string mensaje = "6/Cuantas consultas";

        //    byte[] msg = Encoding.ASCII.GetBytes(mensaje);
        //    server.Send(msg);
        //    byte[] msg2 = new byte[20];
        //    server.Receive(msg2);

        //    mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];

        //    ResultLbl.Text = mensaje;
        //}

        private void Consultas_Load(object sender, EventArgs e)
        {

        }

        private void nueva_partida_button_Click(object sender, EventArgs e)
        {

        }

        private void activas_button_Click(object sender, EventArgs e)
        {

        }

        private void busqueda_button_Click(object sender, EventArgs e)
        {

        }

        private void acabadas_button_Click(object sender, EventArgs e)
        {

        }

        private void conectados_button_Click(object sender, EventArgs e)
        {
            Usuarios_Conectados ucon = new Usuarios_Conectados();
            ucon.Show();
        }
    }
}
