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

        public int turno_actual { get; private set; }

        public string mimazo { get; private set; }
        public string mazopartida { get; private set; }
        public int lastcard { get; private set; }
        public string listajugadoresvivos { get; private set; }
        public int vivo { get; private set; } = 1;
        public int conectado { get; private set; } = 0;
        public int registrado { get; private set; } = 0;



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

        public void Set_turno(int turno)
        {
            this.turno_actual = turno;
        }

        public void Set_mimazo(string mazo)
        {
            this.mimazo = mazo;
        }
        public void Set_mazopartida(string mazo)
        {
            this.mazopartida = mazo;
        }
        public void Set_lastcard(int carta)
        {
            this.lastcard = carta;
        }
        public void Set_listajugadoresvivos(string listajugcon) 
        {
            this.listajugadoresvivos = listajugcon;    
        }
        public void Set_vivo(int alive)
        {
            this.vivo = alive;
        }
        public void Set_registrado(int reg)
        {
            this.registrado = reg;
        }
        public void Set_conectado(int con)
        {
            this.conectado = con;
        }
    }
}
