--------------------------------------------------------------------------------------------------
---- CREACIÓN BASE DE DATOS ----------------------------------------------------------------------
--------------------------------------------------------------------------------------------------
use master
go

--Determina si esta la base de datos Obligatorio--
if exists(Select * FROM SysDataBases WHERE name='Obligatorio')
BEGIN
 --Borra la BD Obligatorio
DROP DATABASE Obligatorio
END
go

--Crea la BD Obligatorio--
CREATE DATABASE Obligatorio
ON(
NAME = Obligatorio,
FILENAME='c:\Obligatorio.mdf'
)
go

--Comandos Creacion de Tablas
USE Obligatorio
go

--------------------------------------------------------------------------------------------------
---- CREACIÓN DE TABLAS ---------------------------------------------------------------------
--------------------------------------------------------------------------------------------------

CREATE TABLE Anunciantes
(
	RutAn bigint NOT NULL PRIMARY KEY,
	NomAn varchar (20) NOT NULL,
	DirAn varchar (30) 
)
go

CREATE TABLE TelefonoAnunciantes
(
	RutAn bigint NOT NULL FOREIGN KEY REFERENCES Anunciantes(RutAn),
	TelAn int NOT NULL,
	PRIMARY KEY(RutAn, TelAn)
)
go

CREATE TABLE Campanias
(
	IdCam int NOT NULL PRIMARY KEY IDENTITY(1000,1),
	NomCam varchar (40) NOT NULL,
	DurSpotCam int NOT NULL,
	MenDiaCam int NOT NULL,
	FIniCam datetime NOT NULL,
	FFinCam datetime NOT NULL,
	RutAn bigint NOT NULL FOREIGN KEY REFERENCES Anunciantes(RutAn)
)
go

CREATE TABLE CampPropias
(
	IdCam int NOT NULL FOREIGN KEY REFERENCES Campanias(IdCam),
	CostoCam int NOT NULL,
	PRIMARY KEY(IdCam)
)
go

CREATE TABLE CampExternas
(
	IdCam int NOT NULL FOREIGN KEY REFERENCES Campanias(IdCam),
	ProdCam varchar (30) NOT NULL,
	PRIMARY KEY(IdCam)
)
go

CREATE TABLE Programas
(
	NomProg varchar (20) NOT NULL PRIMARY KEY,
	ProdProg varchar (20) NOT NULL,
	TipoProg varchar(20) NOT NULL,
	PreXSegProg int NOT NULL
)
go

CREATE TABLE Emisiones
(
	IdCam int FOREIGN KEY REFERENCES Campanias(IdCam),
	NomProg varchar (20) NOT NULL FOREIGN KEY REFERENCES Programas(NomProg),
	FEmision datetime NOT NULL,
	PRIMARY KEY(IdCam, NomProg, FEmision)
)
go


--------------------------------------------------------------------------------------------------
---- DATOS DE PRUEBA ---------------------------------------------------------------------
--------------------------------------------------------------------------------------------------
INSERT INTO Anunciantes(RutAn, NomAn, DirAn) VALUES(1234567890, 'Supermecados Rapi', '18 de Julio')
INSERT INTO Anunciantes(RutAn, NomAn, DirAn) VALUES(2234567891, 'Finger', 'Herrera 2472')
INSERT INTO Anunciantes(RutAn, NomAn, DirAn) VALUES(3234567892, 'Zony', 'Paraguay esq Colonia')
INSERT INTO Anunciantes(RutAn, NomAn, DirAn) VALUES(4234567893, 'Misaka', 'Santa Lucia 4144')
INSERT INTO Anunciantes(RutAn, NomAn, DirAn) VALUES(5234567894, 'ShuangSung', 'Agraciada 2002')
INSERT INTO Anunciantes(RutAn, NomAn, DirAn) VALUES(6234567895, 'Biciciclo', 'Uruguay y Rondeau')
INSERT INTO Anunciantes(RutAn, NomAn, DirAn) VALUES(7234567896, 'Gaggle', 'Ciudad de Pando 1506')
INSERT INTO Anunciantes(RutAn, NomAn, DirAn) VALUES(8234567897, 'Farmacia Vectors', 'Eduardo Victor Haedo 1250')
INSERT INTO Anunciantes(RutAn, NomAn, DirAn) VALUES(9234567898, 'Tiendas M y H', null)
go

