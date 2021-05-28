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

        ////Se Crea el metodo para listar a los Clientes
        public List<E_Clientes> listarClientes(string buscar)
        {
            SqlDataReader leerFilas;
            SqlCommand cmd = new SqlCommand("sp_BuscarCliente",sqlcnx);
            cmd.CommandType = CommandType.StoredProcedure;
            sqlcnx.Open();
            cmd.Parameters.AddWithValue("@Buscar",buscar);
            leerFilas = cmd.ExecuteReader();

            List<E_Clientes> listarClientes = new List<E_Clientes>();
            while (leerFilas.Read())
            {
                listarClientes.Add(new E_Clientes {
                    IdCliente = leerFilas.GetInt32(0),
                    CodigoCliente = leerFilas.GetString(1),
                    NombreCliente = leerFilas.GetString(2),
                    AClientePaterno = leerFilas.GetString(3),
                    AClienteMaterno = leerFilas.GetString(4),
                    TelefonoCliente = leerFilas.GetString(5),
                    GeneroCliente = leerFilas.GetString(6),
                });
            }
            sqlcnx.Close();
            leerFilas.Close();
            return listarClientes;
        }

    }
}
