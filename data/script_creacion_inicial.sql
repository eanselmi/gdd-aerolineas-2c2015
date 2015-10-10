-----------------------------------------------------------------------
-- MASTER TABLE
USE GD2C2015;

-----------------------------------------------------------------------
-- SCHEMA

IF NOT EXISTS (
    SELECT schema_name 
    FROM information_schema.schemata 
    WHERE schema_name = 'AERO' 
    )

BEGIN
    EXEC sp_executesql N'CREATE SCHEMA AERO;';
END

-----------------------------------------------------------------------
-- DROP TABLES

IF OBJECT_ID('AERO.cancelaciones') IS NOT NULL
BEGIN
    DROP TABLE AERO.cancelaciones;
END;

IF OBJECT_ID('AERO.canjes') IS NOT NULL
BEGIN
    DROP TABLE AERO.canjes;
END;

IF OBJECT_ID('AERO.productos') IS NOT NULL
BEGIN
    DROP TABLE AERO.productos;
END;

IF OBJECT_ID('AERO.aeronaves_por_periodos') IS NOT NULL
BEGIN
    DROP TABLE AERO.aeronaves_por_periodos;
END;

IF OBJECT_ID('AERO.periodos_de_inactividad') IS NOT NULL
BEGIN
    DROP TABLE AERO.periodos_de_inactividad;
END;

IF OBJECT_ID('AERO.funcionalidades_por_rol') IS NOT NULL
BEGIN
    DROP TABLE AERO.funcionalidades_por_rol;
END;

IF OBJECT_ID('AERO.funcionalidades') IS NOT NULL
BEGIN
    DROP TABLE AERO.funcionalidades;
END;

IF OBJECT_ID('AERO.usuarios') IS NOT NULL
BEGIN
    DROP TABLE AERO.usuarios;
END;

IF OBJECT_ID('AERO.tarjetas_de_credito') IS NOT NULL
BEGIN
    DROP TABLE AERO.tarjetas_de_credito;
END;

IF OBJECT_ID('AERO.tipos_tarjeta') IS NOT NULL
BEGIN
    DROP TABLE AERO.tipos_tarjeta;
END;

IF OBJECT_ID('AERO.paquetes') IS NOT NULL
BEGIN
    DROP TABLE AERO.paquetes;
END;

IF OBJECT_ID('AERO.encomiendas') IS NOT NULL
BEGIN
    DROP TABLE AERO.encomiendas;
END;

IF OBJECT_ID('AERO.vuelos') IS NOT NULL
BEGIN
    DROP TABLE AERO.vuelos;
END;

IF OBJECT_ID('AERO.rutas') IS NOT NULL
BEGIN
    DROP TABLE AERO.rutas;
END;

IF OBJECT_ID('AERO.aeropuertos') IS NOT NULL
BEGIN
    DROP TABLE AERO.aeropuertos;
END;

IF OBJECT_ID('AERO.ciudades') IS NOT NULL
BEGIN
    DROP TABLE AERO.ciudades;
END;

IF OBJECT_ID('AERO.pasajes') IS NOT NULL
BEGIN
    DROP TABLE AERO.pasajes;
END;

IF OBJECT_ID('AERO.butacas') IS NOT NULL
BEGIN
    DROP TABLE AERO.butacas;
END;

IF OBJECT_ID('AERO.aeronaves') IS NOT NULL
BEGIN
    DROP TABLE AERO.aeronaves;
END;

IF OBJECT_ID('AERO.tipos_de_servicio') IS NOT NULL
BEGIN
    DROP TABLE AERO.tipos_de_servicio;
END;

IF OBJECT_ID('AERO.fabricantes') IS NOT NULL
BEGIN
    DROP TABLE AERO.fabricantes;
END;

IF OBJECT_ID('AERO.boletos_de_compra') IS NOT NULL
BEGIN
    DROP TABLE AERO.boletos_de_compra;
END;

IF OBJECT_ID('AERO.clientes') IS NOT NULL
BEGIN
    DROP TABLE AERO.clientes;
END;

IF OBJECT_ID('AERO.roles') IS NOT NULL
BEGIN
    DROP TABLE AERO.roles;
END;

-----------------------------------------------------------------------
-- TABLES

CREATE TABLE AERO.aeronaves (
    ID  INT   IDENTITY(1,1)    PRIMARY KEY,
    MATRICULA        NVARCHAR(255)    UNIQUE NOT NULL,
    MODELO        NVARCHAR(255) DEFAULT 'modelo',
    KG_DISPONIBLES    NUMERIC(18,0)    NOT NULL,
    FABRICANTE_ID    INT            NOT NULL,
    TIPO_SERVICIO_ID    INT            NOT NULL,
    BAJA            NVARCHAR(255),
    FECHA_ALTA      DATETIME        NOT NULL,
    CANT_BUTACAS    INT            NOT NULL,
    FECHA_BAJA    DATETIME,
    CONSTRAINT aeronaves_CK001 CHECK (BAJA IN ('DEFINITIVA', 'POR_PERIODO'))
)

CREATE TABLE AERO.fabricantes (
    ID  INT  IDENTITY(1,1)    PRIMARY KEY,
    NOMBRE        NVARCHAR(255)    NOT NULL
)

