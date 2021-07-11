go
--drop database Yomayel_Hildt_DB
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
	Telefono int not null,
	Estado bit default 1
)

USE Yomayel_Hildt_DB
GO
create table Marcas(
	id int not null primary key identity(1,1),
	Nombre varchar(20) not null,
	Estado bit default 1
)

create table Categorias(
	id int not null primary key identity(1,1),
	Nombre varchar(20) not null,
	Estado bit default 1
)


go
create table Productos(
	Id int not null identity(1,1) primary key,
	Nombre varchar(100) not null,
	Descripcion varchar(200) not null,
	UltPrecio int null,
	PorcGanancia int not null,
	UrlImagen varchar(500) null,
	StockActual int null,
	StockMinimo int not null,
	IdMarca int not null foreign key references Marcas(id),
	IdCategoria int not null foreign key references Categorias(id),
	Estado bit default 1
)

use Yomayel_Hildt_DB
go
Alter table Productos alter column Nombre varchar(100) not null
create table Proveedores(
	id int not null primary key identity(1,1),
	RazonSocial varchar(100) not null,
	Descripcion varchar(200) null,
	Estado bit default 1
)

create table Proveedores_X_Producto(
	IdProveedores int not null  foreign key references Proveedores(id),
	IdProducto int not null  foreign key references Productos(id)
)
ALTER table Proveedores_X_Producto ADD PRIMARY KEY (IdProveedores, IdProducto)

use Yomayel_Hildt_DB
insert into Marcas (Nombre) values('Samsung')
insert into Marcas (Nombre) values('Lenovo')
insert into Marcas (Nombre) values('Logitech')
insert into Marcas (Nombre) values('Razer')
insert into Marcas (Nombre) values('Redragon')
insert into Marcas (Nombre) values('Motorola')
insert into Categorias (Nombre) values('Televisor')
insert into Categorias (Nombre) values('Celular')
insert into Categorias (Nombre) values('Teclado')
insert into Categorias (Nombre) values('Mouse')
insert into Categorias (Nombre) values('Monitor')

