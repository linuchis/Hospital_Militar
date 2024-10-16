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

namespace PoxterMilitar.Views
{
    public partial class Survey_Patient : Page
    {
        private readonly SurveyService _surveyService;
        private readonly long patientId;
        private readonly MainContent mainContent;

        public Survey_Patient(long patientId, MainContent mainContent)
        {
            InitializeComponent();
            _surveyService = new SurveyService();
            this.patientId = patientId;
            this.mainContent = mainContent;   // Solo Dios y yo know

            // Mensaje de depuración para verificar el patientId
            MessageBox.Show($"Survey_Patient cargada para el paciente ID: {patientId}");
        }

        private void Button_GuardarEncuesta(object sender, RoutedEventArgs e)
        {
            var survey = new surveys_patients
            {
                hour_survey = DateTime.Now,
                _1_survey = Encuesta_1.Text,
                _2_survey = Encuesta_2.Text,
                _3_survey = Encuesta_3.Text,
                _4_survey = Encuesta_4.Text,
                _5_survey = Encuesta_5.Text,
                _6_survey = Encuesta_6.Text,
                _7_survey = Encuesta_7.Text,
                _8_survey = Encuesta_8.Text,
                _9_survey = Encuesta_9.Text,
                _10_survey = Encuesta_10.Text,
                id_p = patientId
            };

            try
            {
                _surveyService.AddSurvey(survey);
                MessageBox.Show("Encuesta guardada exitosamente.");

                // Navegar de vuelta a la lista de encuestas del paciente
                mainContent.navigateToSurveyList(patientId);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la encuesta: {ex.Message}");
            }

            mainContent.PrimeraEncuesta = false;
        }

        private void Button_Patientinformation_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Patient__Information(patientId, mainContent));
        }
    }


}