INSERT INTO TelefonoAnunciantes(RutAn, TelAn) VALUES(1234567890, 24087812)
INSERT INTO TelefonoAnunciantes(RutAn, TelAn) VALUES(3234567892, 28052593)
INSERT INTO TelefonoAnunciantes(RutAn, TelAn) VALUES(5234567894, 23079238)
INSERT INTO TelefonoAnunciantes(RutAn, TelAn) VALUES(7234567896, 26983871)
INSERT INTO TelefonoAnunciantes(RutAn, TelAn) VALUES(2234567891, 23054986)
INSERT INTO TelefonoAnunciantes(RutAn, TelAn) VALUES(8234567897, 24091711)
INSERT INTO TelefonoAnunciantes(RutAn, TelAn) VALUES(6234567895, 29002572)
INSERT INTO TelefonoAnunciantes(RutAn, TelAn) VALUES(4234567893, 23044906)
INSERT INTO TelefonoAnunciantes(RutAn, TelAn) VALUES(9234567898, 23048563)
go

INSERT INTO Campanias(NomCam, DurSpotCam, MenDiaCam, FIniCam, FFinCam, RutAn) VALUES('Verduras Frescas', 40, 4, '20140901', '20141027', 1234567890)
INSERT INTO Campanias(NomCam, DurSpotCam, MenDiaCam, FIniCam, FFinCam, RutAn) VALUES('Hortalizas Primavera', 35, 3, '20141001', '20141115', 1234567890)
INSERT INTO Campanias(NomCam, DurSpotCam, MenDiaCam, FIniCam, FFinCam, RutAn) VALUES('Ofertas Tijeras', 25, 5, '20141002', '20141031', 2234567891)
INSERT INTO Campanias(NomCam, DurSpotCam, MenDiaCam, FIniCam, FFinCam, RutAn) VALUES('Tv Led 42" ISDBT', 45, 7, '20140922', '20141016',3234567892)
INSERT INTO Campanias(NomCam, DurSpotCam, MenDiaCam, FIniCam, FFinCam, RutAn) VALUES('Celulares Android', 35, 6, '20141004', '20141120', 3234567892)
INSERT INTO Campanias(NomCam, DurSpotCam, MenDiaCam, FIniCam, FFinCam, RutAn) VALUES('Cine Anime', 37, 8,'20140914', '20141015', 4234567893)
INSERT INTO Campanias(NomCam, DurSpotCam, MenDiaCam, FIniCam, FFinCam, RutAn) VALUES('Te Verde Milagroso', 34, 3, '20140928', '20141013', 5234567894)
INSERT INTO Campanias(NomCam, DurSpotCam, MenDiaCam, FIniCam, FFinCam, RutAn) VALUES('Gimnasio Multi', 26, 5, '20140930', '20141028', 6234567895)
INSERT INTO Campanias(NomCam, DurSpotCam, MenDiaCam, FIniCam, FFinCam, RutAn) VALUES('Oferta motos', 50, 8, '20141003', '20141028', 6234567895)
INSERT INTO Campanias(NomCam, DurSpotCam, MenDiaCam, FIniCam, FFinCam, RutAn) VALUES('Dto de 20% VISA', 24, 6, '20141005', '20141031', 6234567895)
INSERT INTO Campanias(NomCam, DurSpotCam, MenDiaCam, FIniCam, FFinCam, RutAn) VALUES('Lentes net', 55, 7, '20141005', '20141115', 7234567896)
INSERT INTO Campanias(NomCam, DurSpotCam, MenDiaCam, FIniCam, FFinCam, RutAn) VALUES('Celular de alta gama', 43, 9, '20141010', '20141031', 7234567896)
INSERT INTO Campanias(NomCam, DurSpotCam, MenDiaCam, FIniCam, FFinCam, RutAn) VALUES('Aqua Cure', 25, 4, '20141001', '20141101', 8234567897)
INSERT INTO Campanias(NomCam, DurSpotCam, MenDiaCam, FIniCam, FFinCam, RutAn) VALUES('Dto en medicamentos', 38, 3, '20140620', '20140710', 8234567897)
INSERT INTO Campanias(NomCam, DurSpotCam, MenDiaCam, FIniCam, FFinCam, RutAn) VALUES('Dto en cosmeticos', 26, 4, '20140903', '20140927', 8234567897)
INSERT INTO Campanias(NomCam, DurSpotCam, MenDiaCam, FIniCam, FFinCam, RutAn) VALUES('Prueba', 26, 4, '20140903', '20140927', 9234567898)
go

