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
using System.Collections.ObjectModel;

namespace PoxterMilitar.Views
{

    public partial class Survey_List : Page
    {
        private readonly MainContent mainContent;
        private readonly long patientId;
        private readonly SurveyService surveyService;
       
        public Survey_List(long patientId, MainContent mainContent)
        {
            InitializeComponent(); //maldito funciona cuando quiere
            this.mainContent = mainContent;
            this.patientId = patientId;
            this.surveyService = new SurveyService();

            LoadSurveys();
            this.DataContext = this;
        }

        public ObservableCollection<surveys_patients> Surveys { get; set; }

        private void LoadSurveys()
        {
            var surveys = surveyService.GetSurveysByPatient(patientId);
            Surveys = new ObservableCollection<surveys_patients>(surveys);
        }

        //Este bot[on es el que va a la encuesta seg[un la encuesta seleccionada mostrada.

        private void ViewSurveyButton_Click(object sender, RoutedEventArgs e)
        {
            if (SurveysDataGrid.SelectedItem is surveys_patients selectedSurvey)
            {
                NavigationService.Navigate(new Survey_View(selectedSurvey));
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una encuesta para ver.");
            }
        }

        private void Button_Patientinformation_Click(object sender, RoutedEventArgs e)
        {
            mainContent.navigateToPatients();
        }



    }

}
