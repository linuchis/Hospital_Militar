﻿using PoxterMilitar.Features;
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
    public partial class Alert : Window
    {
        public Alert(string message)
        {
            InitializeComponent();

            lblMensaje.Text = message;
        }

        private void Button_OK(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
