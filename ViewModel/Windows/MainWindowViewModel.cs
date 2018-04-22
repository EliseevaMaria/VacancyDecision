using System;
using ViewModel.Tabs;

namespace ViewModel
{
    public class MainWindowViewModel
    {
        public AlternativesTabViewModel Alternatives
        {
            set;
            get;
        }

        public CriteriaTabViewModel Criteria
        {
            set;
            get;
        }

        public ExpertsTabViewModel Experts
        {
            set;
            get;
        }

        public MarksTabViewModel Marks
        {
            set;
            get;
        }

        public MainWindowViewModel(ViewService entityTabViewService)
        {
            this.Alternatives = new AlternativesTabViewModel(entityTabViewService);
            this.Criteria = new CriteriaTabViewModel(entityTabViewService);
            this.Experts = new ExpertsTabViewModel(entityTabViewService);
            this.Marks = new MarksTabViewModel(entityTabViewService);
            this.Vectors = new VectorsTabViewModel(entityTabViewService);
        }

        public VectorsTabViewModel Vectors
        {
            set;
            get;
        }
    }
}
