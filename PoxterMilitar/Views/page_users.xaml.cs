using PoxterMilitar.classe;
using PoxterMilitar.Features;
using PoxterMilitar.DataAccess;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class Page_Users : Page
    {

        public ObservableCollection<dato_usuario> ListaUsuario { get; set; }
        public MainContent mainContent;
        private Page_Users page_Users;
        private readonly UserService _userService; // Instancia del servicio

        public Page_Users(ObservableCollection<dato_usuario> listaUsuario, MainContent mainContent)
        {
            InitializeComponent();
            this.mainContent = mainContent;
            ListaUsuario = listaUsuario;
            _userService = new UserService(); // Inicializa el servicio

            this.DataContext = this;
        }


        public Page_Users(MainContent mainContent)
        {
            InitializeComponent();
            this.mainContent = mainContent;

            _userService = new UserService(); // Inicializa el servicio

            // Cargar los usuarios desde el servicio
            var usuarios = _userService.GetAllUsers();
            ListaUsuario = new ObservableCollection<dato_usuario>(usuarios);

            this.DataContext = this;
        }

        public Page_Users(Page_Users page_Users)
        {
            this.page_Users = page_Users;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void Btn_NewUser(object sender, RoutedEventArgs e)
        {

        }

        private void Button_BackHome(object sender, RoutedEventArgs e)
        {
            mainContent.navigateToPatients(); 
        }

        // Método para manejar el evento Click del botón 'Editar Usuario'
        private void Button_UserInformation(object sender, RoutedEventArgs e)
        {
            // Obtener el botón que fue clickeado
            Button button = sender as Button;
            if (button != null)
            {
                // Obtener el contexto de datos del botón (es decir, el usuario)
                dato_usuario selectedUser = button.DataContext as dato_usuario;
                if (selectedUser != null)
                {
                    // Navegar a la página de Información del Usuario pasando el ID
                    this.NavigationService.Navigate(new User_Information(selectedUser.Id, mainContent));
                }
            }
        }
    }
}
