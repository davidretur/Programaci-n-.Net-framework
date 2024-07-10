use InstitutoTich

-- 1. Actualizar el estatus del Alumnos de los que están en propedéutico a capacitación--
-- 1. Actualizar el estatus del Alumnos de los que están en "En Incursión id 4" a "Laborando id 5"---

select * from Alumnos 

select * from EstatusAlumnos


select ea.id, ea.nombre from EstatusAlumnos ea inner join
Alumnos a on ea.id = a.idEstatus


	UPDATE Alu SET Alu.idEstatus = 5
	FROM Alumnos Alu 
	WHERE idEstatus= 4

select * from Alumnos 

-- 2. Actualizar el segundo apellido del Alumno a Mayúsculas o mINUSCULAS--

	UPDATE Alu SET Alu.segundoApellido = REPLACE(Alu.segundoApellido,SUBSTRING(Alu.segundoApellido, 1, 1),
	UPPER(SUBSTRING(segundoApellido, 1, 1)))
	FROM Alumnos Alu 
	WHERE id= 11

	select segundoApellido, UPPER(SUBSTRING(segundoApellido, 1, 1)) as [pLetra],
REPLACE(segundoApellido,SUBSTRING(segundoApellido, 1, 1), UPPER(SUBSTRING(segundoApellido, 1, 1))) as [minLetra]
from Alumnos

--- 3. Actualizar el segundo Apellido para que la primera letra sea mayúsculas y el resto minúsculas--
--- 3. Actualizar el segundo Apellido para que la primera letra sea mayúsculas y el resto minúsculas--
select * from Alumnos

	UPDATE Alu SET Alu.segundoApellido = REPLACE(Alu.segundoApellido,SUBSTRING(Alu.segundoApellido, 1, 1),
	lower(SUBSTRING(segundoApellido, 1, 1)))
	FROM Alumnos Alu 
	WHERE id= 11

select segundoApellido, lower(SUBSTRING(segundoApellido, 1, 1)) as [pLetra],
REPLACE(segundoApellido,SUBSTRING(segundoApellido, 1, 1), lower(SUBSTRING(segundoApellido, 1, 1))) as [minLetra]
from Alumnos



---- 4. Actualizar el número telefónico de los instructores para que los dos primeros
----dígitos sean 55, en caso de que de acuerdo al curp sean del DF

select * from Instructores
INSERT INTO Instructores
VALUES('David', 'Garcia', 'Perez', 'da@gmail.com',7861266114,'1997-02-19','DUHD970219A6','DUHD970219HDFLSv06', 200, 1);

select telefono,curp, SUBSTRING(curp, 12, 2) as [estado curp], SUBSTRING(telefono, 1, 2) as [lada] 
from Instructores

	UPDATE ins SET ins.telefono = REPLACE(telefono, SUBSTRING(telefono, 1, 2), '55')
	FROM Instructores ins
	WHERE SUBSTRING(curp, 12, 2) = 'DF'


----5. Subirles un punto en la calificación a los alumnos de Hidalgo y Oaxaca, 
--- y del Curso impartido en junio de 2021. Se deberá considerar 
---que al incrementar el punto no exceda del máximo de la calificación permitida.


select * from Alumnos

select * from CursosAlumnos

select a.id, a.nombre,e.nombre, ca.calificacion, ca.fechaInscripcion,
avg(ca.calificacion) as [promedio], sum(ca.calificacion)+1 as [Mas 1] from Alumnos a
inner join CursosAlumnos ca on a.id = ca.idAlumno 
inner join Estados e on a.idEstadoOrigen = e.id 
where e.nombre = 'Hidalgo' or e.nombre = 'Oaxaca' 
and ca.fechaInscripcion like '%2024-06%'
group by a.id, a.nombre,e.nombre, ca.calificacion, ca.fechaInscripcion
having sum(ca.calificacion)+ 1 <= 100

select * from Estados

select * from CursosAlumnos

	UPDATE Ca SET Ca.calificacion = (ca.calificacion)+10
	FROM  Alumnos a 
	inner join CursosAlumnos ca on a.id = ca.idAlumno 
	inner join Estados e on a.idEstadoOrigen = e.id 
	WHERE (e.nombre = 'Hidalgo' or e.nombre = 'Oaxaca') and ca.calificacion < 100
	and ca.fechaInscripcion like '%2024-06%'


---- 6. Subirle el 10% de la cuota por hora a los profesores que han 
---impartido el curso de Desarrollador .Net


select * from CursosInstructores
select * from CatCursos
select * from Cursos


select cc.nombre,c.idCatCurso, ci.idInstructor, i.cuotaHora from Instructores i
inner join CursosInstructores ci on ci.idInstructor = i.id
inner join Cursos c on ci.idCurso = c.id
inner join CatCursos cc on c.idCatCurso = cc.id
where cc.nombre = 'Desarrollador .Net'

select * from Instructores

	UPDATE i SET i.cuotaHora = (i.cuotaHora)*(10)/100+(i.cuotaHora)
	FROM Instructores i 
	inner join CursosInstructores ci on ci.idInstructor = i.id
inner join Cursos c on ci.idCurso = c.id
inner join CatCursos cc on c.idCatCurso = cc.id
where cc.nombre = 'Desarrollador .Net'

---7. En la Base de Datos Ejercicios realice lo siguiente:


--a. Copiar la Tabla de Alumnos de la Base de Datos InstitutoTich a la Tabla AlumnosTodos
use EjerciciosTich
select * INTO EjerciciosTich.dbo.AlumnosTodos FROM InstitutoTich.dbo.Alumnos

select * from AlumnosTodos

drop table AlumnosTodos
drop table AlumnosHgo
--b. Copiar a los alumnos de Hidalgo de la Tabla de Alumnos de la Base de Datos 
--InstitutoTich a la Tabla AlumnosHgo
use InstitutoTich

select a.nombre, a.segundoApellido,a.segundoApellido,
a.correo, a.telefono, a.fechaNacimiento,a.curp, a.sueldo,
a.idEstadoOrigen, a.idEstatus from Alumnos a
inner join Estados e on a.idEstadoOrigen = e.id
where e.nombre = 'Hidalgo'

SELECT a.id,a.nombre, a.primerApellido,a.segundoApellido,
a.correo, a.telefono, a.fechaNacimiento,a.curp, a.sueldo,
a.idEstadoOrigen, a.idEstatus
INTO EjerciciosTich.dbo.AlumnosHgo
 FROM Alumnos a
inner join Estados e on a.idEstadoOrigen = e.id
WHERE e.nombre = 'Hidalgo'

use EjerciciosTich

drop table AlumnosHgo
select * from AlumnosHgo
---https://robertomiguelz.blogspot.com/2018/08/copiar-tablas-en-sql-server-con-select.html--


--c. En la Tabla AlumnosHgo cambiarles el número telefónico inicie con 77, 
--mediante la instrucción update

use EjerciciosTich
select * from AlumnosHgo

select telefono, SUBSTRING(telefono, 1, 2) as [lada] 
from AlumnosHgo

	UPDATE ah SET ah.telefono = REPLACE(telefono, SUBSTRING(telefono, 1, 2), '77')
	FROM AlumnosHgo ah

--d. Actualizar el teléfono de la tabla AlumnosTodos obtenidos desde la taba AlumnosHgo


select ah.telefono from AlumnosTodos att
inner join AlumnosHgo ah on att.id = ah.id

	UPDATE att SET att.telefono = ah.telefono
	FROM AlumnosTodos att
	inner join AlumnosHgo ah on att.id = ah.id
	where att.id = ah.id

select * from AlumnosHgo

select * from AlumnosTodos