using System;
using System.ComponentModel;
using Database.Repository;
using Model.Entity;
using ViewModel.CustomControls;
using ViewModel.CustomControls.EntityFields;
using ViewModel.Windows.CreateEditEntity;

namespace ViewModel.Tabs
{
    public sealed class ExpertsTabViewModel : BaseEntityTabViewModel<Expert>
    {
        public override void ClearFilter()
        {
            this.ExpertFieldsViewModel.Description = string.Empty;
            this.ExpertFieldsViewModel.Name = string.Empty;
            this.ExpertFieldsViewModel.Weight = null;

            this.GridControlViewModel.RefreshRecordList();
        }

        public override void CreateRecord()
        {
            this.CreateEditViewModel.Entity = new Expert();
            base.CreateRecord();
        }

        public ExpertFieldsViewModel ExpertFieldsViewModel => this.EntityFieldsViewModel as ExpertFieldsViewModel;

        public ExpertsTabViewModel(ViewService viewService)
        {
            this.CreateEditViewModel = new СreateEditExpertViewModel();

            this.EntityFieldsViewModel = new ExpertFieldsViewModel();
            this.EntityFieldsViewModel.PropertyChanged += this.RefreshClearFilterButtonEnabled;

            var repository = new ExpertRepository();
            this.GridControlViewModel = new GridControlViewModel<Expert>(repository);
            this.GridControlViewModel.PropertyChanged += this.RefreshIsRecordSelected;

            this.InteractionService = viewService;
        }

        public override void Filter()
        {
            string where = $@"WHERE {nameof(this.ExpertFieldsViewModel.Description)} LIKE '%{this.ExpertFieldsViewModel.Description}%'
                                AND {nameof(this.ExpertFieldsViewModel.Name)} LIKE '%{this.ExpertFieldsViewModel.Name}%'";
            
            if (this.ExpertFieldsViewModel.Weight != null)
                where += $@"AND {nameof(this.ExpertFieldsViewModel.Weight)} = 
                            {this.ExpertFieldsViewModel.Weight}";

            this.GridControlViewModel.RefreshRecordList(where);
        }

        protected override void RefreshClearFilterButtonEnabled(object sender, PropertyChangedEventArgs e)
        {
            this.ClearFilterButtonEnabled = !string.IsNullOrEmpty(this.ExpertFieldsViewModel.Description)
                                         || !string.IsNullOrEmpty(this.ExpertFieldsViewModel.Name)
                                         || this.ExpertFieldsViewModel.Weight != null;
        }
    }
}
