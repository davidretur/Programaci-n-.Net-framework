use InstitutoTich

  CREATE or ALTER PROCEDURE ConsultarEstadoWeb
AS
BEGIN
 SET NOCOUNT ON;
	SELECT * from Estados;
END

--Ejecutar una procedimiento :
EXEC ConsultarEstadoWeb;

  CREATE or ALTER PROCEDURE ConsultarEstadoWebId
  @idEstado int
AS
BEGIN
 SET NOCOUNT ON;
	SELECT id,nombre FROM Estados e WHERE e.id = @idEstado
END

--Ejecutar una procedimiento :
EXEC ConsultarEstadoWebId @idEstado=1;