using System;
using Model.Entity;

namespace ViewModel.CustomControls.EntityFields
{
    public class ExpertFieldsViewModel : EntityFieldsViewModel
    {
        string description;
        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                if (this.description == value)
                    return;

                this.description = value;
                this.OnPropertyChanged(nameof(this.Description));
            }
        }

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

        string weight;
        public string Weight
        {
            get
            {
                return this.weight;
            }
            set
            {
                if (this.weight == value)
                    return;

                this.weight = value;
                this.OnPropertyChanged(nameof(this.Weight));
            }
        }
    }
}
