use InstitutoTich
-----Agregar los registros a la Tabla de Estados proporcionados en el script correspondiente----
SET IDENTITY_INSERT [Estados] ON 

INSERT [dbo].[Estados] ([id], [nombre]) VALUES (1, N'Aguascalientes')
INSERT [dbo].[Estados] ([id], [nombre]) VALUES (2, N'Baja California')
INSERT [dbo].[Estados] ([id], [nombre]) VALUES (3, N'Baja California Sur')
INSERT [dbo].[Estados] ([id], [nombre]) VALUES (4, N'Campeche')
INSERT [dbo].[Estados] ([id], [nombre]) VALUES (5, N'Chihuahua')
INSERT [dbo].[Estados] ([id], [nombre]) VALUES (6, N'Chiapas')
INSERT [dbo].[Estados] ([id], [nombre]) VALUES (7, N'Coahuila')
INSERT [dbo].[Estados] ([id], [nombre]) VALUES (8, N'Colima')
INSERT [dbo].[Estados] ([id], [nombre]) VALUES (9, N'Durango')
INSERT [dbo].[Estados] ([id], [nombre]) VALUES (10, N'Guanajuato')
INSERT [dbo].[Estados] ([id], [nombre]) VALUES (11, N'Guerrero')
INSERT [dbo].[Estados] ([id], [nombre]) VALUES (12, N'Hidalgo')
INSERT [dbo].[Estados] ([id], [nombre]) VALUES (13, N'Jalisco')
INSERT [dbo].[Estados] ([id], [nombre]) VALUES (14, N'México')
INSERT [dbo].[Estados] ([id], [nombre]) VALUES (15, N'Michoacán')
INSERT [dbo].[Estados] ([id], [nombre]) VALUES (16, N'Morelos')
INSERT [dbo].[Estados] ([id], [nombre]) VALUES (17, N'Nayarit')
INSERT [dbo].[Estados] ([id], [nombre]) VALUES (18, N'Nuevo León')
INSERT [dbo].[Estados] ([id], [nombre]) VALUES (19, N'Oaxaca')
INSERT [dbo].[Estados] ([id], [nombre]) VALUES (20, N'Puebla')
INSERT [dbo].[Estados] ([id], [nombre]) VALUES (21, N'Querétaro')
INSERT [dbo].[Estados] ([id], [nombre]) VALUES (22, N'Quintana Roo')
INSERT [dbo].[Estados] ([id], [nombre]) VALUES (23, N'San Luis Potosí')
INSERT [dbo].[Estados] ([id], [nombre]) VALUES (24, N'Sinaloa')
INSERT [dbo].[Estados] ([id], [nombre]) VALUES (25, N'Sonora')
INSERT [dbo].[Estados] ([id], [nombre]) VALUES (26, N'Tabasco')
INSERT [dbo].[Estados] ([id], [nombre]) VALUES (27, N'Tamaulipas')
INSERT [dbo].[Estados] ([id], [nombre]) VALUES (28, N'Tlaxcala')
INSERT [dbo].[Estados] ([id], [nombre]) VALUES (29, N'Veracruz')
INSERT [dbo].[Estados] ([id], [nombre]) VALUES (30, N'Yucatán')
INSERT [dbo].[Estados] ([id], [nombre]) VALUES (31, N'Zacatecas')

SET IDENTITY_INSERT [Estados] OFF


select * from Estados

------Agregar los registros a la Tabla de EstatusAlumno proporcionados en el script correspondiente----
SET IDENTITY_INSERT [dbo].[EstatusAlumnos] ON 
INSERT [dbo].[EstatusAlumnos] ([id], [Clave], [Nombre]) VALUES (1, N'PTO       ', N'Prospecto')
INSERT [dbo].[EstatusAlumnos] ([id], [Clave], [Nombre]) VALUES (2, N'PRO       ', N'En curso propedéutico')
INSERT [dbo].[EstatusAlumnos] ([id], [Clave], [Nombre]) VALUES (3, N'CAP       ', N'En capacitación')
INSERT [dbo].[EstatusAlumnos] ([id], [Clave], [Nombre]) VALUES (4, N'INC       ', N'En Incursión')
INSERT [dbo].[EstatusAlumnos] ([id], [Clave], [Nombre]) VALUES (5, N'LAB       ', N'Laborando')
INSERT [dbo].[EstatusAlumnos] ([id], [Clave], [Nombre]) VALUES (6, N'LIB       ', N'Liberado')
INSERT [dbo].[EstatusAlumnos] ([id], [Clave], [Nombre]) VALUES (7, N'NI        ', N'No le interesó')
INSERT [dbo].[EstatusAlumnos] ([id], [Clave], [Nombre]) VALUES (8, N'BA        ', N'Baja')

