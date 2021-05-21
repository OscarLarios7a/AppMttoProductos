using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void pctClose_Click(object sender, EventArgs e)
        {
            DialogResult resultado = new DialogResult();
            Form mensaje = new frmInformacion("¿Seguro Desea Salir del Sistema?");
            resultado = mensaje.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                Application.Exit();
                //Llamarias en un Form Login
                //this.Hide();
            }
        }

        //Metodo para para agrandar pantalla sin ocupar la barra de tareas
        public void pantallaMaximizada()
        {
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }
        //metodo para cambiar el color de los botones al ser seleccionados
        public void seleccionBoton(Bunifu.Framework.UI.BunifuFlatButton sender)
        {
            btnDashboard.Textcolor=Color.White;
            btnProductos.Textcolor = Color.White;
            btnVentas.Textcolor = Color.White;
            btnCompras.Textcolor = Color.White;
            btnProveedores.Textcolor = Color.White;
            btnTrabajadores.Textcolor = Color.White;
            btnClientes.Textcolor = Color.White;
            btnGanancias.Textcolor = Color.White;

            sender.selected = true;
            if (sender.selected)
            {
                sender.Textcolor = Color.FromArgb(98,195,140);
            }
        }
        //metodo para seguir la flecha en un boton
        private void seguirBoton(Bunifu.Framework.UI.BunifuFlatButton sender)
        {
            pctFlecha.Top = sender.Top;
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            pantallaMaximizada();
        }

       

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            seleccionBoton((Bunifu.Framework.UI.BunifuFlatButton)sender);
            seguirBoton((Bunifu.Framework.UI.BunifuFlatButton)sender);
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            seleccionBoton((Bunifu.Framework.UI.BunifuFlatButton)sender);
            seguirBoton((Bunifu.Framework.UI.BunifuFlatButton)sender);
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            seleccionBoton((Bunifu.Framework.UI.BunifuFlatButton)sender);
            seguirBoton((Bunifu.Framework.UI.BunifuFlatButton)sender);

        }

        private void btnTrabajadores_Click(object sender, EventArgs e)
        {
            seleccionBoton((Bunifu.Framework.UI.BunifuFlatButton)sender);
            seguirBoton((Bunifu.Framework.UI.BunifuFlatButton)sender);
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            seleccionBoton((Bunifu.Framework.UI.BunifuFlatButton)sender);
            seguirBoton((Bunifu.Framework.UI.BunifuFlatButton)sender);
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            seleccionBoton((Bunifu.Framework.UI.BunifuFlatButton)sender);
            seguirBoton((Bunifu.Framework.UI.BunifuFlatButton)sender);
        }

        private void btnGanancias_Click(object sender, EventArgs e)
        {
            seleccionBoton((Bunifu.Framework.UI.BunifuFlatButton)sender);
            seguirBoton((Bunifu.Framework.UI.BunifuFlatButton)sender);
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            seleccionBoton((Bunifu.Framework.UI.BunifuFlatButton)sender);
            seguirBoton((Bunifu.Framework.UI.BunifuFlatButton)sender);
        }
    }
}
