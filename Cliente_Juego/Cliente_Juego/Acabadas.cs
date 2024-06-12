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

namespace Cliente_Juego
{
    public partial class Acabadas : Form
    {
        private Socket server;
        private DataTable datatable;
        public Acabadas(Socket server, DataTable datatable)
        {
            InitializeComponent();
            this.server = server;
            this.datatable = datatable;
        }

        private void Acabadas_Load(object sender, EventArgs e)
        {

            acabadasGrid.DataSource = datatable;

        }
    }
}
