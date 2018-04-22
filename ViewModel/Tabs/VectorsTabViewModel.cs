using System;
using System.ComponentModel;
using Database.Repository;
using Model.Entity;
using ViewModel.CustomControls;
using ViewModel.CustomControls.EntityFields;
using ViewModel.Windows.CreateEditEntity;

namespace ViewModel.Tabs
{
    public class VectorsTabViewModel : BaseEntityTabViewModel<Vector>
    {
        public override void ClearFilter()
        {
            this.VectorFieldsViewModel.Alternative = null;
            this.VectorFieldsViewModel.Mark = null;

            this.GridControlViewModel.RefreshRecordList();
        }

        public override void Filter()
        {
            string where = "";
            
            if (this.VectorFieldsViewModel.Alternative != null)
                where += $" AND Vector.{nameof(this.VectorFieldsViewModel.Alternative)}Id = {this.VectorFieldsViewModel.Alternative.Id}";

            if (this.VectorFieldsViewModel.Mark != null)
                where += $" AND Vector.{nameof(this.VectorFieldsViewModel.Mark)}Id = {this.VectorFieldsViewModel.Mark.Id}";

            this.GridControlViewModel.RefreshRecordList(where);
        }

        protected override void RefreshClearFilterButtonEnabled(object sender, PropertyChangedEventArgs e)
        {
            this.ClearFilterButtonEnabled = this.VectorFieldsViewModel.Alternative != null
                                            || this.VectorFieldsViewModel.Mark != null;
        }

        public VectorFieldsViewModel VectorFieldsViewModel => EntityFieldsViewModel as VectorFieldsViewModel;

        public VectorsTabViewModel(ViewService viewService)
        {
            this.CreateEditViewModel = new СreateEditVectorViewModel();

            this.EntityFieldsViewModel = new VectorFieldsViewModel();
            this.EntityFieldsViewModel.PropertyChanged += this.RefreshClearFilterButtonEnabled;

            var repository = new VectorRepository();
            this.GridControlViewModel = new GridControlViewModel<Vector>(repository);
            this.GridControlViewModel.PropertyChanged += this.RefreshIsRecordSelected;

            this.InteractionService = viewService;
        }
    }
}
