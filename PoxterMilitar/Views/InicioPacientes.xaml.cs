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
    /// Interaction logic for InicioPacientes.xaml
    /// </summary>
    public partial class InicioPacientes : Page
    {
        MainContent mainContent;

        public InicioPacientes(MainContent mainContent)
        {
            InitializeComponent();

            this.mainContent = mainContent;

            List<Paciente> pacientes = new List<Paciente>
            {

            };
        }
        private void Button_VerPacientes_Click(object sender, RoutedEventArgs e)
        {
            // Si deseas que el botón también cargue la página, puedes mantener este método
        }


        private void Btn_NewPaciente(object sender, RoutedEventArgs e)
        {

        }

        private void DataPacientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged()
        {

        }

        private void Button_Patientinformation_Click(object sender, RoutedEventArgs e)
        {
            mainContent.navigateToPatients();
        }

        private void Button_Userinformation_Click(object sender, RoutedEventArgs e)
        {
            mainContent.navigateToUsers();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mainContent.navigateToLogin();
        }

        private void Button_Exit(object sender, RoutedEventArgs e)
        {
            mainContent.navigateToSesion();
        }

        public class Paciente
        {
            public string? Foto { get; set; }
            public string? Nombre { get; set; }
            public string? Apellido { get; set; }
            public string? Genero { get; set; }
            public string? Altura { get; set; }
            public string? Peso { get; set; }
            public string? Correo { get; set; }
            public string? Telefono { get; set; }
        }

        //Agregar informacion en los datos
    }
}