CREATE TABLE AERO.tipos_de_servicio (
    ID INT   IDENTITY(1,1)    PRIMARY KEY,
    NOMBRE        NVARCHAR(255)    NOT NULL
)

CREATE TABLE AERO.butacas (
    ID  INT     IDENTITY(1,1)    PRIMARY KEY,
    NUMERO        NUMERIC(18,0)    NOT NULL,
    TIPO            NVARCHAR(255),
    PISO            NUMERIC(18,0),
    AERONAVE_ID    INT            NOT NULL,
    ESTADO        NVARCHAR(255) DEFAULT 'LIBRE',
    CONSTRAINT butacas_CK001 CHECK (TIPO IN ('VENTANILLA', 'PASILLO')),
    CONSTRAINT butacas_CK002 CHECK (ESTADO IN ('LIBRE', 'COMPRADO')),
	CONSTRAINT butacas_CK003 CHECK (PISO IN (1,2))
)

CREATE TABLE AERO.pasajes (
    ID    INT    IDENTITY(1,1)    PRIMARY KEY,
    PRECIO        NUMERIC(18,2)		NOT NULL,
    CODIGO        NUMERIC(18,0)    UNIQUE NOT NULL,
    BUTACA_ID        INT            NOT NULL,
    CLIENTE_ID        INT            NOT NULL,
    BOLETO_COMPRA_ID INT             NOT NULL
)

CREATE TABLE AERO.clientes (
    ID   INT     IDENTITY(1,1)    PRIMARY KEY,
    ROL_ID        INT            NOT NULL,
    NOMBRE        NVARCHAR(255)    NOT NULL,
    APELLIDO        NVARCHAR(255),
    DNI            NUMERIC(18,0) NOT NULL,
    DIRECCION        NVARCHAR(255),
    TELEFONO        NUMERIC(18,0),
    MAIL            NVARCHAR(255),
    FECHA_NACIMIENTO DATETIME
)

CREATE TABLE AERO.boletos_de_compra (
    ID INT IDENTITY(1,1)    PRIMARY KEY,
    CODIGO_COMPRA    NUMERIC(18,0)    NOT NULL,
    FECHA_COMPRA    DATETIME          NOT NULL,
    PRECIO_COMPRA    NUMERIC(18,2)	NOT NULL,
    TIPO_COMPRA    NVARCHAR(255),
    CLIENTE_ID        INT            NOT NULL,
	MILLAS 			  INT,
    CONSTRAINT boletos_de_compra_CK001 CHECK (TIPO_COMPRA IN ('EFECTIVO', 'TARJETA'))
)

CREATE TABLE AERO.roles (
    ID    INT    IDENTITY(1,1)    PRIMARY KEY,
	NOMBRE 	NVARCHAR(255)		NOT NULL,
	ACTIVO	INT DEFAULT 1,
	CONSTRAINT roles_CK001 CHECK (ACTIVO IN (0,1))
)

CREATE TABLE AERO.funcionalidades (
    ID INT IDENTITY(1,1)    PRIMARY KEY,
    DETALLES        NVARCHAR(255) NOT NULL
)

CREATE TABLE AERO.funcionalidades_por_rol (
	ROL_ID    INT,
	FUNCIONALIDAD_ID INT, 
	PRIMARY KEY(ROL_ID,FUNCIONALIDAD_ID)
)
CREATE TABLE AERO.usuarios (
    ID INT IDENTITY(1,1)    PRIMARY KEY,
    ROL_ID        INT            NOT NULL ,
    USERNAME        NVARCHAR(255)    UNIQUE NOT NULL,
    PASSWORD        NVARCHAR(255)		NOT NULL,
	FECHA_CREACION DATETIME				NOT NULL,
	ULTIMA_MODIFICACION DATETIME		NOT NULL,
	INTENTOS_LOGIN INT NOT NULL DEFAULT 0,
	ACTIVO INT,
	CONSTRAINT usuarios_CK001 CHECK (ACTIVO IN (0,1))
)
CREATE TABLE AERO.productos (
    ID  INT  IDENTITY(1,1)    PRIMARY KEY,
    NOMBRE        NVARCHAR(255)    UNIQUE,
    MILLAS_REQUERIDAS INT  NOT NULL,
    STOCK        INT      NOT NULL    
)

CREATE TABLE AERO.periodos_de_inactividad (
    ID    INT     IDENTITY(1,1)    PRIMARY KEY,
    DESDE        DATETIME			NOT NULL,
    HASTA        DATETIME			NOT NULL
)

CREATE TABLE AERO.aeronaves_por_periodos (
    AERONAVE_ID INT,
    PERIODO_ID  INT,
    PRIMARY KEY(AERONAVE_ID,PERIODO_ID)
)

CREATE TABLE AERO.aeropuertos (
    ID  INT    IDENTITY(1,1)    PRIMARY KEY,
    NOMBRE        NVARCHAR(255)     NOT NULL,
    CIUDAD_ID        INT             NOT NULL
)

CREATE TABLE AERO.vuelos (
    ID     INT    IDENTITY(1,1)     PRIMARY KEY,
    FECHA_SALIDA     DATETIME		NOT NULL,
    FECHA_LLEGADA     DATETIME,
    FECHA_LLEGADA_ESTIMADA DATETIME NOT NULL,
    AERONAVE_ID     INT            NOT NULL,
    RUTA_ID         INT            NOT NULL
)

