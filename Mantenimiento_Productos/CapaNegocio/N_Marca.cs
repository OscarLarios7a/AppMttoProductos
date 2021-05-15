using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaDatos;

namespace CapaNegocio
{
    public class N_Marca
    {
        D_Marca objDato = new D_Marca();

        public List<E_Marca> ListandoMarca(string buscar)
        {
            return objDato.ListarMarcas(buscar);
        }
        public void insertandoMarca(E_Marca marca)
        {
            objDato.insertarMarca(marca);
        }

        public void editandoMarca(E_Marca marca)
        {
            objDato.editarMarca(marca);
        }

        public void eliminandoMarca(E_Marca marca)
        {
            objDato.eliminarMarca(marca);
        }
    }
}
