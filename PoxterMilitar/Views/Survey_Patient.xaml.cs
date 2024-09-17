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
    /// Lógica de interacción para Survey_Patient.xaml
    /// </summary>
    public partial class Survey_Patient : Page
    {
        MainContent mainContent;
        public Survey_Patient(MainContent mainContent)
        {
            InitializeComponent();
            this.mainContent = mainContent;     
        }
        private void Button_GuardarEncuesta(object sender, RoutedEventArgs e)
        {
            this.mainContent.PrimeraEncuesta =false;
            this.NavigationService.Navigate(new Patient__Information(mainContent));
        }



    }

    



}
