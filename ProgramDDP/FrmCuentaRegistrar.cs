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
    public partial class FrmCuentaRegistrar : Form
    {
        CuentaService oCuentaService = new CuentaService();

        public FrmCuentaRegistrar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ICuenta oCuenta = abstraerCuenta();
            if(oCuenta == null)
            {
                MessageBox.Show("Complete los campos de la cuenta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            oCuentaService.Guardar(oCuenta); 
            MessageBox.Show("Se ha guardado la cuenta", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private ICuenta abstraerCuenta()
        {
            ICliente oCliente = abstraerCliente();
            if(oCliente == null)
            {
                MessageBox.Show("Complete los campos del cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            ICuenta oCuenta = null;
            if(comboBox2.SelectedIndex == 0)
            {
                oCuenta = new Ahorros()
                {
                    Numero = textBox2.Text,
                    Clave = textBox3.Text,
                    Saldo = 0,
                    Cliente = oCliente
                };
            }
            else if(comboBox2.SelectedIndex == 1)
            {
                oCuenta = new Corriente()
                {
                    Numero = textBox2.Text,
                    Clave = textBox3.Text,
                    Saldo = 0,
                    Cliente = oCliente
                };
            }
            return oCuenta;
        }

        private ICliente abstraerCliente()
        {
            ICliente oCliente = null;
            if (comboBox1.SelectedIndex == 0)
            {
                oCliente = new Persona()
                {
                    Id = textBox8.Text,
                    Nombre = textBox7.Text,
                    Direccion = textBox1.Text,
                    Telefono = textBox6.Text
                };
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                oCliente = new Empresa()
                {
                    Id = textBox8.Text,
                    Nombre = textBox7.Text,
                    Direccion = textBox1.Text,
                    Telefono = textBox6.Text
                };
            }
            return oCliente;
        }
    }
}
