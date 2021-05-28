using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaDatos;

namespace CapaNegocio
{
    public class N_Cliente
    {
        D_Clientes objClientes = new D_Clientes();

        #region D_Cliente/N_Cliente
        //Metodo de listado de los clientes entre la capa de Datos de D_cliente y la Capa de Negocio N_Cliente
        public List<E_Clientes> listandoClientes(string cliente)
        {
            return objClientes.listarClientes(cliente);
        }
        public void insertarCliente(E_Clientes cliente)
        {
            objClientes.insertarClientes(cliente);
        }
        public void editarCliente(E_Clientes cliente)
        {
            objClientes.editarCliente(cliente);
        }
        public void eliminarCliente(E_Clientes cliente)
        {
            objClientes.eliminarCliente(cliente);
        }
        #endregion

    }
}
