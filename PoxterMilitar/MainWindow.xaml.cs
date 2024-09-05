using PoxterMilitar.Views;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PoxterMilitar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Cargar la primera página en el primer Frame
            FrameInicioPacientes.Navigate(new InicioPacientes());

            // Cargar la segunda página en el segundo Frame
            FramePagePatients.Navigate(new Page_Users());
        }
    }
}