using System;
using System.ComponentModel;
using Model.Entity;
using ViewModel.CustomControls.EntityFields;

namespace ViewModel.Windows.CreateEditEntity
{
    public sealed class СreateEditVectorViewModel : BaseCreateEditViewModel<Vector>
    {
        public СreateEditVectorViewModel()
        {
            this.EntityFieldsViewModel = new VectorFieldsViewModel();
            this.EntityFieldsViewModel.PropertyChanged += this.RefreshIsOkEnabled;
        }

        public override Vector Entity
        {
            get
            {
                entity.Alternative = this.VectorFieldsViewModel.Alternative;
                entity.Mark = this.VectorFieldsViewModel.Mark;
                return entity;
            }
            set
            {
                entity = value;
                this.VectorFieldsViewModel.Alternative = value.Alternative;
                this.VectorFieldsViewModel.Mark = value.Mark;             
            }
        }

        protected override void RefreshIsOkEnabled(object sender, PropertyChangedEventArgs e)
        {
            this.IsOkEnabled = this.VectorFieldsViewModel.Alternative != null
                            && this.VectorFieldsViewModel.Mark != null;
        }

        public VectorFieldsViewModel VectorFieldsViewModel => this.EntityFieldsViewModel as VectorFieldsViewModel;
    }
}
