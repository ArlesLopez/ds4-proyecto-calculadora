using Proyecto_2.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Http;

[RoutePrefix("api/operaciones")]
public class OperacionesController : ApiController
{
    [HttpGet]
    [Route("historial")]
    public IEnumerable<Operacion> GetHistorial()
    {
        List<Operacion> lista = new List<Operacion>();

        using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["CalculadoraDB"].ConnectionString))
        {
            con.Open();
            var cmd = new SqlCommand("SELECT * FROM Operaciones ORDER BY Fecha DESC", con);
            var rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                lista.Add(new Operacion
                {
                    Id = (int)rd["Id"],
                    Numero1 = (decimal)rd["Numero1"],
                    Numero2 = (decimal)rd["Numero2"],
                    OperacionTipo = rd["Operacion"].ToString(),
                    Resultado = (decimal)rd["Resultado"],
                    Fecha = (DateTime)rd["Fecha"]
                });
            }
        }

        return lista;
    }
    [HttpPost]
    [Route("guardar")]
    public IHttpActionResult Guardar(Operacion op)
    {
        using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["CalculadoraDB"].ConnectionString))
        {
            con.Open();

            var cmd = new SqlCommand(
                "INSERT INTO Operaciones (Numero1, Numero2, Operacion, Resultado) VALUES (@n1, @n2, @op, @res)",
                con);

            cmd.Parameters.AddWithValue("@n1", op.Numero1);
            cmd.Parameters.AddWithValue("@n2", op.Numero2);
            cmd.Parameters.AddWithValue("@op", op.OperacionTipo);
            cmd.Parameters.AddWithValue("@res", op.Resultado);

            cmd.ExecuteNonQuery();
        }

        return Ok("Guardado");
    }
}