INSERT INTO CampPropias(IdCam, CostoCam) VALUES(1005, 500)
INSERT INTO CampPropias(IdCam, CostoCam) VALUES(1006, 635)
INSERT INTO CampPropias(IdCam, CostoCam) VALUES(1007, 863)
INSERT INTO CampPropias(IdCam, CostoCam) VALUES(1012, 853)
INSERT INTO CampPropias(IdCam, CostoCam) VALUES(1014, 900)
INSERT INTO CampPropias(IdCam, CostoCam) VALUES(1015, 900)
go

INSERT INTO CampExternas(IdCam, ProdCam) VALUES(1000, 'E y G Producciones')
INSERT INTO CampExternas(IdCam, ProdCam) VALUES(1001, 'Index Producciones')
INSERT INTO CampExternas(IdCam, ProdCam) VALUES(1002, 'Altamira')
INSERT INTO CampExternas(IdCam, ProdCam) VALUES(1003, 'Vitamina')
INSERT INTO CampExternas(IdCam, ProdCam) VALUES(1008, 'Oz')
INSERT INTO CampExternas(IdCam, ProdCam) VALUES(1009, 'Musiteli')
INSERT INTO CampExternas(IdCam, ProdCam) VALUES(1010, 'VideoTime')
INSERT INTO CampExternas(IdCam, ProdCam) VALUES(1011, 'Estudio 9')
INSERT INTO CampExternas(IdCam, ProdCam) VALUES(1013, 'AniPlex')
go

INSERT INTO Programas(NomProg, ProdProg, TipoProg, PreXSegProg) VALUES('Informativisimo', 'Marcelo', 'Periodistico', 250)
INSERT INTO Programas(NomProg, ProdProg, TipoProg, PreXSegProg) VALUES('Viajar por Uruguay', 'Andres', 'Variedades', 500)
INSERT INTO Programas(NomProg, ProdProg, TipoProg, PreXSegProg) VALUES('Escuchemos', 'Juarez', 'Variedades', 150)
INSERT INTO Programas(NomProg, ProdProg, TipoProg, PreXSegProg) VALUES('Radioshopping', 'Pablo', 'Variedades', 200)
INSERT INTO Programas(NomProg, ProdProg, TipoProg, PreXSegProg) VALUES('Top 10', 'Valeria', 'Musical', 180)
INSERT INTO Programas(NomProg, ProdProg, TipoProg, PreXSegProg) VALUES('Noticias 20', 'Camila', 'Periodistico', 300)
INSERT INTO Programas(NomProg, ProdProg, TipoProg, PreXSegProg) VALUES('Rush Hour', 'Jackie', 'Variedades', 300)
go

INSERT INTO Emisiones(IdCam, NomProg, FEmision) VALUES(1000, 'Informativisimo', '20140923 20:30')
INSERT INTO Emisiones(IdCam, NomProg, FEmision) VALUES(1001, 'Top 10', '20140910 19:00')
INSERT INTO Emisiones(IdCam, NomProg, FEmision) VALUES(1002, 'Viajar por Uruguay', '20140802 15:30')
INSERT INTO Emisiones(IdCam, NomProg, FEmision) VALUES(1003, 'Informativisimo', '20140905 12:00')
INSERT INTO Emisiones(IdCam, NomProg, FEmision) VALUES(1004, 'Noticias 20', '20140630 08:00')
INSERT INTO Emisiones(IdCam, NomProg, FEmision) VALUES(1005, 'Top 10', '20140723 21:00')
INSERT INTO Emisiones(IdCam, NomProg, FEmision) VALUES(1006, 'Noticias 20', '20140825 23:30')
INSERT INTO Emisiones(IdCam, NomProg, FEmision) VALUES(1007, 'Viajar por Uruguay', '20140920 12:30')
INSERT INTO Emisiones(IdCam, NomProg, FEmision) VALUES(1008, 'Viajar por Uruguay', '20141006 11:00')
INSERT INTO Emisiones(IdCam, NomProg, FEmision) VALUES(1009, 'Informativisimo', '20141101 15:00')
INSERT INTO Emisiones(IdCam, NomProg, FEmision) VALUES(1010, 'Viajar por Uruguay', '20141102 15:00')
INSERT INTO Emisiones(IdCam, NomProg, FEmision) VALUES(1011, 'Noticias 20', '20140821 08:00')
INSERT INTO Emisiones(IdCam, NomProg, FEmision) VALUES(1012, 'Informativisimo', '20141002 20:30')
INSERT INTO Emisiones(IdCam, NomProg, FEmision) VALUES(1013, 'Noticias 20', '20140830 19:00')
INSERT INTO Emisiones(IdCam, NomProg, FEmision) VALUES(1014, 'Informativisimo', '20140713 11:00')
go

-------------------------------------------------------------------------------------------------------------------------
------------------------
------ANUNCIANTES-------
------------------------


