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

                if (this.criterion == null)
                    return;

                var criterionRepo = new MarkRepository();
                this.availableMarks = criterionRepo.GetByCriterion(value);
                this.OnPropertyChanged(nameof(this.AvailableMarks));
            }
        }

        private List<Alternative> availableAlternatives;
        public List<Alternative> AvailableAlternatives => this.availableAlternatives ?? 
            (this.availableAlternatives = this.repository.GetAlternatives());

        private List<Criterion> availableCriteria;
        public List<Criterion> AvailableCriteria => this.availableCriteria ?? 
            (this.availableCriteria = this.repository.GetCriteria());

        private List<Mark> availableMarks;
        public List<Mark> AvailableMarks => this.availableMarks ?? 
            (this.availableMarks = this.repository.GetMarks());

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

            this.availableCriteria = this.repository.GetCriteria();
            this.OnPropertyChanged(nameof(this.AvailableCriteria));

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
