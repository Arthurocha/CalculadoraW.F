using System.Configuration;
using System.Linq;

namespace CalculadoraRosen
{

    public partial class Form1 : Form
    {
        private const string vazio = "";
        string valores;
        string sinais = "";


        public decimal Resultado { get; set; }
        public decimal Valor { get; set; }

        private Operacao OperacaoSelecionada { get; set; }

        private enum Operacao
        {
            Div,
            Mult,
            Soma,
            Sub
        }

        public Form1()
        {
            InitializeComponent();
        }
        private void AdicionarNumero(string numero)
        {
            if (txtHistorico.Text.Contains("+") ||
            txtHistorico.Text.Contains("-") ||
            txtHistorico.Text.Contains("x") ||
            txtHistorico.Text.Contains("/"))
            {
                valores += numero;
                txtHistorico.Text += numero;
            }

            else
            {
                if (txtHistorico.Text.Contains(Convert.ToString(Resultado)))
                {
                    valores = "";
                    txtHistorico.Text = "";
                    Resultado = -1m;
                    Valor = 0;
                    valores += numero;
                    txtHistorico.Text += numero;
                }

                else
                {
                    valores += numero;
                    txtHistorico.Text += numero;
                }
            }
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            AdicionarNumero("0");
        }
        private void btnUm_Click(object sender, EventArgs e)
        {
            AdicionarNumero("1");
        }
        private void btnDois_Click(object sender, EventArgs e)
        {
            AdicionarNumero("2");
        }
        private void btnTres_Click(object sender, EventArgs e)
        {
            AdicionarNumero("3");
        }
        private void btnQuatro_Click(object sender, EventArgs e)
        {
            AdicionarNumero("4");
        }
        private void btnCinco_Click(object sender, EventArgs e)
        {
            AdicionarNumero("5");
        }
        private void btnSeis_Click(object sender, EventArgs e)
        {
            AdicionarNumero("6");
        }
        private void btnSete_Click(object sender, EventArgs e)
        {
            AdicionarNumero("7");
        }
        private void btnOito_Click(object sender, EventArgs e)
        {
            AdicionarNumero("8");
        }
        private void btnNove_Click(object sender, EventArgs e)
        {
            AdicionarNumero("9");
        }

        private void btnVirgula_Click(object sender, EventArgs e)
        {
            if (valores.Contains(","))
            {
                valores += "";
                txtHistorico.Text += "";
            }

            else
            {
                if (!string.IsNullOrEmpty(txtHistorico.Text))
                {
                    valores += ",";
                    txtHistorico.Text += ",";
                    Resultado = -1m;
                }
            }
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            if (sinais.Contains("+") ||
                 sinais.Contains("-") ||
                 sinais.Contains("x") ||
                 sinais.Contains("/"))
            {
                valores += "";
                txtHistorico.Text += "";
            }

            else
            {
                if (!string.IsNullOrEmpty(txtHistorico.Text))
                {
                    OperacaoSelecionada = Operacao.Div;
                    Valor = Convert.ToDecimal(valores);
                    valores = "";
                    txtHistorico.Text += "/";
                    sinais = "/";
                }
            }
        }

        private void btnMult_Click(object sender, EventArgs e)
        {
            if (sinais.Contains("+") ||
                 sinais.Contains("-") ||
                 sinais.Contains("x") ||
                 sinais.Contains("/"))
            {
                valores += "";
                txtHistorico.Text += "";
            }

            else
            {
                if (!string.IsNullOrEmpty(txtHistorico.Text))
                {
                    OperacaoSelecionada = Operacao.Mult;
                    Valor = Convert.ToDecimal(valores);
                    valores = "";
                    txtHistorico.Text += "x";
                    sinais = "x";
                }
            }
        }

        private void btnSoma_Click(object sender, EventArgs e)
        {
            if (sinais.Contains("+") ||
                 sinais.Contains("-") ||
                 sinais.Contains("x") ||
                 sinais.Contains("/"))
            {
                valores += "";
                txtHistorico.Text += "";
            }

            else
            {
                if (!string.IsNullOrEmpty(txtHistorico.Text))
                {
                    OperacaoSelecionada = Operacao.Soma;
                    Valor = Convert.ToDecimal(valores);
                    valores = "";
                    txtHistorico.Text += "+";
                    sinais = "+";
                }
            }
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtHistorico.Text))
            {
                valores += "-";
                txtHistorico.Text += "-";
                sinais = "";
            }

            else
            {

                if (sinais.Contains("+") ||
                 sinais.Contains("-") ||
                 sinais.Contains("x") ||
                 sinais.Contains("/"))
                {
                    valores += "";
                    txtHistorico.Text += "";
                }

                else
                {
                    OperacaoSelecionada = Operacao.Sub;
                    Valor = Convert.ToDecimal(valores);
                    valores = "";
                    txtHistorico.Text += "-";
                    sinais = "-";
                }
            }
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            decimal zero = 0;
            if (zero == Convert.ToDecimal(valores))
            {
                switch (OperacaoSelecionada)
                {
                    case Operacao.Div:
                        break;


                    case Operacao.Mult:
                        Resultado = Valor * Convert.ToDecimal(valores);
                        valores = Convert.ToString(Resultado);
                        txtHistorico.Text = Convert.ToString(Resultado);
                        sinais = "";
                        break;

                    case Operacao.Soma:
                        Resultado = Valor + Convert.ToDecimal(valores);
                        valores = Convert.ToString(Resultado);
                        txtHistorico.Text = Convert.ToString(Resultado);
                        sinais = "";
                        break;

                    case Operacao.Sub:
                        Resultado = Valor - Convert.ToDecimal(valores);
                        valores = Convert.ToString(Resultado);
                        txtHistorico.Text = Convert.ToString(Resultado);
                        sinais = "";
                        break;

                }
            }

