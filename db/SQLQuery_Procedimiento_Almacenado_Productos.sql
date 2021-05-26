use Mantenimiento_Productos;
--Procdimiento Almacenado de Listar productos
create proc sp_ListarProductos
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
order by idProducto asc




