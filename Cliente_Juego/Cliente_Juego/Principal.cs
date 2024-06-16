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
    public partial class Principal : Form
    {
        Socket server;
        Thread atender;
        DataTable datatable5;
        DataTable datatable10;
        DataTable datatable11;
        public bool conexion = false;
        public string user;

        public Principal()
        {
            InitializeComponent();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            conectarseAlServidorToolStripMenuItem.Enabled = true;
            cerrarSesiónToolStripMenuItem.Enabled = false;
            desconectarseToolStripMenuItem.Enabled = false;
            invitarToolStripMenuItem.Enabled = false;
            borrarCuentaToolStripMenuItem.Enabled = false;
            registrarseToolStripMenuItem.Enabled = false;
            iniciarSesiónToolStripMenuItem.Enabled = false;
        }

        public void Conectarse()
        {
            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            //al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse("10.4.119.5");
            IPEndPoint ipep = new IPEndPoint(direc, 50060);


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

        private void conectarseAlServidorToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Conectarse();
            if (conexion)
            {
                registrarseToolStripMenuItem.Enabled=true;
                conectarseAlServidorToolStripMenuItem.Enabled = false;
                desconectarseToolStripMenuItem.Enabled = true;
                borrarCuentaToolStripMenuItem.Enabled = true;
                invitarToolStripMenuItem.Enabled = false;
                cerrarSesiónToolStripMenuItem.Enabled = false;
                iniciarSesiónToolStripMenuItem.Enabled = true;
            } 
        }
        private void FormularioIniciarSession()
        {
            IniciarSesion iniciarsesion = new IniciarSesion(server);
            iniciarsesion.ShowDialog();
        }
        private void iniciarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (conexion)
            {
                
                ThreadStart ts = delegate { FormularioIniciarSession(); };
                Thread i = new Thread(ts);
                i.Start();
                iniciarSesiónToolStripMenuItem.Enabled = false;
                cerrarSesiónToolStripMenuItem.Enabled = true;
                invitarToolStripMenuItem.Enabled = true;
                borrarCuentaToolStripMenuItem.Enabled = false;
                cerrarSesiónToolStripMenuItem.Enabled = true;
                
            }
            else
            {
                MessageBox.Show("Primero debes conectarte al servidor");
            }
        }

        private void FormularioRegistrar()
        {
            Registro registro = new Registro(server);
            registro.ShowDialog();
        }
        private void registrarseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (conexion)
            {
                ThreadStart ts = delegate { FormularioRegistrar(); };
                Thread r = new Thread(ts);
                r.Start();

            }
            else
            {
                MessageBox.Show("Primero debes conectarte al servidor");
            }
        }

        private void cerrarSesiónToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            string mensaje = "4/";
            byte[] msg = Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            conectarseAlServidorToolStripMenuItem.Enabled = false;
            desconectarseToolStripMenuItem.Enabled = true;
            borrarCuentaToolStripMenuItem.Enabled = true;
            invitarToolStripMenuItem.Enabled = false;
            cerrarSesiónToolStripMenuItem.Enabled = false;
            iniciarSesiónToolStripMenuItem.Enabled = true;
            registrarseToolStripMenuItem.Enabled = true;   
        }
        private void FormularioBorrarCuenta()
        {
            BorrarCuenta borrarcuenta = new BorrarCuenta(server);
            borrarcuenta.ShowDialog();
        }
        private void borrarCuentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (conexion)
            {
                ThreadStart ts = delegate { FormularioBorrarCuenta(); };
                Thread b = new Thread(ts);
                b.Start();

            }
            else
            {
                MessageBox.Show("Primero debes conectarte al servidor");
            }
        }
        private void FormularioInvitar()
        {
            Invitación invitacion = new Invitación(server, datatable5);
            invitacion.ShowDialog();
        }
        private void invitarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (conexion)
            {
                string mensaje1 = "16/";
                byte[] msg1 = Encoding.ASCII.GetBytes(mensaje1);
                server.Send(msg1);

                ThreadStart ts = delegate { FormularioInvitar(); };
                Thread a = new Thread(ts);
                a.Start();
            }
            else
            {
                MessageBox.Show("Primero debes conectarte al servidor");
            }
        }
        public void FormularioTablero()
        {
            Tablero tablero = new Tablero(server);
            tablero.ShowDialog();
        }
        public void ThreadPartida()
        {
            ThreadStart ts = delegate { FormularioTablero(); };
            Thread z = new Thread(ts);
            z.Start();
        }
        private void FormularioConectados()
        {

            Conectados conectados = new Conectados(server, datatable5);
            conectados.ShowDialog();
        }
        private void Conectados_Click(object sender, EventArgs e)
        {
            if (conexion)
            {
                string consulta = "5/";
                byte[] msg = Encoding.ASCII.GetBytes(consulta);
                server.Send(msg);
                ThreadStart ts = delegate { FormularioConectados(); };
                Thread f = new Thread(ts);
                f.Start();

            }
            else
            {
                MessageBox.Show("Primero debes conectarte al servidor");
            }
        }
        private void FormularioActivas()
        {
            Activas activas = new Activas(server, datatable11);
            activas.ShowDialog();
        }
        private void Activas_Click(object sender, EventArgs e)
        {
            if (conexion)
            {
                string mensaje = "11/";
                byte[] msg = Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
                ThreadStart ts = delegate { FormularioActivas(); };
                Thread v = new Thread(ts);
                v.Start();

            }
            else
            {
                MessageBox.Show("Primero debes conectarte al servidor");
            }
        }
        private void FormularioAcabadas()
        {
            Acabadas acabadas = new Acabadas(server, datatable10);
            acabadas.ShowDialog();
        }
        private void Acabadas_Click(object sender, EventArgs e)
        {
            if (conexion)
            {
                string mensaje = "10/";
                byte[] msg = Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
                ThreadStart ts = delegate { FormularioAcabadas(); };
                Thread g = new Thread(ts);
                g.Start();

            }
            else
            {
                MessageBox.Show("Primero debes conectarte al servidor");
            }
        }
        private void Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (conexion)
            {
                string mensaje = "4/";
                byte[] msg = Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
                MessageBox.Show("Desconectado del servidor.");
                conexion = false;
                this.BackColor = Color.Gray;
                server.Shutdown(SocketShutdown.Both);
                server.Close();
                atender.Abort();
            }
        }
        private void desconectarseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            conectarseAlServidorToolStripMenuItem.Enabled = true;
            desconectarseToolStripMenuItem.Enabled = false;
            string mensaje = "0/";
            byte[] msg = Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            conectarseAlServidorToolStripMenuItem.Enabled = true;
            cerrarSesiónToolStripMenuItem.Enabled = false;
            desconectarseToolStripMenuItem.Enabled = false;
            invitarToolStripMenuItem.Enabled = false;
            borrarCuentaToolStripMenuItem.Enabled = false;
            registrarseToolStripMenuItem.Enabled = false;
            iniciarSesiónToolStripMenuItem.Enabled = false;

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
                    case 0:
                        if (Convert.ToInt32(trozos[1]) == 1)
                        {
                            MessageBox.Show("Desconectado del servidor.");
                            conexion = false;
                            this.BackColor = Color.Gray;
                            
                        }
                        else
                            MessageBox.Show("No te has podido desconectar");
                        break;
                    case 1:
                        if (Convert.ToInt32(trozos[1]) == 1)
                        {
                            MessageBox.Show("Te has registrado correctamente");
                        }
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
                        {
                            MessageBox.Show("Has iniciado sesión correctamente");

                            int idjugador = Convert.ToInt32(trozos[2]);
                            string usuari = trozos[3];
                            int socket = Convert.ToInt32(trozos[4]);
                            GlobalData.Instance.Set_nombrejugador(usuari);
                            GlobalData.Instance.Set_idjugador(idjugador);
                            GlobalData.Instance.Set_socketconn(socket);
                        }
                        else if (Convert.ToInt32(trozos[1]) == -2)
                            MessageBox.Show("No has podido iniciar sesión. Revisa los campos o regístrate");
                        else
                            MessageBox.Show("Ha habido un error en el inicio de sesión");
                        break;
                    case 4:
                        if (Convert.ToInt32(trozos[1]) == 1)
                        {
                            MessageBox.Show("Has cerrado sesión correctamente");
                            
                        }
                            
                        else
                            MessageBox.Show("No has podido cerrar sesión");
                        break;
                    case 5:
                        datatable5 = new DataTable();
                        if (trozos.Length > 1)
                        {
                            try
                            {
                                string[] subVector = new string[trozos.Length - 1];
                                Array.Copy(trozos, 1, subVector, 0, trozos.Length - 1);

                                // Unir los elementos en un solo string
                                string resultado1 = String.Join("/", subVector);
                                // Split the serialized data by '/'
                                string[] rows = resultado1.Split('/');

                                // Create a new DataTable and define its columns
                                
                                datatable5.Columns.Add("ID Jugador", typeof(int));
                                datatable5.Columns.Add("Nombre de Usuario", typeof(string));
                                datatable5.Columns.Add("Puerto de Conexión", typeof(int));

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
                                        datatable5.Rows.Add(id, nombre, puerto);
                                    }
                                    else
                                    {
                                        // Handle the case where the number of fields is not as expected
                                        MessageBox.Show($"Invalid row data: {rowData}");
                                    }
                                }

                                // Set the DataSource of the DataGridView to the DataTable
                                //dataGridView3.DataSource = datatable5;
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
                        int turno = Convert.ToInt32(trozos[1]);
                        GlobalData.Instance.Set_turno(turno);
                        break;
                    case 8:
                        
                        string mimazo = trozos[1];
                        string mazopartida = trozos[2];
                        int lastcard = Convert.ToInt32(trozos[3]);
                        GlobalData.Instance.Set_mimazo(mimazo);
                        GlobalData.Instance.Set_mazopartida(mazopartida);
                        GlobalData.Instance.Set_lastcard(lastcard);
                        break; //
                    case 9:
                        break;
                    case 10:
                        datatable10 = new DataTable();
                        if (mensaje != null)
                        {
                            try
                            {
                                string[] subVector = new string[trozos.Length - 1];
                                Array.Copy(trozos, 1, subVector, 0, trozos.Length - 1);

                                // Unir los elementos en un solo string
                                string resultado2 = String.Join("/", subVector);
                                // Split the serialized data by '/'
                                string[] rows = resultado2.Split('/');

                                
                                datatable10.Columns.Add("ID Partida Acabada", typeof(int));

                                foreach (string data in rows)
                                {
                                    if (data != null)
                                    {
                                        int id = Convert.ToInt32(data);
                                        datatable10.Rows.Add(id);
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
                        datatable11 = new DataTable();
                        if (mensaje != null)
                        {
                            try
                            {
                                string[] subVector = new string[trozos.Length - 1];
                                Array.Copy(trozos, 1, subVector, 0, trozos.Length - 1);

                                // Unir los elementos en un solo string
                                string resultado3 = String.Join("/", subVector);
                                // Split the serialized data by '/'
                                string[] rows = resultado3.Split('/');

                                
                                datatable11.Columns.Add("ID Partida Activa", typeof(int));

                                foreach (string data in rows)
                                {
                                    if (data != null)
                                    {
                                        int id = Convert.ToInt32(data);
                                        datatable11.Rows.Add(id);
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
                        GlobalData.Instance.Set_vivo(0);
                        break;
                    case 14:
                        string listajugadoresvivos = trozos[1].TrimEnd('*');
                        GlobalData.Instance.Set_listajugadoresvivos(listajugadoresvivos);
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
                        string nickname = trozos[1];
                        int id_partida = Convert.ToInt32(trozos[2]);
                        int id_jugador_invitado = Convert.ToInt32(trozos[3]);
                        string missatge = nickname + "te ha invitado a una partida";
                        DialogResult resultado = MessageBox.Show(missatge, "Deseas unirte?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (resultado == DialogResult.Yes)
                        {
                            string mensaje1 = "18/" + id_partida + "/" + id_jugador_invitado;
                            byte[] msg1 = Encoding.ASCII.GetBytes(mensaje1);
                            server.Send(msg1);
                            //FALTA ESCIBIR LA LÓGICA DE ENTRAR EN PARTIDA
                            GlobalData.Instance.Set_idpartida(id_partida);
                            ThreadPartida();
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

