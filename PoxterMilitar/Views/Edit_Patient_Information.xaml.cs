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

namespace PoxterMilitar.Views
{
    /// <summary>
    /// Lógica de interacción para Edit_Patient_Information.xaml
    /// </summary>
    public partial class Edit_Patient_Information : Page
    {

        MainContent mainContent;

        public Edit_Patient_Information(MainContent mainContent)
        {
            this.mainContent = mainContent;
        }

        public Edit_Patient_Information(long id_p, MainContent mainContent)
        {
            InitializeComponent();
            this.mainContent = mainContent;
        }

        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            mainContent.navigateToPatients();
        }
        private void Button_ToEditRealPatientInformation(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Edit_Real_Patient_Information(mainContent));
        }
    }
}
