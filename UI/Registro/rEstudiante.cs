
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
        private Estudiante Estudiante = new Estudiante();

        public rEstudiante()
        {
            InitializeComponent();
        }

        

        private List<Carrera> listaCarreras;
        private void ActualizarCarrerasCombobox()
        {
            
            listaCarreras = CarreraBLL.GetList(c => true);
            CarreraComboBox.ItemsSource = listaCarreras;
        }
    }
}