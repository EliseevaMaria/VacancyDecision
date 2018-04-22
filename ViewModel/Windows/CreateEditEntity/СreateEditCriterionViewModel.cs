using System;
using System.ComponentModel;
using Model.Entity;
using Model.Enumeration;
using ViewModel.CustomControls.EntityFields;

namespace ViewModel.Windows.CreateEditEntity
{
    public sealed class СreateEditCriterionViewModel : BaseCreateEditViewModel<Criterion>
    {
        public СreateEditCriterionViewModel()
        {
            this.EntityFieldsViewModel = new CriterionFieldsViewModel();
            this.EntityFieldsViewModel.PropertyChanged += this.RefreshIsOkEnabled;
        }

        public CriterionFieldsViewModel CriterionFieldsViewModel => 
            this.EntityFieldsViewModel as CriterionFieldsViewModel;

        public override Criterion Entity
        {
            get
            {
                entity.Name = this.CriterionFieldsViewModel.Name;
                entity.Range = Convert.ToInt32(this.CriterionFieldsViewModel.Range);
                entity.Weight = Convert.ToInt32(this.CriterionFieldsViewModel.Weight);
                entity.Type = this.CriterionFieldsViewModel.Type ?? CriterionType.Qualitative;
                entity.OptimalValue = this.CriterionFieldsViewModel.OptimalValue ?? CriterionOptimalValue.Maximum;
                entity.Unit = this.CriterionFieldsViewModel.Unit;
                entity.ScaleType = this.CriterionFieldsViewModel.ScaleType ?? CriterionScaleType.Interval;
                return entity;
            }
            set
            {
                entity = value;
                this.CriterionFieldsViewModel.Name = value.Name;
                this.CriterionFieldsViewModel.Range = value.Range.ToString();         
                this.CriterionFieldsViewModel.Weight = value.Weight.ToString();         
                this.CriterionFieldsViewModel.Type = value.Type;
                this.CriterionFieldsViewModel.OptimalValue = value.OptimalValue;         
                this.CriterionFieldsViewModel.Unit = value.Unit;
                this.CriterionFieldsViewModel.ScaleType = value.ScaleType;
            }
        }

        protected override void RefreshIsOkEnabled(object sender, PropertyChangedEventArgs e)
        {
            this.IsOkEnabled = !string.IsNullOrEmpty(this.CriterionFieldsViewModel.Name)
                            && !string.IsNullOrEmpty(this.CriterionFieldsViewModel.Range)
                            && !string.IsNullOrEmpty(this.CriterionFieldsViewModel.Weight)
                            && this.CriterionFieldsViewModel.Type != null
                            && this.CriterionFieldsViewModel.OptimalValue != null
                            && !string.IsNullOrEmpty(this.CriterionFieldsViewModel.Unit)
                            && this.CriterionFieldsViewModel.ScaleType != null;
        }
    }
}
