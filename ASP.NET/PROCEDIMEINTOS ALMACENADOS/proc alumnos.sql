use InstitutoTich


  CREATE or ALTER PROCEDURE ConsultarAlumnoWeb
AS
BEGIN
 SET NOCOUNT ON;
	SELECT a.id,a.nombre,a.primerApellido,a.segundoApellido,a.fechaNacimiento,a.correo,
a.telefono, a.curp, e.nombre AS[estado], ea.nombre AS[estatus]
FROM Alumnos a 
INNER JOIN Estados e ON a.idEstadoOrigen = e.id
INNER JOIN EstatusAlumnos ea ON a.idEstatus = ea.id
END

--Ejecutar una procedimiento :
EXEC ConsultarAlumnoWeb;

  CREATE or ALTER PROCEDURE ConsultarAlumnoWebId
  @idAlumno int
AS
BEGIN
 SET NOCOUNT ON;
	SELECT a.id,a.nombre,a.primerApellido,a.segundoApellido,a.fechaNacimiento,a.correo,
a.telefono, a.curp, a.sueldo, e.id AS[estado], ea.id AS[estatus]
FROM Alumnos a 
INNER JOIN Estados e ON a.idEstadoOrigen = e.id
INNER JOIN EstatusAlumnos ea ON a.idEstatus = ea.id
WHERE a.id = @idAlumno
END

--Ejecutar una procedimiento :
EXEC ConsultarAlumnoWebId @idAlumno=1;

CREATE or Alter PROCEDURE AgregarAlumnosWeb
@Nombre VARCHAR(50),
@primerApellido VARCHAR(50),
@segundoApellido VARCHAR(50),
@Correo VARCHAR(50),
@telefono numeric(10),
@fechaNacimiento date,
@curp VARCHAR(19),
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

EXEC AgregarAlumnosWeb  @nombre='pepe', @primerApellido ='sert', @segundoApellido = 'Alvarez',
@Correo = 'da@gmail.com', @telefono = '7861198289', @fechaNacimiento = '2005-04-27', @curp = 'SGAM050229HMNRRVA6',
@sueldo = 32000, @idEstadoOrigen = 16, @idEstatus = 5


DROP PROCEDURE ActualizarAlumnosWebId

CREATE OR ALTER PROCEDURE ActualizarAlumnosWebId
@id int,
@nombre varchar(60),
@primerApellido VARCHAR(50),
@segundoApellido VARCHAR(50),
@Correo VARCHAR(50),
@telefono numeric(10),
@fechaNacimiento date,
@curp VARCHAR(19),
@sueldo int,
@idEstadoOrigen int,
@idEstatus int
AS
BEGIN
    SET NOCOUNT ON;

    -- Verificar si el alumno existe
    IF NOT EXISTS (SELECT 1 FROM Alumnos WHERE id = @id)
    BEGIN
        PRINT 'ERROR';
        RETURN;
    END
    
    -- Actualizar el registro del alumno
		UPDATE Alumnos SET
       nombre = @Nombre, primerApellido = @primerApellido, segundoApellido = @segundoApellido,
	   correo = @Correo, telefono = @telefono, fechaNacimiento = @fechaNacimiento, curp = @curp,
	   sueldo = @sueldo, idEstadoOrigen = @idEstadoOrigen, idEstatus = @idEstatus
       WHERE id = @id

    -- Mensaje de éxito
    PRINT 'OK';
END


-- Crear el procedimiento almacenado



SELECT * FROM Alumnos


EXEC ActualizarAlumnosWebId  @id = 1013 ,@nombre='David', @primerApellido ='Garcia', @segundoApellido = 'Alvarez',
@Correo = 'David@gmail.com', @telefono = '4461788289', @fechaNacimiento = '1997-05-27', @curp = 'SGAM970220HMNRRVA6',
@sueldo = 38000, @idEstadoOrigen = 16, @idEstatus = 6



CREATE PROCEDURE EliminarAlumnosWeb
    @idEliminar INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        -- Verificar saldo suficiente en la cuenta origen
        
        SELECT @idEliminar = id FROM Alumnos  WHERE id = @idEliminar;

        IF @idEliminar > 0
        BEGIN
            -- Restar la cantidad de la cuenta origen
			DELETE FROM Alumnos WHERE id = @idEliminar;
            COMMIT;
            PRINT 'OK';
        END
        ELSE
        BEGIN
            ROLLBACK;
            PRINT 'ERROR';
        END
    END TRY
    BEGIN CATCH
        ROLLBACK;
        PRINT 'Error en la Eliminacion. Se ha realizado un rollback.';
		THROW 51000,'Error al realizar la Eliminacion', 1;
    END CATCH;
END;

select * from Alumnos;

EXEC EliminarAlumnosWeb @idEliminar=1014