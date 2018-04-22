using System;
using System.ComponentModel;
using Model.Entity;
using ViewModel.CustomControls.EntityFields;

namespace ViewModel.Windows.CreateEditEntity
{
    public sealed class СreateEditAlternativeViewModel : BaseCreateEditViewModel<Alternative>
    {
        public override Alternative Entity
        {
            get
            {
                entity.Name = this.AlternativeFieldsViewModel.Name;
                return entity;
            }
            set
            {
                entity = value;
                this.AlternativeFieldsViewModel.Name = value.Name;               
            }
        }

        public AlternativeFieldsViewModel AlternativeFieldsViewModel => 
            this.EntityFieldsViewModel as AlternativeFieldsViewModel;

        public СreateEditAlternativeViewModel()
        {
            this.EntityFieldsViewModel = new AlternativeFieldsViewModel();
            this.EntityFieldsViewModel.PropertyChanged += this.RefreshIsOkEnabled;
        }

        protected override void RefreshIsOkEnabled(object sender, PropertyChangedEventArgs e)
        {
            this.IsOkEnabled = !string.IsNullOrEmpty(this.AlternativeFieldsViewModel.Name);
        }
    }
}