CREATE TABLE AERO.rutas (
    ID     INT     IDENTITY(1,1)     PRIMARY KEY,
    CODIGO         NUMERIC(18,0)    NOT NULL,
    PRECIO_BASE_KG     NUMERIC(18,2)  NOT NULL,
    PRECIO_BASE_PASAJE NUMERIC(18,2) NOT NULL,
    ORIGEN_ID        INT            NOT NULL,
    DESTINO_ID        INT            NOT NULL,
	TIPO_SERVICIO_ID	INT	NOT NULL
)

CREATE TABLE AERO.encomiendas (
    ID  INT    IDENTITY(1,1)    PRIMARY KEY,
    BOLETO_COMPRA_ID INT		NOT NULL,
    VUELO_ID         INT		NOT NULL
)

CREATE TABLE AERO.ciudades (
    ID     INT     IDENTITY(1,1)     PRIMARY KEY,
    NOMBRE         NVARCHAR(255)    NOT NULL
)

CREATE TABLE AERO.paquetes(
    ID   INT  IDENTITY(1,1)     PRIMARY KEY,
    CODIGO         NUMERIC(18,0)    UNIQUE NOT NULL,
    PRECIO         NUMERIC(18,2)	NOT NULL,
    KG             NUMERIC(18,0)	NOT NULL,
    ENCOMIENDA_ID     INT		NOT NULL
)

CREATE TABLE AERO.canjes (
    ID     INT    IDENTITY(1,1)     PRIMARY KEY,
    CLIENTE_ID         INT             NOT NULL,
    PRODUCTO_ID     INT             NOT NULL,
    CANTIDAD         INT			DEFAULT 1,
    FECHA_CANJE         DATETIME	NOT NULL
)

CREATE TABLE AERO.tarjetas_de_credito (
    ID   INT   IDENTITY(1,1)     PRIMARY KEY,
    TIPO_TARJETA_ID    INT NOT NULL,
    NUMERO         NUMERIC(18,0)    UNIQUE NOT NULL,
    FECHA_VTO         DATETIME        NOT NULL,
    CLIENTE_ID         INT            NOT NULL
)

CREATE TABLE AERO.tipos_tarjeta (
    ID   INT   IDENTITY(1,1)     PRIMARY KEY,
    NOMBRE    NVARCHAR(255) NOT NULL,
	CUOTAS INT DEFAULT 0   
)


CREATE TABLE AERO.cancelaciones (
    ID   INT   IDENTITY(1,1)     PRIMARY KEY,
    FECHA_DEVOLUCION DATETIME		NOT NULL,
    BOLETO_COMPRA_ID INT            NOT NULL,
    MOTIVO         NVARCHAR(255)   NOT NULL
)

-----------------------------------------------------------------------
-- FOREIGN KEYS && INDEXES

ALTER TABLE AERO.tarjetas_de_credito
ADD CONSTRAINT TARJETAS_FK01 FOREIGN KEY
(TIPO_TARJETA_ID) REFERENCES AERO.tipos_tarjeta (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'TARJ_TIPO_TARJ' AND object_id = OBJECT_ID('AERO.tarjetas_de_credito'))
    BEGIN
       CREATE INDEX TARJ_TIPO_TARJ ON AERO.tarjetas_de_credito (TIPO_TARJETA_ID);
    END


ALTER TABLE AERO.aeronaves
ADD CONSTRAINT AERONAVES_FK01 FOREIGN KEY
(FABRICANTE_ID) REFERENCES AERO.fabricantes (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'AERO_FABRIC' AND object_id = OBJECT_ID('AERO.aeronaves'))
    BEGIN
       CREATE INDEX AERO_FABRIC ON AERO.aeronaves (FABRICANTE_ID);
    END

ALTER TABLE AERO.aeronaves
ADD CONSTRAINT AERONAVES_FK02 FOREIGN KEY
(TIPO_SERVICIO_ID) REFERENCES AERO.tipos_de_servicio (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'AERO_TIPO_SERV' AND object_id = OBJECT_ID('AERO.aeronaves'))
    BEGIN
       CREATE INDEX AERO_TIPO_SERV ON AERO.aeronaves (TIPO_SERVICIO_ID);
    END

ALTER TABLE AERO.butacas
ADD CONSTRAINT BUTACAS_FK01 FOREIGN KEY
(AERONAVE_ID) REFERENCES AERO.aeronaves (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'BUTAC_AERO' AND object_id = OBJECT_ID('AERO.butacas'))
    BEGIN
       CREATE INDEX BUTAC_AERO ON AERO.butacas (AERONAVE_ID);
    END

ALTER TABLE AERO.pasajes
ADD CONSTRAINT PASAJES_FK01 FOREIGN KEY
(BUTACA_ID) REFERENCES AERO.butacas (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'PASAJ_BUTAC' AND object_id = OBJECT_ID('AERO.pasajes'))
    BEGIN
       CREATE INDEX PASAJ_BUTAC ON AERO.pasajes (BUTACA_ID);
    END

