using System;
using System.ComponentModel;
using Database.Repository;
using Model.Entity;
using ViewModel.CustomControls;
using ViewModel.CustomControls.EntityFields;
using ViewModel.Windows.CreateEditEntity;

namespace ViewModel.Tabs
{
    public class AlternativesTabViewModel : BaseEntityTabViewModel<Alternative>
    {
        public AlternativeFieldsViewModel AlternativeFieldsViewModel => 
            this.EntityFieldsViewModel as AlternativeFieldsViewModel;

        public AlternativesTabViewModel(ViewService viewService)
        {
            this.CreateEditViewModel = new СreateEditAlternativeViewModel();

            this.EntityFieldsViewModel = new AlternativeFieldsViewModel();
            this.EntityFieldsViewModel.PropertyChanged += this.RefreshClearFilterButtonEnabled;

            var repository = new AlternativeRepository();
            this.GridControlViewModel = new GridControlViewModel<Alternative>(repository);
            this.GridControlViewModel.PropertyChanged += this.RefreshIsRecordSelected;

            this.InteractionService = viewService;
        }

        public override void ClearFilter()
        {
            this.AlternativeFieldsViewModel.Name = string.Empty;

            this.GridControlViewModel.RefreshRecordList();
        }

        public override void CreateRecord()
        {
            this.CreateEditViewModel.Entity = new Alternative();
            base.CreateRecord();
        }

        public override void Filter()
        {
            string where = $@"WHERE {nameof(this.AlternativeFieldsViewModel.Name)} 
                              LIKE '%{this.AlternativeFieldsViewModel.Name}%'";
            this.GridControlViewModel.RefreshRecordList(where);
        }

        protected override void RefreshClearFilterButtonEnabled(object sender, PropertyChangedEventArgs e)
        {
            this.ClearFilterButtonEnabled = !string.IsNullOrEmpty(this.AlternativeFieldsViewModel.Name);
        }
    }
}
