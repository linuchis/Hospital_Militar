using PoxterMilitar.classe;
using PoxterMilitar.Views;
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

namespace PoxterMilitar.Features
{
    /// <summary>
    /// Lógica de interacción para MainContent.xaml
    /// </summary>
    public partial class MainContent : Page
    {
        public static ObservableCollection<dato_paciente> ListaPacientes { get; set; }

        public MainContent()
        {
            InitializeComponent();

            ListaPacientes = new ObservableCollection<dato_paciente>
            {
                new dato_paciente
                {
                    Foto = "/Resources/Inicio/Pacientes_List/lina.png",
                    Nombre = "Lina",
                    Apellido = "Castañeda",
                    Genero = "Femenino",
                    Altura = "1.73",
                    Peso = "73",
                    Correo = "lina.castaneda@sasoftco.com",
                    Telefono = "3208942453"
                }
            };

            // Navegar el Frame de InicioPacientes a la página InicioPacientes
            FrameInicioPacientes.Navigate(new InicioPacientes(this));

            // Navegar el Frame de Page_Patients a la página Page_Patients
            FramePagePatients.Navigate(new Page_Patients(ListaPacientes, this));

        }

        public void navigateToPatients()
        {
            FramePagePatients.Navigate(new Page_Patients(ListaPacientes, this));
        }

        public void navigateToUsers()
        {
            FramePagePatients.Navigate(new Page_Users());
        }

        public void navigateToLogin()
        {
            NavigationService.Navigate(new Login());
        }
    }
}
