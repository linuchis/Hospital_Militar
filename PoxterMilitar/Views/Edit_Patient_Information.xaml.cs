using PoxterMilitar.classe;
using PoxterMilitar.DataAccess;
using PoxterMilitar.Features;
using PoxterMilitar.Views;
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
    /// Lógica de interacción para Edit_Patient_Information.xaml
    /// </summary>
    public partial class Edit_Patient_Information : Page
    {
        MainContent mainContent;
        private readonly PatientService _patientService;
        private long patientId;
        private dato_paciente patient;

        public Edit_Patient_Information(MainContent mainContent, long patientId)
        {
            this.mainContent = mainContent;

            this.patientId = patientId;

            LoadPatientData();
        }


        public Edit_Patient_Information(MainContent mainContent)
        {
            this.mainContent = mainContent;
        }


        public Edit_Patient_Information(long id_p, MainContent mainContent)
        {
            InitializeComponent();
            this.mainContent = mainContent;
            this.patientId = id_p;
            _patientService = new PatientService();

            LoadPatientData();
        }

        

        private void LoadPatientData()
        {
            try
            {
                // Obtener el paciente por ID
                patient = _patientService.GetPatientById(patientId);
                if (patient != null)
                {
                    // Asignar los datos a los TextBlocks
                    NombresUsuario.Text = patient.Nombre;
                    ApellidosUsuario.Text = patient.Apellido;
                    GeneroUsuario.Text = patient.Genero;
                    PesoUsuario.Text = patient.Peso.ToString();
                    AlturaUsuario.Text = patient.Altura.ToString();
                    Id_Paciente.Text = patient.Id.ToString();
                    // Asigna otros TextBlocks según sea necesario
                }
                else
                {
                    MessageBox.Show("Paciente no encontrado.");
                    // Opcional: Navegar de vuelta a la lista de pacientes
                    mainContent.navigateToPatients();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos del paciente: {ex.Message}");
            }
        }

        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            mainContent.navigateToPatients();
        }

        private void Button_ToEditRealPatientInformation(object sender, RoutedEventArgs e)
        {
            // Asegúrate de que 'patientId' está definido y tiene el valor correcto
            this.NavigationService.Navigate(new Edit_Real_Patient_Information(mainContent, patientId));
        }

    }
}