CREATE PROCEDURE AgregarAnunciante @RutAn BIGINT, @NomAn VARCHAR(20), @DirAn VARCHAR(30) AS
BEGIN
	IF(EXISTS(SELECT * FROM Anunciantes WHERE @RutAn = RutAn))
		RETURN (-1)--Ya existe el Anunciante

	INSERT INTO Anunciantes(RutAn, NomAn, DirAn) VALUES(@RutAn, @NomAn, @DirAn)

	IF (@@Error = 0)
		RETURN (1)--Anunciante Agregado
    ELSE
        RETURN (-2)--Error al agregar Anunciante
END
go

--DECLARE @Retorno int
--EXECUTE @Retorno = AgregarAnunciante 9934567890, 'Supermecados Rata', '18 de Julio'
--PRINT @Retorno


CREATE PROCEDURE EliminarAnunciante @RutAn BIGINT AS
BEGIN
	IF(NOT EXISTS(SELECT * FROM Anunciantes WHERE @RutAn = RutAn))
		RETURN (-1)--No existe el Anunciante 

	BEGIN TRAN
			DELETE
			FROM Emisiones
			WHERE IdCam in (
									SELECT IdCam
									FROM Campanias
									WHERE @RutAn = RutAn
								)
			IF @@Error<>0
				BEGIN 
					ROLLBACK TRAN
					RETURN (-2)--Error al intentar eliminar la Emision
			    END
			
			
			DELETE 
			FROM CampPropias
			WHERE IdCam in(
									SELECT IdCam
									FROM Campanias
									WHERE @RutAn = RutAn
								)
			IF @@Error<>0
				BEGIN 
					ROLLBACK TRAN
					RETURN (-3)--Error al intentar eliminar la Campania Propia
				END

			
			DELETE 
			FROM CampExternas
			WHERE exists (
									SELECT *
									FROM Campanias
									WHERE @RutAn = RutAn
								)
			IF @@Error<>0
				BEGIN 
					ROLLBACK TRAN
					RETURN (-4)--Error al intentar eliminar la Campania Externa
				END

			
			DELETE 
			FROM Campanias
			WHERE @RutAn = RutAn
			
			IF @@Error<>0
				BEGIN 
					ROLLBACK TRAN
					RETURN (-5)--Error al intentar eliminar la Campania
				END	
					

			DELETE
			FROM TelefonoAnunciantes
			WHERE @RutAn = RutAn

			BEGIN
				IF @@Error<>0
				BEGIN 
					ROLLBACK TRAN 
					RETURN (-6)--Error al intentar eliminar el Telefono del Anunciante
			    END
			END


			DELETE
			FROM Anunciantes
			WHERE @RutAn = RutAn

				IF @@Error<>0
				BEGIN 
					ROLLBACK TRAN 
					RETURN (-7)--Error al intentar eliminar el Anunciante
				END
			
				BEGIN 
					COMMIT TRAN 
					RETURN (1)--Anunciante Eliminado con Exito
				END
END
go

--DECLARE @Retorno int
--EXECUTE @Retorno = EliminarAnunciante 9934567890
--PRINT @Retorno


CREATE PROCEDURE BuscarAnunciante @RutAn BIGINT AS
BEGIN 
	SELECT *
	FROM Anunciantes
	WHERE RutAn = @RutAn;
END
go

--execute BuscarAnunciante '2234567891'


CREATE PROCEDURE ModificarAnunciante @RutAn BIGINT, @NomAn VARCHAR(20), @DirAn VARCHAR(30) AS
BEGIN 
	IF(NOT EXISTS(SELECT * FROM Anunciantes WHERE RutAn = @RutAn))
		RETURN (-1)--No Existe el Anunciante

	UPDATE Anunciantes SET  NomAn = @NomAn, DirAn = @DirAn WHERE RutAn = @RutAn;

	IF (@@Error = 0)
		RETURN (1)--Anunciante Modificado Exitosamente
	ELSE
	    RETURN (-2)--Error al Modificar Anunciante
END
go

--DECLARE @Retorno int
--EXECUTE @Retorno = ModificarAnunciante 9934567890, 'Supermecados HolaHo', 'Sarandi 1209'
--PRINT @Retorno


----------------------------------
------TELEFONOS ANUNCIANTES-------
----------------------------------

