use InstitutoTich
---- 1. Alumnos cuyo apellido sea �Mendoza�---

SELECT *
FROM Alumnos
WHERE primerApellido LIKE 'Mendoza' or segundoApellido LIKE 'Mendoza';

-- 2. Alumnos cuyo estatus sea �Laborando�--

select * from EstatusAlumnos
select * from Alumnos

SELECT a.nombre, ea.Nombre, ea.Clave FROM Alumnos a
inner join EstatusAlumnos ea on a.idEstatus = ea.id
WHERE ea.Nombre LIKE 'Laborando';

---3. Instructores que sean mayores de 40 a�os--
select * from Instructores

select id, Nombre, fechaNacimiento, GETDATE() as hoy,
DATEDIFF(year,fechaNacimiento,GETDATE()) AS [Edad hoy]
from Instructores where DATEDIFF(year,fechaNacimiento,GETDATE()) > 30 ;

--- 4. Alumnos que est�n entre 20 y 25 a�os--

select * from Alumnos

select nombre, fechaNacimiento, GETDATE() as hoy,
DATEDIFF(year,fechaNacimiento,GETDATE()) AS [Edad hoy] from Alumnos
where DATEDIFF(year,fechaNacimiento,GETDATE()) BETWEEN 20 AND 25;

--5. Alumnos que sea del Estado de �Oaxaca� y 
---su estatus sea �En Capacitaci�n�, o que sean de �Campeche� y que est�n en estatus �Prospecto�
--o que sean de �Jalisco� y que est�n en estatus �Laborando�---


select * from Alumnos
select * from Estados
select * from CursosAlumnos
select * from EstatusAlumnos

select a.nombre, e.nombre, ea.Nombre from Alumnos a 
inner join Estados e on a.idEstadoOrigen = e.id 
inner join EstatusAlumnos ea on a.idEstatus = ea.id
inner join CursosAlumnos ca on a.id = ca.idAlumno
where e.nombre LIKE 'Oaxaca' and
ea.nombre LIKE 'liberado' 
or e.nombre LIKE 'Campeche' 
and ea.nombre LIKE 'Prospecto'
or e.nombre LIKE 'Jalisco' 
and ea.nombre LIKE 'Laborando'

select a.nombre, e.nombre, ea.Nombre from Alumnos a 
inner join Estados e
on a.idEstadoOrigen = e.id 
inner join CursosAlumnos ca on a.id = ca.idAlumno
inner join EstatusAlumnos ea on a.idEstatus = ea.id
where ea.nombre LIKE 'Liberado'
and e.nombre = 'Veracruz'


--- 6. Alumnos cuyo correo sea de gmail--
SELECT * FROM Alumnos  WHERE correo LIKE '%@gmail%'

-- 7. Alumnos que cumplen a�os en el mes de marzo--

select nombre, fechaNacimiento, GETDATE() as hoy,
DATEDIFF(year,fechaNacimiento,GETDATE()) AS [Edad hoy] from Alumnos
where fechaNacimiento LIKE '%03%';

--- 8. Alumnos que cumplen 30 a�os dentro de 5 a�os en relaci�n con la fecha actual 
-- o Alumnos que cumplen 32 a�os dentro de 5 a�os en relaci�n con la fecha actual--

select nombre, fechaNacimiento, GETDATE() as hoy,
DATEDIFF(year,fechaNacimiento,GETDATE()) AS [Edad hoy],
DATEDIFF(year,DATEADD(YEAR, -5, fechaNacimiento), GETDATE()) as Edad5A�os from Alumnos
where DATEDIFF(year,DATEADD(YEAR, -5, fechaNacimiento), GETDATE()) LIKE '30';

-- 9. Alumnos cuyo nombre exceda de 10 caracteres--
SELECT LEN(nombre)
FROM Alumnos

select nombre from Alumnos where LEN(nombre)>10

-- 10. Alumnos cuyo �ltimo car�cter del curp sea num�rico-- 
select * from Alumnos

