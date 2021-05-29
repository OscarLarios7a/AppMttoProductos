using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Carga de las referencias a utilizar dentro de la clase
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using CapaEntidades;


namespace CapaDatos
{
    public class D_Clientes
    {
        SqlConnection sqlcnx = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString); //se instancia la conexion con la base de datos SQL
        //////Se Crea el metodo para listar a los Clientes
        public DataTable listarClientes()
        {
            DataTable tabla = new DataTable();
            SqlDataReader leerFilas; // para leer Datos
            SqlCommand cmd = new SqlCommand("sp_ListarClientes", sqlcnx);
            cmd.CommandType = CommandType.StoredProcedure;
            sqlcnx.Open();

            leerFilas = cmd.ExecuteReader();
            tabla.Load(leerFilas);

            leerFilas.Close();
            sqlcnx.Close();

            return tabla;
        }
        public DataTable buscarClientes(E_Clientes cliente)
        {
            DataTable tabla = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_BuscarClientes", sqlcnx);
            cmd.CommandType = CommandType.StoredProcedure;
            sqlcnx.Open();

            cmd.Parameters.AddWithValue("@Buscar", cliente.BuscarCliente);
            SqlDataAdapter da = new SqlDataAdapter(cmd); // se crea una variable para la consulta general con la tabla de acuerdo al procedimiento almacenado
            da.Fill(tabla);// se rellena los datos a la variable de SqlDataAdapter da para su manipulacion en el DataTable

            sqlcnx.Close();

            return tabla;
        }

        //////Se Crea el metodo para listar a los Clientes
        //public List<E_Clientes> listarClientes(string buscar)
        //{
        //    SqlDataReader leerFilas;
        //    SqlCommand cmd = new SqlCommand("sp_BuscarCliente",sqlcnx);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    sqlcnx.Open();
        //    cmd.Parameters.AddWithValue("@Buscar",buscar);
        //    leerFilas = cmd.ExecuteReader();

        //    List<E_Clientes> listarClientes = new List<E_Clientes>();
        //    while (leerFilas.Read())
        //    {
        //        listarClientes.Add(new E_Clientes {
        //            IdCliente = leerFilas.GetInt32(0),
        //            CodigoCliente = leerFilas.GetString(1),
        //            NombreCliente = leerFilas.GetString(2),
        //            AClientePaterno = leerFilas.GetString(3),
        //            AClienteMaterno = leerFilas.GetString(4),
        //            TelefonoCliente = leerFilas.GetString(5),
        //            GeneroCliente = leerFilas.GetString(6),
        //        });
        //    }
        //    sqlcnx.Close();
        //    leerFilas.Close();
        //    return listarClientes;
        //}
        //metofo para insertar Datos del cliente
        public void insertarClientes(E_Clientes cliente)
        {
            SqlCommand cmd = new SqlCommand("sp_InsertarCliente", sqlcnx);
            cmd.CommandType = CommandType.StoredProcedure;
            sqlcnx.Open();

            cmd.Parameters.AddWithValue("@NombreCliente",cliente.NombreCliente);
            cmd.Parameters.AddWithValue("@aClientePaterno",cliente.AClientePaterno);
            cmd.Parameters.AddWithValue("@aClienteMaterno",cliente.AClienteMaterno) ;
            cmd.Parameters.AddWithValue("@telefonoCliente",cliente.TelefonoCliente);
            cmd.Parameters.AddWithValue("@generoCliente",cliente.GeneroCliente);

            cmd.ExecuteNonQuery();
            sqlcnx.Close();

        }
        //metodo para editar los Datos del cliente
        public void editarCliente(E_Clientes cliente)
        {
            SqlCommand cmd = new SqlCommand("sp_EditarCliente", sqlcnx);
            cmd.CommandType = CommandType.StoredProcedure;
            sqlcnx.Open();

            cmd.Parameters.AddWithValue("@idCliente", cliente.IdCliente);
            cmd.Parameters.AddWithValue("@NombreCliente", cliente.NombreCliente);
            cmd.Parameters.AddWithValue("@aClientePaterno", cliente.AClientePaterno);
            cmd.Parameters.AddWithValue("@aClienteMaterno", cliente.AClienteMaterno);
            cmd.Parameters.AddWithValue("@telefonoCliente", cliente.TelefonoCliente);
            cmd.Parameters.AddWithValue("@generoCliente", cliente.GeneroCliente);

            cmd.ExecuteNonQuery();
            sqlcnx.Close();
        }

        //metod para eliminar los datos del cliente
        public void eliminarCliente(E_Clientes cliente)
        {
            SqlCommand cmd = new SqlCommand("sp_EliminarCliente", sqlcnx);
            cmd.CommandType = CommandType.StoredProcedure;
            sqlcnx.Open();

            cmd.Parameters.AddWithValue("@idCliente", cliente.IdCliente);

            cmd.ExecuteNonQuery();
            sqlcnx.Close();
        }

    }
}
