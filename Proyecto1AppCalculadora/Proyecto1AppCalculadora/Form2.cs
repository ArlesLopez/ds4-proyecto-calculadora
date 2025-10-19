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

    public partial class FrmHistorial : Form
    {
        string connectionString = @"Server=ASUSVIVOBOOX;Database=CalculadoraC#;TrustServerCertificate=True;Integrated Security=SSPI;";
        public FrmHistorial()
        {
            InitializeComponent();
            CargarHistorial();
            aplicarestilos();
        }

        private void aplicarestilos()
        {
            this.BackColor = Color.Black;
            lstHisotorial.BackColor = Color.White;
            lblHistorial.ForeColor = Color.White;
        }
        private void CargarHistorial()
        {
            lstHisotorial.Items.Clear();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Operacion, Resultado, Fecha FROM Historial ORDER BY Fecha DESC";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string operacion = reader["Operacion"].ToString();
                            string resultado = reader["Resultado"].ToString();
                            string fecha = Convert.ToDateTime(reader["Fecha"]).ToString("g");

                            lstHisotorial.Items.Add($"{fecha}: {operacion} = {resultado}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar historial: " + ex.Message);
                }
            }


        }

        private void BtnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
