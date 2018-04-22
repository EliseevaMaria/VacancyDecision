using System;
using System.ComponentModel;
using Model.Entity;
using ViewModel.CustomControls.EntityFields;

namespace ViewModel.Windows.CreateEditEntity
{
    public sealed class СreateEditMarkViewModel : BaseCreateEditViewModel<Mark>
    {
        public СreateEditMarkViewModel()
        {
            this.EntityFieldsViewModel = new MarkFieldsViewModel();
            this.EntityFieldsViewModel.PropertyChanged += this.RefreshIsOkEnabled;
        }

        public override Mark Entity
        {
            get
            {
                entity.Name = this.MarkFieldsViewModel.Name;
                entity.Rank = Convert.ToInt32(this.MarkFieldsViewModel.Rank);
                entity.QuantitativeValue = Convert.ToInt32(this.MarkFieldsViewModel.QuantitativeValue);
                entity.NormalizedValue = Convert.ToInt32(this.MarkFieldsViewModel.NormalizedValue);
                entity.Criterion = this.MarkFieldsViewModel.Criterion;
                return entity;
            }
            set
            {
                entity = value;
                this.MarkFieldsViewModel.Criterion = value.Criterion;
                this.MarkFieldsViewModel.Rank = value.Rank.ToString();         
                this.MarkFieldsViewModel.QuantitativeValue = value.QuantitativeValue.ToString();         
                this.MarkFieldsViewModel.NormalizedValue = value.NormalizedValue.ToString();
                this.MarkFieldsViewModel.Name = value.Name;
            }
        }

        public MarkFieldsViewModel MarkFieldsViewModel => 
            this.EntityFieldsViewModel as MarkFieldsViewModel;

        protected override void RefreshIsOkEnabled(object sender, PropertyChangedEventArgs e)
        {
            this.IsOkEnabled = !string.IsNullOrEmpty(this.MarkFieldsViewModel.Name)
                            && !string.IsNullOrEmpty(this.MarkFieldsViewModel.Rank)
                            && !string.IsNullOrEmpty(this.MarkFieldsViewModel.QuantitativeValue)
                            && !string.IsNullOrEmpty(this.MarkFieldsViewModel.NormalizedValue)
                            && this.MarkFieldsViewModel.Criterion != null;
        }
    }
}