insert into Productos(Nombre ,Descripcion,UltPrecio,PorcGanancia,UrlImagen,StockActual,StockMInimo,IdMarca,IdCategoria)values('Monitor 24','Para jugar valorant',NULL,15,'https://http2.mlstatic.com/D_NQ_NP_993724-MLA46185878746_052021-O.webp',NULL,3,1,5)
insert into Productos(Nombre ,Descripcion,UltPrecio,PorcGanancia,UrlImagen,StockActual,StockMInimo,IdMarca,IdCategoria)values('Logitech Lightspeed G703','Demasiados dpi',NULL,13,'https://http2.mlstatic.com/D_NQ_NP_920865-MLA41632030645_052020-O.webp',NULL,5,3,4)
insert into Productos(Nombre ,Descripcion,UltPrecio,PorcGanancia,UrlImagen,StockActual,StockMInimo,IdMarca,IdCategoria)values('DeathAdder Essential','Pareciera estar bueno',NULL,25,'https://http2.mlstatic.com/D_NQ_NP_674581-MLA41799362594_052020-O.webp',NULL,2,4,4)
insert into Productos(Nombre ,Descripcion,UltPrecio,PorcGanancia,UrlImagen,StockActual,StockMInimo,IdMarca,IdCategoria)values('logitech g203','El blanco es muy fachero',NULL,17,'https://http2.mlstatic.com/D_NQ_NP_775601-MLA45385615343_032021-O.webp',NULL,3,3,4)
insert into Productos(Nombre ,Descripcion,UltPrecio,PorcGanancia,UrlImagen,StockActual,StockMInimo,IdMarca,IdCategoria)values('Logitech G502','Una forma muy rara',NULL,20,'https://http2.mlstatic.com/D_NQ_NP_966913-MLA32149634914_092019-O.webp',NULL,3,3,4)
insert into Productos(Nombre ,Descripcion,UltPrecio,PorcGanancia,UrlImagen,StockActual,StockMInimo,IdMarca,IdCategoria)values('Monitor 27 F390','Ya me parece muy grande',NULL,40,'https://images.bidcom.com.ar/resize?src=https://www.bidcom.com.ar/publicacionesML/productos/MON00001/1000x1000-MON00001.jpg&w=500&q=100',NULL,10,1,5)
insert into Productos(Nombre ,Descripcion,UltPrecio,PorcGanancia,UrlImagen,StockActual,StockMInimo,IdMarca,IdCategoria)values('Monitor Lenovo 27 L27i-28','Sin bordes, una belleza',NULL,25,'https://www.arrichetta.com.ar/wp-content/uploads/2021/07/65E0KAC1AR-1.jpg',NULL,7,2,5)
insert into Productos(Nombre ,Descripcion,UltPrecio,PorcGanancia,UrlImagen,StockActual,StockMInimo,IdMarca,IdCategoria)values('Monitor 34 Led Ultra Wqhd','Parece un 2 en 1',NULL,19,'https://http2.mlstatic.com/D_NQ_NP_715381-MLA41528601238_042020-O.webp',NULL,6,1,5)
insert into Productos(Nombre ,Descripcion,UltPrecio,PorcGanancia,UrlImagen,StockActual,StockMInimo,IdMarca,IdCategoria)values('Galaxy S20','Que hermosa pantalla tiene',NULL,31,'https://www.cetrogar.com.ar/media/catalog/product/t/e/te2602-5.jpg?quality=80&bg-color=255,255,255&fit=bounds&height=500&width=500&canvas=500:500',NULL,11,1,2)
insert into Productos(Nombre ,Descripcion,UltPrecio,PorcGanancia,UrlImagen,StockActual,StockMInimo,IdMarca,IdCategoria)values('Razer Phone 2 Ii','Razer tiene celulares?',NULL,27,'https://http2.mlstatic.com/D_NQ_NP_865025-MLA32543687823_102019-O.webp',NULL,3,4,2)
insert into Productos(Nombre ,Descripcion,UltPrecio,PorcGanancia,UrlImagen,StockActual,StockMInimo,IdMarca,IdCategoria)values('Moto z play','La mejor bateria del mundo',NULL,38,'https://http2.mlstatic.com/D_NQ_NP_752497-MLA42141458796_062020-O.jpg',NULL,8,6,2)
insert into Productos(Nombre ,Descripcion,UltPrecio,PorcGanancia,UrlImagen,StockActual,StockMInimo,IdMarca,IdCategoria)values('Razer BlackWidow','Tiene un apoya manos muy comodo',NULL,11,'https://hardzone.es/app/uploads-hardzone.es/2020/10/RazerBlackWidowV3.jpg',NULL,5,4,3)


set dateformat dmy
insert into Clientes(Nombre,Apellido,FechaNac,Direccion,Telefono) values ('PEDRO ','CONSTANTIN GASPAR',Cast(N'28/09/1993' as date),'COLON 8111',1189076217)
insert into Clientes(Nombre,Apellido,FechaNac,Direccion,Telefono) values ('LORENZO ','LUENGO AGUSTI',Cast('24/12/1963' as date),'Juan B Justo 18033',1187578217)
insert into Clientes(Nombre,Apellido,FechaNac,Direccion,Telefono) values ('CARLOS ','JUNQUERA DE OLIVEIRA',Cast('03/04/1957' as date),'Emilio Conesa 986 Piso 20âº Dpto G Colegiales',1190612202)
insert into Clientes(Nombre,Apellido,FechaNac,Direccion,Telefono) values ('FELIX','BARCO AMOROS',Cast('08/02/1988' as date),'Av E Perón 42 PB',1172924092)
insert into Clientes(Nombre,Apellido,FechaNac,Direccion,Telefono) values ('FELIX ','SARABIA POPA',Cast('13/11/1964' as date),'Buenos Aires 1127 P.D .A',1118062293)
insert into Clientes(Nombre,Apellido,FechaNac,Direccion,Telefono) values ('DIEGO ','MOLTO PAJARES',Cast('18/01/1960' as date),'Melian 3199',1173320453)
insert into Clientes(Nombre,Apellido,FechaNac,Direccion,Telefono) values ('JOSEFA ','ARMENGOL ARGUELLES',Cast('28/11/1987' as date),'Bernardo De Irigoyen 387',1153263214)
insert into Clientes(Nombre,Apellido,FechaNac,Direccion,Telefono) values ('JOSEFA ','CONSTANTIN SAUCEDO',Cast('26/09/1991' as date),'Paso 26136',1140285085)
insert into Clientes(Nombre,Apellido,FechaNac,Direccion,Telefono) values ('CAROLINA ','CASTILLO FERREIRA',Cast('28/10/1981' as date),'San Lorenzo 2484',1154974222)
insert into Clientes(Nombre,Apellido,FechaNac,Direccion,Telefono) values ('ANA ','MILAN LOMAS',Cast('10/03/1968' as date),'Avellaneda 372',1145042913)
insert into Clientes(Nombre,Apellido,FechaNac,Direccion,Telefono) values ('MARIA ','JOSEFA NIEVES MULERO',Cast('14/01/2001' as date),'Martin Miguel De Guemes 3049',1123091584)


