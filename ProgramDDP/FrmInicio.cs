using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgramDDP
{
    public partial class FrmInicio : Form
    {
        FrmCuentaRegistrar oFrmRegistrar { get; set; }
        FrmCuentaConsultar oFrmConsultar { get; set; }
        FrmTransaccion oFrmTransaccion { get; set; }

        public FrmInicio()
        {
            InitializeComponent();
        }

        private void abrir(Form ventana)
        {
            PnBase.Controls.Clear();

            ventana.TopLevel = false;
            PnBase.Controls.Add(ventana);
            PnBase.Tag = true;
            ventana.Dock = DockStyle.Fill;
            ventana.Show();
        }

        private void registrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (oFrmRegistrar == null)
                oFrmRegistrar = new FrmCuentaRegistrar();
            else if (oFrmRegistrar.IsDisposed)
                oFrmRegistrar.Activate();
            abrir(oFrmRegistrar);
        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (oFrmConsultar == null)
                oFrmConsultar = new FrmCuentaConsultar();
            else if (oFrmConsultar.IsDisposed)
                oFrmConsultar.Activate();
            abrir(oFrmConsultar);
        }

        private void transaccionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (oFrmTransaccion == null)
                oFrmTransaccion = new FrmTransaccion();
            else if (oFrmTransaccion.IsDisposed)
                oFrmTransaccion.Activate();
            abrir(oFrmTransaccion);
        }
    }
}
