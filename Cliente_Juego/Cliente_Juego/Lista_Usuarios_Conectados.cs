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
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Collections;

namespace Cliente_Juego
{

    public partial class Usuarios_Conectados : Form
    {
        private Socket server;
        ListaUsuariosConectados userconlist;
        public Usuarios_Conectados()
        {
            InitializeComponent();
           
            userconlist.actualizarconectados();

            lista_usuarios_conectados.DataSource = userconlist.PopulateDataGridView(userconlist);
            
        }
        

        private void Usuarios_Conectados_Load(object sender, EventArgs e)
        {

        }
    }
}

     