using System;
using System.ComponentModel;
using ViewModel.CustomControls.EntityFields;

namespace ViewModel.Windows.CreateEditEntity
{
    public abstract class BaseCreateEditViewModel<T> : BaseViewModel, IDisposable
    {
        public void Dispose()
        {
            this.EntityFieldsViewModel.PropertyChanged -= this.RefreshIsOkEnabled;
        }

        protected T entity;
        public abstract T Entity
        {
            set;
            get;
        }

        public EntityFieldsViewModel EntityFieldsViewModel
        {
            set;
            get;
        }

        private bool isOkEnabled;
        public bool IsOkEnabled
        {
            get
            {
                return this.isOkEnabled;
            }
            set
            {
                if (this.isOkEnabled == value)
                    return;

                this.isOkEnabled = value;
                this.OnPropertyChanged(nameof(this.IsOkEnabled));
            }
        }

        protected abstract void RefreshIsOkEnabled(object sender, PropertyChangedEventArgs e);
    }
}
