using System;
using System.ComponentModel;
using Database.Repository;
using Model.Entity;
using Model.Enumeration;
using ViewModel.CustomControls;
using ViewModel.CustomControls.EntityFields;
using ViewModel.Windows.CreateEditEntity;

namespace ViewModel.Tabs
{
    public class CriteriaTabViewModel : BaseEntityTabViewModel<Criterion>
    {
        public CriterionFieldsViewModel CriterionFieldsViewModel =>
            this.EntityFieldsViewModel as CriterionFieldsViewModel;

        public CriteriaTabViewModel(ViewService viewService)
        {
            this.CreateEditViewModel = new СreateEditCriterionViewModel();

            this.EntityFieldsViewModel = new CriterionFieldsViewModel();
            this.EntityFieldsViewModel.PropertyChanged += this.RefreshClearFilterButtonEnabled;

            var repository = new CriterionRepository();
            this.GridControlViewModel = new GridControlViewModel<Criterion>(repository);
            this.GridControlViewModel.PropertyChanged += this.RefreshIsRecordSelected;

            this.InteractionService = viewService;
        }

        public override void ClearFilter()
        {
            this.CriterionFieldsViewModel.Name = string.Empty;
            this.CriterionFieldsViewModel.Range = null;
            this.CriterionFieldsViewModel.Weight = null;
            this.CriterionFieldsViewModel.Type = null;
            this.CriterionFieldsViewModel.OptimalValue = null;
            this.CriterionFieldsViewModel.ScaleType = null;

            this.GridControlViewModel.RefreshRecordList();
        }

        public override void CreateRecord()
        {
            this.CreateEditViewModel.Entity = new Criterion();
            base.CreateRecord();
        }

        public override void Filter()
        {
            string where = $@"WHERE {nameof(this.CriterionFieldsViewModel.Name)} LIKE '%{this.CriterionFieldsViewModel.Name}%'
                                AND {nameof(this.CriterionFieldsViewModel.Unit)} LIKE '%{this.CriterionFieldsViewModel.Unit}%'";

            if (this.CriterionFieldsViewModel.Range != null)
                where += $@"AND {nameof(this.CriterionFieldsViewModel.Range)} = 
                            {(this.CriterionFieldsViewModel.Range)}";

            if (this.CriterionFieldsViewModel.Weight != null)
                where += $@"AND {nameof(this.CriterionFieldsViewModel.Weight)} = 
                            {(this.CriterionFieldsViewModel.Weight)}";

            if (this.CriterionFieldsViewModel.Type != null)
                where += $@"AND {nameof(this.CriterionFieldsViewModel.Type)} = 
                            {(byte)(this.CriterionFieldsViewModel.Type ?? CriterionType.Qualitative)}";

            if (this.CriterionFieldsViewModel.OptimalValue != null)
                where += $@"AND {nameof(this.CriterionFieldsViewModel.OptimalValue)} = 
                            {(byte)(this.CriterionFieldsViewModel.OptimalValue ?? CriterionOptimalValue.Maximum)}";

            if (this.CriterionFieldsViewModel.ScaleType != null)
                where += $@"AND {nameof(this.CriterionFieldsViewModel.ScaleType)} = 
                            {(byte)(this.CriterionFieldsViewModel.ScaleType ?? CriterionScaleType.Interval)}";

            this.GridControlViewModel.RefreshRecordList(where);
        }

        protected override void RefreshClearFilterButtonEnabled(object sender, PropertyChangedEventArgs e)
        {
            this.ClearFilterButtonEnabled = !string.IsNullOrEmpty(this.CriterionFieldsViewModel.Name)
                                            || !string.IsNullOrEmpty(this.CriterionFieldsViewModel.Range)
                                            || !string.IsNullOrEmpty(this.CriterionFieldsViewModel.Weight)
                                            || this.CriterionFieldsViewModel.Type != null
                                            || this.CriterionFieldsViewModel.OptimalValue != null
                                            || !string.IsNullOrEmpty(this.CriterionFieldsViewModel.Unit)
                                            || this.CriterionFieldsViewModel.ScaleType != null;
        }
    }
}
