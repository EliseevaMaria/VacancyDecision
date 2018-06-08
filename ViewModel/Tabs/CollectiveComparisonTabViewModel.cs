using System;
using System.Collections.Generic;
using System.Linq;
using Business;
using Database.Repository;
using Model;
using Model.Entity;
using ViewModel.CustomControls;

namespace ViewModel.Tabs
{
    public class CollectiveComparisonTabViewModel : BaseViewModel, IDisposable
    {
        private AlternativeRepository alternativeRepository;

        private ExpertRepository expertRepository;

        private bool AllChoicesMade => this.ExpertsComparing.All(expert => expert.Value.ChoiceIsMade);

        public CollectiveComparisonTabViewModel(ViewService viewService)
        {
            this.InteractionService = viewService;
            this.alternativeRepository = new AlternativeRepository();

            this.expertRepository = new ExpertRepository();
            this.ExpertGridControlViewModel = new GridControlViewModel<Expert>(this.expertRepository);
            this.ExpertGridControlViewModel.SelectedRecordChanged += this.SelectExpert;

            this.RefreshExpertGrid();
        }

        public bool ComparisonAvailable => this.SelectedExpertComparisonViewModel != null;

        private CondorcetComparison condorcetComparison;
        private CondorcetComparison CondorcetComparison => 
            this.condorcetComparison ?? (this.condorcetComparison = new CondorcetComparison());

        private Alternative condorcetWinner;
        private Alternative CondorcetWinner
        {
            get
            {
                return this.condorcetWinner;
            }
            set
            {
                if (this.condorcetWinner == value)
                    return;

                this.condorcetWinner = value;
                this.OnPropertyChanged(nameof(this.WinnerByCondorcetText));
            }
        }

        private Dictionary<Expert, ExpertComparisonViewModel> expertsComparing;
        public Dictionary<Expert, ExpertComparisonViewModel> ExpertsComparing => this.expertsComparing ??
            (this.expertsComparing = new Dictionary<Expert, ExpertComparisonViewModel>());

        public GridControlViewModel<Expert> ExpertGridControlViewModel
        {
            get;
            set;
        }

        public void Dispose()
        {
            this.ExpertGridControlViewModel.SelectedRecordChanged -= this.SelectExpert;
            foreach (var expertComparison in this.ExpertsComparing)
            {
                expertComparison.Value.ChoiceMade -= this.OnExpertChoiceMade;
                expertComparison.Value.ComparisonStartedEvent -= this.OnComparisonStarted;
            }
        }

        private void OnComparisonStarted(object sender, EventArgs e)
        {
            this.CondorcetWinner = null;
            this.SimpsonWinner = null;
        }

        private void OnExpertChoiceMade(object sender, EventArgs e)
        {
            if (this.AllChoicesMade)
            {
                List<CollectiveComparisonAlternativePair> pairs = 
                    this.ExpertsComparing.Values.SelectMany(x => x.AlternativePairs).ToList();

                this.CondorcetWinner = this.CondorcetComparison.Compare(pairs);
                this.SimpsonWinner = this.SimpsonComparison.Compare(pairs);
            }
        }

        public void RefreshAll()
        {
            this.RefreshExpertGrid();

            this.CondorcetWinner = null;
            this.SimpsonWinner = null;

            foreach (var comparisonViewModel in this.ExpertsComparing.Values)
            {
                comparisonViewModel.RefreshAlternatives();
            }
        }

        private void RefreshExpertGrid()
        {
            this.ExpertGridControlViewModel.RefreshRecordList();
            this.ExpertsComparing.Clear();
            foreach (var expert in this.ExpertGridControlViewModel.RecordList)
            {
                var expertComparison = new ExpertComparisonViewModel(this.InteractionService, expert);
                expertComparison.ChoiceMade += this.OnExpertChoiceMade;
                expertComparison.ComparisonStartedEvent += this.OnComparisonStarted;

                this.ExpertsComparing.Add(expert, expertComparison);
            }
            this.SelectedExpertComparisonViewModel = null;
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
                this.selectedExpertComparisonViewModel = value;

                this.OnPropertyChanged(nameof(this.SelectedExpertComparisonViewModel));
                this.OnPropertyChanged(nameof(this.ComparisonAvailable));
            }
        }

        private SimpsonComparison simpsonComparison;
        private SimpsonComparison SimpsonComparison =>
            this.simpsonComparison ?? (this.simpsonComparison = new SimpsonComparison());

        private Alternative simpsonWinner;
        private Alternative SimpsonWinner
        {
            get
            {
                return this.simpsonWinner;
            }
            set
            {
                if (this.simpsonWinner == value)
                    return;

                this.simpsonWinner = value;
                this.OnPropertyChanged(nameof(this.WinnerBySimpsonText));
            }
        }

        public string WinnerByCondorcetText
        {
            get
            {
                string result = "Condorcet's winner: ";
                if (this.CondorcetWinner == null)
                {
                    result += "-";
                    return result;
                }

                if (this.CondorcetWinner.Name.Length > 10)
                    result += string.Concat(this.CondorcetWinner.Name.Take(10)) + "...";
                else
                    result += this.CondorcetWinner.Name;

                return result;
            }
        }

        public string WinnerBySimpsonText
        {
            get
            {
                string result = "Simpson's winner: ";
                if (this.SimpsonWinner == null)
                {
                    result += "-";
                    return result;
                }

                if (this.SimpsonWinner.Name.Length > 10)
                    result += string.Concat(this.SimpsonWinner.Name.Take(10)) + "...";
                else
                    result += this.SimpsonWinner.Name;

                return result;
            }
        }
    }
}
