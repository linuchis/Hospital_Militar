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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
            // Suscribe al evento SizeChanged de la ventana
            this.Loaded += Login_Loaded;
        }

        private void Login_Loaded(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            if (parentWindow != null)
            {
                parentWindow.SizeChanged += Window_SizeChanged;
            }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            const double aspectRatio = 16.0 / 9.0;

            // Determina si la altura o el ancho es el que está cambiando más
            if (e.WidthChanged)
            {
                // Ajusta la altura en función del nuevo ancho para mantener la relación 16:9
                ((Window)sender).Height = ((Window)sender).Width / aspectRatio;
            }
            else if (e.HeightChanged)
            {
                // Ajusta el ancho en función de la nueva altura para mantener la relación 16:9
                ((Window)sender).Width = ((Window)sender).Height * aspectRatio;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Aquí puedes manejar el evento TextChanged si es necesario
        }
    }
}
