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
        public InicioPacientes()
        {
            InitializeComponent();

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Patientinformation_Click(object sender, RoutedEventArgs e)
        {
            // Navegar a Page_NewPatient en el mismo Frame
            this.NavigationService.Navigate(new Patient__Information());
        }
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