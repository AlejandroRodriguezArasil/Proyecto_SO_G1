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
    public class UsuarioConectado
    {
        int id;
        string nombre;
        int puerto;

        public int GetID()
        {
            return id;
        }
        public string GetNombre()
        {
            return nombre;
        }
        public int GetPuerto()
        {
            return puerto;
        }
        public void SetID(int a)
        {
            this.id = a;
        }
        public void SetNombre(string a)
        {
            this.nombre = a;
        }
        public void SetPuerto(int a)
        {
            this.puerto = a;
        }
    }
}