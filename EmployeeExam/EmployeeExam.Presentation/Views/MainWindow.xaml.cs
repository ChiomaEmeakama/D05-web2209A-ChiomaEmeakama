using System.Windows;

namespace EmployeeExam.Presentation.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            MinWidth = Width;
            MinHeight = Height;
        }
    }
}
