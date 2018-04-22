using System;
using System.ComponentModel;
using Model.Entity;
using ViewModel.CustomControls;
using ViewModel.CustomControls.EntityFields;
using ViewModel.Windows.CreateEditEntity;

namespace ViewModel
{
    public abstract class BaseEntityTabViewModel<T> : BaseViewModel, IDisposable
        where T : BaseEntity, new()
    {
        public abstract void ClearFilter();

        private bool clearFilterButtonEnabled;
        public bool ClearFilterButtonEnabled
        {
            get
            {
                return this.clearFilterButtonEnabled;
            }
            set
            {
                if (this.clearFilterButtonEnabled == value)
                    return;

                this.clearFilterButtonEnabled = value;
                this.OnPropertyChanged(nameof(this.ClearFilterButtonEnabled));
            }
        }

        public BaseCreateEditViewModel<T> CreateEditViewModel
        {
            set;
            get;
        }

        public virtual void CreateRecord()
        {
            try
            {
                this.CreateEditViewModel.Entity = new T();
                bool result =
                    this.InteractionService.ProvideService($"Open{typeof(T).Name}EditWindowServiceId", this.CreateEditViewModel);
                if (result == true)
                    this.GridControlViewModel.CreateRecord(this.CreateEditViewModel.Entity);
            }
            catch (Exception e)
            {
                this.InteractionService.ProvideService(ViewService.ServiceId.ShowErrorServiceId, e.Message);
            }
        }

        public virtual void Dispose()
        {
            this.EntityFieldsViewModel.PropertyChanged -= this.RefreshClearFilterButtonEnabled;
            this.GridControlViewModel.PropertyChanged -= this.RefreshIsRecordSelected;
        }

        public EntityFieldsViewModel EntityFieldsViewModel
        {
            set;
            get;
        }

        public virtual void Delete()
        {
            try
            {
                this.GridControlViewModel.Delete();
            }
            catch (Exception e)
            {
                this.InteractionService.ProvideService(ViewService.ServiceId.ShowErrorServiceId, e.Message);
            }
        }

        public abstract void Filter();

        private bool isRecordSelected;
        public bool IsRecordSelected
        {
            get
            {
                return this.isRecordSelected;
            }
            set
            {
                if (this.isRecordSelected == value)
                    return;

                this.isRecordSelected = value;
                this.OnPropertyChanged(nameof(this.IsRecordSelected));
            }
        }

        public GridControlViewModel<T> GridControlViewModel
        {
            get;
            set;
        }

        protected abstract void RefreshClearFilterButtonEnabled(object sender, PropertyChangedEventArgs e);

        protected virtual void RefreshIsRecordSelected(object sender, PropertyChangedEventArgs e)
        {
            this.IsRecordSelected = this.GridControlViewModel.SelectedRecord != null;
        }

        public virtual void UpdateRecord()
        {
            try
            {
                this.CreateEditViewModel.Entity = this.GridControlViewModel.SelectedRecord;
                bool result =
                    this.InteractionService.ProvideService($"Open{typeof(T).Name}EditWindowServiceId", this.CreateEditViewModel);
                if (result == true)
                    this.GridControlViewModel.UpdateRecord(this.CreateEditViewModel.Entity);
            }
            catch (Exception e)
            {
                this.InteractionService.ProvideService(ViewService.ServiceId.ShowErrorServiceId, e.Message);
            }
        }
    }
}
