/*1. Realizar una vista vAlumnos que obtenga el siguiente resultado*/
use InstitutoTich
CREATE OR ALTER VIEW vistaAlumnos
AS
SELECT a.id,a.nombre,a.primerApellido,a.segundoApellido,a.correo,
a.telefono, a.curp, e.nombre AS[Estado Origen], ea.nombre AS[Estatus Laboral]
FROM Alumnos a 
INNER JOIN Estados e ON a.idEstadoOrigen = e.id
INNER JOIN EstatusAlumnos ea ON a.idEstatus = ea.id
--Ejecutar una vista:
SELECT *
FROM vistaAlumnos

---- 2. Realizar el procedimiento almacenado consultarEstados el cual obtendrá la siguiente consulta,
--recibiendo como parámetro el id del registro que se requiere consultar de la tabla Estados.
--En caso de que el valor sea -1 (menos uno) deberá regresar todos los registros de dicha tabla.

CREATE or Alter PROCEDURE consultarEstadosId
@idEstado int
AS
BEGIN
    SET NOCOUNT ON;
	IF(@idEstado >0)
      SELECT id, nombre 
      FROM Estados WHERE id = @idEstado;
	  ELSE
      SELECT id, nombre 
      FROM Estados;
	END

  EXEC consultarEstadosId @idEstado=-1;

  /* 3. Realizar el procedimiento almacenado consultarEstatusAlumnos 
  el cual obtendrá la siguiente consulta, 
  recibiendo como parámetro el id del registro que se requiere consultar de la tabla estatusAlumnos.
  En caso de que el valor sea -1 
  (menos uno) deberá regresar todos los registros de dicha tabla.*/

  SELECT * FROM estatusAlumnos

  CREATE or Alter PROCEDURE consultarEstatusAlumnosId
@idEstatus int
AS
BEGIN
    SET NOCOUNT ON;
	IF(@idEstatus >0)
      SELECT id, Clave,nombre 
      FROM EstatusAlumnos WHERE id = @idEstatus;
	  ELSE
      SELECT id, Clave,nombre 
      FROM EstatusAlumnos;
	END

  EXEC consultarEstatusAlumnosId @idEstatus=-1;

  /*4. Realizar el procedimiento almacenado consultarAlumnos el cual obtendrá la
siguiente consulta, recibiendo como parámetro el id del registro que se
requiere consultar de la tabla Alumnos. En caso de que el valor sea -1 (menos
uno) deberá regresar todos los registros de dicha tabla.*/


  CREATE or Alter PROCEDURE consultarAlumnosId
@idAlumno int
AS
BEGIN
 SET NOCOUNT ON;
	IF(@idAlumno >0)
	SELECT a.id,a.nombre,a.primerApellido,a.segundoApellido,a.fechaNacimiento,a.correo,
a.telefono, a.curp, e.nombre AS[Estado Origen], ea.nombre AS[Estatus Laboral]
FROM Alumnos a 
INNER JOIN Estados e ON a.idEstadoOrigen = e.id
INNER JOIN EstatusAlumnos ea ON a.idEstatus = ea.id
WHERE a.id = @idAlumno
	ELSE
	SELECT a.id,a.nombre,a.primerApellido,a.segundoApellido,a.fechaNacimiento,a.correo,
a.telefono, a.curp, e.nombre AS[Estado Origen], ea.nombre AS[Estatus Laboral]
FROM Alumnos a 
INNER JOIN Estados e ON a.idEstadoOrigen = e.id
INNER JOIN EstatusAlumnos ea ON a.idEstatus = ea.id
END

--Ejecutar una procedimiento :
EXEC consultarAlumnosId @idAlumno=-1;


/*5. Realizar el procedimiento almacenado consultarEAlumnos el cual obtendrá la
siguiente consulta, recibiendo como parámetro el id del registro que se
requiere consultar de la tabla Alumnos. En caso de que el valor sea -1 (menos
uno) deberá regresar todos los registros de dicha tabla.*/

  CREATE or Alter PROCEDURE consultarEAlumnosId
@idAlumno int
AS
BEGIN
 SET NOCOUNT ON;
	IF(@idAlumno >0)
	SELECT a.id,a.nombre,a.primerApellido,a.segundoApellido,a.fechaNacimiento,a.correo,
