use InstitutoTich


select id,  nombre, primerApellido, segundoApellido, fechaNacimiento, GETDATE() as hoy,
DATEDIFF(year,fechaNacimiento,GETDATE()) AS Edad,
DATEDIFF(year,DATEADD(MONTH, -5, fechaNacimiento), GETDATE()) as Edad5meses
from Alumnos

---- 1. Realizar la siguiente consulta Alumnos por Estado--
select * from Alumnos
select * from Estados

select  e.nombre, COUNT(*) AS TotalAlumnos from Estados e
inner join Alumnos a on e.id = a.idEstadoOrigen GROUP BY e.nombre

-- 2. Realizar la siguiente consulta Alumnos por Estatus---

select * from Alumnos
select * from EstatusAlumnos


select ea.nombre, COUNT(*) AS Total from EstatusAlumnos ea
inner join Alumnos a on a.idEstatus = ea.id GROUP BY ea.nombre


-- 3. Realizar la siguiente consulta Resumen de Calificaciones--

select * from CursosAlumnos

select 'ResumenCalificaciones' AS 'Calificaciones Alumnos', MAX(calificacion) as Maximos,
MIN(calificacion) as Minimo,
AVG(calificacion) as Promedio from CursosAlumnos

--- 4. Realizar la siguiente consulta Resumen de Calificaciones por Curso--
select * from Cursos
select * from CursosAlumnos



select  cc.nombre, c.fechaInicio, c.fechatermino,
COUNT(ca.calificacion) AS Total,
MAX(ca.calificacion) as Maximos,
MIN(ca.calificacion) as Minimo,
AVG(ca.calificacion) as Promedio from CatCursos cc
inner join Cursos c on c.idCatCurso = cc.id
inner join CursosAlumnos ca on ca.idCurso = c.id
group by cc.nombre, c.fechaInicio, c.fechatermino

---5. Realizar la siguiente consulta Resumen de Calificaciones por Estado,
---considerando únicamente a los Estados que tienen promedio mayor a 6--

select * from CursosAlumnos
select * from Estados
select * from Alumnos

select  e.nombre ,Count(ca.calificacion) as Total,
MAX(ca.calificacion) as Maximos,
MIN(ca.calificacion) as Minimo,
AVG(ca.calificacion) as Promedio
from CursosAlumnos ca
inner join Alumnos a on ca.idAlumno = a.id
inner join Estados e on a.idEstadoOrigen = e.id
group by e.nombre HAVING AVG(ca.calificacion) > 60




