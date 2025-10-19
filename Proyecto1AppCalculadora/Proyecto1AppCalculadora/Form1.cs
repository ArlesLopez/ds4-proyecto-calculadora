using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1AppCalculadora
{
    public partial class Form1 : Form
    {
        double numero1 =0 , numero2 =0 ;
        char operardor;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

       private void agreagarNumero (object sender, EventArgs e)
        {
            var boton = ((Button)sender);
            if(txtResultado.Text == "0")
                txtResultado.Text = "";

            txtResultado.Text += boton.Text ;
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            numero2 = Convert.ToDouble(txtResultado.Text);
            if (operardor == '+')
            {
                txtResultado.Text = (numero1 + numero2).ToString();
                numero1 = Convert.ToDouble(txtResultado.Text);
            } else if (operardor == '-')
            {
                txtResultado.Text = (numero1 - numero2).ToString();
                numero1 = Convert.ToDouble(txtResultado.Text);
            }
            else if (operardor == 'X')
            {
                txtResultado.Text = (numero1 * numero2).ToString();
                numero1 = Convert.ToDouble(txtResultado.Text);
            }
            else if (operardor == '/') 
            {
                if (txtResultado.Text != "0")
                {
                    txtResultado.Text = (numero1 / numero2).ToString();
                    numero1 = Convert.ToDouble(txtResultado.Text);
                }
                {
                    MessageBox.Show("No se puede divir por cero");
                }
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (txtResultado.Text.Length > 1)
            {
                txtResultado.Text = txtResultado.Text.Substring(0,txtResultado.Text.Length - 1);
            }
            else{
                txtResultado.Text = "0";
            }
        }

        private void btnBorrarTodo_Click(object sender, EventArgs e)
        {
            numero1 = 0;
            numero2 = 0;
            operardor = '\0';
            txtResultado.Text = "0";
        }

        private void btnBorrarUltimo_Click(object sender, EventArgs e)
        {
            txtResultado.Text = "0";
        }

        private void btnComa_Click(object sender, EventArgs e)
        {
            if (!txtResultado.Text.Contains("."))
            {
                txtResultado.Text += ".";
            }
        }

        private void btnSigno_Click(object sender, EventArgs e)
        {
            numero1 = Convert.ToDouble(txtResultado.Text);
            numero1 *= -1;
            txtResultado.Text = numero1.ToString();
        }

        private void clickOperador(object sender, EventArgs e)
        {
            var boton = ((Button)sender);

            numero1 = Convert.ToDouble(txtResultado.Text);
            operardor = Convert.ToChar(boton.Tag);
            if (operardor == '²')
            {
                numero1 = Math.Pow(numero1, 2);
                txtResultado.Text = numero1.ToString();
            }
            else if (operardor == '√')
            {
                numero1 = Math.Sqrt(numero1);
                txtResultado.Text = numero1.ToString();
            }
            else
            {
                txtResultado.Text = "0";
            }
        }

    }
}
