using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EjercicioPatentes.Models;

namespace EjercicioPatentes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string[] lista = new string[7];
        EjRegexMatch regex = null; // 
        EjCharString str = null; // new EjCharString();

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            tbVer.Clear();
            lista[0]= "OXY333";
            lista[1]= "OYZ 013";
            lista[2]= "AAA 123";
            lista[3] = "BCD 456";
            lista[4] = "AB 123 CD";
            lista[5] = "YZ5432EF";  
            lista[6] = "QW 3456 AB";
            string imprimir;
            string patente;
            int i;
            if (rbRegex.Checked)
            {
                regex = new EjRegexMatch();
                for (i = 0; i < lista.Length; i++)
                {
                    patente = lista[i];
                    imprimir = regex.ProcesarPatente(patente, out string nueva);
                    tbVer.Text += imprimir;
                }
            }
            if (rbString.Checked)
            {
                str = new EjCharString();
                for (i = 0; i < lista.Length; i++)
                {
                    patente = lista[i];
                    imprimir = str.ProcesarPatente(patente, out string nueva);
                    tbVer.Text += imprimir;
                }
            }  //cada objeto sabrá cómo procesar su patente
            if(!rbString.Checked && !rbRegex.Checked)
            {
               MessageBox.Show("Seleccione un método para procesar la patente");
            }
            rbRegex.Checked = false;
            rbString.Checked = false;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar == ',')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
