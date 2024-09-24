using System.Windows.Controls;
using System.Windows;
using System.Collections.ObjectModel;
using PoxterMilitar.classe;
using PoxterMilitar.Features;

namespace PoxterMilitar.Views
{
    public partial class Page_Patients : Page
    {
        private MainWindow mainWindow;
        // Colección observable que estará vinculada al DataGrid
        public ObservableCollection<dato_paciente> ListaPacientes { get; set; }

        public MainContent mainContent;

        public Page_Patients(ObservableCollection<dato_paciente> listaPacientes, MainContent mainContent)
        {
            InitializeComponent();

            // Inicializar la colección de pacientes
            this.ListaPacientes = listaPacientes;
            this.mainContent = mainContent;
            this.DataContext = this;
        }

        public Page_Patients(MainContent mainContent)
        {
            this.mainContent = mainContent;
        }

        // Método para manejar el evento TextChanged del TextBox
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Aquí puedes agregar lógica para filtrar la lista de pacientes o actualizar la UI
        }

        // Método para manejar el evento Click del botón 'Nuevo Paciente'
        private void Button_NuevoPaciente_Click(object sender, RoutedEventArgs e)
        {
            // Navegar a Page_NewPatient en el mismo Frame
            this.NavigationService.Navigate(new Page_New_Patients(mainContent));
        }

        private void Button_Patientinformation_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Patient__Information(mainContent));
        }

        private void Button_SurveyList_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Survey_list(mainContent));
        }

        private void Button_EditPatientinformation_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Edit_Patient_Information(mainContent));
        }
    }
}
