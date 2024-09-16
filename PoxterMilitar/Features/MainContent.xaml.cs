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

namespace PoxterMilitar.Features
{
    /// <summary>
    /// Lógica de interacción para MainContent.xaml
    /// </summary>
    public partial class MainContent : Page
    {
        public MainContent()
        {
            InitializeComponent();

            // Navegar el Frame de InicioPacientes a la página InicioPacientes
            FrameInicioPacientes.Navigate(new InicioPacientes());

            // Navegar el Frame de Page_Patients a la página Page_Patients
            FramePagePatients.Navigate(new Page_Patients());

        }
    }
}
