using System;
using System.Collections.Generic;
using Database.Repository;
using Model.Entity;
using ViewModel.CustomControls;

namespace ViewModel.Tabs
{
    public class CollectiveComparisonTabViewModel : BaseViewModel
    {
        public bool ComparisonAvailable => this.SelectedExpertComparisonViewModel != null;

        public CollectiveComparisonTabViewModel(ViewService viewService)
        {
            this.InteractionService = viewService;

            var expertRepo = new ExpertRepository();
            this.ExpertGridControlViewModel = new GridControlViewModel<Expert>(expertRepo);
            this.ExpertGridControlViewModel.SelectedRecordChanged += this.SelectExpert;

            foreach (var expert in this.ExpertGridControlViewModel.RecordList)
                this.ExpertsComparing.Add(expert, new ExpertComparisonViewModel(viewService, expert));
        }

        private Dictionary<Expert, ExpertComparisonViewModel> expertsComparing;
        public Dictionary<Expert, ExpertComparisonViewModel> ExpertsComparing => this.expertsComparing ??
            (this.expertsComparing = new Dictionary<Expert, ExpertComparisonViewModel>());

        public GridControlViewModel<Expert> ExpertGridControlViewModel
        {
            get;
            set;
        }

        private void SelectExpert(object sender, EventArgs e)
        {
            this.SelectedExpertComparisonViewModel = this.ExpertsComparing[this.ExpertGridControlViewModel.SelectedRecord];
        }

        private ExpertComparisonViewModel selectedExpertComparisonViewModel;
        public ExpertComparisonViewModel SelectedExpertComparisonViewModel
        {
            get
            {
                return this.selectedExpertComparisonViewModel;
            }
            set
            {
                if (value == null)
                    return;

                this.selectedExpertComparisonViewModel = value;
                this.SelectedExpertComparisonViewModel.RefreshAlternatives();

                this.OnPropertyChanged(nameof(this.SelectedExpertComparisonViewModel));
                this.OnPropertyChanged(nameof(this.ComparisonAvailable));
            }
        }
    }
}
