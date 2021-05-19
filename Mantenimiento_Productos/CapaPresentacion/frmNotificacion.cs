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
    public partial class frmNotificacion : Form
    {
        public frmNotificacion(string mensaje)
        {
            InitializeComponent();
            lblMensaje.Text = mensaje;

        }

        private void frmNotificacion_Load(object sender, EventArgs e)
        {
            frmfadeTransition.ShowAsyc(this);
        }

        //
        public static void confirmacionForm(string mensaje)
        {
            frmNotificacion frm = new frmNotificacion(mensaje);
            frm.ShowDialog();
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
