using PoxterMilitar.classe;
using PoxterMilitar.Features;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Net.Sockets;
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
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows.Interop;

namespace PoxterMilitar.Views
{
    /// <summary>
    /// Lógica de interacción para page_config_oculus.xaml
    /// </summary>
    public partial class page_config_oculus : Page
    {
        MainContent mainContent;

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        private Process scrcpyProcess;

        public page_config_oculus(MainContent mainContent)
        {
            InitializeComponent();

            this.DataContext = this;
            this.mainContent = mainContent;
        }

        private async void IniciarVinculacion_Click(object sender, RoutedEventArgs e)
        {
            if (Equipo.SelectedValue != null)
            {
                MessageBox.Show("Conecta un dispositivo Oculus por USB para configurarlo.");

                string deviceSerial = GetUsbDeviceSerial();
                if (!string.IsNullOrEmpty(deviceSerial))
                {
                    // Obtener la IP del dispositivo
                    string deviceIp = GetDeviceIp(deviceSerial);

                    if (!string.IsNullOrEmpty(deviceIp))
                    {
                        // Habilitar ADB over WiFi
                        EnableAdbTcpip(deviceSerial);

                        // Conectar por WiFi
                        ConnectAdbDevice(deviceIp);

                        // Agregar el dispositivo a la lista de dispositivos conectados
                        MainWindow.ListaDispositivo.Add(new dato_dispositivo { id = Equipo.SelectedValue.ToString(), devideIp = deviceIp });
                        deviceList.Items.Add(Equipo.SelectedValue.ToString() + "-" + deviceIp);
                    }
                }
                else
                {
                    MessageBox.Show("No se detectó un dispositivo Oculus conectado por USB");
                }
            }
            else
            {
                MessageBox.Show("Seleccione un dispositivo de la lista");
            }
        }

        // Obtener el serial del dispositivo conectado por USB
        private string GetUsbDeviceSerial()
        {
            var adbProcess = new Process();
            adbProcess.StartInfo.FileName = @"..\..\..\scrcpy\adb";
            adbProcess.StartInfo.Arguments = "devices";
            adbProcess.StartInfo.UseShellExecute = false;
            adbProcess.StartInfo.RedirectStandardOutput = true;
            adbProcess.StartInfo.CreateNoWindow = true;

            adbProcess.Start();
            string output = adbProcess.StandardOutput.ReadToEnd();
            adbProcess.WaitForExit();

            // Parsear el output para obtener el serial del dispositivo USB
            var lines = output.Split('\n');
            var usbDeviceLine = lines.FirstOrDefault(line => line.Contains("device") && !line.Contains("List"));
            if (usbDeviceLine != null)
            {
                return usbDeviceLine.Split('\t')[0]; // El serial está antes de "device"
            }

            return null;
        }