a.telefono, a.curp, a.idEstadoOrigen AS[Estado Origen], a.idEstatus AS[Estatus Laboral]
FROM Alumnos a
WHERE a.id = @idAlumno
	ELSE
	SELECT a.id,a.nombre,a.primerApellido,a.segundoApellido,a.fechaNacimiento,a.correo,
a.telefono, a.curp, a.idEstadoOrigen AS[Estado Origen], a.idEstatus AS[Estatus Laboral]
FROM Alumnos a
END

EXEC consultarEAlumnosId @idAlumno=3;

/*6. Realizar el procedimiento almacenado actualizarEstatusAlumnos el cual
recibirá como parámetros el id del Alumno al cual se le requiere cambiar el
estatus y el valor del nuevo estatus.*/

CREATE or Alter PROCEDURE actualizarEstatusAlumnosId
@IdAlumno int,
@idEstatus int
AS
IF NOT EXISTS (SELECT * FROM Alumnos WHERE id=@IdAlumno)
BEGIN
	PRINT 'El id ingresado no existe en la tabla alumnos';
END
ELSE
BEGIN
       UPDATE Alumnos SET
       idEstatus = @idEstatus
       WHERE id = @IdAlumno
END

EXEC actualizarEstatusAlumnosId @IdAlumno=2, @idEstatus =4

SELECT * FROM EstatusAlumnos
SELECT * FROM Alumnos WHERE id=2

/* 7. Realizar el procedimiento almacenado agregarAlumnos el cual recibirá como
parámetros los valores de cada una de las columnas de la tabla de Alumnos
con los cuales se insertará el registro a la tabla Alumnos. El procedimiento
deberá regresar el id con el que se creo el registro en formato de entero.*/

CREATE or Alter PROCEDURE agregarAlumnos
@Nombre VARCHAR(50),
@primerApellido VARCHAR(50),
@segundoApellido VARCHAR(50),
@Correo VARCHAR(50),
@telefono numeric(10),
@fechaNacimiento date,
@curp VARCHAR(18),
@sueldo int,
@idEstadoOrigen int,
@idEstatus int

AS
BEGIN
       INSERT [dbo].[Alumnos] ([nombre],[primerApellido],[segundoApellido],
	   [correo],[telefono], [fechaNacimiento],[curp],[sueldo],[idEstadoOrigen],[idEstatus])
       VALUES (@Nombre,@primerApellido,@segundoApellido,@Correo,@telefono,@fechaNacimiento,@curp,
	   @sueldo,@idEstadoOrigen,@idEstatus)
	   PRINT SCOPE_IDENTITY()
END


EXEC agregarAlumnos  @nombre='Santiago', @primerApellido ='Garcia', @segundoApellido = 'Alvarez',
@Correo = 'sa@gmail.com', @telefono = '7861198289', @fechaNacimiento = '2005-04-27', @curp = 'SGAM050229HMNRRVA6',
@sueldo = 28000, @idEstadoOrigen = 16, @idEstatus = 5


SELECT * FROM Alumnos WHERE id=7

/*8. Realizar el procedimiento almacenado actualizarAlumnos el cual recibirá
como parámetros los valores de cada una de las columnas de la tabla de
Alumnos con los cuales se actualizarán los valores que existen en la tabla 
Alumnos del registro que corresponda al id enviado como parámetro.
El procedimiento deberá regresar la cantidad de registros actualizados.*/

CREATE or Alter PROCEDURE actualizarAlumnos
@Id int,
@Nombre varchar(60),
@primerApellido VARCHAR(50),
@segundoApellido VARCHAR(50),
@Correo VARCHAR(50),
@telefono numeric(10),
@fechaNacimiento date,
@curp VARCHAR(18),
@sueldo int,
@idEstadoOrigen int,
@idEstatus int
AS
BEGIN
       UPDATE Alumnos SET
       nombre = @Nombre, primerApellido = @primerApellido, segundoApellido = @segundoApellido,
	   correo = @Correo, telefono = @telefono, fechaNacimiento = @fechaNacimiento, curp = @curp,
	   sueldo = @sueldo, idEstadoOrigen = @idEstadoOrigen, idEstatus = @idEstatus
       WHERE id = @Id
	   PRINT 'Transacción: '+ SCOPE_IDENTITY()
END

SELECT * FROM Alumnos

