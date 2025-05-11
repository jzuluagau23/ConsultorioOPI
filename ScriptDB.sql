-- Eliminar base de datos si ya existe
IF DB_ID('ConsultorioOPIDB') IS NOT NULL
    DROP DATABASE ConsultorioOPIDB;
GO

-- Crear base de datos
CREATE DATABASE ConsultorioOPIDB;
GO

USE ConsultorioOPIDB;
GO

-- Tabla de Médicos
CREATE TABLE Medicos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Especialidad NVARCHAR(100) NOT NULL
);
GO

-- Tabla de Pacientes
CREATE TABLE Pacientes (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Documento NVARCHAR(20) NOT NULL,
    FechaNacimiento DATE NOT NULL
);
GO

-- Catálogo de Estados de Turno
CREATE TABLE EstadosTurno (
    Id INT PRIMARY KEY,
    Nombre NVARCHAR(50) NOT NULL
);
GO

-- Insertar Estados
INSERT INTO EstadosTurno (Id, Nombre) VALUES (1, 'Agendado');
INSERT INTO EstadosTurno (Id, Nombre) VALUES (2, 'Cancelado');
INSERT INTO EstadosTurno (Id, Nombre) VALUES (3, 'Realizado');
GO

-- Tabla de Turnos
CREATE TABLE Turnos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    MedicoId INT NOT NULL,
    PacienteId INT NOT NULL,
    FechaHora DATETIME NOT NULL,
    EstadoId INT NOT NULL DEFAULT 1,
    CONSTRAINT FK_Turno_Medico FOREIGN KEY (MedicoId) REFERENCES Medicos(Id),
    CONSTRAINT FK_Turno_Paciente FOREIGN KEY (PacienteId) REFERENCES Pacientes(Id),
    CONSTRAINT FK_Turno_Estado FOREIGN KEY (EstadoId) REFERENCES EstadosTurno(Id)
);
GO

-- Insertar Médicos
INSERT INTO Medicos (Nombre, Especialidad) VALUES ('Juan Camilo Restrepo', 'Pediatría');
INSERT INTO Medicos (Nombre, Especialidad) VALUES ('Laura González', 'Cardiología');
INSERT INTO Medicos (Nombre, Especialidad) VALUES ('Andrés Felipe Torres', 'Dermatología');
GO

-- Insertar Pacientes
INSERT INTO Pacientes (Nombre, Documento, FechaNacimiento) VALUES ('María Fernanda Ramírez', '1012345678', '1990-05-10');
INSERT INTO Pacientes (Nombre, Documento, FechaNacimiento) VALUES ('Carlos Andrés Quintero', '1023456789', '1985-12-22');
INSERT INTO Pacientes (Nombre, Documento, FechaNacimiento) VALUES ('Valentina López', '1034567890', '2000-03-15');
GO

-- Insertar Turnos 
INSERT INTO Turnos (MedicoId, PacienteId, FechaHora, EstadoId)
VALUES 
(1, 1, '2025-05-10 09:00', 1),
(2, 2, '2025-05-10 10:00', 3),
(3, 3, '2025-05-11 11:30', 2);
GO
