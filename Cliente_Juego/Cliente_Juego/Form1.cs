using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cliente_Juego
{
    public partial class cargar_partida : Form
    {
        ListaUsuariosConectados userconlist;
        public cargar_partida()
        {
            InitializeComponent();
        }

        private void cargar_partida_Load(object sender, EventArgs e)
        {
            userconlist.actualizarconectados();
            dgvcarga.DataSource=userconlist.PopulateDataGridView();
        }

        private void cargar_Click(object sender, EventArgs e)
        {
            // passar els jugadors que jugaran
            Tablero tablero = new Tablero();    
            tablero.ShowDialog();   
        }
    }
}
