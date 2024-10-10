using PoxterMilitar.classe;
using PoxterMilitar.DataAccess;
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
        private readonly PatientService _patientService;

        public Page_New_Patients(MainContent mainContent)
        {
            InitializeComponent();
            this.mainContent = mainContent;
            _patientService = new PatientService();
            this.DataContext = this; ;

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            GridAmputacion.Visibility = Visibility.Visible;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            GridAmputacion.Visibility = Visibility.Collapsed;
        }

        //--------------
        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            mainContent.navigateToPatients();
        }

        private void Button_IniciarSesion_Click(object sender, RoutedEventArgs e)
        {          
            mainContent.navigateToPatients();           
        }

        private void Button_SavePatient_Click(object sender, RoutedEventArgs e)
        {
            SavePatientData();
        }

        private void SavePatientData()
        {
            try
            {
                // Obtener los datos de los controles
                string nombre = Nombre.Text.Trim();
                string apellidos = Apellidos.Text.Trim();
                string genero = (Sexo.SelectedItem as ComboBoxItem)?.Content.ToString().Trim();
                string idText = ID.Text.Trim();
                string pesoText = Weight.Text.Trim();
                string alturaText = Height.Text.Trim();

                // Validaciones
                if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellidos) || string.IsNullOrEmpty(genero) || string.IsNullOrEmpty(idText))
                {
                    MessageBox.Show("Por favor, completa todos los campos obligatorios.", "Campos Vacíos", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (!long.TryParse(idText, out long id_p))
                {
                    MessageBox.Show("ID inválido. Por favor, ingrese un número válido.", "Error de Validación", MessageBoxButton.OK, MessageBoxImage.Error);
                    ID.BorderBrush = Brushes.Red;
                    return;
                }

                if (!double.TryParse(pesoText, out double peso))
                {
                    MessageBox.Show("Peso inválido. Por favor, ingrese un número válido.", "Error de Validación", MessageBoxButton.OK, MessageBoxImage.Error);
                    Weight.BorderBrush = Brushes.Red;
                    return;
                }

                if (!double.TryParse(alturaText, out double altura))
                {
                    MessageBox.Show("Altura inválida. Por favor, ingrese un número válido.", "Error de Validación", MessageBoxButton.OK, MessageBoxImage.Error);
                    Height.BorderBrush = Brushes.Red;
                    return;
                }

                // Crear un nuevo objeto dato_paciente
                dato_paciente newPatient = new dato_paciente
                {
                    Id = id_p,
                    Nombre = nombre,
                    Apellido = apellidos,
                    Genero = genero,
                    Peso = (long)peso,
                    Altura = (long)altura
                    // Ignoramos extremidades amputadas y tipo de documento según la solicitud
                };

                // Agregar el paciente a la base de datos
                _patientService.AddPatient(newPatient);

                MessageBox.Show("Paciente guardado correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);

                // Limpiar los campos después de guardar (opcional)
                ClearFields();

                // Navegar de vuelta a la lista de pacientes
                mainContent.navigateToPatients();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el paciente: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Método Opcional para Limpiar los Campos
        private void ClearFields()
        {
            Nombre.Text = string.Empty;
            Apellidos.Text = string.Empty;
            Sexo.SelectedIndex = 3; // Seleccionar "No se identifica"
            ID.Text = string.Empty;
            Weight.Text = string.Empty;
            Height.Text = string.Empty;
            CheckAmputacion.IsChecked = false;
            ComboBox1.SelectedIndex = 3; // Seleccionar "Tipo de documento"
            Extremidad1.SelectedIndex = 4; // Seleccionar "Seleccionar extremidad amputada"
            Extremidad2.SelectedIndex = 4; // Seleccionar "Seleccionar extremidad amputada"
        }
    }
    
}
