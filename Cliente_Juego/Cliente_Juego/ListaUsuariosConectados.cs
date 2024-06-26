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
        public void actualizarconectados(string serializedData)
        {

            // Desencriptamos la informacion recibida 
            string[] rows = serializedData.Split('/');
            foreach (string rowData in rows)
            {
                string[] fields = rowData.Split(',');
                UsuarioConectado user = new UsuarioConectado();
                // Set values for the user
                user.SetID(Convert.ToInt32(fields[0]));
                user.SetNombre(fields[1]);
                user.SetPuerto(Convert.ToInt32(fields[2]));
                // Add the user to the list
                int n = this.GetNum();
                this.userconected[n] = user;
                this.SetNum(n + 1);
            }

        }

        public DataTable PopulateDataGridView(ListaUsuariosConectados lista)
        {
            // Create a new DataTable
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ID", typeof(int));
            dataTable.Columns.Add("Nombre", typeof(string));
            dataTable.Columns.Add("Puerto", typeof(int));

            // Iterate through the userconected array and add data to the DataTable
            foreach (UsuarioConectado user in lista.userconected)
            {
                if (user != null) // Check if the slot is not null
                {
                    dataTable.Rows.Add(user.GetID(), user.GetNombre(), user.GetPuerto());
                }
            }

            return dataTable;

        }
    }

}
