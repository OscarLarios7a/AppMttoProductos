use Mantenimiento_Productos

--Tabla de Productos //
create table productos(
idProducto int identity(1,1) primary key not null,
codProducto as ('PR'+right('00'+convert(varchar,idProducto),(2))),
producto nvarchar(50)not null,
precio_compra decimal(18,2)null,
precio_venta decimal(18,2)null,
stock int null,
idCategoria int not null, 
idMarca int not null,
constraint relacionar_categoria foreign key (idCategoria) references categoria(idCategoria),
constraint relacionar_marca foreign key (idMarca) references marca(idMarca)
)

-- Proceso Almacenado de Listado de Productos
Create proc sp_ListarProductos
as
select top 100
productos.idProducto,
productos.codProducto,
productos.producto,
productos.idCategoria,
categoria.nombre as categoria,
productos.idMarca,
marca.nombre as Marca,
productos.precio_compra,
productos.precio_venta,
productos.stock
from productos
inner join categoria on productos.idCategoria=categoria.idCategoria
inner join marca on productos.idMarca=marca.idMarca
order by idProducto asc

exec sp_ListarProductos

insert into productos values('SUPER TALADRO',12.50,20,100,3,2)
insert into productos values('SERRUCHO',5.50,10,10,3,3)
insert into productos values('ALICATE',12.50,20,100,3,2)
insert into productos values('WINCHA',12.50,20,100,3,2)
insert into productos values('CEMENTO SOL',12.50,20,100,3,2)
insert into productos values('ARENA',12.50,20,100,3,2)
insert into productos values('CAJA TORNILLO 1P',12.50,20,100,3,2)
insert into productos values('CEMENTO ANDINO',12.50,20,100,3,2)
insert into productos values('CAJA TORNILLOS 2P',12.50,20,100,3,2)
insert into productos values('RODOPLAS',12.50,20,100,3,2)

-- Procedimiento Almacenado de la Busqueda de Productos
create proc sp_BuscarProductos
@buscar nvarchar(20)
as
select top 100
productos.idProducto, 
productos.codProducto,
productos.producto,
productos.idCategoria,
categoria.nombre as Categoria,
productos.idMarca,
marca.nombre as Marca,
productos.precio_compra,
productos.precio_venta,
productos.stock
from productos
inner join categoria on productos.idCategoria=categoria.idCategoria
inner join marca on productos.idMarca=marca.idMarca
where producto like @buscar + '%'
order by idProducto asc

--Procedimiento Almacenado de Insertar Productos
create proc sp_CrearProductos
@producto nvarchar(50),
@precioCompra decimal(18,2),
@precioVenta decimal(18,2),
@stock int,
@idCategoria int,
@idMarca int
as
insert into productos values(@producto ,@precioCompra ,@precioVenta,@stock,@idCategoria, @idMarca)

--Procedimiento Almacenado de Actualizacion de Productos
create proc sp_UpdateProductos
@idProducto int,
@producto nvarchar(50),
@precioCompra decimal(18,2),
@precioVenta decimal(18,2),
@stock int,
@idCategoria int,
@idMarca int
as
update productos set producto=@producto, precio_compra=@precioCompra,precio_venta=@precioVenta,stock= @stock,idCategoria=@idCategoria,idMarca=@idMarca
where idProducto=@idProducto

--Procedimiento Almacenado de Borrar Productos
create proc sp_EliminarProductos
@idProducto int
as 
delete productos
where idProducto=@idProducto

---Procedimiento Almacenado para contar Productos,Categorias, Marcas y sumar Stock de Productos

create proc ap_sumarProducto
@totalCategoria int output,
@totalMarca int output,
@totalProducto int output,
@sumaProducto int output
as
set @totalCategoria = (select count(idCategoria) as Categorias from categoria)
set @totalMarca= (select count(idMarca) as Marcas from marca)
set @totalProducto= (select count(idProducto) as Productos from productos)
set @sumaProducto= (select sum(stock) as Total_Productos from productos)
go


