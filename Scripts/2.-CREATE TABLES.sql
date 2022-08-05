use BDCanvia
go

CREATE TABLE Usuarios(
	usuarioId		int not null IDENTITY(1,1) ,
	documentoIdentidad	varchar(12) not null PRIMARY KEY,
	passwordUsuario varchar(100) not null,
	nombre		varchar(200) not null,
	apellidos		varchar(200) not null,
	telefono			varchar(50) null,
	correoElectronico			varchar(100) null,
	activo		bit not null default 1
)
GO
INSERT INTO Usuarios values('72854591','','Bryan','Vislao Chavez','987654321','correo@admin.com',1)
GO
CREATE TABLE Cliente(
	clienteId		int not null IDENTITY(1,1) PRIMARY KEY,
	nombre		varchar(200) not null,
	apellidos		varchar(200) not null,
	telefono			varchar(50) null,
	correoElectronico			varchar(100) null,
	documentoIdentidad	varchar(12) not null,
	activo		bit not null default 1
)
GO
INSERT INTO Cliente values('CLIENTE','GENERAL','00000000','correo@admin.com','00000000',1)
GO
CREATE TABLE Productos(
	productoId		int not null IDENTITY(1,1) PRIMARY KEY,
	nombreProducto varchar(100) not null,
	precioVenta decimal(18,2) not null,
	precioEnvioMinimo  decimal(18,2) not null,
	activo bit not null default 1
)
GO
INSERT INTO Productos values('Pelota Futbol',20.00,5.00,1)
GO
CREATE TABLE Ordenes(
	ordenId		int not null IDENTITY(1,1) PRIMARY KEY,
	clienteId   int not null,
	ordenEstado varchar(20) not null default 'REGISTRADO',
	fechaOrden datetime default getdate(),
	fechaEnvio datetime,
	precioEnvio decimal(18,2) not null,
	subTotal  decimal(18,2) not null,
	totalOrden decimal(18,2) not null,
	activo bit not null default 1,
	FOREIGN KEY (clienteId) REFERENCES  Cliente(clienteId)
)
GO
CREATE TABLE OrdenesDetalle(
	ordenDetalleId		int not null IDENTITY(1,1) PRIMARY KEY,
	ordenId int not null,
	productoId int not null,
	cantidad int not null,
	totalPrecio decimal(18,2) not null,
	activo bit not null default 1,
	FOREIGN KEY (ordenId) REFERENCES  Ordenes(ordenId),
	FOREIGN KEY (productoId) REFERENCES  Productos(productoId)
)
GO