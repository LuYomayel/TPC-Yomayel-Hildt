--go
--drop database Yomayel_Hildt_DB
create database Yomayel_Hildt_DB
go 
use Yomayel_Hildt_DB
go
create table Clientes(
	Cuit varchar(20) not null primary key,
	Nombre varchar(20) not null,
	Apellido varchar(20) not null,
	FechaNac date not null,
	Direccion varchar(100) not null,
	Telefono int not null,
	Email varchar(200) null, 
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
	UltPrecio money null,
	PorcGanancia float not null,
	UrlImagen varchar(200) null,
	StockActual int null,
	StockMinimo int not null,
	IdMarca int not null foreign key references Marcas(id),
	IdCategoria int not null foreign key references Categorias(id),
	Estado bit default 1
)



create table Proveedores(
	Cuit varchar(20) not null primary key,
	RazonSocial varchar(100) not null,
	Descripcion varchar(200) null,
	Email varchar(200) null, 
	Estado bit default 1
)

create table Proveedores_X_Producto(
	IdProveedores varchar(20) not null  foreign key references Proveedores(Cuit),
	IdProducto int not null  foreign key references Productos(id)
)
ALTER table Proveedores_X_Producto ADD PRIMARY KEY (IdProveedores, IdProducto)

create table Transacciones(
	Id int not null identity(1,1) primary key,
	Tipo char not null Check(Tipo = 'C' or Tipo = 'V'),
	Monto money null,
	IdProveedor varchar(20) null foreign key references Proveedores(Cuit),
	IdCliente varchar(20) null foreign key references Clientes(Cuit)
)



create table Detalle(
	Id int not null identity(1,1) primary key,
	IdProducto int not null  foreign key references Productos(id),
	Cantidad int not null,
	IdTransaccion int not null foreign key references Transacciones(Id),
	PrecioUnitario money not null
)

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
insert into Clientes(Nombre,Apellido,FechaNac,Direccion,Telefono,Cuit,Email) values ('PEDRO ','CONSTANTIN GASPAR',Cast(N'28/09/1993' as date),'COLON 8111',1189076217,'20-38508234-8','PEDROCONSTANTINGASPAR@gmail.com')
insert into Clientes(Nombre,Apellido,FechaNac,Direccion,Telefono,Cuit,Email) values ('LORENZO','LUENGO AGUSTI',Cast(N'24/12/1963' as date),'Juan B Justo 18033',1187578217,'20-33581386-4','LORENZOLUENGOAGUSTI@gmail.com')
insert into Clientes(Nombre,Apellido,FechaNac,Direccion,Telefono,Cuit,Email) values ('CARLOS ','JUNQUERA DE OLIVEIRA',Cast(N'03/04/1957' as date),'Emilio Conesa 986 Piso 20âº Dpto G Colegiales',1190612202,'20-21465875-6','CARLOSJUNQUERADEOLIVEIRA@gmail.com')
insert into Clientes(Nombre,Apellido,FechaNac,Direccion,Telefono,Cuit,Email) values ('FELIX','BARCO AMOROS',Cast(N'08/02/1988' as date),'Av E Perón 42 PB',1172924092,'20-23708016-6','FELIXBARCOAMOROS@gmail.com')
insert into Clientes(Nombre,Apellido,FechaNac,Direccion,Telefono,Cuit,Email) values ('FELIX ','SARABIA POPA',Cast(N'13/11/1964' as date),'Buenos Aires 1127 P.D .A',1118062293,'20-41628555-2','FELIXSARABIAPOPA@gmail.com')
insert into Clientes(Nombre,Apellido,FechaNac,Direccion,Telefono,Cuit,Email) values ('DIEGO ','MOLTO PAJARES',Cast(N'18/01/1960' as date),'Melian 3199',1173320453,'20-49232417-6','DIEGOMOLTOPAJARES@gmail.com')
insert into Clientes(Nombre,Apellido,FechaNac,Direccion,Telefono,Cuit,Email) values ('JOSEFA ','ARMENGOL ARGUELLES',Cast(N'28/11/1987' as date),'Bernardo De Irigoyen 387',1153263214,'23-51089852-4','JOSEFAARMENGOLARGUELLES@gmail.com')
insert into Clientes(Nombre,Apellido,FechaNac,Direccion,Telefono,Cuit,Email) values ('JOSEFA ','CONSTANTIN SAUCEDO',Cast(N'26/09/1991' as date),'Paso 26136',1140285085,'23-16783331-4','JOSEFACONSTANTINSAUCEDO@gmail.com')
insert into Clientes(Nombre,Apellido,FechaNac,Direccion,Telefono,Cuit,Email) values ('CAROLINA ','CASTILLO FERREIRA',Cast(N'28/10/1981' as date),'San Lorenzo 2484',1154974222,'23-12986046-4','CAROLINACASTILLOFERREIRA@gmail.com')
insert into Clientes(Nombre,Apellido,FechaNac,Direccion,Telefono,Cuit,Email) values ('ANA ','MILAN LOMAS',Cast(N'10/03/1968' as date),'Avellaneda 372',1145042913,'27-15754535-9','ANAMILANLOMAS@gmail.com')
insert into Clientes(Nombre,Apellido,FechaNac,Direccion,Telefono,Cuit,Email) values ('MARIA ','JOSEFA NIEVES MULERO',Cast(N'14/01/2001' as date),'Martin Miguel De Guemes 3049',1123091584,'27-43758850-9','MARIAJOSEFANIEVESMULERO@gmail.com')


