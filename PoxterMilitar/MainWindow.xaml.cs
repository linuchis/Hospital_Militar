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

            MainFrame.Navigate(new Login());
        }
    }
}