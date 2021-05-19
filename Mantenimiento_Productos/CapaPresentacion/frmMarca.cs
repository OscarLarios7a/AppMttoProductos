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
    public partial class frmMarca : Form
    {
        //declaraciones variable global
        private string idMarca;
        private bool edicion = false;

        //declaraciones de variables de nuestras capas
        E_Marca objEntidad = new E_Marca();
        N_Marca objNegocio = new N_Marca();

        public frmMarca()
        {
            InitializeComponent();
        }

        private void pctCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmMarca_Load(object sender, EventArgs e)
        {
            mostrarBuscarTabla("");
            accionesTabla();

        }
        //Metodo para mostrar los datos a buscar de mi tabla
        public void mostrarBuscarTabla(string buscar)
        {
            N_Marca objNegocio = new N_Marca();
            dtgMarca.DataSource = objNegocio.ListandoMarca(buscar);
        }
        //metodos para las accciones 
        public void accionesTabla()
        {

            dtgMarca.Columns[0].Visible = false;
            dtgMarca.Columns[1].Width = 60;
            dtgMarca.Columns[2].Width = 170;

            dtgMarca.ClearSelection();
        }

        //metod para limpiar las cajas 
        public void limpiarCajas()
        {
            edicion = false;
            txtCodigoMarca.Text = "";
            txtNombreMarca.Text = "";
            txtdescripcionMarca.Text = "";
            txtNombreMarca.Focus();
        }

        private void btnNuevoMarca_Click(object sender, EventArgs e)
        {
            limpiarCajas();
        }

        private void btnEditarMarca_Click(object sender, EventArgs e)
        {
            if (dtgMarca.SelectedRows.Count > 0)
            {
                edicion = true;
                idMarca = dtgMarca.CurrentRow.Cells[0].Value.ToString();
                txtCodigoMarca.Text = dtgMarca.CurrentRow.Cells[1].Value.ToString();
                txtNombreMarca.Text = dtgMarca.CurrentRow.Cells[2].Value.ToString();
                txtdescripcionMarca.Text = dtgMarca.CurrentRow.Cells[3].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione una fila por favor");
            }
        }

        private void btnEliminarMarca_Click(object sender, EventArgs e)
        {
            if (dtgMarca.SelectedRows.Count > 0)
            {

                objEntidad.IdMarca = Convert.ToInt32(dtgMarca.CurrentRow.Cells[0].Value.ToString());
                objNegocio.eliminandoMarca(objEntidad);

                MessageBox.Show("Se elimino correctamente");
                mostrarBuscarTabla("");
            }
            else
            {
                MessageBox.Show("Seleccione la fila a eliminar");
            }
        }

        private void btnGuardarMarca_Click(object sender, EventArgs e)
        {
            if (edicion == false)
            {
                try
                {
                    objEntidad.NombreMarca = txtNombreMarca.Text.ToUpper();
                    objEntidad.DescripcionMarca  = txtdescripcionMarca.Text.ToUpper();

                    objNegocio.insertandoMarca(objEntidad);

                    //MessageBox.Show("Se guardaron correctamente los Datos");
                    frmNotificacion.confirmacionForm("GUARDADO");
                    mostrarBuscarTabla("");
                    limpiarCajas();

                }
                catch (Exception ex)
                {

                    MessageBox.Show("No se guardaron los Datos" + ex);
                }
            }
            if (edicion == true)
            {
                try
                {
                    objEntidad.IdMarca = Convert.ToInt32(idMarca);
                    objEntidad.NombreMarca = txtNombreMarca.Text.ToUpper();
                    objEntidad.DescripcionMarca = txtdescripcionMarca.Text.ToUpper();

                    objNegocio.editandoMarca(objEntidad);

                    frmNotificacion.confirmacionForm("EDITADO");
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

        private void btnImprimirMarca_Click(object sender, EventArgs e)
        {

        }

        private void btnExcelMarca_Click(object sender, EventArgs e)
        {

        }
    }
}
