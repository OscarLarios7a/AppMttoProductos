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
    }
}
