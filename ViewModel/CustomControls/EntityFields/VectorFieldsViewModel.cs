using System;
using System.Collections.Generic;
using Database.Repository;
using Model.Entity;

namespace ViewModel.CustomControls.EntityFields
{
    public class VectorFieldsViewModel : EntityFieldsViewModel
    {
        Alternative alternative;
        public Alternative Alternative
        {
            get
            {
                return this.alternative;
            }
            set
            {
                if (this.alternative == value)
                    return;

                this.alternative = value;
                this.OnPropertyChanged(nameof(this.Alternative));
            }
        }

        private List<Alternative> availableAlternatives;
        public List<Alternative> AvailableAlternatives => this.repository.GetAlternatives();

        private List<Mark> availableMarks;
        public List<Mark> AvailableMarks => this.repository.GetMarks();

        Mark mark;
        public Mark Mark
        {
            get
            {
                return this.mark;
            }
            set
            {
                if (this.mark == value)
                    return;

                this.mark = value;
                this.OnPropertyChanged(nameof(this.Mark));
            }
        }

        public override void RefreshComboboxLists()
        {
            this.availableAlternatives = this.repository.GetAlternatives();
            this.OnPropertyChanged(nameof(this.AvailableAlternatives));
            this.availableMarks = this.repository.GetMarks();
            this.OnPropertyChanged(nameof(this.AvailableMarks));
        }

        private VectorRepository repository;

        public VectorFieldsViewModel()
        {
            this.repository = new VectorRepository();
        }
    }
}
