--Procedimientos almacenado buscar categoria---
CREATE PROC sp_BuscarCategoria
@Buscar nvarchar(20)
as
select * from categoria
where nombre like @Buscar + '%'

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