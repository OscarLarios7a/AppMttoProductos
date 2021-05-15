use Mantenimiento_Productos

create table marca(
idMarca int identity(1,1)NOT NULL PRIMARY KEY,
codigo as ('MR'+RIGHT('00'+convert(varchar,idMarca),(2))),
nombre nvarchar(30) NOT NULL,
descripcion nvarchar(256) NULL
);
--
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


