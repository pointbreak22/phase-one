using System.ComponentModel;

namespace Events
{
    public class NotifyProperty : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string msg)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(msg));
        }
    }
}