ALTER TABLE AERO.pasajes
ADD CONSTRAINT PASAJES_FK02 FOREIGN KEY
(CLIENTE_ID) REFERENCES AERO.clientes (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'PASAJ_CLIENT' AND object_id = OBJECT_ID('AERO.pasajes'))
    BEGIN
       CREATE INDEX PASAJ_CLIENT ON AERO.pasajes (CLIENTE_ID);
    END

ALTER TABLE AERO.pasajes
ADD CONSTRAINT PASAJES_FK03 FOREIGN KEY
(BOLETO_COMPRA_ID) REFERENCES AERO.boletos_de_compra (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'PASAJ_BOL_COMP' AND object_id = OBJECT_ID('AERO.pasajes'))
    BEGIN
       CREATE INDEX PASAJ_BOL_COMP ON AERO.pasajes (BOLETO_COMPRA_ID);
    END

ALTER TABLE AERO.clientes
ADD CONSTRAINT CLIENTES_FK01 FOREIGN KEY
(ROL_ID) REFERENCES AERO.roles (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'CLIENT_ROLES' AND object_id = OBJECT_ID('AERO.clientes'))
    BEGIN
       CREATE INDEX CLIENT_ROLES ON AERO.clientes (ROL_ID);
    END

ALTER TABLE AERO.boletos_de_compra
ADD CONSTRAINT BOLETOS_DE_COMPRA_FK01 FOREIGN KEY
(CLIENTE_ID) REFERENCES AERO.clientes (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'FKI_BOL_COMP_CLIENT' AND object_id = OBJECT_ID('AERO.boletos_de_compra'))
    BEGIN
       CREATE INDEX FKI_BOL_COMP_CLIENT ON AERO.boletos_de_compra (CLIENTE_ID);
    END

ALTER TABLE AERO.funcionalidades_por_rol
ADD CONSTRAINT FUNCIONALIDADES_POR_ROL_FK01 FOREIGN KEY
(ROL_ID) REFERENCES AERO.roles (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'FKI_FUNCXROL_ROL' AND object_id = OBJECT_ID('AERO.funcionalidades_por_rol'))
    BEGIN
       CREATE INDEX FKI_FUNCXROL_ROL ON AERO.funcionalidades_por_rol (ROL_ID);
    END

ALTER TABLE AERO.funcionalidades_por_rol
ADD CONSTRAINT FUNCIONALIDADES_POR_ROL_FK02 FOREIGN KEY
(FUNCIONALIDAD_ID) REFERENCES AERO.funcionalidades (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'FKI_FUNCXROL_FUNC' AND object_id = OBJECT_ID('AERO.funcionalidades_por_rol'))
    BEGIN
       CREATE INDEX FKI_FUNCXROL_FUNC ON AERO.funcionalidades_por_rol (FUNCIONALIDAD_ID);
    END

ALTER TABLE AERO.usuarios
ADD CONSTRAINT USUARIOS_FK01 FOREIGN KEY
(ROL_ID) REFERENCES AERO.roles (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'FKI_USR_ROL' AND object_id = OBJECT_ID('AERO.usuarios'))
    BEGIN
       CREATE INDEX FKI_USR_ROL ON AERO.usuarios (ROL_ID);
    END

ALTER TABLE AERO.aeronaves_por_periodos
ADD CONSTRAINT AERONAVES_POR_PERIODOS_FK01 FOREIGN KEY
(AERONAVE_ID) REFERENCES AERO.aeronaves (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'FKI_AEROXPER_AERO' AND object_id = OBJECT_ID('AERO.aeronaves_por_periodos'))
    BEGIN
       CREATE INDEX FKI_AEROXPER_AERO ON AERO.aeronaves_por_periodos (AERONAVE_ID);
    END

ALTER TABLE AERO.aeronaves_por_periodos
ADD CONSTRAINT AERONAVES_POR_PERIODOS_FK02 FOREIGN KEY
(PERIODO_ID) REFERENCES AERO.periodos_de_inactividad (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'FKI_AEROXPER_PERXINAC' AND object_id = OBJECT_ID('AERO.aeronaves_por_periodos'))
    BEGIN
       CREATE INDEX FKI_AEROXPER_PERXINAC ON AERO.aeronaves_por_periodos (PERIODO_ID);
    END

ALTER TABLE AERO.aeropuertos
ADD CONSTRAINT AEROPUERTOS_FK01 FOREIGN KEY
(CIUDAD_ID) REFERENCES AERO.ciudades (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'FKI_AERO_CIUD' AND object_id = OBJECT_ID('AERO.aeropuertos'))
    BEGIN
       CREATE INDEX FKI_AERO_CIUD ON AERO.aeropuertos (CIUDAD_ID);
    END

ALTER TABLE AERO.vuelos
ADD CONSTRAINT VUELOS_FK01 FOREIGN KEY
(AERONAVE_ID) REFERENCES AERO.aeronaves (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'FKI_VUEL_AERO' AND object_id = OBJECT_ID('AERO.vuelos'))
    BEGIN
       CREATE INDEX FKI_VUEL_AERO ON AERO.vuelos (AERONAVE_ID);
    END