SET IDENTITY_INSERT [dbo].[EstatusAlumnos] OFF 

----Agregar al menos cuatro registros a la Tabla de CatCursos donde dos de ellos
---deberán tener como prerrequisito otro curso de esta misma tabla----

GO
SET IDENTITY_INSERT [dbo].[CatCursos] ON 

INSERT [dbo].[CatCursos] ([id], [clave], [nombre], [descripcion], [horas], [idPreRequisito], [activo]) VALUES (1,N'Prog', N'Programacion 1', N'Programa ya', 10,null, 1)
INSERT [dbo].[CatCursos] ([id], [clave], [nombre], [descripcion], [horas], [idPreRequisito], [activo]) VALUES (2,N'bd', N'Base Datos 1', N'aprende bd ya', 11, null, 1)
INSERT [dbo].[CatCursos] ([id], [clave], [nombre], [descripcion], [horas], [idPreRequisito], [activo]) VALUES (3,N'prog2', N'Programacion 2', N'Lee ya', 12, 1, 1)
INSERT [dbo].[CatCursos] ([id], [clave], [nombre], [descripcion], [horas], [idPreRequisito], [activo]) VALUES (4,N'bd2', N'Base Datos 2', N'experto en bd ya', 13, 2, 1)
SET IDENTITY_INSERT [dbo].[CatCursos] OFF
GO

select * from CatCursos

-----Agregar al menos seis registros a la Tabla de Cursos,
---donde se deberá referenciar a todos los registros que están en CatCursos----
SET IDENTITY_INSERT [dbo].[Cursos] ON 

INSERT [dbo].[Cursos] ([id], [idCatCurso], [fechaInicio], [fechatermino], [activo]) VALUES (1, 1, N'09/03/01', N'10/06/01', 1)
INSERT [dbo].[Cursos] ([id], [idCatCurso], [fechaInicio], [fechatermino], [activo]) VALUES (2, 2, N'09/06/27', N'10/09/27', 1)
INSERT [dbo].[Cursos] ([id], [idCatCurso], [fechaInicio], [fechatermino], [activo]) VALUES (3, 3, N'11/05/2', N'11/08/22', 1)
INSERT [dbo].[Cursos] ([id], [idCatCurso], [fechaInicio], [fechatermino], [activo]) VALUES (4, 4, N'12/01/30', N'12/03/30', 1)
INSERT [dbo].[Cursos] ([id], [idCatCurso], [fechaInicio], [fechatermino], [activo]) VALUES (5, 1, N'13/08/3', N'13/11/3', 1)
INSERT [dbo].[Cursos] ([id], [idCatCurso], [fechaInicio], [fechatermino], [activo]) VALUES (6, 2, N'14/09/4', N'14/12/15', 1)
SET IDENTITY_INSERT [dbo].[Cursos] OFF
GO

select * from Cursos

