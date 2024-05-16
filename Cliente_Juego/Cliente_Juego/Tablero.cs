using Cliente_Juego.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cliente_Juego
{
    public partial class Tablero : Form
    {
        ListaUsuariosConectados userpartida;
        public Tablero()
        {
            InitializeComponent();
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
            Tablero.Controls.Clear();

            // Iterate over connected players
            foreach (UsuarioConectado user in userpartida)
            {
                // Create a new picture box
                PictureBox pictureBox = new PictureBox();

                // Set properties of the picture box
                pictureBox.Image = Resources.persona.png; // Assuming you have a default image in your resources
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox.Width = 100; // Set width (adjust as needed)
                pictureBox.Height = 100; // Set height (adjust as needed)
                // Optionally, set other properties such as Name, Tag, etc.

                // Add a tooltip with player's name
                ToolTip toolTip = new ToolTip();
                toolTip.SetToolTip(pictureBox, user);

                // Add the picture box to the container control
                flowLayoutPanel1.Controls.Add(pictureBox);
            }
        }
    }
}
