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

namespace PoxterMilitar.Views
{
    /// <summary>
    /// Lógica de interacción para Patient__Information.xaml
    /// </summary>
    public partial class Patient__Information : Page
    {
        // Colección observable que estará vinculada al DataGrid
        public ObservableCollection<dato_paciente> ListaPacientes { get; set; }

        MainContent mainContent;

        public Patient__Information(MainContent mainContent)
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
            this.mainContent = mainContent;
            if (!this.mainContent.PrimeraEncuesta)
            {
                Encuesta.Visibility = Visibility.Hidden;
            }
        }

        private void IniciarPrograma_Click(object sender, RoutedEventArgs e)
        {
            if (ExerciseCombo.SelectionBoxItem != null
                && ExerciseCombo.SelectedIndex != 0
                && Equipo.SelectionBoxItem != null
                && Equipo.SelectedIndex != 0
                && Perfil.SelectionBoxItem != null
                && Perfil.SelectedIndex != 0
                && PrimerosPasos.IsChecked == true)
            {
                mainContent.LoadExercise(Equipo.SelectionBoxItem.ToString(), ExerciseCombo.SelectionBoxItem.ToString(), Perfil.SelectionBoxItem.ToString(), PrimerosPasos.IsChecked.ToString());
            }
        }

        private void ReiniciarPrograma_Click(object sender, RoutedEventArgs e)
        {
            if (Equipo.SelectionBoxItem != null
                && Equipo.SelectedIndex != 0)
            {
                mainContent.RestartExercise(Equipo.SelectionBoxItem.ToString());
            }
        }

        private void DetenerPrograma_Click(object sender, RoutedEventArgs e)
        {
            if (Equipo.SelectionBoxItem != null
                && Equipo.SelectedIndex != 0)
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
    }
}
