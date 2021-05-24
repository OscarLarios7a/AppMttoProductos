using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaEntidades;
using CapaDatos;

namespace CapaNegocio
{
    public class N_Productos
    {
        D_Productos objProducto = new D_Productos();

        //metodo para listar los productos
        public DataTable listandoProductos()
        {
            return objProducto.listarProductos();
        }
    }
}
