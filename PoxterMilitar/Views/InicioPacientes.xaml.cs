﻿using PoxterMilitar.Features;
using System.Windows;
using System.Windows.Controls;

namespace PoxterMilitar.Views
{
    /// <summary>
    /// Interaction logic for InicioPacientes.xaml
    /// </summary>
    public partial class InicioPacientes : Page
    {
        MainContent mainContent;

        public InicioPacientes(MainContent mainContent)
        {
            InitializeComponent();

            this.mainContent = mainContent;

            List<Paciente> pacientes = new List<Paciente>
            {

            };
        }
        private void Button_VerPacientes_Click(object sender, RoutedEventArgs e)
        {
        }


        private void Btn_NewPaciente(object sender, RoutedEventArgs e)
        {

        }

        private void DataPacientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged()
        {

        }

        private void Button_Patientinformation_Click(object sender, RoutedEventArgs e)
        {
            mainContent.navigateToPatients();
        }

        private void Button_Userinformation_Click(object sender, RoutedEventArgs e)
        {
            mainContent.navigateToUserInformation();
        }


        private void Button_UsersList_Click(object sender, RoutedEventArgs e)
        {
            mainContent.navigateToUsersList();
        }

        private void Button_Settings_Click(object sender, RoutedEventArgs e)
        {
            mainContent.navigateToSettings();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mainContent.navigateToLogin();
        }

        private void Button_Exit(object sender, RoutedEventArgs e)
        {
            mainContent.navigateToSesion();
        }

        public class Paciente
        {
            public string? Foto { get; set; }
            public string? Nombre { get; set; }
            public string? Apellido { get; set; }
            public string? Genero { get; set; }
            public string? Altura { get; set; }
            public string? Peso { get; set; }
            public string? Correo { get; set; }
            public string? Telefono { get; set; }
        }

        //Agregar informacion en los datos
    }
}
