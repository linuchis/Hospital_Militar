using Microsoft.Windows.Themes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PoxterMilitar.classe;
using PoxterMilitar.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Sockets;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PoxterMilitar.Features
{
    /// <summary>
    /// Lógica de interacción para MainContent.xaml
    /// </summary>
    public partial class MainContent : Page
    {
        public static ObservableCollection<dato_paciente> ListaPacientes { get; set; }
        SocketIOClient.SocketIO socket;

        public bool PrimeraEncuesta=true;
        

        public MainContent()
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

            // Navegar el Frame de InicioPacientes a la página InicioPacientes
            FrameInicioPacientes.Navigate(new InicioPacientes(this));

            // Navegar el Frame de Page_Patients a la página Page_Patients
            FramePagePatients.Navigate(new Page_Patients(ListaPacientes, this));

            InitSocket();
        }

        public void navigateToPatients()
        {
            FramePagePatients.Navigate(new Page_Patients(ListaPacientes, this));
        }

        public void navigateToUsers()
        {
            FramePagePatients.Navigate(new Page_Users());
        }

        public void navigateToLogin()
        {
            NavigationService.Navigate(new Login());
        }





        public void navigateToSesion()
        {
            Log_Out log_Out = new Log_Out(this);
            log_Out.ShowDialog();
        }

        private void InitSocket()
        {
            socket = new SocketIOClient.SocketIO(Settings.Default.Socket);

            socket.On("VRSimulator", (data) =>
            {
                Console.WriteLine(data);
                string message = data.GetValue<string>();

                try
                {
                    JObject jsonObject = JObject.Parse(message);

                    if (jsonObject.ContainsKey("receiverId"))
                    {
                        if (jsonObject["receiverId"].ToString().Equals("INSTRUCTOR1"))
                        {
                            if (jsonObject.ContainsKey("senderId"))
                            {
                                if (jsonObject["senderId"].ToString().Equals("VR1"))
                                {
                                    if (jsonObject.ContainsKey("command"))
                                    {
                                        if (jsonObject["command"].ToString().Equals("Estado"))
                                        {
                                            if (jsonObject.ContainsKey("state"))
                                            {
                                                switch (jsonObject["state"].ToString())
                                                {
                                                    case "Finalizado":
                                                        FramePagePatients.Dispatcher.Invoke(new Action(() =>
                                                        {
                                                            var page = FramePagePatients.Content as Patient__Information;

                                                            if (page != null)
                                                            {
                                                                page.EnableSurveyButton();
                                                            }
                                                        }));
                                                        break;
                                                    default:
                                                        break;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch
                {
                }
            });

            socket.ConnectAsync();
        }

        public void LoadExercise(string receiverId, string nameExercise, string profile, string firstStep)
        {
            socket.EmitAsync("VRSimulator", "{\"command\": \"Comenzar\", \"receiverId\": \"" + receiverId + "\", \"senderId\": \"INSTRUCTOR1\", \"nameEx\": \"" + nameExercise + "\", \"firtsStep\": \"" + firstStep + "\", \"profile\": \"" + profile + "\"}");
        }


        public void RestartExercise(string receiverId)
        {
            socket.EmitAsync("VRSimulator", "{\"command\": \"Reiniciar\", \"receiverId\": \"" + receiverId + "\", \"senderId\": \"INSTRUCTOR1\"}");
        }

        public void StopExercise(string receiverId)
        {
            socket.EmitAsync("VRSimulator", "{\"command\": \"Detener\", \"receiverId\": \"" + receiverId + "\", \"senderId\": \"INSTRUCTOR1\"}");
        }

    }
}
