using System;
using System.ComponentModel;

namespace ViewModel
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public ViewService InteractionService
        {
            set;
            get;
        }

        public void OnPropertyChanged(string propertyName = "")
        {
            if (this.PropertyChanged == null)
                return;

            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
