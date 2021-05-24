using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaNegocio;
using CapaEntidades;

namespace CapaPresentacion
{
    public partial class frmProductos : Form
    {
        //instanciamos el objeto de N_Productos

        N_Productos objNProductos = new N_Productos();
        public frmProductos()
        {
            InitializeComponent();
            mostrarTablaProductos();//iniciamos en el constructor la carga del metodo de listado de productos

        }

        public void mostrarTablaProductos()
        {
            dtgProductos.DataSource = objNProductos.listandoProductos();
        }
        
    }
}