CREATE PROCEDURE AgregarTelAnunciante @RutAn BIGINT, @TelAn INT AS
BEGIN
    IF(NOT EXISTS(SELECT * FROM Anunciantes WHERE @RutAn = RutAn))
        RETURN (-1)--No Existe el Anunciante
    IF(EXISTS(SELECT * FROM TelefonoAnunciantes WHERE (TelAn = @TelAn AND RutAn = @RutAn)))
        RETURN (-2)--Telefono Duplicado

	INSERT INTO TelefonoAnunciantes(RutAn, TelAn) VALUES(@RutAn, @TelAn)
	
	IF (@@Error = 0)
		RETURN (1)--Telefono Agregado
	ELSE
	    RETURN (-3)--Error al agregar el Telefono
END
go

--DECLARE @Retorno int
--EXECUTE @Retorno = AgregarTelAnunciante 1234567890, 22097942
--PRINT @Retorno

CREATE PROCEDURE EliminarTelAnunciante @RutAn BIGINT AS
BEGIN
    IF(NOT EXISTS(SELECT * FROM Anunciantes WHERE RutAn = @RutAn))
        RETURN (-1)--No Existe el Anunciante

    DELETE
    FROM TelefonoAnunciantes
    WHERE RutAn = @RutAn
    
    IF (@@Error = 0)
        RETURN (1)--Telefonos Eliminados
    ELSE
        RETURN (-2)--Error al Eliminar Telefonos
END
go

--DECLARE @Retorno int
--EXECUTE @Retorno = EliminarTelAnunciante 3234567892
--PRINT @Retorno


-------------------------
--------CAMPANIAS--------
-------------------------

CREATE PROCEDURE EliminarCampania @IdCam INT AS
BEGIN
	IF(NOT EXISTS(SELECT * FROM Campanias WHERE IdCam = @IdCam))
		RETURN (-1)--No Existe la Campania

	DECLARE @Error INT
	BEGIN TRAN
	DELETE Emisiones WHERE IdCam = @IdCam;
	SET @Error = @@ERROR;

	IF(@Error != 0)
	BEGIN
		ROLLBACK TRAN;
		RETURN (-2);--Error al Eliminar la Emision
	END

	DELETE CampPropias WHERE IdCam = @IdCam;

	IF(@Error != 0)
	BEGIN
		ROLLBACK TRAN;
		RETURN (-3);--Error al Eliminar la Campania Propia
	END

	DELETE CampExternas WHERE IdCam = @IdCam;

	IF(@Error != 0)
	BEGIN
		ROLLBACK TRAN;
		RETURN (-4);--Error al Eliminar la Campania Externa
	END

	DELETE Campanias WHERE IdCam = @IdCam;
	
	IF(@Error!=0)
	BEGIN
		ROLLBACK TRAN;
		RETURN (-5);--Error al Eliminar la Campania
	END

	ELSE
	BEGIN
		COMMIT TRAN;
		RETURN (1);--Campania Propia Eliminada Exitosamente
	END	
END
go

--DECLARE @Retorno int
--EXECUTE @Retorno = EliminarCampania 1005
--PRINT @Retorno

-------------------------
----CAMPANIAS PROPIAS----
-------------------------

CREATE PROCEDURE AgregarCampaniaPropia @NomCam VARCHAR(40), @DurSpotCam INT ,@MenDiaCam INT, @FIniCam DATETIME, @FFinCam DATETIME, 
@RutAn BIGINT, @CostoCam INT AS
BEGIN 
	IF (NOT EXISTS (SELECT * FROM Anunciantes WHERE RutAn = @RutAn))
		RETURN (-1);--No existe el Anunciante

    IF (@FIniCam > @FFinCam)
        RETURN (-2);--La Fecha de Inicio debe ser menor o igual a la Fecha Final

	DECLARE @Error INT
	BEGIN TRAN

	INSERT INTO Campanias(NomCam, DurSpotCam, MenDiaCam, FIniCam, FFinCam, RutAn) 
	VALUES(@NomCam, @DurSpotCam, @MenDiaCam, @FIniCam, @FFinCam, @RutAn);
	SET @Error = @@ERROR;

	IF(@Error != 0)
	BEGIN
		ROLLBACK TRAN;
		RETURN (-3);--Error al Agregar Campania
	END

	INSERT INTO CampPropias(IdCam, CostoCam) VALUES(IDENT_CURRENT('Campanias'), @CostoCam);
	
	IF(@Error!=0)
	BEGIN
		ROLLBACK TRAN;
		RETURN (-4);--Error al Agregar Campania Propia
	END
	ELSE
	BEGIN
		COMMIT TRAN;
--		RETURN (1);--Campania Propia Agregada con Exito
        RETURN (IDENT_CURRENT('Campanias'));
	END	
END
go

