using PoxterMilitar.DataAccess;
using PoxterMilitar.Features;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Collections.Specialized;
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
using PoxterMilitar.DataAccess; // Importa el servicio


namespace PoxterMilitar.Views
{
    
    public partial class Login : Page
    {
        
        private UserLoginService _userLoginService;

        public Login()
        {
            InitializeComponent();
            _userLoginService = new UserLoginService();

            this.Loaded += Login_Loaded;
            LoadUserSettings();

        }

        //REMEEEEMBER MEEEE  
        private void LoadUserSettings()
        {
            // Verificar si RememberMe está activado
           
            if (Settings.Default.RememberMe)
            {
                // Si está activado, cargar el nombre de usuario guardado
                txtUsername.Text = Settings.Default.Username;
                chkRememberMe.IsChecked = true; // Marcar el checkbox de "Recuérdame"
            }
        }

        private void SaveUserSettings()
        {
            if (chkRememberMe.IsChecked == true) // Si el checkbox está marcado
            {
                Settings.Default.Username = txtUsername.Text; // Guardar el nombre de usuario
                Settings.Default.RememberMe = true; // Guardar que "Recordarme" está activado
            }
            else
            {
                // Limpiar los datos si el checkbox NO está marcado
                Settings.Default.Username = string.Empty;
                Settings.Default.RememberMe = false;
            }

            // Guardar la configuración en Properties
            Settings.Default.Save();
        }



        private void Button_IniciarSesion_Click(object sender, RoutedEventArgs e)
        {
            // Obtener los valores ingresados por el usuario  
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            if (_userLoginService.ValidateCredentials(username, password))
            {
                // Credenciales correctas, navegar a la siguiente página  
                SaveUserSettings();
                NavigationService.Navigate(new MainContent());
            }
            else
            {
               
                MainContent mainContent = new MainContent();
                mainContent.navigateToWrongData();
                 
            }
        }
        
        // Se supone que después de esto ya quedan guardados los datos xd







        private void Login_Loaded(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            if (parentWindow != null)
            {
                parentWindow.SizeChanged += Window_SizeChanged;
            }
        }

        //ventana de ¿Olvidaste tu contraseña?

        void Button_Forgot_Password(object sender, RoutedEventArgs e)
        {
            MainContent mainContent = new MainContent();
            mainContent.navigateToInfoPassword();
        }

        //Para ajustar el tamaño de la ventana xd

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            const double aspectRatio = 16.0 / 9.0;

            // Determina si la altura o el ancho es el que está cambiando más
            if (e.WidthChanged)
            {
                // Ajusta la altura en función del nuevo ancho para mantener la relación 16:9
                ((Window)sender).Height = ((Window)sender).Width / aspectRatio;
            }
            else if (e.HeightChanged)
            {
                // Ajusta el ancho en función de la nueva altura para mantener la relación 16:9
                ((Window)sender).Width = ((Window)sender).Height * aspectRatio;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Aquí puedes manejar el evento TextChanged si es necesario
        }

        private void TBUsuario_GotFocus(object sender, RoutedEventArgs e)
        {
            // Verificar si el texto es el placeholder y borrarlo
            if (txtUsername.Text == "Usuario")
            {
                txtUsername.Text = "";
                txtUsername.Foreground = new SolidColorBrush(Colors.Black); // Cambiar el color del texto
            }
        }

        private void TBUsuario_LostFocus(object sender, RoutedEventArgs e)
        {
            // Si no hay ningún texto ingresado, restaurar el placeholder
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                txtUsername.Text = "Usuario";
                txtUsername.Foreground = new SolidColorBrush(Color.FromRgb(112, 112, 112)); // Color del placeholder
            }
        }

        private void PBContra_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtPassword.Password == "Contraseña")
            {
                txtPassword.Password = "";
                txtPassword.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void PBContra_PasswordChanged(object sender, RoutedEventArgs e)
        {
            // Muestra u oculta el placeholder basado en si hay texto en el PasswordBox
            if (string.IsNullOrEmpty(txtPassword.Password))
            {
                PlaceholderText.Visibility = Visibility.Visible;  // Muestra el placeholder
            }
            else
            {
                PlaceholderText.Visibility = Visibility.Hidden;    // Oculta el placeholder
            }
        }
    }
}
