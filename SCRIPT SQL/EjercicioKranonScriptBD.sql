USE [master]
GO
/****** Object:  Database [EjercicioKranon]    Script Date: 05/07/2022 07:23:47 p. m. ******/
CREATE DATABASE [EjercicioKranon]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EjercicioKranon', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\EjercicioKranon.mdf' , SIZE = 10304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'EjercicioKranon_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\EjercicioKranon_log.ldf' , SIZE = 10368KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [EjercicioKranon] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EjercicioKranon].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EjercicioKranon] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EjercicioKranon] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EjercicioKranon] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EjercicioKranon] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EjercicioKranon] SET ARITHABORT OFF 
GO
ALTER DATABASE [EjercicioKranon] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EjercicioKranon] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [EjercicioKranon] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EjercicioKranon] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EjercicioKranon] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EjercicioKranon] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EjercicioKranon] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EjercicioKranon] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EjercicioKranon] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EjercicioKranon] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EjercicioKranon] SET  ENABLE_BROKER 
GO
ALTER DATABASE [EjercicioKranon] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EjercicioKranon] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EjercicioKranon] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EjercicioKranon] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EjercicioKranon] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EjercicioKranon] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EjercicioKranon] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EjercicioKranon] SET RECOVERY FULL 
GO
ALTER DATABASE [EjercicioKranon] SET  MULTI_USER 
GO
ALTER DATABASE [EjercicioKranon] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EjercicioKranon] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EjercicioKranon] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EjercicioKranon] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'EjercicioKranon', N'ON'
GO
USE [EjercicioKranon]
GO
/****** Object:  StoredProcedure [dbo].[AutorAdd]    Script Date: 05/07/2022 07:23:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AutorAdd]
@Nombre VARCHAR(50)
,@ApellidoPaterno VARCHAR(50)
      ,@ApellidoMaterno VARCHAR(50)
      ,@FechaNacimiento DATE
      ,@LugarNacimiento VARCHAR(50)
AS
INSERT INTO Autor ([Nombre],[ApellidoPaterno],[ApellidoMaterno],[FechaNacimiento],[LugarNacimiento])
VALUES (@Nombre, @ApellidoPaterno, @ApellidoMaterno, @FechaNacimiento, @LugarNacimiento)
GO
/****** Object:  StoredProcedure [dbo].[AutorDelete]    Script Date: 05/07/2022 07:23:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AutorDelete]
	@IdAutor INT
	AS
	DELETE FROM Autor
	WHERE IdAutor = @IdAutor
GO
/****** Object:  StoredProcedure [dbo].[AutorGetAll]    Script Date: 05/07/2022 07:23:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AutorGetAll]
AS
SELECT 
	IdAutor,
	Nombre + ' ' + ApellidoPaterno + ' ' + ApellidoMaterno as NombreCompleto,
	FechaNacimiento,
	LugarNacimiento

FROM Autor
GO
/****** Object:  StoredProcedure [dbo].[AutorGetById]    Script Date: 05/07/2022 07:23:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AutorGetById]
@IdAutor INT
AS
SELECT 
		IdAutor,
		Nombre, 
		ApellidoPaterno, 
		ApellidoMaterno, 
		FechaNacimiento, 
		LugarNacimiento
FROM Autor
WHERE IdAutor = @IdAutor
GO
/****** Object:  StoredProcedure [dbo].[AutorUpdate]    Script Date: 05/07/2022 07:23:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AutorUpdate]
	
	@IdAutor INT
	,@Nombre VARCHAR(50)
	,@ApellidoPaterno VARCHAR(50)
    ,@ApellidoMaterno VARCHAR(50)
    ,@FechaNacimiento DATE
    ,@LugarNacimiento VARCHAR(50)
AS
UPDATE Autor
SET 
	Nombre = @Nombre,
	ApellidoPaterno = @ApellidoPaterno,
	ApellidoMaterno = @ApellidoMaterno,
	FechaNacimiento = @FechaNacimiento,
	LugarNacimiento = @LugarNacimiento
	
WHERE IdAutor = @IdAutor
GO
/****** Object:  StoredProcedure [dbo].[Busqueda]    Script Date: 05/07/2022 07:23:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Busqueda] 
@Titulo VARCHAR (50), 
@IdAutor INT,
@IdEditorial INT,
@AñoPublicacion VARCHAR (50)
AS

IF @IdAutor = 0 AND @IdEditorial = 0
BEGIN
SELECT 
	IdLibro,
	Titulo,
	AñoPublicacion,
	[Libro].IdEditorial,
	[Editorial].Nombre as EditorialNombre,
	[Libro].IdAutor,
	[Autor].Nombre as AutorNombre,
	[Libro].IdGenero,
	[Genero].Nombre as GeneroNombre,
	NumeroPaginas,
	Descripcion,
	Imagen
FROM Libro

INNER JOIN Editorial
ON Libro.IdEditorial = Editorial.IdEditorial

INNER JOIN Autor
ON Libro.IdAutor = Autor.IdAutor

INNER JOIN Genero
ON Libro.IdGenero = Genero.IdGenero
WHERE Titulo LIKE '%' + @Titulo + '%' AND AñoPublicacion = @AñoPublicacion
END 
ELSE
BEGIN
SELECT 
	IdLibro,
	Titulo,
	AñoPublicacion,
	[Libro].IdEditorial,
	[Editorial].Nombre as EditorialNombre,
	[Libro].IdAutor,
	[Autor].Nombre as AutorNombre,
	[Libro].IdGenero,
	[Genero].Nombre as GeneroNombre,
	NumeroPaginas,
	Descripcion,
	Imagen
FROM Libro

INNER JOIN Editorial
ON Libro.IdEditorial = Editorial.IdEditorial

INNER JOIN Autor
ON Libro.IdAutor = Autor.IdAutor

INNER JOIN Genero
ON Libro.IdGenero = Genero.IdGenero

WHERE Titulo LIKE '%' + @Titulo + '%' AND AñoPublicacion = @AñoPublicacion AND Libro.IdAutor = @IdAutor AND Libro.IdEditorial = @IdEditorial AND AñoPublicacion = @AñoPublicacion
END

GO
/****** Object:  StoredProcedure [dbo].[EditorialAdd]    Script Date: 05/07/2022 07:23:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditorialAdd]
@Nombre VARCHAR(50),
@Direccion VARCHAR(50)
AS
INSERT INTO Editorial (Nombre, Direccion)
VALUES (@Nombre, @Direccion)
GO
/****** Object:  StoredProcedure [dbo].[EditorialDelete]    Script Date: 05/07/2022 07:23:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditorialDelete]
@IdEditorial INT
AS
DELETE FROM Editorial
WHERE IdEditorial = @IdEditorial
GO
/****** Object:  StoredProcedure [dbo].[EditorialGetAll]    Script Date: 05/07/2022 07:23:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditorialGetAll]
AS
SELECT 
	IdEditorial,
	Nombre,
	Direccion

FROM Editorial
GO
/****** Object:  StoredProcedure [dbo].[EditorialGetById]    Script Date: 05/07/2022 07:23:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditorialGetById]
@IdEditorial INT
AS
	SELECT 
			IdEditorial,
			Nombre,
			Direccion
	FROM Editorial
WHERE IdEditorial = @IdEditorial
GO
/****** Object:  StoredProcedure [dbo].[EditorialUpdate]    Script Date: 05/07/2022 07:23:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditorialUpdate]
	
	@IdEditorial INT,
	@Nombre VARCHAR (50),
	@Direccion VARCHAR (50)
AS
UPDATE Editorial
SET 
	Nombre = @Nombre,
	Direccion = @Direccion

WHERE IdEditorial = @IdEditorial
GO
/****** Object:  StoredProcedure [dbo].[GeneroAdd]    Script Date: 05/07/2022 07:23:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GeneroAdd]
@Nombre VARCHAR(50)
AS
INSERT INTO Genero (Nombre) VALUES (@Nombre)
GO
/****** Object:  StoredProcedure [dbo].[GeneroDelete]    Script Date: 05/07/2022 07:23:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GeneroDelete] 
@IdGenero INT
AS
DELETE FROM Genero
WHERE IdGenero = @IdGenero
GO
/****** Object:  StoredProcedure [dbo].[GeneroGetAll]    Script Date: 05/07/2022 07:23:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GeneroGetAll]
AS
SELECT 
	IdGenero,
	Nombre

FROM Genero
GO
/****** Object:  StoredProcedure [dbo].[GeneroGetById]    Script Date: 05/07/2022 07:23:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GeneroGetById] 
@IdGenero INT 
AS
SELECT 
		Nombre 
FROM Genero 
WHERE IdGenero = @IdGenero
GO
/****** Object:  StoredProcedure [dbo].[GeneroUpdate]    Script Date: 05/07/2022 07:23:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GeneroUpdate]
@IdGenero INT,
@Nombre VARCHAR(50)
AS
UPDATE Genero
SET
Nombre = @Nombre
WHERE IdGenero = @IdGenero
GO
/****** Object:  StoredProcedure [dbo].[LibroAdd]    Script Date: 05/07/2022 07:23:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LibroAdd]

	@Titulo VARCHAR (50),
	@AñoPublicacion VARCHAR (5),
	@IdEditorial INT,
	@IdAutor INT,
	@IdGenero INT,
	@NumeroPaginas VARCHAR (50),
	@Descripcion VARCHAR (MAX),
	@Imagen VARBINARY (MAX)
AS
	INSERT INTO Libro (Titulo, AñoPublicacion, IdAutor, IdEditorial, IdGenero, NumeroPaginas, Descripcion, Imagen)
	VALUES (@Titulo, @AñoPublicacion, @IdAutor, @IdEditorial, @IdGenero, @NumeroPaginas, @Descripcion, @Imagen)
GO
/****** Object:  StoredProcedure [dbo].[LibroDelete]    Script Date: 05/07/2022 07:23:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LibroDelete]
@IdLibro INT
AS
DELETE FROM Libro
WHERE IdLibro = @IdLibro
GO
/****** Object:  StoredProcedure [dbo].[LibroDeleteByAutor]    Script Date: 05/07/2022 07:23:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LibroDeleteByAutor]
@IdAutor INT
AS
DELETE FROM Libro
WHERE IdAutor = @IdAutor
GO
/****** Object:  StoredProcedure [dbo].[LibroDeleteByEditorial]    Script Date: 05/07/2022 07:23:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LibroDeleteByEditorial]
@IdEditorial INT
AS
DELETE FROM Libro
WHERE IdEditorial = @IdEditorial
GO
/****** Object:  StoredProcedure [dbo].[LibroGetAll]    Script Date: 05/07/2022 07:23:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LibroGetAll]
AS
SELECT 
	IdLibro,
	Titulo,
	AñoPublicacion,
	[Libro].IdEditorial,
	[Editorial].Nombre as EditorialNombre,
	[Libro].IdAutor,
	[Autor].Nombre + ' ' + [Autor].ApellidoPaterno + ' ' + [Autor].ApellidoMaterno as AutorNombre,
	[Libro].IdGenero,
	[Genero].Nombre as GeneroNombre,
	NumeroPaginas,
	Descripcion,
	Imagen
FROM Libro

INNER JOIN Editorial
ON Libro.IdEditorial = Editorial.IdEditorial

INNER JOIN Autor
ON Libro.IdAutor = Autor.IdAutor

INNER JOIN Genero
ON Libro.IdGenero = Genero.IdGenero
GO
/****** Object:  StoredProcedure [dbo].[LibroGetByAutor]    Script Date: 05/07/2022 07:23:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LibroGetByAutor]
@IdAutor INT
AS
SELECT 
	IdLibro,
	Titulo,
	AñoPublicacion,
	[Libro].IdEditorial,
	[Editorial].Nombre as EditorialNombre,
	[Libro].IdAutor,
	[Autor].Nombre as AutorNombre,
	[Libro].IdGenero,
	[Genero].Nombre as GeneroNombre,
	NumeroPaginas,
	Descripcion,
	Imagen
FROM Libro

INNER JOIN Editorial
ON Libro.IdEditorial = Editorial.IdEditorial

INNER JOIN Autor
ON Libro.IdAutor = Autor.IdAutor

INNER JOIN Genero
ON Libro.IdGenero = Genero.IdGenero

WHERE [Libro].IdAutor = @IdAutor
GO
/****** Object:  StoredProcedure [dbo].[LibroGetByAutorYFecha]    Script Date: 05/07/2022 07:23:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LibroGetByAutorYFecha]
@IdAutor INT,
@AñoPublicacion VARCHAR (5)
AS
IF @AñoPublicacion = ''
SELECT 
	IdLibro,
	Titulo,
	AñoPublicacion,
	[Libro].IdEditorial,
	[Editorial].Nombre as EditorialNombre,
	[Libro].IdAutor,
	[Autor].Nombre as AutorNombre,
	[Libro].IdGenero,
	[Genero].Nombre as GeneroNombre,
	NumeroPaginas,
	Descripcion,
	Imagen
FROM Libro

INNER JOIN Editorial
ON Libro.IdEditorial = Editorial.IdEditorial

INNER JOIN Autor
ON Libro.IdAutor = Autor.IdAutor

INNER JOIN Genero
ON Libro.IdGenero = Genero.IdGenero

WHERE [Libro].IdAutor = @IdAutor

ELSE 

SELECT 
	IdLibro,
	Titulo,
	AñoPublicacion,
	[Libro].IdEditorial,
	[Editorial].Nombre as EditorialNombre,
	[Libro].IdAutor,
	[Autor].Nombre as AutorNombre,
	[Libro].IdGenero,
	[Genero].Nombre as GeneroNombre,
	NumeroPaginas,
	Descripcion
FROM Libro

INNER JOIN Editorial
ON Libro.IdEditorial = Editorial.IdEditorial

INNER JOIN Autor
ON Libro.IdAutor = Autor.IdAutor

INNER JOIN Genero
ON Libro.IdGenero = Genero.IdGenero

WHERE AñoPublicacion LIKE '%' + @AñoPublicacion + '%'
GO
/****** Object:  StoredProcedure [dbo].[LibroGetByEditorial]    Script Date: 05/07/2022 07:23:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LibroGetByEditorial]
@IdEditorial VARCHAR
AS
IF @IdEditorial = ''
SELECT 
	IdLibro,
	Titulo,
	AñoPublicacion,
	[Libro].IdEditorial,
	[Editorial].Nombre as EditorialNombre,
	[Libro].IdAutor,
	[Autor].Nombre as AutorNombre,
	[Libro].IdGenero,
	[Genero].Nombre as GeneroNombre,
	NumeroPaginas,
	Descripcion,
	Imagen
FROM Libro

INNER JOIN Editorial
ON Libro.IdEditorial = Editorial.IdEditorial

INNER JOIN Autor
ON Libro.IdAutor = Autor.IdAutor

INNER JOIN Genero
ON Libro.IdGenero = Genero.IdGenero

ELSE 

SELECT 
	IdLibro,
	Titulo,
	AñoPublicacion,
	[Libro].IdEditorial,
	[Editorial].Nombre as EditorialNombre,
	[Libro].IdAutor,
	[Autor].Nombre as AutorNombre,
	[Libro].IdGenero,
	[Genero].Nombre as GeneroNombre,
	NumeroPaginas,
	Descripcion,
	Imagen
FROM Libro

INNER JOIN Editorial
ON Libro.IdEditorial = Editorial.IdEditorial

INNER JOIN Autor
ON Libro.IdAutor = Autor.IdAutor

INNER JOIN Genero
ON Libro.IdGenero = Genero.IdGenero

WHERE [Libro].IdEditorial LIKE '%' + @IdEditorial + '%'
GO
/****** Object:  StoredProcedure [dbo].[LibroGetByFechaPublicacion]    Script Date: 05/07/2022 07:23:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LibroGetByFechaPublicacion]
@AñoPublicacion VARCHAR (5)
AS
IF @AñoPublicacion = null
SELECT 
	IdLibro,
	Titulo,
	AñoPublicacion,
	[Libro].IdEditorial,
	[Editorial].Nombre as EditorialNombre,
	[Libro].IdAutor,
	[Autor].Nombre as AutorNombre,
	[Libro].IdGenero,
	[Genero].Nombre as GeneroNombre,
	NumeroPaginas,
	Descripcion,
	Imagen
FROM Libro

INNER JOIN Editorial
ON Libro.IdEditorial = Editorial.IdEditorial

INNER JOIN Autor
ON Libro.IdAutor = Autor.IdAutor

INNER JOIN Genero
ON Libro.IdGenero = Genero.IdGenero

ELSE 

SELECT 
	IdLibro,
	Titulo,
	AñoPublicacion,
	[Libro].IdEditorial,
	[Editorial].Nombre as EditorialNombre,
	[Libro].IdAutor,
	[Autor].Nombre as AutorNombre,
	[Libro].IdGenero,
	[Genero].Nombre as GeneroNombre,
	NumeroPaginas,
	Descripcion
FROM Libro

INNER JOIN Editorial
ON Libro.IdEditorial = Editorial.IdEditorial

INNER JOIN Autor
ON Libro.IdAutor = Autor.IdAutor

INNER JOIN Genero
ON Libro.IdGenero = Genero.IdGenero

WHERE AñoPublicacion = @AñoPublicacion
GO
/****** Object:  StoredProcedure [dbo].[LibroGetById]    Script Date: 05/07/2022 07:23:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LibroGetById]
@IdLibro INT
AS
SELECT 
	IdLibro,
	Titulo,
	AñoPublicacion,
	[Libro].IdEditorial,
	[Editorial].Nombre as EditorialNombre,
	[Libro].IdAutor,
	[Autor].Nombre as AutorNombre,
	[Libro].IdGenero,
	[Genero].Nombre as GeneroNombre,
	NumeroPaginas,
	Descripcion,
	Imagen
FROM Libro

INNER JOIN Editorial
ON Libro.IdEditorial = Editorial.IdEditorial

INNER JOIN Autor
ON Libro.IdAutor = Autor.IdAutor

INNER JOIN Genero
ON Libro.IdGenero = Genero.IdGenero

WHERE IdLibro = @IdLibro
GO
/****** Object:  StoredProcedure [dbo].[LibroGetByTitulo]    Script Date: 05/07/2022 07:23:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LibroGetByTitulo]
@Titulo VARCHAR(50)
AS
IF @Titulo = ''
SELECT 
	IdLibro,
	Titulo,
	AñoPublicacion,
	[Libro].IdEditorial,
	[Editorial].Nombre as EditorialNombre,
	[Libro].IdAutor,
	[Autor].Nombre as AutorNombre,
	[Libro].IdGenero,
	[Genero].Nombre as GeneroNombre,
	NumeroPaginas,
	Descripcion,
	Imagen
FROM Libro

INNER JOIN Editorial
ON Libro.IdEditorial = Editorial.IdEditorial

INNER JOIN Autor
ON Libro.IdAutor = Autor.IdAutor

INNER JOIN Genero
ON Libro.IdGenero = Genero.IdGenero
ELSE 

SELECT 
	IdLibro,
	Titulo,
	AñoPublicacion,
	[Libro].IdEditorial,
	[Editorial].Nombre as EditorialNombre,
	[Libro].IdAutor,
	[Autor].Nombre as AutorNombre,
	[Libro].IdGenero,
	[Genero].Nombre as GeneroNombre,
	NumeroPaginas,
	Descripcion
FROM Libro

INNER JOIN Editorial
ON Libro.IdEditorial = Editorial.IdEditorial

INNER JOIN Autor
ON Libro.IdAutor = Autor.IdAutor

INNER JOIN Genero
ON Libro.IdGenero = Genero.IdGenero

WHERE Titulo LIKE '%' + @Titulo + '%'
GO
/****** Object:  StoredProcedure [dbo].[LibroGetByTituloyAutor]    Script Date: 05/07/2022 07:23:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LibroGetByTituloyAutor] 
@Titulo VARCHAR(50),
@Nombre VARCHAR(50)
AS

IF @Titulo = '' AND @Nombre = ''
SELECT 
	IdLibro,
	Titulo,
	AñoPublicacion,
	[Libro].IdEditorial,
	[Editorial].Nombre as EditorialNombre,
	[Libro].IdAutor,
	[Autor].Nombre as AutorNombre,
	[Libro].IdGenero,
	[Genero].Nombre as GeneroNombre,
	NumeroPaginas,
	Descripcion,
	Imagen
FROM Libro

INNER JOIN Editorial
ON Libro.IdEditorial = Editorial.IdEditorial

INNER JOIN Autor
ON Libro.IdAutor = Autor.IdAutor

INNER JOIN Genero
ON Libro.IdGenero = Genero.IdGenero

ELSE 
SELECT 
	IdLibro,
	Titulo,
	AñoPublicacion,
	[Libro].IdEditorial,
	[Editorial].Nombre as EditorialNombre,
	[Libro].IdAutor,
	[Autor].Nombre as AutorNombre,
	[Libro].IdGenero,
	[Genero].Nombre as GeneroNombre,
	NumeroPaginas,
	Descripcion,
	Imagen
FROM Libro

INNER JOIN Editorial
ON Libro.IdEditorial = Editorial.IdEditorial

INNER JOIN Autor
ON Libro.IdAutor = Autor.IdAutor

INNER JOIN Genero
ON Libro.IdGenero = Genero.IdGenero

WHERE [Autor].Nombre LIKE @Nombre + '%' AND Titulo LIKE '%' + @Titulo +'%'
GO
/****** Object:  StoredProcedure [dbo].[LibroUpdate]    Script Date: 05/07/2022 07:23:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LibroUpdate]
	
	@IdLibro INT,
	@Titulo VARCHAR (50),
	@AñoPublicacion VARCHAR (5),
	@IdEditorial INT,
	@IdAutor INT,
	@IdGenero INT,
	@NumeroPaginas VARCHAR (50),
	@Descripcion VARCHAR (MAX),
	@Imagen VARBINARY (MAX)
AS
UPDATE Libro
SET 
	Titulo = @Titulo,
	AñoPublicacion = @AñoPublicacion,
	IdEditorial = @IdEditorial,
	IdAutor = @IdAutor,
	IdGenero = @IdGenero,
	NumeroPaginas = @NumeroPaginas,
	Descripcion = @Descripcion,
	Imagen = @Imagen

WHERE IdLibro = @IdLibro
GO
/****** Object:  StoredProcedure [dbo].[RolGetAll]    Script Date: 05/07/2022 07:23:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RolGetAll]
AS
SELECT 
		IdRol,
		Nombre
FROM Rol
GO
/****** Object:  StoredProcedure [dbo].[UsuarioGetAll]    Script Date: 05/07/2022 07:23:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UsuarioGetAll]
AS
SELECT 
		IdUsuario,
		Email,
		Password,
		[Usuario].IdRol,
		[Rol].Nombre
FROM Usuario

INNER JOIN Rol
ON Usuario.IdRol = Rol.IdRol
GO
/****** Object:  StoredProcedure [dbo].[UsuarioGetByEmail]    Script Date: 05/07/2022 07:23:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UsuarioGetByEmail] 
@Email VARCHAR(50)
AS
SELECT 
		Email, 
		Password
FROM Usuario
WHERE Email = @Email
GO
/****** Object:  Table [dbo].[Autor]    Script Date: 05/07/2022 07:23:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Autor](
	[IdAutor] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[ApellidoPaterno] [varchar](50) NULL,
	[ApellidoMaterno] [varchar](50) NULL,
	[FechaNacimiento] [datetime] NULL,
	[LugarNacimiento] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdAutor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Editorial]    Script Date: 05/07/2022 07:23:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Editorial](
	[IdEditorial] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Direccion] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdEditorial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Genero]    Script Date: 05/07/2022 07:23:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Genero](
	[IdGenero] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdGenero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Libro]    Script Date: 05/07/2022 07:23:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Libro](
	[IdLibro] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [varchar](50) NULL,
	[AñoPublicacion] [varchar](5) NULL,
	[IdEditorial] [int] NULL,
	[IdAutor] [int] NULL,
	[IdGenero] [int] NULL,
	[NumeroPaginas] [varchar](50) NULL,
	[Descripcion] [varchar](max) NULL,
	[Imagen] [varbinary](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdLibro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Rol]    Script Date: 05/07/2022 07:23:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Rol](
	[IdRol] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 05/07/2022 07:23:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[IdRol] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Libro]  WITH CHECK ADD FOREIGN KEY([IdAutor])
REFERENCES [dbo].[Autor] ([IdAutor])
GO
ALTER TABLE [dbo].[Libro]  WITH CHECK ADD FOREIGN KEY([IdEditorial])
REFERENCES [dbo].[Editorial] ([IdEditorial])
GO
ALTER TABLE [dbo].[Libro]  WITH CHECK ADD FOREIGN KEY([IdGenero])
REFERENCES [dbo].[Genero] ([IdGenero])
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD FOREIGN KEY([IdRol])
REFERENCES [dbo].[Rol] ([IdRol])
GO
USE [master]
GO
ALTER DATABASE [EjercicioKranon] SET  READ_WRITE 
GO