----Agregar dos registros en la tabla Alumnos, por cada uno de los cursos que se encuentren en la Cursos----
SET IDENTITY_INSERT [dbo].[Alumnos] ON 
INSERT [dbo].[Alumnos] ([id], [nombre], [primerApellido], [segundoApellido], [correo], [telefono], [fechaNacimiento], [curp], [sueldo], [idEstadoOrigen], [idEstatus]) VALUES (1, N'Marcelo Isai a', N'García', N'Mirón', N'marcelo@outlook.com', N'9911362600', CAST(N'1997-12-12' AS Date), N'MADA971212HVZRMN04', CAST(22000.00 AS Decimal(9, 2)), 29, 6)
INSERT [dbo].[Alumnos] ([id], [nombre], [primerApellido], [segundoApellido], [correo], [telefono], [fechaNacimiento], [curp], [sueldo], [idEstadoOrigen], [idEstatus]) VALUES (2, N'Oliver Alexis', N'Martínez', N'Estudillo', N'alexis@gmail.com', N'8897877417', CAST(N'1996-04-18' AS Date), N'DIAE960418HOCSVL07', CAST(20000.00 AS Decimal(9, 2)), 19, 6)
INSERT [dbo].[Alumnos] ([id], [nombre], [primerApellido], [segundoApellido], [correo], [telefono], [fechaNacimiento], [curp], [sueldo], [idEstadoOrigen], [idEstatus]) VALUES (3, N'Oscar', N'Mendoza', N'García', N'omscar@outlook.es', N'7711589568', CAST(N'1994-04-07' AS Date), N'RUVJ940407HOCSSN03', NULL, 29, 4)
INSERT [dbo].[Alumnos] ([id], [nombre], [primerApellido], [segundoApellido], [correo], [telefono], [fechaNacimiento], [curp], [sueldo], [idEstadoOrigen], [idEstatus]) VALUES (4, N'Edgar', N'Martínez', N'Espinoza', N'edgargmail.com', N'5528356144', CAST(N'1996-05-23' AS Date), N'DOML960323HMNMTS00', CAST(25000.00 AS Decimal(9, 2)), 12, 5)
INSERT [dbo].[Alumnos] ([id], [nombre], [primerApellido], [segundoApellido], [correo], [telefono], [fechaNacimiento], [curp], [sueldo], [idEstadoOrigen], [idEstatus]) VALUES (5, N'Rodrigo', N'Tolentino', N'Martínez', N'rodrigo@gmail.com', N'4421436224', CAST(N'1998-03-13' AS Date), N'TOMR980313HHGLRD06', NULL, 13, 5)
INSERT [dbo].[Alumnos] ([id], [nombre], [primerApellido], [segundoApellido], [correo], [telefono], [fechaNacimiento], [curp], [sueldo], [idEstadoOrigen], [idEstatus]) VALUES (6, N'Jesiel', N'García', N'Pérez', N'jesiel@gmail.com', N'3317901341', CAST(N'1990-11-08' AS Date), N'GAPJ901108HHGRRS00', NULL, 13, 5)
INSERT [dbo].[Alumnos] ([id], [nombre], [primerApellido], [segundoApellido], [correo], [telefono], [fechaNacimiento], [curp], [sueldo], [idEstadoOrigen], [idEstatus]) VALUES (7, N'Christian Josue ', N'Gonzalez', N'Lozano', N'christian@gmail.com', N'4922153353', CAST(N'1996-06-19' AS Date), N'GOLC960619HZSNZH08', NULL, 16, 4)
INSERT [dbo].[Alumnos] ([id], [nombre], [primerApellido], [segundoApellido], [correo], [telefono], [fechaNacimiento], [curp], [sueldo], [idEstadoOrigen], [idEstatus]) VALUES (8, N'Luis Enrique', N'Lopez ', N'Cruz', N'luis@gmail.com', N'2235700644', CAST(N'1997-07-15' AS Date), N'LOCL970715HGTPRS04', NULL, 16, 5)
INSERT [dbo].[Alumnos] ([id], [nombre], [primerApellido], [segundoApellido], [correo], [telefono], [fechaNacimiento], [curp], [sueldo], [idEstadoOrigen], [idEstatus]) VALUES (9, N'Rolando', N'Marquez', N'Hernandez', N'rolando@gmail.com', N'1168329969', CAST(N'1997-03-08' AS Date), N'MAHR97030815HRL600', NULL, 15, 4)
INSERT [dbo].[Alumnos] ([id], [nombre], [primerApellido], [segundoApellido], [correo], [telefono], [fechaNacimiento], [curp], [sueldo], [idEstadoOrigen], [idEstatus]) VALUES (10, N'Jesús Yotecatl', N'Miranda', N'Espinosa', N'jesus@gmail.com', N'2213335247', CAST(N'1997-06-14' AS Date), N'MIEJ970614HMCRSS05', NULL, 15, 4)
INSERT [dbo].[Alumnos] ([id], [nombre], [primerApellido], [segundoApellido], [correo], [telefono], [fechaNacimiento], [curp], [sueldo], [idEstadoOrigen], [idEstatus]) VALUES (11, N'Cecilia', N'Cruz', N'Luna', N'cecilia@outlook.com', N'3317052376', CAST(N'1997-08-08' AS Date), N'CULC970808MPLRNC02', CAST(22000.00 AS Decimal(9, 2)), 21, 4)
INSERT [dbo].[Alumnos] ([id], [nombre], [primerApellido], [segundoApellido], [correo], [telefono], [fechaNacimiento], [curp], [sueldo], [idEstadoOrigen], [idEstatus]) VALUES (12, N'Baldomero', N'Gómez', N'García', N'baldomero@gmail.com', N'4419055010', CAST(N'2000-11-08' AS Date), N'GOGB001108HPLMRLA2', CAST(23000.00 AS Decimal(9, 2)), 21, 4)
SET IDENTITY_INSERT [dbo].[Alumnos] OFF
GO

