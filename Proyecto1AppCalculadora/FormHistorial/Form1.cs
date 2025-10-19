using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FormHistorial {
    public partial class FormHistorial : Form
    {
        string connectionString = @"Server=ASUSVIVOBOOX;Database=CalculadoraC#;TrustServerCertificate=True;Integrated Security=SSPI;";

        public FormHistorial()
        {
            InitializeComponent();
            CargarHistorial();
        }

        private void CargarHistorial()
        {
           
            lstHistorial.Items.Clear();

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

                            lstHistorial.Items.Add($"{fecha}: {operacion} = {resultado}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar historial: " + ex.Message);
                }
            }
        }

    
    }
}