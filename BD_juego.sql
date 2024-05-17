CREATE DATABASE juego;
USE juego;
CREATE TABLE Jugador (id_jugador INTEGER PRIMARY KEY NOT NULL, username VARCHAR (16) NOT NULL, password VARCHAR (8) NOT NULL)ENGINE = InnoDB;
CREATE TABLE Partida (id_partida INTEGER PRIMARY KEY NOT NULL, acabada INTEGER DEFAULT 0, inicio DATETIME NOT NULL, final DATETIME NOT NULL, duracion DATETIME NOT NULL, ganador VARCHAR (16) NOT NULL)ENGINE = InnoDB;
CREATE TABLE Puntos (id_p INTEGER NOT NULL, id_j INTEGER NOT NULL , puntos INTEGER NOT NULL, FOREIGN KEY (id_p) REFERENCES Partida(id_partida), FOREIGN KEY (id_j) REFERENCES Jugador(id_jugador))ENGINE = InnoDB;
CREATE TABLE Conectados (id_j INTEGER NOT NULL, nickname VARCHAR (16) NOT NULL, port INTEGER NOT NULL, FOREIGN KEY (id_j) REFERENCES Jugador (id_jugador), FOREIGN KEY (nickname) REFERENCES Jugador (username))ENGINE = InnoDB;
CREATE TABLE Auxiliar (id_p INTEGER NOT NULL, id_j INTEGER NOT NULL, turno INTEGER NOT NULL, lastcard INTEGER NOT NULL, FOREIGN KEY (id_p) REFERENCES Partida(id_partida), FOREIGN KEY (id_j) REFERENCES Jugador(id_jugador))ENGINE = InnoDB;
CREATE TABLE Mazo (id_p INTEGER NOT NULL, id_j INTEGER NOT NULL , cartas VARCHAR (100) NOT NULL, FOREIGN KEY (id_p) REFERENCES Partida(id_partida), FOREIGN KEY (id_j) REFERENCES Jugador(id_jugador))ENGINE = InnoDB;
