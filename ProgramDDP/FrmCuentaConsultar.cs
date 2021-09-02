using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Logica;
using Entidades;

namespace ProgramDDP
{
    public partial class FrmCuentaConsultar : Form
    {
        CuentaService oCuentaService = new CuentaService();
        TransaccionService oTransaccionService = new TransaccionService();

        public FrmCuentaConsultar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Ingrese un número de cuenta valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var Cuenta = oCuentaService.Consultar(textBox1.Text);

            if(Cuenta == null)
            {
                panel1.Visible = false;
                limpiar();
                MessageBox.Show("No existe una cuenta coincidente con el número ingresado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            panel1.Visible = true;
            var Transacciones = oTransaccionService.Consultar(Cuenta);
            mapCuenta(Cuenta, Transacciones);
        }

        private void mapCuenta(ICuenta pCuenta, IEnumerable<ITransaccion> pTransacciones)
        {
            dataGridView1.DataSource = pTransacciones;
            textBox2.Text = pCuenta.Numero;
            textBox3.Text = pCuenta.Cliente.Nombre;
            textBox4.Text = pCuenta.Saldo.ToString();
            textBox5.Text = pCuenta.Tipo; 
        }

        private void limpiar()
        {
            dataGridView1.DataSource = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
        }
    }
}
