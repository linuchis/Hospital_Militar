using PoxterMilitar.classe;
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
    /// <summary>
    /// Lógica de interacción para Patient__Information.xaml
    /// </summary>
    public partial class Patient__Information : Page
    {
        // Colección observable que estará vinculada al DataGrid
        public ObservableCollection<dato_paciente> ListaPacientes { get; set; }

        public Patient__Information()
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

            this.DataContext = this;
        }

       

        private void Button_NuevoPaciente_Click(object sender, RoutedEventArgs e)
        {
            // Navegar a Page_NewPatient en el mismo Frame
            this.NavigationService.Navigate(new Page_New_Patients());
        }
    }
}
