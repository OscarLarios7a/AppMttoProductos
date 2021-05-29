using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class E_Clientes //se hace q nuestra clase sea publica para que asi podamos acceder a todos sus metodos o variables
    {
        //generando las variables de enterono para la manipulacion de la informacion 
        private int idCliente;
        private string codigoCliente;
        private string nombreCliente;
        private string aClientePaterno;
        private string aClienteMaterno;
        private string telefonoCliente;
        private string generoCliente;

        private string buscarCliente;

        // Seccion para el Encapusalamiento de informacion 
        public int IdCliente
        {
            get
            {
                return idCliente;
            }

            set
            {
                idCliente = value;
            }
        }

        public string CodigoCliente
        {
            get
            {
                return codigoCliente;
            }

            set
            {
                codigoCliente = value;
            }
        }

        public string NombreCliente
        {
            get
            {
                return nombreCliente;
            }

            set
            {
                nombreCliente = value;
            }
        }

        public string AClientePaterno
        {
            get
            {
                return aClientePaterno;
            }

            set
            {
                aClientePaterno = value;
            }
        }

        public string AClienteMaterno
        {
            get
            {
                return aClienteMaterno;
            }

            set
            {
                aClienteMaterno = value;
            }
        }

        public string TelefonoCliente
        {
            get
            {
                return telefonoCliente;
            }

            set
            {
                telefonoCliente = value;
            }
        }

        public string GeneroCliente
        {
            get
            {
                return generoCliente;
            }

            set
            {
                generoCliente = value;
            }
        }

        public string BuscarCliente
        {
            get
            {
                return buscarCliente;
            }

            set
            {
                buscarCliente = value;
            }
        }
    }
}