--DECLARE @Retorno int
--EXECUTE @Retorno = AgregarCampaniaPropia 'Verduras Viejas', 40, 4, '20141101', '20141227', 1234567890, 200
--PRINT @Retorno


CREATE PROCEDURE BuscarCampaniaPropia @IdCam INT AS
BEGIN 
	SELECT C.IdCam, NomCam, DurSpotCam, MenDiaCam, FIniCam, FFinCam, RutAn, CostoCam
	FROM CampPropias P INNER JOIN Campanias C ON P.IdCam=C.IdCam
	WHERE C.IdCam = @IdCam;
END
go


--DECLARE @Retorno int
--EXECUTE @Retorno = BuscarCampaniaPropia 1005
--PRINT @Retorno

CREATE PROCEDURE ModificarCampaniaPropia @IdCam INT, @NomCam VARCHAR(40), @DurSpotCam INT ,@MenDiaCam INT, 
@FIniCam DATETIME, @FFinCam DATETIME, @RutAn BIGINT, @CostoCam INT AS
BEGIN 
	IF (NOT EXISTS (SELECT * FROM Campanias WHERE @IdCam = IdCam))
		RETURN (-1);--No existe la Campania

	IF (NOT EXISTS (SELECT * FROM CampPropias WHERE @IdCam = IdCam))
		RETURN (-2);--No es una Campania Propia

    IF (NOT EXISTS (SELECT * FROM Anunciantes WHERE RutAn = @RutAn))
		RETURN (-3);--No existe el Anunciante

	DECLARE @Error INT
	BEGIN TRAN

	UPDATE Campanias SET NomCam = @NomCam, DurSpotCam = @DurSpotCam, MenDiaCam = @MenDiaCam, FIniCam = @FIniCam, FFinCam = @FFinCam,
	RutAn = @RutAn WHERE IdCam = @IdCam;
	SET @Error = @@ERROR;

	IF(@Error != 0)
	BEGIN
		ROLLBACK TRAN;
		RETURN (-4);--Error al Modificar Campania
	END
	
	UPDATE CampPropias SET CostoCam = @CostoCam WHERE IdCam = @IdCam;
	
	IF(@Error!=0)
	BEGIN
		ROLLBACK TRAN;
		RETURN (-5);--Error al Modificar Campania Propia
	END
	ELSE
	BEGIN
		COMMIT TRAN;
		RETURN (1);--Campania Propia Modificada con Exito
	END	
END
go

--DECLARE @Retorno int
--EXECUTE @Retorno = ModificarCampaniaPropia 1016, 'Verduras Viejas', 20, 4, '20141101', '20141227', 1234567890, 200
--PRINT @Retorno


------------------------
---CAMPANIAS EXTERNAS---
------------------------

CREATE PROCEDURE AgregarCampaniaExterna @NomCam VARCHAR(40), @DurSpotCam INT ,@MenDiaCam INT, 
@FIniCam DATETIME, @FFinCam DATETIME, @RutAn BIGINT, @ProdCam VARCHAR(30) AS
BEGIN 
	IF (NOT EXISTS (SELECT * FROM Anunciantes WHERE RutAn = @RutAn))
		RETURN (-1);--No existe el Anunciante

    IF (@FIniCam > @FFinCam)
        RETURN (-2);--La Fecha de Inicio debe ser menor o igual a la Fecha Final

	DECLARE @Error INT
	BEGIN TRAN

	INSERT INTO Campanias(NomCam, DurSpotCam, MenDiaCam, FIniCam, FFinCam, RutAn) 
	VALUES(@NomCam, @DurSpotCam, @MenDiaCam, @FIniCam, @FFinCam, @RutAn);
	SET @Error = @@ERROR;

	IF(@Error != 0)
	BEGIN
		ROLLBACK TRAN;
		RETURN (-3);--Error al Agregar Campania
	END

	INSERT INTO CampExternas(IdCam, ProdCam) VALUES(IDENT_CURRENT('Campanias'), @ProdCam);
	
	IF(@Error!=0)
	BEGIN
		ROLLBACK TRAN;
		RETURN (-4);--Error al Agregar Campania Externa
	END
	ELSE
	BEGIN
		COMMIT TRAN;
		RETURN (1);--Campania Externa Agregada con Exito
	END	
END
go

--DECLARE @Retorno int
--EXECUTE @Retorno = AgregarCampaniaExterna 'Verduras Verdes', 40, 4, '20141001', '20141227', 1234567890, 'Vegano'
--PRINT @Retorno


