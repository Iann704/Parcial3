create Database Parcial#3;
Go
Use Parcial#3;
go
create table Usuarios (
    Id             int identity(1,1) primary Key,
    NombreUsuario  varchar(50)  NOT NULL unique,
    NombreCompleto varchar(100) NOT NULL,
    PasswordHash   varchar(100) NOT NULL
);
Go
create table IntentosLogin (
    Id             int identity(1,1) primary key,
    NombreUsuario  varchar(50) NOT NULL,
    Fecha          datetime    NOT NULL default GetDate(),
    Exitoso        bit         NOT NULL
);
Go

