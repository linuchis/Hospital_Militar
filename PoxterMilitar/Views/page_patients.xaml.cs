using System.Windows.Controls;
using System.Windows;

namespace PoxterMilitar.Views
{
    public partial class Page_Patients : Page
    {
        public Page_Patients()
        {
            InitializeComponent();

            // Inicializar lista de pacientes
            List<PacientePageModel> pacientes = new List<PacientePageModel>
            {
                new PacientePageModel { Foto = "/Resources/Inicio/logo_blanco_soracost_1.png", Nombre = "Nombre", Apellido = "Apellido", Genero = "Genero", Altura = "Altura", Peso = "Peso", Correo = "Correo", Telefono = "Telefono" },
                // Agrega más pacientes según sea necesario
            };

            // Puedes enlazar la lista de pacientes a un control, como un DataGrid, si es necesario
            // DataGridPacientes.ItemsSource = pacientes;
        }

        // Maneja el evento para el botón de nuevo paciente
        private void Btn_NewPaciente(object sender, RoutedEventArgs e)
        {
            // Lógica para agregar un nuevo paciente
        }

        // Maneja el evento cuando se selecciona un paciente en la lista
        private void DataPacientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Lógica para manejar la selección de un paciente
        }

        // Maneja el evento para un botón genérico (puede ser usado para diferentes acciones)
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Lógica para manejar el click en un botón
        }

        // Nuevo método para manejar el evento TextChanged en el TextBox
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Lógica para manejar el cambio de texto en el TextBox
            // Por ejemplo, filtrar la lista de pacientes o buscar un paciente específico.
        }
    }

    // Clase Paciente que almacena la información de cada paciente
    public class PacientePageModel
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
}
