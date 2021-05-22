use Mantenimiento_Productos

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

