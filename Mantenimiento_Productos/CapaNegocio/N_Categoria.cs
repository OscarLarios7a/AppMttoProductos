using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaDatos;


namespace CapaNegocio
{
    public class N_Categoria
    {
        D_Categoria objDato = new D_Categoria();

        public List<E_Categoria>ListandoCategoria(string buscar)
        {
            return objDato.ListarCategorias(buscar);
        }
        public void insertandoCategoria(E_Categoria categoria)
        {
            objDato.insertarCategoria(categoria);
        }

        public void editandoCategoria(E_Categoria categoria) {
            objDato.editarCategoria(categoria);
        }

        public void eliminandoCategoria(E_Categoria categoria)
        {
            objDato.eliminarCategoria(categoria);
        }
    }
}
