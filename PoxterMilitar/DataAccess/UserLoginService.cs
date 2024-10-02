using System;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using PoxterMilitar.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace PoxterMilitar.DataAccess
{
    public class UserLoginService // Cambié a public para que sea accesible desde otras partes del proyecto
    {
        private readonly dbpoxterContext _context; // Instancia del contexto de base de datos

        // Constructor que inicializa el contexto de base de datos
        public UserLoginService()
        {
            _context = new dbpoxterContext(); // Inicializa el contexto aquí
        }

        // Método para calcular el hash SHA256 de una cadena
        private string ComputeSha256Hash(string rawData)
        {
            // Crear una instancia de SHA256
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Computar el hash como arreglo de bytes
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convertir el arreglo de bytes a una cadena hexadecimal
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        // Método para validar las credenciales
        public bool ValidateCredentials(string username, string password)
        {
            // Buscar el usuario en la base de datos por nombre de usuario
             var user = _context.users_poxter.FirstOrDefault(u => u.username_u == username);

            if (user != null)
            {
                // Calcular el hash SHA256 de la contraseña ingresada
                string hashedPassword = ComputeSha256Hash(password);

                // Verificar si el hash calculado coincide con el almacenado
                if (user.password_u.Equals(hashedPassword, StringComparison.OrdinalIgnoreCase))
                {
                    return true; // Credenciales válidas
                }
            }

            return false; // Credenciales no válidas
        }
    }
}
