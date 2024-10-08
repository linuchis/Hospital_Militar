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
                Id = u.id_u,
                Nombre = u.name_u,
                Apellido = u.lastname_u,
                Correo = u.email_u,
                Area = u.area_u,
                Foto = "ruta_por_defecto.png",
                Telefono = u.telephone_u,
            }).ToList();

            return listaUsuarios;
        }

        public users_poxter GetUserById(long userId)
        {
            return _context.users_poxter.FirstOrDefault(u => u.id_u == userId);
        }




        public void AddUser(dato_usuario nuevoUsuario)
        {
            var userEntity = new users_poxter
            {
                name_u = nuevoUsuario.Nombre,
                lastname_u = nuevoUsuario.Apellido,
                email_u = nuevoUsuario.Correo,
                area_u = nuevoUsuario.Area,
                password_u = "hashed_password",
                username_u = "username"
            };

            _context.users_poxter.Add(userEntity);
            _context.SaveChanges();
        }


        public void UpdateUser(long userId, dato_usuario updatedUser)
        {
            try
            {
                var user = _context.users_poxter.FirstOrDefault(u => u.id_u == userId);
                if (user != null)
                {

                    user.name_u = updatedUser.Nombre;
                    user.lastname_u = updatedUser.Apellido;
                    user.email_u = updatedUser.Correo;
                    user.area_u = updatedUser.Area;

                    if (!string.IsNullOrEmpty(updatedUser.Password))
                    {
                        user.password_u = ComputeSha256Hash(updatedUser.Password);
                    }

                    _context.SaveChanges();
                }
                else
                {
                    throw new Exception("Usuario no encontrado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el usuario: {ex.Message}");
            }
        }

        public string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

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