ALTER TABLE AERO.vuelos
ADD CONSTRAINT VUELOS_FK02 FOREIGN KEY
(RUTA_ID) REFERENCES AERO.rutas (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'FKI_VUEL_RUT' AND object_id = OBJECT_ID('AERO.vuelos'))
    BEGIN
       CREATE INDEX FKI_VUEL_RUT ON AERO.vuelos (RUTA_ID);
    END

ALTER TABLE AERO.rutas
ADD CONSTRAINT RUTAS_FK02 FOREIGN KEY
(ORIGEN_ID) REFERENCES AERO.aeropuertos (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'FKI_RUT_AERO' AND object_id = OBJECT_ID('AERO.rutas'))
    BEGIN
       CREATE INDEX FKI_RUT_AERO ON AERO.rutas (ORIGEN_ID);
    END

ALTER TABLE AERO.encomiendas
ADD CONSTRAINT ENCOMIENDAS_FK01 FOREIGN KEY
(BOLETO_COMPRA_ID) REFERENCES AERO.boletos_de_compra (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'FKI_ENCO_BOLDECOMP' AND object_id = OBJECT_ID('AERO.encomiendas'))
    BEGIN
       CREATE INDEX FKI_ENCO_BOLDECOMP ON AERO.encomiendas (BOLETO_COMPRA_ID);
    END

ALTER TABLE AERO.encomiendas
ADD CONSTRAINT ENCOMIENDAS_FK02 FOREIGN KEY
(VUELO_ID) REFERENCES AERO.vuelos (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'FKI_ENCO_VUEL' AND object_id = OBJECT_ID('AERO.encomiendas'))
    BEGIN
       CREATE INDEX FKI_ENCO_VUEL ON AERO.encomiendas (VUELO_ID);
    END

ALTER TABLE AERO.paquetes
ADD CONSTRAINT PAQUETES_FK01 FOREIGN KEY
(ENCOMIENDA_ID) REFERENCES AERO.encomiendas (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'FKI_PAQ_ENCO' AND object_id = OBJECT_ID('AERO.paquetes'))
    BEGIN
       CREATE INDEX FKI_PAQ_ENCO ON AERO.paquetes (ENCOMIENDA_ID);
    END

ALTER TABLE AERO.canjes
ADD CONSTRAINT CANJES_FK01 FOREIGN KEY
(PRODUCTO_ID) REFERENCES AERO.productos (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'FKI_CANJ_PROD' AND object_id = OBJECT_ID('AERO.canjes'))
    BEGIN
       CREATE INDEX FKI_CANJ_PROD ON AERO.canjes (PRODUCTO_ID);
    END

ALTER TABLE AERO.canjes
ADD CONSTRAINT CANJES_FK02 FOREIGN KEY
(CLIENTE_ID) REFERENCES AERO.clientes (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'FKI_CANJ_CLIE' AND object_id = OBJECT_ID('AERO.canjes'))
    BEGIN
       CREATE INDEX FKI_CANJ_CLIE ON AERO.canjes (CLIENTE_ID);
    END

ALTER TABLE AERO.tarjetas_de_credito
ADD CONSTRAINT TARJETAS_DE_CREDITO_FK01 FOREIGN KEY
(CLIENTE_ID) REFERENCES AERO.clientes (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'FKI_TARJCRED_CLIE' AND object_id = OBJECT_ID('AERO.tarjetas_de_credito'))
    BEGIN
       CREATE INDEX FKI_TARJCRED_CLIE ON AERO.tarjetas_de_credito (CLIENTE_ID);
    END

ALTER TABLE AERO.cancelaciones
ADD CONSTRAINT CANCELACIONES_FK01 FOREIGN KEY
(BOLETO_COMPRA_ID) REFERENCES AERO.boletos_de_compra (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'FKI_CANC_BOLCOMP' AND object_id = OBJECT_ID('AERO.cancelaciones'))
    BEGIN
       CREATE INDEX FKI_CANC_BOLCOMP ON AERO.cancelaciones (BOLETO_COMPRA_ID);
    END

ALTER TABLE AERO.rutas
ADD CONSTRAINT rutas_FK01 FOREIGN KEY
(TIPO_SERVICIO_ID) REFERENCES AERO.tipos_de_servicio (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'FKI_rutas_tipo_servicio' AND object_id = OBJECT_ID('AERO.rutas'))
    BEGIN
       CREATE INDEX FKI_rutas_tipo_servicio ON AERO.rutas (TIPO_SERVICIO_ID);
    END

-----------------------------------------------------------------------
-- INSERTS

INSERT INTO AERO.funcionalidades VALUES
('Consultar Millas'),
('Alta de Cliente'),
('Alta de Aeronave'),
('Alta de Ciudad'),
('Alta de Tarjeta de Crédito'),
('Baja de Aeronave'),
('Baja de Ciudad'),
('Baja de Cliente'),
('Baja de Tarjeta de Crédito'),
('Modificacion de Aeronave'),
('Modificacion de Ciudad'),
('Modificacion de Cliente'),
('Realizar Canje'),
('Alta de Rol'),
('Baja de Rol'),
('Modificacion de Rol'),
('Alta de Ruta'),
('Baja de Ruta'),
('Modificacion de Ruta'),
('Comprar Pasaje/Encomienda'),
('Generar Viaje'),
('Registrar Llegadas'),
('Consultar Listado');