--crear la tabal de Marca
create table marca(
idMarca int identity(1,1)NOT NULL PRIMARY KEY,
codigo as ('MR'+RIGHT('00'+convert(varchar,idMarca),(2))),
nombre nvarchar(30) NOT NULL,
descripcion nvarchar(256) NULL
);
--Procedimientos Almacenados de la Tabla de Marca
create proc sp_BuscarMarca
@Buscar varchar(30)
as
select * from marca 
where nombre like @Buscar + '%'

create proc sp_InsertarMarca
@Nombre varchar(30),
@Descripcion varchar(256)
as
insert into marca values(@Nombre,@Descripcion)

create proc sp_EditarMarca
@IdMarca int,
@Nombre varchar(30),
@Descripcion varchar(256)
as
update marca set nombre=@Nombre, descripcion=@Descripcion
where idMarca=@IdMarca

create proc sp_EliminarMarca
@IdMarca int
as
delete marca
where idMarca=@IdMarca

--Seccion de Categorias --
--Tabla de Categorias
create table categoria(
idCategoria INT IDENTITY(1,1)PRIMARY KEY NOT NULL,
codigo AS ('CT'+ RIGHT	('00' + convert(VARCHAR,idCategoria),(2))),
nombre NVARCHAR(30) NOT NULL,
descripcion NVARCHAR(256) NULL
)

INSERT INTO categoria VALUES ('HERRAMIENTAS','LAS MEJORES HERRAMIENTAS')
INSERT INTO categoria VALUES ('PINTURAS','LAS MEJORES PINTURAS PARA TU CASA')

--Procedimientos almacenado buscar categoria---
CREATE PROC sp_BuscarCategoria
@Buscar nvarchar(20)
as
select * from categoria
where nombre like @Buscar + '%'

/*Seccion para los procedimientos almacenados de la tabla de Categoria */
--PROCEDIMIENTO ALMACENADO DE INSERTAR DATOS EN CATEGORIA---
CREATE PROC sp_InsertarCategoria
@Nombre nvarchar(30),
@Descripcion nvarchar(256)
as
insert into categoria values (@Nombre,@Descripcion)

--PROCEDIMIENTO ALMACENADO DE EDITAR DATOS EN CATEGORIA---
CREATE PROC sp_EditarCategoria
@IdCategoria int,
@Nombre nvarchar(30),
@descripcion nvarchar(256)
as
UPDATE categoria set nombre=@Nombre, descripcion=@descripcion
WHERE idCategoria=@IdCategoria


--PROCEDIMIENTO ALMACENADO DE Eliminar DATOS EN CATEGORIA---
CREATE PROC sp_EliminarCategoria
@IdCategoria int
as
delete categoria
where idCategoria=@IdCategoria

/*Seccion para la tabla de Ventas*/
--tabla Ventas
create table ventas(
idVenta int identity(1,1)primary key not null,
codigoVenta AS ('VNT'+ RIGHT	('00' + convert(VARCHAR,idVenta),(2))),
numeroVenta nvarchar(15),
fecha date,
estado nvarchar(15),
idCliente int not null,
constraint relacionar_cliente foreign key (idCliente) references cliente(idCliente)
)

--//creacion de la tabla detalle de la venta
create table detalleVenta(
	cantidad int,
	descripcion nvarchar(256),
	precio decimal(18,2),
	gravadas decimal(18,2),
	totales decimal(18,2),
	idVenta int not null,
	constraint  relacionar_ventas foreign key(idVenta) references venta(idVenta)

	on update cascade
	on delete cascade

)


--Tabla cliente 
CREATE TABLE cliente (
  idCliente  INT IDENTITY(1,1)PRIMARY KEY NOT NULL,
  codigoCliente AS ('CLT'+ RIGHT	('00' + convert(VARCHAR,idCliente),(2))),
  nombreCliente varchar(35),
  aClientePaterno varchar(35) ,
  aClienteMaterno varchar(35),
  Telefono varchar(15),
  Genero varchar(10)
) 