using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class E_Categoria
    {
        //Abstraccion
        private int idCategoria;
        private string codigoCategoria;
        private string nombreCategoria;
        private string descripcionCategoria;

        ///encapsulamiento 


        public int IdCategoria { get { return idCategoria;} set{ idCategoria = value; } }

        public string CodigoCategoria {get{return codigoCategoria;} set{codigoCategoria = value;} }

        public string NombreCategoria
        {
            get
            {
                return nombreCategoria;
            }

            set
            {
                nombreCategoria = value;
            }
        }

        public string DescripcionCategoria
        {
            get
            {
                return descripcionCategoria;
            }

            set
            {
                descripcionCategoria = value;
            }
        }

       

    }
}