select nombre, primerApellido,curp, SUBSTRING(curp, 17, 2) as [�ltimo car�cter curp] 
from Alumnos where SUBSTRING(curp, 17, 2) NOT LIKE '%[A,Z]%'


--- 11. Alumnos cuya calificaci�n sea mayor que 80 --
select * from Alumnos
select * from CursosAlumnos

select a.nombre, a.primerApellido, ca.calificacion from Alumnos a
inner join CursosAlumnos ca 
on ca.idAlumno = a.id
where ca.calificacion > 80

--- 12. Alumnos que se encuentren en estatus laborando o liberado con un sueldo superior a 15,000--

select * from Alumnos
select * from EstatusAlumnos

select a.nombre, a.primerApellido,a.sueldo, ea.Nombre from Alumnos a
inner join EstatusAlumnos ea on a.idEstatus = ea.id
where ea.Nombre BETWEEN 'laborando' and 'liberado' and a.sueldo > 15000

--- 13. Alumnos cuyo a�o de nacimiento est� entre 1990 y 1995
--y que su primer apellido empiece con B, C � Z--

select * from Alumnos

select nombre, primerApellido, fechaNacimiento,YEAR(fechaNacimiento) as [A�o] from Alumnos
WHERE primerApellido LIKE '[B,C,Z,M]%' and YEAR(fechaNacimiento) BETWEEN 1990 and 1995

--- 14. Alumnos cuyo fecha de Nacimiento no coincide con la fecha de nacimiento del curp---

select nombre, curp, fechaNacimiento,YEAR(fechaNacimiento) as [A�o],
CONVERT(DATE, SUBSTRING(curp, 5, 6)) [Fecha de Nacimiento curp]
from Alumnos where fechaNacimiento NOT LIKE CONVERT(DATE, SUBSTRING(curp, 5, 6))



--- 15. Alumnos cuyo primer apellido inicie con �A� 
--y el mes de nacimiento sea abril y que tengan entre 21 y 30 a�os
select * from Alumnos
select nombre, primerApellido, fechaNacimiento,MONTH(fechaNacimiento) as [mes],
DATEDIFF(year,fechaNacimiento,GETDATE()) AS [Edad hoy] from Alumnos
WHERE primerApellido LIKE 'M%' AND MONTH(fechaNacimiento) = 04 
and DATEDIFF(year,fechaNacimiento,GETDATE())  BETWEEN 21 and 31

--- 16. Obtener una lista de alumnos que se llaman Luis aunque sea compuesto-
select * from Alumnos

select nombre from Alumnos where nombre LIKE '%luis%'

---17. Obtener una consulta de los cursos que se han impartido en el a�o de 2021,
---o nombre del curso
--o fecha de inicio
--o fecha final
--o cantidad de alumnos
--o promedio de calificaciones.
select * from CatCursos
select * from Cursos
select * from CursosAlumnos

select cc.nombre, c.fechaInicio, c.fechatermino, count(ca.idAlumno) as [cantidad de alumnos],
AVG(ca.calificacion) as [Promedio], YEAR(fechaInicio) as [A�o Impartido]
from CatCursos cc
inner join CursosAlumnos ca on ca.idCurso = cc.id
inner join Cursos c on ca.idCurso = c.id
where YEAR(fechaInicio) LIKE '%2027%'
GROUP BY cc.nombre, c.fechaInicio, c.fechatermino

--- 18. Realizar la siguiente consulta Resumen de Calificaciones por Estado, 
---considerando �nicamente a los alumnos que tienen calificaci�n mayor 
---a 6 mostrando �nicamente a los estados cuyo total de alumnos (con promedio mayor a 6) sea mayor a 1

select * from CursosAlumnos
select * from Alumnos
select * from Cursos
select * from Estados

select e.nombre, avg(ca.calificacion) as [Calificacion por estado],
count(ca.idAlumno) as [Total Alumnos], avg(a.sueldo)as [Prom Sueldo] from Estados e
inner join Alumnos a on e.id = a.idEstadoOrigen
inner join CursosAlumnos ca on a.id = ca.idAlumno
where ca.calificacion > 60 
group by e.nombre 
having count(*) > 1



