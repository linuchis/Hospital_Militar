using PoxterMilitar.classe;
using PoxterMilitar.DataAccess;
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
    /// Lógica de interacción para Edit_Real_Patient_Information.xaml
    /// </summary>
    public partial class Edit_Real_Patient_Information : Page
    {
        MainContent mainContent;
        private readonly PatientService _patientService;
        private long patientId;
        private dato_paciente patient;

        public Edit_Real_Patient_Information(MainContent mainContent)
        {
            InitializeComponent();
            this.mainContent = mainContent;
        }

        public Edit_Real_Patient_Information(MainContent mainContent, long id_p)
        {
            InitializeComponent();
            this.mainContent = mainContent;
            this.patientId = id_p;
            _patientService = new PatientService();

            LoadPatientData();
        }

        private void LoadPatientData()
        {
            try
            {
                // Obtener el paciente por ID
                patient = _patientService.GetPatientById(patientId);
                if (patient != null)
                {
                    // Asignar los datos a los TextBoxes y ComboBox
                    NombrePaciente.Text = patient.Nombre;
                    ApellidoPaciente.Text = patient.Apellido;
                    GeneroPaciente.SelectedItem = GetComboBoxItemByContent(GeneroPaciente, patient.Genero);
                    PesoPaciente.Text = patient.Peso.ToString();
                    AlturaPaciente.Text = patient.Altura.ToString();
                    Id_Paciente.Text = patient.Id.ToString();
                    // Asigna otros controles según sea necesario
                }
                else
                {
                    MessageBox.Show("Paciente no encontrado.");
                    mainContent.navigateToPatients();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos del paciente: {ex.Message}");
            }
        }

        private ComboBoxItem GetComboBoxItemByContent(ComboBox comboBox, string content)
        {
            foreach (ComboBoxItem item in comboBox.Items)
            {
                if (item.Content.ToString().Trim().Equals(content, StringComparison.OrdinalIgnoreCase))
                {
                    return item;
                }
            }
            return null;
        }

        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            mainContent.navigateToPatients();
        }

        private void Button_Save_Patient_Click(object sender, RoutedEventArgs e)
        {
            SavePatientData();
        }

        private void SavePatientData()
        {
            try
            {
                if (patient == null)
                {
                    MessageBox.Show("No se ha cargado la información del paciente.");
                    return;
                }

                // Obtener los datos de los controles
                string nombre = NombrePaciente.Text.Trim();
                string apellido = ApellidoPaciente.Text.Trim();
                string genero = (GeneroPaciente.SelectedItem as ComboBoxItem)?.Content.ToString().Trim();
                if (!int.TryParse(PesoPaciente.Text.Trim(), out int peso))
                {
                    MessageBox.Show("Peso inválido.");
                    PesoPaciente.BorderBrush = Brushes.Red;
                    return;
                }
                if (!int.TryParse(AlturaPaciente.Text.Trim(), out int altura))
                {
                    MessageBox.Show("Altura inválida.");
                    AlturaPaciente.BorderBrush = Brushes.Red;
                    return;
                }

                // Validar que los campos obligatorios no estén vacíos
                if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) || string.IsNullOrEmpty(genero))
                {
                    MessageBox.Show("Por favor, completa todos los campos obligatorios.");
                    return;
                }

                // Actualizar el objeto paciente
                patient.Nombre = nombre;
                patient.Apellido = apellido;
                patient.Genero = genero;
                patient.Peso = peso;
                patient.Altura = altura;
                // Actualiza otras propiedades según sea necesario

                // Actualizar en la base de datos
                _patientService.UpdatePatient(patient);

                MessageBox.Show("Datos del paciente actualizados correctamente.");

                // Navegar de vuelta a la lista de pacientes
                mainContent.navigateToPatients();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar los datos del paciente: {ex.Message}");
            }
        }

    }
}
