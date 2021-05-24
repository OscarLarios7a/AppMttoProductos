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
            SqlDataReader leerFilas;
            SqlCommand cmd = new SqlCommand("sp_ListarProductos",sqlcnx);
            cmd.CommandType = CommandType.StoredProcedure;
            sqlcnx.Open();

            leerFilas = cmd.ExecuteReader();
            tabla.Load(leerFilas);

            leerFilas.Close();
            sqlcnx.Close();

            return tabla;
        }
    }
}
