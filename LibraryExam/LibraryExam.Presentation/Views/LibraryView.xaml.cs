using System.ComponentModel;
using System.Windows.Controls;
using LibraryExam.Application.ViewModels;

namespace LibraryExam.Presentation.Views
{
    public partial class LibraryView : UserControl
    {
        public LibraryView()
        {
            InitializeComponent();
            if (!DesignerProperties.GetIsInDesignMode(this))
                DataContext = new LibraryViewModel();
        }
    }
}
