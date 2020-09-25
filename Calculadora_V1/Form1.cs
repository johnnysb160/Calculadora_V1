﻿using System;
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
            Exibir("0");
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            Exibir("1");
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            Exibir("2");
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            Exibir("3");
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            Exibir("4");
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            Exibir("5");
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            Exibir("6");
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            Exibir("7");
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            Exibir("8");
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            Exibir("9");
        }
        private void btnVirgula_Click(object sender, EventArgs e)
        {
            if (!txtBox.Text.Contains(","))
            {
                if (txtBox.Text == "0")
                {
                    Exibir("0,");
                }
                else
                {
                    Exibir(",");
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
        public double Total = 0;
        private void btnIgual_Click(object sender, EventArgs e)
        {
            if (txtBox.TextLength > 10 || txtBox.Text == "Error")
            {
                txtBox.Text = "Error";
                lblOperador.Text = "";
                txtBox.Font = new Font(txtBox.Font.FontFamily, 28);
                return;
            }
            else
            {
                Valor2 = double.Parse(txtBox.Text.Replace(".", "").Replace(",", "."), CultureInfo.InvariantCulture);
            }
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
        public bool status = false;
        private void Atribuicao(string operador)
        {
            lblOperador.Text = operador;
            if (operador == "²√")
            {
                Valor1 = double.Parse(txtBox.Text.Replace(".", "").Replace(",", "."), CultureInfo.InvariantCulture);
                string aux = Math.Sqrt(Valor1).ToString();
                if (aux.Length > 9)
                {
                    txtBox.Text = Math.Sqrt(Valor1).ToString().Substring(0,9);
                }
                else
                {
                    txtBox.Text = Math.Sqrt(Valor1).ToString();
                }
            }
            else if (operador == "%")
            {
                Valor2 = double.Parse(txtBox.Text.Replace(".", "").Replace(",", "."), CultureInfo.InvariantCulture);
                Aux = (Valor2 / 100);
                txtBox.Text = Aux.ToString();
            }
            else
            {
                Valor1 = double.Parse(txtBox.Text.Replace(".", "").Replace(",", "."), CultureInfo.InvariantCulture);
                status = true;
            }
        }
        private void Exibir(string valor)
        {
            int aux = 0;
                if (lblOperador.Text != "" && status == true)
                {
                    txtBox.Text = "";
                    txtBox.Font = new Font(txtBox.Font.FontFamily, 28);
                }
                if (txtBox.TextLength <= 10)
                {
                    if (txtBox.Text == "0")
                    {
                        txtBox.Text = valor;
                    }
                    else
                    {
                        if (valor == ",")
                        {
                            txtBox.Text += valor;
                            status = false;
                        }
                        else
                        {
                            if (txtBox.TextLength > 2 && txtBox.TextLength <= 4 && !txtBox.Text.Contains(".") && !txtBox.Text.Contains(","))
                            {
                                aux = txtBox.TextLength;
                                txtBox.Text = txtBox.Text.Insert(aux - 2, ".");
                            }
                            if (txtBox.TextLength > 4 && txtBox.TextLength <= 6 && txtBox.Text.Contains(".") && !txtBox.Text.Contains(","))
                            {
                                txtBox.Text = txtBox.Text.Replace(".", "");
                                aux = txtBox.TextLength;
                                txtBox.Text = txtBox.Text.Insert(aux - 2, ".");
                            }
                            if (txtBox.TextLength > 6 && txtBox.TextLength <= 10 && txtBox.Text.Contains(".") && !txtBox.Text.Contains(","))
                            {
                                txtBox.Text = txtBox.Text.Replace(".", "");
                                aux = txtBox.TextLength;
                                txtBox.Text = txtBox.Text.Insert(aux - 5, ".").Insert(aux - 1, ".");
                            }
                            if (txtBox.TextLength >= 8)
                            {
                                txtBox.Font = new Font(txtBox.Font.FontFamily, txtBox.Font.Size - 2);
                            }
                            txtBox.Text += valor;
                            status = false;
                        }
                    }
                }
        }
        private void btnApagar_Click(object sender, EventArgs e)
        {
            txtBox.Text = "0";
            lblOperador.Text = "";
            txtBox.Font = new Font(txtBox.Font.FontFamily, 28);
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            if (lblOperador.Text=="" || status == false) {
                if (txtBox.Text.LastIndexOf(".") == txtBox.TextLength - 2 && txtBox.TextLength > 1)
                {
                    txtBox.Text = txtBox.Text.Substring(0, txtBox.TextLength - 2);
                }
                else
                {
                    txtBox.Text = txtBox.Text.Substring(0, txtBox.TextLength - 1);
                }
                if (txtBox.TextLength == 0)
                {
                    lblOperador.Text = "";
                    txtBox.Text = "0";
                }
                if (txtBox.TextLength >= 8)
                {
                    txtBox.Font = new Font(txtBox.Font.FontFamily, txtBox.Font.Size + 2);
                }
                else
                {
                    txtBox.Font = new Font(txtBox.Font.FontFamily, 28);
                }
            }
            else
            {
                lblOperador.Text = "";
            }
        }

        private void txtBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
