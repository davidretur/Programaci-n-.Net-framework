use InstitutoTich
CREATE or ALTER PROCEDURE ConsultarEstatusAlumnoWeb
AS
BEGIN
 SET NOCOUNT ON;
	SELECT * from EstatusAlumnos;
END

--Ejecutar una procedimiento :
EXEC ConsultarEstatusAlumnoWeb;

  CREATE or ALTER PROCEDURE ConsultarEstatusWebId
  @idEstatus int
AS
BEGIN
 SET NOCOUNT ON;
	SELECT id,clave,nombre FROM EstatusAlumnos WHERE id = @idEstatus
END

--Ejecutar una procedimiento :
EXEC ConsultarEstatusWebId @idEstatus=1;