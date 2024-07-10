use InstitutoTich

---- 1 Realizar la siguiente consulta de Instructores--
select * from Instructores
select nombre, primerApellido as[Apellido Paterno],
segundoApellido as [Apellido Materno],
rfc , cuotaHora as [Cuota por Hora], IIF(activo>0, 'Activo', 'Inactivo') as [Estatus] from Instructores 

---- 2 Realizar la siguiente consulta de Cursos

select * from Cursos
select * from CatCursos

UPDATE CatCursos
SET horas = 150
WHERE id = 4;

SELECT Catcur.Nombre as Curso, Horas as horas, Cur.fechaInicio,fechaTermino
	FROM Cursos Cur INNER JOIN  CatCursos Catcur
	ON Cur.idCatCurso = Catcur.id 

----- 3 Realizar la siguiente consulta de alumnos----

select * from Alumnos
select * from Estados
select * from EstatusAlumnos


select alu.nombre, alu.primerApellido, alu.segundoApellido, alu.curp, est.nombre as [Estado Origen],
ea.Nombre as [Estatus] from Alumnos alu 
LEFT JOIN Estados est  on  alu.idEstadoOrigen = est.id
INNER JOIN EstatusAlumnos ea  on  alu.idEstatus = ea.id
----- 4 Realizar la siguiente consulta de Instructores, en que cursos ha participado---

select * from Instructores
select * from CursosInstructores
select * from CursosAlumnos
select * from CatCursos
select * from Cursos

select DISTINCT Concat(ins.nombre,' ',ins.primerApellido, ' ',ins.segundoApellido) AS Instructor,
ins.cuotaHora as [Salario por hora], cc.nombre,
c.fechaInicio, c.fechatermino from Instructores ins
INNER JOIN CursosInstructores ci on ins.id = ci.idInstructor
RIGHT JOIN CatCursos cc on ci.idCurso = cc.id 
FULL JOIN Cursos c on cc.id = c.idCatCurso 

------ 5 Realizar la siguiente consulta de Alumnos, mostrando los cursos ha tomado---
select * from alumnos
select * from Cursos
select * from CursosAlumnos
select * from CatCursos

select alu.nombre, alu.primerApellido, alu.segundoApellido,
est.nombre, cc.nombre as [curso],c.fechaInicio, c.fechatermino, ca.fechaInscripcion,
ca.calificacion from Alumnos alu
INNER JOIN Estados est ON alu.idEstadoOrigen = est.id
FULL JOIN CursosAlumnos ca ON alu.id = ca.idAlumno
INNER JOIN Cursos c ON ca.idCurso = c.id
 JOIN CatCursos cc ON c.idCatCurso = cc.id;

 ---- 6. Consulta de alumnos: Nombre y apellidos, curso, fecha inicial, 
 ---fecha final, calificación. Ordenado de la calificación más alta a la más baja--

select alu.nombre, alu.primerApellido, alu.segundoApellido,
est.nombre, cc.nombre as [curso],c.fechaInicio, c.fechatermino, ca.fechaInscripcion,
ca.calificacion from Alumnos alu
INNER JOIN Estados est ON alu.idEstadoOrigen = est.id
INNER JOIN CursosAlumnos ca ON alu.id = ca.idAlumno
INNER JOIN Cursos c ON ca.idCurso = c.id
 JOIN CatCursos cc ON c.idCatCurso = cc.id
 ORDER BY ca.calificacion Desc;

 ---- 7 Realizar la siguiente consulta de los Cursos con su correspondiente curso de prerrequisito---

 select * from CatCursos
 select * from Cursos

 select c.clave, c.nombre, c.horas, 
 IIF(cc.nombre!='', cc.nombre, 'Sin prerequisito') as [Prerequisito]  from CatCursos c
 LEFT join CatCursos cc on cc.id  = c.idPreRequisito


 ---- 8 Realizar una consulta con los datos del alumno y curso, dentro de ellos la calificación,
 ---obteniendo el nivel alcanzado de acuerdo con lo siguiente---

select alu.id, alu.nombre, alu.primerApellido, alu.segundoApellido,
cc.nombre as [curso],c.fechaInicio, c.fechatermino, calificacion,
CASE calificacion
	WHEN  90 THEN 'Excelente'
	WHEN  80 THEN 'Bien'
	WHEN 60 THEN 'Suficiente'
	ELSE 'N/A'
	END AS Calificacion from Alumnos alu
INNER JOIN CursosAlumnos ca ON alu.id = ca.idAlumno
INNER JOIN Cursos c ON ca.idCurso = c.id
 JOIN CatCursos cc ON c.idCatCurso = cc.id 
 ORDER BY ca.calificacion Desc;