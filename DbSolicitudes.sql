
CREATE DATABASE DbSolicitudes;
GO

USE DbSolicitudes;
GO


CREATE TABLE Rol (
    idRol INT PRIMARY KEY IDENTITY(1,1),
    nombre VARCHAR(50) NOT NULL,
    fechaRegistro DATETIME DEFAULT GETDATE()
);
GO


CREATE TABLE Menu (
    idMenu INT PRIMARY KEY IDENTITY(1,1),
    nombre VARCHAR(50) NOT NULL,
    icono VARCHAR(50),
    url VARCHAR(50)
);
GO


CREATE TABLE MenuRol (
    idMenuRol INT PRIMARY KEY IDENTITY(1,1),
    idMenu INT NOT NULL,
    idRol INT NOT NULL,
    FOREIGN KEY (idMenu) REFERENCES Menu(idMenu),
    FOREIGN KEY (idRol) REFERENCES Rol(idRol)
);
GO


CREATE TABLE Usuario (
    idUsuario INT PRIMARY KEY IDENTITY(1,1),
    nombreCompleto VARCHAR(100) NOT NULL,
    correo VARCHAR(40) NOT NULL UNIQUE,
    idRol INT NOT NULL,
    clave VARCHAR(255) NOT NULL,
    esActivo BIT DEFAULT 1,
    fechaRegistro DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (idRol) REFERENCES Rol(idRol)
);
GO


CREATE TABLE Solicitudes (
    SolicitudID INT PRIMARY KEY IDENTITY(1,1),
    FechaRegistro DATETIME NOT NULL DEFAULT GETDATE(),
    UsuarioID INT NOT NULL,
    CodigoSolicitud NVARCHAR(50) NOT NULL,
    DetalleSolicitud NVARCHAR(MAX),
    Modificada BIT NOT NULL DEFAULT 0,
    FOREIGN KEY (UsuarioID) REFERENCES Usuario(idUsuario)
);
GO


INSERT INTO Solicitudes (FechaRegistro, UsuarioID, CodigoSolicitud, DetalleSolicitud, Modificada) 
VALUES ('2024-06-27', 1, 'SO001', 'Hacer un cambio', 0);
GO


CREATE TABLE SolicitudesEliminadas (
    SolicitudEliminadaID INT PRIMARY KEY IDENTITY(1,1),
    FechaEliminacion DATETIME NOT NULL DEFAULT GETDATE(),
    MotivoEliminacion NVARCHAR(MAX) NOT NULL,
    CodigoSolicitud NVARCHAR(50) NOT NULL,
    UsuarioSolicitanteID INT NOT NULL,
    UsuarioEliminadorID INT NOT NULL,
    DetalleSolicitud NVARCHAR(MAX),
    FOREIGN KEY (UsuarioSolicitanteID) REFERENCES Usuario(idUsuario),
    FOREIGN KEY (UsuarioEliminadorID) REFERENCES Usuario(idUsuario)
);
GO


INSERT INTO SolicitudesEliminadas (FechaEliminacion, MotivoEliminacion, CodigoSolicitud, UsuarioSolicitanteID, UsuarioEliminadorID, DetalleSolicitud)
VALUES (GETDATE(), 'Duplicado', 'SO001', 1, 1, 'Detalles de la solicitud eliminada por duplicado');
GO


INSERT INTO Rol(nombre) 
VALUES ('Administrador'),('Empleado'),('Supervisor');
GO

INSERT INTO Usuario(nombreCompleto, correo, idRol, clave)
VALUES 
('David Macha Alcantara', 'damachaalcantara', 1, 'david123'),
('Juan Perez Alvarado Milla', 'juanperezmilla@hotmail.com', 1, 'JUAN@#PEREZ');
GO

-- Consultas para verificar inserciones
SELECT * FROM Solicitudes;
SELECT * FROM SolicitudesEliminadas;
SELECT * FROM Rol;
SELECT * FROM Usuario;

