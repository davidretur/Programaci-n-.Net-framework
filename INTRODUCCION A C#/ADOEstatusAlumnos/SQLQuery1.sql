CREATE OR ALTER PROCEDURE InsertarEstatusAlumno (
    @clave NVARCHAR(50),
    @nombre NVARCHAR(100),
    @idNuevo INT OUTPUT
)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO EstatusAlumnos(Clave, nombre)
    VALUES (@clave, @nombre);

    SET @idNuevo = SCOPE_IDENTITY();
    
    SELECT @idNuevo AS UltimoIDInsertado;
END;
