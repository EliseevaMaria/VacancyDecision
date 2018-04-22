using System;
using System.ComponentModel;
using Model.Entity;
using ViewModel.CustomControls.EntityFields;

namespace ViewModel.Windows.CreateEditEntity
{
    public sealed class СreateEditExpertViewModel : BaseCreateEditViewModel<Expert>
    {
        public override Expert Entity
        {
            get
            {
                entity.Description = this.ExpertFieldsViewModel.Description;
                entity.Name = this.ExpertFieldsViewModel.Name;
                entity.Weight = Convert.ToInt32(this.ExpertFieldsViewModel.Weight);
                return entity;
            }
            set
            {
                entity = value;
                this.ExpertFieldsViewModel.Description = value.Description;
                this.ExpertFieldsViewModel.Name = value.Name;
                this.ExpertFieldsViewModel.Weight = value.Weight.ToString();                
            }
        }

        public ExpertFieldsViewModel ExpertFieldsViewModel => this.EntityFieldsViewModel as ExpertFieldsViewModel;

        public СreateEditExpertViewModel()
        {
            this.EntityFieldsViewModel = new ExpertFieldsViewModel();
            this.EntityFieldsViewModel.PropertyChanged += this.RefreshIsOkEnabled;
        }

        protected override void RefreshIsOkEnabled(object sender, PropertyChangedEventArgs e)
        {
            this.IsOkEnabled = !string.IsNullOrEmpty(this.ExpertFieldsViewModel.Description)
                            && !string.IsNullOrEmpty(this.ExpertFieldsViewModel.Name)
                            && !string.IsNullOrEmpty(this.ExpertFieldsViewModel.Weight);
        }
    }
}
