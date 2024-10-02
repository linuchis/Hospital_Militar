using PoxterMilitar.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PoxterMilitar.DataAccess;
using PoxterMilitar.Models;

using PoxterMilitar.classe;

namespace PoxterMilitar.Views
{
    /// <summary>
    /// Lógica de interacción para Edit_User_Information.xaml
    /// </summary>
    public partial class Edit_User_Information : Page
    {

        MainContent mainContent;
        private readonly UserService _userService;
        private long userId;
        private users_poxter user;

        public Edit_User_Information(long userId, MainContent mainContent)
        {
            InitializeComponent();
            this.mainContent = mainContent;
            this.userId = userId;
            _userService = new UserService();

            LoadUserData();
        }

        public Edit_User_Information(MainContent mainContent)
        {
            this.mainContent = mainContent;
        }

        private void LoadUserData()
        {
            user = _userService.GetUserById(userId);
            if (user != null)
            {
                // Asignar los datos a los TextBoxes
                UserEditName.Text = user.name_u;
                UserEditLastname.Text = user.lastname_u;
                UserEditArea.Text = user.area_u;
                UserEditTelephone.Text = user.telefono_u ?? ""; // Asegúrate de tener este campo en la entidad
                UserEditEmail.Text = user.email_u;
                UserEditPassword.Text = ""; // Dejar vacío para ingresar una nueva contraseña si se desea
            }
            else
            {
                MessageBox.Show("Usuario no encontrado.");
            }
        }

        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            mainContent.navigateToPatients();
        }

        private void Save_Patients_Information_Click(object sender, RoutedEventArgs e)
        {
            // Obtener los datos ingresados
            string nombre = UserEditName.Text.Trim();
            string apellido = UserEditLastname.Text.Trim();
            string area = UserEditArea.Text.Trim();
            string telefono = UserEditTelephone.Text.Trim();
            string correo = UserEditEmail.Text.Trim();
            string contraseña = UserEditPassword.Text.Trim();

            // Validar los datos (puedes agregar más validaciones según sea necesario)
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) ||
                string.IsNullOrEmpty(area) || string.IsNullOrEmpty(correo))
            {
                MessageBox.Show("Por favor, completa todos los campos obligatorios.");
                return;
            }

            

            // Crear un objeto `dato_usuario` con los datos actualizados
            var updatedUser = new dato_usuario
            {
                Id = userId,
                Nombre = nombre,
                Apellido = apellido,
                Area = area,
                Telefono = telefono,
                Correo = correo,
                Password = contraseña 
            };

            // Actualizar el usuario en la base de datos
            _userService.UpdateUser(userId, updatedUser);

            // Confirmar la actualización
            MessageBox.Show("Información del usuario actualizada correctamente.");

            // Navegar de vuelta a la página de Información del Usuario
            this.NavigationService.Navigate(new User_Information(userId, mainContent));
        }
    }
}
