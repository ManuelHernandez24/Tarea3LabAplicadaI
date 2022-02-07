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
using Tarea_3.UI.Registro;

namespace Tarea_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RegistroCarreraMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var rCarrera = new rCarrera();
            rCarrera.Show();
        }


        private void RegistroEstudianteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var rEstudiante = new rEstudiante();
            rEstudiante.Show();
        }

    }
}
