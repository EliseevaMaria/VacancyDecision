using System;
using Model.Entity;

namespace ViewModel.CustomControls.EntityFields
{
    public class AlternativeFieldsViewModel : EntityFieldsViewModel
    {
        string name;
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (this.name == value)
                    return;

                this.name = value;
                this.OnPropertyChanged(nameof(this.Name));
            }
        }
    }
}
