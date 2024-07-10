use InstitutoTich

------- 1. Obtener una consulta que contenga el Nombre y apellidos, 
---mes y día de nacimiento de todos los alumnos y profesores, 
---ordenado por tipo persona, mes y día de nacimiento

SELECT 'Alumno' as TipoPersona,nombre, month(fechaNacimiento) as [Mes],day(fechaNacimiento) as [Dia]
	FROM Alumnos
	UNION 
	SELECT 'Profesor' as TipoPersona, nombre,  month(fechaNacimiento)as [Mes],day(fechaNacimiento) as [Dia]
	FROM Instructores
	ORDER BY TipoPersona, month(fechaNacimiento), day(fechaNacimiento)

