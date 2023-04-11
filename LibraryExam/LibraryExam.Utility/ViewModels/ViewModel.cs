using System.ComponentModel;

namespace LibraryExam.Utility.ViewModels
{
    public abstract class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(sender: this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