USE Yomayel_Hildt_DB
GO
SET IDENTITY_INSERT [dbo].[Clientes] ON 
GO
INSERT [dbo].[Clientes] ([ID], [Nombre], [Apellido], [FechaNac], [Direccion], [Telefono]) VALUES (1, N'Luciano', N'Yomayel', CAST(N'2000-12-20' AS Date), N'C Pellegrini 1388', 1123905295)
GO
INSERT [dbo].[Clientes] ([ID], [Nombre], [Apellido], [FechaNac], [Direccion], [Telefono]) VALUES (2, N'Franco', N'Hildt', CAST(N'1990-12-20' AS Date), N'Av H Yrigoyen 4108', 1164037219)
GO
INSERT [dbo].[Clientes] ([ID], [Nombre], [Apellido], [FechaNac], [Direccion], [Telefono]) VALUES (3, N'Tadeo', N'Gomez', CAST(N'1991-10-01' AS Date), N'Darwin 22103', 1121670391)
GO
INSERT [dbo].[Clientes] ([ID], [Nombre], [Apellido], [FechaNac], [Direccion], [Telefono]) VALUES (4, N'Lautaro', N'Arostegui', CAST(N'2004-08-19' AS Date), N'ULamadrid 101', 1174077019)
GO
INSERT [dbo].[Clientes] ([ID], [Nombre], [Apellido], [FechaNac], [Direccion], [Telefono]) VALUES (5, N'Leandro', N'Fernandez', CAST(N'2001-03-15' AS Date), N'Bolivar Gral Simon 591', 1157492856)
GO
INSERT [dbo].[Clientes] ([ID], [Nombre], [Apellido], [FechaNac], [Direccion], [Telefono]) VALUES (6, N'Graciela', N'Ayala', CAST(N'1970-12-26' AS Date), N'Uruguay 328 Piso 03 Depto. 0045', 1135661664)
GO
INSERT [dbo].[Clientes] ([ID], [Nombre], [Apellido], [FechaNac], [Direccion], [Telefono]) VALUES (7, N'Roxana', N'Lopez', CAST(N'1966-01-11' AS Date), N'Alte Brown 13104', 1138655526)
GO
INSERT [dbo].[Clientes] ([ID], [Nombre], [Apellido], [FechaNac], [Direccion], [Telefono]) VALUES (8, N'Adriana', N'Zuidwijk', CAST(N'1994-05-20' AS Date), N'Espejo 114', 1122596288)
GO
SET IDENTITY_INSERT [dbo].[Clientes] OFF

insert into Proveedores (RazonSocial,Descripcion) values('TecnoSolucion','Mouse y monitores')
insert into Proveedores (RazonSocial,Descripcion) values('FullH4rd','Teclados')
insert into Proveedores (RazonSocial,Descripcion) values('CompraGamer','Mouse, teclados y monitores')
insert into Proveedores (RazonSocial,Descripcion) values('Garbarino','Celulares')
insert into Proveedores (RazonSocial,Descripcion) values('Compumundo','Celulares')
insert into Proveedores (RazonSocial,Descripcion) values('GtripleL','Televisores y monitores')
insert into Proveedores (RazonSocial,Descripcion) values('Solja','Teclados y celulares')
insert into Proveedores (RazonSocial,Descripcion) values('Delz1k','Mouse y teclados')

--update categorias set estado = 1 
--update Marcas set estado = 1
--update Clientes set estado = 1
--update Proveedores set estado = 1
--update Productos set estado = 1
select * from categorias







