go
create database Yomayel_Hildt_DB
go 
use Yomayel_Hildt_DB
go
create table Clientes(
	Id int not null identity(1,1) primary key,
	Nombre varchar(20) not null,
	Apellido varchar(20) not null,
	FechaNac date not null,
	Direccion varchar(100) not null,
	Telefono int not null
)

USE Yomayel_Hildt_DB
GO
SET IDENTITY_INSERT [dbo].[Clientes] ON 
GO
INSERT [dbo].[Clientes] ([ID], [Nombre], [Apellido], [FechaNac], [Direccion], [Telefono]) VALUES (1, N'Luciano', N'Yomayel', CAST(N'2000-12-20' AS Date), N'Urquiza 4912', 1123905295)
GO
INSERT [dbo].[Clientes] ([ID], [Nombre], [Apellido], [FechaNac], [Direccion], [Telefono]) VALUES (2, N'Franco', N'Hildt', CAST(N'1990-12-20' AS Date), N'Urquiza 4912', 1164037219)
GO
INSERT [dbo].[Clientes] ([ID], [Nombre], [Apellido], [FechaNac], [Direccion], [Telefono]) VALUES (3, N'Tadeo', N'Gomez', CAST(N'1991-10-01' AS Date), N'Urquiza 4912', 1121670391)
GO
INSERT [dbo].[Clientes] ([ID], [Nombre], [Apellido], [FechaNac], [Direccion], [Telefono]) VALUES (4, N'Lautaro', N'Arostegui', CAST(N'2004-08-19' AS Date), N'Urquiza 4912', 1174077019)
GO
INSERT [dbo].[Clientes] ([ID], [Nombre], [Apellido], [FechaNac], [Direccion], [Telefono]) VALUES (5, N'Leandro', N'Fernandez', CAST(N'2001-03-15' AS Date), N'Urquiza 4912', 1157492856)
GO
INSERT [dbo].[Clientes] ([ID], [Nombre], [Apellido], [FechaNac], [Direccion], [Telefono]) VALUES (6, N'Graciela', N'Ayala', CAST(N'1970-12-26' AS Date), N'Urquiza 4912', 1135661664)
GO
INSERT [dbo].[Clientes] ([ID], [Nombre], [Apellido], [FechaNac], [Direccion], [Telefono]) VALUES (7, N'Roxana', N'Lopez', CAST(N'1966-01-11' AS Date), N'Urquiza 4912', 1138655526)
GO
INSERT [dbo].[Clientes] ([ID], [Nombre], [Apellido], [FechaNac], [Direccion], [Telefono]) VALUES (8, N'Adriana', N'Zuidwijk', CAST(N'1994-05-20' AS Date), N'Urquiza 4912', 1122596288)
GO
SET IDENTITY_INSERT [dbo].[Clientes] OFF

delete FechaNac from Clientes

USE Yomayel_Hildt_DB
GO
select * from clientes

use Yomayel_Hildt_DB
go
create table Productos(
	Id int not null identity(1,1) primary key,
	Nombre varchar(20) not null,
	Descripcion varchar(200) not null,
	UltPrecio date not null,
	PorcGanancia varchar(100) not null,
	UrlImagen varchar(500) null,
	IdStock int not null foreign key references Stock(id),
	IdMarca int not null foreign key references Marcas(id),
	IdCategoria int not null foreign key references Categorias(id)
)

use Yomayel_Hildt_DB
go
create table Marcas(
	id int not null primary key identity(1,1),
	Nombre varchar(20) not null
)

create table Categorias(
	id int not null primary key identity(1,1),
	Nombre varchar(20) not null
)

create table Stock(
	id int not null primary key identity(1,1),
	StockMinimo int not null check(StockMinimo > 0),
	StockActual int not null
)

create table Proveedores(
	id int not null primary key identity(1,1),
	RazonSocial varchar(100) not null,
	Descripcion varchar(200) null
)

create table Proveedores_X_Producto(
	IdProveedores int not null  foreign key references Proveedores(id),
	IdProducto int not null  foreign key references Productos(id)
)
ALTER table Proveedores_X_Producto ADD PRIMARY KEY (IdProveedores, IdProducto)