CREATE PROCEDURE BuscarCampaniaExterna @IdCam INT AS
BEGIN 
	SELECT C.IdCam, NomCam, DurSpotCam, MenDiaCam, FIniCam, FFinCam, RutAn, ProdCam
	FROM CampExternas E INNER JOIN Campanias C ON E.IdCam=C.IdCam
	WHERE C.IdCam = @IdCam;
END
go

--DECLARE @Retorno int
--EXECUTE @Retorno = BuscarCampaniaExterna 1000
--PRINT @Retorno

CREATE PROCEDURE ModificarCampaniaExterna @IdCam INT, @NomCam VARCHAR(40), @DurSpotCam INT ,@MenDiaCam INT, 
@FIniCam DATETIME, @FFinCam DATETIME, @RutAn BIGINT, @ProdCam VARCHAR(30) AS
BEGIN 
	IF (NOT EXISTS (SELECT * FROM Anunciantes WHERE RutAn = @RutAn))
		RETURN (-1);--No existe el Anunciante

	IF (NOT EXISTS (SELECT * FROM Campanias WHERE @IdCam = IdCam))
		RETURN (-2);--No existe la Campania

	IF (NOT EXISTS (SELECT * FROM CampExternas WHERE @IdCam = IdCam))
		RETURN (-3);--No es una Campania Externa 

	DECLARE @Error INT
	BEGIN TRAN

	UPDATE Campanias SET NomCam = @NomCam, DurSpotCam = @DurSpotCam, MenDiaCam = @MenDiaCam, FIniCam = @FIniCam, FFinCam = @FFinCam,
	RutAn = @RutAn WHERE IdCam = @IdCam;
	SET @Error = @@ERROR;

	IF(@Error != 0)
	BEGIN
		ROLLBACK TRAN;
		RETURN (-4);--Error al Modificar Campania
	END
	
	UPDATE CampExternas SET ProdCam = @ProdCam WHERE IdCam = @IdCam;
	
	IF(@Error!=0)
	BEGIN
		ROLLBACK TRAN;
		RETURN (-5);--Error al Modificar Campania Externa
	END
	ELSE
	BEGIN
		COMMIT TRAN;
		RETURN (1);--Campania Externa Modificada con Exito
	END	
END
go

--DECLARE @Retorno int
--EXECUTE @Retorno = ModificarCampaniaExterna 1001, 'Verduras Viejas', 20, 4, '20141101', '20141227', 1234567890, 'Vegie'
--PRINT @Retorno

-------------------------
--------PROGRAMAS--------
-------------------------

CREATE PROCEDURE AgregarPrograma @NomProg VARCHAR(20), @ProdProg VARCHAR(20), @TipoProg VARCHAR(20), @PreXSegProg INT AS
BEGIN
	IF (EXISTS (SELECT * FROM Programas WHERE NomProg = @NomProg))
		RETURN (-1);--El programa ya existe

	INSERT INTO Programas(NomProg, ProdProg, TipoProg, PreXSegProg) VALUES(@NomProg, @ProdProg, @TipoProg, @PreXSegProg)

	IF (@@Error = 0)
		RETURN (1)--Programa Agregado
    ELSE
        RETURN (-2)--Error al agregar Programa
END
go

--DECLARE @Retorno int
--EXECUTE @Retorno = AgregarPrograma 'Hola Mundo', 'Pedro', 'Variedades', 700
--PRINT @Retorno

CREATE PROCEDURE EliminarPrograma @NomProg VARCHAR(20) AS
BEGIN
	IF (EXISTS (SELECT * FROM Emisiones WHERE NomProg = @NomProg))
		RETURN (-1);--El programa tiene campanias asociadas

	DELETE
	FROM Programas
	WHERE NomProg = @NomProg

	IF (@@Error = 0)
		RETURN (1)--Programa Eliminado
    ELSE
        RETURN (-2)--Error al eliminar Programa
END
go

--DECLARE @Retorno int
--EXECUTE @Retorno = EliminarPrograma 'Hola Mundo'
--PRINT @Retorno

CREATE PROCEDURE BuscarPrograma @NomProg VARCHAR(20) AS
BEGIN
	SELECT *
	FROM Programas
	WHERE NomProg = @NomProg
END
go

--DECLARE @Retorno int
--EXECUTE @Retorno = BuscarPrograma 'Top 10'
--PRINT @Retorno

