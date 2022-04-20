--
-- File generated with SQLiteStudio v3.3.3 on mar. abr. 19 17:59:47 2022
--
-- Text encoding used: System
--
PRAGMA foreign_keys = off;
BEGIN TRANSACTION;

-- Table: empleado
DROP TABLE IF EXISTS empleado;

CREATE TABLE empleado (
    id               INTEGER      PRIMARY KEY AUTOINCREMENT
                                  UNIQUE
                                  NOT NULL,
    primer_nombre    VARCHAR (30) NOT NULL,
    segundo_nombre   VARCHAR (30),
    primer_apellido  VARCHAR (30) NOT NULL,
    segundo_apellido VARCHAR (30) NOT NULL,
    fecha_nacimiento DATE         NOT NULL,
    activo           BOOLEAN      NOT NULL
                                  DEFAULT (true) 
);


-- Table: gerente
DROP TABLE IF EXISTS gerente;

CREATE TABLE gerente (
    id                  INTEGER      PRIMARY KEY AUTOINCREMENT
                                     UNIQUE
                                     NOT NULL,
    primer_nombre       VARCHAR (30) NOT NULL,
    segundo_nombre      VARCHAR (30),
    primer_apellido     VARCHAR (30) NOT NULL,
    segundo_apellido    VARCHAR (30) NOT NULL,
    fecha_nacimiento    DATE         NOT NULL,
    fecha_incorporacion DATE         NOT NULL,
    ultimas_vacaciones  DATE         NOT NULL
);


-- Table: pagos
DROP TABLE IF EXISTS pagos;

CREATE TABLE pagos (
    id         INTEGER         PRIMARY KEY AUTOINCREMENT
                               UNIQUE
                               NOT NULL,
    usuario_id INTEGER         REFERENCES usuario (id) ON DELETE NO ACTION
                                                       ON UPDATE NO ACTION
                               NOT NULL,
    persona_id INTEGER         REFERENCES persona (id) ON DELETE NO ACTION
                                                       ON UPDATE NO ACTION
                               NOT NULL,
    cantidad   DECIMAL (30, 2) NOT NULL,
    fecha      DATETIME        NOT NULL
);


-- Table: persona
DROP TABLE IF EXISTS persona;

CREATE TABLE persona (
    id               INTEGER      PRIMARY KEY AUTOINCREMENT
                                  UNIQUE
                                  NOT NULL,
    primer_nombre    VARCHAR (30) NOT NULL,
    segundo_nombre   VARCHAR (30),
    primer_apellido  VARCHAR (30) NOT NULL,
    segundo_apellido VARCHAR (30) NOT NULL,
    fecha_nacimiento DATE         NOT NULL
);


-- Table: prestamo
DROP TABLE IF EXISTS prestamo;

CREATE TABLE prestamo (
    id                INTEGER         PRIMARY KEY AUTOINCREMENT
                                      UNIQUE
                                      NOT NULL,
    usuario_id        INTEGER         REFERENCES usuario (id) ON DELETE NO ACTION
                                                              ON UPDATE NO ACTION
                                      NOT NULL,
    empleado_id       INTEGER         REFERENCES empleado (id) ON DELETE NO ACTION
                                                               ON UPDATE NO ACTION,
    gerente_id        INTEGER         REFERENCES gerente (id) ON DELETE NO ACTION
                                                              ON UPDATE NO ACTION,
    meses             INT (2)         NOT NULL,
    cantidad          DECIMAL (30, 2) NOT NULL,
    pago_mes          DECIMAL (30, 2) NOT NULL,
    fecha_solicitud   DATE            NOT NULL,
    fecha_aprobacion  DATE,
    fecha_liquidacion DATE,
    activo            BOOLEAN         NOT NULL
                                      DEFAULT (true) 
);


-- Table: solicitud
DROP TABLE IF EXISTS solicitud;

CREATE TABLE solicitud (
    id         INTEGER PRIMARY KEY AUTOINCREMENT
                       UNIQUE
                       NOT NULL,
    persona_id INTEGER REFERENCES persona (id) ON DELETE NO ACTION
                                               ON UPDATE NO ACTION
                       NOT NULL,
    usuario_id INTEGER REFERENCES persona (id) ON DELETE NO ACTION
                                               ON UPDATE NO ACTION
                       NOT NULL,
    gerente_id INTEGER REFERENCES gerente (id) ON DELETE NO ACTION
                                               ON UPDATE NO ACTION
                       NOT NULL,
    estatus    INT (1) NOT NULL
);


-- Table: usuario
DROP TABLE IF EXISTS usuario;

CREATE TABLE usuario (
    id             INTEGER         PRIMARY KEY
                                   UNIQUE
                                   NOT NULL,
    persona_id     INTEGER         REFERENCES persona (id) ON DELETE NO ACTION
                                                           ON UPDATE NO ACTION
                                   UNIQUE
                                   NOT NULL,
    nombre_usuario VARCHAR (50)    UNIQUE
                                   NOT NULL,
    password       TEXT            NOT NULL,
    saldo          DECIMAL (30, 2) NOT NULL
                                   DEFAULT (10000),
    activo         BOOLEAN         DEFAULT (true) 
                                   NOT NULL,
    intentos       INT (1)         NOT NULL
                                   DEFAULT (0) 
);


COMMIT TRANSACTION;
PRAGMA foreign_keys = on;