-------Agregar al menos cuatro registros en la tabla Instructores-----
SET IDENTITY_INSERT [dbo].[Instructores] ON 

INSERT [dbo].[Instructores] ([id], [nombre], [primerApellido], [segundoApellido], [correo], [telefono], [fechaNacimiento], [rfc], [curp], [cuotaHora], [activo]) VALUES (1, N'Oscar', N'López', N'Osorio', N'olopez@ti-capitalhumano.com', N'7226181450', CAST(N'1984-08-03' AS Date), N'LOOO840803S08', N'LOOO840803HMCPSS08', CAST(110.00 AS Decimal(9, 2)), 1)
INSERT [dbo].[Instructores] ([id], [nombre], [primerApellido], [segundoApellido], [correo], [telefono], [fechaNacimiento], [rfc], [curp], [cuotaHora], [activo]) VALUES (2, N'Jorge', N'Valdivia', N'Rosas', N'jvaldivia@ti-capitalhumano.com', N'5561040510', CAST(N'1964-01-26' AS Date), N'VARJ640126R00', N'VARJ640126HDFLSR00', CAST(100.00 AS Decimal(9, 2)), 1)
INSERT [dbo].[Instructores] ([id], [nombre], [primerApellido], [segundoApellido], [correo], [telefono], [fechaNacimiento], [rfc], [curp], [cuotaHora], [activo]) VALUES (3, N'Luis', N'Vázquez', N'Cuj', N'luisvazquez@ti-capitalhumano.com', N'5540612941', CAST(N'1974-10-11' AS Date), N'VACL741011JS5', N'VACL741011HTCZJS05', CAST(80.00 AS Decimal(9, 2)), 1)
INSERT [dbo].[Instructores] ([id], [nombre], [primerApellido], [segundoApellido], [correo], [telefono], [fechaNacimiento], [rfc], [curp], [cuotaHora], [activo]) VALUES (4, N'José', N'Morales', N'Narváez', N'jose.morales@ti-capitalhumano.com', N'5511506288', CAST(N'1984-12-31' AS Date), N'MONM941231N07', N'MONM941231HCCRRN07', CAST(70.00 AS Decimal(9, 2)), 1)
SET IDENTITY_INSERT [dbo].[Instructores] OFF
GO

select * from Instructores

-----Agregar los registros necesarios a la Tabla CursosAlumnos
----para cumplir con lo indicado en el punto 5 de estos ejercicios.----

SET IDENTITY_INSERT [dbo].[CursosAlumnos] ON 

