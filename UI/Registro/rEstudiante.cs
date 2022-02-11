
/*Click="NuevoButton_Click"
                <Button Content="✔ Guardar"/>
 Click="EliminarButton_Click"
 Click="BuscarButton_Click" 
 */
using System.Windows;
using Registro.Entidades;
using Registro.BLL;

namespace Tarea_3.UI.Registro
{
    public partial class rEstudiante : Window
    {
        private Estudiante estudiante = new Estudiante();

        public rEstudiante()
        {
            InitializeComponent();
            AddCarrerasCombobox();
            Cargar();
            RefrescarConsultaEstudiante();
        }

        void RefrescarConsultaEstudiante(){
            DataGridConsultaEstudiante.ItemsSource = EstudianteBLL.GetList();
        }
        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = this.estudiante;
        }

        void AddCarrerasCombobox(){
            CarreraComboBox.ItemsSource = CarreraBLL.GetListaCarrera(c => true);
        }

        private void Limpiar()
        {
            this.estudiante = new Estudiante();
            this.DataContext = estudiante;
        }

        private bool Validar()
        {
            bool esValido = true;

            if (string.IsNullOrWhiteSpace(estudiante.Nombres))
            {
                esValido = false;
                NombresTextBox.Focus();
                MessageBox.Show("Debe indicar el nombre!", "Validación", MessageBoxButton.OK, MessageBoxImage.Error);
            } 
            else if (string.IsNullOrWhiteSpace(estudiante.Nombres))
            {
                esValido = false;
                EmailTextBox.Focus();
                MessageBox.Show("Debe indicar el email!", "Validación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return esValido;
        }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var encontrado = EstudianteBLL.Buscar (this.estudiante.EstudianteId);

            if (encontrado != null)
            {
                this.estudiante = encontrado;
                Cargar();
            }
            else
            {
                Limpiar();
                MessageBox.Show("No se encontro la carrera!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            RefrescarConsultaEstudiante();
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
            RefrescarConsultaEstudiante();
        }


        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            if (!Validar()){
                if(ActivoCheckBox.IsChecked == true){
                    estudiante.Activo = true;
                } else {
                    estudiante.Activo = false;
                }             

                return;

            }            
            paso = EstudianteBLL.Guardar(estudiante);

            if (paso)
                MessageBox.Show("Carrera guardado con éxito", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("No se pudo guardar la carrera", "Fallo", MessageBoxButton.OK, MessageBoxImage.Information);
            RefrescarConsultaEstudiante();
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (EstudianteBLL.Eliminar(estudiante.EstudianteId))
            {
                Limpiar();
                MessageBox.Show("Carrera eliminado con éxito", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No se pudo eliminar la carrera", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            
            RefrescarConsultaEstudiante();
        }
    }
}
        
