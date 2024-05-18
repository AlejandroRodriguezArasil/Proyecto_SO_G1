using Cliente_Juego.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
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
        private string mimazo;
        private int[] mimazodesglosado = new int[10];
        private string mazopartida;
        private int lastcard;
        private int cartajugada;

        // Identificadores de cartas (nums 0-9) en orden del tablero
        // 0-bomba
        // 1-no  2-roba de abajo  3-ataque  4-mira el futuro  5-saltar  6-mezclar  7-cambia el futuro  8-ataque dirigido
        // 9-desactivacion (no en el tablero)
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

        private void RecibirMazos()  //nota: estructura del mazo  numcarta/numcarta/numcarta...
        {
            string consulta = "8/" + this.id_partida + "/" + this.id_jugador;
            byte[] msg = Encoding.ASCII.GetBytes(consulta);
            server.Send(msg);
            // recibimos respuesta del servidor
            byte[] msg2 = new byte[80];
            server.Receive(msg2);
            string serializedData = Encoding.ASCII.GetString(msg2).Split('\0')[0];
            this.mimazo = serializedData.Split('-')[0];
            this.mazopartida = serializedData.Split('-')[1];
            this.lastcard = Convert.ToInt32(serializedData.Split('-')[2]);

        }

        private void EnviarMazos()
        {
            string consulta = "9/" + this.id_partida + "/" + this.id_jugador + "-" + this.mimazo + "-" + this.mazopartida + "-" + this.cartajugada;
            byte[] msg = Encoding.ASCII.GetBytes(consulta);
            server.Send(msg);
            // no recibimos respuesta del servidor
        }
        
        private void Robarcarta (int pos)
        {
            if (this.turno != true)
            {
                return; 
            }

            int nuevacarta;

            if (pos == 0) // robar carta normal
            {
                int indexOfSeparator = this.mazopartida.IndexOf('/');
                string primeracarta = this.mazopartida.Substring(0, indexOfSeparator);
                nuevacarta = int.Parse(primeracarta);
                this.mazopartida = this.mazopartida.Substring(indexOfSeparator + 1);
            }
            else if (pos == 1) // robar carta de abajo
            {
                int indexOfLastSeparator = this.mazopartida.LastIndexOf('/');
                string ultimacarta = this.mazopartida.Substring(indexOfLastSeparator + 1);
                nuevacarta = int.Parse(ultimacarta);
                this.mazopartida = this.mazopartida.Substring(0, indexOfLastSeparator);
            }
            else
            {
                return; 
            }

            //if(nuevacarta == 0)
            //{
            //    logica de haber explotado
            //}

            this.mimazo = this.mimazo + "/" + Convert.ToString(nuevacarta);
        }


        public void Crearmazo (int longitud)
        {
            Random random = new Random();
            int[] cartas = new int[longitud];
            for (int i = 0; i < longitud; i++)
            {
                cartas[i] = random.Next(10); 
            }
            string mazocartas = string.Join("/", cartas);
            this.mazopartida = mazocartas;
        }

        public void DesglosarMazo()
        {
            int[] counts = new int[10];
            string[] numbers = this.mimazo.Split('/');
            foreach (string number in numbers)
            {
                int digit = int.Parse(number);
                counts[digit]++;
            }
            this.mimazodesglosado = counts;
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
