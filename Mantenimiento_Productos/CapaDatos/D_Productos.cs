using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using CapaEntidades;
using System.Data;

namespace CapaDatos
{
    public class D_Productos
    {
        SqlConnection sqlcnx = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        //Se crea el metodo para listar los productos
        public DataTable listarProductos()
        {
            DataTable tabla = new DataTable();
            SqlDataReader leerFilas; // para leer Datos
            SqlCommand cmd = new SqlCommand("sp_ListarProductos",sqlcnx);
            cmd.CommandType = CommandType.StoredProcedure;
            sqlcnx.Open();

            leerFilas = cmd.ExecuteReader();
            tabla.Load(leerFilas);

            leerFilas.Close();
            sqlcnx.Close();

            return tabla;
        }
        //metodo para la busqueda de productos en una tabla 
        public DataTable buscarProductos(E_Productos producto)
        {
            DataTable tabla = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_BuscarProductos", sqlcnx);//hago la conexion con el procedimiento almacenado de mi DB
            cmd.CommandType = CommandType.StoredProcedure; //ejecuto el procedimienot almacenado
            sqlcnx.Open(); //abro la conexion con la DB

            cmd.Parameters.AddWithValue("@buscar", producto.BuscarProducto);// paso el valor al procedimiento almacenado de mi E_producto de la variable de buscarProducto

            SqlDataAdapter da = new SqlDataAdapter(cmd); // se crea una variable para la consulta general con la tabla de acuerdo al procedimiento almacenado
            da.Fill(tabla);// se rellena los datos a la variable de SqlDataAdapter da para su manipulacion en el DataTable

            sqlcnx.Close();
            
            return tabla;
        }
        //metodo para inserta Productos
        public void insertarProductos(E_Productos producto)
        {
            SqlCommand cmd = new SqlCommand("sp_CrearProductos", sqlcnx);//hago la conexion con el procedimiento almacenado de mi DB
            cmd.CommandType = CommandType.StoredProcedure; //ejecuto el procedimienot almacenado
            sqlcnx.Open(); //abro la conexion con la DB

            cmd.Parameters.AddWithValue("@producto", producto.NombreProducto);// paso el valor al procedimiento almacenado de mi E_producto de la variable de  producto.NombreProducto
            cmd.Parameters.AddWithValue("@precioCompra", producto.PrecioCompra);// paso el valor al procedimiento almacenado de mi E_producto de la variable de producto.PrecioCompra
            cmd.Parameters.AddWithValue("@precioVenta", producto.PrecioVenta);// paso el valor al procedimiento almacenado de mi E_producto de la variable de producto.PrecioVenta
            cmd.Parameters.AddWithValue("@stock", producto.StockProducto);// paso el valor al procedimiento almacenado de mi E_producto de la variable de producto.StockProducto
            cmd.Parameters.AddWithValue("@idCategoria", producto.IdCategoria);// paso el valor al procedimiento almacenado de mi E_producto de la variable de producto.IdCategoria
            cmd.Parameters.AddWithValue("@idMarca", producto.IdMarca);// paso el valor al procedimiento almacenado de mi E_producto de la variable de producto.IdMarca

            cmd.ExecuteNonQuery();//se realizar para modificaciones de objetos en la base de datos o una tabla
            sqlcnx.Close();

        }

        //metodo para la actualizacion de productos
        public void updateProductos(E_Productos producto)
        {
            SqlCommand cmd = new SqlCommand("sp_UpdateProductos", sqlcnx);//hago la conexion con el procedimiento almacenado de mi DB
            cmd.CommandType = CommandType.StoredProcedure; //ejecuto el procedimienot almacenado
            sqlcnx.Open(); //abro la conexion con la DB

            cmd.Parameters.AddWithValue("@@idProducto ", producto.IdProducto);// paso el valor al procedimiento almacenado de mi E_producto de la variable de  producto.NombreProducto
            cmd.Parameters.AddWithValue("@producto", producto.NombreProducto);// paso el valor al procedimiento almacenado de mi E_producto de la variable de  producto.NombreProducto
            cmd.Parameters.AddWithValue("@precioCompra", producto.PrecioCompra);// paso el valor al procedimiento almacenado de mi E_producto de la variable de producto.PrecioCompra
            cmd.Parameters.AddWithValue("@precioVenta", producto.PrecioVenta);// paso el valor al procedimiento almacenado de mi E_producto de la variable de producto.PrecioVenta
            cmd.Parameters.AddWithValue("@stock", producto.StockProducto);// paso el valor al procedimiento almacenado de mi E_producto de la variable de producto.StockProducto
            cmd.Parameters.AddWithValue("@idCategoria", producto.IdCategoria);// paso el valor al procedimiento almacenado de mi E_producto de la variable de producto.IdCategoria
            cmd.Parameters.AddWithValue("@idMarca", producto.IdMarca);// paso el valor al procedimiento almacenado de mi E_producto de la variable de producto.IdMarca

            cmd.ExecuteNonQuery();//se realizar para modificaciones de objetos en la base de datos o una tabla
            sqlcnx.Close();
        }
        //metodo para Eliminar Productos
        public void eliminarProductos(int idProducto)
        {
            SqlCommand cmd = new SqlCommand("sp_EliminarProductos", sqlcnx);//hago la conexion con el procedimiento almacenado de mi DB
            cmd.CommandType = CommandType.StoredProcedure; //ejecuto el procedimienot almacenado
            sqlcnx.Open(); //abro la conexion con la DB

            cmd.Parameters.AddWithValue("@idProducto",idProducto);// paso el valor al procedimiento almacenado de mi E_producto de la variable de buscarProducto
            cmd.ExecuteNonQuery();//se realizar para modificaciones de objetos en la base de datos o una tabla
            sqlcnx.Close();

        }

        //metodo para mostrar los totales de Maca,Categoria y Producto
        public void contabilizarProductos(E_Productos producto)
        {
            SqlCommand cmd = new SqlCommand("ap_sumarProducto", sqlcnx);//hago la conexion con el procedimiento almacenado de mi DB
            cmd.CommandType = CommandType.StoredProcedure; //ejecuto el procedimienot almacenado

            SqlParameter totalCategorias = new SqlParameter("@totalCategoria", 0);
            totalCategorias.Direction = ParameterDirection.Output;

            SqlParameter totalMarcas = new SqlParameter("@totalMarca", 0);
            totalMarcas.Direction = ParameterDirection.Output;

            SqlParameter totalProductos = new SqlParameter("@totalProducto", 0);
            totalProductos.Direction = ParameterDirection.Output;

            SqlParameter sumaProductos = new SqlParameter("@sumaProducto", 0);
            sumaProductos.Direction = ParameterDirection.Output;

            cmd.Parameters.Add(totalCategorias);
            cmd.Parameters.Add(totalMarcas);
            cmd.Parameters.Add(totalProductos);
            cmd.Parameters.Add(sumaProductos);
            sqlcnx.Open();
            cmd.ExecuteNonQuery();

            producto.TotalCategoria = cmd.Parameters["@totalCategoria"].Value.ToString();
            producto.TotalMarca = cmd.Parameters["@totalMarca"].Value.ToString();
            producto.TotalProducto = cmd.Parameters["@totalProducto"].Value.ToString();
            producto.SumaProducto = cmd.Parameters["@sumaProducto"].Value.ToString();

            sqlcnx.Close();

        }
    }
}
