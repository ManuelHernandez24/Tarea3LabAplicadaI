using System.Windows;
using Registro.Entidades;
using Registro.BLL;

namespace Tarea_3.UI.Registro
{
    public partial class rCarrera : Window
    {
        private Carrera carrera = new Carrera();

        public rCarrera()
        {
            InitializeComponent();

            this.DataContext = carrera;
            RefrescarConsultaCarrera();
        }

        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = this.carrera;
        }

        private void Limpiar()
        {
            this.carrera = new Carrera();
            this.DataContext = carrera;
        }

        private bool Validar()
        {
            bool esValido = true;

            if (string.IsNullOrWhiteSpace(carrera.Nombre))
            {
                esValido = false;
                NombreTextBox.Focus();
                MessageBox.Show("Debe indicar el nombre!", "Validación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return esValido;
        }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var encontrado = CarreraBLL.Buscar (this.carrera.CarreraId);

            if (encontrado != null)
            {
                this.carrera = encontrado;
                Cargar();

            }
            else
            {
                Limpiar();
                MessageBox.Show("No se encontro la carrera!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            RefrescarConsultaCarrera();

        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
            RefrescarConsultaCarrera();
        }


        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if (!Validar())
                return;

            paso = CarreraBLL.Guardar(carrera);

            if (paso)
                MessageBox.Show("Carrera guardado con éxito", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("No se pudo guardar la carrera", "Fallo", MessageBoxButton.OK, MessageBoxImage.Information);
            RefrescarConsultaCarrera();

        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (CarreraBLL.Eliminar(carrera.CarreraId))
            {
                Limpiar();
                MessageBox.Show("Carrera eliminado con éxito", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No se pudo eliminar la carrera", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            RefrescarConsultaCarrera();
        }

        void RefrescarConsultaCarrera(){
            DataGridConsultaCarrera.ItemsSource = CarreraBLL.GetList();
        }
    }
}