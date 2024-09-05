using System.Windows.Controls;
using System.Windows;
using System.Collections.ObjectModel;

namespace PoxterMilitar.Views
{
    public partial class Page_Patients : Page
    {
        // Colección observable que estará vinculada al DataGrid
        public ObservableCollection<Paciente> ListaPacientes { get; set; }

        public Page_Patients()
        {
            InitializeComponent();

            // Inicializar la colección de pacientes
            ListaPacientes = new ObservableCollection<Paciente>
            {
                new Paciente
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

        // Método para manejar el evento TextChanged del TextBox
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Aquí puedes agregar lógica para filtrar la lista de pacientes o actualizar la UI
        }

        // Método para manejar el evento Click del botón 'Nuevo Paciente'
        private void Btn_NewPaciente(object sender, RoutedEventArgs e)
        {
            // Lógica para agregar un nuevo paciente o abrir una ventana de creación de paciente
            MessageBox.Show("Botón 'Nuevo Paciente' fue clicado.");
        }
    }
}
