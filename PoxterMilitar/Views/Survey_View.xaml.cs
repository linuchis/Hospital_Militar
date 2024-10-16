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
using PoxterMilitar.Models;
using PoxterMilitar.Views;

namespace PoxterMilitar.Views
{
    
    public partial class Survey_View : Page
    {
        public Survey_View(surveys_patients survey)
        {
            InitializeComponent();
            this.DataContext = survey;
            
        }

        void Button_Patientinformation_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Patient_Information.xaml", UriKind.Relative));
        }

        void Button_GuardarEncuesta(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Survey_Patient.xaml", UriKind.Relative));
        }
        
        
        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
            else
            {
                MessageBox.Show("No hay páginas a las que regresar.", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }




    }
}
