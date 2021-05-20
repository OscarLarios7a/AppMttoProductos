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
    public partial class frmInformacion : Form
    {
        public frmInformacion( string mensaje)
        {
            InitializeComponent();
            lblMensaje.Text = mensaje;
        }

        private void frmInformacion_Load(object sender, EventArgs e)
        {
            esclarecerForm.ShowAsyc(this);

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
