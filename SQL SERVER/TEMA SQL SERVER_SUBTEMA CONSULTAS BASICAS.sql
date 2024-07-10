use InstitutoTich

Select * from Alumnos

--- seleccionar alumnos por apellido
select primerApellido, segundoApellido, nombre, telefono, correo from Alumnos;

--- consulta los instructores---
Select * from Instructores
select nombre, primerApellido, segundoApellido, rfc, cuotaHora from Instructores;

--Realizar la siguiente consulta de CatCusos--
Select * from CatCursos

select clave,nombre, descripcion, horas from CatCursos;

--Realizar la consulta de los 5 alumnos más jóvenes---
Select * from Alumnos
select top (5) nombre, fechaNacimiento from alumnos WHERE fechanacimiento IN (SELECT MIN(fechanacimiento)FROM alumnos GROUP BY fechaNacimiento)

--- Crear la Base de datos Ejercicios----

create database EjerciciosTich

----- Copiar las tablas de Alumnos desde la Base de Datos InstitutoTich a la de Ejercicios

SELECT *
INTO EjerciciosTich.dbo.Alumnos
FROM InstitutoTich.dbo.Alumnos;

---- Copiar las tablas de Instructores desde la Base de Datos InstitutoTich a la de Ejercicios
SELECT *
INTO EjerciciosTich.dbo.Instructores
FROM InstitutoTich.dbo.Instructores;