INSERT [dbo].[CursosAlumnos] ([id], [idCurso], [idAlumno], [fechaInscripcion], [fechaBaja], [calificacion]) VALUES (1, 1, 1, CAST(N'2024-06-09' AS Date), CAST(N'2025-02-09' AS Date), 100)
INSERT [dbo].[CursosAlumnos] ([id], [idCurso], [idAlumno], [fechaInscripcion], [fechaBaja], [calificacion]) VALUES (2, 1, 2, CAST(N'2024-06-09' AS Date), CAST(N'2025-02-09' AS Date), 90)
INSERT [dbo].[CursosAlumnos] ([id], [idCurso], [idAlumno], [fechaInscripcion], [fechaBaja], [calificacion]) VALUES (3, 2, 3, CAST(N'2024-06-09' AS Date), CAST(N'2025-02-09' AS Date), 80)
INSERT [dbo].[CursosAlumnos] ([id], [idCurso], [idAlumno], [fechaInscripcion], [fechaBaja], [calificacion]) VALUES (4, 2, 4, CAST(N'2024-06-09' AS Date), CAST(N'2025-02-09' AS Date), 90)
INSERT [dbo].[CursosAlumnos] ([id], [idCurso], [idAlumno], [fechaInscripcion], [fechaBaja], [calificacion]) VALUES (5, 3, 5, CAST(N'2024-06-09' AS Date), CAST(N'2025-02-09' AS Date), 50)
INSERT [dbo].[CursosAlumnos] ([id], [idCurso], [idAlumno], [fechaInscripcion], [fechaBaja], [calificacion]) VALUES (6, 3, 6, CAST(N'2024-06-09' AS Date), CAST(N'2025-02-09' AS Date), 60)
INSERT [dbo].[CursosAlumnos] ([id], [idCurso], [idAlumno], [fechaInscripcion], [fechaBaja], [calificacion]) VALUES (7, 4, 7, CAST(N'2024-06-09' AS Date), CAST(N'2025-02-09' AS Date), 80)
INSERT [dbo].[CursosAlumnos] ([id], [idCurso], [idAlumno], [fechaInscripcion], [fechaBaja], [calificacion]) VALUES (8, 4, 8, CAST(N'2024-06-09' AS Date), CAST(N'2025-02-09' AS Date),40)

SET IDENTITY_INSERT [dbo].[CursosAlumnos] OFF
GO
select * from CursosAlumnos

------- Agregar los registros necesarios a la Tabla CursosInstructores
-----para que cada curso haya sido impartido por al menos 2 instructores.-----

SET IDENTITY_INSERT [dbo].[CursosInstructores] ON 

INSERT [dbo].[CursosInstructores] ([id], [idCurso], [idInstructor], [fechaContratacion]) VALUES (1,1, 1, CAST(N'2018-01-01' AS Date))
INSERT [dbo].[CursosInstructores] ([id], [idCurso], [idInstructor], [fechaContratacion]) VALUES (2,1, 1, CAST(N'2018-02-02' AS Date))
INSERT [dbo].[CursosInstructores] ([id], [idCurso], [idInstructor], [fechaContratacion]) VALUES (3,2, 2, CAST(N'2019-03-03' AS Date))
INSERT [dbo].[CursosInstructores] ([id], [idCurso], [idInstructor], [fechaContratacion]) VALUES (4,2, 2, CAST(N'2017-04-04' AS Date))
INSERT [dbo].[CursosInstructores] ([id], [idCurso], [idInstructor], [fechaContratacion]) VALUES (5,3, 3, CAST(N'2016-06-06' AS Date))
INSERT [dbo].[CursosInstructores] ([id], [idCurso], [idInstructor], [fechaContratacion]) VALUES (6,3, 3, CAST(N'2022-07-07' AS Date))
INSERT [dbo].[CursosInstructores] ([id], [idCurso], [idInstructor], [fechaContratacion]) VALUES (7,4, 4, CAST(N'2021-08-08' AS Date))
INSERT [dbo].[CursosInstructores] ([id], [idCurso], [idInstructor], [fechaContratacion]) VALUES (8,4, 4, CAST(N'2015-09-09' AS Date))


SET IDENTITY_INSERT [dbo].[CursosInstructores] OFF
GO

select * from CursosInstructores
