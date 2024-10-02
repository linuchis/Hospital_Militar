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
    /// Lógica de interacción para Survey_list.xaml
    /// </summary>
    public partial class Survey_list : Page
    {
        MainContent mainContent;


        public Survey_list(long id, MainContent mainContent)
        {
            InitializeComponent();
            this.mainContent = mainContent;
        }

        public Survey_list(MainContent mainContent)
        {
            InitializeComponent();
            this.mainContent = mainContent;
        }
    }
}
