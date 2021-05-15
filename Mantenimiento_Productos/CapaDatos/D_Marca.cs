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
    public class D_Marca
    {
        SqlConnection sqlcnx = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        //metodo de mostrar 
        public List<E_Marca> ListarMarcas(string buscar)
        {
            SqlDataReader LeerFilas;
            SqlCommand sqlcmd = new SqlCommand("sp_BuscarMarca", sqlcnx);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcnx.Open();
            sqlcmd.Parameters.AddWithValue("@Buscar", buscar);
            LeerFilas = sqlcmd.ExecuteReader();

            List<E_Marca> Listar = new List<E_Marca>();
            while (LeerFilas.Read())
            {
                Listar.Add(new E_Marca
                {
                    IdMarca = LeerFilas.GetInt32(0),
                    CodigoMarca = LeerFilas.GetString(1),
                    NombreMarca = LeerFilas.GetString(2),
                    DescripcionMarca = LeerFilas.GetString(3)
                });
            }

            sqlcnx.Close();
            LeerFilas.Close();
            return Listar;
        }

        //metodo para insertar
        public void insertarMarca(E_Marca marca)
        {
            SqlCommand sqlcmd = new SqlCommand("sp_InsertarMarca", sqlcnx);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcnx.Open();
            sqlcmd.Parameters.AddWithValue("@Nombre", marca.NombreMarca);
            sqlcmd.Parameters.AddWithValue("@Descripcion", marca.DescripcionMarca);
            sqlcmd.ExecuteNonQuery();
            sqlcnx.Close();

        }

        //metodo para editar
        public void editarMarca(E_Marca marca)
        {
            SqlCommand sqlcmd = new SqlCommand("sp_EditarMarca", sqlcnx);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcnx.Open();
            sqlcmd.Parameters.AddWithValue("@IdMarca", marca.IdMarca);
            sqlcmd.Parameters.AddWithValue("@Nombre", marca.NombreMarca);
            sqlcmd.Parameters.AddWithValue("@Descripcion", marca.DescripcionMarca);
            sqlcmd.ExecuteNonQuery();
            sqlcnx.Close();

        }
        //metodo para eliminar
        public void eliminarMarca(E_Marca marca)
        {
            SqlCommand sqlcmd = new SqlCommand("sp_EliminarMarca", sqlcnx);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcnx.Open();
            sqlcmd.Parameters.AddWithValue("@IdMarca", marca.IdMarca);
            sqlcmd.ExecuteNonQuery();
            sqlcnx.Close();

        }
    }
}
