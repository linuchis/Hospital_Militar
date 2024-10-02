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
    public partial class Page_New_Patients : Page
    {
        public MainContent mainContent;

        public Page_New_Patients(MainContent mainContent)
        {
            InitializeComponent();
            this.mainContent = mainContent;
            this.DataContext = this;

        }

        // Evento cuando el CheckBox está marcado
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            // Hacer visible el Grid cuando el CheckBox está marcado
            GridAmputacion.Visibility = Visibility.Visible;
        }

        // Evento cuando el CheckBox está desmarcado
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            // Colapsar el Grid cuando el CheckBox está desmarcado
            GridAmputacion.Visibility = Visibility.Collapsed;
        }

        private void Button_IniciarSesion_Click(object sender, RoutedEventArgs e)
        {
            

            mainContent.navigateToPatients();

           
        }

        private void SavePatient_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            mainContent.navigateToPatients();
        }
    }
}
