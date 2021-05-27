using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    //se crea la clase de E_Productos en publico para su manipulacion de datos 
    public class E_Productos
    {
        //creando las variables que se utilizaran para el manejo de los datos 
        private int idProducto;
        private string codigoProducto;
        private string nombreProducto;
        private decimal precioCompra;
        private decimal precioVenta;
        private int stockProducto;
        private int idCategoria;
        private int idMarca;
        private string buscarProducto; // variable que se utilizara para la busqueda de datos 

        //se crean lsa siguientes variables para la asignacion del resultado a los Labels del frmProducto
        private string totalCategoria;
        private string totalMarca;
        private string totalProducto;
        private string sumaProducto;

        public int IdProducto
        {
            get
            {
                return idProducto;
            }

            set
            {
                idProducto = value;
            }
        }

        public string CodigoProducto
        {
            get
            {
                return codigoProducto;
            }

            set
            {
                codigoProducto = value;
            }
        }

        public string NombreProducto
        {
            get
            {
                return nombreProducto;
            }

            set
            {
                nombreProducto = value;
            }
        }

        public decimal PrecioCompra
        {
            get 
            {
                return precioCompra;
            }

            set
            {
                precioCompra = value;
            }
        }

        public decimal PrecioVenta
        {
            get
            {
                return precioVenta;
            }

            set
            {
                precioVenta = value;
            }
        }

        public int StockProducto
        {
            get
            {
                return stockProducto;
            }

            set
            {
                stockProducto = value;
            }
        }

        public int IdCategoria
        {
            get
            {
                return idCategoria;
            }

            set
            {
                idCategoria = value;
            }
        }

        public int IdMarca
        {
            get
            {
                return idMarca;
            }

            set
            {
                idMarca = value;
            }
        }

        public string BuscarProducto
        {
            get
            {
                return buscarProducto;
            }

            set
            {
                buscarProducto = value;
            }
        }

        public string TotalCategoria
        {
            get
            {
                return totalCategoria;
            }

            set
            {
                totalCategoria = value;
            }
        }

        public string TotalMarca
        {
            get
            {
                return totalMarca;
            }

            set
            {
                totalMarca = value;
            }
        }

        public string TotalProducto
        {
            get
            {
                return totalProducto;
            }

            set
            {
                totalProducto = value;
            }
        }

        public string SumaProducto
        {
            get
            {
                return sumaProducto;
            }

            set
            {
                sumaProducto = value;
            }
        }
    }
}
