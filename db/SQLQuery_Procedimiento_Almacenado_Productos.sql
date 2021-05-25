use Mantenimiento_Productos;

-- Procedimiento Almacenado de la Busqueda de Productos
create proc sp_BuscarProductos
@buscar nvarchar(20)
as
productos.idproducto, 
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
inner join categoria on productos.idCategoria=categoria.idcategoria
inner join marca on productos.idMarca=marca.idMarca
where productos like @buscar + '%'
order by idProducto asc

