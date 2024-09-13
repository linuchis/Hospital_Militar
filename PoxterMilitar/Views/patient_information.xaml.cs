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
    /// Lógica de interacción para patient_information.xaml
    /// </summary>
    public partial class Patient_Information : Page
    {
        // Colección observable que estará vinculada al DataGrid
        public ObservableCollection<dato_paciente> ListaPacientes { get; set; }

        public Patient_Information()
        {
            InitializeComponent();

            // Inicializar la colección de pacientes
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
