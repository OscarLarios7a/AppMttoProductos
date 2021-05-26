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

            dtgProductos.Columns[0].DisplayIndex=10;
            dtgProductos.Columns[1].DisplayIndex =10;

        }

        private void txtBuscarProducto_TextChanged(object sender, EventArgs e)
        {
            buscarProductos(txtBuscarProducto.Text);
        }

        private void btnNuevoProducto_Click(object sender, EventArgs e)
        {
            frmNuevoProducto frm = new frmNuevoProducto();
            frm.ShowDialog();
            //frm.Update = false;
            //mostrarTablaProductos();
        }
    }
}
