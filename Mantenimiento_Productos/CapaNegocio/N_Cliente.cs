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
    public class N_Cliente
    {
        D_Clientes objDClientes = new D_Clientes();
        E_Clientes objEClientes = new E_Clientes();

        #region D_Cliente/N_Cliente
        //Metodo de listado de los clientes entre la capa de Datos de D_cliente y la Capa de Negocio N_Cliente
        public DataTable listandoClientes()
        {
            return objDClientes.listarClientes();
        }
        public DataTable buscarClientes(string buscar)
        {
            objEClientes.BuscarCliente = buscar;
            return objDClientes.buscarClientes(objEClientes);
        }
        public void insertarCliente(E_Clientes cliente)
        {
            objDClientes.insertarClientes(cliente);
        }
        public void editarCliente(E_Clientes cliente)
        {
            objDClientes.editarCliente(cliente);
        }
        public void eliminarCliente(E_Clientes cliente)
        {
            objDClientes.eliminarCliente(cliente);
        }
        #endregion

    }
}
