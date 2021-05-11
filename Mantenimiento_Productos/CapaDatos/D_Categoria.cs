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
    public class D_Categoria
    {
        SqlConnection sqlcnx = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        //metodo de mostrar 
        public List <E_Categoria> ListarCategorias(string buscar)
        {
            SqlDataReader LeerFilas;
            SqlCommand sqlcmd = new SqlCommand("sp_BuscarCategoria",sqlcnx);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcnx.Open();

            sqlcmd.Parameters.AddWithValue("@Buscar", buscar);

            LeerFilas = sqlcmd.ExecuteReader();

            List<E_Categoria> Listar = new List<E_Categoria>;
            while (LeerFilas.Read())
            {
                Listar.Add(new E_Categoria
                {
                    IdCategoria = LeerFilas.GetInt32(0),
                    CodigoCategoria=LeerFilas.GetString(1),
                    NombreCategoria=LeerFilas.GetString(2),
                    DescripcionCategoria=LeerFilas.GetString(3)
                });
            }

            sqlcnx.Close();
            LeerFilas.Close();

            return Listar;
        }

        //metodo para insertar
        public void insertarCategoria(E_Categoria categoria)
        {
            SqlCommand sqlcmd = new SqlCommand("sp_InsertarCategoria", sqlcnx);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcnx.Open();

            sqlcmd.Parameters.AddWithValue("@Nombre",categoria.NombreCategoria);
            sqlcmd.Parameters.AddWithValue("@Descripcion",categoria.DescripcionCategoria);

            sqlcmd.ExecuteNonQuery();
            sqlcnx.Close();

        }

        //metodo para editar
        public void editarCategoria(E_Categoria categoria)
        {
            SqlCommand sqlcmd = new SqlCommand("sp_EditarCategoria", sqlcnx);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcnx.Open();

            sqlcmd.Parameters.AddWithValue("@IdCategoria", categoria.IdCategoria);
            sqlcmd.Parameters.AddWithValue("@Nombre", categoria.NombreCategoria);
            sqlcmd.Parameters.AddWithValue("@Descripcion", categoria.DescripcionCategoria);

            sqlcmd.ExecuteNonQuery();
            sqlcnx.Close();

        }
        //metodo para eliminar
        public void eliminarCategoria(E_Categoria categoria)
        {
            SqlCommand sqlcmd = new SqlCommand("sp_EliminarCategoria", sqlcnx);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcnx.Open();

            sqlcmd.Parameters.AddWithValue("@IdCategoria", categoria.IdCategoria);
   
            sqlcmd.ExecuteNonQuery();
            sqlcnx.Close();

        }
    }
}
