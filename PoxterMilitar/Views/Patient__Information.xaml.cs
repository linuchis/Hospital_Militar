using PoxterMilitar.classe;
using PoxterMilitar.Features;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Net.Sockets;
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
using PoxterMilitar.DataAccess;
using PoxterMilitar.Models;
using System.ComponentModel;

namespace PoxterMilitar.Views
{
    /// <summary>
    /// Lógica de interacción para Patient__Information.xaml
    /// </summary>
    public partial class Patient__Information : Page, INotifyPropertyChanged
    {
        // Colección observable que estará vinculada al DataGrid

        MainContent mainContent;
        private PatientService _userPatients;
        private long patientId;
        private dato_paciente patients;
        private List<dato_paciente> _listaPacientes;
        public List<dato_paciente> ListaPacientes
        {
            get { return _listaPacientes; }
            set
            {
                _listaPacientes = value;
                OnPropertyChanged(nameof(ListaPacientes));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        //-----------------------------------------------------------------------------

        public Patient__Information(long id, MainContent mainContent)
        {
            InitializeComponent();
            this.mainContent = mainContent;
            this.patientId = id; // Asignar el ID del paciente
            _userPatients = new PatientService();

            LoadPatientData();

            this.DataContext = this; // Establecer DataContext a la página misma

            if (!this.mainContent.PrimeraEncuesta)
            {
                Encuesta.Visibility = Visibility.Hidden;
            }
        }


        public Patient__Information(MainContent mainContent)
        {
            this.mainContent = mainContent;
        }

        private void LoadPatientData()
        {
            try
            {
                // Obtener el paciente por ID
                patients = _userPatients.GetPatientById(patientId);
                if (patients != null)
                {
                    // Asignar el paciente a una lista para el DataGrid
                    ListaPacientes = new List<dato_paciente> { patients };
                }
                else
                {
                    MessageBox.Show("Paciente no encontrado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos del paciente: {ex.Message}");
            }
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Text == "Digite número")
            {
                textBox.Text = "";
                textBox.Foreground = new SolidColorBrush(Colors.Black); // Cambia el color del texto cuando el usuario escribe
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Digite número";
                textBox.Foreground = new SolidColorBrush(Colors.Gray); // Cambia el color del texto del placeholder
            }
        }

        private void IniciarPrograma_Click(object sender, RoutedEventArgs e)
        {
            if (ExerciseCombo.SelectionBoxItem != null
                //&& ExerciseCombo.SelectedIndex != 0
                && Equipo.SelectionBoxItem != null
                //&& Equipo.SelectedIndex != 0
                && Perfil.SelectionBoxItem != null
                //&& Perfil.SelectedIndex != 0
                //&& PrimerosPasos.IsChecked == true
                && !string.IsNullOrEmpty(Repeticiones.Text) // Verifica que no esté vacío
                && int.TryParse(Repeticiones.Text, out int rep) // Verifica que sea un número válido
                && rep > 0) // Verifica que el número sea mayor que 0
            {
                mainContent.LoadExercise(Equipo.SelectionBoxItem.ToString(), ExerciseCombo.SelectionBoxItem.ToString(), Perfil.SelectionBoxItem.ToString(), PrimerosPasos.IsChecked.ToString(), rep);
            }
        }

        private void ReiniciarPrograma_Click(object sender, RoutedEventArgs e)
        {
            if (Equipo.SelectionBoxItem != null
                //&& Equipo.SelectedIndex != 0
                )
            {
                mainContent.RestartExercise(Equipo.SelectionBoxItem.ToString());
            }
        }

        private void DetenerPrograma_Click(object sender, RoutedEventArgs e)
        {
            if (Equipo.SelectionBoxItem != null
                //&& Equipo.SelectedIndex != 0
                )
            {
                mainContent.StopExercise(Equipo.SelectionBoxItem.ToString());
            }
        }

        public void EnableSurveyButton()
        {
            Encuesta.Visibility = Visibility.Visible;
        }

        private void EncuestaUsuario_Click(object sender, RoutedEventArgs e)
        {
            // 
            this.NavigationService.Navigate(new Survey_Patient(mainContent));
        }

        private void Button_BackPatients(object sender, RoutedEventArgs e)
        {
            mainContent.navigateToPatients();
        }

        private void CheckPrimerosPasos_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Button_BackHome(object sender, RoutedEventArgs e)
        {
            mainContent.navigateToPatients();
        }

        private void Button_Maximice(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Inicio de transmisión...", "Estado de transmisión", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Button_SurveyList_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Survey_list(mainContent));
        }

        private void Button_EditPatientinformation_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Edit_Patient_Information(mainContent));
        }

        private void ExerciseCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
