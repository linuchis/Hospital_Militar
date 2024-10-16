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

        public ObservableCollection<surveys_patients> Surveys { get; set; }

        public Survey_List(long patientId, MainContent mainContent)
        {
            InitializeComponent(); //??????????????????
            this.mainContent = mainContent;
            this.patientId = patientId;
            this.surveyService = new SurveyService();

            LoadSurveys();
            this.DataContext = this;
        }

        private void LoadSurveys()
        {
            var surveys = surveyService.GetSurveysByPatient(patientId);
            Surveys = new ObservableCollection<surveys_patients>(surveys);
        }

        private void Button_Patientinformation_Click(object sender, RoutedEventArgs e)
        {
            mainContent.navigateToPatients();
        }

        private void ViewSurveyButton_Click()
        {

        }



    }

}
