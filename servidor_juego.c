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
		else if(codigo ==2)// consulta 2: borrar la cuenta XD
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
			
			if (row == NULL)
			{
				printf("Jugador no encontrado.");
				strcpy(respuesta,"Jugador no encontrado.");
			}
			else 
			{
				
				char borrar[300];
				
				strcpy (borrar,"DELETE FROM Jugador WHERE username = '"); 
				strcat (borrar,nombre ); 
				strcat(borrar, "' AND password = '");
				strcat (borrar, contrasena);
				strcat(borrar, "';");
				
				// DELETE * FROM Jugador WHERE username = 'nombre' AND password = 'contrasena';
				
				printf("%s\n", borrar);
				strcpy (respuesta,"Usuario borrado correctamente.");
				
				
				err=mysql_query (conn, borrar); //err = 1 si existeix ja alguna PRIMARY KEY dins la taula Jugadores
				if (err!=0) {
					printf ("Error al consultar datos de la base %u %s\n",
							mysql_errno(conn), mysql_error(conn));
					//exit (1);
				}
				
				//mysql_close (conn);
				//exit(0);
			}
		}
		else if(codigo ==3)// consulta 3: icnicio sesion, consulta la base de datos para saber si existe esa persona y la añade a la tabla conectados
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
			
			resultado = mysql_store_result(conn);
			row = mysql_fetch_row(resultado);
			if(row == NULL)
			{
				strcpy(respuesta,"Error al iniciar sesion");
			}
			else
			{
				
				Nconectados +=1;
				
				//buscar la id del jugador
				
				char pregunta[100];
				strcpy (pregunta,"SELECT id_jugador FROM Jugador WHERE username = '");
				strcat (pregunta, nombre);
				strcat(pregunta,"';");
				
				
				err=mysql_query (conn, pregunta);
				if (err!=0) {
					printf ("Error al consultar datos de la base %u %s\n",
							mysql_errno(conn), mysql_error(conn));
					//exit (1);
				}
				
				resultado = mysql_store_result (conn);
				row = mysql_fetch_row (resultado);
				int id;
				if (row == NULL)
					printf ("No se han obtenido datos en la consulta\n");
				else
				
					id = atoi(row[0]);
				printf("ID inici de sessio: %d\n",id);
				printf("SOCKET inici de sessio: %d\n",sock_conn);
				
				char conexion[300]; //añadir al jugador a la tabla conectados
				sprintf(conexion, "INSERT INTO Conectados VALUES(%d,'%s',%d);",id,nombre,sock_conn);
				
				err=mysql_query (conn, conexion);
				if (err!=0) {
					printf ("Error al consultar datos de la base %u %s\n",
							mysql_errno(conn), mysql_error(conn));
					//exit (1);
				}
				
				strcpy(respuesta, "Inicio de sesion correcto");
			}
			printf("Conectados: %d\n",Nconectados);
			
		}
		else if(codigo ==4)//consulta 4: tancament de sessio
		{	
			char cerrar[300];
			
			sprintf(borrar, "DELETE FROM Conectados WHERE port = '%d';",sock_conn);
			
			err=mysql_query (conn, borrar); //err = 1 si existeix ja alguna PRIMARY KEY dins la taula Jugadores
			if (err!=0) {
				printf ("Error al consultar datos de la base %u %s\n",
						mysql_errno(conn), mysql_error(conn));
				//exit (1);
			}
		
		}
		else if (codigo == 5) // petici  d'usuaris connectats
		{
			char consulta[100];
			strcpy(consulta, "SELECT * FROM Jugador WHERE conectado = 1;");
			err=mysql_query (conn, consulta);
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
		else if (codigo == 6)
		{
			sprintf(respuesta, "%d", contador);
		}
		else if (codigo == 7) //devuelve el turno
		{
			int partida = strtok( NULL, "/");
			char consulta[100];
			strcpy (consulta,"SELECT turno FROM Auxiliar WHERE id_p = '");
			strcat (consulta, partida);
			strcat(consulta,"';");
			err=mysql_query (conn, consulta);
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
				printf ("%s\n", row[0]);
			sprintf (respuesta,"%s\n", row[0]);
			
			//mysql_close (conn);
			//exit(0);

			
			
		}
		else if (codigo == 8) //proceso de coger el mazo entero
		{
			int partida = strtok( NULL, "/");
			int jugador = strtok( NULL, "/");
			char consulta[100];

			strcpy (consulta,"SELECT cartas FROM Mazo WHERE id_j=");
			strcat (consulta, jugador);
			strcat (consulta, "AND id_p = ");
			strcat (consulta, partida);
			strcat(consulta,";");

			err=mysql_query (conn, consulta);
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
				printf ("%s\n", row[0]);
			sprintf (respuesta,"%s-\n", row[0]);

			strcpy (consulta,"SELECT cartas FROM Mazo WHERE id_j=0 AND id_p = '");
			strcat (consulta, partida);
			strcat(consulta,"';");

			err=mysql_query (conn, consulta);
			if (err!=0) {
				printf ("Error al consultar datos de la base %u %s\n",
						mysql_errno(conn), mysql_error(conn));
				//exit (1);
			}
			
			resultado = mysql_store_result (conn);
			row= mysql_fetch_row (resultado);
			if (row == NULL)
				printf ("No se han obtenido datos en la consulta\n");
			else
				printf ("%s-\n", row[0]);
			strcat (respuesta, row[0]);

			strcpy (consulta,"SELECT lastcard FROM Auxiliar WHERE id_j=");
			strcat (consulta, jugador);
			strcat (consulta, "AND id_p = ");
			strcat (consulta, partida);
			strcat(consulta,";");

			err=mysql_query (conn, consulta);
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
				printf ("%s-\n", row[0]);
			strcat (respuesta, row[0]);

			//mysql_close (conn);
			//exit(0);
			
		}
		else if (codigo == 9) // proceso de actualizar mazos
		{
			int partida = strtok( NULL, "/");
			int jugador = strtok( NULL, "/");
			char mazojugador[100];
			p = strtok( NULL, "-");
			strcpy (mazojugador, p);
			char mazopartida[100];
			p = strtok( NULL, "-");
			strcpy (mazopartida, p);
			int lastcard = strtok( NULL, "-");

			char update[100];

			strcpy(update, "UPDATE Mazo SET cartas = '");
			strcat(update,mazojugador);
			strcat(update,"' WHERE id_j = ");
			strcat(update,"AND WHERE id_p = ");
			err=mysql_query (conn, update);
			if (err!=0) {
				printf ("Error al consultar datos de la base %u %s\n",
						mysql_errno(conn), mysql_error(conn));
				//exit (1);
			}

			strcpy(update, "UPDATE Mazo SET cartas = '");
			strcat(update,mazopartida);
			strcat(update,"' WHERE id_p = ");
			strcat(update,"AND WHERE id_j = 0;");
			err=mysql_query (conn, update);
			if (err!=0) {
				printf ("Error al consultar datos de la base %u %s\n",
						mysql_errno(conn), mysql_error(conn));
				//exit (1);
			}
			
			strcpy(update, "UPDATE Auxiliar SET lastcard = ");
			strcat(update,lastcard);
			strcat(update,";");
			err=mysql_query (conn, update);
			if (err!=0) {
				printf ("Error al consultar datos de la base %u %s\n",
						mysql_errno(conn), mysql_error(conn));
				//exit (1);
			}


			

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
	serv_adr.sin_port = htons(9185);
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
