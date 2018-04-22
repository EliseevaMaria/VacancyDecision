using System;
using System.ComponentModel;
using Database.Repository;
using Model.Entity;
using ViewModel.CustomControls;
using ViewModel.CustomControls.EntityFields;
using ViewModel.Windows.CreateEditEntity;

namespace ViewModel.Tabs
{
    public class MarksTabViewModel : BaseEntityTabViewModel<Mark>
    {
        public MarksTabViewModel(ViewService viewService)
        {
            this.CreateEditViewModel = new СreateEditMarkViewModel();

            this.EntityFieldsViewModel = new MarkFieldsViewModel();
            this.EntityFieldsViewModel.PropertyChanged += this.RefreshClearFilterButtonEnabled;

            var repository = new MarkRepository();
            this.GridControlViewModel = new GridControlViewModel<Mark>(repository);
            this.GridControlViewModel.PropertyChanged += this.RefreshIsRecordSelected;

            this.InteractionService = viewService;
        }

        public override void ClearFilter()
        {
            this.MarkFieldsViewModel.Criterion = null;
            this.MarkFieldsViewModel.Name = string.Empty;
            this.MarkFieldsViewModel.NormalizedValue = null;
            this.MarkFieldsViewModel.QuantitativeValue = null;
            this.MarkFieldsViewModel.Rank = null;

            this.GridControlViewModel.RefreshRecordList();
        }

        public override void Filter()
        {
            string where = $@"WHERE Mark.{nameof(this.MarkFieldsViewModel.Name)} LIKE '%{this.MarkFieldsViewModel.Name}%'";

            if (this.MarkFieldsViewModel.Criterion != null)
                where += $" AND Mark.{nameof(this.MarkFieldsViewModel.Criterion)}Id = {this.MarkFieldsViewModel.Criterion.Id}";

            if (this.MarkFieldsViewModel.NormalizedValue != null)
                where += $" AND {nameof(this.MarkFieldsViewModel.NormalizedValue)} = {this.MarkFieldsViewModel.NormalizedValue}";

            if (this.MarkFieldsViewModel.QuantitativeValue != null)
                where += $" AND {nameof(this.MarkFieldsViewModel.QuantitativeValue)} = {this.MarkFieldsViewModel.QuantitativeValue}";

            if (this.MarkFieldsViewModel.Rank != null)
                where += $" AND Mark.{nameof(this.MarkFieldsViewModel.Rank)} = {this.MarkFieldsViewModel.Rank}";

            this.GridControlViewModel.RefreshRecordList(where);
        }

        public MarkFieldsViewModel MarkFieldsViewModel => EntityFieldsViewModel as MarkFieldsViewModel;

        protected override void RefreshClearFilterButtonEnabled(object sender, PropertyChangedEventArgs e)
        {
            this.ClearFilterButtonEnabled = this.MarkFieldsViewModel.Criterion != null
                                            || !string.IsNullOrEmpty(this.MarkFieldsViewModel.Name)
                                            || !string.IsNullOrEmpty(this.MarkFieldsViewModel.NormalizedValue)
                                            || !string.IsNullOrEmpty(this.MarkFieldsViewModel.QuantitativeValue)
                                            || !string.IsNullOrEmpty(this.MarkFieldsViewModel.Rank);
        }
    }
}
