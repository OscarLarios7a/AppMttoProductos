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
        E_Productos objEProductos = new E_Productos();
        public frmProductos()
        {
            InitializeComponent();
            mostrarTablaProductos();//iniciamos en el constructor la carga del metodo de listado de productos
            ocultarmMoverAncharColumnas();
            contarProductos();
        }


        //Creaciones de Metodos
        //metodo para mostras los datos de la DB "Mantenimiento_Productos -> Productos"
        public void mostrarTablaProductos()
        {
            dtgProductos.DataSource = objNProductos.listandoProductos();
        }
        //metodo para buscar Productos 
        public void buscarProductos(string buscar)
        {
            dtgProductos.DataSource = objNProductos.buscarProductos(buscar);
        }
        //metodo para ocutar o mostrar columnas del dtgProductos
        public void ocultarmMoverAncharColumnas()
        {
            dtgProductos.Columns[2].Visible = false;
            dtgProductos.Columns[5].Visible = false;
            dtgProductos.Columns[7].Visible = false;

            dtgProductos.Columns[0].Width = 50;
            dtgProductos.Columns[1].Width = 50;
            dtgProductos.Columns[3].Width = 90;
            dtgProductos.Columns[4].Width = 200;

            dtgProductos.Columns[0].DisplayIndex=11;
            dtgProductos.Columns[1].DisplayIndex =11;

        }

        //metodo para mostrar los totales de Productos,categorias y marcas
        public void contarProductos()
        {
            objNProductos.contabilizarProducto(objEProductos);
            lblProductos.Text = objEProductos.TotalProducto;
            lblCategorias.Text = objEProductos.TotalCategoria;
            lblMarcas.Text = objEProductos.TotalMarca;
            lblTotalProductos.Text = objEProductos.SumaProducto;
        } 

        private void txtBuscarProducto_TextChanged(object sender, EventArgs e)
        {
            buscarProductos(txtBuscarProducto.Text);
        }

        private void btnNuevoProducto_Click(object sender, EventArgs e)
        {
            frmNuevoProducto frm = new frmNuevoProducto();
            frm.ShowDialog();
            frm.Update = false;
            mostrarTablaProductos();
            contarProductos();
        }

        private void dtgProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgProductos.Rows[e.RowIndex].Cells["Eliminar"].Selected)
            {
                Form informacion = new frmInformacion("¿Estas Seguro de Eliminar el Producto?");
                DialogResult resultado = informacion.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    int eliminar = Convert.ToInt32(dtgProductos.Rows[e.RowIndex].Cells[2].Value.ToString());
                    objNProductos.eliminarProducto(eliminar);
                    frmNotificacion.confirmacionForm("Eliminado");
                    mostrarTablaProductos();
                    contarProductos();
                }
            }
            else if (dtgProductos.Rows[e.RowIndex].Cells["Editar"].Selected)
            {
                frmNuevoProducto frm = new frmNuevoProducto(); 
                 frm.Update = true;
                frm.txtCodProducto.Text = dtgProductos.Rows[e.RowIndex].Cells["codProducto"].Value.ToString();
                frm.txtIdProducto.Text = dtgProductos.Rows[e.RowIndex].Cells["idProducto"].Value.ToString(); 
                frm.txtNombreProducto.Text = dtgProductos.Rows[e.RowIndex].Cells["producto"].Value.ToString(); ;
                frm.txtPrecioCompra.Text = dtgProductos.Rows[e.RowIndex].Cells["precio_compra"].Value.ToString();
                frm.txtPrecioVenta.Text = dtgProductos.Rows[e.RowIndex].Cells["precio_venta"].Value.ToString();
                frm.txtStock.Text = dtgProductos.Rows[e.RowIndex].Cells["stock"].Value.ToString();
                frm.cmbCategoria.Text = dtgProductos.Rows[e.RowIndex].Cells["idCategoria"].Value.ToString();
                frm.cmbMarca.Text = dtgProductos.Rows[e.RowIndex].Cells["idMarca"].Value.ToString();

                frm.ShowDialog();
                mostrarTablaProductos();
                contarProductos();
            }
        
        }

        private void btnOpenCategoria_Click(object sender, EventArgs e)
        {
            frmCategoria frmOpenCategoria = new frmCategoria();
            frmOpenCategoria.ShowDialog();
            contarProductos();
        }

        private void btnOpenMarca_Click(object sender, EventArgs e)
        {
            frmMarca frmOpenMarca = new frmMarca();
            frmOpenMarca.ShowDialog();
            contarProductos();
        }

        private void btnImportarExcel_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook libro = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet hoja = null;
            hoja = libro.Sheets[1];
            //libro. = "Libro_Producto";
            hoja.Name = "Productos";

            for (int i = 3; i < dtgProductos.Columns.Count + 1; i++)
            {
                hoja.Cells[1, i] = dtgProductos.Columns[i - 1].HeaderText;
            }

            for (int i = 0; i < dtgProductos.Rows.Count; i++)
            {
                for (int j = 0; j < dtgProductos.Columns.Count; j++)
                {
                    hoja.Cells[i + 2, j + 1] = dtgProductos.Rows[i].Cells[j].Value.ToString();
                }
            }
            app.Visible = true;
        }
    }
}