INSERT INTO AERO.roles (nombre, activo) VALUES
('administrador', 1),
('cliente', 1);

INSERT INTO AERO.usuarios  (ROL_ID, USERNAME, PASSWORD, FECHA_CREACION, ULTIMA_MODIFICACION, INTENTOS_LOGIN, ACTIVO) VALUES 
(1, 'admin', 'e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7', GETDATE(), GETDATE(), 0, 1);

INSERT INTO AERO.productos (NOMBRE, MILLAS_REQUERIDAS, STOCK)
VALUES ('Valija', 150, 50),
('Candado', 10, 200),
('Almohada', 45, 100),
('Auto', 10000, 15),
('Calefactor', 500, 150);

INSERT INTO AERO.tipos_tarjeta (NOMBRE, CUOTAS)
VALUES ('VISA', 6),
('MASTERCARD', 12),
('AMEX', 3),
('DINERS', 0);

-----------------------------------------------------------------------
-- TRIGGERS


-----------------------------------------------------------------------
-- PROCEDURES && FUNCTIONS

--DROP

IF OBJECT_ID('AERO.addFuncionalidad') IS NOT NULL
BEGIN
	DROP PROCEDURE AERO.addFuncionalidad;
END;
GO

IF OBJECT_ID('AERO.UpdateIntento') IS NOT NULL
BEGIN
	DROP PROCEDURE AERO.UpdateIntento;
END;
GO

IF OBJECT_ID('AERO.agregarRol') IS NOT NULL
BEGIN
	DROP PROCEDURE AERO.agregarRol;
END;
GO

IF OBJECT_ID('AERO.agregarCliente') IS NOT NULL
BEGIN
	DROP PROCEDURE AERO.agregarCliente;
END;
GO

IF OBJECT_ID('AERO.agregarAeronave') IS NOT NULL
BEGIN
	DROP PROCEDURE AERO.agregarAeronave;
END;
GO

IF OBJECT_ID('AERO.updateAeronave') IS NOT NULL
BEGIN
	DROP PROCEDURE AERO.updateAeronave;
END;
GO

IF OBJECT_ID('AERO.corrigeMail') IS NOT NULL
    DROP FUNCTION AERO.corrigeMail
GO

IF OBJECT_ID('AERO.bajaAeronave') IS NOT NULL
BEGIN
	DROP PROCEDURE AERO.bajaAeronave;
END;
GO

--CREATE
CREATE PROCEDURE AERO.addFuncionalidad(@rol nvarchar(255), @func nvarchar(255)) AS
BEGIN
	INSERT INTO AERO.funcionalidades_por_rol (ROL_ID, FUNCIONALIDAD_ID)
		VALUES ((SELECT id FROM AERO.roles WHERE NOMBRE = @rol),
		        (SELECT id FROM AERO.funcionalidades WHERE DETALLES = @func))
END
GO


CREATE PROCEDURE AERO.UpdateIntento(@nombre varchar(25), @exitoso int)
AS BEGIN
	IF(@exitoso = 1)
		BEGIN
			UPDATE AERO.usuarios  SET INTENTOS_LOGIN=0 WHERE USERNAME=@nombre
		END
	ELSE
		BEGIN
			DECLARE @cant_Intentos int
			SELECT @cant_Intentos = intentos_login FROM AERO.usuarios WHERE USERNAME=@nombre
			IF( @cant_Intentos = 2)
				BEGIN
					UPDATE AERO.usuarios  SET ACTIVO=0, INTENTOS_LOGIN=0 WHERE USERNAME=@nombre
				END
			ELSE
				BEGIN
					UPDATE AERO.usuarios set INTENTOS_LOGIN=@cant_Intentos+1 WHERE USERNAME=@nombre
				END
		END
END
GO

CREATE PROCEDURE AERO.agregarRol(@nombreRol nvarchar(255), @ret int output)
AS BEGIN
	INSERT INTO AERO.Roles (NOMBRE,ACTIVO) VALUES (@nombreRol, 1)
	SET @ret = SCOPE_IDENTITY()
END
GO

CREATE PROCEDURE AERO.agregarCliente(@rol_id INT, @nombreCliente nvarchar(255), @apellidoCliente nvarchar(255), 
	@documentoCliente numeric(18,0), @direccion nvarchar(255), 
	@telefono numeric(18,0), @mail nvarchar(255), @fechaNac datetime,
	@ret INT output)
AS BEGIN
	INSERT INTO AERO.Clientes (rol_id, nombre, apellido, dni, direccion,telefono,
	mail,FECHA_NACIMIENTO)  
	VALUES (@rol_id, @nombreCliente, @apellidoCliente, 
	@documentoCliente, @direccion, 
	@telefono, @mail, @fechaNac)
	SET @ret = SCOPE_IDENTITY()
END
GO

CREATE PROCEDURE AERO.agregarAeronave(@matricula nvarchar(255), @modelo nvarchar(255), @kg_disponibles numeric(18,0), 
@fabricante nvarchar(255), @tipo_servicio nvarchar(255), @alta datetime, @cantButacas int)
AS BEGIN
	INSERT INTO AERO.aeronaves(MATRICULA, MODELO, KG_DISPONIBLES, FABRICANTE_ID, TIPO_SERVICIO_ID, FECHA_ALTA, CANT_BUTACAS)
	VALUES (@matricula, @modelo, @kg_disponibles, @fabricante, @tipo_servicio, @alta, @cantButacas)
