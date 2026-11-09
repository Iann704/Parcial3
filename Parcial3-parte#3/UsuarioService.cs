using System;
using Microsoft.Data.SqlClient;

public class UsuarioService
{
    public bool Registrar(string usuario, string nombreCompleto, string clave)
    {
        string hash = BCrypt.Net.BCrypt.HashPassword(clave);

        using var cn = new SqlConnection(Conexion.Cadena);
        cn.Open();
        var cmd = new SqlCommand(
            "INSERT INTO Usuarios (NombreUsuario, NombreCompleto, PasswordHash) " +
            "VALUES (@u, @n, @h)", cn);
        cmd.Parameters.AddWithValue("@u", usuario);
        cmd.Parameters.AddWithValue("@n", nombreCompleto);
        cmd.Parameters.AddWithValue("@h", hash);

        try
        {
            cmd.ExecuteNonQuery();
            return true;
        }
        catch (SqlException)
        {
            return false; // el usuario ya existe
        }
    }

    public string? Login(string usuario, string clave)
    {
        string? nombre = null;
        bool exitoso = false;

        using var cn = new SqlConnection(Conexion.Cadena);
        cn.Open();

        var cmd = new SqlCommand(
            "SELECT NombreCompleto, PasswordHash FROM Usuarios WHERE NombreUsuario = @u", cn);
        cmd.Parameters.AddWithValue("@u", usuario);

        using (var rd = cmd.ExecuteReader())
        {
            if (rd.Read())
            {
                string hash = rd.GetString(1);
                if (BCrypt.Net.BCrypt.Verify(clave, hash))
                {
                    nombre = rd.GetString(0);
                    exitoso = true;
                }
            }
        }

        RegistrarIntento(cn, usuario, exitoso);
        return nombre;
    }

    private void RegistrarIntento(SqlConnection cn, string usuario, bool exitoso)
    {
        var cmd = new SqlCommand(
            "INSERT INTO IntentosLogin (NombreUsuario, Fecha, Exitoso) VALUES (@u, @f, @e)", cn);
        cmd.Parameters.AddWithValue("@u", usuario);
        cmd.Parameters.AddWithValue("@f", DateTime.Now);
        cmd.Parameters.AddWithValue("@e", exitoso);
        cmd.ExecuteNonQuery();
    }
}