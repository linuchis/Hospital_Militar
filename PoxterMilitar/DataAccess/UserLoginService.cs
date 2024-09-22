using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        // Método para validar las credenciales
        public bool ValidateCredentials(string username, string password)
        {
            // Buscar el usuario en la base de datos por nombre de usuario
            var user = _context.users_poxter.FirstOrDefault(u => u.username_u == username);

            if (user != null)
            {
                // Verificar la contraseña (aquí deberías usar hash en un entorno real)
                if (user.password_u == password)
                {
                    return true; // Credenciales válidas
                }
            }

            return false; // Credenciales no válidas
        }
    }
}