insert into Proveedores (RazonSocial,Descripcion,Email,Cuit) values('TecnoSolucion','Mouse y monitores','TecnoSolucion@gmail.com','23-17606071-9')
insert into Proveedores (RazonSocial,Descripcion,Email,Cuit) values('FullH4rd','Teclados','FullH4rd@gmail.com','20-40485816-6')
insert into Proveedores (RazonSocial,Descripcion,Email,Cuit) values('CompraGamer','Mouse, teclados y monitores','CompraGamer@gmail.com','20-55204244-2')
insert into Proveedores (RazonSocial,Descripcion,Email,Cuit) values('Garbarino','Celulares','Garbarino@gmail.com','20-44408344-2')
insert into Proveedores (RazonSocial,Descripcion,Email,Cuit) values('Compumundo','Celulares','Compumundo@gmail.com','20-27366697-5')
insert into Proveedores (RazonSocial,Descripcion,Email,Cuit) values('GtripleL','Televisores y monitores','GtripleL@gmail.com','20-25020905-4')
insert into Proveedores (RazonSocial,Descripcion,Email,Cuit) values('Solja','Teclados y celulares','Solja@gmail.com','20-24487622-7')
insert into Proveedores (RazonSocial,Descripcion,Email,Cuit) values('Delz1k','Mouse y teclados','Delz1k@gmail.com','23-40238597-9')


--update categorias set estado = 1 
--update Marcas set estado = 1
--update Clientes set estado = 1
--update Proveedores set estado = 1
--update Productos set estado = 1

--insert into Transacciones (Tipo)values('C') 
--insert into Transacciones (Tipo)values('C') 
--insert into Transacciones (Tipo)values('V') 
--insert into Transacciones (Tipo)values('V') 
--select * from Transacciones

insert into Transacciones(Tipo,Monto,IdProveedor,IdCliente) values ('C',Null,'23-17606071-9',null)
insert into Transacciones(Tipo,Monto,IdProveedor,IdCliente) values ('C',Null,'20-40485816-6',null)
insert into Transacciones(Tipo,Monto,IdProveedor,IdCliente) values ('V',Null,null,'20-38508234-8')
insert into Transacciones(Tipo,Monto,IdProveedor,IdCliente) values ('V',Null,null,'20-33581386-4')

insert into Detalle(IdProducto,Cantidad,IdTransaccion,PrecioUnitario) values (3,20,1,5000)
insert into Detalle(IdProducto,Cantidad,IdTransaccion,PrecioUnitario) values (4,4,1,20000)
insert into Detalle(IdProducto,Cantidad,IdTransaccion,PrecioUnitario) values (5,11,1,50000)
insert into Detalle(IdProducto,Cantidad,IdTransaccion,PrecioUnitario) values (10,3,2,10000)
insert into Detalle(IdProducto,Cantidad,IdTransaccion,PrecioUnitario) values (11,6,2,11500)
insert into Detalle(IdProducto,Cantidad,IdTransaccion,PrecioUnitario) values (12,9,2,37000)
insert into Detalle(IdProducto,Cantidad,IdTransaccion,PrecioUnitario) values (3,5,3,5000)
insert into Detalle(IdProducto,Cantidad,IdTransaccion,PrecioUnitario) values (4,3,3,20000)




select D.Id Id, d.IdProducto IdProducto, p.Nombre NombreP, d.Cantidad Cantidad, d.IdTransaccion IdTransaccion, d.PrecioUnitario PrecioUnitario, 
(d.Cantidad * d.PrecioUnitario) PrecioParcial from Detalle D 
join Productos p on p.Id=d.IdProducto 

where IdTransaccion=21
group by d.Id


select t.id IdTransaccion, coalesce(t.monto,0) Monto, t.IdProveedor IdProveedor, p.RazonSocial RazonSocial from Transacciones t join Proveedores p on p.Cuit = t.idProveedor where t.Tipo = 'C'

select id, nombre, descripcion, urlimagen, coalesce(ultprecio, 0) UltPrecio from Productos where estado = 1 and id= 1