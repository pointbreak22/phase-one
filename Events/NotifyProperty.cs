using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

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