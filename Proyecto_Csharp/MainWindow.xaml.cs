using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Proyecto_Csharp
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string valor1 = ConfigurationManager.AppSettings["Valor1"];
            string valor2 = ConfigurationManager.AppSettings["Valor2"];

            txtValor1.Text = valor1;
            txtValor2.Text = valor2;
        }

        private void GuardarValores_Click(object sender, RoutedEventArgs e)
        {
            // Guardar los valores ingresados en la interfaz gráfica en el archivo de configuración
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            config.AppSettings.Settings["Valor1"].Value = txtValor1.Text;
            config.AppSettings.Settings["Valor2"].Value = txtValor2.Text;

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");

            MessageBox.Show("Valores guardados correctamente.");
        }
    }
}
