using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora_V1
{
    public partial class Calculadora : Form
    {
        public Calculadora()
        {
            InitializeComponent();
        }


        private void btn0_Click(object sender, EventArgs e)
        {
            Ebibir("0");
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            Ebibir("1");
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            Ebibir("2");
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            Ebibir("3");
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            Ebibir("4");
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            Ebibir("5");
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            Ebibir("6");
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            Ebibir("7");
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            Ebibir("8");
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            Ebibir("9");
        }
        private void btnVirgula_Click(object sender, EventArgs e)
        {
            if (!txtBox.Text.Contains(","))
            {
                if(txtBox.Text == "0")
                {
                    Ebibir("0,");
                }
                else
                {
                    Ebibir(",");
                }
      
            }
        }
        private void btnSomar_Click(object sender, EventArgs e)
        {
            Atribuicao("+");
        }
        private void btnSubtrair_Click(object sender, EventArgs e)
        {
            Atribuicao("-");
        }

        private void btnMultiplicar_Click(object sender, EventArgs e)
        {
            Atribuicao("x");
        }

        private void btnDividir_Click(object sender, EventArgs e)
        {
            Atribuicao("÷");
        }
        private void btnRaiz_Click(object sender, EventArgs e)
        {
            Atribuicao("²√");
        }
        private void btnPorcentagem_Click(object sender, EventArgs e)
        {
            Atribuicao("%");
        }
        private void btnIgual_Click(object sender, EventArgs e)
        {
            Valor2 = double.Parse(txtBox.Text.Replace(",", "."), CultureInfo.InvariantCulture);
            if (lblOperador.Text == "+")
            {
                Aux = Valor1 + Valor2;
            }
            if (lblOperador.Text == "-")
            {
                Aux = Valor1 - Valor2;
            }
            if (lblOperador.Text == "x")
            {
                Aux = Valor1 * Valor2;
            }
            if (lblOperador.Text == "÷")
            {
                Aux = Valor1 / Valor2;
            }
            if (lblOperador.Text == "%")
            {
                Aux = Valor1 * Aux;
            }
            if (lblOperador.Text == "²√")
            {
                lblOperador.Text = "";
                txtBox.Text = "0";
                return;
            }
            txtBox.Text = Math.Round(Aux, 2).ToString();
        }
        public double Valor1 = 0;
        public double Valor2 = 0;
        public double Aux = 0;
        private void Atribuicao(string operador)
        {

            lblOperador.Text = operador;
            if (operador == "²√")
            {
                Valor1 = double.Parse(txtBox.Text.Replace(",", "."), CultureInfo.InvariantCulture);
                txtBox.Text = Math.Sqrt(Valor1).ToString();
            }
            else if (operador == "%")
            {
                Valor2 = double.Parse(txtBox.Text.Replace(",", "."), CultureInfo.InvariantCulture);
                Aux = (Valor2 / 100);
                txtBox.Text = Aux.ToString();
            }
            else
            {
                Valor1 = double.Parse(txtBox.Text.Replace(",", "."), CultureInfo.InvariantCulture);
                txtBox.Text = "";
            }

        }
        private void Ebibir(string valor)
        {

            if (txtBox.TextLength <= 7)
            {
                if (txtBox.Text == "0")
                {
                    txtBox.Text = valor;
                }
                else
                {
                    txtBox.Text += valor;
                }
            }


        }
        private void btnApagar_Click(object sender, EventArgs e)
        {
            txtBox.Text = "0";
            lblOperador.Text = "";
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtBox.Text = txtBox.Text.Substring(0, txtBox.TextLength - 1);
            if (txtBox.TextLength == 0)
            {
                lblOperador.Text = "";
                txtBox.Text = "0";
            }
        }

        private void txtBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
