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
        N_Productos objNProducto = new N_Productos();
        E_Productos objEProductos = new E_Productos();


        public bool Update = false; //Declaro una varibale booleana para la manipulacion de los objetos que tenga mi frmNuevoProducto
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

        private void btnGuardarProducto_Click(object sender, EventArgs e)
        {
            if (Update == false) //para que nuestra variable boolena 
            {
                try
                {
                    objEProductos.NombreProducto = txtNombreProducto.Text;
                    objEProductos.PrecioCompra=Convert.ToDecimal( txtPrecioCompra.Text);
                    objEProductos.PrecioVenta = Convert.ToDecimal(txtPrecioVenta.Text);
                    objEProductos.StockProducto= Convert.ToInt32(txtStock.Text);
                    objEProductos.IdCategoria= Convert.ToInt32(cmbCategoria.SelectedValue);
                    objEProductos.IdMarca= Convert.ToInt32( cmbMarca.SelectedValue);

                    objNProducto.insertarProductos(objEProductos);
                    frmNotificacion.confirmacionForm("Producto Guardado");
                    Close();
                    

                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo guardar la categoria" + ex);
                }
            }
            if (Update==true)
            {
                try
                {
                    objEProductos.IdProducto = Convert.ToInt32(txtIdProducto.Text);
                    objEProductos.NombreProducto = txtNombreProducto.Text;
                    objEProductos.PrecioCompra = Convert.ToDecimal(txtPrecioCompra.Text);
                    objEProductos.PrecioVenta = Convert.ToDecimal(txtPrecioVenta.Text);
                    objEProductos.StockProducto = Convert.ToInt32(txtStock.Text);
                    objEProductos.IdCategoria = Convert.ToInt32(cmbCategoria.SelectedValue);
                    objEProductos.IdMarca = Convert.ToInt32(cmbMarca.SelectedValue);

                    objNProducto.updateProductos(objEProductos);
                    frmNotificacion.confirmacionForm("Producto Actualizado");
                    Close();
                    Update = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo editar la categoria" + ex);
                }
               
            }
        }
    }
}
