using System;
using System.Collections.Generic;
using System.Linq;
using Database.Repository;
using Model;
using Model.Entity;

namespace ViewModel.Tabs
{
    public class ExpertComparisonViewModel : BaseViewModel
    {
        private Alternative alternative1;

        private Alternative alternative2;

        private AlternativeRepository alternativeRepository;

        private List<AlternativeToCompare> alternatives = new List<AlternativeToCompare>();

        private Alternative currentWinner;

        private List<Mark> marksForAlternative1;

        private List<Mark> marksForAlternative2;

        private MarkRepository markRepository;

        public Alternative Alternative1
        {
            get
            {
                return this.alternative1;
            }
            private set
            {
                if (this.alternative1 == value)
                    return;

                this.alternative1 = value;
                this.OnPropertyChanged(nameof(this.Alternative1));

                this.MarksForAlternative1 = this.markRepository.GetByAlternative(value);
            }
        }

        public Alternative Alternative2
        {
            get
            {
                return this.alternative2;
            }
            private set
            {
                if (this.alternative2 == value)
                    return;

                this.alternative2 = value;
                this.OnPropertyChanged(nameof(this.Alternative2));

                this.MarksForAlternative2 = this.markRepository.GetByAlternative(value);
            }
        }

        public void ContinueComparison()
        {
            this.GetNextComparisonPair();
            this.ComparisonStarted = true;
            this.OnPropertyChanged(nameof(this.ContinueComparisonAvailable));
        }

        private bool comparisonStarted;
        public bool ComparisonStarted
        {
            get
            {
                return this.comparisonStarted;
            }
            set
            {
                if (this.comparisonStarted == value)
                    return;

                this.comparisonStarted = value;
                this.OnPropertyChanged(nameof(this.ComparisonStarted));
            }
        }

        private Expert CurrentExpert
        {
            get;
            set;
        }

        public ExpertComparisonViewModel(ViewService viewService, Expert expert)
        {
            this.alternativeRepository = new AlternativeRepository();
            this.markRepository = new MarkRepository();
            this.InteractionService = viewService;

            this.CurrentExpert = expert;

            this.RefreshAlternatives();
            this.ComparisonStarted = false;
            this.OnPropertyChanged(nameof(this.ContinueComparisonAvailable));
        }

        public bool ContinueComparisonAvailable => !this.ComparisonStarted
            && this.currentWinner != null && this.alternatives.Any(alternative => !alternative.IsCompared);

        public string CurrentWinnerText => $"The current winner for {this.CurrentExpert}: " + (this.currentWinner?.Name ?? "-");

        public void GetNextComparisonPair()
        {
            var notCompared = this.alternatives.Where(alternatives => !alternatives.IsCompared).ToList();
            if (notCompared.Count() == 0)
            {
                if (this.currentWinner == null)
                    this.InteractionService.ProvideService(ViewService.ServiceId.ShowWarningServiceId,
                        "No alternatives to compare!");
                else
                    this.SetWinner();
                return;
            }

            if (this.currentWinner != null)
            {
                this.Alternative1 = this.currentWinner;
                this.Alternative2 = notCompared[0].Alternative;
                notCompared[0].IsCompared = true;
            }
            else
            {
                if (notCompared.Count > 1)
                {
                    this.Alternative1 = notCompared[0].Alternative;
                    notCompared[0].IsCompared = true;
                    this.Alternative2 = notCompared[1].Alternative;
                    notCompared[1].IsCompared = true;
                }
                else
                    this.SetWinner();
            }
        }

        public void MakeChoice(Alternative chosenAlternative)
        {
            if (chosenAlternative == null)
                return;

            this.currentWinner = chosenAlternative;
            this.OnPropertyChanged(nameof(CurrentWinnerText));

            this.GetNextComparisonPair();
        }

        public List<Mark> MarksForAlternative1
        {
            get
            {
                return this.marksForAlternative1;
            }
            set
            {
                if (this.marksForAlternative1 == value)
                    return;

                this.marksForAlternative1 = value;
                this.OnPropertyChanged(nameof(this.MarksForAlternative1));
            }
        }

        public List<Mark> MarksForAlternative2
        {
            get
            {
                return this.marksForAlternative2;
            }
            set
            {
                if (this.marksForAlternative2 == value)
                    return;

                this.marksForAlternative2 = value;
                this.OnPropertyChanged(nameof(this.MarksForAlternative2));
            }
        }

        public void RefreshAlternatives()
        {
            AlternativeToCompare[] alternativesToCompare = new AlternativeToCompare[this.alternatives.Count];
            this.alternatives.CopyTo(alternativesToCompare);
            this.alternatives.Clear();
            var alternativeEntities = alternativesToCompare.Select(a => a.Alternative).ToList();

            var alternatives = alternativeRepository.GetRecords();
            if (this.currentWinner != null && !alternatives.Any(a => a.Id == this.currentWinner.Id))
            {
                this.currentWinner = null;
                this.OnPropertyChanged(nameof(this.CurrentWinnerText));
            }

            alternatives.ForEach(alternative =>
            {
                int oldIndex = alternativeEntities.FindIndex(ae => ae.Id == alternative.Id);
                bool compared = false;
                if (oldIndex >= 0)
                    compared = alternativesToCompare[oldIndex].IsCompared;

                this.alternatives.Add(new AlternativeToCompare(alternative, compared));
            });

            this.ComparisonStarted = false;
            this.OnPropertyChanged(nameof(this.ContinueComparisonAvailable));
        }

        private void SetWinner()
        {
            this.InteractionService.ProvideService(ViewService.ServiceId.ShowInformationServiceId,
                $"The winner is '{this.currentWinner.Name}'!");
            this.ComparisonStarted = false;
        }

        public void StartFromBeginning()
        {
            this.currentWinner = null;
            this.OnPropertyChanged(nameof(this.CurrentWinnerText));

            this.alternatives.ForEach(a => a.IsCompared = false);
            this.GetNextComparisonPair();
            this.ComparisonStarted = true;
        }
    }
}
