---------------------------------------------
use InstitutoTich
---------------------------------------------

-- crear tabla estados
drop table Estados

create table Estados(
id int primary key identity(1,1) not null, 
nombre varchar(100) null)

-- crear tabla EstatusAlumnos

drop table EstatusAlumnos

create table EstatusAlumnos(
id smallint primary key identity(1,1) not null, 
Clave char(10) not null, 
Nombre varchar(100) not null)

---- Crear tabla CatCursos

create table CatCursos(
id smallint primary key identity(1,1) not null,
clave varchar(15) not null,
nombre varchar(50) not null, 
descripcion varchar(1000) null, 
horas tinyint not null, 
idPreRequisito smallint null,
activo bit not null)

-- crear tabla Cursos
drop table Cursos

CREATE TABLE Cursos (
id smallint PRIMARY KEY IDENTITY(1,1) not null,
idCatCurso smallint null, 
fechaInicio date null,
fechatermino date null,
activo bit null,
CONSTRAINT fkidCatCurso FOREIGN KEY(idCatCurso)
REFERENCES CatCursos (id))


-- crear tablas Alumnos

drop table Alumnos

create table Alumnos (
id int primary key identity(1,1) not null,
nombre varchar(60) not null,
primerApellido varchar(50) not null,
segundoApellido varchar(50) null,
correo varchar(80) not null,
telefono nchar(10)not null,
fechaNacimiento date not null,
curp char(18) not null,
sueldo decimal(9,2) null,
idEstadoOrigen int not null,
idEstatus smallint not null,
CONSTRAINT fkEstadoOrigen FOREIGN KEY(idEstadoOrigen)
REFERENCES Estados (id),
CONSTRAINT fkidEstatus FOREIGN KEY(idEstatus)
REFERENCES EstatusAlumnos (id))

-- crear tabla Instructores
create table Instructores(
id int primary key identity(1,1) not null,
nombre varchar(60) not null,
primerApellido varchar(50) not null,
segundoApellido varchar(50) null,
correo varchar(80) not null,
telefono nchar(10)not null,
fechaNacimiento date not null,
rfc char(13) not null,
curp char(18) not null,
cuotaHora decimal(9,2) not null,
activo bit not null)

-- crear tabla AlumnosBaja
-----crear tabla sin cascade----
create table CursosAlumnos(
id int primary key identity(1,1) not null,
idCurso smallint not null,
idAlumno int not null,
fechaInscripcion date not null,
fechaBaja date null,
calificacion tinyint null,
CONSTRAINT fkidCurso FOREIGN KEY(idCurso)
REFERENCES Cursos (id),
CONSTRAINT fkidAlumno FOREIGN KEY(idAlumno)
REFERENCES Alumnos (id))
--------------------------------------------------
drop table CursosAlumnos
---- crear tabla con cascade--
create table CursosAlumnos(
id int primary key identity(1,1) not null,
idCurso smallint not null,
idAlumno int not null,
fechaInscripcion date not null,
fechaBaja date null,
calificacion tinyint null,
CONSTRAINT fkidCurso FOREIGN KEY(idCurso)
REFERENCES Cursos (id),
CONSTRAINT fkidAlumno FOREIGN KEY(idAlumno)
REFERENCES Alumnos (id)
ON DELETE CASCADE ON UPDATE CASCADE)

-------------------------------------------------
-- crear tabla CursosAlumnos

drop table CursosInstructores
-----SIN CASCADE----
create table CursosInstructores(
id int primary key identity(1,1) not null,
idCurso smallint not null,
idInstructor int not null,
fechaContratacion date null,
CONSTRAINT fkidCursoInstructores FOREIGN KEY(idCurso)
REFERENCES Cursos (id),
CONSTRAINT fkidInstructor FOREIGN KEY(idInstructor)
REFERENCES Instructores (id))
---------------------------------------------------
----CON CASCADE----
create table CursosInstructores(
id int primary key identity(1,1) not null,
idCurso smallint not null,
idInstructor int not null,
fechaContratacion date null,
CONSTRAINT fkidCursoInstructores FOREIGN KEY(idCurso)
REFERENCES Cursos (id),
CONSTRAINT fkidInstructor FOREIGN KEY(idInstructor)
REFERENCES Instructores (id)
ON DELETE CASCADE ON UPDATE CASCADE)
----------------------------------------------
-- crear tabla de AlumnosBaja
create table AlumnosBaja (
id int primary key identity(1,1) not null,
nombre varchar(60) not null,
primerApellido varchar(50) not null,
segundoApellido varchar(50) null, 
fechabaja datetime not null)
-------------------------------------------------

--- crear tabla TablaISR
create table TablaISR (
id int primary key identity(1,1) not null,
limInf int not null,
limSup int not null,
cuotaFija int not null,
exedLimInf int not null,
subsidio int not null)











