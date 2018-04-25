using System;
using ViewModel.Tabs;

namespace ViewModel
{
    public class MainWindowViewModel
    {
        public AlternativesTabViewModel AlternativesViewModel
        {
            set;
            get;
        }

        public ComparisonTabViewModel ComparisonTabViewModel
        {
            set;
            get;
        }

        public CriteriaTabViewModel CriteriaViewModel
        {
            set;
            get;
        }

        public ExpertsTabViewModel ExpertsViewModel
        {
            set;
            get;
        }

        public MarksTabViewModel MarksViewModel
        {
            set;
            get;
        }

        public MainWindowViewModel(ViewService entityTabViewService)
        {
            this.AlternativesViewModel = new AlternativesTabViewModel(entityTabViewService);
            this.CriteriaViewModel = new CriteriaTabViewModel(entityTabViewService);
            this.ExpertsViewModel = new ExpertsTabViewModel(entityTabViewService);
            this.MarksViewModel = new MarksTabViewModel(entityTabViewService);
            this.VectorsViewModel = new VectorsTabViewModel(entityTabViewService);
            this.ComparisonTabViewModel = new ComparisonTabViewModel(entityTabViewService);
        }

        public VectorsTabViewModel VectorsViewModel
        {
            set;
            get;
        }
    }
}
