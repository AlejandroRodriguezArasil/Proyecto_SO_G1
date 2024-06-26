﻿using Cliente_Juego.Properties;
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
using System.Threading;
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
        private string jugador_nombre;
        private int socketconn;
        private int turno_actual;
        private bool turno = false;
        private string mimazo = "-1";
        private int[] mimazodesglosado = new int[10];
        private string mazopartida;
        private int lastcard = -1;
        private int cartajugada = -1;
        private static Random rng = new Random();
        private bool mazocreado = false;

        // Identificadores de cartas (nums 0-9) en orden del tablero
        // 0-bomba
        // 1-no  2-roba de abajo  3-ataque  4-mira el futuro  5-saltar  6-mezclar  7-cambia el futuro  8-ataque dirigido
        // 9-desactivacion (no en el tablero)

        public Tablero(Socket Server)
        {
            InitializeComponent();
            //DisplayPlayerBoxes();
            this.id_jugador = GlobalData.Instance.id_jugador;
            this.id_partida = GlobalData.Instance.id_partida;
            this.jugador_nombre = GlobalData.Instance.nombre_jugador;
            this.socketconn = GlobalData.Instance.socketconn;
            this.server = Server;
        }

        private void Tablero_Load(object sender, EventArgs e)
        {
            //this.Height = 0;

            int alturaTB = this.Height - 50;
            int HTB = 97;
            int alturaB = this.Height - 10;
            cantidad_no.Location = new Point(HTB, alturaTB);
            no_button.Location = new Point(HTB,alturaB);

            GlobalData.Instance.Set_vivo(1);

            Crearmazo(10);
            EnviarMazos();

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
            if (GlobalData.Instance.vivo == 1)
            {
                string consulta = "7/" + this.id_partida;
                byte[] msg = Encoding.ASCII.GetBytes(consulta);
                server.Send(msg);
                Thread.Sleep(500);
                this.turno_actual = GlobalData.Instance.turno_actual;
                if (this.turno_actual == this.id_jugador)
                {
                    this.turno = true;
                }
            }
            else
            {
                MessageBox.Show("Has explotado, no puedes seguir jugando.");
                this.turno = false;
            }

        }

        private void RecibirMazos()  //nota: estructura del mazo  numcarta/numcarta/numcarta...
        {
            string consulta = "8/" + this.id_partida + "/" + this.id_jugador; //missatge que rebem passar-lo al Principal igual que hem fet amb el codi 7
            byte[] msg = Encoding.ASCII.GetBytes(consulta);
            server.Send(msg);
            Thread.Sleep(500);
            this.mimazo = GlobalData.Instance.mimazo;
            this.mazopartida = GlobalData.Instance.mazopartida;
            this.lastcard = GlobalData.Instance.lastcard;
            if (this.mazopartida == null)
            {
                Crearmazo(10);
                EnviarMazos();
                this.mimazo = "-1";
            }
        }

        private void EnviarMazos()
        {
            if (this.mimazo == "")
            {
                this.mimazo = "-1";
            }
            MessageBox.Show("Mimazo: " + this.mimazo);

            string consulta = "9/" + this.id_partida + "/" + this.id_jugador + "/" + this.mimazo + "/" + this.mazopartida + "/" + this.cartajugada;
            MessageBox.Show("Enviamos mazos con: " + consulta);
            byte[] msg = Encoding.ASCII.GetBytes(consulta);
            server.Send(msg);
            this.cartajugada = -1;
            // no recibimos respuesta del servidor
        }

        private void Robarcarta(int pos)
        {
            if (this.turno != true)
            {
                return;
            }
            
            int nuevacarta;

            if (pos == 0) // robar carta normal
            {
                int indexOfSeparator = this.mazopartida.IndexOf('*');
                string primeracarta = this.mazopartida.Substring(0, indexOfSeparator);
                nuevacarta = int.Parse(primeracarta);
                this.mazopartida = this.mazopartida.Substring(indexOfSeparator + 1);
            }
            else if (pos == 1) // robar carta de abajo
            {
                int indexOfLastSeparator = this.mazopartida.LastIndexOf('*');
                string ultimacarta = this.mazopartida.Substring(indexOfLastSeparator + 1);
                nuevacarta = int.Parse(ultimacarta);
                this.mazopartida = this.mazopartida.Substring(0, indexOfLastSeparator);
            }
            else
            {
                return;
            }

            if (nuevacarta == 0)
            {
                GlobalData.Instance.Set_vivo(0);
                MessageBox.Show("¡BOOM!");
                string consulta = "13/" + this.id_jugador + "/" + this.id_partida;
                byte[] msg = Encoding.ASCII.GetBytes(consulta);
                server.Send(msg);    //    logica de haber explotado
            }

            if (this.mimazo == "-1")
            {
                this.mimazo = Convert.ToString(nuevacarta);
            }
            else
            {
                this.mimazo = this.mimazo + "/" + Convert.ToString(nuevacarta);
            }

            DesglosarMazo();
        }


        public void Crearmazo(int longitud)
        {
            string consulta = "14/" + GlobalData.Instance.id_partida;
            byte[] msg = Encoding.ASCII.GetBytes(consulta);
            server.Send(msg);
            // recibimos respuesta del servidor
            Thread.Sleep(500);
            string listajugadoresvivos = GlobalData.Instance.listajugadoresvivos;
            string[] numbers = listajugadoresvivos.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            int numjug = numbers.Length;

            Random random = new Random();
            int totalLength = longitud + numjug;
            int[] cartas = new int[totalLength];

            // Initialize the first numjug elements with zeroes
            for (int i = 0; i < numjug; i++)
            {
                cartas[i] = 0;
            }

            // Fill the remaining elements with random numbers
            for (int i = numjug; i < totalLength; i++)
            {
                cartas[i] = random.Next(10);
            }

            // Shuffle the array to distribute the zeroes randomly
            for (int i = totalLength - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                int temp = cartas[i];
                cartas[i] = cartas[j];
                cartas[j] = temp;
            }

            // Convert the array to a string with elements separated by '*'
            string mazocartas = string.Join("*", cartas);
            this.mazopartida = mazocartas;
            this.mazocreado = true;
            this.mimazo = "-1";
        }

        public void DesglosarMazo()
        {
            if (this.mimazo != "-1")
            {
                try
                {
                    int[] counts = new int[10];
                    string[] numbers = this.mimazo.Split('*');
                    foreach (string number in numbers)
                    {
                        int digit = int.Parse(number);
                        counts[digit]++;
                    }
                    this.mimazodesglosado = counts;
                    PopulateCantidadCartas();
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
        }

        public void PopulateCantidadCartas()
        {
            cantidad_no.Text = mimazodesglosado[0].ToString();
            cantidad_rda.Text = mimazodesglosado[1].ToString();
            cantidad_ataque.Text = mimazodesglosado[2].ToString();
            cantidad_mef.Text = mimazodesglosado[3].ToString();
            cantidad_saltar.Text = mimazodesglosado[4].ToString();
            cantidad_mezclar.Text = mimazodesglosado[5].ToString();
            cantidad_cel.Text = mimazodesglosado[6].ToString();
            cantidad_ataquedir.Text = mimazodesglosado[7].ToString();
        }
        // 1-no  2-roba de abajo  3-ataque  4-mira el futuro  5-saltar  6-mezclar  7-cambia el futuro  8-ataque dirigido
        public void JugarTurno()
        {
            Checkturno();
            
            if (this.turno == true)
            {
                //MessageBox.Show("Es el teu torn");
                RecibirMazos();
                Thread.Sleep(500);
                DesglosarMazo();
                // primero, comprobamos cuál ha sido la ultima carta
                if ((lastcard == 3) || (lastcard == 8))
                {
                    Robarcarta(0);
                    Robarcarta(0);
                    AsignarProximoTurno(0);
                }
                //si no es un ataque
                else
                {
                    if (cartajugada != -1)
                    {
                        if (cartajugada == 1) // no
                        {
                            AsignarProximoTurno(1);
                        }
                        else if (cartajugada == 2) // roba de abajo
                        {
                            Robarcarta(1);
                            AsignarProximoTurno(0);
                        }
                        else if (cartajugada == 3) //ataque
                        {
                            AsignarProximoTurno(0);
                        }
                        else if (cartajugada == 4) //miraelfuturo
                        {
                            string[] numbers = this.mazopartida.Split('/');
                            int[] firstThreeDigits = new int[Math.Min(3, numbers.Length)];
                            for (int i = 0; i < firstThreeDigits.Length; i++)
                            {
                                firstThreeDigits[i] = int.Parse(numbers[i]);
                            }
                            MessageBox.Show($"Las proximas cartas son:\n{firstThreeDigits}\n1-no  2-roba de abajo  3-ataque  4-mira el futuro  5-saltar  6-mezclar  7-cambia el futuro  8-ataque dirigido");
                        }
                        else if (cartajugada == 5) // saltar
                        {
                            AsignarProximoTurno(0);
                        }
                        else if (cartajugada == 6) // mezclar
                        {
                            string[] parts = this.mazopartida.Split('/');
                            parts = parts.OrderBy(x => rng.Next()).ToArray();
                            this.mazopartida = string.Join("/", parts);
                            Robarcarta(1);
                            AsignarProximoTurno(0);
                        }
                        else if (cartajugada == 7) // cambia el futuro
                        {
                            Robarcarta(1);
                            // turno al siguiente

                        }
                        else if (cartajugada == 8) // ataque dirigido
                        {
                            // turno a alguien determinado
                        }
                    }
                    else if (cartajugada == -1 || cartajugada == null)
                    {
                        if(MessageBox.Show("Deseas no tirar?", "No se ha seleccionado carta.", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Robarcarta(0);
                            this.cartajugada = -1;
                            AsignarProximoTurno(0);
                        }
                    }
                }
                EnviarMazos();
            }
            else
            {
                MessageBox.Show("No es tu turno");
            }
        }

        private void Lanzarcarta(int carta)
        {
            if (turno == true)
            {
                if (mimazodesglosado[carta] > 0)
                {
                    cartajugada = carta;
                    int index = mimazo.IndexOf(carta.ToString());
                    if (index != -1)
                    {
                        mimazo = mimazo.Remove(index, 1);
                    }
                }
            }
        }

        private void AsignarProximoTurno(int direccion)  // direccion 0 -> adelante, direccion 1 -> atras
        {
            string consulta = "14/" + id_partida;
            byte[] msg = Encoding.ASCII.GetBytes(consulta);
            server.Send(msg);
            // recibimos respuesta del servidor
            
            string listajugadoresvivos = GlobalData.Instance.listajugadoresvivos;
            string[] numbers = listajugadoresvivos.Split(new char[] { '*' }, StringSplitOptions.RemoveEmptyEntries);
            int index = Array.IndexOf(numbers, id_jugador);
            int nextIndex = id_jugador;
            if (direccion == 0)
            {
                nextIndex = (index + 1) % numbers.Length;
            }
            if (direccion == 1)
            {
                nextIndex = (index - 1) % numbers.Length;
            }
            string update = "15/" + id_partida + "/" + nextIndex;
            byte[] msg3 = Encoding.ASCII.GetBytes(consulta);
            server.Send(msg3);
        }

        private void jugar_turno_Click_1(object sender, EventArgs e)
        {
            JugarTurno();
        }

        private void no_button_Click_1(object sender, EventArgs e)
        {
            Lanzarcarta(1);
        }

        private void jugar_rda_Click_1(object sender, EventArgs e)
        {
            Lanzarcarta(2);
        }

        private void jugar_ataque_Click_1(object sender, EventArgs e)
        {
            Lanzarcarta(3); 
        }

        private void mef_button_Click_1(object sender, EventArgs e)
        {
            Lanzarcarta(4);
        }

        private void saltar_jugar_Click_1(object sender, EventArgs e)
        {
            Lanzarcarta(5);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Lanzarcarta(6);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Lanzarcarta(7);
        }

        private void atdir_button_Click_1(object sender, EventArgs e)
        {
            Lanzarcarta(8);
        }
    }
}
