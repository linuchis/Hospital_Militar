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
    public partial class Page_Patients : Page
    {
        public List<dato_paciente> ListaPacientes { get; set; }
        public MainContent mainContent;
        private Page_Patients page_Patients;
        private readonly PatientService _patientService; // Instancia del servicio

        public Page_Patients(List<dato_paciente> listaPacientes, MainContent mainContent)
        {
            InitializeComponent();
            this.mainContent = mainContent;
            ListaPacientes = listaPacientes;
            _patientService = new PatientService(); // Inicializa el servicio

            this.DataContext = this;
        }

        public Page_Patients(Page_Patients page_Patients)
        {
            this.page_Patients = page_Patients;
        }
        //--------------------------------------------------------------------------------------------------------------------------
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }

        private void Button_NuevoPaciente_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Page_New_Patients(mainContent));
        }

        //ESTE ES EL BOTON QUE DEBE CREAR LA NAVEGACIÓN A LA PÁGINA DE INFORMACIÓN DEL PACIENTE
        private void Button_Patientinformation_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                dato_paciente selectedPatient = button.DataContext as dato_paciente;
                if (selectedPatient != null)
                {
                    this.NavigationService.Navigate(new Patient__Information(selectedPatient.Id, mainContent));
                }
            }
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