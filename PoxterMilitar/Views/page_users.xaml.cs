using PoxterMilitar.classe;
using PoxterMilitar.Features;
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
        public Page_Users(ObservableCollection<dato_usuario> listaUsuario, MainContent mainContent)
        {
            InitializeComponent();
            this.ListaUsuario = listaUsuario;
            this.mainContent = mainContent;
            this.DataContext = this;
        }

        // Método para manejar el evento TextChanged del TextBox
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Aquí puedes agregar lógica para filtrar la lista de pacientes o actualizar la UI
        }

        // Método para manejar el evento Click del botón 'Nuevo Paciente'
        private void Btn_NewUser(object sender, RoutedEventArgs e)
        {
            // Lógica para agregar un nuevo paciente o abrir una ventana de creación de paciente
        }

        private void Button_BackHome(object sender, RoutedEventArgs e)
        {
            mainContent.navigateToPatients(); 
        }

        private void Button_UserInformation(object sender, RoutedEventArgs e)
        {
            mainContent.navigateToUserInformation();
        }


    }
}
