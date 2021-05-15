using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class frmCategoria : Form
    {
        //declaraciones variable global
        private string idCategoria;
        private bool edicion = false;

        //declaraciones de variables de nuestras capas
        E_Categoria objEntidad = new E_Categoria();
        N_Categoria objNegocio = new N_Categoria();
        public frmCategoria()
        {
            InitializeComponent();
        }

        private void pctCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmCategoria_Load(object sender, EventArgs e)
        {
            mostrarBuscarTabla("");
            accionesTabla();
        }

        //Metodo para mostrar los datos a buscar de mi tabla
        public void mostrarBuscarTabla(string buscar)
        {
            N_Categoria objNegocio = new N_Categoria();
            dtgCategoria.DataSource = objNegocio.ListandoCategoria(buscar);
        }

        //metodos para las accciones 
        public void accionesTabla()
        {
            
            dtgCategoria.Columns[0].Visible = false;
            dtgCategoria.Columns[1].Width = 60;
            dtgCategoria.Columns[2].Width = 170;

            dtgCategoria.ClearSelection();
        }

        //metod para limpiar las cajas 
        public void limpiarCajas()
        {
            edicion = false;
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtdescripcion.Text = "";
            txtNombre.Focus();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            mostrarBuscarTabla(txtBuscar.Text);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiarCajas();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dtgCategoria.SelectedRows.Count > 0)
            {
                edicion = true;
                idCategoria = dtgCategoria.CurrentRow.Cells[0].Value.ToString();
                txtCodigo.Text= dtgCategoria.CurrentRow.Cells[1].Value.ToString();
                txtNombre.Text= dtgCategoria.CurrentRow.Cells[2].Value.ToString();
                txtdescripcion.Text= dtgCategoria.CurrentRow.Cells[3].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione una fila por favor");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (edicion == false)
            {
                try
                {
                    objEntidad.NombreCategoria = txtNombre.Text.ToUpper();
                    objEntidad.DescripcionCategoria = txtdescripcion.Text.ToUpper();

                    objNegocio.insertandoCategoria(objEntidad);

                    MessageBox.Show("Se guardaron correctamente los Datos");
                    mostrarBuscarTabla("");
                    limpiarCajas();

                }
                catch (Exception ex)
                {

                    MessageBox.Show("No se guardaron los Datos"+ ex);
                }
            }
            if (edicion == true)
            {
                try
                {
                    objEntidad.IdCategoria = Convert.ToInt32(idCategoria);
                    objEntidad.NombreCategoria = txtNombre.Text.ToUpper();
                    objEntidad.DescripcionCategoria = txtdescripcion.Text.ToUpper();

                    objNegocio.editandoCategoria(objEntidad);

                    MessageBox.Show("Se Edito correctamente los Datos");
                    mostrarBuscarTabla("");
                    limpiarCajas();
                    edicion = false;

                }
                catch (Exception ex)
                {

                    MessageBox.Show("No se editaron los Datos" + ex);
                }
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dtgCategoria.SelectedRows.Count > 0)
            {

                objEntidad.IdCategoria = Convert.ToInt32( dtgCategoria.CurrentRow.Cells[0].Value.ToString());
                objNegocio.eliminandoCategoria(objEntidad);

                MessageBox.Show("Se elimino correctamente");
                mostrarBuscarTabla("");
            }
            else
            {
                MessageBox.Show("Seleccione la fila a eliminar");
            }
        }
    }
}
