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
            ocultarmMoverAncharColumnas();
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
                }
            }
            else if (dtgProductos.Rows[e.RowIndex].Cells["Editar"].Selected)
            {
                frmNuevoProducto frm = new frmNuevoProducto();
                 frm.Update = true;
                frm.txtCodProducto.Text = dtgProductos.Rows[e.RowIndex].Cells["idProducto"].Value.ToString();
                frm.txtIdProducto.Text = dtgProductos.Rows[e.RowIndex].Cells["codProducto"].Value.ToString(); 
                frm.txtNombreProducto.Text = dtgProductos.Rows[e.RowIndex].Cells["producto"].Value.ToString(); ;
                frm.txtPrecioCompra.Text = dtgProductos.Rows[e.RowIndex].Cells["precio_compra"].Value.ToString();
                frm.txtPrecioVenta.Text = dtgProductos.Rows[e.RowIndex].Cells["precio_venta"].Value.ToString();
                frm.txtStock.Text = dtgProductos.Rows[e.RowIndex].Cells["stock"].Value.ToString();
                frm.cmbCategoria.Text = dtgProductos.Rows[e.RowIndex].Cells["idCategoria"].Value.ToString();
                frm.cmbMarca.Text = dtgProductos.Rows[e.RowIndex].Cells["idMarca"].Value.ToString();

            }
        
        }
    }
}
