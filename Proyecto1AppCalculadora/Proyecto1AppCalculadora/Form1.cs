using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Proyecto1AppCalculadora
{
    public partial class FrmCalculadora : Form
    {
        double numero1 =0 , numero2 =0 ;
        char operardor;
        public FrmCalculadora()
        {
            InitializeComponent();
            aplicarestilos();
        }
        private void aplicarestilos()   
        {
            this.BackColor = Color.Black;
            btnHistorial.BackColor = Color.White;
            txtResultado.BackColor = Color.Silver;
            
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
            double resultado = 0;
            string operacionTexto = $"{numero1} {operardor} {numero2}";

            if (operardor == '+')
            {
                resultado = numero1 + numero2;
            }
            else if (operardor == '-')
            {
                resultado = numero1 - numero2;
            }
            else if (operardor == 'X')
            {
                resultado = numero1 * numero2;
            }
            else if (operardor == '/')
            {
                if (numero2 != 0)
                {
                    resultado = numero1 / numero2;
                }
                else
                {
                    MessageBox.Show("No se puede dividir por cero");
                    return;
                }
            }
            txtResultado.Text = resultado.ToString();
            numero1 = resultado;

            
            GuardarOperacion(operacionTexto, resultado.ToString());
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
            if (!txtResultado.Text.Contains(","))
            {
                txtResultado.Text += ",";
            }
        }

        private void btnSigno_Click(object sender, EventArgs e)
        {
            numero1 = Convert.ToDouble(txtResultado.Text);
            numero1 *= -1;
            txtResultado.Text = numero1.ToString();
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            var historial = new FrmHistorial();
            historial.Show();

        }

        private void clickOperador(object sender, EventArgs e)
        {
            var boton = ((Button)sender);

            numero1 = Convert.ToDouble(txtResultado.Text);
            operardor = Convert.ToChar(boton.Tag);

            if (operardor == '²')
            {
                double resultado = Math.Pow(numero1, 2);
                txtResultado.Text = resultado.ToString();
                GuardarOperacion($"{numero1}²", resultado.ToString());
                numero1 = resultado;
            }
            else if (operardor == '√')
            {
                double resultado = Math.Sqrt(numero1);
                txtResultado.Text = resultado.ToString();
                GuardarOperacion($"√{numero1}", resultado.ToString());
                numero1 = resultado;
            }
            else
            {
                txtResultado.Text = "0";
            }
        }


        string connectionString = @"Server=ASUSVIVOBOOX;Database=CalculadoraC#;TrustServerCertificate=True;Integrated Security=SSPI;";
        private void GuardarOperacion(string operacion, string resultado)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO Historial (Operacion, Resultado, Fecha) VALUES (@Operacion, @Resultado, @Fecha)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Operacion", operacion);
                        cmd.Parameters.AddWithValue("@Resultado", resultado);
                        cmd.Parameters.AddWithValue("@Fecha", DateTime.Now);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro al guardar opercacion: " + ex.Message);
                }

            }
        }
    }
}
