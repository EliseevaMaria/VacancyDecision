using System;
using System.Collections.Generic;
using Database.Repository;
using Model.Entity;

namespace ViewModel.CustomControls.EntityFields
{
    public class MarkFieldsViewModel : EntityFieldsViewModel
    {
        private List<Criterion> availableCriteria;
        public List<Criterion> AvailableCriteria => this.availableCriteria ?? 
            (this.availableCriteria = this.repository.GetCriteria());

        Criterion criterion;
        public Criterion Criterion
        {
            get
            {
                return this.criterion;
            }
            set
            {
                if (this.criterion == value)
                    return;

                this.criterion = value;
                this.OnPropertyChanged(nameof(this.Criterion));
            }
        }

        public MarkFieldsViewModel()
        {
            this.repository = new MarkRepository();
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

        string normalizedValue;
        public string NormalizedValue
        {
            get
            {
                return this.normalizedValue;
            }
            set
            {
                if (this.normalizedValue == value)
                    return;

                this.normalizedValue = value;
                this.OnPropertyChanged(nameof(this.NormalizedValue));
            }
        }

        public override void RefreshComboboxLists()
        {
            this.availableCriteria = this.repository.GetCriteria();
            this.OnPropertyChanged(nameof(this.AvailableCriteria));
        }

        string quantitativeValue;
        public string QuantitativeValue
        {
            get
            {
                return this.quantitativeValue;
            }
            set
            {
                if (this.quantitativeValue == value)
                    return;

                this.quantitativeValue = value;
                this.OnPropertyChanged(nameof(this.QuantitativeValue));
            }
        }

        string rank;
        public string Rank
        {
            get
            {
                return this.rank;
            }
            set
            {
                if (this.rank == value)
                    return;

                this.rank = value;
                this.OnPropertyChanged(nameof(this.Rank));
            }
        }

        private MarkRepository repository;
    }
}