EXEC actualizarAlumnos  @id = 5 ,@nombre='David', @primerApellido ='Garcia', @segundoApellido = 'Alvarez',
@Correo = 'David@gmail.com', @telefono = '4461788289', @fechaNacimiento = '1997-05-27', @curp = 'SGAM970220HMNRRVA6',
@sueldo = 38000, @idEstadoOrigen = 16, @idEstatus = 5

/*9. Realizar el procedimiento almacenado eliminarAlumnos el cual recibirá como parámetros 
el valor del id del registro del alumno del que se requiere eliminar.
Primeramente se deberán eliminar todos los registros de la Tabla de CursosAlumnos los cuales 
tengan el id del alumno a eliminar y posteriormente el eliminar al alumno de la Tabla de Alumnos.
Esto deberá considerarse como una transacción ya que se trate de actualizar dos tablas relacionadas.
En caso de que no se haya eliminado el registro de la tabla de Alumnos deberá levantar una excepción.*/
drop procedure eliminarAlumnosId

CREATE PROCEDURE eliminarAlumnosId
    @idEliminar INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        -- Verificar saldo suficiente en la cuenta origen
        
        SELECT @idEliminar = id FROM Alumnos  WHERE ID = @idEliminar;

        IF @idEliminar > 0
        BEGIN
            -- Restar la cantidad de la cuenta origen
			DELETE FROM Alumnos WHERE id = @idEliminar;
            COMMIT;
            PRINT 'Eliminacion completada exitosamente.';
        END
        ELSE
        BEGIN
            ROLLBACK;
            PRINT 'El id del alumno no Existe.';
        END
    END TRY
    BEGIN CATCH
        ROLLBACK;
        PRINT 'Error en la Eliminacion. Se ha realizado un rollback.';
		THROW 51000,'Error al realizar la Eliminacion', 1;
    END CATCH;
END;

select * from Alumnos

EXEC eliminarAlumnosId @idEliminar=14

/*10. Crear el trigger Trigger_EliminarAlumnos el cual se debe ejecutar cuando se elimina 
un registro de la tabla de Alumnos.
Este trigger deberá insertar un registro en la Tabla AlumnosBaja del alumno eliminado.*/


Create OR Alter TRIGGER Trigger_EliminarAlumnos
	ON alumnos
	AFTER DELETE
	AS
	SET NOCOUNT ON --impide que se muestre en los mensajes la fila afectada 
	BEGIN
		INSERT INTO AlumnosBaja (nombre,
								 primerApellido,
								 segundoApellido,
								 fechabaja	 
								 )
		SELECT d.nombre,
			   d.primerApellido,
			   d.segundoApellido,
			   d.fechaNacimiento

		FROM deleted d;
	END
	GO
----------------------------------------------------------------------------
SELECT * FROM Alumnos
DELETE FROM alumnos WHERE id =11;

truncate table alumnosBaja

select * from alumnosBaja

/*11. Obtener un respaldo de su base de datos InstitutoTich*/

---Para generar el respaldo de la base de datos
USE  InstitutoTich;
-- Definir variables para el nombre del archivo de respaldo y su ubicación
GO
BACKUP DATABASE InstitutoTich
TO DISK = 'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\Backup\InstitutoTich.bak'
    WITH FORMAT,
        MEDIANAME= 'SQLServerBackups',
        NAME = 'Respaldo completo de InstitutoTich';
        GO

/*12. Crear una base de datos PruebasTich con el respaldo de la base de datos InstitutoTich.*/
CREATE DATABASE PruebasTich
use master

DECLARE @BackupPath NVARCHAR(500);
SET @BackupPath = 'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\Backup\InstitutoTich_LogBackup_2024-06-20_11-19-59.bak'; 

RESTORE DATABASE InstitutoTich
FROM DISK = @BackupPath
WITH REPLACE, STATS = 10;

USE PruebasTich; 

GO

CREATE PROCEDURE spEliminaAlumnosCurso
    @nombreCurso NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    
    DELETE FROM Alumnos
    WHERE idCurso IN (
        SELECT idCurso
        FROM Cursos
        WHERE nombreCurso = @nombreCurso
    );

   
    DELETE FROM Cursos
    WHERE nombreCurso = @nombreCurso;
END;

EXEC spEliminaAlumnosCurso @nombreCurso = 'Base De Datos';
