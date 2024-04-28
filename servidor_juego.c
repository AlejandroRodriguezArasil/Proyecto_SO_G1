#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <mysql.h>
#include <pthread.h>

int Nconectados;
int contador;

void *AtenderCliente(void *socket)
{
	
	int sock_conn;
	int *s;
	s = (int*) socket;
	sock_conn = *s;
	int numjug;
	
	//iniciamos conexion con la base de datos
	MYSQL *conn;
	int err;
	// Estructura especial para almacenar resultados de consultas 
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	
	//Creamos una conexion al servidor MYSQL 
	conn = mysql_init(NULL);
	if (conn==NULL) {
		printf ("Error al crear la conexion: %u %s\n", 
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
	
	int ret;
	char peticion[512];
	char respuesta[512];
	
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
			// aqui ha d'anar el codi x canviar l'estat a desconectat a la base de dades
			terminar=1;
		else if(codigo == 1)// consulta 1: Registrarse
		{	
			
			char nombre[100];
			char contrasena[100];
			
			p = strtok(NULL, "/");
			strcpy(nombre, p);
			p = strtok(NULL, "/");
			strcpy(contrasena, p);
			
			printf("nombre: %s \n", nombre);
			printf("contrase a: %s\n", contrasena);
			
			char Existe[300];
			strcpy (Existe, "SELECT username FROM Jugador WHERE username = '");
			strcat(Existe,nombre);
			strcat(Existe,"';");
			
			err=mysql_query (conn, Existe); //err = 1 si existeix ja alguna PRIMARY KEY dins la taula Jugadores
			if (err!=0) {
				printf ("Error al consultar datos de la base %u %s\n",
						mysql_errno(conn), mysql_error(conn));
				//exit (1);
			}
			
			resultado = mysql_store_result(conn);
			row = mysql_fetch_row(resultado);
			
			if (row != NULL)
			{
				printf("Jugador ya existe.");
				strcpy(respuesta,"Nombre de usuario existente.");
				printf("0: %d\n",row[0]);
			}
			else 
			{
				int numjug;
				p = strtok(NULL, "/");
				numjug = atoi(p);
				
				char registro[300];
				
				strcpy (registro,"INSERT INTO Jugador VALUES ("); //INSERT INTO Jugador VALUES (5, nombre, contrase a)
				sprintf (registro, "%s%d",registro,numjug ); 
				strcat(registro, ",'");
				strcat (registro, nombre);
				strcat(registro, "','");
				strcat (registro, contrasena);
				strcat(registro, "');");
				
				printf("%s\n", registro);
				strcpy (respuesta,"Registrado correctamente");
				
				
				err=mysql_query (conn, registro); //err = 1 si existeix ja alguna PRIMARY KEY dins la taula Jugadores
				if (err!=0) {
					printf ("Error al consultar datos de la base %u %s\n",
							mysql_errno(conn), mysql_error(conn));
					//exit (1);
				}
				
				//mysql_close (conn);
				//exit(0);
			}
		}
		else if(codigo ==2)// consulta 2:
		{				
			char pregunta[300];
			strcpy (pregunta,"SELECT * FROM Puntos ORDER BY puntos DESC");
			
			
			err=mysql_query (conn, pregunta);
			if (err!=0) {
				printf ("Error al consultar datos de la base %u %s\n",
						mysql_errno(conn), mysql_error(conn));
				//exit (1);
			}
			
			MYSQL_RES *tablaordenada;
			char primero[100];
			char segundo[100];
			MYSQL_ROW fila1;
			MYSQL_ROW fila2;
			
			tablaordenada = mysql_store_result (conn);
			fila1 = mysql_fetch_row (tablaordenada); //al leer la 1a fila cogemos el jugador con m￡s puntos
			fila2 = mysql_fetch_row (tablaordenada); //volvemos a leer para coger la informacion del 2o jugador
			strcpy(primero, fila1[1]);
			strcpy(segundo, fila2[1]);
			
			char pregunta2[100];
			sprintf (pregunta2,"SELECT username FROM Jugador WHERE id_jugador = '%s'",segundo);
			
			err=mysql_query (conn, pregunta2);
			if (err!=0) {
				printf ("Error al consultar datos de la base %u %s\n",
						mysql_errno(conn), mysql_error(conn));
				exit (1);
			}
			
			if (mysql_store_result (conn) == NULL)
				printf ("No se han obtenido datos en la consulta\n");
			else
				printf(mysql_store_result(conn));
			strcpy (respuesta, mysql_store_result (conn));
			
			
			//mysql_close (conn);
			//exit(0); 
		}
		else if(codigo ==3)// consulta 3: icnicio sesion, consulta la base de datos para saber si existe esa persona
		{	
			char sesion[300];
			char nombre[100];
			char contrasena[100];
			char conectado[100];
			
			p = strtok(NULL, "/");
			strcpy(nombre, p);
			p = strtok(NULL, "/");
			strcpy(contrasena, p);
			
			printf("nombre: %s \n", nombre);
			printf("contrase a: %s\n", contrasena);
			
			strcpy(sesion,"SELECT id_jugador FROM Jugador WHERE username = '");
			strcat(sesion,nombre);
			strcat(sesion,"' AND password = '");
			strcat(sesion,contrasena);
			strcat(sesion,"';");
			
			err=mysql_query (conn, sesion);
			if (err!=0) {
				printf ("Error al consultar datos de la base %u %s\n",
						mysql_errno(conn), mysql_error(conn));
				//exit (1);
			}
			
			Nconectados +=1;
			
			resultado = mysql_store_result(conn);
			int res = resultado;
			sprintf(respuesta, "Jugador con identificacion: %d",res);
			// canviem l'identificador de connectat ara que ja s'ha fet la conexi  amb  xit
			strcpy(conectado, "UPDATE Jugador SET conectado = 1 WHERE username = '");
			strcat(conectado,nombre);
			strcat(conectado,"';");
			err=mysql_query (conn, conectado);
			
		}
		else if(codigo ==4)//consulta 4: contrase a de un usuario
		{	
			char jugador[16];
			p = strtok( NULL, "/");
			strcpy (jugador, p);
			
			char pregunta[100];
			strcpy (pregunta,"SELECT password FROM Jugador WHERE username = '");
			strcat (pregunta, jugador);
			strcat(pregunta,"';");
			
			
			err=mysql_query (conn, pregunta);
			if (err!=0) {
				printf ("Error al consultar datos de la base %u %s\n",
						mysql_errno(conn), mysql_error(conn));
				//exit (1);
			}
			
			resultado = mysql_store_result (conn);
			row = mysql_fetch_row (resultado);
			if (row == NULL)
				printf ("No se han obtenido datos en la consulta\n");
			else
				// la columna 0 contiene la contrase a del jugador
				printf ("%s\n", row[0]);
			sprintf (respuesta,"%s\n", row[0]);
			
			//mysql_close (conn);
			//exit(0);
		}
		else if (codigo == 5) // petici  d'usuaris connectats
		{
			char consulta[100];
			strcpy(consulta, "SELECT * FROM Conectados;");
			err=mysql_query (conn, consulta);
			if (err!=0) {
				printf ("Error al consultar datos de la base %u %s\n",
						mysql_errno(conn), mysql_error(conn));
				//exit (1);
			}
			
			resultado = mysql_store_result (conn);
			row = mysql_fetch_table (resultado);
			if (row == NULL)
				printf ("No se han obtenido datos en la consulta\n");
			else
				while (row != NULL)
				{
					sprintf(respuesta, "%s,%s,%s\n", row[0], row[1], row[2]);
 					row = mysql_fetch_table (resultado);
				}
			
			//mysql_close (conn);
			//exit(0);
		
	
		}
		else if (codigo == 6)
		{
			sprintf(respuesta, "%d", contador);
		}
		
		if (codigo !=0)
		{
			
			printf ("Respuesta: %s\n", respuesta);
			// Enviamos respuesta
			write (sock_conn, respuesta, strlen(respuesta));
		}
		if (codigo ==1 || codigo == 2 || codigo ==3 || codigo == 4|| codigo == 5)
		{
			contador += 1;
		}
	}
	// Se acabo el servicio para este cliente
	close(sock_conn);
	//exit(0);
}


int main(int argc, char *argv[])
{
	
	int sock_conn, sock_listen;
	struct sockaddr_in serv_adr;
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
	serv_adr.sin_port = htons(9285);
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf ("Error al bind\n");
	
	if (listen(sock_listen, 3) < 0)
		printf("Error en el Listen");
	
	
	contador = 0;
	Nconectados = 0;
	int i = 0;
	int sockets[100];
	pthread_t thread;
	
	// Bucle infinito
	for (;;){
		printf ("Escuchando\n");
		
		sock_conn = accept(sock_listen, NULL, NULL);
		printf ("He recibido conexion\n");
		
		sockets[i] = sock_conn;
		//sock_conn es el socket que usaremos para este cliente
		
		pthread_create (&thread,NULL,AtenderCliente,&sockets[i]);
		i += 1;
	}
	
	
}
