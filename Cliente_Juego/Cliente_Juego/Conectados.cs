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
using System.Threading;

namespace Cliente_Juego
{
    public partial class Conectados : Form
    {
        private Socket server;
        private DataTable datatable;
        public Conectados(Socket server, DataTable datatable)
        {
            InitializeComponent();
            this.server = server;
            this.datatable = datatable;
        }

        private void Conectados_Load(object sender, EventArgs e)
        {
            gridconectados.DataSource = datatable;
        }
    }
}
