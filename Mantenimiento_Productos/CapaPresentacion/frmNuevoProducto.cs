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
    public partial class frmNuevoProducto : Form
    {
        N_Categoria objNCategoria = new N_Categoria();
        N_Marca objNMarca = new N_Marca();

        public frmNuevoProducto()
        {
            InitializeComponent();
            listarCategorias();
            listarMarcas();
        }
        //metodo para rellenar el cmbCategoria 
        public void listarCategorias()
        {
            cmbCategoria.DataSource = objNCategoria.ListandoCategoria("");
            cmbCategoria.ValueMember = "idCategoria";
            cmbCategoria.DisplayMember = "nombreCategoria";
        }

        //metodo para rellenar el cmbMarca
        public void listarMarcas()
        {
            cmbMarca.DataSource = objNMarca.ListandoMarca("");
            cmbMarca.ValueMember = "idMarca";
            cmbMarca.DisplayMember = "nombreMarca";
        }
        private void pctCerrar_Click(object sender, EventArgs e)
        {
            frmNuevoProducto.ActiveForm.Close();
        }
    }
}
