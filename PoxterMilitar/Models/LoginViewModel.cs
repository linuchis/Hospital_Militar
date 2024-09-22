using Microsoft.EntityFrameworkCore;
using PoxterMilitar.Models; // Asegúrate de tener la referencia correcta a los modelos
using System.Linq;
using System.Windows;

public class LoginViewModel
{
    private readonly dbpoxterContext _context;

    public string Username { get; set; }
    public string Password { get; set; }

    public LoginViewModel()
    {
        _context = new dbpoxterContext();
    }

    public bool ValidarUsuario(string username, string password)
    {
        // Buscar el usuario en la base de datos
        var user = _context.users_poxter.FirstOrDefault(u => u.username_u == username);

        if (user != null && user.password_u == password) // Aquí debería usar hashing y comparación segura
        {
            return true; // Credenciales válidas
        }
        else
        {
            MessageBox.Show("Usuario o contraseña incorrectos.");
            return false;
        }
    }
}
