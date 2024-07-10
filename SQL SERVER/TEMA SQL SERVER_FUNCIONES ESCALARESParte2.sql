 -- 8.Crear la función Factorial la cual reciba como parámetros un número entero
-- y regrese como resultado el factorial.
use EjerciciosTich
CREATE FUNCTION factorialProc(@Numero INT)
RETURNS BIGINT
AS
BEGIN
    DECLARE @Result BIGINT;
    
    IF @Numero < 0
        SET @Result = NULL; -- Manejo de error, si lo deseas
    ELSE IF @Numero = 0 OR @Numero = 1
        SET @Result = 1;
    ELSE
        SET @Result = @Numero * dbo.factorial(@Numero - 1);
    
    RETURN @Result;
END;

drop function Factorial

 CREATE or ALTER FUNCTION Factorial(
 @numero int
 )
 RETURNS int
 AS
 BEGIN
  DECLARE @fact int
  if @numero <= 1
  SET @fact = 1
  ELSE
  SET @fact = @numero * dbo.Factorial(@numero-1)
RETURN @fact
 END
 GO

 SELECT dbo.Factorial(5);

 --9.Crear la función ReembolsoQuincenal la cual reciba como parámetros un SueldoMensual 
 -- y regrese como resultado el Importe de Reembolso quincenal, 
 --considerando que el importe total a reembolsar es igual a dos meses y medio de sueldo, 
 -- y el periodo de reembolso es de 6 meses en base 30 %

 drop function ReembolsoQuincenal

 CREATE FUNCTION ReembolsoQuincenal(
 @sueldo int
 )
 RETURNS int
 AS
 BEGIN
  DECLARE @remQuincenal int
  SET @remQuincenal = @sueldo * (2.5) / 12

RETURN @remQuincenal
 END
 GO

 SELECT dbo.ReembolsoQuincenal(30000);

--10. Realizar una función que calcule el impuesto que debe pagar un instructor para un determinado curso.
--De tal manera que la función recibirá id de un instructor y el id del curso correspondiente.
--El cálculo del impuesto se realiza de la siguiente forma:
--Determinar el porcentaje que aplicará dependiendo del estado de nacimiento
--Chiapas = 5 %
--Sonora = 10 %
--Veracruz = 7 %
--El resto del país 8 %
--El impuesto se obtendrá aplicando el porcentaje al total de la cuota por hora por la cantidad de horas del curso
--El Estado de Origen se obtendrá de la posición 12 y 13 del curp de acuerdo con la siguiente tabla

use InstitutoTich

select * from CursosInstructores
select * from CatCursos
select * from Instructores

select  I.cuotaHora,cc.horas, I.curp from Instructores i
inner join CursosInstructores ci on i.id = ci.idInstructor
inner join CatCursos cc on ci.idCurso = cc.id
WHERE i.id = 4 and ci.idCurso = 4
GROUP BY i.id,i.nombre, i.cuotaHora, i.curp,ci.idCurso,cc.horas

select i.curp from Instructores i where i.id = 2

 drop function calcularImpuestoInstructores
 use InstitutoTich
 CREATE FUNCTION calcularImpuestoInstructores(
 @idinstructor int, @idCurso int
 )
 RETURNS decimal
 AS
 BEGIN
  DECLARE @totalCuotaHora decimal
  DECLARE @totalHoras decimal
  DECLARE @Estado varchar(20)
  DECLARE @curp varchar(20)
  DECLARE @detPorcentaje decimal
  set @totalCuotaHora = (select i.cuotaHora from Instructores i
inner join CursosInstructores ci on i.id = ci.idInstructor
inner join CatCursos cc on ci.idCurso = cc.id
WHERE i.id = @idinstructor and ci.idCurso = @idCurso
GROUP BY i.id,i.nombre, i.cuotaHora, i.curp,ci.idCurso,cc.horas)

set @totalHoras = (select cc.horas from Instructores i
inner join CursosInstructores ci on i.id = ci.idInstructor
inner join CatCursos cc on ci.idCurso = cc.id
WHERE i.id = @idinstructor and ci.idCurso = @idCurso
GROUP BY i.id,i.nombre, i.cuotaHora, i.curp,ci.idCurso,cc.horas)

  set @curp = (select i.curp from Instructores i where i.id = @idinstructor)
  SET @Estado = SUBSTRING(@curp, 11, 2)
     
IF(@Estado = 'CS')
 SET @detPorcentaje = @totalCuotaHora * 5 / 100 * @totalHoras
 ELSE
IF(@Estado = 'SR')
 SET @detPorcentaje = @totalCuotaHora * 10 / 100 * @totalHoras
  ELSE
IF(@Estado = 'VZ')
 SET @detPorcentaje = @totalCuotaHora * 7 / 100 * @totalHoras
ELSE
SET @detPorcentaje = @totalCuotaHora * 8 / 100 * @totalHoras
RETURN @detPorcentaje
 END
 GO

 SELECT dbo.calcularImpuestoInstructores(1,1);

--11.Haciendo uso de la función GetEdad, obtener una relación de alumnos 
--con la edad a la fecha de inscripción,
-- y la edad actual. De aquellos alumnos que actualmente tengan más de 25 años.



select * from cursos
select * from CursosAlumnos

select  a.nombre, a.fechaNacimiento, ca.fechaInscripcion, 
dbo.GetEdad(a.fechaNacimiento,GETDATE()) [Edad hoy],
dbo.GetEdad(a.fechaNacimiento,ca.fechaInscripcion) [Edad despuesCurso] from Alumnos a
inner join CursosAlumnos ca on a.id = ca.idAlumno 
where DATEDIFF(year,a.fechaNacimiento,GETDATE()) > 25


---12 Realizar una función que determine el porcentaje a descontar en los reembolsos, 
-- con base a la cantidad de meses en que se realizará el reembolso y 
--  sueldo mensual logrado, de acuerdo al siguiente procedimiento:

drop function Reembolso

 CREATE OR ALTER FUNCTION Reembolso(
 @sueldo int,
 @meses int
 )
 RETURNS decimal(10,1)
 AS
 BEGIN
  DECLARE @rembolso decimal(10,1)
  DECLARE @porcentaje decimal(10,1)
  SET @porcentaje = @sueldo / 1000
SET @rembolso  =
             CASE (@meses)
                    WHEN '1' THEN @porcentaje
                    WHEN '2' THEN @porcentaje * .75
                    WHEN '3' THEN @porcentaje * .50
                    WHEN '4' THEN @porcentaje * .25
					ELSE
					0
					END
RETURN @rembolso
 END
 GO

 SELECT dbo.Reembolso(30000,1);


 --13. Hacer una función que convierta a mayúsculas la primera 
 -- letra de cada palabra de una cadena de caracteres recibida.


 drop function primeraMayuscula

create or alter function primeraMayuscula(
@Cadena varchar(100)
)
returns varchar(100)
as
begin
  declare @Reset bit = 1;
  declare @Resultado varchar(100) = '';
  declare @i int = 1;
  declare @palabra char(1);

  while (@i <= len(@Cadena))
    select @palabra = substring(@Cadena, @i, 1),
      @Resultado = @Resultado + 
	  case 
	  when @Reset = 1 then UPPER(@palabra) 
	  else LOWER(@palabra) 
	  end,
      @Reset = 
	  case
	  when @palabra like '[a-z]' then 0
	  else 1 
	  end,
      @i = @i + 1
  return @Resultado
end

select dbo.primeraMayuscula('hola mundo como estas')