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
using System.Drawing.Text;
using System.Threading;

namespace Cliente_Juego
{
    public partial class MainDish : Form
    {

        Socket server;
        Thread atender;
        public bool conexion = false;
        public MainDish()
        {
            InitializeComponent();
        }

        public void Conectarse()
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
                ThreadStart ts = delegate { atender_server(); };
                atender = new Thread(ts);
                atender.Start();
                conexion = true;
            }
            catch (SocketException ex)
            {
                MessageBox.Show("No te has podido conectar al servidor");
            }

        }

        private void FormularioIniciarSesion()
        {
            Identificación identificación = new Identificación(server);
            identificación.ShowDialog();
        }
        private void iniciarSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (conexion)
            {
                ThreadStart ts = delegate { FormularioIniciarSesion(); };
                Thread r = new Thread(ts);
                r.Start();

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
            atender.Abort();
        }
        private void MainDish_Load(object sender, EventArgs e)
        {
           
        }
        private void FormularioConsulta()
        {
            Consultas consulta = new Consultas(server);
            consulta.ShowDialog();
        }

        private void consultasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (conexion)
            {
                ThreadStart ts = delegate { FormularioConsulta(); };
                Thread c = new Thread(ts);
                c.Start();
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
        }

        private void MainDish_FormClosed(object sender, FormClosedEventArgs e)
        {
            string mensaje = "4/";
            byte[] msg = Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }
        public void atender_server()
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
                        if (Convert.ToInt32(trozos[1]) == 1)
                            MessageBox.Show("Te has registrado correctamente");
                        else
                            MessageBox.Show("No te has podido registrar");
                        break;
                    case 2:
                        if (Convert.ToInt32(trozos[1]) == 1)
                            MessageBox.Show("Has borrado tu cuenta correctamente");
                        else
                            MessageBox.Show("No has podido borrar tu cuenta");
                        break;
                    case 3:
                        if (Convert.ToInt32(trozos[1]) == 1)
                            MessageBox.Show("Has iniciado sesión correctamente");
                        else
                            MessageBox.Show("No has podido iniciar sesión");
                        break;
                    case 4:
                        if (Convert.ToInt32(trozos[1]) == 1)
                            MessageBox.Show("Has cerrado sesión correctamente");
                        else
                            MessageBox.Show("No has podido cerrar sesión");
                        break;
                    case 5:
                        string serializedData = mensaje = trozos[1].Split('\0')[0];
                        serializedData = serializedData.TrimEnd('/');

                        if (serializedData != null)
                        {
                            try
                            {
                                // Split the serialized data by '/'
                                string[] rows = serializedData.Split('/');

                                // Create a new DataTable and define its columns
                                DataTable dataTable = new DataTable();
                                dataTable.Clear();
                                dataTable.Columns.Add("ID", typeof(int));
                                dataTable.Columns.Add("Nombre", typeof(string));
                                dataTable.Columns.Add("Puerto", typeof(int));

                                foreach (string rowData in rows)
                                {
                                    // Split the row data by ',' to get the individual fields
                                    string[] fields = rowData.Split(',');

                                    // Ensure that there are exactly 3 fields before proceeding
                                    if (fields.Length == 3)
                                    {
                                        // Parse and convert the fields to their respective types
                                        int id = Convert.ToInt32(fields[0]);
                                        string nombre = fields[1];
                                        int puerto = Convert.ToInt32(fields[2]);

                                        // Add the data to the DataTable
                                        dataTable.Rows.Add(id, nombre, puerto);
                                    }
                                    else
                                    {
                                        // Handle the case where the number of fields is not as expected
                                        MessageBox.Show($"Invalid row data: {rowData}");
                                    }
                                }

                                // Set the DataSource of the DataGridView to the DataTable
                                dataGridView1.DataSource = dataTable;
                            }
                            catch (FormatException ex)
                            {
                                // Handle format exceptions that occur during conversion
                                MessageBox.Show($"Error converting data: {ex.Message}");
                            }
                            catch (Exception ex)
                            {
                                // Handle any other exceptions that might occur
                                MessageBox.Show($"An error occurred: {ex.Message}");
                            }
                        }
                        else
                        {
                            MessageBox.Show("No hay usuarios conectados");
                        }
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
                        if (mensaje != null)
                        {
                            try
                            {

                                DataTable dataTable = new DataTable();
                                dataTable.Clear();
                                dataTable.Columns.Add("ID Partida Acabada", typeof(int));

                                foreach (string data in trozos)
                                {
                                    if (data == "10")
                                    {

                                    }
                                    else if (data != null)
                                    {
                                        int id = Convert.ToInt32(data);
                                        dataTable.Rows.Add(id);
                                    }
                                    else
                                    {
                                        MessageBox.Show($"Invalid row data: {data}");
                                    }
                                }
                            }
                            catch (FormatException ex)
                            {
                                // Handle format exceptions that occur during conversion
                                MessageBox.Show($"Error converting data: {ex.Message}");
                            }
                            catch (Exception ex)
                            {
                                // Handle any other exceptions that might occur
                                MessageBox.Show($"An error occurred: {ex.Message}");
                            }
                        }
                        break;
                    case 11:
                        if (mensaje != null)
                        {
                            try
                            {

                                DataTable dataTable = new DataTable();
                                dataTable.Clear();
                                dataTable.Columns.Add("ID Partida Activa", typeof(int));

                                foreach (string data in trozos)
                                {
                                    if (data == "11")
                                    {

                                    }
                                    else if (data != null)
                                    {
                                        int id = Convert.ToInt32(data);
                                        dataTable.Rows.Add(id);
                                    }
                                    else
                                    {
                                        MessageBox.Show($"Invalid row data: {data}");
                                    }
                                }
                            }
                            catch (FormatException ex)
                            {
                                // Handle format exceptions that occur during conversion
                                MessageBox.Show($"Error converting data: {ex.Message}");
                            }
                            catch (Exception ex)
                            {
                                // Handle any other exceptions that might occur
                                MessageBox.Show($"An error occurred: {ex.Message}");
                            }
                        }
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
                        if (Convert.ToInt32(trozos[1]) == -1)
                            MessageBox.Show("No has podido crear una partida");
                        else
                            MessageBox.Show("Has creado una partida con identificador: " + trozos[1]);
                        break;
                    case 17:
                        if (Convert.ToInt32(trozos[1]) == -1)
                            MessageBox.Show("No se ha podido invitar");
                        else
                        {
                            string nickname = trozos[1];
                            int id_partida = Convert.ToInt32(trozos[2]);
                            int id_jugador_invitado = Convert.ToInt32(trozos[3]);
                            string missatge = nickname + "te ha invitado a su partida";
                            DialogResult resultado = MessageBox.Show(missatge, "Deseas unirte?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (resultado == DialogResult.Yes)
                            {
                                string mensaje1 = "18/" + id_partida + "/" + id_jugador_invitado;
                                byte[] msg1 = Encoding.ASCII.GetBytes(mensaje1);
                                server.Send(msg1);
                                //FALTA ESCIBIR LA LÓGICA DE ENTRAR EN PARTIDA
                            }
                        }
                        break;
                    case 18:
                        if (Convert.ToInt32(trozos[1]) == 0)
                            MessageBox.Show("No has podido crear una partida");
                        else if (Convert.ToInt32(trozos[1]) == 1)
                            MessageBox.Show("Se ha aceptado tu invitación");
                        else
                            MessageBox.Show("Error al recibir respuesta");
                        break;
                }
            }
        }
    }
}
