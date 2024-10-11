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
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Interop;
using System.Text.RegularExpressions;

namespace PoxterMilitar.Views
{
    
    public partial class Patient__Information : Page, INotifyPropertyChanged
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        private Process scrcpyProcess;

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
            this.patientId = id; 
            _userPatients = new PatientService();

            LoadPatientData();

            this.DataContext = this; 

            if (!this.mainContent.PrimeraEncuesta)
            {
                Encuesta.Visibility = Visibility.Hidden;
            }

            var ejercicio = MainContent.ListaEjercicios.Where(l => l.Id == id).FirstOrDefault();
            if(ejercicio != null)
            {
                foreach (ComboBoxItem item in Equipo.Items)
                {
                    if (item.Tag != null && item.Tag.ToString() == ejercicio.Dispositivo)
                    {
                        Equipo.SelectedItem = item;
                        break;
                    }
                }

                foreach (ComboBoxItem item in ExerciseCombo.Items)
                {
                    if (item.Tag != null && item.Tag.ToString() == ejercicio.Ejercicio)
                    {
                        ExerciseCombo.SelectedItem = item;
                        break;
                    }
                }

                foreach (ComboBoxItem item in Perfil.Items)
                {
                    if (item.Tag != null && item.Tag.ToString() == ejercicio.Extremidad)
                    {
                        Perfil.SelectedItem = item;
                        break;
                    }
                }

                PrimerosPasos.IsChecked = ejercicio.PrimerosPasos;
                Repeticiones.Text = ejercicio.Repeticiones;
                Repeticiones.Foreground = new SolidColorBrush(Colors.Black);

                if (ejercicio.Estado == "Ejecutando")
                {
                    Equipo.IsEnabled = false;
                }
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
                textBox.Foreground = new SolidColorBrush(Colors.Black); 
            }

            
            textBox.BorderBrush = Brushes.Gray;
            ErrorMessage.Visibility = Visibility.Collapsed;
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Digite número";
                textBox.Foreground = new SolidColorBrush(Colors.Gray); 
            }
            else
            {
               
                if (!int.TryParse(textBox.Text, out int rep) || rep <= 0 || rep > 50)
                {                
                    textBox.BorderBrush = Brushes.Red;
                    ErrorMessage.Visibility = Visibility.Visible;
                }
                else
                {                    
                    textBox.BorderBrush = Brushes.Gray;
                    ErrorMessage.Visibility = Visibility.Collapsed;
                }
            }
        }

        //------------------------------------------

        private void IniciarPrograma_Click(object sender, RoutedEventArgs e)
        {
            bool isValid = true;
            int rep = 0;            
            Repeticiones.BorderBrush = Brushes.Gray;
            ErrorMessage.Visibility = Visibility.Collapsed;
            
            if (string.IsNullOrWhiteSpace(Repeticiones.Text) ||
                !int.TryParse(Repeticiones.Text, out rep) ||
                rep <= 0 ||
                rep > 50)
            {
                isValid = false;
                Repeticiones.BorderBrush = Brushes.Red; 
                ErrorMessage.Visibility = Visibility.Visible;
            }           
            if (ExerciseCombo.SelectionBoxItem == null ||
                Equipo.SelectionBoxItem == null ||
                Perfil.SelectionBoxItem == null)
            {
                isValid = false;                
                MessageBox.Show("Por favor, completa todos los campos requeridos.");
            }

            if (isValid)
            {
                mainContent.LoadExercise(
                    Equipo.SelectedValue.ToString(),
                    ExerciseCombo.SelectedValue.ToString(),
                    Perfil.SelectedValue.ToString(),
                    PrimerosPasos.IsChecked.ToString(),
                    rep
                );
            }
        }

        private void ReiniciarPrograma_Click(object sender, RoutedEventArgs e)
        {
            if (Equipo.SelectionBoxItem != null               
                )
            {
                mainContent.RestartExercise(Equipo.SelectionBoxItem.ToString());
            }
        }

        private void DetenerPrograma_Click(object sender, RoutedEventArgs e)
        {
            if (Equipo.SelectionBoxItem != null                
                )
            {
                mainContent.StopExercise(Equipo.SelectionBoxItem.ToString());
            }
        }

        public void Ejecutando(string senderId)
        {
            Equipo.IsEnabled = false;

            var ejercicio = MainContent.ListaEjercicios.Where(l => l.Dispositivo.Equals(senderId)).FirstOrDefault();

            if (ejercicio == null)
            {
                MainContent.ListaEjercicios.Add(new dato_ejercicio { Estado = "Ejecutando", Dispositivo = senderId, Id = this.patientId, Ejercicio = ExerciseCombo.SelectedValue.ToString(), Extremidad = Perfil.SelectedValue.ToString(), PrimerosPasos = (bool)PrimerosPasos.IsChecked, Repeticiones = Repeticiones.Text });
            }
            else
            {
                ejercicio.Id = this.patientId;
                ejercicio.Ejercicio = ExerciseCombo.SelectedValue.ToString();
                ejercicio.Extremidad = Perfil.SelectedValue.ToString();
                ejercicio.PrimerosPasos = (bool)PrimerosPasos.IsChecked;
                ejercicio.Repeticiones = Repeticiones.Text;
            }
        }

        public void Finalizado()
        {
            Equipo.IsEnabled = true;
            EnableSurveyButton();
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

        private void Button_Cast(object sender, RoutedEventArgs e)
        {
            var ejercicio = MainContent.ListaEjercicios.Where(l => l.Id == this.patientId).FirstOrDefault();

            if (ejercicio != null)
            {
                var dispositivo = MainWindow.ListaDispositivo.Where(l => l.id.Equals(ejercicio.Dispositivo)).FirstOrDefault();
                if (dispositivo != null)
                {
                    if (scrcpyProcess == null || scrcpyProcess.HasExited)
                    {
                        StartScrcpyCast(dispositivo.devideIp);
                    }
                    else
                    {
                        Alert alert = new Alert("Hay una transmisión en curso");
                        alert.ShowDialog();
                    }
                }
                else
                {
                    Alert alert = new Alert("No se ha configurado el dispositivo");
                    alert.ShowDialog();
                }
            }
            else
            {
                Alert alert = new Alert("Debe ejecutar un ejercicio para iniciar la transmisión");
                alert.ShowDialog();
            }
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

        private void StartScrcpyCast(string deviceIp)
        {
            try
            {
                // Obtener la resolución del dispositivo
                var resolution = GetDeviceResolution(deviceIp);

                if (resolution != null)
                {
                    int screenWidth = resolution.Item1;
                    int screenHeight = resolution.Item2;

                    // Recortar solo un lente (lado izquierdo) - se asume que la pantalla está dividida por la mitad
                    int halfWidth = screenWidth / 2;

                    // Inicializamos scrcpy con el dispositivo seleccionado
                    scrcpyProcess = new Process();
                    scrcpyProcess.StartInfo.FileName = @"..\..\..\scrcpy\scrcpy.exe"; // Cambia la ruta a la ubicación de scrcpy
                    scrcpyProcess.StartInfo.Arguments = $"-s {deviceIp}:5555 --crop {halfWidth}:{screenHeight}:0:0"; // Solo el lado izquierdo
                    scrcpyProcess.StartInfo.UseShellExecute = false;
                    scrcpyProcess.StartInfo.CreateNoWindow = true;

                    // Iniciar scrcpy
                    scrcpyProcess.Start();

                    // Esperar hasta que el proceso tenga un MainWindowHandle válido
                    IntPtr scrcpyHandle = IntPtr.Zero;
                    int retryCount = 0;

                    while (scrcpyHandle == IntPtr.Zero && retryCount < 10)
                    {
                        Thread.Sleep(500); // Espera 500ms antes de intentar obtener el handle de la ventana
                        scrcpyHandle = scrcpyProcess.MainWindowHandle;
                        retryCount++;
                    }

                    if (scrcpyHandle == IntPtr.Zero)
                    {
                        Alert alert = new Alert("No se pudo obtener la ventana de scrcpy");
                        alert.ShowDialog();
                        return;
                    }

                    // Obtener la ventana que contiene la Page
                    Window parentWindow = Window.GetWindow(this);

                    if (parentWindow != null)
                    {
                        // Obtener el handle de la ventana contenedora
                        IntPtr wpfWindowHandle = new WindowInteropHelper(parentWindow).Handle;

                        // Cambiar el padre de la ventana scrcpy al contenedor de WPF
                        SetParent(scrcpyHandle, wpfWindowHandle);

                        double containerWidth = scrcpyContainer.ActualWidth;
                        double containerHeight = scrcpyContainer.ActualHeight;

                        // Convertir las coordenadas del contenedor a coordenadas de pantalla
                        Point screenPos = scrcpyContainer.PointToScreen(new Point(0, 0));

                        // Obtener las coordenadas x e y de la posición en pantalla
                        int x = (int)screenPos.X;
                        int y = (int)screenPos.Y - 20;

                        // Mover la ventana scrcpy a la posición y tamaño del contenedor
                        MoveWindow(scrcpyHandle, x, y, (int)containerWidth, (int)containerHeight, true);
                    }
                }
            }
            catch (Exception ex)
            {
                Alert alert = new Alert("Error al iniciar scrcpy: " + ex.Message);
                alert.ShowDialog();
            }
        }

        // Método para obtener la resolución del dispositivo usando ADB
        private Tuple<int, int> GetDeviceResolution(string deviceIp)
        {
            try
            {
                var adbProcess = new Process();
                adbProcess.StartInfo.FileName = "adb";
                adbProcess.StartInfo.Arguments = $"-s {deviceIp} shell wm size"; // Obtener el tamaño de pantalla
                adbProcess.StartInfo.UseShellExecute = false;
                adbProcess.StartInfo.RedirectStandardOutput = true;
                adbProcess.StartInfo.CreateNoWindow = true;

                adbProcess.Start();
                string output = adbProcess.StandardOutput.ReadToEnd();
                adbProcess.WaitForExit();

                // Buscar la línea que contiene la resolución
                var match = Regex.Match(output, @"Physical size: (\d+)x(\d+)");
                if (match.Success)
                {
                    int width = int.Parse(match.Groups[1].Value);
                    int height = int.Parse(match.Groups[2].Value);
                    return Tuple.Create(width, height);
                }
            }
            catch (Exception ex)
            {
                Alert alert = new Alert("Error al obtener la resolución del dispositivo: " + ex.Message);
                alert.ShowDialog();
            }

            return null;
        }
    }
}
