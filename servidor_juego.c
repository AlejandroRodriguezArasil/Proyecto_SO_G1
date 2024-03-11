#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <mysql.h>



int main(int argc, char *argv[])
{
	
	int sock_conn, sock_listen, ret;
	struct sockaddr_in serv_adr;
	char peticion[512];
	char respuesta[512];
	// INICIALITZACIONS
	// Obrim el socket
	if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0)
		printf("Error creant socket");
	// Fem el bind al port
	
	
	memset(&serv_adr, 0, sizeof(serv_adr));// inicialitza a zero serv_addr
	serv_adr.sin_family = AF_INET;
	
	// asocia el socket a cualquiera de las IP de la m?quina. 
	//htonl formatea el numero que recibe al formato necesario
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	// establecemos el puerto de escucha
	serv_adr.sin_port = htons(9000);
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf ("Error al bind");
	
	if (listen(sock_listen, 3) < 0)
		printf("Error en el Listen");
	
	int i;
	
	
	//iniciamos conexion con la base de datos
	MYSQL *conn;
	int err;
	// Estructura especial para almacenar resultados de consultas 
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	
	//Creamos una conexion al servidor MYSQL 
	conn = mysql_init(NULL);
	if (conn==NULL) {
		printf ("Error al crear la conexiï¿³n: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	//inicializar la conexion
	conn = mysql_real_connect (conn, "localhost","root", "mysql", "juego",0, NULL, 0);
	if (conn==NULL) {
		printf ("Error al inicializar la conexion: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	// Bucle infinito
	for (;;){
		printf ("Escuchando\n");
		
		sock_conn = accept(sock_listen, NULL, NULL);
		printf ("He recibido conexion\n");
		//sock_conn es el socket que usaremos para este cliente
		int terminar =0;
		// Entramos en un bucle para atender todas las peticiones de este cliente
		//hasta que se desconecte
		while (terminar ==0)
		{
			// Ahora recibimos la petici?n
			ret=read(sock_conn,peticion, sizeof(peticion));
			printf ("Recibido\n");
			
			// Tenemos que a?adirle la marca de fin de string 
			// para que no escriba lo que hay despues en el buffer
			peticion[ret]='\0';
			
			
			printf ("Peticion: %s\n",peticion);
			
			// vamos a ver que quieren
			char *p = strtok(peticion, "/");
			int codigo =  atoi (p);
			char consulta[80];
			
			if (codigo !=0)
			{
				p = strtok( NULL, "/");
				
				strcpy (consulta, p);
				// Ya tenemos el nombre
				printf ("Codigo: %d, Consulta: %s\n", codigo, consulta);
			}
			
			if (codigo ==0) //petici?n de desconexi?n
				terminar=1;
			else if(codigo == 1)// consulta 1: Registrarse
			{	
				char registro[100];
				char nombre[100];
				char contrasena[100];
				int i = 5;
				
				p = strtok(NULL, "/");
				strcpy(nombre, p);
				p = strtok(NULL, "/");
				strcpy(contrasena, p);
				
				strcpy (registro,"INSERT INTO Jugador VALUES (");
				strcat (registro, i);
				strcat(registro, ",");
				strcat (registro, nombre);
				strcat(registro, ",");
				strcat (registro, contrasena);
				strcat(registro, ")");
				strcpy (respuesta,"Registrado");
				i = i + 1;
				
				err=mysql_query (conn, registro);
				if (err!=0) {
					printf ("Error al consultar datos de la base %u %s\n",
							mysql_errno(conn), mysql_error(conn));
					exit (1);
				}
				
				mysql_close (conn);
				exit(0); 
			}
			else if(codigo ==2)// consulta 2:
			{	
								
				char pregunta[100];
				strcpy (pregunta,"SELECT * FROM Puntos ORDER BY puntos DESC");
				
				
				err=mysql_query (conn, pregunta);
				if (err!=0) {
					printf ("Error al consultar datos de la base %u %s\n",
							mysql_errno(conn), mysql_error(conn));
					exit (1);
				}
				
				MYSQL_RES* tablaordenada;
				char primero[100];
				char segundo[100];
				MYSQL_ROW fila1;
				MYSQL_ROW fila2;
				
				tablaordenada = mysql_store_result (conn);
				fila1 = mysql_fetch_row (tablaordenada); //al leer la 1a fila cogemos el jugador con mï¿¡s puntos
				fila2 = mysql_fetch_row (tablaordenada); //volvemos a leer para coger la informaciï¿³n del 2o jugador
				strcpy(primero, fila1);
				strcpy(segundo, fila2);
				
				char pregunta2[100];
				strcpy (pregunta2,"SELECT Jugador.nombre FROM Jugador WHERE Jugador.id = '");
				strcat (pregunta, segundo[0]);
				
				if (mysql_store_result (conn) == NULL)
					printf ("No se han obtenido datos en la consulta\n");
				else
					strcpy (respuesta, mysql_store_result (conn));
				
					
				mysql_close (conn);
				exit(0); 
			}
			else if(codigo ==3)// consulta 3: icnicio sesion, supongo que solo un mensaje que ponga OK
			{	
				p = strtok( NULL, "/");
			}
			else if(codigo ==4)//consulta 4: contraseña de un usuario
			{	
				char jugador[20];
				char j;
				j = strtok( NULL, "/");
				strcpy (jugador, j);
				
				char pregunta[100];
				strcpy (pregunta,"SELECT Jugador.contraseña FROM Jugador,Puntos,Partida WHERE Jugador.nombre = '");
				strcat (pregunta, jugador);
				
				
				err=mysql_query (conn, pregunta);
				if (err!=0) {
					printf ("Error al consultar datos de la base %u %s\n",
							mysql_errno(conn), mysql_error(conn));
					exit (1);
				}
				
				resultado = mysql_store_result (conn);
				row = mysql_fetch_row (resultado);
				if (row == NULL)
					printf ("No se han obtenido datos en la consulta\n");
				else
					while (row !=NULL) {
						// la columna 0 contiene la contraseña del jugador
						printf ("%s\n", row[0]);
						strcat (respuesta, row[0]);
						// obtenemos la siguiente fila
						row = mysql_fetch_row (resultado);
					}
					
					mysql_close (conn);
					exit(0);
			}
			
			if (codigo !=0)
			{
					
				printf ("Respuesta: %s\n", respuesta);
				// Enviamos respuesta
				write (sock_conn, respuesta, strlen(respuesta));
			}
		}
		// Se acabo el servicio para este cliente
		close(sock_conn); 
	}
}
