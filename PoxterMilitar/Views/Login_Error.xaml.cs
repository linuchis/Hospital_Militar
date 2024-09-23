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
using System.Windows.Shapes;

namespace PoxterMilitar.Views
{
    /// <summary>
    /// Lógica de interacción para Login_Error.xaml
    /// </summary>
    public partial class Login_Error : Window
    {
        public Login_Error()
        {
            InitializeComponent();
        }

        private void Button_Accept(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
