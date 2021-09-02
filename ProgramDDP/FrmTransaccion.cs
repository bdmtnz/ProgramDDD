using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Entidades;
using Logica;

namespace ProgramDDP
{
    public partial class FrmTransaccion : Form
    {
        TransaccionService oTransaccionService = new TransaccionService();
        CuentaService oCuentaService = new CuentaService();

        public FrmTransaccion()
        {
            InitializeComponent();
        }

        private void FrmTransaccion_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ITransaccion oTransaccion = abstraerTransaccion();
            if(oTransaccion == null)
            {
                MessageBox.Show("Complete los campos de la transacción", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (String.IsNullOrEmpty(textBox6.Text))
            {
                MessageBox.Show("Clave invalida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                var Origen = oCuentaService.Consultar(textBox1.Text);
                if(Origen == null)
                {
                    MessageBox.Show("Número de cuenta de origen invalido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if(Origen.Clave != textBox6.Text)
                {
                    MessageBox.Show("Clave invalida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (panel1.Visible)
                {
                    var Destino = oCuentaService.Consultar(textBox7.Text);
                    if (Destino == null)
                    {
                        MessageBox.Show("Número de cuenta de origen invalido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            oTransaccionService.Guardar(oTransaccion);
            if(oTransaccionService.HuboError)
                MessageBox.Show(oTransaccionService.ErrorDescripcion, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("Se ha guardado la transacción", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private ITransaccion abstraerTransaccion()
        {
            ITransaccion oTransaccion = null;
            if(comboBox1.SelectedIndex == 0)
            {
                oTransaccion = new Retiro()
                {
                    Origen = oCuentaService.Consultar(textBox1.Text),
                    Saldo = (double)numericUpDown1.Value
                };
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                oTransaccion = new Consignacion()
                {
                    Destino = oCuentaService.Consultar(textBox1.Text),
                    Saldo = (double)numericUpDown1.Value
                };
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                oTransaccion = new Transferencia()
                {
                    Origen = oCuentaService.Consultar(textBox1.Text),
                    Destino = oCuentaService.Consultar(textBox7.Text),
                    Saldo = (double)numericUpDown1.Value
                };
            }
            return oTransaccion;
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            var combo = sender as ComboBox;
            if(combo.SelectedIndex == 2)
            {
                panel1.Visible = true;
            }
            else
            {
                panel1.Visible = false;
                textBox7.Text = "";
            }
        }
    }
}
