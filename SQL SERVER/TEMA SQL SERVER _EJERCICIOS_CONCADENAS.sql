use InstitutoTich
---- 1. Realizar la siguiente Consulta con el nombre y apellidos en Mayúsculas---
select * from Alumnos

select id, UPPER(nombre) AS Nombre,
UPPER(primerApellido) AS PrimerApellido, UPPER(segundoApellido) AS SegundoApellido, fechaNacimiento, GETDATE() as hoy,
DATEDIFF(year,fechaNacimiento,GETDATE()) AS Edad,
DATEDIFF(year,DATEADD(MONTH, -5, fechaNacimiento), GETDATE()) as Edad5meses
from Alumnos