END
GO

CREATE PROCEDURE AERO.updateAeronave(@id  INT, @fechaInicio DATETIME, @fechaFin DATETIME)
AS BEGIN
DECLARE @IDPERIODO INT
SELECT @IDPERIODO= ID FROM AERO.periodos_de_inactividad WHERE DESDE=@fechaInicio AND HASTA=@fechaFin
	IF(@IDPERIODO IS NULL)
		BEGIN
			INSERT INTO AERO.periodos_de_inactividad VALUES(@fechaInicio,@fechaFin) 
			SET @IDPERIODO=SCOPE_IDENTITY()
		END
INSERT INTO  AERO.aeronaves_por_periodos VALUES(@ID,@IDPERIODO)
UPDATE AERO.aeronaves SET BAJA='POR_PERIODO' WHERE ID=@id; 
END
GO

CREATE PROCEDURE AERO.bajaAeronave(@id  INT)
AS BEGIN
UPDATE AERO.aeronaves SET BAJA='DEFINITIVA',
FECHA_BAJA= CURRENT_TIMESTAMP
WHERE ID=@id;
END
GO


CREATE FUNCTION AERO.corrigeMail (@s NVARCHAR (255)) 
RETURNS NVARCHAR(255)
AS
BEGIN
   IF @s is null
      RETURN null
   
   DECLARE @s2 NVARCHAR(255)
   SET @s2 = ''
   DECLARE @l int
   SET @l = len(@s)
   DECLARE @p int
   SET @p = 1
   WHILE @p <= @l
   BEGIN
      DECLARE @c int;
      SET @c = ascii(substring(@s, @p, 1))
      set @c = LOWER(@c)
      
      --si es espacio todo a la izquierda se descarta
      if (@c = 32) set @s2 = '';
      
	  if @c = ascii('ä') set @c = ascii('a')
	  if @c = ascii('ë') set @c = ascii('e')
	  if @c = ascii('ï') set @c = ascii('i')
	  if @c = ascii('ö') set @c = ascii('o')
      if @c = ascii('ü') set @c = ascii('u')
	  if @c = ascii('á') set @c = ascii('a')
      if @c = ascii('é') set @c = ascii('e')
	  if @c = ascii('í') set @c = ascii('i')
	  if @c = ascii('ó') set @c = ascii('o')
	  if @c = ascii('ú') set @c = ascii('u')
	  if @c = ascii('à') set @c = ascii('a')
      if @c = ascii('è') set @c = ascii('e')
	  if @c = ascii('ì') set @c = ascii('i')
	  if @c = ascii('ò') set @c = ascii('o')
	  if @c = ascii('ù') set @c = ascii('u')
	  if @c = ascii('ñ') set @c = ascii('n')

      if (@c between 48 and 57 or @c = 64 or @c = 45 or @c = 46 
      or @c = 95 or @c between 65 and 90 or @c between 97 and 122)
		
		SET @s2 = @s2 + char(@c)
      
      SET @p = @p + 1
   END
   IF len(@s2) = 0
      return null
   return @s2
END
GO

-----------------------------------------------------------------------
-- MIGRACION

INSERT INTO AERO.fabricantes (NOMBRE)
SELECT DISTINCT Aeronave_Fabricante
FROM gd_esquema.Maestra
WHERE Aeronave_Fabricante IS NOT NULL

INSERT INTO AERO.tipos_de_servicio (NOMBRE)
SELECT DISTINCT Tipo_Servicio
FROM gd_esquema.Maestra
WHERE Tipo_Servicio IS NOT NULL

INSERT INTO AERO.ciudades (NOMBRE)
(SELECT DISTINCT Ruta_Ciudad_Origen
FROM gd_esquema.Maestra
WHERE Ruta_Ciudad_Origen IS NOT NULL
UNION
SELECT DISTINCT Ruta_Ciudad_Destino
FROM gd_esquema.Maestra
WHERE Ruta_Ciudad_Destino IS NOT NULL)

INSERT INTO AERO.aeropuertos (CIUDAD_ID, NOMBRE)
(SELECT ID, NOMBRE
FROM AERO.ciudades)

INSERT INTO AERO.clientes (DNI, NOMBRE, APELLIDO, FECHA_NACIMIENTO, MAIL, TELEFONO, DIRECCION, ROL_ID)
select m.Cli_Dni, m.Cli_Nombre, m.Cli_Apellido, m.Cli_Fecha_Nac, AERO.corrigeMail(m.Cli_Mail), m.Cli_Telefono, m.Cli_Dir, r.ID
from GD2C2015.gd_esquema.Maestra m, AERO.roles r
where r.NOMBRE = 'cliente'
group by m.Cli_Dni, m.Cli_Nombre, m.Cli_Apellido, m.Cli_Fecha_Nac, m.Cli_Mail, m.Cli_Telefono, m.Cli_Dir, r.ID;

