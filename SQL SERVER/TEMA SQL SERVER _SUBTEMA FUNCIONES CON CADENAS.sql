use InstitutoTich
---- 1. Realizar la siguiente Consulta con el nombre y apellidos en Mayúsculas---
select * from Alumnos

select id, UPPER(nombre) AS Nombre,
UPPER(primerApellido) AS PrimerApellido, UPPER(segundoApellido) AS SegundoApellido, fechaNacimiento, GETDATE() as hoy,
DATEDIFF(year,fechaNacimiento,GETDATE()) AS Edad,
DATEDIFF(year,DATEADD(MONTH, -5, fechaNacimiento), GETDATE()) as Edad5meses
from Alumnos

--2. Realizar la consulta Anterior agregando columna con la fecha de nacimiento extraída del CURP--
select id, UPPER(nombre) AS Nombre,
UPPER(primerApellido) AS PrimerApellido, UPPER(segundoApellido) AS SegundoApellido, fechaNacimiento, curp,
CONVERT(DATE, SUBSTRING(curp,5,6)) [fecha Curp]
from Alumnos;
--- 3. Realizar una consulta con los datos del alumnos y una columna adicional indicando 
---el género con la palabra,
--- ‘Hombre’ o ‘Mujer’ según corresponda de acuerdo con lo indicado en la columna 11 del curp--

select id, nombre , primerApellido, correo, fechaNacimiento, curp,
 IIF(SUBSTRING(curp,11, 1)= 'H', 'Hombre','Mujer') as [Genero] from Alumnos

 ---- 4. Realizar la siguiente consulta de Alumnos, cambiando el correo de Gmail por hotmail---
 select id, nombre , primerApellido, correo,
 REPLACE(correo, '@gmail', '@hotmail') as [Nuevo Correo] from Alumnos