            else
            {
                switch (OperacaoSelecionada)
                {
                    case Operacao.Div:
                        Resultado = Valor / Convert.ToDecimal(valores);
                        break;


                    case Operacao.Mult:
                        Resultado = Valor * Convert.ToDecimal(valores);
                        break;

                    case Operacao.Soma:
                        Resultado = Valor + Convert.ToDecimal(valores);
                        break;

                    case Operacao.Sub:
                        Resultado = Valor - Convert.ToDecimal(valores);
                        break;

                }
                valores = Convert.ToString(Resultado);
                txtHistorico.Text = Convert.ToString(Resultado);
                sinais = "";
            }

            

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            valores = "";
            txtHistorico.Text = "";
            sinais = "";
            Valor = 0;
        }

        private void btnLimparUm_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtHistorico.Text))
            {
                if (char.IsDigit(txtHistorico.Text[txtHistorico.Text.Length - 1]) || txtHistorico.Text[txtHistorico.Text.Length - 1] == ',')
                {
                    valores = valores.Substring(0, valores.Length - 1);
                    txtHistorico.Text = txtHistorico.Text.Substring(0, txtHistorico.Text.Length - 1);
                }
            }
            else
            {
                valores = "";
                txtHistorico.Text = "";
                Valor = 0;
            }
        }

        private void btnBinario_Click(object sender, EventArgs e)
        {
            if (txtHistorico.Text.Contains("+") ||
            txtHistorico.Text.Contains("-") ||
            txtHistorico.Text.Contains("x") ||
            txtHistorico.Text.Contains("/"))
            {
                valores += "";
                txtHistorico.Text += "";
            }

            else
            {
                if (!string.IsNullOrEmpty(valores))
                {
                    int num = Convert.ToInt32(valores);
                    valores = Convert.ToString(num, 2);
                    txtHistorico.Text = valores;
                    Resultado = Convert.ToDecimal(valores);
                }
            }
        }

        private void btnFatorial_Click(object sender, EventArgs e)
        {
            if (txtHistorico.Text.Contains("+") ||
          txtHistorico.Text.Contains("-") ||
          txtHistorico.Text.Contains("x") ||
          txtHistorico.Text.Contains("/"))
            {
                valores += "";
                txtHistorico.Text += "";
            }

            else
            {
                if (!string.IsNullOrEmpty(valores))
                {
                    int num;
                    if (!int.TryParse(valores, out num))
                    {
                        num = 0;
                    }
                    
                    Resultado = 1;

                    for (int i = num; i > 1; i--)
                    {
                        Resultado *= i;
                    }

                    valores = Convert.ToString(Resultado);
                    txtHistorico.Text = valores;
                }
            }
        }

        private void btnSen_Click(object sender, EventArgs e)
        {
            if (txtHistorico.Text.Contains("+") ||
          txtHistorico.Text.Contains("-") ||
          txtHistorico.Text.Contains("x") ||
          txtHistorico.Text.Contains("/"))
            {
                valores += "";
                txtHistorico.Text += "";
            }

            else
            {
                if (!string.IsNullOrEmpty(valores))
                {
                    double graus = Convert.ToDouble(valores);
                    double radianos = graus * (Math.PI / 180);
                    Resultado = Convert.ToDecimal(Math.Sin(radianos));

                    valores = Convert.ToString(Resultado);
                    txtHistorico.Text = valores;
                }
            }
        }

        private void btnCos_Click(object sender, EventArgs e)
        {
            if (txtHistorico.Text.Contains("+") ||
          txtHistorico.Text.Contains("-") ||
          txtHistorico.Text.Contains("x") ||
          txtHistorico.Text.Contains("/"))
            {
                valores += "";
                txtHistorico.Text += "";
            }

            else
            {
                if (!string.IsNullOrEmpty(valores))
                {
                    double graus = Convert.ToDouble(valores);
                    double radianos = graus * (Math.PI / 180);
                    Resultado = Convert.ToDecimal(Math.Cos(radianos));

                    valores = Convert.ToString(Resultado);
                    txtHistorico.Text = valores;
                }
            }
        }

        private void btnTan_Click(object sender, EventArgs e)
        {
            if (txtHistorico.Text.Contains("+") ||
          txtHistorico.Text.Contains("-") ||
          txtHistorico.Text.Contains("x") ||
          txtHistorico.Text.Contains("/"))
            {
                valores += "";
                txtHistorico.Text += "";
            }

            else
            {
                if (!string.IsNullOrEmpty(valores))
                {
                    double graus = Convert.ToDouble(valores);
                    double radianos = graus * (Math.PI / 180);
                    Resultado = Convert.ToDecimal(Math.Tan(radianos));

                    valores = Convert.ToString(Resultado);
                    txtHistorico.Text = valores;
                }
            }
        }
    }
}
