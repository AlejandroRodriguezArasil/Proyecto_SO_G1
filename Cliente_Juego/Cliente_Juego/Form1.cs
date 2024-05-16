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
            dgvcarga.DataSource=userconlist.PopulateDataGridView(userconlist);
        }

        private void cargar_Click(object sender, EventArgs e)
        {
            List<UsuarioConectado> userspartida = new List<UsuarioConectado>();
            foreach (DataGridViewRow row in dgvcarga.SelectedRows)
            {
                // Convert the DataGridViewRow.DataBoundItem to UsuarioConectado
                userspartida.Add((UsuarioConectado)row.DataBoundItem);
            }

            // Create a new ListaUsuariosConectados with selected users
            ListaUsuariosConectados userpartida = new ListaUsuariosConectados();
            userpartida.userconected = userspartida.ToArray();
            // passar els jugadors que jugaran
            Tablero tablero = new Tablero();    
            tablero.ShowDialog();   
        }
    }
}
