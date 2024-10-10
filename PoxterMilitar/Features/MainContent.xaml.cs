using Newtonsoft.Json.Linq;
using PoxterMilitar.classe;
using PoxterMilitar.DataAccess;
using PoxterMilitar.Views;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace PoxterMilitar.Features
{

    public partial class MainContent : Page
    {
        public static List<dato_paciente> ListaPacientes { get; set; }
        public static ObservableCollection<dato_usuario> ListaUsuario { get; set; }

        SocketIOClient.SocketIO socket;

        public bool PrimeraEncuesta = true;
        private PatientService _patientService;

        public MainContent()
        {
            InitializeComponent();
            _patientService = new PatientService(); // Inicializa el servicio


            ListaPacientes = _patientService.GetAllPatients();

            // Navegar el Frame de InicioPacientes a la página InicioPacientes
            FrameInicioPacientes.Navigate(new InicioPacientes(this));

            // Navegar el Frame de Page_Patients a la página Page_Patients
            FramePagePatients.Navigate(new Page_Patients(ListaPacientes, this));

            InitSocket();
        }

        public void navigateToPatients()
        {
            //var pagePatients = new Page_Patients(this);
            //FramePagePatients.Navigate(pagePatients);
            FramePagePatients.Navigate(new Page_Patients(ListaPacientes, this));
        }

        public void navigateToUsersList()
        {
            FramePagePatients.Navigate(new Page_Users(this));
        }

        public void navigateToSettings()
        {
            FramePagePatients.Navigate(new page_config_oculus(this));
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

        public void navigateToInfoPassword()
        {
            Recover_Password recover_Password = new Recover_Password(this);
            recover_Password.ShowDialog();
        }

        public void navigateToWrongData()
        {
            Login_Error login_Error = new Login_Error(this);
            login_Error.ShowDialog();
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

        public void LoadExercise(string receiverId, string nameExercise, string profile, string firstStep, int rep)
        {
            socket.EmitAsync("VRSimulator", "{\"command\": \"Comenzar\", \"receiverId\": \"" + receiverId + "\", \"senderId\": \"INSTRUCTOR1\", \"nameEx\": \"" + nameExercise + "\", \"firtsStep\": \"" + firstStep + "\", \"profile\": \"" + profile + "\", \"rep\": \"" + rep + "\"}");
        }


        public void RestartExercise(string receiverId)
        {
            socket.EmitAsync("VRSimulator", "{\"command\": \"Reiniciar\", \"receiverId\": \"" + receiverId + "\", \"senderId\": \"INSTRUCTOR1\"}");
        }

        public void StopExercise(string receiverId)
        {
            socket.EmitAsync("VRSimulator", "{\"command\": \"Detener\", \"receiverId\": \"" + receiverId + "\", \"senderId\": \"INSTRUCTOR1\"}");
        }

        internal void navigateToUserInformation()
        {
            throw new NotImplementedException();
        }
    }
}
