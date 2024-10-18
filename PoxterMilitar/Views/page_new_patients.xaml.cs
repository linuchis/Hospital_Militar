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

        private void Document_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Implementa lógica si es necesario para manejar cambios en el campo de documento
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            GridAmputacion.Visibility = Visibility.Visible;
            GridLabelAmp.Visibility = Visibility.Visible;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            GridAmputacion.Visibility = Visibility.Collapsed;
            GridLabelAmp.Visibility = Visibility.Collapsed;

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
            try
            {
                // Obtener y validar los datos de los controles de entrada
                long id_p;
                if (!long.TryParse(ID.Text, out id_p))
                {
                    MessageBox.Show("Por favor, ingresa un número de cédula válido.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                string nombre = Nombre.Text.Trim();
                string apellidos = Apellidos.Text.Trim();
                long peso;
                if (!long.TryParse(Weight.Text, out peso))
                {
                    MessageBox.Show("Por favor, ingresa un peso válido.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                long altura;
                if (!long.TryParse(Height.Text, out altura))
                {
                    MessageBox.Show("Por favor, ingresa una estatura válida.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                string genero = (Sexo.SelectedItem as ComboBoxItem)?.Content.ToString();
                string tipoDocumento = (ComboBox1.SelectedItem as ComboBoxItem)?.Content.ToString();
                string extremidadAmputada = (Extremidad1.SelectedItem as ComboBoxItem)?.Content.ToString();
                string segundoAmputado = null;
                
                if (CheckAmputacion.IsChecked == false)
                {
                    segundoAmputado = "No aplica";
                }
                else
                {
                    // Si el checkbox está marcado, pero no se seleccionó una opción, también asignar "No aplica"
                    segundoAmputado = (Extremidad2.SelectedItem as ComboBoxItem)?.Content.ToString();
                    if (string.IsNullOrEmpty(segundoAmputado))
                    {
                        segundoAmputado = "No aplica";
                    }
                }

                // Crear una instancia de dato_paciente
                var nuevoPaciente = new dato_paciente
                {
                    Id = id_p,
                    Nombre = nombre,
                    Apellido = apellidos,
                    Peso = peso,
                    Altura = altura,
                    Genero = genero,
                    PrimerAmp = extremidadAmputada,
                    SegundoAmp = segundoAmputado
                };

                // Agregar el nuevo paciente
                _patientService.AddPatient(nuevoPaciente);

                MessageBox.Show("Paciente agregado exitosamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);

                // Limpiar los campos después de guardar
                mainContent.navigateToPatients();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el paciente: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Método Opcional para Limpiar los Campos
        private void LimpiarCampos()
        {
            Nombre.Text = "";
            Apellidos.Text = "";
            Weight.Text = "";
            Height.Text = "";
            ComboBox1.SelectedIndex = -1;
            Sexo.SelectedIndex = -1;
            Extremidad1.SelectedIndex = -1;
            Extremidad2.SelectedIndex = -1;
            CheckAmputacion.IsChecked = false;
            GridAmputacion.Visibility = Visibility.Collapsed;
            ID.Text = "";
        }

        
    }
    
}
