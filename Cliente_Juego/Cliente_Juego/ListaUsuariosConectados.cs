using System;
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
    public class ListaUsuariosConectados
    {
        private Socket server;

        public UsuarioConectado[] userconected = new UsuarioConectado[100];
        int num = 0;
        public UsuarioConectado GetUsuarioConectado(int index)
        {
            return userconected[index];
        }
        public int GetNum()
        {
            return num;
        }
        public void SetNum(int a)
        {
            this.num = a;
        }
        public void actualizarconectados()
        {
            ListaUsuariosConectados listauserconec = new ListaUsuariosConectados();
            string consulta = "5/";
            byte[] msg = Encoding.ASCII.GetBytes(consulta);
            server.Send(msg);
            // recibimos respuesta del servidor
            byte[] msg2 = new byte[80];
            server.Receive(msg2);
            string serializedData = Encoding.ASCII.GetString(msg2).Split('\0')[0];
            // Desencriptamos la informacion recibida 
            string[] rows = serializedData.Split('\n');
            foreach (string rowData in rows)
            {
                string[] fields = rowData.Split(',');
                UsuarioConectado user = new UsuarioConectado();
                // Set values for the user
                user.SetID(Convert.ToInt32(fields[0]));
                user.SetNombre(fields[1]);
                user.SetPuerto(Convert.ToInt32(fields[2]));
                // Add the user to the list
                int n = listauserconec.GetNum() + 1;
                listauserconec.userconected[n] = user;
                listauserconec.SetNum(n);
            }
        }
    }

}
