using PoxterMilitar.classe;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class Page_Users : Page
    {

        public ObservableCollection<dato_usuario> ListaUsuario { get; set; }

        public Page_Users()
        {
            InitializeComponent();
            // Inicializar la colección de pacientes
            ListaUsuario = new ObservableCollection<dato_usuario>
            {
                new dato_usuario
                {
                    Foto = "/Resources/Inicio/Pacientes_List/lina.png",
                    Nombre = "Lina",
                    Apellido = "Castañeda",
                    Area = "Ingenieria",
                    Correo = "lina.castaneda@sasoftco.com",
                    Telefono = "3208942453",
                    NivelAcceso = "Administrador"
                }
            };

            this.DataContext = this;

        }

        // Método para manejar el evento TextChanged del TextBox
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Aquí puedes agregar lógica para filtrar la lista de pacientes o actualizar la UI
        }

        // Método para manejar el evento Click del botón 'Nuevo Paciente'
        private void Btn_NewUser(object sender, RoutedEventArgs e)
        {
            // Lógica para agregar un nuevo paciente o abrir una ventana de creación de paciente
            MessageBox.Show("Botón 'Nuevo Usuario' fue clicado.");
        }
    }
}