/*la fecha de creacion es CURRENT TIMESTAMP ya que las fechas de salida de las aeronaves son en 2016*/
INSERT INTO AERO.aeronaves (MATRICULA, MODELO, KG_DISPONIBLES, FABRICANTE_ID, TIPO_SERVICIO_ID, FECHA_ALTA, CANT_BUTACAS)
SELECT m.Aeronave_Matricula, m.Aeronave_Modelo, m.Aeronave_KG_Disponibles, f.ID, ts.ID, CURRENT_TIMESTAMP, m.Butaca_Nro
FROM GD2C2015.gd_esquema.Maestra m, AERO.fabricantes f, AERO.tipos_de_servicio ts
where f.NOMBRE = m.Aeronave_Fabricante and ts.NOMBRE = m.Tipo_Servicio 
/*QUERY PARA SABER CUAL ES EL MAYOR NUMERO DE BUTACA DE LAS AERONAVES, POR SI ES QUE SE USA ESE NUMERO PARA LA CANT_BUTACAS*/
and m.Butaca_Nro = (select max(Butaca_Nro) from [GD2C2015].[gd_esquema].[Maestra] j where m.Aeronave_Matricula = j.Aeronave_Matricula)
group by m.Aeronave_Matricula, m.Aeronave_Modelo, m.Aeronave_KG_Disponibles, f.ID, ts.ID, m.Butaca_Nro

INSERT INTO AERO.butacas (NUMERO, TIPO, PISO, AERONAVE_ID, ESTADO)
SELECT M.Butaca_Nro, M.Butaca_Tipo, M.Butaca_Piso, A.ID, 'COMPRADO'
FROM AERO.aeronaves A, GD2C2015.gd_esquema.Maestra M
WHERE A.MATRICULA = M.Aeronave_Matricula AND M.Butaca_Nro != 0
GROUP BY M.Butaca_Nro, M.Butaca_Tipo, M.Butaca_Piso, A.ID
/* FALTA DEFINIR (SE PREGUNTO EN EL GRUPO DE GOOGLE
INSERT INTO AERO.rutas (CODIGO, PRECIO_BASE_KG, PRECIO_BASE_PASAJE, ORIGEN_ID, DESTINO_ID)
SELECT m.Ruta_Codigo, m.Ruta_Precio_BaseKG, m.Ruta_Precio_BasePasaje, origen.ID, destino.ID
FROM AERO.aeropuertos origen, AERO.aeropuertos destino, GD2C2015.gd_esquema.Maestra m
WHERE origen.NOMBRE = m.Ruta_Ciudad_Origen AND destino.NOMBRE = m.Ruta_Ciudad_Destino
GROUP BY m.Ruta_Codigo, m.Ruta_Precio_BaseKG, m.Ruta_Precio_BasePasaje, origen.ID, destino.ID*/

-----------------------------------------------------------------------
-- EJECUCION DE PROCEDURES

EXEC AERO.addFuncionalidad @rol='administrador', @func ='Consultar Millas';
EXEC AERO.addFuncionalidad @rol='administrador', @func ='Alta de Cliente';
EXEC AERO.addFuncionalidad @rol='administrador', @func ='Alta de Aeronave';
EXEC AERO.addFuncionalidad @rol='administrador', @func ='Alta de Ciudad';
EXEC AERO.addFuncionalidad @rol='administrador', @func ='Alta de Tarjeta de Crédito';
EXEC AERO.addFuncionalidad @rol='administrador', @func ='Baja de Aeronave';
EXEC AERO.addFuncionalidad @rol='administrador', @func ='Baja de Ciudad';
EXEC AERO.addFuncionalidad @rol='administrador', @func ='Baja de Cliente';
EXEC AERO.addFuncionalidad @rol='administrador', @func ='Baja de Tarjeta de Crédito';
EXEC AERO.addFuncionalidad @rol='administrador', @func ='Modificacion de Aeronave';
EXEC AERO.addFuncionalidad @rol='administrador', @func ='Modificacion de Ciudad';
EXEC AERO.addFuncionalidad @rol='administrador', @func ='Modificacion de Cliente';
EXEC AERO.addFuncionalidad @rol='administrador', @func ='Realizar Canje';
EXEC AERO.addFuncionalidad @rol='administrador', @func ='Alta de Rol';
EXEC AERO.addFuncionalidad @rol='administrador', @func ='Baja de Rol';
EXEC AERO.addFuncionalidad @rol='administrador', @func ='Modificacion de Rol';
EXEC AERO.addFuncionalidad @rol='administrador', @func ='Alta de Ruta';
EXEC AERO.addFuncionalidad @rol='administrador', @func ='Baja de Ruta';
EXEC AERO.addFuncionalidad @rol='administrador', @func ='Modificacion de Ruta';
EXEC AERO.addFuncionalidad @rol='administrador', @func ='Comprar Pasaje/Encomienda';
EXEC AERO.addFuncionalidad @rol='administrador', @func ='Generar Viaje';
EXEC AERO.addFuncionalidad @rol='administrador', @func ='Registrar Llegadas';
EXEC AERO.addFuncionalidad @rol='administrador', @func ='Consultar Listado';
EXEC AERO.addFuncionalidad @rol='cliente', @func ='Comprar Pasaje/Encomienda';
EXEC AERO.addFuncionalidad @rol='cliente', @func ='Consultar Millas';
EXEC AERO.addFuncionalidad @rol='cliente', @func ='Realizar Canje';