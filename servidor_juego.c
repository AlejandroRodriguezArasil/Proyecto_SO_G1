#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <mysql.h>
#include <pthread.h>
//#include <my_global.h>

int Nconectados;
int contador;

pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;

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
	conn = mysql_real_connect (conn, "shiva2.upc.es","root", "mysql", "T1_Juego",0, NULL, 0);
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
		printf("Codigo: %d\n",codigo);
		
		switch(codigo)
		{
			case 0:
			{
				terminar = 1;
				break;
			}//petici?n de desconexi?n
			case 1:// consulta 1: Registrarse
			{	
					
				char nombre[100];
				char contrasena[100];
				
				p = strtok(NULL, "/");
				strcpy(nombre, p);
				p = strtok(NULL, "/");
				strcpy(contrasena, p);
				
				printf("nombre: %s \n", nombre);
				printf("contrase a: %s\n", contrasena);
				
				int numjug = 1;
				char contar[300];
				strcpy (contar,"SELECT * FROM Jugador");
				
				err=mysql_query (conn, contar); //err = 1 si existeix ja alguna PRIMARY KEY dins la taula Jugadores
				if (err!=0) {
					printf ("Error al consultar datos de la base %u %s\n",
							mysql_errno(conn), mysql_error(conn));
					//exit (1);
				}
				
				
				resultado = mysql_store_result(conn);
				row = mysql_fetch_row(resultado);
				
				while (row != NULL)
				{
					numjug = atoi(row[0]) + 1;
					row = mysql_fetch_row(resultado);
				}
				
				printf("El jugador tindrà la id: %d\n",numjug);
				
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
					printf("0: %s\n",row[0]);
				}
				else 
				{
					
					char registro[400];
					
					pthread_mutex_lock(&mutex);
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
					pthread_mutex_unlock(&mutex);
					
					//mysql_close (conn);
					//exit(0);
				}
				break;
			}
			case 2:// consulta 2: borrar la cuenta XD
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
					
					pthread_mutex_lock(&mutex);
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
					pthread_mutex_unlock(&mutex);
					
					//mysql_close (conn);
					//exit(0);
				}
				break;
			}
			case 3:// consulta 3: icnicio sesion, consulta la base de datos para saber si existe esa persona y la aï¿½ade a la tabla conectados
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
					
					pthread_mutex_lock(&mutex);
					char conexion[300]; //aï¿½adir al jugador a la tabla conectados
					sprintf(conexion, "INSERT INTO Conectados VALUES(%d,'%s',%d);",id,nombre,sock_conn);
					
					err=mysql_query (conn, conexion);
					if (err!=0) {
						printf ("Error al consultar datos de la base %u %s\n",
								mysql_errno(conn), mysql_error(conn));
						//exit (1);
					}
					pthread_mutex_unlock(&mutex);
					
					sprintf(respuesta, "Inicio de sesion correcto/%d/%d",sock_conn,id);
					
				}
				printf("Conectados: %d\n",Nconectados);
				break;
				
			}
			case 4://consulta 4: tancament de sessio
			{	
							
				char cerrar[300];
				
				
				pthread_mutex_lock(&mutex);
				sprintf(cerrar, "DELETE FROM Conectados WHERE port = %d;",sock_conn);
				
				err=mysql_query (conn, cerrar); //err = 1 si existeix ja alguna PRIMARY KEY dins la taula Jugadores
				if (err!=0) {
					printf ("Error al consultar datos de la base %u %s\n",
							mysql_errno(conn), mysql_error(conn));
					//exit (1);
				}
				else{
					strcpy(respuesta,"Cierre de sesion exitoso");
				}
				pthread_mutex_unlock(&mutex);
				
				//mysql_close (conn);
				//exit(0);
				break;
				
			}
			case 5: // peticio  d'usuaris connectats
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
				row = mysql_fetch_row (resultado);
				strcpy(respuesta,"");
				if (row == NULL)
					printf ("No se han obtenido datos en la consulta\n");
				else{
					while (row != NULL)
					{
						
						strcat(respuesta, row[0]);
						strcat(respuesta,",");
						strcat(respuesta,row[1]);
						strcat(respuesta,",");
						strcat(respuesta,row[2]);
						strcat(respuesta,"/");
						
						row = mysql_fetch_row(resultado);
					}
				}
				
				
				//mysql_close (conn);
				//exit(0);
				break;
				
			}
			case 6:
			{
				sprintf(respuesta, "%d", contador);
				break;
			}
			case 7: //devuelve el turno
			{
				p = strtok(NULL,"/");
				int partida = atoi(p);
				char consulta[100];
				sprintf (consulta,"SELECT turno FROM Auxiliar WHERE id_p = %d;",partida);
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
				break;
					
			}
			case 8: //proceso de coger el mazo entero
			{
				p = strtok(NULL,"/");
				int partida = atoi(p);
				p = strtok(NULL,"/");
				int jugador = atoi(p);
				char consulta[100];
				
				sprintf(consulta,"SELECT cartas FROM Mazo WHERE id_j= %d AND id_p = %d;", jugador,partida);
				
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
				
				sprintf (consulta,"SELECT cartas FROM Mazo WHERE id_j=0 AND id_p = %d;",partida);
				
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
				
				sprintf (consulta,"SELECT lastcard FROM Auxiliar WHERE id_j =%d AND id_p = %d;",jugador,partida);
				
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
				break;
				
			}
			case 9: // proceso de actualizar mazos
			{
				p = strtok(NULL,"/");
				int partida = atoi(p);
				p = strtok(NULL,"/");
				int jugador = atoi(p);
				
				char mazojugador[100];
				p = strtok( NULL, "-");
				strcpy (mazojugador, p);
				char mazopartida[100];
				p = strtok( NULL, "-");
				strcpy (mazopartida, p);
				p = strtok(NULL,"-");
				int lastcard = atoi(p);
				
				char update[200];
				
				sprintf(update, "UPDATE Mazo SET cartas = '%s' WHERE id_j = %d AND id_p = %d;",mazojugador,jugador,partida);
				
				err=mysql_query (conn, update);
				if (err!=0) {
					printf ("Error al consultar datos de la base %u %s\n",
							mysql_errno(conn), mysql_error(conn));
					//exit (1);
				}
				
				sprintf(update,"UPDATE Mazo SET cartas = '%s' WHERE id_j = 0 AND id_p = %d;", mazopartida,partida);
				
				if (err!=0) {
					printf ("Error al consultar datos de la base %u %s\n",
							mysql_errno(conn), mysql_error(conn));
					//exit (1);
				}
				
				sprintf(update, "UPDATE Auxiliar SET lastcard = %d WHERE id_p = %d;",lastcard,partida);
				
				err=mysql_query (conn, update);
				if (err!=0) {
					printf ("Error al consultar datos de la base %u %s\n",
							mysql_errno(conn), mysql_error(conn));
					//exit (1);
				}
			
				break;
			}
			case 10: //partidas acabadas se envia como formato al cliente 10,id_partida
			{
				
				printf("tenim el codi 10");
				
				char jugador [300];
				sprintf(jugador, "SELECT id_jugador FROM Conectados WHERE port = %d;",sock_conn);
				
				resultado = mysql_store_result(conn);
				row = mysql_fetch_row(resultado);
				int id_jugador = atoi(row[0]);
				
				printf("id jugador: %d",id_jugador);
				
				char consulta[300];
				sprintf(consulta,"SELECT id_p FROM Partida,Puntos WHERE Puntos.id_j = %d AND Partida.acabada = 1 AND Partida.id_partida = Puntos.id_p;",id_jugador);
				
				
				err=mysql_query (conn, consulta);
				if (err!=0) {
					printf ("Error al consultar datos de la base %u %s\n",
							mysql_errno(conn), mysql_error(conn));
					//exit (1);
				}
				
				
				resultado = mysql_store_result(conn);
				row = mysql_fetch_row(resultado);
				strcpy(respuesta,"10/");
				while(row != NULL)
				{
					char partida[10];
					sprintf(partida,"%s",row[0]);
					strcat(respuesta, partida); 
					strcat(respuesta,",");
					printf("respuesta: %s\n", respuesta);
					row = mysql_fetch_row(resultado);
				}
				
				break;
			}
			case 11: //partidas acativas que se envian como formato al cliente 11/id_partida/turno
			{
				printf("estas en el codi 11");
				
				char jugador [300];
				sprintf(jugador, "SELECT id_j FROM Conectados WHERE port = %d;",sock_conn);
				
				err=mysql_query (conn, jugador);
				if (err!=0) {
					printf ("Error al consultar datos de la base %u %s\n",
							mysql_errno(conn), mysql_error(conn));
					//exit (1);
				}
				
				resultado = mysql_store_result(conn);
				row = mysql_fetch_row(resultado);
				
				int id_jugador;
				id_jugador = atoi(row[0]);
				
				char consulta[300];
				sprintf(consulta,"SELECT id_p FROM Partida,Puntos WHERE Puntos.id_j = %d AND Partida.acabada = 0 AND Partida.id_partida = Puntos.id_p",id_jugador);				
				
				err=mysql_query (conn, consulta);
				if (err!=0) {
					printf ("Error al consultar datos de la base %u %s\n",
							mysql_errno(conn), mysql_error(conn));
					//exit (1);
				}
				
				
				resultado = mysql_store_result(conn);
				row = mysql_fetch_row(resultado);
				while(row != NULL)
				{
					int partida = atoi(row[0]);
					char turno[300];
					MYSQL_ROW row3;
					
					sprintf(turno, "SELECT turno FROM Partida,Auxiliar WHERE Auxiliar.id_partida = %d AND Auxiliar.id_p = Partida.id_partida;",partida);
					
					err=mysql_query (conn, turno);
					if (err!=0) {
						printf ("Error al consultar datos de la base %u %s\n",
								mysql_errno(conn), mysql_error(conn));
						//exit (1);
					}
					
					resultado = mysql_store_result(conn);
					row3 = mysql_fetch_row(resultado);
					
					char respuesta [50];
					sprintf(respuesta, "11/%d/%s", partida, row3[0]); // 11/partida1/torn1/11/partida2/torn2
					write(sock_conn, respuesta, strlen(respuesta));
					row = mysql_fetch_row(resultado);
				}
				break;
					
			}
			case 12: //cliente entra en la partida con id que le llegue
			{
				p = strtok(NULL,"/");
				int id_partida = atoi(p);
				//faltaria poner el como entrar a dicho id_partida
				break;
			}
			case 13: //se actualiza persona eliminada
			{
				p = strtok(NULL,"/");
				int id_elim = atoi(p);
				p = strtok(NULL,"/");
				int id_partida = atoi(p);
				char update [100];
				sprintf(update,"UPDATE Auxiliar SET vivo = 0 WHERE id_j = %d AND id_p = %d;",id_elim,id_partida);
				
				err=mysql_query (conn, update);
				if (err!=0) {
					printf ("Error al consultar datos de la base %u %s\n",
							mysql_errno(conn), mysql_error(conn));
					//exit (1);
				}
				break;
			}
			case 14: // peticio  d'usuaris vius
			{
				p = strtok(NULL,"/");
				int id_partida = atoi(p);
				char consulta[100];
				sprintf(consulta, "SELECT id_j FROM Auxiliar WHERE vivo = 1 AND id_p = %d;",id_partida);
				
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
				else{
					while (row != NULL)
					{
						
						strcat(respuesta, row[0]);
						strcat(respuesta,"/");
						
						row = mysql_fetch_row(resultado);
					}
				}
			
					
				//mysql_close (conn);
				//exit(0);
				
				break;
			}
			case 15: // assignació nou torn
			{
				p = strtok(NULL,"/");
				int id_partida = atoi(p);
				p = strtok(NULL,"/");
				int id_jug = atoi(p);
				char update[100];
				sprintf(update, "UPDATE Auxiliar SET turno = %d WHERE id_p = %d;",id_jug,id_partida);
				err=mysql_query (conn, update);
				if (err!=0) {
					printf ("Error al consultar datos de la base %u %s\n",
							mysql_errno(conn), mysql_error(conn));
					//exit (1);
				}
				char consulta[100];
				sprintf(consulta, "SELECT port FROM Conectados WHERE id_j = %d;",id_jug);
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
				{
					char respuesta [100];
					// enviar notificació de torn a tothom fent un for per a tots els sockets
				}
					
				//mysql_close (conn);
				//exit(0);
				break;
			
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
	serv_adr.sin_port = htons(50063);
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

