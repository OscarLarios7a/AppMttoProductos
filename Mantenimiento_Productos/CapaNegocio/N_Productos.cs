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
        E_Productos objEProductos = new E_Productos();
        D_Productos objProducto = new D_Productos();

        //metodo para listar los productos
        public DataTable listandoProductos()
        {
            return objProducto.listarProductos();
        }
        //metodo para buscar los productos
        public DataTable buscarProductos(string buscar)
        {
            objEProductos.BuscarProducto = buscar;
            return objProducto.buscarProductos(objEProductos);
        }
        //metodo para insertar productos
        public void insertarProductos(E_Productos producto)
        {
            objProducto.insertarProductos(producto);
        }

        //metodo para actualizar productos
        public void updateProductos(E_Productos producto)
        {
            objProducto.updateProductos(producto);
        }
        //metodo para Eliminar Productos
        public void eliminarProducto(int idProducto)
        {
              objProducto.eliminarProductos(idProducto);
        }

    }
}
