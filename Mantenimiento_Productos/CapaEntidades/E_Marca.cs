using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class E_Marca
    {
        private int idMarca;
        private string codigoMarca;
        private string nombreMarca;
        private string descripcionMarca;

        public int IdMarca
        { get {return idMarca; } set { idMarca = value; }  }

        public string CodigoMarca
        {
         get { return codigoMarca;}
         set { codigoMarca = value;}
        }

        public string NombreMarca
        {
         get {return nombreMarca;}
         set{nombreMarca = value;}
        }

        public string DescripcionMarca
        {
          get { return descripcionMarca;}
          set{ descripcionMarca = value;}
        }
    }
}
