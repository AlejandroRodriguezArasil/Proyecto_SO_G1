using Cliente_Juego.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cliente_Juego
{
    public partial class Tablero : Form
    {
        ListaUsuariosConectados userpartida;
        private Socket server;
        private int id_partida;
        private int id_jugador;
        private int turno_actual;
        private bool turno = false;
        public Tablero()
        {
            InitializeComponent();
            Identificarpartida();
            Identificarjugador();
            DisplayPlayerBoxes();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void DisplayPlayerBoxes()
        {
            // Clear existing controls from the container (if any)
            Controls.Clear();

            // Iterate over connected players
            foreach (UsuarioConectado user in userpartida.userconected)
            {
                // Create a new picture box
                PictureBox pictureBox = new PictureBox();

                // Set properties of the picture box
                pictureBox.Image = Resources.persona; // Assuming you have a default image in your resources
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox.Width = 100; // Set width (adjust as needed)
                pictureBox.Height = 100; // Set height (adjust as needed)
                // Optionally, set other properties such as Name, Tag, etc.

                // Add a tooltip with player's name
                ToolTip toolTip = new ToolTip();
                string name = user.GetNombre();
                toolTip.SetToolTip(pictureBox, name);

                // Add the picture box to the container control
                //flowLayoutPanel1.
                Controls.Add(pictureBox);
            }
        }

        
        private void Checkturno()
        {
            string consulta = "7/" + this.id_partida;
            byte[] msg = Encoding.ASCII.GetBytes(consulta);
            server.Send(msg);
            // recibimos respuesta del servidor
            byte[] msg2 = new byte[80];
            server.Receive(msg2);
            string serializedData = Encoding.ASCII.GetString(msg2).Split('\0')[0];
            turno_actual = Convert.ToInt32(serializedData);
            if (this.turno_actual == this.id_jugador)
            {
                turno = true;
            }


        }

        private void Robarcarta()
        {
            string consulta = "8/" + this.id_partida + "/" + this.id_jugador;
            byte[] msg = Encoding.ASCII.GetBytes(consulta);
            server.Send(msg);
            // recibimos respuesta del servidor
            byte[] msg2 = new byte[80];
            server.Receive(msg2);
            string serializedData = Encoding.ASCII.GetString(msg2).Split('\0')[0];
        }


        public void Identificarpartida()
        {
            this.id_partida = 0; // a pasar mas tarde des de otro formulario
        }
        public void Identificarjugador()
        {
            this.id_jugador = 0; // a pasar mas tarde des de otro formulario
        }
    }
}
