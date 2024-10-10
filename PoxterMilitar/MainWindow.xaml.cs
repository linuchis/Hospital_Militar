using PoxterMilitar.Views;
using System.Windows;
using PoxterMilitar.classe;

namespace PoxterMilitar
{

    public partial class MainWindow : Window
    {
        public static List<dato_dispositivo> ListaDispositivo { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            ListaDispositivo = new List<dato_dispositivo>();

            MainFrame.Navigate(new Login());
        }
    }
}