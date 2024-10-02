using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using PoxterMilitar.Models;
using System.Text;
using System.Threading.Tasks;
using PoxterMilitar.classe;
using System.Windows;

namespace PoxterMilitar.DataAccess
{
    public class UserService
    {
        private readonly dbpoxterContext _context;

        // Constructor que inicializa el contexto de la base de datos
        public UserService()
        {
            _context = new dbpoxterContext();
        }

        // Método para obtener todos los usuarios y mapearlos a dato_usuario
        public List<classe.dato_usuario> GetAllUsers()
        {
            var users = _context.users_poxter.ToList();

            var listaUsuarios = users.Select(u => new classe.dato_usuario
            {
                // Mapea las propiedades de users_poxter a dato_usuario
                // Asegúrate de que las propiedades coinciden o realiza las conversiones necesarias
                Id = u.id_u,
                Nombre = u.name_u,
                Apellido = u.lastname_u,
                Correo = u.email_u,
                Area = u.area_u,
                // Asigna valores predeterminados o mapea otras propiedades si existen
                Foto = "ruta_por_defecto.png", // Puedes ajustar esto según tus necesidades
                Telefono = u.telephone_u,
            }).ToList();

            return listaUsuarios;
        }



        // Método para obtener un usuario por su ID
        public users_poxter GetUserById(long userId)
        {
            return _context.users_poxter.FirstOrDefault(u => u.id_u == userId);
        }

        // Método para agregar un nuevo usuario
        public void AddUser(dato_usuario nuevoUsuario)
        {
            var userEntity = new users_poxter
            {
                name_u = nuevoUsuario.Nombre,
                lastname_u = nuevoUsuario.Apellido,
                email_u = nuevoUsuario.Correo,
                area_u = nuevoUsuario.Area,
                password_u = "hashed_password", // Asegúrate de manejar el hash correctamente
                username_u = "username" // Asigna el username correspondiente
                // Asigna otros campos si existen
            };

            _context.users_poxter.Add(userEntity);
            _context.SaveChanges();
        }

        //método para traer el usuario, editarlo y guardarlo

        public void UpdateUser(long userId, dato_usuario updatedUser)
        {
            try
            {
                // Obtener el usuario de la base de datos
                var user = _context.users_poxter.FirstOrDefault(u => u.id_u == userId);
                if (user != null)
                {
                    // Actualizar los campos necesarios
                    user.name_u = updatedUser.Nombre;
                    user.lastname_u = updatedUser.Apellido;
                    user.email_u = updatedUser.Correo;
                    user.area_u = updatedUser.Area;

                    // Si deseas actualizar la contraseña, asegúrate de hashearla antes
                    if (!string.IsNullOrEmpty(updatedUser.Password))
                    {
                        user.password_u = ComputeSha256Hash(updatedUser.Password); // Asegúrate de tener este método
                    }

                    // Guardar los cambios en la base de datos
                    _context.SaveChanges();
                }
                else
                {
                    throw new Exception("Usuario no encontrado.");
                }
            }
            catch (Exception ex)
            {
                // Manejar el error, por ejemplo, loguearlo o mostrar un mensaje
                MessageBox.Show($"Error al actualizar el usuario: {ex.Message}");
            }
        }

        public string ComputeSha256Hash(string rawData)
        {
            // Crear una instancia de SHA256
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Convertir la cadena en bytes y computar el hash
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convertir el array de bytes a una cadena hexadecimal
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

    }
}
