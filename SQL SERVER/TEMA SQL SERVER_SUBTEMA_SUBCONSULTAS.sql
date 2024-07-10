use InstitutoTich

--1. Obtener el nombre del alumno cuya longitud es la más grande

select * from Alumnos

select nombre, len(nombre) as tamaño from Alumnos
where len(nombre) >= All (select len(nombre) from Alumnos)


--2. Mostrar el o los alumnos menos jóvenes es decir al alumno mayor


select nombre, fechaNacimiento, DATEDIFF(year,fechaNacimiento,GETDATE()) AS [Edad hoy] 
from Alumnos
where DATEDIFF(year,fechaNacimiento,GETDATE()) = (select max(DATEDIFF(year,fechaNacimiento,GETDATE()))
from Alumnos)



--3. Obtener una lista de los alumnos que tuvieron la máxima calificación
select * from Alumnos
select * from CursosAlumnos 
select * from Cursos
select * from CatCursos


select a.nombre, a.primerApellido,a.segundoApellido,
cc.nombre, c.fechaInicio, c.fechatermino, max(ca.calificacion) as [Calificacion] from Alumnos a 
inner join CursosAlumnos ca on a.id = ca.idAlumno
inner join Cursos c on ca.idCurso = c.id 
inner join CatCursos cc on c.idCatCurso = cc.id 
where ca.calificacion =(SELECT MAX(calificacion)
      FROM CursosAlumnos)
group by a.nombre, a.primerApellido,a.segundoApellido,
cc.nombre, c.fechaInicio, c.fechatermino 




--4. Obtener la siguiente consulta con los datos de cada uno de los cursos--

select * from CursosAlumnos
select * from Cursos
select * from CatCursos

select cc.nombre, c.fechaInicio, c.fechatermino, count(ca.idCurso) as [Total],
(SELECT Max(ca.calificacion)) as [calMax], (SELECT MIN(ca.calificacion)) as [calMin],
(SELECT avg(ca.calificacion)) as [calProm] from Cursos c
inner join CursosAlumnos ca on c.id = ca.idCurso
inner join CatCursos cc on c.idCatCurso = cc.id
GROUP BY cc.nombre, c.fechaInicio, c.fechatermino

select cc.nombre, c.fechaInicio, c.fechatermino, p.Total, p.calMax, p.calMin, p.calProm
from Cursos c inner join
(SELECT idCurso, count(idCurso) as [Total] ,Max(calificacion) as [calMax],
MIN(calificacion) as [calMin],
avg(calificacion) as [calProm] from CursosAlumnos GROUP BY idCurso) as p 
ON p.idCurso = c.id
inner join CatCursos cc on c.idCatCurso = cc.id


---5. Obtener una consulta de los alumnos,
---que tienen una calificación igual o menor que el promedio de calificaciones.

select * from CursosAlumnos



select a.nombre, ca.calificacion
from Alumnos a
inner join CursosAlumnos ca on a.id = ca.idAlumno 
where ca.calificacion <= 
(SELECT avg(calificacion) as [calProm] from CursosAlumnos)












---- https://learnsql.es/blog/subconsulta-correlacionada-en-sql-una-guia-para-principiantes/----