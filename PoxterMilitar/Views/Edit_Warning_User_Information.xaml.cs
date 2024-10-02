using PoxterMilitar.Features;
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
    /// Lógica de interacción para Edit_Warning_User_Information.xaml
    /// </summary>
    public partial class Edit_Warning_User_Information : Window
    {
        MainContent mainContent;
        public Edit_Warning_User_Information(MainContent mainContent)
        {
            InitializeComponent();
            this.mainContent = mainContent;
        }
    }
    

}
