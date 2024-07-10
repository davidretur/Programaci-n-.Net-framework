

 --1.Crear una funci�n Suma que reciba dos n�meros enteros y regrese la suma de ambos n�mero

 CREATE FUNCTION MiSuma(
 @num1 int , @num2 int
 )
 RETURNS int
 AS
 BEGIN
 RETURN @num1 + @num2
 END
 GO
 
 SELECT dbo.MiSuma(10,100);

 -- 2.
--Crear la funci�n GetGenero la cual reciba como par�metros el curp y 
--regrese el g�nero al que pertenece


drop function genero

 CREATE FUNCTION genero(
 @curp varchar(50)
 )
 RETURNS varchar(20)
 AS
 BEGIN
 DECLARE @genero VARCHAR(20)
  SET @curp = SUBSTRING(@curp,11, 1)
  if(@curp = 'H')
  set @genero = 'HOMBRE'
  else
  set @genero = 'MUJER'
RETURN @genero
 END
 GO

 SELECT dbo.genero('MADA971212HVZRMN04');


 --3. Crear la funci�n GetFechaNacimiento la cual reciba como par�metros el curp y
--regrese la fecha de nacimiento. La fecha de nacimiento deber� completarse a 4 d�gitos,
--debi�ndose determinar si es a�o dos mil o a�o mil novecientos
--N�mero que se asigna con tu a�o de nacimiento. Se asigna del 0 al 9, si naciste en 1999 o antes.
--Y si naciste despu�s del a�o 2000 se te asigna una letra del alfabeto.

drop function fechaNacimientoRFC

 CREATE FUNCTION fechaNacimientoRFC(
 @fecha varchar(20)
 )
 RETURNS varchar(20)
 AS
 BEGIN
  DECLARE @tipoasignado VARCHAR(2)
  DECLARE @fechaN VARCHAR(20)
  DECLARE @FechaFinal VARCHAR(20)
  SET @fechaN =  CONCAT(SUBSTRING(@fecha, 5, 2),'-',SUBSTRING(@fecha, 7, 2),'-',SUBSTRING(@fecha, 9, 2))
  set @tipoasignado = SUBSTRING(@fecha, 17, 1)

			IF(@tipoasignado LIKE '%[A,Z]%')
			   SET @FechaFinal = CONCAT('20',@fechaN)
			   ELSE
			   SET @FechaFinal = CONCAT('19',@fechaN)

RETURN @FechaFinal
 END
 GO

 SELECT dbo.fechaNacimientoRFC('DUHD870219HMNRRV06');

	SELECT dbo.fechaNacimientoRFC('DUHD060219HMNRRVA8');


 --4.Crear la funci�n GetidEstado la cual reciba como par�metros el curp
--y regrese el Id Estado con base en la siguiente tabla

drop function GetidEstadoRFC

 CREATE FUNCTION GetidEstadoRFC(
 @curp varchar(20)
 )
 RETURNS varchar(20)
 AS
 BEGIN
  DECLARE @Estado VARCHAR(20)
  DECLARE @EstadoCom VARCHAR(20)
  DECLARE @EstadoN VARCHAR(20)
  SET @Estado = SUBSTRING(@curp, 11, 2)
       SET @EstadoCom =
             CASE (@Estado)
			        WHEN 'AS' THEN '1'
			        WHEN 'BC' THEN '2'
			        WHEN 'BS' THEN '3'
			        WHEN 'CC' THEN '4'
			        WHEN 'AS' THEN '5'
			        WHEN 'CH' THEN '6'
                    WHEN 'CS' THEN '7'
                    WHEN 'CL' THEN '8'
					WHEN 'CM' THEN '9'
					WHEN 'DG' THEN '10'
					WHEN 'GT' THEN '11'
					WHEN 'CG' THEN '12'
				
			END
RETURN @EstadoCom 
 END
 GO

 SELECT dbo.GetidEstadoRFC('MADA971212CMZRMN04');


 -- 5.Realizar una funci�n llamada Calculadora que reciba como par�metros dos enteros y
 --un operador (+,-,*,/,%) 
--regresando el resultado de la operaci�n se deber� cuidar de no hacer divisi�n entre cero

drop function Calculadora

 CREATE FUNCTION Calculadora(
 @num1 int,@num2 int,@opedor varchar(2)
 )
 RETURNS int
 AS
 BEGIN
  DECLARE @resCom VARCHAR(20)
  if(@num1 > 0 and @num2 > 0)
       SET @resCom =
             CASE (@opedor)
                    WHEN '+' THEN @num1 + @num2
                    WHEN '-' THEN @num1 - @num2
                    WHEN '*' THEN @num1 * @num2
                    WHEN '/' THEN @num1 / @num2					
					END
ELSE
SET @resCom = 0
RETURN @resCom
 END
 GO

 SELECT dbo.Calculadora(10,9,'*');


 --- 6. Realizar una funci�n llamada GetHonorarios que calcule el importe a 
 --pagar a un determinado instructor y curso, por lo que la funci�n 
 --recibir� como par�metro el id del instructor y el id del curso.

 use InstitutoTich

 select * from CursosInstructores

 select * from Instructores

 select * from CursosAlumnos

  select * from CatCursos


 select distinct i.cuotaHora,cc.horas from CursosInstructores ci
 inner join Cursos c on ci.idCurso = c.id 
 inner join Instructores i on ci.idInstructor = i.id 
 inner join CatCursos cc on c.idCatCurso = cc.id
 where ci.idInstructor = 2 and c.id = 2
 

 drop function GetHonorarios

 CREATE FUNCTION GetHonorarios(
 @idInstructor int,@idCurso int
 )
 RETURNS int
 AS
 BEGIN
  DECLARE @cuotaHora int
    DECLARE @horas int
	DECLARE @importe int
       SET @importe = (select distinct i.cuotaHora * cc.horas from CursosInstructores ci
 inner join Cursos c on ci.idCurso = c.id 
 inner join Instructores i on ci.idInstructor = i.id 
 inner join CatCursos cc on c.idCatCurso = cc.id
 where ci.idInstructor = @idInstructor and c.id = @idCurso) 
        
RETURN @importe 
 END
 GO

 SELECT dbo.GetHonorarios(2,2);


-- 7.Crear la funci�n GetEdad la cual reciba como par�metros la fecha de nacimiento y
--la fecha a la que se requiere realizar el c�lculo de la edad. 
--Los a�os deber�n ser cumplidos, considerando mes y d�a

SELECT DATEDIFF(month,'1997/02/19','2024/02/20') AS DateDif;

SELECT DATEDIFF(day,'1997/02/19','2024/02/20') AS DateDif;


drop function GetEdad
use InstitutoTich
 CREATE FUNCTION GetEdad(
 @fecha1 date,@fecha2 date
 )
 RETURNS int
 AS
 BEGIN
  DECLARE @resCom int
  DECLARE @dias int
  DECLARE @diaNaciemiento int
  DECLARE @diaActual int
  SET @diaNaciemiento = day(@fecha1)
  SET @diaActual = day(@fecha2)
  SET @dias = DATEDIFF(day,@fecha1,@fecha2)

  if(@diaNaciemiento = @diaActual)
        SET @resCom = @dias / 365
  ELSE
       SET @resCom = @dias / 365.25
RETURN @resCom
 END
 GO

 SELECT dbo.GetEdad('1997/02/19','2025/02/18');




 --- https://www.sqlshack.com/es/usar-variables-en-sql-dinamico/---