CREATE PROCEDURE ModificarPrograma @NomProg VARCHAR(20), @ProdProg VARCHAR(20), @TipoProg VARCHAR(20), @PreXSegProg INT AS
BEGIN
	IF (NOT EXISTS (SELECT * FROM Programas WHERE NomProg = @NomProg))
		RETURN (-1);--El programa NO existe

	UPDATE Programas SET ProdProg = @ProdProg, TipoProg = @TipoProg, PreXSegProg = @PreXSegProg WHERE NomProg = @NomProg;

	IF (@@Error = 0)
		RETURN (1)--Programa Modificado
    ELSE
        RETURN (-2)--Error al modificar Programa
END
go

--DECLARE @Retorno int
--EXECUTE @Retorno = ModificarPrograma 'Hola Mundo', 'Pancracio', 'Variedades', 400
--PRINT @Retorno

-------------------------------
--------AGREGAR MENCION--------
-------------------------------

CREATE PROCEDURE AgregarEmision @IdCam INT, @NomProg VARCHAR(20), @FEmision DATETIME AS
BEGIN
	IF (NOT EXISTS (SELECT * FROM Campanias WHERE IdCam = @IdCam))
		RETURN (-1);--La campania no existe
	
	IF (NOT EXISTS (SELECT * FROM Programas WHERE NomProg = @NomProg))
		RETURN (-2);--El programa no existe

	DECLARE @FIniCam DATETIME, @FFinCam DATETIME;

    SELECT @FIniCam = FIniCam, @FFinCam = FFinCam
	FROM Campanias
	WHERE IdCam = @IdCam

	IF((@FEmision < @FIniCam) OR (@FEmision > @FFinCam))
		RETURN (-3);--La fecha de la mencion no esta dentro del rango de la campania

    DECLARE @CantEmDia INT;

    SELECT @CantEmDia = COUNT (@IdCam)
    FROM Emisiones
	WHERE year(FEmision) = year(@FEmision) AND month(FEmision) = month(@FEmision) AND day(FEmision) = day(@FEmision)

    DECLARE @MenDiaCam INT;

    SELECT @MenDiaCam = MenDiaCam
    FROM Campanias
    WHERE IdCam = @IdCam

    IF(@CantEmDia > @MenDiaCam)
       RETURN(-4)--Se exede la Cantidad de Emisiones diarias Permitida
	
INSERT INTO Emisiones(IdCam, NomProg, FEmision) VALUES (@IdCam, @NomProg, @FEmision)

	IF (@@Error = 0)
		RETURN (1)--Emisión Agregada
    ELSE
        RETURN (-5)--Error al agregar la Emisión
END
go

--DECLARE @Retorno int
--EXECUTE @Retorno = AgregarEmision 1013, 'Noticias 20', '20140630 18:00'
--PRINT @Retorno


---------------------------------
------------LISTADOS-------------
---------------------------------
CREATE PROCEDURE ListarCampanias AS
BEGIN
     SELECT IdCam, NomCam, DurSpotCam, MenDiaCam, FIniCam, FFinCam, RutAn
     FROM Campanias
END
go

--EXECUTE ListarCampanias

CREATE PROCEDURE ListarCampaniasPropias AS
BEGIN
     SELECT C.IdCam, NomCam, DurSpotCam, MenDiaCam, FIniCam, FFinCam, RutAn, CostoCam
	FROM CampPropias P INNER JOIN Campanias C ON P.IdCam=C.IdCam
END
go

--EXECUTE ListarCampaniasPropias

CREATE PROCEDURE ListarCampaniasExternas AS
BEGIN
     SELECT C.IdCam, NomCam, DurSpotCam, MenDiaCam, FIniCam, FFinCam, RutAn, ProdCam
	FROM CampExternas E INNER JOIN Campanias C ON E.IdCam = C.IdCam
END
go

--EXECUTE ListarCampaniasExternas

CREATE PROCEDURE ListarEmisiones  @IdCam INT AS
BEGIN
     SELECT *
	FROM Emisiones
	WHERE @IdCam = IdCam
END
go

--EXECUTE ListarEmisiones

CREATE PROCEDURE ListarProgramas AS
BEGIN
     SELECT NomProg, ProdProg, TipoProg, PreXSegProg
     FROM Programas
END
go

--EXECUTE ListarProgramas

CREATE PROCEDURE ListarTelAnunciante @RutAn BIGINT AS
BEGIN 
	SELECT *
	FROM TelefonoAnunciantes
	WHERE RutAn = @RutAn
END
go

--EXECUTE ListarTelAnunciante

CREATE PROCEDURE ListarAnunciantes AS
BEGIN
     SELECT RutAn, NomAn, DirAn
     FROM Anunciantes
END
go

--EXECUTE ListarAnunciantes

---------------------------------------------------------------------------------------------------------------------------------------------
