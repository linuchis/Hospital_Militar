using PoxterMilitar.Features;
using PoxterMilitar.DataAccess;
using PoxterMilitar.Models;
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

namespace PoxterMilitar.Views
{
    /// <summary>
    /// Lógica de interacción para User_Information.xaml
    /// </summary>
    public partial class User_Information : Page
    {
        MainContent mainContent;
        private readonly UserService _userService;
        private long userId;
        private users_poxter user;

        public User_Information(long userId, MainContent mainContent)
        {
            InitializeComponent();
            this.mainContent = mainContent;
            this.userId = userId;
            _userService = new UserService();

            LoadUserData();
        }

        private void LoadUserData()
        {
            user = _userService.GetUserById(userId);
            if (user != null)
            {
                NombresURGDsuario.Text = user.name_u;
                ApellidosUsuario.Text = user.lastname_u;
                AreaUsuario.Text = user.area_u;
                TelefonoUsuario.Text = user.telephone_u; // Cambia esto si tienes el dato
                CorreoElectronicoUsuario.Text = user.email_u;
                ContraseñaUsuario.Text = "********************"; // No mostrar la contraseña real por seguridad
            }
            else
            {
                MessageBox.Show("Usuario no encontrado.");
            }
        }

        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            mainContent.navigateToUsersList();
        }

        private void Button_ToEditUserInformation(object sender, RoutedEventArgs e)
        {
            // Verificar que userId está correctamente asignado
            if (userId > 0)
            {
                this.NavigationService.Navigate(new Edit_User_Information(userId, mainContent));
            }
            else
            {
                MessageBox.Show("ID de usuario inválido.");
            }
        }
    }
}
