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
    public partial class frmCliente : Form
    {
        N_Cliente objNCliente = new N_Cliente();
        E_Clientes objECliente = new E_Clientes();
        public frmCliente()
        {
            InitializeComponent();
            mostrarTablaClientes();//iniciamos en el constructor la carga del metodo de listado de clientes
            ocultarmMoverAncharColumnas();
        }

        #region MetodosInternos
        //metodo para mostrar los Clientes
        public void mostrarTablaClientes()
        {
            dtgClientes.DataSource = objNCliente.listandoClientes();
        }
        //metodo para buscar Productos 
        public void buscarClientes(string buscar)
        {
            dtgClientes.DataSource = objNCliente.buscarClientes(buscar);

        }
        //metodo para ocutar o mostrar columnas del dtgProductos
        public void ocultarmMoverAncharColumnas()
        {
            dtgClientes.Columns[2].Visible = false;
            //dtgClientes.Columns[5].Visible = false;
            //dtgClientes.Columns[7].Visible = false;
        
            dtgClientes.Columns[0].Width = 40;
            dtgClientes.Columns[1].Width = 40;
            //dtgClientes.Columns[2].Width = 70;
            dtgClientes.Columns[3].Width = 70;
            dtgClientes.Columns[4].Width = 90;
            dtgClientes.Columns[5].Width = 90;
            dtgClientes.Columns[6].Width = 90;
            dtgClientes.Columns[7].Width = 90;
            dtgClientes.Columns[8].Width = 90;

            dtgClientes.Columns[0].DisplayIndex =8;
            dtgClientes.Columns[1].DisplayIndex =8;

        }


        //metodo para mostrar los totales de Productos,categorias y marcas
        //public void contarProductos()
        //{
        //    objNProductos.contabilizarProducto(objEProductos);
        //    lblProductos.Text = objEProductos.TotalProducto;
        //    lblCategorias.Text = objEProductos.TotalCategoria;
        //    lblMarcas.Text = objEProductos.TotalMarca;
        //    lblTotalProductos.Text = objEProductos.SumaProducto;
        //}
        #endregion

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            frmNuevoCliente frm = new frmNuevoCliente();
            frm.ShowDialog();
            frm.Update = false;
            mostrarTablaClientes();
            //contarProductos();
        }

        private void txtBuscarCliente_TextChanged(object sender, EventArgs e)
        {
            buscarClientes(txtBuscarCliente.Text);
          
        }

        private void dtgClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgClientes.Rows[e.RowIndex].Cells["Eliminar"].Selected)
            {
                Form informacion = new frmInformacion("¿Estas Seguro de Eliminar el Producto?");
                DialogResult resultado = informacion.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    int eliminar = Convert.ToInt32(dtgClientes.Rows[e.RowIndex].Cells[2].Value.ToString());
                    //objNCliente.eliminarCliente();
                    frmNotificacion.confirmacionForm("Eliminado");
                    mostrarTablaClientes();
                    //contarProductos();
                }
            }
            else if (dtgClientes.Rows[e.RowIndex].Cells["Editar"].Selected)
            {
                frmNuevoCliente frm = new frmNuevoCliente();
                frm.Update = true;
                frm.txtCodProducto.Text = dtgClientes.Rows[e.RowIndex].Cells["codProducto"].Value.ToString();
                frm.txtIdProducto.Text = dtgClientes.Rows[e.RowIndex].Cells["idProducto"].Value.ToString();
                frm.txtNombreProducto.Text = dtgClientes.Rows[e.RowIndex].Cells["producto"].Value.ToString(); ;
                frm.txtPrecioCompra.Text = dtgClientes.Rows[e.RowIndex].Cells["precio_compra"].Value.ToString();
                frm.txtPrecioVenta.Text = dtgClientes.Rows[e.RowIndex].Cells["precio_venta"].Value.ToString();
                frm.txtStock.Text = dtgClientes.Rows[e.RowIndex].Cells["stock"].Value.ToString();
                frm.cmbCategoria.Text = dtgClientes.Rows[e.RowIndex].Cells["idCategoria"].Value.ToString();
                frm.cmbMarca.Text = dtgClientes.Rows[e.RowIndex].Cells["idMarca"].Value.ToString();

                frm.ShowDialog();
                mostrarTablaClientes();
                //contarProductos();
            }
        }
    }
}
