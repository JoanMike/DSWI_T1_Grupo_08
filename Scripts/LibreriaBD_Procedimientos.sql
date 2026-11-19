USE LibreriaBD;
GO

CREATE OR ALTER PROCEDURE sp_Autores_Listar
AS
BEGIN
    SET NOCOUNT ON;

    SELECT AutorID, Nombre, Nacionalidad
    FROM Autores
    ORDER BY AutorID;
END
GO

CREATE OR ALTER PROCEDURE sp_Autores_ObtenerPorId
    @AutorID INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT AutorID, Nombre, Nacionalidad
    FROM Autores
    WHERE AutorID = @AutorID;
END
GO

CREATE OR ALTER PROCEDURE sp_Autores_Crear
    @Nombre NVARCHAR(100),
    @Nacionalidad NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Autores (Nombre, Nacionalidad)
    VALUES (@Nombre, @Nacionalidad);
END
GO

CREATE OR ALTER PROCEDURE sp_Autores_Editar
    @AutorID INT,
    @Nombre NVARCHAR(100),
    @Nacionalidad NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Autores
    SET Nombre = @Nombre,
        Nacionalidad = @Nacionalidad
    WHERE AutorID = @AutorID;
END
GO

CREATE OR ALTER PROCEDURE sp_Libros_Listar
AS
BEGIN
    SET NOCOUNT ON;

    SELECT LibroID, Titulo, Genero, AñoPublicacion, ISBN, AutorID
    FROM Libros
    ORDER BY LibroID;
END
GO

CREATE OR ALTER PROCEDURE sp_Libros_ObtenerPorId
    @LibroID INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT LibroID, Titulo, Genero, AñoPublicacion, ISBN, AutorID
    FROM Libros
    WHERE LibroID = @LibroID;
END
GO

CREATE OR ALTER PROCEDURE sp_Libros_Crear
    @Titulo NVARCHAR(100),
    @Genero NVARCHAR(50),
    @AnioPublicacion INT,
    @ISBN NVARCHAR(20),
    @AutorID INT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Libros (Titulo, Genero, AñoPublicacion, ISBN, AutorID)
    VALUES (@Titulo, @Genero, @AnioPublicacion, @ISBN, @AutorID);
END
GO

CREATE OR ALTER PROCEDURE sp_Libros_Editar
    @LibroID INT,
    @Titulo NVARCHAR(100),
    @Genero NVARCHAR(50),
    @AnioPublicacion INT,
    @ISBN NVARCHAR(20),
    @AutorID INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Libros
    SET Titulo = @Titulo,
        Genero = @Genero,
        AñoPublicacion = @AnioPublicacion,
        ISBN = @ISBN,
        AutorID = @AutorID
    WHERE LibroID = @LibroID;
END
GO