        // Obtener la IP del dispositivo conectado por USB
        private string GetDeviceIp(string usbSerial)
        {
            try
            {
                var adbProcess = new Process();
                adbProcess.StartInfo.FileName = @"..\..\..\scrcpy\adb";
                adbProcess.StartInfo.Arguments = $"-s {usbSerial} shell ip route";
                adbProcess.StartInfo.UseShellExecute = false;
                adbProcess.StartInfo.RedirectStandardOutput = true;
                adbProcess.StartInfo.CreateNoWindow = true;

                adbProcess.Start();
                string output = adbProcess.StandardOutput.ReadToEnd();
                adbProcess.WaitForExit();

                // Extraer la IP de la salida del comando
                var lines = output.Split('\n');
                foreach (var line in lines)
                {
                    if (line.Contains("wlan0"))
                    {
                        string[] parts = line.Split(' ');

                        // Buscar la palabra "src" y obtener la IP que está justo después
                        int srcIndex = Array.IndexOf(parts, "src");
                        if (srcIndex != -1 && srcIndex + 1 < parts.Length)
                        {
                            string ipWithoutMask = parts[srcIndex + 1]; // La IP estará justo después de "src"
                            return ipWithoutMask; // Devuelve la segunda IP (después de "src")
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener la IP: " + ex.Message);
            }

            return null;
        }

        // Habilitar ADB over WiFi en el dispositivo conectado
        private void EnableAdbTcpip(string usbSerial)
        {
            try
            {
                var adbProcess = new Process();
                adbProcess.StartInfo.FileName = @"..\..\..\scrcpy\adb";
                adbProcess.StartInfo.Arguments = $"-s {usbSerial} tcpip 5555";
                adbProcess.StartInfo.UseShellExecute = false;
                adbProcess.StartInfo.RedirectStandardOutput = true;
                adbProcess.StartInfo.CreateNoWindow = true;

                adbProcess.Start();
                adbProcess.WaitForExit();
                MessageBox.Show("ADB over WiFi habilitado.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al habilitar ADB over WiFi: " + ex.Message);
            }
        }

        // Conectar el dispositivo por WiFi usando su IP
        private void ConnectAdbDevice(string deviceIp)
        {
            try
            {
                var adbProcess = new Process();
                adbProcess.StartInfo.FileName = @"..\..\..\scrcpy\adb";
                adbProcess.StartInfo.Arguments = $"connect {deviceIp}:5555";
                adbProcess.StartInfo.UseShellExecute = false;
                adbProcess.StartInfo.RedirectStandardOutput = true;
                adbProcess.StartInfo.CreateNoWindow = true;

                adbProcess.Start();
                adbProcess.WaitForExit();
                MessageBox.Show($"Dispositivo conectado por WiFi: {deviceIp}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar ADB por WiFi: " + ex.Message);
            }
        }

        private void IniciarTransmicion_Click(object sender, RoutedEventArgs e)
        {
            string selectedDeviceIp = deviceList.SelectedItem as string;
            if (!string.IsNullOrEmpty(selectedDeviceIp))
            {
                string[] partes = selectedDeviceIp.Split('-');
                if (partes.Length > 1)
                {
                    StartScrcpyCast(partes[1]);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un dispositivo vinculado");
            }
        }

        private void StartScrcpyCast(string deviceIp)
        {
            try
            {
                // Obtener la resolución del dispositivo
                var resolution = GetDeviceResolution(deviceIp);

                if (resolution != null)
                {
                    int screenWidth = resolution.Item1;
                    int screenHeight = resolution.Item2;

                    // Recortar solo un lente (lado izquierdo) - se asume que la pantalla está dividida por la mitad
                    int halfWidth = screenWidth / 2;

                    // Inicializamos scrcpy con el dispositivo seleccionado
                    scrcpyProcess = new Process();
                    scrcpyProcess.StartInfo.FileName = @"..\..\..\scrcpy\scrcpy.exe"; // Cambia la ruta a la ubicación de scrcpy
                    scrcpyProcess.StartInfo.Arguments = $"-s {deviceIp}:5555 --crop {halfWidth}:{screenHeight}:0:0"; // Solo el lado izquierdo
                    scrcpyProcess.StartInfo.UseShellExecute = false;
                    scrcpyProcess.StartInfo.CreateNoWindow = true;

                    // Iniciar scrcpy
                    scrcpyProcess.Start();

                    // Esperar hasta que el proceso tenga un MainWindowHandle válido
                    IntPtr scrcpyHandle = IntPtr.Zero;
                    int retryCount = 0;

                    while (scrcpyHandle == IntPtr.Zero && retryCount < 10)
                    {
                        Thread.Sleep(500); // Espera 500ms antes de intentar obtener el handle de la ventana
                        scrcpyHandle = scrcpyProcess.MainWindowHandle;
                        retryCount++;
                    }

                    if (scrcpyHandle == IntPtr.Zero)
                    {
                        MessageBox.Show("No se pudo obtener la ventana de scrcpy.");
                        return;
                    }

                    // Obtener la ventana que contiene la Page
                    Window parentWindow = Window.GetWindow(this);

                    if (parentWindow != null)
                    {
                        // Obtener el handle de la ventana contenedora
                        IntPtr wpfWindowHandle = new WindowInteropHelper(parentWindow).Handle;

                        // Cambiar el padre de la ventana scrcpy al contenedor de WPF
                        SetParent(scrcpyHandle, wpfWindowHandle);

                        // Ajustar la ventana de scrcpy dentro del contenedor
                        MoveWindow(scrcpyHandle, 0, 0, (int)scrcpyContainer.ActualWidth, (int)scrcpyContainer.ActualHeight, true);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al iniciar scrcpy: " + ex.Message);
            }
        }

        // Método para obtener la resolución del dispositivo usando ADB
        private Tuple<int, int> GetDeviceResolution(string deviceIp)
        {
            try
            {
                var adbProcess = new Process();
                adbProcess.StartInfo.FileName = "adb";
                adbProcess.StartInfo.Arguments = $"-s {deviceIp} shell wm size"; // Obtener el tamaño de pantalla
                adbProcess.StartInfo.UseShellExecute = false;
                adbProcess.StartInfo.RedirectStandardOutput = true;
                adbProcess.StartInfo.CreateNoWindow = true;

                adbProcess.Start();
                string output = adbProcess.StandardOutput.ReadToEnd();
                adbProcess.WaitForExit();

                // Buscar la línea que contiene la resolución
                var match = Regex.Match(output, @"Physical size: (\d+)x(\d+)");
                if (match.Success)
                {
                    int width = int.Parse(match.Groups[1].Value);
                    int height = int.Parse(match.Groups[2].Value);
                    return Tuple.Create(width, height);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener la resolución del dispositivo: " + ex.Message);
            }

            return null;
        }

        private void Desconectar_Click(object sender, RoutedEventArgs e)
        {
            var adbProcess = new Process();
            adbProcess.StartInfo.FileName = @"..\..\..\scrcpy\adb";
            adbProcess.StartInfo.Arguments = "disconnect";
            adbProcess.StartInfo.UseShellExecute = false;
            adbProcess.StartInfo.RedirectStandardOutput = true;
            adbProcess.StartInfo.CreateNoWindow = true;

            adbProcess.Start();
            adbProcess.WaitForExit();

            deviceList.Items.Clear();
        }

        private void Button_BackHome(object sender, RoutedEventArgs e)
        {
            mainContent.navigateToPatients();
        }
    }
}
