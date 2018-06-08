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

        private int currentComparisonPairIndex = -1;

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

        public List<CollectiveComparisonAlternativePair> AlternativePairs
        {
            get;
            private set;
        }

        public bool CompareButtonVisible => !this.ComparisonStarted;

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
                this.OnPropertyChanged(nameof(this.CompareButtonVisible));

                if (this.comparisonStarted == true)
                    this.ComparisonStartedEvent?.Invoke(this, null);
            }
        }

        public event EventHandler ComparisonStartedEvent;

        private Expert CurrentExpert
        {
            get;
            set;
        }

        public string CurrentWinnerText => $"{this.CurrentExpert} has done all the choices";

        public ExpertComparisonViewModel(ViewService viewService, Expert expert)
        {
            this.alternativeRepository = new AlternativeRepository();
            this.markRepository = new MarkRepository();
            this.InteractionService = viewService;

            this.CurrentExpert = expert;

            this.AlternativePairs = new List<CollectiveComparisonAlternativePair>();
            this.RefreshAlternatives();
            this.ComparisonStarted = false;
        }

        public void GetNextComparisonPair()
        {
            this.currentComparisonPairIndex++;
            if (this.currentComparisonPairIndex < this.AlternativePairs.Count)
            {
                this.Alternative1 = this.AlternativePairs[this.currentComparisonPairIndex].Alternative1;
                this.Alternative2 = this.AlternativePairs[this.currentComparisonPairIndex].Alternative2;
            }
            else
                this.EndComparison();
        }

        public void MakeChoice(Alternative chosenAlternative)
        {
            if (chosenAlternative == null)
                return;

            this.AlternativePairs[this.currentComparisonPairIndex].Winner = chosenAlternative;
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
            var alternativesList = this.alternativeRepository.GetRecords();
            this.AlternativePairs.Clear();

            int diagonalIndex = 0;
            for (int j = 0; j < alternativesList.Count; j++, diagonalIndex++)
                for (int i = 0; i < diagonalIndex; i++) 
                    this.AlternativePairs.Add(new CollectiveComparisonAlternativePair(alternativesList[i], alternativesList[j]));

            this.currentComparisonPairIndex = -1;

            this.ComparisonStarted = false;
            this.ChoiceIsMade = false;
        }

        private void EndComparison()
        {
            this.InteractionService.ProvideService(ViewService.ServiceId.ShowInformationServiceId,
                $"All choices for {this.CurrentExpert} are done!");
            this.ComparisonStarted = false;
            this.ChoiceIsMade = true;
            this.ChoiceMade?.Invoke(this, null);
        }

        public event EventHandler ChoiceMade;

        private bool choiceIsMade;
        public bool ChoiceIsMade
        {
            get
            {
                return this.choiceIsMade;
            }
            set
            {
                if (this.choiceIsMade == value)
                    return;

                this.choiceIsMade = value;
                this.OnPropertyChanged(nameof(this.ChoiceIsMade));
            }
        }

        public void StartFromBeginning()
        {
            this.currentComparisonPairIndex = -1;

            this.AlternativePairs.ForEach(pair => pair.Winner = null);
            this.GetNextComparisonPair();
            this.ChoiceIsMade = false;
            this.ComparisonStarted = true;
        }
    }
}
