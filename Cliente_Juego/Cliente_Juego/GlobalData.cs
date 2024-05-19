using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente_Juego
{
    public class GlobalData
    {
        private static GlobalData instance = null;
        private static readonly object padlock = new object();

        public int id_jugador { get; private set; }
        public string nombre_jugador { get; private set; }
        public int socketconn { get; private set; }
        public int id_partida { get; private set; }

        private GlobalData() { }

        public static GlobalData Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new GlobalData();
                    }
                    return instance;
                }
            }
        }

        public void Set_idjugador(int idj)
        {
            this.id_jugador = idj;
        }

        public void Set_nombrejugador(string namej)
        {
            this.nombre_jugador = namej;
        }

        public void Set_socketconn(int socket)
        {
            this.socketconn = socket;
        }

        public void Set_idpartida(int idpartida)
        {
            this.id_partida = idpartida;
        }
    }
}

